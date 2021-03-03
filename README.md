# [Toptout](https://github.com/beatcracker/toptout) --command line interactive

Read more at [Toptout](https://github.com/beatcracker/toptout)

> In a draft state!

## Requirements

- python 3
  - argparser
  - json
  - requests
  - win32 (registry)

## Command Line Parameters

### Turn Off Telemetry

`toptout-cli`

Show recommends about `update` if it cannot find local db file `toptout.json`.
Ignore list and options are in the [user-options.txt](#useroptions)

### Update

- `toptout-cli -u`
- `toptout-cli --update`
- `toptout-cli --force`

Download `.json` datas from `https://github.com/beatcracker/toptout/tree/master/data` and consolidate it in a local db. Also creates the `user-options` file.

### ¿ Revert / Undo ?

- `toptout-cli -r`
- `toptout-cli --revert`
- `toptout-cli --undo`

`?` Revert or undoing all changes

### Print Help

- `toptout-cli -h`
- `toptout-cli --help`

### Diagnostics

print, show, dry, list, ...

## user.options

1. `+-.` without spaces. But some symbols can appear, like parenthesis [], (), }}.
   - `+` turn _tm_ on
   - `-` switch _tm_ off
   - `_`, `' '` , `.` do nothing or ignore. Default behavior. `¿¿¿ [] [ ] = [.] ???`
2. Any spacers like space or tab
3. Name of the module

```plain
[-] switch telemetry off
[+] turn telemetry back again

[-] name of the module
[+] name of the module 2
[.] ignore opts for module_name_3
[ ] do nothing for module_that_called_four
[_] still do nothing mod-5
... ...
[-] name of the module N
```
