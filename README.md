# JiraPOC

Today the jiraPOCa will chirp.

![samplev3](http://sailormoonnews.com/wp-content/uploads/2018/10/sailor_moon_episode_1_tuxedo_mask_leaving_without_doing_anything.jpg)



****

## Installing

Clone this repo to a local folder.
> run commands in console: 
```sh
dotnet build
cd bin/Debug/net6.0
JiraPOC.Core.exe --help
```

## Usage:
  JiraPOC.Core [command] [\<use-template>] [options]

### Arguments
	<use-template>  This argument is a flag to use a template for descrition.

# Commands:

| Commands | Description |
| ------ | ------ |
| ticket \<use-template>  | Just create a sigle ticket |
| ticket-with-comment \<use-template> | Create a sigle ticket and comment |
|  ticket-with-file \<use-template> | Create a sigle ticket and  attach files |
|  full-ticket \<use-template> | Create a jira ticket, comment and attach files |

### Options

| Option | Description |
| ------ | ------ |
|-s, --summary <summary>| The summary or brief description of an issue or task in Jira. It is typically a short sentence or phrase that gives an idea of what the issue is about. [default: TESTE]|
|-d, --description <description> | The detailed description of an issue or task in Jira. It provides more information than the summary and is typically used to describe the problem or request in more detail. []|		
|-et, --epic-ticket <epic-ticket> (REQUIRED) | The epic ticket or issue in Jira. An epic is a large body of work that can be broken down into smaller tasks or issues. The epic ticket is used to track the progress of  the entire epic. []|
|-ti, --team-id <team-id> |The team ID in Jira. The team ID is used to identify a specific team in Jira, which can be useful for assigning tasks or issues to specific teams. [default: 720]|
|-an, --assignee-name <assignee-name> |The name of the person who is assigned to work on a task or issue in Jira. The assignee is responsible for completing the work and is typically notified when the task or issue is assigned to them. [] |
|-pn, --priority-name <priority-name> | The priority level of a task or issue in Jira. Priority levels can range from low to critical and are used to indicate the importance of the issue or task. [default: High] |
|-l, --labels <labels>  | The labels associated with a task or issue in Jira. Labels are used to categorize and organize issues and can be used to search for specific issues based on certain criteria. [] |
|-it, --issue-type <issue-type>  | The type of issue or task in Jira. Issue types can include things like bug, task, story, or epic, and are used to categorize and organize issues. [default: 1] |
|-cn, --component-name <component-name> | The components associated with a task or issue in Jira. Components are used to categorize issues based on their functionality or location within a system. []|
|-vn, --version-name <version-name>| The version of software associated with a task or issue.  in Jira. [] |
|-pi, --project-id <project-id> |The project in Jira. Projects are used to organize issues and tasks based on their purpose or area of focus. [default: 21515] |
|-c, --comment <comment> | The comments associated with a task or issue in Jira. Comments can be used to provide additional information or context about an issue, or to communicate with other team members. []|
|-fp, --file-path <file-path> | The file attachments associated with a task or issue in Jira. Files can be attached to provide additional information or to share documents or other resources with team members. []|
|-jt, --jira-token <jira-token> (REQUIRED) | The Jira API token. The API token is used to authenticate API requests and provides a secure way to access Jira data. [] |	
|-ju, --jira-url <jira-url> (REQUIRED) |The base URL of the Jira instance. The base URL is used to access Jira. []|	
|-do, --description-objective <description-objective>  | The objective of ticket [] |	
| -da, --description-assumptions <description-assumptions>| The assumptions of ticket. It's a array pass e.g: ('-da "My assumption" -da" My assumption two" -da" My tree ") []|	
|-dpd, --description-pre-dep <description-pre-dep> |The prerequisites and dependecies of ticket. It's a array pass e.g: ('-dpd "My requisite" -dpd" My requisite two" -dpd" My tree ") [] |	
| -dd, --description-deliverables <description-deliverables>| The deliverables of ticket. It's a array pass e.g: ('-dd "My deliverable" -dd" My deliverable two" -dd" My tree ") [] |	
|-dac, --description-acceptance-criteria <description-acceptance-criteria>  | The acceptance criteria of ticket. It's a array pass with e.g: ('-dac "My acceptance" -dac"My acceptance two" -dac" My tree ") []|
| -dai, --description-additional-informations <description-additional-informations> |  The additional informations of ticket. It's a array pass e.g: ('-dai "My dditional informations" -dai "My dditional informations two " -dai" My tree ") [] |											  
|--version |Show version information |
|-?, -h, --help | Show help and usage information |





