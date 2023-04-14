
using JiraPOC.Core.Models;
using scl;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;

namespace JiraPOC.Models
{
    public class JiraTicket
    {
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? EpicTicket { get; set; }
        public string? TeamId { get; set; }
        public string? AssigneeName { get; set; }
        public string? PriorityName { get; set; }
        public List<string>? Labels { get; set; }
        public string? IssueType { get; set; }
        public List<string>? ComponentNames { get; set; }
        public List<string>? VersionsNames { get; set; }
        public string? ProjectId { get; set; }
        public string? Comment { get; set; }
        public List<string>? FilePaths { get; set; }
        public string? JiraToken { get; set; }
        public string? JiraBaseUrl { get; set; }

        public List<string> DescriptionTemplate { get; set; }

        public JiraTicket(InvocationContext context, Argument<bool> template)
        {

            var descrip = new Description();
            // var on = context.ParseResult.GetValueForOption()
            var commandResult = context.ParseResult.CommandResult.Children.ToList();

            //context.ParseResult.GetValueForOption();

            commandResult.ForEach(c =>
            {
                var name = c.Symbol.Name;
                var tokens = c.Tokens;

                switch (name)
                {
                    case "summary":
                        Summary = GetTokenValue(tokens, name, context);
                        break;
                    case "description":
                        Description = GetTokenValue(tokens, name, context);
                        break;
                    case "epic-ticket":
                        EpicTicket = GetTokenValue(tokens, name, context);
                        break;
                    case "team-id":
                        TeamId = GetTokenValue(tokens, name, context);
                        break;
                    case "assignee-name":
                        AssigneeName = GetTokenValue(tokens, name, context);
                        break;
                    case "priority-name":
                        PriorityName = GetTokenValue(tokens, name, context);
                        break;
                    case "labels":
                        Labels = GetTokenValues(tokens, name, context);
                        break;
                    case "issue-type":
                        IssueType = GetTokenValue(tokens, name, context);
                        break;
                    case "component-name":
                        ComponentNames = GetTokenValues(tokens, name, context);
                        break;
                    case "version-name":
                        VersionsNames = GetTokenValues(tokens, name, context);
                        break;
                    case "project-id":
                        ProjectId = GetTokenValue(tokens, name, context);
                        break;
                    case "comment":
                        Comment = GetTokenValue(tokens, name, context);
                        break;
                    case "file-path":
                        FilePaths = GetTokenValues(tokens, name, context);
                        break;
                    case "jira-token":
                        JiraToken = GetTokenValue(tokens, name, context);
                        break;
                    case "jira-url":
                        JiraBaseUrl = GetTokenValue(tokens, name, context);
                        break;
                    case "description-objective":
                        descrip.AddObjective(GetTokenValue(tokens, name, context));
                        break;
                    case "description-assumptions":
                        descrip.AddAssumption();
                        break;
                    case "description-pre-dep":
                        descrip.AddPrerequisites(GetTokenValues(tokens, name, context));
                        break;
                    case "description-deliverables":
                        descrip.AddDeliverables(GetTokenValues(tokens, name, context));
                        break;
                    case "description-acceptance-criteria":
                        descrip.AddAcceptance(GetTokenValues(tokens, name, context));
                        break;
                    case "description-additional-informations":
                        descrip.AddAdditional(GetTokenValues(tokens, name, context));
                        break;
                }
            });

            var useTemplate = context.ParseResult.FindResultFor(template)?.Tokens[0].Value == "true";

            Description = useTemplate ? descrip.Value : Description;
        }
        public string? GetTokenValue(IReadOnlyList<Token> tokens, string name, InvocationContext context) => tokens.Any() ? tokens[0].Value : GetDefaultValue(context, name);

        public List<string>? GetTokenValues(IReadOnlyList<Token> tokens, string name, InvocationContext context) => tokens.Any() ?
               tokens.Select(_ => _.Value).ToList() : new List<string>() { GetDefaultValue(context, name) };

        public string? GetDefaultValue(InvocationContext context, string name) => context?.ParseResult?.GetValueForOption(Program._optionIndex[name])?.ToString();

        public string? GetValueByFlag(List<string> commands, string flag)
        {
            var value = commands.SkipWhile(c => c.ToLower() != flag.ToLower()).Skip(1).FirstOrDefault();
            return value;
        }

    }
}
