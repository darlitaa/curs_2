using System;

namespace lab_6
{
    public class InvalidTypeException : ArgumentException
    {
        public int Value { get; }

        public InvalidTypeException(string message, int type) : base(message)
        {
            Value = type;
            Data.Add("Time exception", DateTime.Now);
        }
    }
}