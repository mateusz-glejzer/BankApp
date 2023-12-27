using System;
using System.Net.Http;

namespace BankApp.Shared.Infrastructure.Configuration;

public record EndpointInfo(string Path, HttpMethod HttpVerb, Delegate Handler, AuthorizationLevel Role);