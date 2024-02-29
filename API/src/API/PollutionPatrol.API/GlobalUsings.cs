// Global using directives

global using System.Reflection;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Newtonsoft.Json;
global using PollutionPatrol.API.ExceptionHandling.Extensions;
global using PollutionPatrol.API.ExceptionHandling.Middleware;
global using PollutionPatrol.API.Models.UserAccess;
global using PollutionPatrol.BuildingBlocks.Application.Env;
global using PollutionPatrol.BuildingBlocks.Application.Exceptions;
global using PollutionPatrol.BuildingBlocks.Application.Interfaces;
global using PollutionPatrol.BuildingBlocks.Application.Pipelines;
global using PollutionPatrol.BuildingBlocks.Domain;
global using PollutionPatrol.Modules.UserAccess.Application.Contracts;
global using PollutionPatrol.Modules.UserAccess.Application.Features.Reg.Registration;
global using PollutionPatrol.Modules.UserAccess.Application.Features.Reg.Verification;
global using Serilog;