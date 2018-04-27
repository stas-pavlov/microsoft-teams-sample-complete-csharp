<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tab.aspx.cs" Inherits="Microsoft.Teams.TemplateBotCSharp.src.tab.tab" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src='https://statics.teams.microsoft.com/sdk/v1.0/js/MicrosoftTeams.min.js'></script>
    <script src='https://code.jquery.com/jquery-1.11.3.min.js'></script>
     <script>
        var microsoftTeams;

        // Set up the tab and stuff.
         microsoftTeams.initialize();

        
     </script>
</head>
<body>
    <div id="content" runat="server" />
 </body>
</html>
