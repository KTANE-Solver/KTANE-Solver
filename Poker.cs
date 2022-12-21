using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Date: 5/30/21
    /// Purpose: Solves the poker module
    /// </summary>
    public class Poker : Module
    {
        //ace tree
        BinaryTree aceTree;

        //king tree
        BinaryTree kingTree;

        //diamond tree
        BinaryTree fiveTree;

        //club tree
        BinaryTree twoTree;

        //the first card
        Card startingCard;

        public List<Card> hand;

        //opponent's response
        public String response;

        public Poker(Bomb bomb, StreamWriter logFileWriter, String startingCard)
            : base(bomb, logFileWriter, "Poker")
        {
            //find the starting card
            switch (startingCard)
            {
                case "KING":
                    this.startingCard = new Card(Card.Number.KING, Card.Suite.HEART);
                    break;

                case "FIVE":
                    this.startingCard = new Card(Card.Number.FIVE, Card.Suite.DIAMOND);
                    break;

                case "TWO":
                    this.startingCard = new Card(Card.Number.TWO, Card.Suite.CLUB);
                    ;
                    break;

                case "ACE":
                    this.startingCard = new Card(Card.Number.ACE, Card.Suite.SPADE);
                    break;
            }

            //set up ace tree

            //more than 3 batteries
            aceTree = new BinaryTree(
                new Card(Card.Number.ACE, Card.Suite.SPADE),
                Bomb.Battery >= 3
            );

            //second card

            //1. a lit frk or bob
            //2. serial contain vowel
            aceTree.SetChildren(
                aceTree.Root,
                new Card(Card.Number.THREE, Card.Suite.SPADE),
                new Card(Card.Number.JACK, Card.Suite.DIAMOND),
                Bomb.Frk.Lit || Bomb.Bob.Visible,
                Bomb.HasVowel
            );

            //third card

            //1. total serial digits equal even
            //2. more d batteires than aa batteries
            aceTree.SetChildren(
                aceTree.Root.LeftNode,
                new Card(Card.Number.FIVE, Card.Suite.SPADE),
                new Card(Card.Number.NINE, Card.Suite.HEART),
                Bomb.DigitSum % 2 == 0,
                Bomb.DBattery > Bomb.AABattery
            );

            //1. unlit car
            //2. serial port?
            aceTree.SetChildren(
                aceTree.Root.RightNode,
                new Card(Card.Number.JACK, Card.Suite.CLUB),
                new Card(Card.Number.FOUR, Card.Suite.CLUB),
                Bomb.Car.VisibleNotLit,
                Bomb.RCAVisuble
            );

            //fourth card

            //1. rj port
            //2. ps port
            aceTree.SetChildren(
                aceTree.Root.LeftNode.LeftNode,
                new Card(Card.Number.TWO, Card.Suite.SPADE),
                new Card(Card.Number.THREE, Card.Suite.DIAMOND),
                Bomb.RJVisible,
                Bomb.PSVisible
            );

            //1. serial contain vowel
            //2. last digit of sieral even
            aceTree.SetChildren(
                aceTree.Root.LeftNode.RightNode,
                new Card(Card.Number.QUEEN, Card.Suite.CLUB),
                new Card(Card.Number.ACE, Card.Suite.DIAMOND),
                Bomb.HasVowel,
                Bomb.LastDigit % 2 == 0
            );

            //1. dvid port
            //2. parallel port
            aceTree.SetChildren(
                aceTree.Root.RightNode.LeftNode,
                new Card(Card.Number.JACK, Card.Suite.SPADE),
                new Card(Card.Number.ACE, Card.Suite.HEART),
                Bomb.DVIVisble,
                Bomb.PPVisuble
            );

            //1, unlit snd or trn
            //2, lit sig or frq
            aceTree.SetChildren(
                aceTree.Root.RightNode.RightNode,
                new Card(Card.Number.SIX, Card.Suite.DIAMOND),
                new Card(Card.Number.QUEEN, Card.Suite.DIAMOND),
                Bomb.Snd.VisibleNotLit || Bomb.Trn.Visible,
                Bomb.Sig.Lit || Bomb.Frq.Visible
            );

            //fifth card
            aceTree.SetChildren(
                aceTree.Root.LeftNode.LeftNode.LeftNode,
                new Card(Card.Number.FOUR, Card.Suite.SPADE),
                new Card(Card.Number.EIGHT, Card.Suite.SPADE),
                false,
                false
            );
            aceTree.SetChildren(
                aceTree.Root.LeftNode.LeftNode.RightNode,
                new Card(Card.Number.THREE, Card.Suite.CLUB),
                new Card(Card.Number.ACE, Card.Suite.CLUB),
                false,
                false
            );

            aceTree.SetChildren(
                aceTree.Root.LeftNode.RightNode.LeftNode,
                new Card(Card.Number.JACK, Card.Suite.DIAMOND),
                new Card(Card.Number.THREE, Card.Suite.DIAMOND),
                false,
                false
            );
            aceTree.SetChildren(
                aceTree.Root.LeftNode.RightNode.RightNode,
                new Card(Card.Number.ACE, Card.Suite.CLUB),
                new Card(Card.Number.SIX, Card.Suite.HEART),
                false,
                false
            );

            aceTree.SetChildren(
                aceTree.Root.RightNode.LeftNode.LeftNode,
                new Card(Card.Number.JACK, Card.Suite.HEART),
                new Card(Card.Number.ACE, Card.Suite.HEART),
                false,
                false
            );
            aceTree.SetChildren(
                aceTree.Root.RightNode.LeftNode.RightNode,
                new Card(Card.Number.TWO, Card.Suite.CLUB),
                new Card(Card.Number.ACE, Card.Suite.CLUB),
                false,
                false
            );

            aceTree.SetChildren(
                aceTree.Root.RightNode.RightNode.LeftNode,
                new Card(Card.Number.THREE, Card.Suite.CLUB),
                new Card(Card.Number.FOUR, Card.Suite.SPADE),
                false,
                false
            );
            aceTree.SetChildren(
                aceTree.Root.RightNode.RightNode.RightNode,
                new Card(Card.Number.TEN, Card.Suite.SPADE),
                new Card(Card.Number.ACE, Card.Suite.CLUB),
                false,
                false
            );

            //set up king tree

            //digit sum of serial is odd
            kingTree = new BinaryTree(
                new Card(Card.Number.KING, Card.Suite.HEART),
                Bomb.DigitSum % 2 == 1
            );

            //second card

            //any batteries
            //parallel port
            kingTree.SetChildren(
                kingTree.Root,
                new Card(Card.Number.FOUR, Card.Suite.CLUB),
                new Card(Card.Number.THREE, Card.Suite.DIAMOND),
                Bomb.Battery > 0,
                Bomb.PPVisuble
            );

            //third card

            //lit ind, msa, trn
            //ps or dvid
            kingTree.SetChildren(
                kingTree.Root.LeftNode,
                new Card(Card.Number.FOUR, Card.Suite.HEART),
                new Card(Card.Number.ACE, Card.Suite.HEART),
                Bomb.Ind.Lit || Bomb.Msa.Lit || Bomb.Trn.Lit,
                Bomb.PSVisible || Bomb.DVIVisble
            );

            //three or fewer aa batteries
            //unlit bob or frq
            kingTree.SetChildren(
                kingTree.Root.RightNode,
                new Card(Card.Number.THREE, Card.Suite.SPADE),
                new Card(Card.Number.FOUR, Card.Suite.HEART),
                Bomb.AABattery <= 3,
                Bomb.Bob.VisibleNotLit || Bomb.Frq.VisibleNotLit
            );

            //fourth card

            //stereo rca
            //rj and serial
            kingTree.SetChildren(
                kingTree.Root.LeftNode.LeftNode,
                new Card(Card.Number.FOUR, Card.Suite.SPADE),
                new Card(Card.Number.KING, Card.Suite.SPADE),
                Bomb.RCAVisuble,
                Bomb.RJVisible || Bomb.RCAVisuble
            );

            //lit sind
            //unlit trn or frk
            kingTree.SetChildren(
                kingTree.Root.LeftNode.RightNode,
                new Card(Card.Number.TWO, Card.Suite.CLUB),
                new Card(Card.Number.QUEEN, Card.Suite.SPADE),
                Bomb.Snd.Lit,
                Bomb.Trn.VisibleNotLit || Bomb.Frk.VisibleNotLit
            );

            //lit frq
            //unlit msa or lit nsa
            kingTree.SetChildren(
                kingTree.Root.RightNode.LeftNode,
                new Card(Card.Number.TWO, Card.Suite.DIAMOND),
                new Card(Card.Number.SEVEN, Card.Suite.SPADE),
                Bomb.Msa.VisibleNotLit || Bomb.Nsa.Lit,
                Bomb.Frq.Lit
            );

            //more aa than d
            //five or fewr batteries
            kingTree.SetChildren(
                kingTree.Root.RightNode.RightNode,
                new Card(Card.Number.TEN, Card.Suite.CLUB),
                new Card(Card.Number.TWO, Card.Suite.CLUB),
                Bomb.AABattery > Bomb.DBattery,
                Bomb.Battery <= 5
            );

            //fifth card
            kingTree.SetChildren(
                kingTree.Root.LeftNode.LeftNode.LeftNode,
                new Card(Card.Number.FOUR, Card.Suite.DIAMOND),
                new Card(Card.Number.KING, Card.Suite.CLUB),
                false,
                false
            );
            kingTree.SetChildren(
                kingTree.Root.LeftNode.LeftNode.RightNode,
                new Card(Card.Number.THREE, Card.Suite.CLUB),
                new Card(Card.Number.KING, Card.Suite.CLUB),
                false,
                false
            );

            kingTree.SetChildren(
                kingTree.Root.LeftNode.RightNode.LeftNode,
                new Card(Card.Number.THREE, Card.Suite.SPADE),
                new Card(Card.Number.FOUR, Card.Suite.DIAMOND),
                false,
                false
            );
            kingTree.SetChildren(
                kingTree.Root.LeftNode.RightNode.RightNode,
                new Card(Card.Number.THREE, Card.Suite.CLUB),
                new Card(Card.Number.FIVE, Card.Suite.CLUB),
                false,
                false
            );

            kingTree.SetChildren(
                kingTree.Root.RightNode.LeftNode.LeftNode,
                new Card(Card.Number.NINE, Card.Suite.CLUB),
                new Card(Card.Number.THREE, Card.Suite.HEART),
                false,
                false
            );
            kingTree.SetChildren(
                kingTree.Root.RightNode.LeftNode.RightNode,
                new Card(Card.Number.TWO, Card.Suite.CLUB),
                new Card(Card.Number.SEVEN, Card.Suite.DIAMOND),
                false,
                false
            );

            kingTree.SetChildren(
                kingTree.Root.RightNode.RightNode.LeftNode,
                new Card(Card.Number.KING, Card.Suite.CLUB),
                new Card(Card.Number.QUEEN, Card.Suite.SPADE),
                false,
                false
            );
            kingTree.SetChildren(
                kingTree.Root.RightNode.RightNode.RightNode,
                new Card(Card.Number.ACE, Card.Suite.HEART),
                new Card(Card.Number.NINE, Card.Suite.CLUB),
                false,
                false
            );

            //diamond tree

            //there are more aa than b
            fiveTree = new BinaryTree(
                new Card(Card.Number.FIVE, Card.Suite.DIAMOND),
                Bomb.AABattery > Bomb.DBattery
            );

            //second card

            //serial contains vowel
            //last digit of the serial an odd number
            fiveTree.SetChildren(
                fiveTree.Root,
                new Card(Card.Number.THREE, Card.Suite.CLUB),
                new Card(Card.Number.NINE, Card.Suite.DIAMOND),
                Bomb.HasVowel,
                Bomb.LastDigit % 2 == 1
            );

            //third card

            //more than one port
            //ther are ps or rj port
            fiveTree.SetChildren(
                fiveTree.Root.LeftNode,
                new Card(Card.Number.TWO, Card.Suite.SPADE),
                new Card(Card.Number.NINE, Card.Suite.HEART),
                Bomb.PortNum > 1,
                Bomb.PSVisible || Bomb.RJVisible
            );

            //bob or unlit frq or sig
            //any lit indicators
            fiveTree.SetChildren(
                fiveTree.Root.RightNode,
                new Card(Card.Number.FOUR, Card.Suite.DIAMOND),
                new Card(Card.Number.SIX, Card.Suite.DIAMOND),
                Bomb.Bob.Lit || Bomb.Frq.VisibleNotLit || Bomb.Sig.Visible,
                Bomb.LitIndicatorsList.Count > 0
            );

            //fourth card

            //unlit clr or lit car
            //lit msa or unlit nsa
            fiveTree.SetChildren(
                fiveTree.Root.LeftNode.LeftNode,
                new Card(Card.Number.ACE, Card.Suite.HEART),
                new Card(Card.Number.SIX, Card.Suite.HEART),
                Bomb.Clr.VisibleNotLit || Bomb.Car.Lit,
                Bomb.Msa.Lit || Bomb.Nsa.VisibleNotLit
            );

            //any unlit indicator
            //ulit clr
            fiveTree.SetChildren(
                fiveTree.Root.LeftNode.RightNode,
                new Card(Card.Number.TEN, Card.Suite.SPADE),
                new Card(Card.Number.JACK, Card.Suite.SPADE),
                Bomb.UnlitIndicatorsList.Count > 0,
                Bomb.Car.VisibleNotLit
            );

            //any port
            //parallel port
            fiveTree.SetChildren(
                fiveTree.Root.RightNode.LeftNode,
                new Card(Card.Number.KING, Card.Suite.DIAMOND),
                new Card(Card.Number.ACE, Card.Suite.DIAMOND),
                Bomb.PortNum > 0,
                Bomb.PPVisuble
            );

            //fewer than three ports
            //rca and dvid port
            fiveTree.SetChildren(
                fiveTree.Root.RightNode.RightNode,
                new Card(Card.Number.SEVEN, Card.Suite.DIAMOND),
                new Card(Card.Number.FIVE, Card.Suite.CLUB),
                Bomb.PortNum < 3,
                Bomb.RCAVisuble && Bomb.DVIVisble
            );

            //fifth card
            fiveTree.SetChildren(
                fiveTree.Root.LeftNode.LeftNode.LeftNode,
                new Card(Card.Number.FOUR, Card.Suite.DIAMOND),
                new Card(Card.Number.SIX, Card.Suite.DIAMOND),
                false,
                false
            );
            fiveTree.SetChildren(
                fiveTree.Root.LeftNode.LeftNode.RightNode,
                new Card(Card.Number.FOUR, Card.Suite.SPADE),
                new Card(Card.Number.THREE, Card.Suite.DIAMOND),
                false,
                false
            );

            fiveTree.SetChildren(
                fiveTree.Root.LeftNode.RightNode.LeftNode,
                new Card(Card.Number.JACK, Card.Suite.CLUB),
                new Card(Card.Number.NINE, Card.Suite.SPADE),
                false,
                false
            );
            fiveTree.SetChildren(
                fiveTree.Root.LeftNode.RightNode.RightNode,
                new Card(Card.Number.QUEEN, Card.Suite.HEART),
                new Card(Card.Number.FIVE, Card.Suite.HEART),
                false,
                false
            );

            fiveTree.SetChildren(
                fiveTree.Root.RightNode.LeftNode.LeftNode,
                new Card(Card.Number.KING, Card.Suite.HEART),
                new Card(Card.Number.QUEEN, Card.Suite.DIAMOND),
                false,
                false
            );
            fiveTree.SetChildren(
                fiveTree.Root.RightNode.LeftNode.RightNode,
                new Card(Card.Number.TWO, Card.Suite.DIAMOND),
                new Card(Card.Number.SIX, Card.Suite.SPADE),
                false,
                false
            );

            fiveTree.SetChildren(
                fiveTree.Root.RightNode.RightNode.LeftNode,
                new Card(Card.Number.EIGHT, Card.Suite.DIAMOND),
                new Card(Card.Number.EIGHT, Card.Suite.HEART),
                false,
                false
            );
            fiveTree.SetChildren(
                fiveTree.Root.RightNode.RightNode.RightNode,
                new Card(Card.Number.FIVE, Card.Suite.SPADE),
                new Card(Card.Number.SIX, Card.Suite.SPADE),
                false,
                false
            );

            //twoTree tree

            //lit trn bob or ind
            twoTree = new BinaryTree(
                new Card(Card.Number.TWO, Card.Suite.CLUB),
                Bomb.Trn.Lit || Bomb.Bob.Visible || Bomb.Ind.Visible
            );

            //second card

            //five or fewer batteries
            //serial contain even number of letters
            twoTree.SetChildren(
                twoTree.Root,
                new Card(Card.Number.SIX, Card.Suite.CLUB),
                new Card(Card.Number.THREE, Card.Suite.HEART),
                Bomb.Battery <= 5,
                Bomb.LetterNum % 2 == 0
            );

            //third card

            //dvid or stereo
            //digits of the serial add up to more than 12
            twoTree.SetChildren(
                twoTree.Root.LeftNode,
                new Card(Card.Number.TEN, Card.Suite.CLUB),
                new Card(Card.Number.ACE, Card.Suite.SPADE),
                Bomb.DVIVisble || Bomb.RCAVisuble,
                Bomb.DigitSum > 12
            );

            //parallel and serial
            //rj port
            twoTree.SetChildren(
                twoTree.Root.RightNode,
                new Card(Card.Number.FOUR, Card.Suite.HEART),
                new Card(Card.Number.KING, Card.Suite.HEART),
                Bomb.PPVisuble && Bomb.RCAVisuble,
                Bomb.RJVisible
            );

            //fourth card

            //last letter of seiral is a consonant
            //last digit of serial odd
            twoTree.SetChildren(
                twoTree.Root.LeftNode.LeftNode,
                new Card(Card.Number.JACK, Card.Suite.HEART),
                new Card(Card.Number.JACK, Card.Suite.CLUB),
                !Bomb.LastLetterIsVowel,
                Bomb.LastDigit % 2 == 1
            );

            //ps and parallel
            //three or fewer ports
            twoTree.SetChildren(
                twoTree.Root.LeftNode.RightNode,
                new Card(Card.Number.TWO, Card.Suite.DIAMOND),
                new Card(Card.Number.SIX, Card.Suite.HEART),
                Bomb.PSVisible && Bomb.PPVisuble,
                Bomb.PortNum <= 3
            );

            //more aa than d
            //more d than aa
            twoTree.SetChildren(
                twoTree.Root.RightNode.LeftNode,
                new Card(Card.Number.FIVE, Card.Suite.SPADE),
                new Card(Card.Number.SIX, Card.Suite.HEART),
                Bomb.AABattery > Bomb.DBattery,
                Bomb.DBattery > Bomb.AABattery
            );

            //more than 2 d
            //mor than 2 batteries
            twoTree.SetChildren(
                twoTree.Root.RightNode.RightNode,
                new Card(Card.Number.KING, Card.Suite.CLUB),
                new Card(Card.Number.FOUR, Card.Suite.DIAMOND),
                Bomb.DBattery > 2,
                Bomb.Battery > 2
            );

            //fifth card
            twoTree.SetChildren(
                twoTree.Root.LeftNode.LeftNode.LeftNode,
                new Card(Card.Number.QUEEN, Card.Suite.CLUB),
                new Card(Card.Number.TWO, Card.Suite.DIAMOND),
                false,
                false
            );
            twoTree.SetChildren(
                twoTree.Root.LeftNode.LeftNode.RightNode,
                new Card(Card.Number.FOUR, Card.Suite.CLUB),
                new Card(Card.Number.KING, Card.Suite.CLUB),
                false,
                false
            );

            twoTree.SetChildren(
                twoTree.Root.LeftNode.RightNode.LeftNode,
                new Card(Card.Number.SIX, Card.Suite.DIAMOND),
                new Card(Card.Number.TWO, Card.Suite.HEART),
                false,
                false
            );
            twoTree.SetChildren(
                twoTree.Root.LeftNode.RightNode.RightNode,
                new Card(Card.Number.ACE, Card.Suite.HEART),
                new Card(Card.Number.SEVEN, Card.Suite.SPADE),
                false,
                false
            );

            twoTree.SetChildren(
                twoTree.Root.RightNode.LeftNode.LeftNode,
                new Card(Card.Number.SIX, Card.Suite.CLUB),
                new Card(Card.Number.FIVE, Card.Suite.DIAMOND),
                false,
                false
            );
            twoTree.SetChildren(
                twoTree.Root.RightNode.LeftNode.RightNode,
                new Card(Card.Number.FIVE, Card.Suite.HEART),
                new Card(Card.Number.KING, Card.Suite.HEART),
                false,
                false
            );

            twoTree.SetChildren(
                twoTree.Root.RightNode.RightNode.LeftNode,
                new Card(Card.Number.THREE, Card.Suite.SPADE),
                new Card(Card.Number.KING, Card.Suite.SPADE),
                false,
                false
            );
            twoTree.SetChildren(
                twoTree.Root.RightNode.RightNode.RightNode,
                new Card(Card.Number.JACK, Card.Suite.CLUB),
                new Card(Card.Number.TWO, Card.Suite.DIAMOND),
                false,
                false
            );
        }

        /// <summary>
        /// A method that will set up the hand. YES IS LEFT. RIGHT IS NO
        /// </summary>
        public void SetHand()
        {
            hand = new List<Card>();

            hand.Add(startingCard);

            BinaryTreeNode currentNode;

            //get the second card
            if (startingCard.number == Card.Number.ACE)
            {
                currentNode = ChoosePath(aceTree.Root);
            }
            else if (startingCard.number == Card.Number.TWO)
            {
                currentNode = ChoosePath(twoTree.Root);
            }
            else if (startingCard.number == Card.Number.KING)
            {
                currentNode = ChoosePath(kingTree.Root);
            }
            else
            {
                currentNode = ChoosePath(fiveTree.Root);
            }

            hand.Add(currentNode.Data);

            //get the third,fourht, and fifth cards

            for (int i = 0; i < 3; i++)
            {
                currentNode = ChoosePath(currentNode);

                hand.Add(currentNode.Data);
            }
        }

        /// <summary>
        /// Will return the next card that needs to be added to the hand
        /// </summary>
        /// <param name="condition">the condition of wheter to go left or right</param>
        /// <param name="parent"></param>
        /// <param name="tree"></param>
        /// <returns></returns>
        public BinaryTreeNode ChoosePath(BinaryTreeNode parent)
        {
            if (parent.Condition)
            {
                return parent.LeftNode;
            }

            return parent.RightNode;
        }

        /// <summary>
        /// Will tell what rank the user has given the hand
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public String SetRank(Card[] hand)
        {
            //sort the cards from lowest to highest based on the numbers
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if ((int)hand[i].number < (int)hand[j].number)
                    {
                        Card temp = hand[i];
                        hand[i] = hand[j];
                        hand[j] = temp;
                    }
                }
            }

            //royal flush - Ten, Jack, Queen, King, Ace of the same suit
            bool kingFound = FindNumber(Card.Number.KING, hand);
            bool queenFound = FindNumber(Card.Number.QUEEN, hand);
            bool jackFound = FindNumber(Card.Number.JACK, hand);
            bool aceFound = FindNumber(Card.Number.ACE, hand);
            bool tenFound = FindNumber(Card.Number.TEN, hand);

            if (
                hand[0].suite == hand[1].suite
                && hand[0].suite == hand[2].suite
                && hand[0].suite == hand[3].suite
                && hand[0].suite == hand[4].suite
                && kingFound
                && queenFound
                && jackFound
                && aceFound
                && tenFound
            )
            {
                return "Royal Flush";
            }

            //straight flush - Five consecutive values of the same suit
            if (
                hand[0].suite == hand[1].suite
                && hand[0].suite == hand[2].suite
                && hand[0].suite == hand[3].suite
                && hand[0].suite == hand[4].suite
            )
            {
                //check to see if there is a straight flush noramally
                if (
                    (int)hand[0].number + 1 == (int)hand[1].number
                    && (int)hand[1].number + 1 == (int)hand[2].number
                    && (int)hand[2].number + 1 == (int)hand[3].number
                    && (int)hand[3].number + 1 == (int)hand[4].number
                )
                {
                    return "Straight Flush";
                }

                //if there is an Ace, check to see if it with the ace being at the bottom
                if (
                    FindNumber(Card.Number.ACE, hand)
                    && (int)hand[0].number + 1 == (int)hand[1].number
                    && (int)hand[1].number + 1 == (int)hand[2].number
                    && (int)hand[2].number + 1 == (int)hand[3].number
                )
                {
                    return "Straight Flush";
                }
            }

            //four of a kind - four cards of the same value
            foreach (Card card in hand)
            {
                if (FindNumberNum(card.number, hand) == 4)
                    return "Four of a Kind";
            }

            //full house - three cards of the same value and two cards if another value
            bool foundThreeSameNumber = false;

            foreach (Card card in hand)
            {
                if (FindNumberNum(card.number, hand) == 3)
                {
                    foundThreeSameNumber = true;
                    break;
                }
            }

            if (foundThreeSameNumber)
            {
                foreach (Card card in hand)
                {
                    if (FindNumberNum(card.number, hand) == 2)
                    {
                        return "Full House";
                    }
                }
            }

            //flush - five cards of the same suit
            if (
                hand[0].suite == hand[1].suite
                && hand[0].suite == hand[2].suite
                && hand[0].suite == hand[3].suite
                && hand[0].suite == hand[4].suite
            )
            {
                return "Flush";
            }

            //straight - Five consecutive values of any suit

            //check to see if there is a straight noramally
            if (
                (int)hand[0].number + 1 == (int)hand[1].number
                && (int)hand[1].number + 1 == (int)hand[2].number
                && (int)hand[2].number + 1 == (int)hand[3].number
                && (int)hand[3].number + 1 == (int)hand[4].number
            )
            {
                return "Straight";
            }

            //if there is an Ace, check to see if it with the ace being at the bottom
            if (
                FindNumber(Card.Number.ACE, hand)
                && (int)hand[0].number + 1 == (int)hand[1].number
                && (int)hand[1].number + 1 == (int)hand[2].number
                && (int)hand[2].number + 1 == (int)hand[3].number
            )
            {
                return "Straight";
            }

            //three of a kind - three cards of the same value
            foreach (Card card in hand)
            {
                if (FindNumberNum(card.number, hand) == 3)
                {
                    return "Three of a Kind";
                }
            }

            //two pair - two cars of the same value and two cards of another value
            Card firstPair = null;

            foreach (Card card in hand)
            {
                if (FindNumberNum(card.number, hand) == 2)
                {
                    firstPair = card;
                    break;
                }
            }

            if (firstPair != null)
            {
                foreach (Card card in hand)
                {
                    if (firstPair != card && FindNumberNum(card.number, hand) == 2)
                    {
                        return "Two Pair";
                    }
                }
            }

            //Pair - two cards of the same value
            foreach (Card card in hand)
            {
                if (FindNumberNum(card.number, hand) == 2)
                {
                    return "Pair";
                }
            }

            return "No Hand";
        }

        /// <summary>
        /// Tells wether bluff or truth given opponent response
        /// </summary>
        /// <returns></returns>
        public String BluffTruth()
        {
            switch (response)
            {
                case "Terrible play!":

                    if (startingCard.number == Card.Number.TWO)
                        return "Bluff";

                    return "Truth";

                case "Awful play!":
                    if (
                        startingCard.number == Card.Number.TWO
                        || startingCard.number == Card.Number.ACE
                    )
                        return "Bluff";

                    return "Truth";

                case "Really?":
                    if (startingCard.number == Card.Number.ACE)
                        return "Truth";

                    return "Bluff";

                case "Really, really?":
                    if (startingCard.number == Card.Number.FIVE)
                        return "Truth";

                    return "Bluff";

                case "Sure about that?":
                    if (
                        startingCard.number == Card.Number.KING
                        || startingCard.number == Card.Number.FIVE
                    )
                        return "Bluff";

                    return "Truth";

                case "Are you sure?":
                    if (startingCard.number == Card.Number.ACE)
                        return "Bluff";

                    return "Truth";
            }

            return "Bluff";
        }

        /// <summary>
        /// A method that tells the user which card to press
        /// </summary>
        /// <param name="betAmount"></param>
        /// <returns></returns>
        public int BettingRule(int betAmount, Card card1, Card card2, Card card3, Card card4)
        {
            switch (betAmount)
            {
                case 25:

                    //If the first card is red and there is a lit BOB indicator, press the fourth card.
                    if (
                        (card1.suite == Card.Suite.DIAMOND || card1.suite == Card.Suite.HEART)
                        && Bomb.Bob.Lit
                    )
                        return 4;

                    //Otherwise, if your opponent said "Awful play!" and the starter card was the Ace of Spades, press the first card.
                    if (response == "Awful play!" && startingCard.number == Card.Number.ACE)
                        return 1;

                    //Otherwise, if there is an unlit FRQ indicator and the fourth card is black, press the second card.
                    if (
                        Bomb.Frq.VisibleNotLit
                        && (card4.suite == Card.Suite.CLUB || card4.suite == Card.Suite.SPADE)
                    )
                        return 2;

                    //Otherwise, if there is at least one diamond and your opponent said "Really?" or "Really, really?", press the third card.
                    if (
                        DiamondNum(card1, card2, card3, card4) >= 1
                        && (response == "Really, really?" || response == "Really?")
                    )
                        return 3;

                    //Otherwise, if the fourth card is a spade and there are more than four batteries, press the third card.
                    if (card4.suite == Card.Suite.SPADE && Bomb.Battery > 4)
                        return 3;

                    //Otherwise, if the third card is a diamond and the second card is not a club, press the second card.
                    if (card3.suite == Card.Suite.DIAMOND && card2.suite != Card.Suite.CLUB)
                        return 2;

                    //Otherwise, if your opponent said "Are you sure?" and the starter card was the Two of Clubs, press the first card.
                    if (response == "Are you sure?" && startingCard.suite == Card.Suite.CLUB)
                        return 1;

                    //Otherwise, if the starter card was the Five of Diamonds, press the fourth card.
                    if (startingCard.suite == Card.Suite.DIAMOND)
                        return 4;

                    //Otherwise, if the second card is a club and there is no RJ - 45 port, press the second card.
                    if (card2.suite == Card.Suite.CLUB && !Bomb.RJVisible)
                        return 2;

                    //Otherwise, press the first card.
                    return 1;

                case 50:
                    //If your opponent said "Sure about that?" and the fourth card is a heart, press the first card.
                    if (response == "Sure about that?" && card4.suite == Card.Suite.HEART)
                        return 1;

                    //Otherwise, if there are no clubs and the starter card was the Two of Clubs, press the third card.
                    if (
                        ClubNum(card1, card2, card3, card4) == 0
                        && startingCard.suite == Card.Suite.CLUB
                    )
                        return 3;

                    //Otherwise, if a heart appears anywhere above a spade and there are no diamonds press the fourth card.
                    if (
                        DiamondNum(card1, card2, card3, card4) == 0
                        && (
                            (card1.suite == Card.Suite.HEART && card2.suite == Card.Suite.SPADE)
                            || (card1.suite == Card.Suite.HEART && card3.suite == Card.Suite.SPADE)
                            || (card1.suite == Card.Suite.HEART && card4.suite == Card.Suite.SPADE)
                            || (card2.suite == Card.Suite.HEART && card3.suite == Card.Suite.SPADE)
                            || (card2.suite == Card.Suite.HEART && card4.suite == Card.Suite.SPADE)
                            || (card3.suite == Card.Suite.HEART && card4.suite == Card.Suite.SPADE)
                        )
                    )
                        return 4;

                    //Otherwise, if the first card is a heart and the starter card was not the King of Hearts, press the second card.
                    if (card1.suite == Card.Suite.HEART && startingCard.suite != Card.Suite.HEART)
                        return 2;

                    //Otherwise, if your opponent said "Really, really?" and the first or second card are hearts, press the fourth card.
                    if (
                        response == "Really, really?"
                        && (card1.suite == Card.Suite.HEART || card2.suite == Card.Suite.HEART)
                    )
                        return 4;

                    //Otherwise, if the starter card was the Five of Diamonds and there is a parallel port, press the first card.
                    if (startingCard.suite == Card.Suite.DIAMOND && Bomb.PPVisuble)
                        return 1;

                    //Otherwise, if there is a lit TRN indicator and there is at least one black card, press the second card.
                    if (
                        Bomb.Trn.Lit
                        && ClubNum(card1, card2, card3, card4)
                            + SpadeNum(card1, card2, card3, card4)
                            >= 1
                    )
                        return 2;

                    //Otherwise, if your opponent said "Terrible play!", press the third card.
                    if (response == "Terrible play!")
                        return 3;

                    //Otherwise, if the digits of the serial number add up to less than ten press the first card.
                    if (Bomb.DigitSum < 10)
                        return 1;

                    //Otherwise, press the third card.
                    return 3;

                case 100:
                    //If your opponent said "Really, really?", press the second card.
                    if (response == "Really, really?")
                        return 2;

                    //Otherwise, if your opponent said, "Really?", press the fourth card.
                    if (response == "Really?")
                        return 4;

                    //Otherwise, if there are no D batteries and the starter card was the Ace of Spades, press the first card.
                    if (Bomb.DBattery == 0 && startingCard.suite == Card.Suite.SPADE)
                        return 1;

                    //Otherwise, if the digits of the serial number add up to a prime number and there is at least one heart, press the fourth card.
                    if (
                        IsPrime(Bomb.DigitSum)
                        && (
                            card1.suite == Card.Suite.HEART
                            || card2.suite == Card.Suite.HEART
                            || card3.suite == Card.Suite.HEART
                            || card4.suite == Card.Suite.HEART
                        )
                    )

                        return 4;

                    //Otherwise, if a club and a spade appear and your opponent said "Sure about that?", press the third card.
                    if (
                        response == "Sure about that?"
                        && (
                            (card1.suite == Card.Suite.CLUB && card2.suite == Card.Suite.SPADE)
                            || (card1.suite == Card.Suite.CLUB && card3.suite == Card.Suite.SPADE)
                            || (card1.suite == Card.Suite.CLUB && card4.suite == Card.Suite.SPADE)
                            || (card2.suite == Card.Suite.CLUB && card1.suite == Card.Suite.SPADE)
                            || (card2.suite == Card.Suite.CLUB && card3.suite == Card.Suite.SPADE)
                            || (card2.suite == Card.Suite.CLUB && card4.suite == Card.Suite.SPADE)
                            || (card3.suite == Card.Suite.CLUB && card1.suite == Card.Suite.SPADE)
                            || (card3.suite == Card.Suite.CLUB && card2.suite == Card.Suite.SPADE)
                            || (card3.suite == Card.Suite.CLUB && card4.suite == Card.Suite.SPADE)
                            || (card4.suite == Card.Suite.CLUB && card1.suite == Card.Suite.SPADE)
                            || (card4.suite == Card.Suite.CLUB && card3.suite == Card.Suite.SPADE)
                        )
                    )
                        return 3;

                    //Otherwise, if a club and a spade appear next to each other, press the second card.
                    if (
                        (card1.suite == Card.Suite.CLUB && card2.suite == Card.Suite.SPADE)
                        || (card2.suite == Card.Suite.CLUB && card3.suite == Card.Suite.SPADE)
                        || (card3.suite == Card.Suite.CLUB && card4.suite == Card.Suite.SPADE)
                        || (card1.suite == Card.Suite.SPADE && card2.suite == Card.Suite.CLUB)
                        || (card2.suite == Card.Suite.SPADE && card3.suite == Card.Suite.CLUB)
                        || (card3.suite == Card.Suite.SPADE && card4.suite == Card.Suite.CLUB)
                    )
                        return 2;

                    //Otherwise, if there is an unlit MSA indicator, press the first card.
                    if (Bomb.Msa.Lit)
                        return 1;

                    //Otherwise, if there is at least one diamond, press the third card.
                    if (DiamondNum(card1, card2, card3, card4) >= 1)
                        return 3;

                    //Otherwise, if your opponent said "Awful play!", press the fourth card.
                    if (response == "Awful play!")
                        return 4;

                    //Otherwise, press the second card.
                    return 2;

                case 500:
                    //If there is more than one club, press the third card.
                    if (ClubNum(card1, card2, card3, card4) > 1)
                        return 3;

                    //Otherwise, if the serial number contains a vowel and there is at least one spade, press the second card.
                    if (Bomb.HasVowel && SpadeNum(card1, card2, card3, card4) >= 1)
                        return 2;

                    //Otherwise, if there are no ports and there is at least one heart, press the first card.
                    if (Bomb.PortNum == 0 && HeartNum(card1, card2, card3, card4) >= 1)
                        return 1;

                    //Otherwise, if there are no red cards, press the fourth card.
                    if (
                        HeartNum(card1, card2, card3, card4) == 0
                        && DiamondNum(card1, card2, card3, card4) == 0
                    )
                        return 4;

                    //Otherwise, if your opponent said "Are you sure?", press the fourth card.
                    if (response == "Are you sure?")
                        return 4;

                    //Otherwise, if there are no lit indicators and the first card is a heart, press the third card.
                    if (Bomb.LitIndicatorsList.Count == 0 && card1.suite == Card.Suite.HEART)
                        return 3;

                    //Otherwise, if there is at least one unlit indicator and the second card is a club, press the second card.
                    if (Bomb.UnlitIndicatorsList.Count >= 1 && card2.suite == Card.Suite.CLUB)
                        return 2;

                    //Otherwise, if your opponent said "Really?" and there are no black cards, press the first card.
                    if (
                        response == "Really?"
                        && SpadeNum(card1, card2, card3, card4) == 0
                        && ClubNum(card1, card2, card3, card4) == 0
                    )
                        return 1;

                    //Otherwise, if there is more than one D battery, press the third card.
                    if (Bomb.DBattery > 1)
                        return 3;

                    //Otherwise, press the fourth card.
                    return 4;
            }

            return -1;
        }

        /// <summary>
        /// A method that tells how many clubs there are in the final stage
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <param name="card3"></param>
        /// <param name="card4"></param>
        /// <returns></returns>
        public int ClubNum(Card card1, Card card2, Card card3, Card card4)
        {
            int num = 0;

            if (card1.suite == Card.Suite.CLUB)
                num++;

            if (card2.suite == Card.Suite.CLUB)
                num++;

            if (card3.suite == Card.Suite.CLUB)
                num++;

            if (card4.suite == Card.Suite.CLUB)
                num++;

            return num;
        }

        /// <summary>
        /// A method that tells how many hears there are in the final stage
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <param name="card3"></param>
        /// <param name="card4"></param>
        /// <returns></returns>
        public int HeartNum(Card card1, Card card2, Card card3, Card card4)
        {
            int num = 0;

            if (card1.suite == Card.Suite.HEART)
                num++;

            if (card2.suite == Card.Suite.HEART)
                num++;

            if (card3.suite == Card.Suite.HEART)
                num++;

            if (card4.suite == Card.Suite.HEART)
                num++;

            return num;
        }

        /// <summary>
        /// A method that tells how many clubs there are in the final stage
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <param name="card3"></param>
        /// <param name="card4"></param>
        /// <returns></returns>
        public int SpadeNum(Card card1, Card card2, Card card3, Card card4)
        {
            int num = 0;

            if (card1.suite == Card.Suite.SPADE)
                num++;

            if (card2.suite == Card.Suite.SPADE)
                num++;

            if (card3.suite == Card.Suite.SPADE)
                num++;

            if (card4.suite == Card.Suite.SPADE)
                num++;

            return num;
        }

        /// <summary>
        /// A method that tells how many clubs there are in the final stage
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <param name="card3"></param>
        /// <param name="card4"></param>
        /// <returns></returns>
        public int DiamondNum(Card card1, Card card2, Card card3, Card card4)
        {
            int num = 0;

            if (card1.suite == Card.Suite.DIAMOND)
                num++;

            if (card2.suite == Card.Suite.DIAMOND)
                num++;

            if (card3.suite == Card.Suite.DIAMOND)
                num++;

            if (card4.suite == Card.Suite.DIAMOND)
                num++;

            return num;
        }

        public bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        /// <summary>
        /// A mehtod that will tell if a given number is in a hand
        /// </summary>
        /// <param name="target"></param>
        /// <param name="hand"></param>
        /// <returns></returns>
        public bool FindNumber(Card.Number target, Card[] hand)
        {
            foreach (Card card in hand)
            {
                if (card.number == target)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// A mehtod that will tell how many of a given number is in a hand
        /// </summary>
        /// <param name="target"></param>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int FindNumberNum(Card.Number target, Card[] hand)
        {
            int num = 0;

            if (hand[0].number == target)
                num++;

            if (hand[1].number == target)
                num++;

            if (hand[2].number == target)
                num++;

            if (hand[3].number == target)
                num++;

            if (hand[4].number == target)
                num++;

            return num;
        }

        /// <summary>
        /// A mehtod that will tell if a given suite is in a hand
        /// </summary>
        /// <param name="target"></param>
        /// <param name="hand"></param>
        /// <returns></returns>
        public bool FindSuite(Card.Suite target, Card[] hand)
        {
            foreach (Card card in hand)
            {
                if (card.suite == target)
                    return true;
            }

            return true;
        }

        /// <summary>
        /// A helper class for the
        /// </summary>
        public class BinaryTreeNode
        {
            //the card the node will hold
            public Card Data;

            public BinaryTreeNode LeftNode { get; set; }

            public BinaryTreeNode RightNode { get; set; }

            //the condition on wheter to go left or right
            public bool Condition { get; set; }

            public BinaryTreeNode(Card data, bool condition)
            {
                Data = data;
                Condition = condition;
            }
        }

        /// <summary>
        /// A class that will hold the card trees
        /// </summary>
        public class BinaryTree
        {
            public BinaryTreeNode Root { get; set; }

            public BinaryTree(Card data, bool condition)
            {
                Root = new BinaryTreeNode(data, condition);
            }

            /// <summary>
            /// Sets up the children for a parent. YES IS LEFT. NO IS RIGHT
            /// </summary>
            /// <param name="parent"></param>
            /// <param name="leftCard"></param>
            /// <param name="rightCard"></param>
            public void SetChildren(
                BinaryTreeNode parent,
                Card leftCard,
                Card rightCard,
                bool leftCondition,
                bool rightCondition
            )
            {
                parent.LeftNode = new BinaryTreeNode(leftCard, leftCondition);
                parent.RightNode = new BinaryTreeNode(rightCard, rightCondition);
            }
        }

        /// <summary>
        /// A class that represents the cards
        /// </summary>
        public class Card
        {
            public Suite suite { get; set; }

            public Number number { get; set; }

            //the suite of the card
            public enum Suite
            {
                CLUB,
                DIAMOND,
                HEART,
                SPADE
            }

            //the number of the card
            public enum Number
            {
                ONE,
                TWO,
                THREE,
                FOUR,
                FIVE,
                SIX,
                SEVEN,
                EIGHT,
                NINE,
                TEN,
                JACK,
                QUEEN,
                KING,
                ACE
            }

            public Card(Number number, Suite suite)
            {
                this.suite = suite;
                this.number = number;
            }
        }
    }
}
