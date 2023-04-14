using JiraPOC.Core.Models;
using scl;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JiraPOC.Core.Commands
{
    public static class Options
    {
        public static void AddOpions(this RootCommand command)
        {
            string fileName = "Commands\\options.json";
            string jsonString = File.ReadAllText(fileName);
            var options = JsonSerializer.Deserialize<CommandOptions>(jsonString);

            options.options.ForEach(option =>
            {
                var op = new Option<string>(name: option.name,
                    description: option.description,
                    getDefaultValue: () => option.defaultValue)
                {
                    IsRequired = option.isRequired,
                    AllowMultipleArgumentsPerToken = option.multipleArgs,
                };

                option.defaultValue = option.defaultValue;
                option.alias.ForEach(a => {
                    op.AddAlias(a);
                    }
                );

                command.AddGlobalOption(op);
                Program.cmOpt.Add(op) ;
            });
        }
    }
}
