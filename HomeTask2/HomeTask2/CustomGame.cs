using System;
using System.Threading;

namespace HomeTask2
{
    class CustomGame
    {
        int _borderLineLenght = Console.BufferWidth - 4;
        int _life = 3;
        int _ballSpeed = 100;

        public void ReOpenGame() // Обновление переменных и вызов метода Action(). 
        {
            _life = 3;
            _ballSpeed = 100;
            MovePlatformAndBall();
        }

        public void LifeCount()  // подсчет жизней
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft = 30;
            Console.CursorTop = 28;
            Console.WriteLine($"LIFE: {_life}");
        }

        public void Borderline()  // постройка рамки
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Gray;

            int _leftCursor = 0, _topCursor = 0, _offset_y = 1;

            while (true)
            {
                Console.CursorLeft = _leftCursor;
                Console.CursorTop = _topCursor;
                Console.Write("██");

                if (_topCursor == 0 && _leftCursor == _borderLineLenght)
                {
                    for (_leftCursor = _borderLineLenght; _leftCursor > 0; _leftCursor--)
                    {
                        Console.CursorLeft = _leftCursor;
                        Console.Write("██");
                    }
                    goto BuildIsDone;
                }
                if (_topCursor < 25)
                {
                    _topCursor += _offset_y;
                }
                else
                {
                    _leftCursor = _borderLineLenght;
                    Console.CursorLeft = _leftCursor;
                    Console.Write("██");
                    _offset_y = -_offset_y;
                    _topCursor--;
                }
            }
            BuildIsDone:;
        }
        public void MovePlatformAndBall() // Двигающаяся платформа и мяч
        {
            for (int i = 0; i <= 3; i++)
            {
                int _moveleft = (Console.BufferWidth - 3) / 2 - 6;
                Console.Clear();
                Borderline();

                Console.ForegroundColor = ConsoleColor.Green;
                int _x_ForBall = 35, _y_ForBall = 10, _offset_x = 1, _offset_y = 1;

                while (_life != 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.CursorLeft = _moveleft;
                    Console.CursorTop = 26;
                    Console.Write("████████████");

                    while (true)
                    {
                        LifeCount();
                        if (Console.KeyAvailable)
                            break;

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorLeft = _x_ForBall;
                        Console.CursorTop = _y_ForBall;
                        Console.Write(" ");
                        _x_ForBall += _offset_x;
                        _y_ForBall += _offset_y;

                        if (_x_ForBall < 2)
                        {
                            _x_ForBall = 2;
                            _offset_x = -_offset_x;
                            Console.Beep(3000, 100);
                        }
                        if (_x_ForBall == _borderLineLenght)
                        {
                            _x_ForBall--;
                            _offset_x = -_offset_x;
                            Console.Beep(3000, 100);
                        }
                        if (_y_ForBall < 1)
                        {
                            _y_ForBall = 1;
                            _offset_y = -_offset_y;
                            Console.Beep(3000, 100);
                        }
                        if (_y_ForBall == 25 && (_moveleft <= _x_ForBall && _x_ForBall <= _moveleft + 11))
                        {
                            _y_ForBall = 25;
                            _offset_y = -_offset_y;
                            Console.Beep(3000, 100);
                        }
                        if (_y_ForBall > 25)
                        {
                            Console.Beep();
                            _life--;
                            goto MinusLife;
                        }

                        Console.CursorLeft = _x_ForBall;
                        Console.CursorTop = _y_ForBall;
                        Console.Write("0");

                        Thread.Sleep(_ballSpeed);
                    }

                    ConsoleKey key = Console.ReadKey(false).Key;
                    Console.CursorTop = 26;
                    Console.CursorLeft = _moveleft;
                    Console.Write("            ");

                    switch (key)
                    {
                        case ConsoleKey.Escape:
                            goto End;
                        case ConsoleKey.LeftArrow:
                            if (_moveleft != 0)
                                _moveleft--;
                            break;
                        case ConsoleKey.RightArrow:
                            if (_moveleft != _borderLineLenght - 10)
                                _moveleft++;
                            break;
                    }
                }
                MinusLife:;
            }
            TheEndGame();
            End:;
        }

        public void TheEndGame()  // конец игры - выбрать выход или продолжить заново
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.CursorLeft = _borderLineLenght / 2 - 4;
            Console.CursorTop = 15;
            Console.WriteLine("THE END");

            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft = 18;
            Console.CursorTop = 28;
            Console.WriteLine($"Exit - \"Escape\"   Newly - \"Enter\"");

            if (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.CursorVisible = false;
                switch (key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Enter:
                        ReOpenGame();
                        break;
                }
            }
        }
    }
}

