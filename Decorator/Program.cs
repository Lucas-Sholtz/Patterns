using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public enum Color
    {
        Red=0,
        Green,
        Blue,
        Yellow,
        White,
        Gold,
        Silver
    }
    class Program
    {
        // Компонента
        abstract class Decoration
        {
            public abstract void Appearance();
        }

        // Іграшка ConcreteComponent1
        class ChristmasTreeToy : Decoration
        {
            private Color color;
            public ChristmasTreeToy()
            {
                Array colors = Enum.GetValues(typeof(Color));
                Random random = new Random();
                this.color = (Color)colors.GetValue(random.Next(colors.Length));
            }
            public override void Appearance()
            {
                Console.WriteLine("This christmas tree toy is {0}.", (color.ToString()).ToLower());
            }
        }
        // Гірлянда ConcreteComponent2
        class ChristmasTreeGarland : Decoration
        {
            private Color color;
            public ChristmasTreeGarland()
            {
                Array colors = Enum.GetValues(typeof(Color));
                Random random = new Random();
                this.color = (Color)colors.GetValue(random.Next(colors.Length));
            }
            public override void Appearance()
            {
                Console.WriteLine("This garland glows {0}.", (color.ToString()).ToLower());
            }
        }
        // "Decorator"
        abstract class Decorator : Decoration
        {
            protected Decoration decoration;

            public void SetDecoration(Decoration decoration)
            {
                this.decoration = decoration;
            }
            public override void Appearance()
            {
                if (decoration != null)
                {
                    decoration.Appearance();
                }
            }
        }

        // "ConcreteDecoratorA"
        class ChristmasTreeBranch : Decorator
        {
            public override void Appearance()
            {
                Console.WriteLine("The branch pleases the eye with needles");
                base.Appearance();
            }
        }

        // "ConcreteDecoratorB" 
        class ChristmasTree : Decorator
        {
            public override void Appearance()
            {
                Console.WriteLine("What a beautiful tree");
                base.Appearance();
            }
        }
        static void Main(string[] args)
        {
            ChristmasTreeToy toy = new ChristmasTreeToy();
            ChristmasTreeGarland garland = new ChristmasTreeGarland();
            ChristmasTreeBranch branch = new ChristmasTreeBranch();
            ChristmasTree tree = new ChristmasTree();


            branch.SetDecoration(toy);
            tree.SetDecoration(branch);

            tree.Appearance();

            branch.SetDecoration(garland);

            tree.Appearance();

            Console.Read();
        }
    }
}
