using System;
using System.Collections.Generic;

namespace HWCardDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            const string AnswerYes = "y";
            const string AnswerNo = "n";

            Game gamePoint = new Game();
            bool isGameWorks = true;
            string userInput;

            Console.WriteLine("Игра 21 очко.\n");
            Console.ReadKey();
            gamePoint.ShowRules();

            while (isGameWorks)
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
                    isGameWorks = false;
                else
                    Console.WriteLine("Не корректный ввод.\n");
            }
        }
    }

    class Game
    {
        private readonly Player _player = new Player();
        private readonly Deck _deck = new Deck();
        private readonly int _winPoints = 21;
        private readonly int _startingCardsQuantity = 2;
        private readonly Dictionary<Rank, int> _valueCards = new Dictionary<Rank, int>()
        {
            [Rank.Two] = 2,
            [Rank.Three] = 3,
            [Rank.Four] = 4,
            [Rank.Five] = 5,
            [Rank.Six] = 6,
            [Rank.Seven] = 7,
            [Rank.Eight] = 8,
            [Rank.Nine] = 9,
            [Rank.Ten] = 10,
            [Rank.J] = 10,
            [Rank.Q] = 10,
            [Rank.K] = 10,
            [Rank.A] = 11
        };

        public void StartPlay()
        {
            //_deck.ShowInfo();
            _deck.Shuffle();
            DealCards(_startingCardsQuantity, true);
            Play();
        }

        public void Play()
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
                        isWork = DealCards(dealCardsQuantity, isWork);
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
            int playerPoints = CalculateSumDeck(_player.GetCopyHand());

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

        public int CalculateSumDeck(List<Card> cards)
        {
            int valueCard;
            int sum = 0;

            foreach (Card card in cards)
            {
                valueCard = _valueCards[card.Relevance];
                sum += valueCard;
            }

            return sum;
        }

        public bool DealCards(int numberOfCards, bool isWork)
        {
            Card topCard = null;
            bool isGameOver = !isWork;
            int pointPlayer;

            for (int i = 0; i < numberOfCards; i++)
            {
                topCard = _deck.GiveCard();
                _player.TakeCard(topCard);
                pointPlayer = CalculateSumDeck(_player.GetCopyHand());

                if (pointPlayer >= _winPoints)
                {
                    isGameOver = true;
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

            if (isGameOver == true)
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
                $"\nВам выдано {_startingCardsQuantity} карты в руку." +
                $"\nДалее Вы можете: " +
                $"\nПосмотреть карты в руке, вытянуть еще карту, " +
                $"\nили закончить игру." +
                $"\nКолода после каждой вытянутой карты перетасовывается." +
                $"\nЕсли вы вытяните в общей сумме больше чем {_winPoints} очко, вы проиграете!");
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
            Suits[] suits = (Suits[])Enum.GetValues(typeof(Suits));
            Rank[] ranks = (Rank[])Enum.GetValues(typeof(Rank));

            foreach (Suits suit in suits)
            {
                foreach (Rank rank in ranks)
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

        public Card GiveCard()
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

        public void ShowInfo()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                _cards[i].ShowInfo();
            }

        }
    }

    class Card
    {
        private readonly Suits _suit;

        public Card(Suits suit, Rank relevance)
        {
            _suit = suit;
            Relevance = relevance;
        }

        public Rank Relevance { get; }

        public void ShowInfo()
        {
            Rank maxNumber = Rank.Ten;

            if (_suit == Suits.Spades || _suit == Suits.Clubs)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                if (Relevance <= maxNumber)
                {
                    if (Relevance == maxNumber)
                        Console.WriteLine($"{((char)_suit)}{((int)Relevance)}");
                    else
                        Console.WriteLine($"{((char)_suit)} {((int)Relevance)}");
                }
                else
                {
                    if (Relevance == maxNumber)
                        Console.WriteLine($"{((char)_suit)}{Relevance}");
                    else
                        Console.WriteLine($"{((char)_suit)} {Relevance}");
                }

            }
            else if (_suit == Suits.Hearts || _suit == Suits.Diamonds)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;

                if (Relevance <= maxNumber)
                {
                    if (Relevance == maxNumber)
                        Console.WriteLine($"{((char)_suit)}{((int)Relevance)}");
                    else
                        Console.WriteLine($"{((char)_suit)} {((int)Relevance)}");
                }
                else
                {
                    if (Relevance == maxNumber)
                        Console.WriteLine($"{((char)_suit)}{Relevance}");
                    else
                        Console.WriteLine($"{((char)_suit)} {Relevance}");
                }
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }

    class Player
    {
        private readonly List<Card> _cards = new List<Card>();

        public void TakeCard(Card card)
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

        public List<Card> GetCopyHand()
        {
            return new List<Card>(_cards);
        }
    }
}
