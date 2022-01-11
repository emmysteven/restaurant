using System;

namespace Restaurant.Application.Common.Exceptions;

public class DeleteFailureException : Exception
{
    public DeleteFailureException(string name, object key, string message)
        : base($"Deletion of entity \"{name}\" ({key}) failed. {message}")
    {
    }
}