using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure_walsh
{
    class NPC : Mob
    {
        private string _faction;
        private string _name;

        private bool _dialogueIreth01Said;
        private bool _dialogueIreth02Said;
        private bool _dialogueIreth03Said;
        private bool _dialogueIreth04Said;
        private bool _dialogueIreth05Said;

        private bool _dialogueSauvterre01Said;
        private bool _dialogueSauvterre02Said;
        private bool _dialogueSauvterre03Said;
        private bool _dialogueSauvterre04Said;
        private bool _dialogueSauvterre05Said;

        private bool _dialogueAtlas01Said;
        private bool _dialogueAtlas02Said;
        private bool _dialogueAtlas03Said;
        private bool _dialogueAtlas04Said;
        private bool _dialogueAtlas05Said;

        private bool _dialogueAnnabelle01Said;
        private bool _dialogueAnnabelle02Said;
        private bool _dialogueAnnabelle03Said;
        private bool _dialogueAnnabelle04Said;
        private bool _dialogueAnnabelle05Said;

        private bool _dialogueFaustus01Said;
        private bool _dialogueFaustus02Said;
        private bool _dialogueFaustus03Said;
        private bool _dialogueFaustus04Said;
        private bool _dialogueFaustus05Said;

        private bool _faustItemGiven;
        private bool _atlasItemGiven;

        public NPC()
        {
            _faction = "Unknown";
            _name = "Generic NPC";
            _dialogueIreth01Said = false;
            _dialogueIreth02Said = false;
            _dialogueIreth03Said = false;
            _dialogueIreth04Said = false;
            _dialogueIreth05Said = false;

            _dialogueSauvterre01Said = false;
            _dialogueSauvterre02Said = false;
            _dialogueSauvterre03Said = false;
            _dialogueSauvterre04Said = false;
            _dialogueSauvterre05Said = false;

            _dialogueAtlas01Said = false;
            _dialogueAtlas02Said = false;
            _dialogueAtlas03Said = false;
            _dialogueAtlas04Said = false;
            _dialogueAtlas05Said = false;

            _dialogueAnnabelle01Said = false;
            _dialogueAnnabelle02Said = false;
            _dialogueAnnabelle03Said = false;
            _dialogueAnnabelle04Said = false;
            _dialogueAnnabelle05Said = false;

            _dialogueFaustus01Said = false;
            _dialogueFaustus02Said = false;
            _dialogueFaustus03Said = false;
            _dialogueFaustus04Said = false;
            _dialogueFaustus05Said = false;

            _faustItemGiven = false;
            _atlasItemGiven = false;
        }

        public string Faction
        {
            get
            {
                return _faction;
            }
            set
            {
                _faction = value;
            }
        }

        public override string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public bool DialogueAtlas01Said
        {
            get; set;
        }

        public bool DialogueAtlas02Said
        {
            get; set;
        }

        public bool DialogueAtlas03Said
        {
            get; set;
        }

        public bool DialogueAtlas04Said
        {
            get; set;
        }

        public bool DialogueAtlas05Said
        {
            get; set;
        }

        public bool DialogueFaustus01Said
        {
            get; set;
        }

        public bool DialogueFaustus02Said
        {
            get; set;
        }

        public bool DialogueFaustus03Said
        {
            get; set;
        }

        public bool DialogueFaustus04Said
        {
            get; set;
        }

        public bool DialogueFaustus05Said
        {
            get; set;
        }

        public bool DialogueAnnabelle01Said
        {
            get; set;
        }

        public bool DialogueAnnabelle02Said
        {
            get; set;
        }

        public bool DialogueAnnabelle03Said
        {
            get; set;
        }

        public bool DialogueAnnabelle04Said
        {
            get; set;
        }

        public bool DialogueAnnabelle05Said
        {
            get; set;
        }

        public bool DialogueSauvterre01Said
        {
            get; set;
        }

        public bool DialogueSauvterre02Said
        {
            get; set;
        }

        public bool DialogueSauvterre03Said
        {
            get; set;
        }

        public bool DialogueSauvterre04Said
        {
            get; set;
        }

        public bool DialogueSauvterre05Said
        {
            get; set;
        }

        public bool DialogueIreth01Said
        {
            get; set;
        }

        public bool DialogueIreth02Said
        {
            get; set;
        }

        public bool DialogueIreth03Said
        {
            get; set;
        }

        public bool DialogueIreth04Said
        {
            get; set;
        }

        public bool DialogueIreth05Said
        {
            get; set;
        }

        public bool FaustItemGiven
        {
            get; set;
        }

        public bool AtlasItemGiven
        {
            get; set;
        }

        // Methods start here

        public string getInfo()
        {
            string stats;

            stats = Name + "\nHealth: " + HLT.ToString() + "\nAttack: " + ATK.ToString() + "\nDefense: " + DEF.ToString()
                + "\nSpeed: " + SPD.ToString() + "\nEvasiveness: " + EVA.ToString() + "\nFaction: " + Faction + "\n\n";

            return stats;
        }

        public string irethSpeak()
        {
            string currentDialogue = "Hello there!\n";

            if (_dialogueIreth01Said == false)
            {
                currentDialogue = "Hello, I am Ireth! The Omnifrog told me somebody was coming.\n";
                _dialogueIreth01Said = true;
            }
            else if (_dialogueIreth02Said == false && _dialogueIreth01Said == true)
            {
                currentDialogue = "The Omnifrog watches over this area.\n";
                _dialogueIreth02Said = true;
            }
            else if (_dialogueIreth03Said == false && _dialogueIreth02Said == true)
            {
                currentDialogue = "I wonder if anything else around here would be useful for the database...\n";
                _dialogueIreth03Said = true;
            }
            else if (_dialogueIreth04Said == false && _dialogueIreth03Said == true)
            {
                currentDialogue = "Oh- Did you want into this chest?\n";
                _dialogueIreth04Said = true;
            }
            else if (_dialogueIreth05Said == false && _dialogueIreth04Said == true)
            {
                currentDialogue = "Let us get out of your way.\n";
                _dialogueIreth05Said = true;
            }

            return currentDialogue;
        }

        public string sauvterreSpeak()
        {
            string currentDialogue = "What?\n";

            if (DialogueSauvterre01Said == false)
            {
                currentDialogue = "Name's Rémi Sauvterre. If anybody asks, I'm an elf.\n";
                DialogueSauvterre01Said = true;
            }
            else if (DialogueSauvterre02Said == false && DialogueSauvterre01Said == true)
            {
                currentDialogue = "Do you need something..?\n";
                DialogueSauvterre02Said = true;
            }
            else if (DialogueSauvterre03Said == false && DialogueSauvterre02Said == true)
            {
                currentDialogue = "Be careful who you trust around here.\n";
                DialogueSauvterre03Said = true;
            }

            return currentDialogue;
        }

        public string atlasSpeak()
        {
            string currentDialogue = "Sup.\n";

            if (DialogueAtlas01Said == false)
            {
                currentDialogue = "Thanks for uh.. Helping me out there and all.\n";
                DialogueAtlas01Said = true;
            }
            else if (DialogueAtlas02Said == false && DialogueAtlas01Said == true)
            {
                currentDialogue = "Just. Don't tell anybody you did that.\n";
                DialogueAtlas02Said = true;
            }
            else if (DialogueAtlas03Said == false && DialogueAtlas02Said == true)
            {
                currentDialogue = "Ugh, here, take this.\n";
                DialogueAtlas03Said = true;
            }

            return currentDialogue;
        }

        public string annaSpeak()
        {
            string currentDialogue = "Hello!\n";

            if (DialogueAnnabelle01Said == false)
            {
                currentDialogue = "Zzz...\n";
                DialogueAnnabelle01Said = true;
            }
            else if (DialogueAnnabelle02Said == false && DialogueAnnabelle01Said == true)
            {
                currentDialogue = "Oh-! My apologies.. I seemed to have fallen asleep..\n";
                DialogueAnnabelle02Said = true;
            }
            else if (DialogueAnnabelle03Said == false && DialogueAnnabelle02Said == true)
            {
                currentDialogue = "I'll move now-! I couldn't find the key for this anyways.\n";
                DialogueAnnabelle03Said = true;
            }

            return currentDialogue;
        }

        public string faustSpeak()
        {
            string currentDialogue = "Oh-! H-Hello there!\n";

            if (DialogueFaustus01Said == false)
            {
                currentDialogue = "T-Thank you, thank you, thank you!\n";
                DialogueFaustus01Said = true;
            }
            else if (DialogueFaustus02Said == false && DialogueFaustus01Said == true)
            {
                currentDialogue = "I was in a really sticky situation there.\n";
                DialogueFaustus02Said = true;
            }
            else if (DialogueFaustus03Said == false && DialogueFaustus02Said == true)
            {
                currentDialogue = "Please, let me give you something!\n";
                DialogueFaustus03Said = true;
            }

            return currentDialogue;
        }
    }
}
