using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_8
{
    public class Programmer
    {
        public delegate void remove(object sender, EventArgs e);
        public delegate void mutation(object sender, EventArgs e);

        public event remove Remove;
        public event mutation Mutation;

        public string Name;

        public Programmer(string name)
        {
            Name = name;
        }

        public void OnRemove() => Remove?.Invoke(this, EventArgs.Empty);
        public void OnMutation() => Mutation?.Invoke(this, EventArgs.Empty);
    }
}