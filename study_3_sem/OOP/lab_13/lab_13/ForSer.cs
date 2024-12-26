using System;
using System.Runtime.Serialization;

namespace Lab_13
{
    [Serializable]
    public abstract class IntelligentBeing
    {
        [DataMember]
        public string Name;

        protected IntelligentBeing(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
        }
        [DataMember]
        public readonly DateTime Birthday;
        public TimeSpan Age => DateTime.Now.Subtract(Birthday) / 365;


        public override string ToString()
        {
            return $"this creature:{Name}\t live:{Age} year";
        }

    }


    [Serializable]
    public class Human : IntelligentBeing
    {
        [NonSerialized]
        public string Gender = null!;

        public Human(string name, DateTime age, string gender) : base(name, age)
        {
            Gender = gender;
        }

        public Human(string name, DateTime age) : base(name, age)
        {
        }

        public Human() : base("undefined", DateTime.Now)
        {
            Gender = "undefined";
        }

        public override string ToString()
        {
            return $"name:{Name}\t age:{Age}\t ";
        }
    }

}

