using Azure.Identity;
using Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Graph.Me.SendMail;
using Microsoft.Graph.Models;

class Program
{
    static async Task Main(string[] args)
    {


        string[] scopes = new[] { "Mail.Send", "User.Read" };

        string clientId = "2d7f5b23-b1cb-45ec-9109-81d493009956";
        string tenantId = "2c2cb52b-74d3-4ebe-8c77-02b082e508c4";
        string clientSecret = "0zX8Q~DzI0gG5P5V4.Twq~JboFnUpEoGpOi8Xagr";


        // Authentication 
        // Cases

        #region Case1

        //Authorization code provider

        //scopes = new[] { "User.Read" };

        //// Multi-tenant apps can use "common",
        //// single-tenant apps must use the tenant ID from the Azure portal
        //tenantId = "common";


        //// For authorization code flow, the user signs into the Microsoft
        //// identity platform, and the browser is redirected back to your app
        //// with an authorization code in the query parameters
        //var authorizationCode = "AUTH_CODE_FROM_REDIRECT";

        //// using Azure.Identity;
        //var options = new AuthorizationCodeCredentialOptions
        //{
        //    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
        //};

        //// https://learn.microsoft.com/dotnet/api/azure.identity.authorizationcodecredential
        //var authCodeCredential = new AuthorizationCodeCredential(
        //    tenantId, clientId, clientSecret, authorizationCode, options);

        //var graphClient = new GraphServiceClient(authCodeCredential, scopes);


        #endregion

        #region Case2

        //Device code provider

        //DeviceCodeCredentialOptions options = new DeviceCodeCredentialOptions
        //{
        //    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
        //    ClientId = clientId,
        //    TenantId = tenantId,

        //    DeviceCodeCallback = (code, cancellation) =>
        //    {
        //        Console.WriteLine(code.Message);
        //        return Task.FromResult(0);
        //    },
        //};

        //// https://learn.microsoft.com/dotnet/api/azure.identity.devicecodecredential
        //var deviceCodeCredential = new DeviceCodeCredential(options);

        //GraphServiceClient graphClient = new GraphServiceClient(deviceCodeCredential, scopes);


        #endregion

        #region Case3

        //Client credentials provider - Using a client secret


        //scopes = new[] { "https://graph.microsoft.com/.default" };


        //var options = new ClientSecretCredentialOptions
        //{
        //    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
        //};

        //// https://learn.microsoft.com/dotnet/api/azure.identity.clientsecretcredential
        //var clientSecretCredential = new ClientSecretCredential(
        //    tenantId, clientId, clientSecret, options);

        //var graphClient = new GraphServiceClient(clientSecretCredential, scopes);

        #endregion

        #region Case4

        //Client credentials provider - Using a client certificate

        //scopes = new[] { "https://graph.microsoft.com/.default" };

        //var clientCertificate = new X509Certificate2("MyCertificate.pfx");

        //// using Azure.Identity;
        //var options = new ClientCertificateCredentialOptions
        //{
        //    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
        //};

        //// https://learn.microsoft.com/dotnet/api/azure.identity.clientcertificatecredential
        //var clientCertCredential = new ClientCertificateCredential(
        //    tenantId, clientId, clientCertificate, options);

        //var graphClient = new GraphServiceClient(clientCertCredential, scopes);

        #endregion

        #region Case5

        //On-behalf-of provider

        //var scopes = new[] { "https://graph.microsoft.com/.default" };

        //// Multi-tenant apps can use "common",
        //// single-tenant apps must use the tenant ID from the Azure portal
        //var tenantId = "common";

        //// Values from app registration
        //var clientId = "YOUR_CLIENT_ID";
        //var clientSecret = "YOUR_CLIENT_SECRET";

        //// using Azure.Identity;
        //var options = new OnBehalfOfCredentialOptions
        //{
        //    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
        //};

        //// This is the incoming token to exchange using on-behalf-of flow
        //var oboToken = "JWT_TOKEN_TO_EXCHANGE";

        //var onBehalfOfCredential = new OnBehalfOfCredential(
        //    tenantId, clientId, clientSecret, oboToken, options);

        //var graphClient = new GraphServiceClient(onBehalfOfCredential, scopes);

        #endregion

        #region Case6

        //Device code provider

        //scopes = new[] { "User.Read" };

        // Multi-tenant apps can use "common",
        // single-tenant apps must use the tenant ID from the Azure portal
        // tenantId = "common";


        //var options = new DeviceCodeCredentialOptions
        //{
        //    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
        //    ClientId = clientId,
        //    TenantId = tenantId,

        //    DeviceCodeCallback = (code, cancellation) =>
        //    {
        //        Console.WriteLine(code.Message);
        //        return Task.FromResult(0);
        //    },
        //};

        //// https://learn.microsoft.com/dotnet/api/azure.identity.devicecodecredential
        //var deviceCodeCredential = new DeviceCodeCredential(options);

        //var graphClient = new GraphServiceClient(deviceCodeCredential, scopes);

        #endregion

        #region Case7

        //Integrated Windows provider

        //[DllImport("user32.dll")]
        //static extern IntPtr GetForegroundWindow();

        //// Get parent window handle
        //var parentWindowHandle = GetForegroundWindow();

        // scopes = new[] { "User.Read" };

        //// Multi-tenant apps can use "common",
        //// single-tenant apps must use the tenant ID from the Azure portal
        // tenantId = "common";


        //// using Azure.Identity.Broker;
        //// This will use the Web Account Manager in Windows
        //var options = new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle)
        //{
        //    ClientId = clientId,
        //    TenantId = tenantId,
        //};

        //// https://learn.microsoft.com/dotnet/api/azure.identity.interactivebrowsercredential
        //var credential = new InteractiveBrowserCredential(options);

        //var graphClient = new GraphServiceClient(credential, scopes);


        #endregion

        #region Case8

        //Interactive provider

        // scopes = new[] { "User.Read" };

        //// Multi-tenant apps can use "common",
        //// single-tenant apps must use the tenant ID from the Azure portal
        // tenantId = "common";

        //// Value from app registration

        //// using Azure.Identity;
        //var options = new InteractiveBrowserCredentialOptions
        //{
        //    TenantId = tenantId,
        //    ClientId = clientId,
        //    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
        //    // MUST be http://localhost or http://localhost:PORT
        //    // See https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/System-Browser-on-.Net-Core
        //    RedirectUri = new Uri("http://localhost"),
        //};

        //// https://learn.microsoft.com/dotnet/api/azure.identity.interactivebrowsercredential
        //var interactiveCredential = new InteractiveBrowserCredential(options);

        //var graphClient = new GraphServiceClient(interactiveCredential, scopes);


        #endregion

        #region Case9

        //Username/password provider

        //tenantId = "common";
        //scopes = new[] { "User.Read" };

        //var options = new UsernamePasswordCredentialOptions
        //{
        //    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
        //};


        //string username = "m.selim@nevotek.com";

        //HelperClass testClass = new HelperClass();
        //string password = testClass.GetCredential();


        //var usernamepasswordcredential = new UsernamePasswordCredential(
        //    username, password, tenantId, clientId, options);

        //var graphClient = new GraphServiceClient(usernamepasswordcredential, scopes);

        #endregion

        #region Case10E

        //Username/password provider

         scopes = new[] { "Mail.Send", "User.Read" };


        var options = new UsernamePasswordCredentialOptions
        {
            AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
        };

        var userName = "m.selim@nevotek.com";
        HelperClass testClass3 = new HelperClass();
        string password = testClass3.GetCredential();

        // https://learn.microsoft.com/dotnet/api/azure.identity.usernamepasswordcredential
        var userNamePasswordCredential = new UsernamePasswordCredential(
            userName, password, tenantId, clientId, options);

        var graphClient = new GraphServiceClient(userNamePasswordCredential, scopes);

        #endregion

        await SendMailAsync(graphClient);
    }

    private static async Task SendMailAsync(GraphServiceClient graphClient)
    {
        SendMailPostRequestBody requestBody = new SendMailPostRequestBody
        {
            Message = new Message
            {
                Subject = "Microsoft Graph API",
                Body = new ItemBody
                {
                    ContentType = BodyType.Html,
                    Content = "test mail"
                },
                ToRecipients = new List<Recipient>
                       {
                           new Recipient
                           {
                               EmailAddress = new EmailAddress
                               {
                                   Address = "m.selim@nevotek.com",
                               },
                           },
                       },
                CcRecipients = new List<Recipient>
                       {
                           new Recipient
                           {
                               EmailAddress = new EmailAddress
                               {
                                   Address = "m.selim@nevotek.com",
                               },
                           },
                       },
            },
            SaveToSentItems = false,
        };


        try
        {
            if (graphClient.Me != null)
            {
                await graphClient.Me.SendMail.PostAsync(requestBody);
                Console.WriteLine("Email sent successfully.");
            }
            else
            {
                Console.WriteLine("GraphClient.Me is null; the user may not have signed in.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during email sending: {ex.Message}");
        }
    }
}