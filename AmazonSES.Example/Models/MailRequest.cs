﻿namespace AmazonSES.Example.Models
{
    public class MailRequest
    {
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
