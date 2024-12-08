using System;

namespace lab_6
{
    public class InvalidCakeException : ArgumentException
    {
        public string Value { get; }
        public InvalidCakeException(string message, string name) : base(message)
        {
            Value = name;
            Data.Add("Time exception", DateTime.Now);
        }
    }
}