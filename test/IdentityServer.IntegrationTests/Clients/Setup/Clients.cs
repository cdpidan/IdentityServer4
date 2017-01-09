﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using System;
using System.Security.Cryptography.X509Certificates;
using IdentityServer4.IntegrationTests.Common;

namespace IdentityServer4.IntegrationTests.Clients
{
    class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                ///////////////////////////////////////////
                // Console Client Credentials Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = 
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedScopes = 
                    {
                        "api1", "api2"
                    }
                },
                new Client
                {
                    ClientId = "client.and.ro",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,

                    AllowedScopes =
                    {
                        "openid",
                        "api1", "api2"
                    }
                },
                new Client
                {
                    ClientId = "client.identityscopes",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedScopes =
                    {
                        "openid", "profile",
                        "api1", "api2"
                    }
                },
                new Client
                {
                    ClientId = "client.no_default_scopes",
                    ClientSecrets = 
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                },

                ///////////////////////////////////////////
                // Console Resource Owner Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "roclient",
                    ClientSecrets = 
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowOfflineAccess = true,
                    AllowedScopes = 
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "api1", "api2", "api4.with.roles"
                    }
                },

                /////////////////////////////////////////
                // Console Custom Grant Flow Sample
                ////////////////////////////////////////
                new Client
                {
                    ClientId = "client.custom",
                    ClientSecrets = 
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.List("custom"),

                    AllowedScopes = 
                    {
                        "api1", "api2"
                    }
                },

                ///////////////////////////////////////////
                // Introspection Client Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "roclient.reference",
                    ClientSecrets = 
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowOfflineAccess = true,
                    AllowedScopes = 
                    {
                        "api1", "api2"
                    },

                    AccessTokenType = AccessTokenType.Reference
                },

                new Client
                {
                    ClientName = "Client with Base64 encoded X509 Certificate",
                    ClientId = "certificate_base64_valid",
                    Enabled = true,

                    ClientSecrets = 
                    {
                        new Secret
                        {
                            Type = IdentityServerConstants.SecretTypes.X509CertificateBase64,
                            Value = Convert.ToBase64String(TestCert.Load().Export(X509ContentType.Cert))
                        }
                    },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedScopes = new List<string>
                    {
                        "api1", "api2"
                    },
                },

                new Client
                {
                    ClientId = "implicit",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = {"api1"}
                },
                new Client
                {
                    ClientId = "implicit_and_client_creds",
                    AllowedGrantTypes = GrantTypes.ImplicitAndClientCredentials,
                    AllowedScopes = {"api1"}
                },
            };
        }
    }
}