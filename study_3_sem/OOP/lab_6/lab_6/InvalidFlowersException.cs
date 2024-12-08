using System;

namespace lab_6
{
    public class InvalidFlowersException : InvalidCakeException
    {
        public InvalidFlowersException(string message, string name) : base(message, name)
        {
            Data.Add("Time exception", DateTime.Now);
        }
    }
}