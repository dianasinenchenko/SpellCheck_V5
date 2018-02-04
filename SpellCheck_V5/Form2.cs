using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SpellCheck_V5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
         
        }

        string wrongWord ;
        string allText;
        

        public void setAllText(string allText)
        {
            this.allText = allText;
        }
        

        public void setInputWrongWord(string wrongWord)
        {
            this.wrongWord = wrongWord;
        }
        

        public void checkText(string text)
        {           
            //words from richTextBox add to list for one words
           string[] lines = richTextBox1.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        
            //create dictionary list
            var dictionary = File.ReadAllLines("../../frequency_dictionary_en_82_765.txt");
            List<string> dictionaryList = new List<string>();
            foreach (var line in dictionary)
            {
                var words = line.Split(' ');
                foreach (var word in words)
                {
                    dictionaryList.Add(word);
                }
            }
            

           foreach (string inputTerm in lines)
            {
              string inputTermChange = inputTerm.Trim(new char[] { ',', '.', '!', '?' });
              string lowerText = inputTermChange.ToLower();

                if (dictionaryList.Exists(x => String.Equals(x, inputTermChange)))
                { }
                else
                {
                    setInputWrongWord(inputTermChange);
                    richTextBox1.Select(richTextBox1.Text.IndexOf(inputTerm), lowerText.Length);
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline);
                    richTextBox1.SelectionColor = Color.Red;                   
                    setAllText(richTextBox1.Text.ToString());
                }
            }
        }
        

        public void setStringBack(string back)
        {
            this.richTextBox1.Text = back;
        }           


        private void button2_Click(object sender, EventArgs e)
        {
            Form1 changeForm = new Form1();
            changeForm.Show();          
            changeForm.setWrongWord(wrongWord);
            changeForm.AllText(allText);
            Hide();           
        }


        private void Form2_Load(object sender, EventArgs e)
        { }

        
       public void button1_Click(object sender, EventArgs e)
        {            
            checkText(richTextBox1.Text.ToString());
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";         
        }
    }
}
