using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace New_KTANE_Solver
{
    internal class EnglishTest : Module
    {
        Dictionary<string, List<string>> sentences = new Dictionary<string, List<string>>();

        public EnglishTest(StreamWriter logFileWriter) : base(null, logFileWriter, "English Test")
        {
            sentences.Add("their", new List<string>()
            {"You need to be at their wedding.",
            "How much does this count from their point of view?"}
                );

            sentences.Add("there", new List<string>()
            {
                "He said he'll get there in a hurry.",
                "Look over there!",
            });

            sentences.Add("they're", new List<string>()
            {
                "I don't know what they're thinking.",
                "It depends on whether they're still thinking about it.",
            });

            sentences.Add("your", new List<string>()
            {
                "If you don't do well, your grades will be lowered.",
                "Your pizza is on its way.",
                "I borrowed your ballpoint pen."
            });

            sentences.Add("you're", new List<string>()
            {
                "If you don't do well, you're getting a lower grade.",
                "You're delivering the lines quite well.",
                "I saw you're quite nice."
            });


            sentences.Add("and I", new List<string>()
            {
                "She and I both drink cappuccino.",
                "He and I tried to get the cat out of the tree."
            });

            sentences.Add("and me", new List<string>()
            {
                "He recognized her and me in the photo.",
                "The cat pounced on him and me to get off the tree."
            });

            sentences.Add("he/she", new List<string>()
            {
                "I can swim as much as he.",
                "I can run as much as she."
            });

            sentences.Add("him/her", new List<string>()
            {
                "He'd rather go with me than with him.",
                "She'd rather go with me than with her."
            });

            sentences.Add("less", new List<string>()
            {
                "This recipe needs less sugar.",
                "I run less than he."
            });

            sentences.Add("fewer", new List<string>()
            {
                "This recipe needs fewer sugar cubes.",
                "I run fewer kilometers than he."
            });

            sentences.Add("who", new List<string>()
            {
                "The detective already knew who killed him, but I had no idea.",
                "Who is our newest employee?"
            });

            sentences.Add("whom", new List<string>()
            {
                "With whom were you texting last night?",
                "Whom did we hire most recently?"
            });

            sentences.Add("definitely", new List<string>()
            {
                "Say what you will, but Star Trek is definitely better than Star Wars!",
                "Yes, we definitely talked about this before."
            });


            sentences.Add("defiantly", new List<string>()
            {
                "The teenager defiantly refused to clean his room.",
                "She defiantly stared at him, but stopped herself from yelling at him."
            });

            sentences.Add("lead", new List<string>()
            {
                "This old paint was laced with lead."
            });

            sentences.Add("led", new List<string>()
            {
                "The metal refinery was led by professionals."
            });

            sentences.Add("cite", new List<string>()
            {
                "You need to cite that Web page.",
            });

            sentences.Add("site", new List<string>()
            {
                "You need to include the URL to the site you quoted."
            });

            sentences.Add("sight", new List<string>()
            {
                "Did you sight the bird yet?"
            });

            sentences.Add("lie", new List<string>()
            {
                "I watched the cat lie down on the plush.",
                "Peter should lie on the ground."
            });

            sentences.Add("lay", new List<string>()
            {
                "The cat lay on the plush all morning.",
                "Peter should lay the box down there."
            });

            sentences.Add("laid", new List<string>()
            {
                "Peter laid the box down there."
            });

            sentences.Add("have", new List<string>()
            {
                "You shouldn't have ended the paragraph there.",
                "I just don't know what I should have done to resolve the conflict.",
                "Oh, you should have seen his face when I broke the news to him!",
                "If you told me about it, I would have looked it up.",
                "I wouldn't have done that if I were you.",
                "The boy said that he may or may not have broken the vase.",
                "You might have been a genius all along.",
                "I could have been there if I weren't busy",
                "He couldn't have known what would be the better idea."
            });

            sentences.Add("of", new List<string>()
            {
                "I asked every question I could of him."
            });

            sentences.Add("its", new List<string>()
            {
                "Its wings span five meters.",
                "The anime's story is bland, but at least its effects are good."
            });

            sentences.Add("it's", new List<string>()
            {
                "It's a bird with five-meter wings.",
                "The anime's story is bland, but at least it's not dubbed.\r\nLet's travel to the capital city."
            });

            sentences.Add("capital", new List<string>()
            {
                "Let's travel to the capital city.",
                "The capital of Japan is Tokyo."
            });

            sentences.Add("capitol", new List<string>()
            {
                "Let's see the view from the capitol.",
                "Let's visit Capitol Hill, Washington D.C."
            });

            sentences.Add("affect", new List<string>()
            {
                "This will affect our business negatively.",
                "He sported a snarky affect at the question asked to him.",
                "Don't let him affect you!"
            });

            sentences.Add("effect", new List<string>()
            {
                "This will have a negative effect on our business.",
                "This will have a negative effect on our business.",
            });

            sentences.Add("impacted", new List<string>()
            {
                "You can see from the dent that the boulder impacted the roof of the car.",
            });

            sentences.Add("impact", new List<string>()
            {
                "The impact sound effect sounds a bit too weak.",
            });

            sentences.Add("i.e.", new List<string>()
            {
                "For geometric construction you only need two things, i.e. a compass and a straightedge.",
                "America's personal savings rate was negative in 2005-i.e. consumers spent more than they made!"
            });

            sentences.Add("e.g.", new List<string>()
            {
                "Electric devices, e.g. smartphones, should be turned off in the theater.",
                "Prohibitions of illegal substances (e.g. LSD and meth) has never worked."
            });

            sentences.Add("piqued", new List<string>()
            {
                "The story piqued my interest."
            });

            sentences.Add("peek", new List<string>()
            {
                "Let's take an exclusive sneak peek at the movie!"
            });

            sentences.Add("peaked", new List<string>()
            {
                "His glare peaked my anxiety."
            });

            sentences.Add("a lot", new List<string>()
            {
                "I think about this a lot.",
                "A lot of you have been asking me the same thing."
            });

            sentences.Add("Allot", new List<string>()
            {
                "Allot some more time for homework.",
            });

            sentences.Add("loose", new List<string>()
            {
                "My belt is loose.",
                "My favorite D4 song is Get Loose."
            });

            sentences.Add("lose", new List<string>()
            {
                "Don't lose your focus.",
                "My favorite Eminem song is Lose Yourself."
            });

            sentences.Add("than", new List<string>()
            {
                "I'd rather be with you than without you.",
                "I like red better than yellow."
            });

            sentences.Add("then", new List<string>()
            {
                "Tonight I'll eat dinner then take a bath.",
                "Paint this one red then paint the next one yellow."
            });

            sentences.Add("complimented", new List<string>()
            {
                "He complimented her eyes."
            });

            sentences.Add("complemented", new List<string>()
            {
                "Her eyeshadow complemented her eyes."
            });

            sentences.Add("farther", new List<string>()
            {
                "The batter hit the ball farther than the last batter did.",
                "My house is farther from the school than yours."
            });

            sentences.Add("further", new List<string>()
            {
                "I don't know how to get further past this level.",
                "No further comment has been provided."
            });

            sentences.Add("number", new List<string>()
            {
                "You should reduce the number of eggs in the recipe.",
                "Our youth spend an alarming number of hours browsing the Internet."
            });

            sentences.Add("amount", new List<string>()
            {
                "Our youth spend an alarming amount of time browsing the Internet.",
                "You should reduce the amount of milk in this recipe."
            });

            sentences.Add("to", new List<string>()
            {
                "This dress is to be worn at prom."
            });

            sentences.Add("too", new List<string>()
            {
                "This dress is too tight for me."
            });

            sentences.Add("two", new List<string>()
            {
                "This dress is two sizes bigger than my size."
            });

            sentences.Add("accept", new List<string>()
            {
                "I won't accept failure.",
                "His first choice wouldn't accept him."
            });

            sentences.Add("except", new List<string>()
            {
                "I won't settle for anything except success.",
                "She didn't send the email to anyone except him."
            });

            sentences.Add("through", new List<string>()
            {
                "\"Jesus helped me through tough times,\" reported the devout Christian.",
                "Wow, I never thought you'd actually get through with it."
            });


            sentences.Add("threw", new List<string>()
            {
                "Upon being denied a candy cane, the toddler threw a tantrum.",
                "My favorite Lonely Island song is I Threw It on the Ground."
            });

            sentences.Add("diffused", new List<string>()
            {
                "The fluorescent light diffused on the bomb's surface."
            });

            sentences.Add("defuse", new List<string>()
            {
                "At this rate, we can't defuse the bomb on time!",
            });

            sentences.Add("statue", new List<string>()
            {
                "Let's visit the Statue of Liberty."
            });

            sentences.Add("stature", new List<string>()
            {
                "At the hospital, she measured her weight and stature."
            });

            sentences.Add("statute", new List<string>()
            {
                "We cannot work on Sundays because of the statute regulating it.",
            });

            sentences.Add("stationary", new List<string>()
            {
                "When parking, pull down the side brake to make sure your car stays stationary.",
            });

            sentences.Add("stationery", new List<string>()
            {
                "Don't steal the office stationery!"
            });

            sentences.Add("by", new List<string>()
            {
                "This book is written by Edgar Allan Poe.",
                "This plank of wood is three by twelve inches."
            });

            sentences.Add("bye", new List<string>()
            {
                "Bye, I'll see you tomorrow."
            });


            sentences.Add("breath", new List<string>()
            {
                "I'm out of breath.",
            });

            sentences.Add("breathe", new List<string>()
            {
                "I find it difficult to breathe without an inhaler.",
            });

            sentences.Add("drink", new List<string>()
            {
                "Take a drink if you're thirsty.",
            });

            sentences.Add("drank", new List<string>()
            {
                "She looks like she once drank from the spring of youth."
            });

            sentences.Add("drunk", new List<string>()
            {
                "This kind of tea was drunk in Japan since the early eighth century.",
                "Just a sip of alcohol makes me feel too drunk."
            });

            sentences.Add("discreet", new List<string>()
            {
                "The politician made a statement, but forgot to be discreet about it.",
                "Without encryption, we wouldn't be able to send discreet messages online."
            });

            sentences.Add("discrete", new List<string>()
            {
                "Don't confuse these two discrete problems.",
                "It's perfectly normal and healthy for a couple to sleep in discrete bedrooms."
            });


        }
    }
}
