﻿namespace PollutionPatrol.BuildingBlocks.Application.Email;

public sealed class EmailMessage 
{
    public EmailMessage(string to, string subject, string body)
    {
        To = to;
        Subject = subject;
        Body = body;
    }

    public string To { get; }
    public string Subject { get; }
    public string Body { get; }
}