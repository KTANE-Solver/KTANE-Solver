using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class ShapeShift : Module
    {
        Ticket currentTicket;
        public List<Ticket> ticketList;

        public enum TicketShape
        {
            Flat,
            Round,
            Point,
            Ticket
        }

        public ShapeShift(
            Bomb bomb,
            StreamWriter logFileWriter,
            TicketShape leftSideStartingPosition,
            TicketShape rightSideStartingPosition
        ) : base(bomb, logFileWriter, "Shape Shift")
        {
            ticketList = new List<Ticket>();
            SetUpModule();
            currentTicket = FindStartingTicket(leftSideStartingPosition, rightSideStartingPosition);
            currentTicket.visitNum++;
        }

        public void Solve()
        {
            while (currentTicket.visitNum != 2)
            {
                PrintDebugLine(
                    $"Current Ticket: {currentTicket.LeftSide} {currentTicket.RightSide}\n"
                );

                PrintDebugLine($"Current Ticket's # of visits: {currentTicket.visitNum}");

                PrintDebugLine($"{currentTicket.Condition}: {currentTicket.Condition}");

                currentTicket = currentTicket.GetNextTicket();
                ;

                PrintDebugLine(
                    $"Current Ticket's is now {currentTicket.LeftSide} {currentTicket.RightSide}\n"
                );

                currentTicket.visitNum++;
            }

            ShowAnswer($"{currentTicket.LeftSide} {currentTicket.RightSide}", true);
        }

        private void SetUpModule()
        {
            Ticket flatRound = new Ticket(
                TicketShape.Flat,
                TicketShape.Round,
                Bomb.DVIVisble,
                "There a DVI-D port"
            );
            Ticket roundDiamond = new Ticket(
                TicketShape.Round,
                TicketShape.Point,
                Bomb.Sig.Lit,
                "There a lit SIG indicator"
            );
            Ticket diamondTicket = new Ticket(
                TicketShape.Point,
                TicketShape.Ticket,
                Bomb.RJVisible,
                "There an RJ-45 port"
            );
            Ticket roundRound = new Ticket(
                TicketShape.Round,
                TicketShape.Round,
                Bomb.HasVowel,
                "The serial # contains a vowel"
            );
            Ticket ticketDiamond = new Ticket(
                TicketShape.Ticket,
                TicketShape.Point,
                Bomb.PSVisible,
                "There's a PS/2 port"
            );
            Ticket diamondDiamond = new Ticket(
                TicketShape.Point,
                TicketShape.Point,
                Bomb.Ind.Lit,
                "There's a lit IND indicator"
            );
            Ticket ticketFlat = new Ticket(
                TicketShape.Ticket,
                TicketShape.Flat,
                Bomb.Frq.VisibleNotLit,
                "There's an unlit FRQ indicator"
            );
            Ticket diamondRound = new Ticket(
                TicketShape.Point,
                TicketShape.Round,
                Bomb.PPVisuble,
                "There's a parallel port"
            );
            Ticket ticketTicket = new Ticket(
                TicketShape.Ticket,
                TicketShape.Ticket,
                Bomb.Battery >= 3,
                "There's three or more batteries"
            );
            Ticket roundTicket = new Ticket(
                TicketShape.Round,
                TicketShape.Ticket,
                Bomb.AABattery >= 2,
                "There's two or more AA batteries"
            );
            Ticket flatFlat = new Ticket(
                TicketShape.Flat,
                TicketShape.Flat,
                Bomb.LastDigit % 2 == 1,
                "The last digit of the serial # is odd"
            );
            Ticket flatTicket = new Ticket(
                TicketShape.Flat,
                TicketShape.Ticket,
                Bomb.Bob.VisibleNotLit,
                "There's an unlit BOB indicator"
            );
            Ticket diamondFlat = new Ticket(
                TicketShape.Point,
                TicketShape.Flat,
                Bomb.Car.VisibleNotLit,
                "There's an unlit CAR indicator"
            );
            Ticket ticketRound = new Ticket(
                TicketShape.Ticket,
                TicketShape.Round,
                Bomb.RCAVisuble,
                "There's a stereo RCA port"
            );
            Ticket roundFlat = new Ticket(
                TicketShape.Round,
                TicketShape.Flat,
                Bomb.Snd.Lit,
                "There's a lit SND indicator"
            );
            Ticket flatDiamond = new Ticket(
                TicketShape.Flat,
                TicketShape.Point,
                Bomb.Msa.Lit,
                "There's a lit MSA indicator"
            );

            AddTrueFalseTickets(flatRound, roundDiamond, ticketDiamond);
            AddTrueFalseTickets(roundDiamond, ticketTicket, flatFlat);
            AddTrueFalseTickets(diamondTicket, roundDiamond, roundRound);
            AddTrueFalseTickets(roundRound, ticketTicket, flatRound);
            AddTrueFalseTickets(ticketDiamond, diamondTicket, diamondRound);
            AddTrueFalseTickets(diamondDiamond, diamondTicket, flatFlat);
            AddTrueFalseTickets(ticketFlat, flatRound, diamondDiamond);
            AddTrueFalseTickets(diamondRound, flatDiamond, roundFlat);
            AddTrueFalseTickets(ticketTicket, ticketFlat, flatTicket);
            AddTrueFalseTickets(roundTicket, ticketFlat, flatTicket);
            AddTrueFalseTickets(flatFlat, diamondFlat, diamondRound);
            AddTrueFalseTickets(flatTicket, ticketRound, diamondDiamond);
            AddTrueFalseTickets(diamondFlat, ticketRound, roundTicket);
            AddTrueFalseTickets(ticketRound, flatDiamond, roundFlat);
            AddTrueFalseTickets(roundFlat, roundRound, roundTicket);
            AddTrueFalseTickets(flatDiamond, ticketDiamond, diamondFlat);
        }

        private void AddTrueFalseTickets(Ticket main, Ticket trueTicket, Ticket falseTicket)
        {
            main.SetTrueFalseTickets(trueTicket, falseTicket);
            ticketList.Add(main);
        }

        private Ticket FindStartingTicket(TicketShape leftSide, TicketShape rightSide)
        {
            foreach (Ticket t in ticketList)
            {
                if (t.LeftSide == leftSide && t.RightSide == rightSide)
                {
                    return t;
                }
            }

            return null;
        }

        public class Ticket
        {
            public int visitNum;
            public Ticket trueTicket;
            public Ticket falseTicket;
            public TicketShape LeftSide { get; }
            public TicketShape RightSide { get; }
            public bool Condition { get; }
            public string ConditionStr { get; }

            public Ticket(
                TicketShape leftSide,
                TicketShape rightSide,
                bool condition,
                string conditionStr
            )
            {
                LeftSide = leftSide;
                RightSide = rightSide;
                Condition = condition;
                ConditionStr = conditionStr;

                visitNum = 0;
            }

            public void SetTrueFalseTickets(Ticket trueTicket, Ticket falseTicket)
            {
                this.trueTicket = trueTicket;
                this.falseTicket = falseTicket;
            }

            public Ticket GetNextTicket()
            {
                return Condition ? trueTicket : falseTicket;
            }

            public bool SameTicketShapes(TicketShape leftSide, TicketShape rightSide)
            {
                return LeftSide == leftSide && RightSide == rightSide;
            }
        }
    }
}
