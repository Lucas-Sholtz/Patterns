using System;
using System.Collections.Generic;
namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаём главную таблицу
            Component main = new Table("Главная");
            // и две дочерних
            Component tableA= new Table("А");
            Component tableB = new Table("B");
            // а также 4 ячейки
            Component cell1 = new Cell("A1");
            Component cell2 = new Cell("A2");
            Component cell3 = new Cell("B3");
            Component cell4 = new Cell("B4");
            // добавляем ячейки в таблицы, по две в каждую
            tableA.Add(cell1);
            tableA.Add(cell2);
            tableB.Add(cell3);
            tableB.Add(cell4);
            // добавляем таблицы в главную
            main.Add(tableA);
            main.Add(tableB);
            // выводим все данные
            main.Print();

            Console.WriteLine();

            //удалим одну ячейку из таблицы А
            tableA.Remove(cell1);

            main.Print();

            Console.Read();
        }
    }

    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }

        public virtual void Print()
        {
            Console.WriteLine(name);
        }
    }
    class Table : Component
    {
        private List<Component> components = new List<Component>();

        public Table(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }

        public override void Print()
        {
            Console.WriteLine("Таблица " + name);
            Console.WriteLine("Ячейки:");
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Print();
            }
        }
    }
    class Cell : Component
    {
        public Cell(string name)
                : base(name)
        {
        }
    }
}
