using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Date: 3/23/21
    /// Purpose: Solves the silly slot module
    /// </summary>
    public class SillySlots : Module
    {
        //============FIELDS============
        private String keyword;

        //stage 1 information
        private Slot stage1Slot1;
        private Slot stage1Slot2;
        private Slot stage1Slot3;

        //stage 2 information
        private Slot stage2Slot1;
        private Slot stage2Slot2;
        private Slot stage2Slot3;

        //stage 3 information
        private Slot stage3Slot1;
        private Slot stage3Slot2;
        private Slot stage3Slot3;

        //stage 4 information
        private Slot stage4Slot1;
        private Slot stage4Slot2;
        private Slot stage4Slot3;

        //placeholder information for the currnet slots
        private ConvertedSlot placeholderSlot1;
        private ConvertedSlot placeholderSlot2;
        private ConvertedSlot placeholderSlot3;

        //============PROPERTIES============

        //============CONSTRUCTORS============
        /// <summary>
        /// Used to solve the first stage of the module
        /// </summary>
        /// <param name="keyword">the keyword at the top</param>
        /// <param name="logFile">used to write to the log file</param>
        public SillySlots(String keyword, Slot slot1, Slot slot2, Slot slot3, StreamWriter logFile)
            : base(null, logFile, "Silly Slots")
        {
            //setting the variables depending on the stage
            this.keyword = keyword;

            stage1Slot1 = slot1;
            stage1Slot2 = slot2;
            stage1Slot3 = slot3;

            placeholderSlot1 = new ConvertedSlot(stage1Slot1, keyword);
            placeholderSlot2 = new ConvertedSlot(stage1Slot2, keyword);
            placeholderSlot3 = new ConvertedSlot(stage1Slot3, keyword);
        }

        /// <summary>
        /// Solves each stage
        /// </summary>
        /// <param name="stage">the stage the user is on</param>
        /// <returns>true if the user presses keep</returns>
        public bool Solve(int stage)
        {
            PrintDebugLine($"Stage {stage}\n");
            PrintDebugLine($"Keyword: {keyword}\n");

            //print information to the log
            if (stage == 1)
            {
                PrintDebugLine($"Stage 1 Slot 1: {stage1Slot1.Color} {stage1Slot1.Object}");
                PrintDebugLine($"Stage 1 Slot 2: {stage1Slot2.Color} {stage1Slot2.Object}");
                PrintDebugLine($"Stage 1 Slot 3: {stage1Slot3.Color} {stage1Slot3.Object}\n");
            }

            if (stage == 2)
            {
                PrintDebugLine($"Stage 2 Slot 1: {stage2Slot1.Color} {stage2Slot1.Object}");
                PrintDebugLine($"Stage 2 Slot 2: {stage2Slot2.Color} {stage2Slot2.Object}");
                PrintDebugLine($"Stage 2 Slot 3: {stage2Slot3.Color} {stage2Slot3.Object}\n");
            }

            if (stage == 3)
            {
                PrintDebugLine($"Stage 3 Slot 1: {stage3Slot1.Color} {stage3Slot1.Object}");
                PrintDebugLine($"Stage 3 Slot 2: {stage3Slot2.Color} {stage3Slot2.Object}");
                PrintDebugLine($"Stage 3 Slot 3: {stage3Slot3.Color} {stage3Slot3.Object}\n");
            }

            if (stage == 4)
            {
                PrintDebugLine($"Stage 4 Slot 1: {stage4Slot1.Color} {stage4Slot1.Object}");
                PrintDebugLine($"Stage 4 Slot 2: {stage4Slot2.Color} {stage4Slot2.Object}");
                PrintDebugLine($"Stage 4 Slot 3: {stage4Slot3.Color} {stage4Slot3.Object}\n");
            }

            //If any of these are true, then pull the lever

            //There is a single Silly Sausage.
            int sillySausageCount = 0;

            if (
                isAdjective(placeholderSlot1, ConvertedSlot.Adjective.SILLY)
                && isNoun(placeholderSlot1, ConvertedSlot.Noun.SAUSAGE)
            )
            {
                sillySausageCount++;
            }

            if (
                isAdjective(placeholderSlot2, ConvertedSlot.Adjective.SILLY)
                && isNoun(placeholderSlot2, ConvertedSlot.Noun.SAUSAGE)
            )
            {
                sillySausageCount++;
            }

            if (
                isAdjective(placeholderSlot3, ConvertedSlot.Adjective.SILLY)
                && isNoun(placeholderSlot3, ConvertedSlot.Noun.SAUSAGE)
            )
            {
                sillySausageCount++;
            }

            if (sillySausageCount == 1)
            {
                PrintDebugLine("There is a single Silly Sausage. Pulling the lever...\n");
                return false;
            }

            //There is a single Sassy Sally, unless the slot in the same position 2 stages ago was Soggy.

            int sassySallyCount = 0;

            //tells which slot is sassy sally
            bool sassySallySlot1 = false;
            bool sassySallySlot2 = false;

            if (
                isAdjective(placeholderSlot1, ConvertedSlot.Adjective.SASSY)
                && isNoun(placeholderSlot1, ConvertedSlot.Noun.SALLY)
            )
            {
                sassySallyCount++;
                sassySallySlot1 = true;
            }

            if (
                isAdjective(placeholderSlot2, ConvertedSlot.Adjective.SASSY)
                && isNoun(placeholderSlot2, ConvertedSlot.Noun.SALLY)
            )
            {
                sassySallyCount++;
                sassySallySlot2 = true;
            }

            if (
                isAdjective(placeholderSlot3, ConvertedSlot.Adjective.SASSY)
                && isNoun(placeholderSlot3, ConvertedSlot.Noun.SALLY)
            )
            {
                sassySallyCount++;
            }

            if (sassySallyCount == 1)
            {
                if (stage == 1 || stage == 2)
                {
                    PrintDebugLine("There is a single Sassy Sally\n");
                    return false;
                }
                else if (stage == 3)
                {
                    ConvertedSlot convertedSlot;

                    //checking which slot needs to be convertd from stage 1
                    if (sassySallySlot1)
                    {
                        convertedSlot = new ConvertedSlot(stage1Slot1, keyword);
                    }
                    else if (sassySallySlot2)
                    {
                        convertedSlot = new ConvertedSlot(stage1Slot2, keyword);
                    }
                    else
                    {
                        convertedSlot = new ConvertedSlot(stage1Slot3, keyword);
                    }

                    //if the converted slot is not soggy, pull the lever
                    if (!isAdjective(convertedSlot, ConvertedSlot.Adjective.SOGGY))
                    {
                        PrintDebugLine(
                            "There is a single sassy sally with the slot two stage ago not being Soggy. Pulling the lever...\n"
                        );
                        return false;
                    }
                }
                else if (stage == 4)
                {
                    ConvertedSlot convertedSlot;

                    //checking which slot needs to be convertd from stage 2
                    if (sassySallySlot1)
                    {
                        convertedSlot = new ConvertedSlot(stage2Slot1, keyword);
                    }
                    else if (sassySallySlot2)
                    {
                        convertedSlot = new ConvertedSlot(stage2Slot2, keyword);
                    }
                    else
                    {
                        convertedSlot = new ConvertedSlot(stage2Slot3, keyword);
                    }

                    //if the converted slot is not soggy, pull the lever
                    if (!isAdjective(convertedSlot, ConvertedSlot.Adjective.SOGGY))
                    {
                        PrintDebugLine(
                            "There is a single sassy sally with the slot two stage ago not being Soggy. Pulling the lever...\n"
                        );
                        return false;
                    }
                }
            }

            //There are 2 or more Soggy Stevens.

            int soggyStevenCount = 0;

            if (
                isAdjective(placeholderSlot1, ConvertedSlot.Adjective.SOGGY)
                && isNoun(placeholderSlot1, ConvertedSlot.Noun.STEVEN)
            )
            {
                soggyStevenCount++;
            }

            if (
                isAdjective(placeholderSlot2, ConvertedSlot.Adjective.SOGGY)
                && isNoun(placeholderSlot2, ConvertedSlot.Noun.STEVEN)
            )
            {
                soggyStevenCount++;
            }

            if (
                isAdjective(placeholderSlot3, ConvertedSlot.Adjective.SOGGY)
                && isNoun(placeholderSlot3, ConvertedSlot.Noun.STEVEN)
            )
            {
                soggyStevenCount++;
            }

            if (soggyStevenCount >= 2)
            {
                PrintDebugLine("There are 2 or more Soggy Stevens. Pulling the lever...\n");
                return false;
            }

            //There are 3 Simons, unless any of them are Sassy.

            int simonCount = 0;

            if (isNoun(placeholderSlot1, ConvertedSlot.Noun.SIMON))
            {
                simonCount++;
            }

            if (isNoun(placeholderSlot2, ConvertedSlot.Noun.SIMON))
            {
                simonCount++;
            }

            if (isNoun(placeholderSlot3, ConvertedSlot.Noun.SIMON))
            {
                simonCount++;
            }

            if (
                simonCount == 3
                && !isAdjective(placeholderSlot1, ConvertedSlot.Adjective.SASSY)
                && !isAdjective(placeholderSlot2, ConvertedSlot.Adjective.SASSY)
                && !isAdjective(placeholderSlot3, ConvertedSlot.Adjective.SASSY)
            )
            {
                PrintDebugLine(
                    "There are 3 Simons with none of them being Sassy. Pulling the lever...\n"
                );
                return false;
            }

            //There is a Sausage adjacent to a Sally, unless every adjacent Sally is Soggy.

            //tells if each slot is sausage
            bool slot1Sausage = isNoun(placeholderSlot1, ConvertedSlot.Noun.SAUSAGE);
            bool slot2Sausage = isNoun(placeholderSlot2, ConvertedSlot.Noun.SAUSAGE);
            bool slot3Sausage = isNoun(placeholderSlot3, ConvertedSlot.Noun.SAUSAGE);

            //tells if each slot is sally
            bool slot1Sally = isNoun(placeholderSlot1, ConvertedSlot.Noun.SALLY);
            bool slot2Sally = isNoun(placeholderSlot2, ConvertedSlot.Noun.SALLY);
            bool slot3Sally = isNoun(placeholderSlot3, ConvertedSlot.Noun.SALLY);

            //check if slot 1 is sausauge and slot 2 is soggy sally
            if (slot1Sausage && slot2Sally)
            {
                if (!isAdjective(placeholderSlot2, ConvertedSlot.Adjective.SOGGY))
                {
                    PrintDebugLine(
                        "Slot 1 is sausage. Slot 2 is Sally without being Soggy. Pulling the lever...\n"
                    );
                    return false;
                }
            }

            //check if slot 3 is sausauge and slot 2 is soggy sally
            if (slot3Sausage && slot2Sally)
            {
                if (!isAdjective(placeholderSlot2, ConvertedSlot.Adjective.SOGGY))
                {
                    PrintDebugLine(
                        "Slot 3 is sausage. Slot 2 is Sally without being Soggy. Pulling the lever...\n"
                    );
                    return false;
                }
            }

            //check if slot 2 is sausauge and slot 1 is soggy sally
            if (slot2Sausage && slot1Sally)
            {
                if (!isAdjective(placeholderSlot1, ConvertedSlot.Adjective.SOGGY))
                {
                    PrintDebugLine(
                        "Slot 2 is sausage. Slot 1 is Sally without being Soggy. Pulling the lever...\n"
                    );
                    return false;
                }
            }

            //check if slot 2 is sausage and slot 3 is soggy sally
            if (slot2Sausage && slot3Sally)
            {
                if (!isAdjective(placeholderSlot3, ConvertedSlot.Adjective.SOGGY))
                {
                    PrintDebugLine(
                        "Slot 2 is sausage. Slot 3 is Sally without being Soggy. Pulling the lever...\n"
                    );
                    return false;
                }
            }

            //There are exactly 2 Silly slots, unless they are both Steven.
            int sillyCount = 0;

            //check slots are silly
            bool slot1Silly = isAdjective(placeholderSlot1, ConvertedSlot.Adjective.SILLY);
            bool slot2Silly = isAdjective(placeholderSlot2, ConvertedSlot.Adjective.SILLY);
            bool slot3Silly = isAdjective(placeholderSlot3, ConvertedSlot.Adjective.SILLY);

            if (slot1Silly)
            {
                sillyCount++;
            }

            if (slot2Silly)
            {
                sillyCount++;
            }

            if (slot3Silly)
            {
                sillyCount++;
            }

            //checking to see if all sillies are stevenes
            if (sillyCount == 2)
            {
                if (slot1Silly && !isNoun(placeholderSlot1, ConvertedSlot.Noun.STEVEN))
                {
                    PrintDebugLine(
                        "There ae two Silly slots but both are not Steven. Pulling the lever...\n"
                    );
                    return false;
                }

                if (slot2Silly && !isNoun(placeholderSlot2, ConvertedSlot.Noun.STEVEN))
                {
                    PrintDebugLine(
                        "There ae two Silly slots but both are not Steven. Pulling the lever...\n"
                    );
                    return false;
                }

                if (slot3Silly && !isNoun(placeholderSlot3, ConvertedSlot.Noun.STEVEN))
                {
                    PrintDebugLine(
                        "There ae two Silly slots but both are not Steven. Pulling the lever...\n"
                    );
                    return false;
                }
            }

            //There is a single Soggy slot, unless the previous stage had any number of Sausage slots.
            int soggyCount = 0;

            if (isAdjective(placeholderSlot1, ConvertedSlot.Adjective.SOGGY))
            {
                soggyCount++;
            }

            if (isAdjective(placeholderSlot2, ConvertedSlot.Adjective.SOGGY))
            {
                soggyCount++;
            }

            if (isAdjective(placeholderSlot3, ConvertedSlot.Adjective.SOGGY))
            {
                soggyCount++;
            }

            if (soggyCount == 1)
            {
                //if this is stage 1, then return false
                if (stage == 1)
                {
                    PrintDebugLine(
                        "There is a single Soggy slot with no previous stage. Pulling the lever...\n"
                    );
                    return false;
                }
                else if (stage == 2)
                {
                    ConvertedSlot convertedSlot1 = new ConvertedSlot(stage1Slot1, keyword);
                    ConvertedSlot convertedSlot2 = new ConvertedSlot(stage1Slot2, keyword);
                    ConvertedSlot convertedSlot3 = new ConvertedSlot(stage1Slot3, keyword);

                    bool stage1Slot1Sausge = isNoun(convertedSlot1, ConvertedSlot.Noun.SAUSAGE);
                    bool stage1Slot2Sausge = isNoun(convertedSlot2, ConvertedSlot.Noun.SAUSAGE);
                    bool stage1Slot3Sausge = isNoun(convertedSlot3, ConvertedSlot.Noun.SAUSAGE);

                    if (!stage1Slot1Sausge && !stage1Slot2Sausge && !stage1Slot3Sausge)
                    {
                        PrintDebugLine(
                            "There is a single Soggy slot with the previous stage not having a Sausage. Pulling the lever...\n"
                        );
                        return false;
                    }
                }
                else if (stage == 3)
                {
                    ConvertedSlot convertedSlot1 = new ConvertedSlot(stage2Slot1, keyword);
                    ConvertedSlot convertedSlot2 = new ConvertedSlot(stage2Slot2, keyword);
                    ConvertedSlot convertedSlot3 = new ConvertedSlot(stage2Slot3, keyword);

                    bool stage2Slot1Sausge = isNoun(convertedSlot1, ConvertedSlot.Noun.SAUSAGE);
                    bool stage2Slot2Sausge = isNoun(convertedSlot2, ConvertedSlot.Noun.SAUSAGE);
                    bool stage2Slot3Sausge = isNoun(convertedSlot3, ConvertedSlot.Noun.SAUSAGE);

                    if (!stage2Slot1Sausge && !stage2Slot2Sausge && !stage2Slot3Sausge)
                    {
                        PrintDebugLine(
                            "There is a single Soggy slot with the previous stage not having a Sausage. Pulling the lever...\n"
                        );
                        return false;
                    }
                }
                else
                {
                    ConvertedSlot convertedSlot1 = new ConvertedSlot(stage3Slot1, keyword);
                    ConvertedSlot convertedSlot2 = new ConvertedSlot(stage3Slot2, keyword);
                    ConvertedSlot convertedSlot3 = new ConvertedSlot(stage3Slot3, keyword);

                    bool stage3Slot1Sausge = isNoun(convertedSlot1, ConvertedSlot.Noun.SAUSAGE);
                    bool stage3Slot2Sausge = isNoun(convertedSlot2, ConvertedSlot.Noun.SAUSAGE);
                    bool stage3Slot3Sausge = isNoun(convertedSlot3, ConvertedSlot.Noun.SAUSAGE);

                    if (!stage3Slot1Sausge && !stage3Slot2Sausge && !stage3Slot3Sausge)
                    {
                        PrintDebugLine(
                            "There is a single Soggy slot with the previous stage not having a Sausage. Pulling the lever...\n"
                        );
                        return false;
                    }
                }
            }

            //All 3 slots are the same symbol and colour, unless there has been a Soggy Sausage in any previous stage.
            if (
                placeholderSlot1.SlotEqual(placeholderSlot2)
                && placeholderSlot2.SlotEqual(placeholderSlot3)
            )
            {
                if (stage == 1)
                {
                    PrintDebugLine(
                        "All 3 slots are the same symbol and colour with no previous stage. Pulling the lever...\n"
                    );
                    return false;
                }
                else
                {
                    List<ConvertedSlot> convertedSlotList = new List<ConvertedSlot>();

                    convertedSlotList.Add(new ConvertedSlot(stage1Slot1, keyword));
                    convertedSlotList.Add(new ConvertedSlot(stage1Slot2, keyword));
                    convertedSlotList.Add(new ConvertedSlot(stage1Slot3, keyword));

                    if (stage >= 2)
                    {
                        convertedSlotList.Add(new ConvertedSlot(stage2Slot1, keyword));
                        convertedSlotList.Add(new ConvertedSlot(stage2Slot2, keyword));
                        convertedSlotList.Add(new ConvertedSlot(stage2Slot3, keyword));

                        if (stage >= 3)
                        {
                            convertedSlotList.Add(new ConvertedSlot(stage3Slot1, keyword));
                            convertedSlotList.Add(new ConvertedSlot(stage3Slot2, keyword));
                            convertedSlotList.Add(new ConvertedSlot(stage3Slot3, keyword));
                        }
                    }

                    bool foundSoggySausage = false;

                    foreach (ConvertedSlot slot in convertedSlotList)
                    {
                        if (
                            isAdjective(slot, ConvertedSlot.Adjective.SOGGY)
                            && isNoun(slot, ConvertedSlot.Noun.SAUSAGE)
                        )
                        {
                            foundSoggySausage = true;
                            break;
                        }
                    }

                    if (!foundSoggySausage)
                    {
                        PrintDebugLine(
                            "All 3 slots are the same symbol and colour with no previous stage having a Soggy Sausage slot. Pulling the lever...\n"
                        );
                        return false;
                    }
                }
            }

            //All 3 slots are the same colour, unless any of them are Sally or there was a Silly Steven in the last stage.
            if (
                placeholderSlot1.AdjectiveEqual(placeholderSlot2)
                && placeholderSlot1.AdjectiveEqual(placeholderSlot3)
                && !isNoun(placeholderSlot1, ConvertedSlot.Noun.SALLY)
                && !isNoun(placeholderSlot2, ConvertedSlot.Noun.SALLY)
                && !isNoun(placeholderSlot3, ConvertedSlot.Noun.SALLY)
            )
            {
                if (stage == 1)
                {
                    PrintDebugLine(
                        "All 3 slots are the same colour with none of them being Sally and no last stage. Pulling the lever...\n"
                    );
                    return false;
                }
                else
                {
                    ConvertedSlot slot1;
                    ConvertedSlot slot2;
                    ConvertedSlot slot3;

                    if (stage == 2)
                    {
                        slot1 = new ConvertedSlot(stage1Slot1, keyword);
                        slot2 = new ConvertedSlot(stage1Slot2, keyword);
                        slot3 = new ConvertedSlot(stage1Slot2, keyword);
                    }
                    else if (stage == 3)
                    {
                        slot1 = new ConvertedSlot(stage2Slot1, keyword);
                        slot2 = new ConvertedSlot(stage2Slot2, keyword);
                        slot3 = new ConvertedSlot(stage2Slot2, keyword);
                    }
                    else
                    {
                        slot1 = new ConvertedSlot(stage3Slot1, keyword);
                        slot2 = new ConvertedSlot(stage3Slot2, keyword);
                        slot3 = new ConvertedSlot(stage3Slot2, keyword);
                    }

                    //count of many silly stevens there are
                    int sillyStevenCount = 0;

                    if (
                        isAdjective(slot1, ConvertedSlot.Adjective.SILLY)
                        && isNoun(slot1, ConvertedSlot.Noun.STEVEN)
                    )
                    {
                        sillyStevenCount++;
                    }
                    else if (
                        isAdjective(slot2, ConvertedSlot.Adjective.SILLY)
                        && isNoun(slot2, ConvertedSlot.Noun.STEVEN)
                    )
                    {
                        sillyStevenCount++;
                    }
                    else if (
                        isAdjective(slot3, ConvertedSlot.Adjective.SILLY)
                        && isNoun(slot3, ConvertedSlot.Noun.STEVEN)
                    )
                    {
                        sillyStevenCount++;
                    }

                    if (sillyStevenCount == 0)
                    {
                        PrintDebugLine(
                            "All 3 slots are the same colour with none of them being Sally and no last stage having a Silly Steven Slot. Pulling the lever...\n"
                        );
                        return false;
                    }
                }
            }

            //There are any number of Silly Simons, unless there has been a Sassy Sausage in any previous stage.

            int sillySimonCount = 0;

            if (
                isAdjective(placeholderSlot1, ConvertedSlot.Adjective.SILLY)
                && isNoun(placeholderSlot1, ConvertedSlot.Noun.SIMON)
            )
            {
                sillySimonCount++;
            }

            if (
                isAdjective(placeholderSlot2, ConvertedSlot.Adjective.SILLY)
                && isNoun(placeholderSlot2, ConvertedSlot.Noun.SIMON)
            )
            {
                sillySimonCount++;
            }

            if (
                isAdjective(placeholderSlot3, ConvertedSlot.Adjective.SILLY)
                && isNoun(placeholderSlot3, ConvertedSlot.Noun.SIMON)
            )
            {
                sillySimonCount++;
            }

            if (sillySimonCount > 0)
            {
                if (stage == 1)
                {
                    PrintDebugLine(
                        $"There is {sillySimonCount} Silly Simon(S) with no previous stage. Pulling the lever...\n"
                    );
                    return false;
                }
                else
                {
                    List<ConvertedSlot> convertedSlotList = new List<ConvertedSlot>();

                    convertedSlotList.Add(new ConvertedSlot(stage1Slot1, keyword));
                    convertedSlotList.Add(new ConvertedSlot(stage1Slot2, keyword));
                    convertedSlotList.Add(new ConvertedSlot(stage1Slot3, keyword));

                    if (stage >= 3)
                    {
                        convertedSlotList.Add(new ConvertedSlot(stage2Slot1, keyword));
                        convertedSlotList.Add(new ConvertedSlot(stage2Slot2, keyword));
                        convertedSlotList.Add(new ConvertedSlot(stage2Slot3, keyword));

                        if (stage >= 4)
                        {
                            convertedSlotList.Add(new ConvertedSlot(stage3Slot1, keyword));
                            convertedSlotList.Add(new ConvertedSlot(stage3Slot2, keyword));
                            convertedSlotList.Add(new ConvertedSlot(stage3Slot3, keyword));
                        }
                    }

                    bool foundSassySausage = false;

                    foreach (ConvertedSlot slot in convertedSlotList)
                    {
                        if (
                            isAdjective(slot, ConvertedSlot.Adjective.SASSY)
                            && isNoun(slot, ConvertedSlot.Noun.SAUSAGE)
                        )
                        {
                            foundSassySausage = true;
                            break;
                        }
                    }

                    if (!foundSassySausage)
                    {
                        PrintDebugLine(
                            $"There is {sillySimonCount} Silly Simon(s) with no previous stage having a Sassy Sausage. Pulling the lever...\n"
                        );
                        return false;
                    }
                }
            }

            //if this statement is reached, then the user will keep the stage
            PrintDebugLine("No illegal statements found. Pressing keep...\n");
            return true;
        }

        //============METHODS============
        /// <summary>
        /// Giveing more information to the
        /// module
        /// </summary>
        /// <param name="stage">the stage the slots belong to</param>
        /// <param name="slot1Color"></param>
        /// <param name="slot1Object"></param>
        /// <param name="slot2Color"></param>
        /// <param name="slot2Object"></param>
        /// <param name="slot3Color"></param>
        /// <param name="slot3Object"></param>
        public void UpdateModule(
            int stage,
            String keyword,
            String slot1Color,
            String slot1Object,
            String slot2Color,
            String slot2Object,
            String slot3Color,
            String slot3Object
        )
        {
            //update the placeholders ahd slots

            this.keyword = keyword;

            Slot slot1 = new Slot(slot1Color, slot1Object);
            Slot slot2 = new Slot(slot2Color, slot2Object);
            Slot slot3 = new Slot(slot3Color, slot3Object);

            placeholderSlot1 = new ConvertedSlot(slot1, keyword);
            placeholderSlot2 = new ConvertedSlot(slot2, keyword);
            placeholderSlot3 = new ConvertedSlot(slot3, keyword);

            if (stage == 1)
            {
                stage1Slot1 = slot1;
                stage1Slot2 = slot2;
                stage1Slot3 = slot3;
            }
            else if (stage == 2)
            {
                stage2Slot1 = slot1;
                stage2Slot2 = slot2;
                stage2Slot3 = slot3;
            }

            if (stage == 3)
            {
                stage3Slot1 = slot1;
                stage3Slot2 = slot2;
                stage3Slot3 = slot3;
            }
            else
            {
                stage4Slot1 = slot1;
                stage4Slot2 = slot2;
                stage4Slot3 = slot3;
            }
        }

        /// <summary>
        /// Tells if a slot has a certain adjective
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="adjective">the adjective the program is looking for</param>
        /// <returns>true if the slot has the adjective</returns>
        private bool isAdjective(ConvertedSlot slot, ConvertedSlot.Adjective adjective)
        {
            return slot.AdjectiveProperty == adjective;
        }

        /// <summary>
        /// Tells if a slot has a certain noun
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="noun">the noun the program is looking for</param>
        /// <returns>true if the slot has the noun</returns>
        private bool isNoun(ConvertedSlot slot, ConvertedSlot.Noun noun)
        {
            return slot.NounProperty == noun;
        }

        //============INNER CLASSES============
        /// <summary>
        /// the slot with a converted adjective and noun
        /// </summary>
        public class ConvertedSlot
        {
            public enum Adjective
            {
                SASSY,
                SILLY,
                SOGGY,
            }

            public enum Noun
            {
                SALLY,
                SAUSAGE,
                SIMON,
                STEVEN
            }

            public Noun NounProperty { get; }

            public Adjective AdjectiveProperty { get; }

            /// <summary>
            /// converts a slot into a placeholder
            /// </summary>
            /// <param name="color"></param>
            /// <param name="objectString"></param>
            /// <param name="keyword"></param>
            public ConvertedSlot(Slot slot, String keyword)
            {
                AdjectiveProperty = ConvertColorToAdjective(keyword, slot.Color);
                NounProperty = ConvertObjectToNoun(keyword, slot.Object);
            }

            /// <summary>
            /// Converting a color into a placeholder adjective
            /// </summary>
            /// <param name="keyword">used to see what the color gets converted to</param>
            /// <param name="color">the color that will be converted</param>
            /// <returns>the adjective the color converted to</returns>
            public Adjective ConvertColorToAdjective(String keyword, String color)
            {
                if (keyword == "Sassy")
                {
                    switch (color)
                    {
                        //if keyword is sassy and the color is blue, the adjective is sassy
                        case "Blue":
                            return Adjective.SASSY;
                        //if keyword is sassy and the color is red, the adjective is silly
                        case "Red":
                            return Adjective.SILLY;

                        //if keyword is sassy and the color is green, the adjective is soggy
                        case "Green":
                            return Adjective.SOGGY;
                    }
                }
                else if (keyword == "Silly")
                {
                    switch (color)
                    {
                        //if keyword is silly and the color is blue, the adjective is sassy
                        case "Blue":
                            return Adjective.SASSY;

                        //if keyword is silly and the color is red, the adjective is soggy
                        case "Red":
                            return Adjective.SOGGY;

                        //if keyword is silly and the color is green, the adjective is silly
                        case "Green":
                            return Adjective.SILLY;
                    }
                }
                else if (keyword == "Soggy")
                {
                    switch (color)
                    {
                        //if keyword is soggy and the color is blue, the adjective is silly
                        case "Blue":
                            return Adjective.SILLY;

                        //if keyword is soggy and the color is red, the adjective is soggy
                        case "Red":
                            return Adjective.SOGGY;

                        //if keyword is soggy and the color is green, the adjective is sassy
                        case "Green":
                            return Adjective.SASSY;
                    }
                }
                else if (keyword == "Sally")
                {
                    switch (color)
                    {
                        //if keyword is sally and the color is blue, the adjective is silly
                        case "Blue":
                            return Adjective.SILLY;

                        //if keyword is sally and the color is red, the adjective is sassy
                        case "Red":
                            return Adjective.SASSY;

                        //if keyword is sally and the color is green, the adjective is soggy
                        case "Green":
                            return Adjective.SOGGY;
                    }
                }
                else if (keyword == "Simon")
                {
                    switch (color)
                    {
                        //if keyword is simon and the color is blue, the adjective is soggy
                        case "Blue":
                            return Adjective.SOGGY;

                        //if keyword is simon and the color is red, the adjective is sassy
                        case "Red":
                            return Adjective.SASSY;

                        //if keyword is simon and the color is green, the adjective is silly
                        case "Green":
                            return Adjective.SILLY;
                    }
                }
                else if (keyword == "Sausage")
                {
                    switch (color)
                    {
                        //if keyword is sausage and the color is blue, the adjective is silly
                        case "Blue":
                            return Adjective.SILLY;

                        //if keyword is sausage and the color is red, he adjective is sassy
                        case "Red":
                            return Adjective.SASSY;

                        //if keyword is sausage and the color is green, the adjective is soggy
                        case "Green":
                            return Adjective.SOGGY;
                    }
                }
                else if (keyword == "Steven")
                {
                    switch (color)
                    {
                        //if keyword is steven and the color is blue, the adjective is soggy
                        case "Blue":
                            return Adjective.SOGGY;

                        //if keyword is steven and the color is red, the adjective is silly
                        case "Red":
                            return Adjective.SILLY;

                        //if keyword is steven and the color is green, the adjective is sassy
                        case "Green":
                            return Adjective.SASSY;
                    }
                }

                //this should not happen
                return Adjective.SASSY;
            }

            /// <summary>
            /// Converting an object into a placeholder noun
            /// </summary>
            /// <param name="keyword">used to see what the color gets converted to</param>
            /// <param name="objectString">the object that will be converted</param>
            /// <returns></returns>
            public Noun ConvertObjectToNoun(String keyword, String objectString)
            {
                if (keyword == "Sassy")
                {
                    switch (objectString)
                    {
                        //if keyword is sassy and the object is cherry, the adjective is sally
                        case "Cherry":
                            return Noun.SALLY;

                        //if keyword is sassy and the object is grape, the adjective is simon
                        case "Grape":
                            return Noun.SIMON;

                        //if keyword is sassy and the object is bomb, the adjective is sausage
                        case "Bomb":
                            return Noun.SAUSAGE;

                        //if keyword is sassy and the object is coin, the adjective is steven
                        case "Coin":
                            return Noun.STEVEN;
                    }
                }
                else if (keyword == "Silly")
                {
                    switch (objectString)
                    {
                        //if keyword is silly and the object is cherry, the adjective is steven
                        case "Cherry":
                            return Noun.STEVEN;

                        //if keyword is silly and the object is grape, the adjective is sausage
                        case "Grape":
                            return Noun.SAUSAGE;

                        //if keyword is silly and the object is bomb, the adjective is simon
                        case "Bomb":
                            return Noun.SIMON;

                        //if keyword is silly and the object is coin, the adjective is sally
                        case "Coin":
                            return Noun.SALLY;
                    }
                }
                else if (keyword == "Soggy")
                {
                    switch (objectString)
                    {
                        //if keyword is soggy and the object is cherry, the adjective is simon
                        case "Cherry":
                            return Noun.SIMON;

                        //if keyword is soggy and the object is grape, the adjective is steven
                        case "Grape":
                            return Noun.STEVEN;

                        //if keyword is soggy and the object is bomb, the adjective is sausage
                        case "Bomb":
                            return Noun.SAUSAGE;

                        //if keyword is soggy and the object is coin, the adjective is sally

                        case "Coin":
                            return Noun.SALLY;
                    }
                }
                else if (keyword == "Sally")
                {
                    switch (objectString)
                    {
                        //if keyword is sally and the object is cherry, the adjective is simon
                        case "Cherry":
                            return Noun.SIMON;

                        //if keyword is sally and the object is grape, the adjective is sally
                        case "Grape":
                            return Noun.SALLY;

                        //if keyword is sally and the object is bomb, the adjective is sausage
                        case "Bomb":
                            return Noun.SAUSAGE;

                        //if keyword is sally and the object is coin, the adjective is steven
                        case "Coin":
                            return Noun.STEVEN;
                    }
                }
                else if (keyword == "Simon")
                {
                    switch (objectString)
                    {
                        //if keyword is simon and the object is cherry, the adjective is sausage
                        case "Cherry":
                            return Noun.SAUSAGE;

                        //if keyword is simon and the object is grape, the adjective is simon
                        case "Grape":
                            return Noun.SIMON;

                        //if keyword is simon and the object is bomb, the adjective is sally
                        case "Bomb":
                            return Noun.SALLY;

                        //if keyword is simon and the object is coin, the adjective is steven
                        case "Coin":
                            return Noun.STEVEN;
                    }
                }
                else if (keyword == "Sausage")
                {
                    switch (objectString)
                    {
                        //if keyword is sausage and the object is cherry, the adjective is steven
                        case "Cherry":
                            return Noun.STEVEN;

                        //if keyword is sausage and the object is grape, the adjective is sally
                        case "Grape":
                            return Noun.SALLY;

                        //if keyword is sausage and the object is bomb, the adjective is simon
                        case "Bomb":
                            return Noun.SIMON;

                        //if keyword is sausage and the object is coin, the adjective is sausage
                        case "Coin":
                            return Noun.SAUSAGE;
                    }
                }
                else if (keyword == "Steven")
                {
                    switch (objectString)
                    {
                        //if keyword is steven and the object is cherry, the adjective is sally
                        case "Cherry":
                            return Noun.SALLY;

                        //if keyword is steven and the object is grape, the adjective is steven
                        case "Grape":
                            return Noun.STEVEN;

                        //if keyword is steven and the object is bomb, the adjective is simon
                        case "Bomb":
                            return Noun.SIMON;

                        //if keyword is steven and the object is coin, the adjective is sausage
                        case "Coin":
                            return Noun.SAUSAGE;
                    }
                }

                //this should not happen
                return Noun.SALLY;
            }

            /// <summary>
            /// Tells if a slot has the same adjective as this one
            /// </summary>
            /// <param name="slot">the slot that will be compared to this one</param>
            /// <returns>true if they have the same adjective</returns>
            public bool AdjectiveEqual(ConvertedSlot slot)
            {
                return AdjectiveProperty == slot.AdjectiveProperty;
            }

            /// <summary>
            /// Tells if a slot has the same noun as this one
            /// </summary>
            /// <param name="slot">the slot that will be compared to this one</param>
            /// <returns>true if they have the same noun</returns>
            public bool NounEqual(ConvertedSlot slot)
            {
                return NounProperty == slot.NounProperty;
            }

            /// <summary>
            /// Tells if a slot has the same noun and adjective as this one
            /// </summary>
            /// <param name="slot">the slot that will be compared to this one</param>
            /// <returns>true if a slot has the same noun and adjective as this
            ///           one</returns>
            public bool SlotEqual(ConvertedSlot slot)
            {
                return NounEqual(slot) && AdjectiveEqual(slot);
            }
        }

        public class Slot
        {
            public String Object { get; set; }
            public String Color { get; set; }

            public Slot(String color, String Object)
            {
                this.Object = Object;
                Color = color;
            }
        }
    }
}
