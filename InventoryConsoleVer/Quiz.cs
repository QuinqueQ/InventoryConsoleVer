using InventoryConsoleVer.Items;
using System;
using System.Linq;

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
                " 1.Инкапсуляция\n2. Полиморфизм\n3. Наследование\n4. Абстракция",
                " 1.Методы для изменения данных\n2. Внешние файлы\n3. Операторы ветвления\n4. Управление памятью",
                " 1.Абстракция\n2. Инкапсуляция\n3. Полиморфизм\n4. Наследование",
                " 1. Возможность объекта иметь разные типы\n2. Сокрытие внутренней реализации\n3. Наследование\n4. Полиморфизм",
                " 1.C\n2. Java\n3. Python\n4. Все вышеперечисленные"
            };

            var random = new Random();
            questionOrder = Enumerable.Range(0, questions.Length).OrderBy(x => random.Next()).ToArray();

            correctAnswers = 0;
        }

        public void StartQuiz(ref int playerLevel)
        {
            Console.Clear();
            Console.WriteLine("Квиз начинается!");
            Console.WriteLine("Ответьте на вопросы, чтобы получить награды.");

            for (int i = 0; i < questionOrder.Length; i++)
            {
                int questionIndex = questionOrder[i];

                Console.Clear();
                Console.WriteLine(questions[questionIndex]);
                Console.WriteLine(answers[questionIndex]);

                ConsoleKeyInfo key;
                do
                {
                    Console.Write("Выберите ответ (1, 2, 3, 4): ");
                    key = Console.ReadKey();
                    Console.WriteLine();
                } while (key.KeyChar != '1' && key.KeyChar != '2' && key.KeyChar != '3' && key.KeyChar != '4');

                if (key.KeyChar == GetCorrectAnswer(questionIndex)[0])
                {
                    Console.WriteLine("Правильно!\n");
                    playerLevel++;
                    correctAnswers++;
                }
                else
                {
                    Console.WriteLine($"Неправильно. Правильный ответ: {GetCorrectAnswer(questionIndex)}\n");
                }

                Console.WriteLine("Нажмите Enter для следующего вопроса...");
                Console.ReadLine();
            }

            if (correctAnswers == 5)
            {
                Console.WriteLine("Поздравляем! Вы ответили правильно на все вопросы!");
                GiveRandomReward();
            }
            else if (correctAnswers == 4)
            {
                Console.WriteLine($"Вы ответили правильно на {correctAnswers} из 5 вопросов.");
                GiveRandomReward();
            }
            else if (correctAnswers == 3)
            {
                Console.WriteLine($"Вы ответили правильно на {correctAnswers} из 5 вопросов.");
                GiveRandomReward();
            }
            else if (correctAnswers == 2)
            {
                Console.WriteLine($"Вы ответили правильно на {correctAnswers} из 5 вопросов.");
                GiveRandomReward();
            }
            else if (correctAnswers == 1)
            {
                Console.WriteLine($"Вы ответили правильно на {correctAnswers} из 5 вопросов.");
                GiveRandomReward();
            }
            else
            {
                Console.WriteLine($"Вы ответили правильно на {correctAnswers} из 5 вопросов.");
            }

            Console.WriteLine("Нажмите Enter, чтобы вернуться в меню.");
            Console.ReadLine();
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

                Console.Write($"Вы получили награду: ");
                Console.ForegroundColor = reward.Color;
                Console.Write($"{reward.Name} ({reward.Rarity})!\n");
                Console.ResetColor();
                // Добавляем награду в инвентарь текущего игрока
                player.AddItemToInventory(reward);
            }
            else
            {
                Console.WriteLine($"К сожалению, нет подходящих наград для редкости: {rarity}");
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
