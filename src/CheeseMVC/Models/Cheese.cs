using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CheeseType Type { get; set; }
        public int Rating { get; set; }
        public string CheeseId { get; set; }
        //private static int nextId = 1;

            /*
        public Cheese(string name, string description)
        {
            Name = name;
            Description = description;
        } */

        public Cheese()
        {
            // Remove the hyphens because routing does not allow them by default
            CheeseId = Guid.NewGuid().ToString().Replace("-", string.Empty);    
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Cheese passedCheese = (Cheese)obj;

            return CheeseId.Equals(passedCheese.CheeseId);
        }
    }
}
