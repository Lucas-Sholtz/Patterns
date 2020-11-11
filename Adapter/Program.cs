using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        interface ILanguage
        {
            void Talk();
        }
        // класс вербального языка
        class English : ILanguage
        {
            public void Talk()
            {
                Console.WriteLine("English text");
            }
        }
        class Human
        {
            public void Communicate(ILanguage language)
            {
                language.Talk();
            }
        }
        // интерфейс языка жестов
        interface IGestures
        {
            void Gesticulate();
        }
        // класс Амслена
        class Amslen : IGestures
        {
            public void Gesticulate()
            {
                Console.WriteLine("Some gestures");
            }
        }
        // адаптер Амслена к ILanguage
        class AmslenToEnglishAdaptor : ILanguage
        {
            Amslen amslen;
            public AmslenToEnglishAdaptor(Amslen amslen)
            {
                this.amslen = amslen;
            }

            public void Talk()
            {
                amslen.Gesticulate();
            }
        }
        static void Main(string[] args)
        {
            // волонтёр
            Human human = new Human();
            // английский язык
            English english = new English();
            // он общается на нём с обычными людьми
            human.Communicate(english);
            // язык жестов Амслен
            Amslen amslen = new Amslen();
            // создаём адаптер
            ILanguage amslenAdapter = new AmslenToEnglishAdaptor(amslen);
            // теперь волонтёр может помогать глухонемым и общаться с ними на Амслене
            human.Communicate(amslenAdapter);

            Console.Read();
        }
    }
}
