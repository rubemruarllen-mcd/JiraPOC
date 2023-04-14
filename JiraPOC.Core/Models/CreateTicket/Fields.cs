namespace JiraPOC.Models.CreateTicket
{
    public class Fields
    {
        public Assignee? assignee { get; set; }
        public Component[]? components { get; set; }
        /// <summary>
        /// Customfield_10006 is the epic.
        /// </summary>
        public string customfield_10006 { get; set; }
        /// <summary>
        /// customfield_13411 is team.
        /// </summary>
        public string customfield_13411 { get; set; } = "720"; // default value is 720 (REST | NPOSTRAN2 | 0 Generic Team")
        public string? description { get; set; }
        public Issuetype issuetype { get; set; } = new Issuetype();
        public List<string>? labels { get; set; }
        public Priority? priority { get; set; }
        public Project project { get; set; } = new Project();
        public string? summary { get; set; }
        public Version[]? versions { get; set; }
    }
}
