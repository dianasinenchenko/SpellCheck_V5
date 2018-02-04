using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SpellCheck_V5
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();          
        }
                
        string allText;

        private void label1_Click(object sender, EventArgs e)
        { }
               
        // set wrong word in the textBox
        public void setWrongWord (string wrongWord)
        {
            this.richTextBox1.Text = wrongWord;
        }

        
        public void AllText (string allText)
        {
            this.allText = allText;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        { }


        private void button1_Click(object sender, EventArgs e)
        {
            //create object
            int initialCapacity = 82765;
            int maxEditDistanceDictionary = 2; //maximum edit distance per dictionary precalculation
            var symSpell = new SymSpell(initialCapacity, maxEditDistanceDictionary);

            
            //load dictionary
            string dictionaryPath = "../../frequency_dictionary_en_82_765.txt";
            int termIndex = 0; //column of the term in the dictionary text file
            int countIndex = 1; //column of the term frequency in the dictionary text file
            if (!symSpell.LoadDictionary(dictionaryPath, termIndex, countIndex)) richTextBox1.Text = "File not found!";         
            

            var suggList = new List<string>();
            string wrongWord = richTextBox1.Text.ToString();
            string lowerWrongWord = wrongWord.ToLower();


            int maxEditDistanceLookup = 1; //max edit distance per lookup (maxEditDistanceLookup<=maxEditDistanceDictionary)
            var suggestionVerbosity = SymSpell.Verbosity.Closest; //Top, Closest, All
            var suggestions = symSpell.Lookup(lowerWrongWord, suggestionVerbosity, maxEditDistanceLookup);
                

                foreach (var suggestion in suggestions)
                {                                     
                    listBox1.Items.Add(suggestion.term.ToString());               
                }  
        }


        public void richTextBox1_TextChanged(object sender, EventArgs e)
        { }


        private void button2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();            
            newForm.Show();
            newForm.setStringBack(allText.Replace(richTextBox1.Text.ToString(), listBox1.SelectedItem.ToString()));
            newForm.checkText(richTextBox1.Text.ToString());
            Close();
        }

        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        { }


        private void button3_Click(object sender, EventArgs e)
        { }

    }
}

