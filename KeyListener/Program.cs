using System;
using System.Threading;


namespace KeyListener
{
    class KeyListener
    {
        public delegate void KeyHandler();
        public event KeyHandler PressKey;
                
        public void Listen(Person p)
        {
            ConsoleKeyInfo k = Console.ReadKey(true);
            PressKey = null;

            switch (k.Key)
            {
                case ConsoleKey.Enter:
                    PressKey += p.Select;
                    break;
                case ConsoleKey.Spacebar:
                    PressKey += p.Jump;
                    break;
                case ConsoleKey.F1:
                    PressKey += p.Fall;
                    break;
                case ConsoleKey.LeftArrow:
                    PressKey += p.Move_Left;
                    break;
                case ConsoleKey.RightArrow:
                    PressKey += p.Move_Right;
                    break;
                case ConsoleKey.UpArrow:
                    PressKey += p.Move_Up;
                    break;
                case ConsoleKey.DownArrow:
                    PressKey += p.Move_Down;
                    break;
                case ConsoleKey.Escape:
                    PressKey += p.Escape;
                    break;                
            }
            PressKey();
        }        
    }

    class Person
    {
        string name;
        public string Name { get; set; }

        public void Select()
        {
            Console.WriteLine("Нажмите клавишу: ");
            Console.WriteLine("\tSpace       - Person jump");
            Console.WriteLine("\tF1          - Person fall");
            Console.WriteLine("\tLeft Arrow  - Person move left");
            Console.WriteLine("\tRight Arrow - Person move right");
            Console.WriteLine("\tUp Arrow    - Person move ahead");
            Console.WriteLine("\tDown Arrow  - Person move back");
            Console.WriteLine("\tEscape      - Exit");
            Console.WriteLine();
        }
        public void Jump()
        {
            Console.WriteLine(Name + " подпрыгивает");
        }
        public void Fall()
        {
            Console.WriteLine(Name + " падает");
        }
        public void Move_Left()
        {
            Console.WriteLine(Name + " двигается влево");
        }
        public void Move_Right()
        {
            Console.WriteLine(Name + " двигается вправо");
        }
        public void Move_Up()
        {
            Console.WriteLine(Name + " двигается вперед");
        }
        public void Move_Down()
        {
            Console.WriteLine(Name + " двигается назад");
        }
        public void Escape()
        {
            Console.WriteLine("Game over!");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            KeyListener kl = new KeyListener();
            Person p = new Person();
            kl.Listen(p);
        }
    }
}


