using System;
using System.Collections.Generic;

namespace HWCardDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Game gamePoint = new Game();

            bool gameWorks = true;
            string userInput;

            const string AnswerYes = "y";
            const string AnswerNo = "n";

            Console.WriteLine("Игра 21 очко.\n");
            Console.ReadKey();
            gamePoint.ShowRules();

            while (gameWorks)
            {
                Console.Clear();

                Console.WriteLine($"Начать игру?" +
                $"\n{AnswerYes}" +
                $"\n{AnswerNo}\n");
                userInput = Console.ReadLine();

                gamePoint = new Game();
                Console.Clear();

                if (userInput == AnswerYes)
                    gamePoint.StartPlay();
                else if (userInput == AnswerNo)
                    gameWorks = false;
                else
                    Console.WriteLine("Не корректный ввод.\n");

            }
        }
    }

    class Game
    {
        private readonly Player _player = new Player();
        private readonly Deck _deck = new Deck();
        private readonly List<Card> _handPlayer = new List<Card>();
        private readonly Dictionary<Card, int> _valueCards = new Dictionary<Card, int>();
        private readonly int _winPoints = 21;

        public void StartPlay()
        {
            Card topCard = null;

            int startingCardsQuantity = 2;

            _deck.Shuffle();
            AssignValueCards();
            DealCards(startingCardsQuantity, topCard, true);
            Play(topCard);
        }

        public void Play(Card topCard)
        {
            bool isWork = true;
            int dealCardsQuantity = 1;
            string userInput;

            while (isWork)
            {
                const string CommandShowCardsInHand = "1";
                const string CommandTakingCard = "2";
                const string CommandGameOver = "3";
                const string CommandShowRules = "0";

                Console.WriteLine("Выбирите действие:");
                ShowMenu(CommandShowCardsInHand, CommandTakingCard, CommandGameOver, CommandShowRules);
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandShowCardsInHand:
                        _player.ShowInfoHand();
                        break;

                    case CommandTakingCard:
                        isWork = DealCards(dealCardsQuantity, topCard, isWork);
                        break;

                    case CommandShowRules:
                        ShowRules();
                        break;

                    case CommandGameOver:
                        isWork = FinishPlay();
                        break;

                    default:
                        Console.WriteLine("Не корректный воод. \nНажмите клавишу, чтобы повторить...");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }
        }

        public bool FinishPlay()
        {
            bool isWork = false;
            int maxPoints = 21;
            int playerPoints = CalculateSumDeck(GetCardsInHand());

            if (playerPoints > maxPoints)
            {
                Console.WriteLine($"Вы набрали {playerPoints}. Это больше чем {maxPoints} очко." +
                    $"\nВы проиграли!");
            }
            else if (playerPoints == maxPoints)
            {
                Console.WriteLine($"Вы набрали {playerPoints} очко." +
                    $"\nВы выиграли!");
            }
            else
            {
                Console.WriteLine($"Вы набрали {playerPoints}. Это меньше чем {maxPoints} очко." +
                    $"\nПопробуйте снова!");
            }

            Console.ReadKey();

            return isWork;
        }

        public List<Card> GetCardsInHand()
        {
            _handPlayer.Clear();

            for (int i = 0; i < _player.GetCardsCount(); i++)
            {
                _handPlayer.Add(_player.GetCardById(i));
            }

            return _handPlayer;
        }

        public void AssignValueCards()
        {
            List<Card> cards = _deck.GetAllCards();

            const int ValueTwo = 2;
            const int ValueThree = 3;
            const int ValueFour = 4;
            const int ValueFive = 5;
            const int ValueSix = 6;
            const int ValueSeven = 7;
            const int ValueEight = 8;
            const int ValueNine = 9;
            const int ValueHighCards = 10;
            const int MaxValue = 11;

            foreach (Card card in cards)
            {
                switch (card.Relevance)
                {
                    case Rank.Two:
                        _valueCards.Add(card, ValueTwo);
                        break;

                    case Rank.Three:
                        _valueCards.Add(card, ValueThree);
                        break;

                    case Rank.Four:
                        _valueCards.Add(card, ValueFour);
                        break;

                    case Rank.Five:
                        _valueCards.Add(card, ValueFive);
                        break;

                    case Rank.Six:
                        _valueCards.Add(card, ValueSix);
                        break;

                    case Rank.Seven:
                        _valueCards.Add(card, ValueSeven);
                        break;

                    case Rank.Eight:
                        _valueCards.Add(card, ValueEight);
                        break;

                    case Rank.Nine:
                        _valueCards.Add(card, ValueNine);
                        break;

                    case Rank.Ten:
                    case Rank.J:
                    case Rank.Q:
                    case Rank.K:
                        _valueCards.Add(card, ValueHighCards);
                        break;

                    case Rank.A:
                        _valueCards.Add(card, MaxValue);
                        break;
                }
            }
        }

        public int CalculateSumDeck(List<Card> cards)
        {
            int valueCard;
            int sum = 0;

            foreach (Card card in cards)
            {
                valueCard = _valueCards[card];
                sum += valueCard;
            }

            return sum;
        }

        public bool DealCards(int numberOfCards, Card topCard, bool isWork)
        {
            bool gameover = !isWork;
            int pointPlayer;

            for (int i = 0; i < numberOfCards; i++)
            {
                topCard = _deck.GetCard();
                _player.DrawCards(topCard);
                pointPlayer = CalculateSumDeck(GetCardsInHand());

                if (pointPlayer >= _winPoints)
                {
                    gameover = true;
                }

                _deck.Shuffle();
            }

            if (numberOfCards == 1)
            {
                Console.Clear();
                Console.WriteLine("Вытянутая карта:\n");
                topCard.ShowInfo();
                Console.ReadKey();
            }

            if (gameover == true)
            {
                isWork = FinishPlay();
            }

            return isWork;
        }

        public void ShowRules()
        {
            Console.Clear();
            Console.WriteLine("Правила\n\n" + new string('-', 50));
            Console.WriteLine($"Есть колода карт." +
                $"\nВам выдано 2 карты в руку." +
                $"\nДалее Вы можете: " +
                $"\nПосмотреть карты в руке, вытянуть еще карту, " +
                $"\nили закончить игру." +
                $"\nКолода после каждой вытянутой карты перетасовывается." +
                $"\nЕсли вы вытяните в общей сумме больше чем 21 очко, вы проиграете!");
            Console.WriteLine(new string('-', 50) + "\n");
            Console.ReadKey();
        }

        public void ShowMenu(string CommandShowInfo, string CommandTakingCard, string CommandGameOver, string CommandShowRules)
        {
            Console.WriteLine($"{CommandShowInfo} - Посмотреть карты в руке" +
                $"\n{CommandTakingCard} - Вытянуть еще карту из колоды" +
                $"\n{CommandGameOver} - Закончить игру" +
                $"\n{CommandShowRules} - Показать правила\n");
        }
    }

    enum Rank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        J,
        Q,
        K,
        A
    }

    enum Suits
    {
        Hearts = '♥',
        Diamonds = '♦',
        Clubs = '♣',
        Spades = '♠'
    }

    class Deck
    {
        private readonly List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();
            Create();
        }

        private void Create()
        {
            foreach (Suits suit in (Suits[])Enum.GetValues(typeof(Suits)))
            {
                foreach (Rank rank in (Rank[])Enum.GetValues(typeof(Rank)))
                {
                    Card card = new Card(suit, rank);
                    _cards.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();

            for (int i = _cards.Count - 1; i >= 0; i--)
            {
                int randomCard = random.Next(_cards.Count);
                (_cards[i], _cards[randomCard]) = (_cards[randomCard], _cards[i]);
            }
        }

        public Card GetCard()
        {
            Card topCard = _cards[_cards.Count - 1];
            _cards.Remove(topCard);

            return topCard;
        }

        public List<Card> GetAllCards()
        {
            List<Card> deckCards = new List<Card>();

            for (int i = 0; i < _cards.Count; i++)
            {
                deckCards.Add(_cards[i]);
            }

            return deckCards;
        }
    }

    class Card
    {
        public Card(Suits suit, Rank relevance)
        {
            Suit = suit;
            Relevance = relevance;
        }

        public Suits Suit { get; private set; }
        public Rank Relevance { get; private set; }

        public void ShowInfo()
        {
            Rank maxNumber = Rank.Ten;

            if (Suit == Suits.Spades || Suit == Suits.Clubs)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                if (Relevance <= maxNumber)
                {
                    if (Relevance == maxNumber)
                        Console.WriteLine($"{((char)Suit)}{((int)Relevance)}");
                    else
                        Console.WriteLine($"{((char)Suit)} {((int)Relevance)}");
                }
                else
                {
                    if (Relevance == maxNumber)
                        Console.WriteLine($"{((char)Suit)}{Relevance}");
                    else
                        Console.WriteLine($"{((char)Suit)} {Relevance}");
                }

            }
            else if (Suit == Suits.Hearts || Suit == Suits.Diamonds)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;

                if (Relevance <= maxNumber)
                {
                    if (Relevance == maxNumber)
                        Console.WriteLine($"{((char)Suit)}{((int)Relevance)}");
                    else
                        Console.WriteLine($"{((char)Suit)} {((int)Relevance)}");
                }
                else
                {
                    if (Relevance == maxNumber)
                        Console.WriteLine($"{((char)Suit)}{Relevance}");
                    else
                        Console.WriteLine($"{((char)Suit)} {Relevance}");
                }
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }

    class Player
    {
        private readonly List<Card> _cards = new List<Card>();

        public void DrawCards(Card card)
        {
            _cards.Add(card);
        }

        public void ShowInfoHand()
        {
            Console.Clear();

            for (int i = 0; i < _cards.Count; i++)
            {
                _cards[i].ShowInfo();
            }

            Console.ReadKey();
        }

        public int GetCardsCount()
        {
            return _cards.Count;
        }

        public Card GetCardById(int id)
        {
            return _cards[id];
        }
    }
}
