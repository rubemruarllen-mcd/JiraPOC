using System.Security.AccessControl;

namespace JiraPOC.Core.Models
{
    public class Description
    {
        public string Value
        {
            get
            {
                return string.Concat(ObjectiveTitle,  AssumptionsTitles, PrerequisitesTitle, DeliverablesTitle,  AcceptanceTitle,  AdditionalTitle);
            }
        }
        public string ObjectiveTitle { get; private set; } = "+*Objective*+";
        public string AssumptionsTitles { get; private set; } = "\n\n+*Assumptions*+";
        public string PrerequisitesTitle { get; private set; } = "\n\n+*Prerequisites/Dependencies*+";
        public string DeliverablesTitle { get; private set; } = "\n\n+*Deliverables*+";
        public string AcceptanceTitle { get; private set; } = "\n\n+*Acceptance Criteria*+";
        public string AdditionalTitle { get; private set; } = "\n\n+*Additional Information*";

        public void AddObjective(string? objective = null)
        {
            objective = objective == null ? "\r\n * N/A " : objective;
            ObjectiveTitle = string.Concat(ObjectiveTitle, $"\r\n * {objective}");
        }

        public void AddAssumption(List<string>? assumptions = null)
        {
            if (assumptions == null)
                AssumptionsTitles += "\r\n * N/A ";
            else
                assumptions!.ForEach(a => { AssumptionsTitles = string.Concat(AssumptionsTitles,  $"\r\n * {a}"); });
        }

        public void AddPrerequisites(List<string>? prerequisitesDependecies = null)
        {
            if (prerequisitesDependecies == null)
                PrerequisitesTitle += "\r\n * N/A ";
            else
                prerequisitesDependecies!.ForEach(a => { PrerequisitesTitle = string.Concat(PrerequisitesTitle,  $"\r\n * {a}"); });
        }

        public void AddDeliverables(List<string>? deliverables = null)
        {
            if (deliverables == null)
                DeliverablesTitle += "\r\n * N/A ";
            else
                deliverables!.ForEach(a => { DeliverablesTitle = string.Concat(DeliverablesTitle,  $"\r\n # {a}"); });
        }

        public void AddAcceptance(List<string>? acceptances = null)
        {
            if (acceptances == null)
                AcceptanceTitle += "\r\n * N/A ";
            else
                acceptances!.ForEach(a => { AcceptanceTitle = string.Concat(AcceptanceTitle,  $"\r\n * {a}"); });
        }

        public void AddAdditional(List<string>? additional = null)
        {
            if (additional == null)
                AdditionalTitle += "\r\n * N/A ";
            else
                additional!.ForEach(a => { AdditionalTitle = string.Concat(AdditionalTitle,  $"\r\n * {a}"); });
        }
    }
}
