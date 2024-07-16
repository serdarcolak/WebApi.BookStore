﻿namespace WebApi.BookStore.Business.Services;

public class DbLogger : ILoggerService
{
    public void Write(string message)
    {
        Console.WriteLine(" [DBLogger] - " + message);
    }
}