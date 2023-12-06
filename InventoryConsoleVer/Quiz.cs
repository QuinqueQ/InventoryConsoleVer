using InventoryConsoleVer.Items;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace InventoryConsoleVer
{
    public class Quiz
    {
        private string[] questions;
        private string[] answers;
        private int[] questionOrder;
        private int correctAnswers;

        private Player player;

        internal Quiz(Player currentPlayer) 
        {
            player = currentPlayer; // сохраняем текущего игрока
            InitializeQuiz();
        }

        private void InitializeQuiz()
        {
            questions = new string[]
            {
                "\n Что представляет собой процесс объединения данных и методов в единый объект?\n",
                "\n Что такое аксессоры в языке программирования?\n",
                "\n Какой принцип ООП позволяет объекту принимать различные формы?\n",
                "\n Как определить полиморфизм в объектно-ориентированном программировании?\n",
                "\n Какие из перечисленных языков программирования поддерживают объектно-ориентированное программирование?\n"
            };

            answers = new string[]
            {
                " 1.Инкапсуляция\n 2.Полиморфизм\n 3.Наследование\n 4.Абстракция",
                " 1.Методы для изменения данных\n 2.Внешние файлы\n 3.Операторы ветвления\n 4.Управление памятью",
                " 1.Абстракция\n 2.Инкапсуляция\n 3.Полиморфизм\n 4.Наследование",
                " 1.Возможность объекта иметь разные типы\n 2.Сокрытие внутренней реализации\n 3.Наследование\n 4.Полиморфизм",
                " 1.C\n 2.Java\n 3.Python\n 4.Все вышеперечисленные"
            };

            var random = new Random();
            questionOrder = Enumerable.Range(0, questions.Length).OrderBy(x => random.Next()).ToArray();

            correctAnswers = 0;
        }

        public void StartQuiz(ref int playerLevel)
        {
            Console.Clear();
            Console.WriteLine("             Квиз начинается!");
            Console.WriteLine("**********************************************");
            Console.WriteLine("Ответьте на вопросы, чтобы получить награды.");
            Thread.Sleep(2000);

            for (int i = 0; i < questionOrder.Length; i++)
            {
                int questionIndex = questionOrder[i];

                Console.Clear();
                Console.WriteLine(questions[questionIndex]);
                Console.WriteLine(answers[questionIndex]);

                ConsoleKeyInfo key;
                Console.Write("\nВыберите ответ (1, 2, 3, 4): ");
                do
                {
                    key = Console.ReadKey(true);
                } while (key.KeyChar != '1' && key.KeyChar != '2' && key.KeyChar != '3' && key.KeyChar != '4');

                if (key.KeyChar == GetCorrectAnswer(questionIndex)[0])
                {
                    Console.WriteLine("\n--------------------------");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n Правильно!\n");
                    Console.ResetColor();
                    playerLevel++;
                    correctAnswers++;
                }
                else
                {
                    Console.WriteLine("\n--------------------------");
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"\n Неправильно!\n");
                    Console.ResetColor();
                    Console.WriteLine($" Правильный ответ: {GetCorrectAnswer(questionIndex)}\n");
                }

                Console.WriteLine(" Нажмите Любую клавишу для следующего вопроса...");
                Console.ReadKey(true);
            }
             Console.Clear();
            if (correctAnswers == 5)
            {
                Console.WriteLine(" Поздравляем! Вы ответили правильно на все вопросы!");
                GiveRandomReward();
            }
            else if (correctAnswers == 4)
            {
                Console.WriteLine($" Вы ответили правильно на {correctAnswers} из 5 вопросов.");
                GiveRandomReward();
            }
            else if (correctAnswers == 3)
            {
                Console.WriteLine($" Вы ответили правильно на {correctAnswers} из 5 вопросов.");
                GiveRandomReward();
            }
            else if (correctAnswers == 2)
            {
                Console.WriteLine($" Вы ответили правильно на {correctAnswers} из 5 вопросов.");
                GiveRandomReward();
            }
            else if (correctAnswers == 1)
            {
                Console.WriteLine($" Вы ответили правильно на {correctAnswers} из 5 вопросов.");
                GiveRandomReward();
            }
            else
            {
                Console.WriteLine($" Вы ответили правильно на {correctAnswers} из 5 вопросов.");
            }

            Console.WriteLine("\n Нажмите Enter, чтобы вернуться в меню.");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
            }
        }


        private void GiveRandomReward()
        {
            int correctAnswersCount = correctAnswers;

            // Задаем редкость награды в зависимости от количества правильных ответов
            string rarity;
            switch (correctAnswersCount)
            {
                case 1:
                    rarity = "Обычный";
                    break;
                case 2:
                    rarity = "Необычный";
                    break;
                case 3:
                    rarity = "Редкий";
                    break;
                case 4:
                    rarity = "Эпический";
                    break;
                case 5:
                    rarity = "Легендарный";
                    break;
                default:
                    rarity = "Обычный";
                    break;
            }

            // Получаем список наград соответствующей редкости
            var itemsByRarity = Full_Items.Itemss
                .Where(item => item.Rarity == rarity)
                .ToList();

            if (itemsByRarity.Count > 0)
            {
                // Получаем случайную награду из списка
                Inventory_Item reward = itemsByRarity[new Random().Next(itemsByRarity.Count)];

                Console.Write($"\n Вы получили награду: ");
                Console.ForegroundColor = reward.Color;
                Console.Write($"{reward.Name} ({reward.Rarity})!\n");
                Console.ResetColor();
                // Добавляем награду в инвентарь текущего игрока
                player.AddItemToInventory(reward);
            }
            else
            {
                Console.WriteLine($" К сожалению, нет подходящих наград для редкости: {rarity}");
            }
        }



        private string GetCorrectAnswer(int questionIndex)
        {
            switch (questionIndex)
            {
                case 0: return "1";
                case 1: return "1";
                case 2: return "3";
                case 3: return "4";
                case 4: return "4";
                default: return "";
            }
        }
    }
}
