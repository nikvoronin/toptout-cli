import json
import requests
import os.path
import re
import argparse

def download_json(url : str):
    raw_json = ''
    r = requests.get(url, stream=True)
    if r.status_code == 200:
        for chunk in r.iter_content(32768, decode_unicode=True):
            # TODO to control maximum downloaded size
            raw_json += chunk
    else:
        return None

    return json.loads(raw_json)

def get_data_url(app_id : str) -> str:
    return f'https://raw.githubusercontent.com/{GITHUB_USER_REPO_PAIR}/master/data/{app_id}.json'

def github_get_data_url() -> str:
    r = requests.get(GITHUB_REPOTREE_MAIN_URL)
    if r.status_code != 200: return None
    
    gh_master_tree = r.json()
    for blob in gh_master_tree['tree']:
        if blob['path'] == 'data': return blob['url']

    return None

def github_get_json_file_list(github_data_url : str) -> list:
    r = requests.get(github_data_url)
    if r.status_code != 200: return None
    
    gh_files_tree = r.json()
    json_files_list = [blob['path'][:-5] for blob in gh_files_tree['tree'] if blob['path'].endswith('.json')]

    return json_files_list


def get_apps_list() -> dict:
    apps = {}
    
    gh_data_url = github_get_data_url()
    apps = { k:None for k in github_get_json_file_list(gh_data_url) }

    return apps

def update():
    apps = get_apps_list()

    for app_id in apps:
        try:
            print(f'{app_id}... ', end='')
            apps[app_id] = download_json(get_data_url(app_id))
            print('OK')
        except:
            apps[app_id] = None
            print( f'ERROR' )
    print()

    with open(DB_FILENAME, 'w') as f:
        json.dump(apps, f)

def db_file_exists():
    return os.path.isfile(f'./{DB_FILENAME}')

def user_options_file_exists():
    return os.path.isfile(f'./{USER_OPTIONS_FILENAME}')

def load_apps():
    with open(DB_FILENAME, 'r') as f:
        apps = json.load(f)
    
    return apps

def save_rules(rules : dict):
    with open(USER_OPTIONS_FILENAME, 'w') as f:
        for app_id, rule in rules.items():
            f.write(f'[{rule}] {app_id}\n')

def load_parse_rules() -> dict:
    rules = {}
    with open(USER_OPTIONS_FILENAME, 'r') as f:
        while True:
            line = f.readline()
            if not line: break

            match = re.search(r"^\s*[|\[\(\{]([+-_.\s])[|\}\)\]]\s+(.*)$", line)
            if match: rules[match.group(2)] = match.group(1)
    
    return rules

def process_rules(apps) -> dict:
    if user_options_file_exists():
        rules = load_parse_rules()
    else:
        rules = {}

    to_update = False
    for app in apps:
        if app not in rules:
            rules[app] = '-'
            to_update = True

    if to_update:
        save_rules(rules)

    return rules

DB_FILENAME = 'toptout.json'
USER_OPTIONS_FILENAME = 'user-options.txt'
GITHUB_USER_REPO_PAIR = 'beatcracker/toptout'
GITHUB_REPOTREE_MAIN_URL = f'https://api.github.com/repos/{GITHUB_USER_REPO_PAIR}/git/trees/master'


if __name__ == '__main__':
    print('Toptout-cli 0.1.0-alpha')

    parser = argparse.ArgumentParser(description='Easily opt-out from telemetry collection.')
    parser.add_argument('-u', '--update', '--force', action='store_true', required=False, help='download and update local database')

    args = parser.parse_args()

    if args.update:
        update()

    if db_file_exists():
        apps = load_apps()
        rules = process_rules(apps)
        # restr = apps['atom']["telemetry"][0]["target"]["plain_file"]["scope"]["user"]["selector"]
        # res = re.match(restr, '')
    else:
        print( '[!] Warning. Can not find local database. Use the `--force`, Luke.\n' )
        parser.print_help()
