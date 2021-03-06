﻿using FluentResults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToptoutCli
{
    public class UserOptions
    {
        public Dictionary<string, OptionPair> Rules = new();
        string _userOptionsFilename;

        public UserOptions(string userOptionsFilename)
        {
            _userOptionsFilename = userOptionsFilename;
        }

        public void AddDefaultRule(string appId)
        {
            Rules.Add(appId, ToOptionPair(Option.TOptOut));
        }

        public void LoadFromFile(string filename = null)
        {
            using var f = File.OpenRead(filename ?? _userOptionsFilename);
            using var reader = (TextReader)new StreamReader(f);
            string line = null;
            while ((line = reader.ReadLine()) != null) {
                var result = MatchLine(line);
                if (result.IsSuccess) {
                    (string appId, string sym) = result.Value;
                    Rules.Add(appId, ToOptionPair(sym));
                }
            }
        }

        public void SaveRules(string filename = null)
        {
            using var f = File.OpenWrite(filename ?? _userOptionsFilename);
            using var writer = (TextWriter) new StreamWriter(f);
            foreach(var appId in Rules.Keys)
                writer.WriteLine( FormatRule(appId, Rules[appId]) );
        }

        public static string FormatRule(string appId, OptionPair option) => $"[{option.Symbol}] {appId}";

        public static Result<(string, string)> MatchLine(string line)
        {
            var regex = new Regex(@"^\s*[|\[\(\{]([+-_.\s])[|\}\)\]]\s+(.*)$");
            MatchCollection matches = regex.Matches(line);

            return matches.Count == 1
                ? Result.Ok((matches[0].Groups[1].Value, matches[0].Groups[2].Value))
                : Result.Fail("No matches");
        }

        public static OptionPair ToOptionPair(string symbol) {
            var opt = symbol switch {
                "-" => Option.TOptOut,
                "+" => Option.TelemetryOn,
                  _ => Option.Ignore
            };

            return new OptionPair() { Symbol = symbol, Value = opt };
        }

        public static OptionPair ToOptionPair(Option option)
        {
            var symbol = option switch {
                Option.TOptOut => "-",
                Option.TelemetryOn => "+",
                _ => "_"
            };

            return new OptionPair() { Symbol = symbol, Value = option };
        }

        public enum Option { TOptOut, TelemetryOn, Ignore }

        public record OptionPair
        {
            public Option Value;
            public string Symbol;
        }
    }
}
