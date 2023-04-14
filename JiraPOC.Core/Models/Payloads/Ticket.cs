using JiraPOC.Models.CreateTicket;

namespace JiraPOC.Core.Models.Payloads
{
    public class Ticket
    {
        public Fields fields { get; set; }
        public Ticket(string epicTicket, string? assignee, List<string>? components, string? team, string? description, string? issuetype,
             List<string>? labels, string? priority, string? project, string? summary, List<string>? versions)
        {

            fields = new Fields()
            {
                customfield_10006 = epicTicket,
            };

            if (!string.IsNullOrEmpty(assignee)) fields.assignee = new Assignee() { name = assignee };
            if (components != null) fields.components = components.Select(c => new Component() { name = c }).ToArray();
            if (!string.IsNullOrEmpty(team)) fields.customfield_13411 = team;
            if (!string.IsNullOrEmpty(description)) fields.description = description;
            if (!string.IsNullOrEmpty(issuetype)) fields.issuetype = new Issuetype() { id = issuetype };
            if (labels != null) fields.labels = labels;
            if (!string.IsNullOrEmpty(priority)) fields.priority = new Priority() { name = priority };
            if (!string.IsNullOrEmpty(project)) fields.project = new Project() { id = project };
            if (!string.IsNullOrEmpty(summary)) fields.summary = summary;
            if (versions != null) fields.versions = versions.Select(v => new JiraPOC.Models.CreateTicket.Version() { name = v }).ToArray();
        }
    }

}
