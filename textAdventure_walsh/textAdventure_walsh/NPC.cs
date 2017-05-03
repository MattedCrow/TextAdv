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
            string currentDialogue = "Hey!\n";

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

            return currentDialogue;
        }

        public string sauvterreSpeak()
        {
            string currentDialogue = "What?\n";

            if (_dialogueSauvterre01Said == false)
            {
                currentDialogue = "Name's Rémi Sauvterre. If anybody asks, I'm an elf.\n";
                _dialogueSauvterre01Said = true;
            }
            else if (_dialogueSauvterre02Said == false && _dialogueSauvterre01Said == true)
            {
                currentDialogue = "Do you need something..?\n";
                _dialogueSauvterre02Said = true;
            }
            else if (_dialogueSauvterre03Said == false && _dialogueSauvterre02Said == true)
            {
                currentDialogue = "Be careful who you trust around here.\n";
                _dialogueSauvterre03Said = true;
            }

            return currentDialogue;
        }

        public string atlasSpeak()
        {
            string currentDialogue = "Sup.";

            if (_dialogueAtlas01Said == false)
            {
                currentDialogue = "Thanks for uh.. Helping me out there and all.\n";
                _dialogueAtlas01Said = true;
            }
            else if (_dialogueAtlas02Said == false && _dialogueAtlas01Said == true)
            {
                currentDialogue = "Just. Don't tell anybody you did that.\n";
                _dialogueAtlas02Said = true;
            }
            else if (_dialogueAtlas03Said == false && _dialogueAtlas02Said == true)
            {
                currentDialogue = "... What?\n";
                _dialogueAtlas03Said = true;
            }

            return currentDialogue;
        }

        public string annaSpeak()
        {
            string currentDialogue = "Hello!";

            if (_dialogueAnnabelle01Said == false)
            {
                currentDialogue = "Thanks for uh.. Helping me out there and all.\n";
                _dialogueAnnabelle01Said = true;
            }
            else if (_dialogueAnnabelle02Said == false && _dialogueAnnabelle01Said == true)
            {
                currentDialogue = "Just. Don't tell anybody you did that.\n";
                _dialogueAnnabelle02Said = true;
            }
            else if (_dialogueAnnabelle03Said == false && _dialogueAnnabelle02Said == true)
            {
                currentDialogue = "... What?\n";
                _dialogueAnnabelle03Said = true;
            }

            return currentDialogue;
        }

        public string faustSpeak()
        {
            string currentDialogue = "Oh-! H-Hello there!";

            if (_dialogueFaustus01Said == false)
            {
                currentDialogue = "T-Thank you, thank you, thank you!\n";
                _dialogueFaustus01Said = true;
            }
            else if (_dialogueFaustus02Said == false && _dialogueFaustus01Said == true)
            {
                currentDialogue = "I was in a really sticky situation there.\n";
                _dialogueFaustus02Said = true;
            }
            else if (_dialogueFaustus03Said == false && _dialogueFaustus02Said == true)
            {
                currentDialogue = "Please, let me give you something!\n";
                _dialogueFaustus03Said = true;
            }

            return currentDialogue;
        }
    }
}
