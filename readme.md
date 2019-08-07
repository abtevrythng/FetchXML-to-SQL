# DEPRECATED
- I don't have access to Dynamics CRM anymore.
- Feel free to fork the project and take over.

⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️

## Convert fetchXML to SQL 
![FetchXML2SQL in Action](/FetchXML2SQLv2/screenshots/mainwindow.png)
## Synopsis
> This is a work in progress...

This tool is born out of the need to convert Microsoft Dynamics CRM generated fetchXML to SQL queries. Although you can get it by running profiler on SQL server. But this tool does it without the need for a SQL server.

[Download Now](https://github.com/abtevrythng/FetchXML-to-SQL/releases/download/1.0.0/FetchXML2SQLv2.zip)

### How it works
It just parse the fetchXML file and creates SQL statements based on the input, just like we humans do when we manually convert fetchXML to SQL.

### Whats missing from the first release
1. Most of the operators such as this-month, next-month, last-year, etc. Planned to be included in the next release.
2. Nested filters in fetchXML such as 
  <filter type="and"><filter type="or"><condition attribute="createdon" operator="on-or-before" value="@Enddate" /><condition attribute="caseorigincode" operator="ne" value="3" /><filter type="or"><condition attribute="createdon" operator="on-or-before" value="@NEWEnddate" /><condition attribute="caseorigincode" operator="ne" value="4" /></filter></filter></filter>
3. You tell me! Please add some issues to work on.

⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️⛔️
