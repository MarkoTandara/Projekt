using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Projekt
{
    public partial class Form1 : Form
    {
        string[,] MushroomValues;
        
        public Form1()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        private async void btn_Predict_Click(object sender, System.EventArgs e)
        {
            Klasifikator Klasifikator = new Klasifikator();
            getValuesFromSelectedItems();
            Klasifikator.setValues(MushroomValues);
            string feedback = await Klasifikator.InvokeRequestResponseService();
            dynamic data = JObject.Parse(feedback);
            float Scored_Probability = data.Results.output1.value.Values[0][2];
            string Edible = data.Results.output1.value.Values[0][1];
            PrintResults(Scored_Probability, Edible);
        }
        private void PrintResults(float probability, string edible)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText(" Mushroom is:\n " + edible + "\n Scored Probability is:\n " + probability);
        }
        
        private void InitializeComboBoxes()
        {
            cb_Cap_Shape.SelectedIndex = 0;
            cb_Cap_Shape.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Cap_Surface.SelectedIndex = 0;
            cb_Cap_Surface.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Cap_Color.SelectedIndex = 0;
            cb_Cap_Color.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Bruises.SelectedIndex = 0;
            cb_Bruises.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Odor.SelectedIndex = 0;
            cb_Odor.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Gill_Attachment.SelectedIndex = 0;
            cb_Gill_Attachment.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Gill_Spacing.SelectedIndex = 0;
            cb_Gill_Spacing.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Gill_Size.SelectedIndex = 0;
            cb_Gill_Size.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Gill_Color.SelectedIndex = 0;
            cb_Gill_Color.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Stalk_Shape.SelectedIndex = 0;
            cb_Stalk_Shape.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Stalk_Root.SelectedIndex = 0;
            cb_Stalk_Root.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Stalk_Surface_Above_Ring.SelectedIndex = 0;
            cb_Stalk_Surface_Above_Ring.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Stalk_Surface_Below_Ring.SelectedIndex = 0;
            cb_Stalk_Surface_Below_Ring.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Stalk_Color_Above_Ring.SelectedIndex = 0;
            cb_Stalk_Color_Above_Ring.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Stalk_Color_Below_Ring.SelectedIndex = 0;
            cb_Stalk_Color_Below_Ring.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Veil_Type.SelectedIndex = 0;
            cb_Veil_Type.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Veil_Color.SelectedIndex = 0;
            cb_Veil_Color.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Ring_Number.SelectedIndex = 0;
            cb_Ring_Number.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Ring_Type.SelectedIndex = 0;
            cb_Ring_Type.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Spore_Print_Color.SelectedIndex = 0;
            cb_Spore_Print_Color.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Population.SelectedIndex = 0;
            cb_Population.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Habitat.SelectedIndex = 0;
            cb_Habitat.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void getValuesFromSelectedItems()
        {
            MushroomValues = new string[,] { { "V",
                    cb_Cap_Shape.SelectedItem.ToString(),
                    cb_Cap_Surface.SelectedItem.ToString(),
                    cb_Cap_Color.SelectedItem.ToString(),
                    cb_Bruises.SelectedItem.ToString(),
                    cb_Odor.SelectedItem.ToString(),
                    cb_Gill_Attachment.SelectedItem.ToString(),
                    cb_Gill_Spacing.SelectedItem.ToString(),
                    cb_Gill_Size.SelectedItem.ToString(),
                    cb_Gill_Color.SelectedItem.ToString(),
                    cb_Stalk_Shape.SelectedItem.ToString(),
                    cb_Stalk_Root.SelectedItem.ToString(),
                    cb_Stalk_Surface_Above_Ring.SelectedItem.ToString(),
                    cb_Stalk_Surface_Below_Ring.SelectedItem.ToString(),
                    cb_Stalk_Color_Above_Ring.SelectedItem.ToString(),
                    cb_Stalk_Color_Below_Ring.SelectedItem.ToString(),
                    cb_Veil_Type.SelectedItem.ToString(),
                    cb_Veil_Color.SelectedItem.ToString(),
                    cb_Ring_Number.SelectedItem.ToString(),
                    cb_Ring_Type.SelectedItem.ToString(),
                    cb_Spore_Print_Color.SelectedItem.ToString(),
                    cb_Population.SelectedItem.ToString(),
                    cb_Habitat.SelectedItem.ToString() } };
        }
    }
}
