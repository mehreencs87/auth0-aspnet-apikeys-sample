# Sample .NET implementation for the blog post "Using JSON Web Tokens as API Keys"

The blog post [Using JSON Web Tokens as API Keys](https://auth0.com/blog/2014/12/02/using-json-web-tokens-as-api-keys/) explains the advantages of using JSON Web Tokens instead of traditional API Keys. This sample project shows you how you can use this technique in .NET

A WebApi is protected using Jwt Bearer Authentication (using Microsoft.Owin.Security.Jwt). A console application will authenticate using the Auth0 Resource Owner endpoint and receive a token. This token can be used to access the protected Api.

## Auth0 configuration

Create an application for the Api.

Also make sure you have a database connection and create a user here for your service account (the console application).

## API configuration

In the web.config of each API you'll need to add the domain, client ID and client secret:

```javascript
  <appSettings>
    <add key="Auth0Domain" value="https://tenant.auth0.com/" />
    <add key="Auth0ClientID" value="bAtjaPBMOJOJPzYTYSEzByEoO0kXGSVA" />
    <add key="Auth0ClientSecret" value="aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" />
  </appSettings>
```

## Client configuration

In the console application you'll need to change the domain, client ID and connection name:

```csharp
var client = new Auth0.Client("aJ720Y4ZCU97EsAfNabs4lLW3GzfTGE0", "tenant.auth0.com");
var token = client.LoginUser("client01-serviceidentity@mycompany.com", "abc", 
    "Username-Password-Authentication", "openid profile");
```
