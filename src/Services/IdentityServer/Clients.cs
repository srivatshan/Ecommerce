﻿using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
        {
            new Client
            {
                //commenting for auto authendiaction

                ClientId = "oauthClient",
                ClientName = "Example client application using client credentials",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
                AllowedScopes = new List<string> {"api1.read"}
                //for Api
            },

            new Client
            {
                ClientId = "oidcClient",
                ClientName = "Example Client Application",
                ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
    
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = new List<string> {"https://localhost:44340/signin-oidc"},
             

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "role",
                    "api1.read"
                },

                RequirePkce = true,
                AllowPlainTextPkce = false
            }

          
        };
        }
    }
}
