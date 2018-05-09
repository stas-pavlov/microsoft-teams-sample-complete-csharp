using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Collections.Generic;


using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

using Microsoft.Graph;


namespace Microsoft.Teams.TemplateBotCSharp.src.tab
{
    public partial class tab : System.Web.UI.Page
    {

        public static TriviaApi triviaApi = null;
        public static string token = String.Empty;
        public static GraphServiceClient graphClient = null;
        public static Dictionary<Guid, string> pictures = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (triviaApi == null)
                triviaApi = new IO.Swagger.Api.TriviaApi();

            if (pictures == null)
                pictures = new Dictionary<Guid, string>();

           var pretoken = Request.QueryString["token"];

            if (pretoken != null && token == String.Empty)
            { 
                token = pretoken.ToString();
                if (graphClient == null)
                {
                    graphClient = new GraphServiceClient(
                    "https://graph.microsoft.com/v1.0",
                    new DelegateAuthenticationProvider(
                        (requestMessage) =>
                        {
                            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
                            return Task.FromResult(0);

                        }));
                    
                }
            }


            if (!IsPostBack)
            {

                var teamId = Request.QueryString["teamId"];
                var channelId = Request.QueryString["channelId"];
                var locale = Request.QueryString["locale"];
                var theme = Request.QueryString["theme"];
                var entityId = Request.QueryString["entityId"];
                var subEntityId = Request.QueryString["subEntityId"];
                var upn = Request.QueryString["upn"];
                var tid = Request.QueryString["tid"];
                var groupId = Request.QueryString["groupId"];

                var html = "<table>";

                if (entityId != null)
                {
                    if (entityId.ToString() == "team")
                    {
                        TeamsContextModel tcm = new TeamsContextModel();
                        tcm.ChannelId = channelId.ToString();
                        tcm.EntityId = entityId.ToString();
                        tcm.GroupId = new System.Guid(groupId.ToString());
                        tcm.Locale = locale.ToString();
                        tcm.SubEntityId = subEntityId.ToString();
                        tcm.TeamId = teamId.ToString();
                        tcm.Theme = theme.ToString();
                        tcm.Tid = new System.Guid(tid.ToString());
                        tcm.Upn = upn.ToString();

                        var results = triviaApi.TriviaGetLeaderboard(tcm, "team");


                        foreach (var result in results)
                        {
                            html = html + "<tr><td>" + result.Name + "</td><td>" + result.Score + "</td><tr>";
                        }

                        content.InnerHtml = html + "</table>";

                    }
                    else
                    {


                        TeamsContextModel tcm = new TeamsContextModel();
                        tcm.ChannelId = channelId.ToString();
                        tcm.EntityId = entityId.ToString();
                        tcm.GroupId = new System.Guid(groupId.ToString());
                        tcm.Locale = locale.ToString();
                        tcm.SubEntityId = subEntityId.ToString();
                        tcm.TeamId = teamId.ToString();
                        tcm.Theme = theme.ToString();
                        tcm.Tid = new System.Guid(tid.ToString());
                        tcm.Upn = upn.ToString();

                        var results = triviaApi.TriviaGetLeaderboard(tcm, "user");

                        //Stream photoStream = graphClient.Me.Photo.Content.Request().GetAsync().Result;
                        //byte[] bytes = new byte[photoStream.Length];
                        //photoStream.Read(bytes, 0, (int)photoStream.Length);

                        //var users = graphClient.Users.Request().GetAsync().Result;

                        string picture = String.Empty;

                        foreach (var result in results)
                        {

                            if (!pictures.ContainsKey(result.Id.GetValueOrDefault()))
                            {

                                string requestUrl = "https://graph.microsoft.com/v1.0//users/" + result.Id.ToString() + "/photo/$value";

                                HttpRequestMessage hrm = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                                graphClient.AuthenticationProvider.AuthenticateRequestAsync(hrm);

                                try
                                {
                                    HttpResponseMessage response = graphClient.HttpProvider.SendAsync(hrm).Result;
                                    if (response.IsSuccessStatusCode)
                                    {
                                        var bytes = response.Content.ReadAsByteArrayAsync().Result;
                                        picture = Convert.ToBase64String(bytes);
                                        pictures.Add(result.Id.GetValueOrDefault(), picture);
                                    }
                                }
                                catch(Exception except)
                                {
                                    picture = String.Empty;
                                }
                            }
                            else
                                picture = pictures[result.Id.GetValueOrDefault()];

                            var pic = "data:image/png;base64," + picture;
                            
                            html = html + "<tr><td><img width=48 src='" + pic + "'/>" + "</td><td>" + result.Name + "</td><td>" + result.Score + "</td><tr>";
                        }

                        content.InnerHtml = html + "</table>";

                    }

                }
            }
        }


    }
}
