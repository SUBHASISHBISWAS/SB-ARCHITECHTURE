using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class ClubSandwichBuilder : SandwichBuilder
    {
        public override void AddCondiments()
        {
            sandwich.HasMayo = true;
            sandwich.HasMustard = true;
        }

        public override void ApplyVegetables()
        {
            sandwich.Vegetables = new List<string> { "Tomato", "Onion", "Lettuce" };
        }

        public override void ApplyMeatAndCheese()
        {
            sandwich.CheeseType = CheeseType.Swiss;
            sandwich.MeatType = MeatType.Turkey;
        }

        public override void PrepareBread()
        {
            sandwich.BreadType = BreadType.White;
            sandwich.IsToasted = true;
        }
    }
}
