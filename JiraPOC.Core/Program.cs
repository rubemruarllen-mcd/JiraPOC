using System.CommandLine;
using JiraPOC.Core.Commands;
using JiraPOC.Core.Models.Payloads;
using JiraPOC.Models;
using JiraPOC.Services;

namespace scl;

class Program
{
    public static List<Option> cmOpt = new List<Option>();
    public static Dictionary<string,Option> _optionIndex = new Dictionary<string, Option>();

    static async Task Main(string[] args)
    {

        var template = new Argument<bool>(name: "use-template", "This argument is a flag to use a template for description. " +
            "If true please pass the flgas ()");
        var rootCommand = new RootCommand("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=[ Welcome to the JiraPOC ]=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-" +
            "\nThis application create jira's tickets, comment and attach files");
        var subCommand1 = new Command("ticket", "Just create a sigle ticket");
        var subCommand2 = new Command("ticket-with-comment", "Create a sigle ticket and comment");
        var subCommand3 = new Command("ticket-with-file", "Create a sigle ticket and  attach files");
        var subCommand4 = new Command("full-ticket", "Create a jira ticket, comment and attach files");


        subCommand1.Add(template);
        subCommand2.Add(template);
        subCommand3.Add(template);
        subCommand4.Add(template);
        rootCommand.Add(template);
        rootCommand.Add(subCommand1);
        rootCommand.Add(subCommand2);
        rootCommand.Add(subCommand3);
        rootCommand.Add(subCommand4);
        rootCommand.AddOpions();

        rootCommand.Options.ToList().ForEach(_ =>
        {
            _optionIndex.Add(_.Name, _);
        });

        rootCommand.SetHandler(() => { });

        subCommand1.SetHandler(async (arg) =>
        {
            var jiraTicket = new JiraTicket(arg, template);
            var createPayload = new Ticket(jiraTicket.EpicTicket!, jiraTicket.AssigneeName, jiraTicket.ComponentNames, jiraTicket.TeamId, jiraTicket.Description,
                jiraTicket.IssueType, jiraTicket.Labels, jiraTicket.PriorityName, jiraTicket.ProjectId, jiraTicket.Summary, jiraTicket.VersionsNames);

            var ticket = await Jira.CreateNewTicket(jiraTicket.JiraBaseUrl!, jiraTicket.JiraToken!, createPayload);
        });

        subCommand2.SetHandler(async (arg) =>
        {
            var jiraTicket = new JiraTicket(arg, template);
            var createPayload = new Ticket(jiraTicket.EpicTicket!, jiraTicket.AssigneeName, jiraTicket.ComponentNames, jiraTicket.TeamId, jiraTicket.Description,
                jiraTicket.IssueType, jiraTicket.Labels, jiraTicket.PriorityName, jiraTicket.ProjectId, jiraTicket.Summary, jiraTicket.VersionsNames);

            var ticket = await Jira.CreateNewTicket(jiraTicket.JiraBaseUrl!, jiraTicket.JiraToken!, createPayload);
            await Jira.CreateNewComment(jiraTicket.JiraBaseUrl!, jiraTicket.JiraToken!, ticket!.id, new Comment() { body = jiraTicket.Comment! });
        });

        subCommand3.SetHandler(async (arg) =>
        {
            var jiraTicket = new JiraTicket(arg, template);
            var createPayload = new Ticket(jiraTicket.EpicTicket!, jiraTicket.AssigneeName, jiraTicket.ComponentNames, jiraTicket.TeamId, jiraTicket.Description,
                jiraTicket.IssueType, jiraTicket.Labels, jiraTicket.PriorityName, jiraTicket.ProjectId, jiraTicket.Summary, jiraTicket.VersionsNames);

            var ticket = await Jira.CreateNewTicket(jiraTicket.JiraBaseUrl!, jiraTicket.JiraToken!, createPayload);
            await Jira.CreateNewAttchament(jiraTicket.JiraBaseUrl!, jiraTicket.JiraToken!, ticket!.id, jiraTicket.FilePaths!);
        });

        subCommand4.SetHandler(async (arg) =>
        {
            var jiraTicket = new JiraTicket(arg, template);
            var createPayload = new Ticket(jiraTicket.EpicTicket!, jiraTicket.AssigneeName, jiraTicket.ComponentNames, jiraTicket.TeamId, jiraTicket.Description,
                jiraTicket.IssueType, jiraTicket.Labels, jiraTicket.PriorityName, jiraTicket.ProjectId, jiraTicket.Summary, jiraTicket.VersionsNames);

            var ticket = await Jira.CreateNewTicket(jiraTicket.JiraBaseUrl!, jiraTicket.JiraToken!, createPayload);
            await Jira.CreateNewComment(jiraTicket.JiraBaseUrl!, jiraTicket.JiraToken!, ticket!.id, new Comment() { body = jiraTicket.Comment! });
            await Jira.CreateNewAttchament(jiraTicket.JiraBaseUrl!, jiraTicket.JiraToken!, ticket!.id, jiraTicket.FilePaths!);

        });

        await rootCommand.InvokeAsync(args);
    }
}