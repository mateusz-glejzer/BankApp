using System;
using System.Net.Http;

namespace BankApp.Shared.Abstractions.Modules;

public record EndpointInfo(string Path, HttpMethod HttpVerb, Delegate Handler);