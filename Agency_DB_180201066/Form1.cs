using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agency_DB_180201066
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Enroll' table. You can move, or remove it, as needed.
            this.enrollTableAdapter.Fill(this.dataSet1.Enroll);
            // TODO: This line of code loads data into the 'dataSet1.Scenario' table. You can move, or remove it, as needed.
            this.scenarioTableAdapter.Fill(this.dataSet1.Scenario);
            // TODO: This line of code loads data into the 'dataSet1.Film' table. You can move, or remove it, as needed.
            this.filmTableAdapter.Fill(this.dataSet1.Film);
            // TODO: This line of code loads data into the 'dataSet1.Manager' table. You can move, or remove it, as needed.
            this.managerTableAdapter.Fill(this.dataSet1.Manager);
            // TODO: This line of code loads data into the 'dataSet1.Actor' table. You can move, or remove it, as needed.
            this.actorTableAdapter.Fill(this.dataSet1.Actor);
            // TODO: This line of code loads data into the 'dataSet1.Agency' table. You can move, or remove it, as needed.
            this.agencyTableAdapter.Fill(this.dataSet1.Agency);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//ADD AGENCY
        {
            this.agencyTableAdapter.InsertQuery(textBox1.Text, textBox2.Text);
            this.agencyTableAdapter.Fill(this.dataSet1.Agency);


        }


        private void button4_Click(object sender, EventArgs e)
        {
            int Agency_ID, Actor_ID;
            int.TryParse(textBox8.Text, out Actor_ID);
            int.TryParse(comboBox1.SelectedValue.ToString(), out Agency_ID);

            this.actorTableAdapter.InsertQuery(textBox6.Text, textBox7.Text, Actor_ID, Agency_ID);
            this.actorTableAdapter.Fill(this.dataSet1.Actor);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)//ADD MANAGER
        {
            int Agency_ID;

            int.TryParse(comboBox3.SelectedValue.ToString(), out Agency_ID);
            this.managerTableAdapter.InsertQuery(textBox13.Text, textBox14.Text, Convert.ToInt32(textBox15.Text), Agency_ID);
            this.managerTableAdapter.Fill(this.dataSet1.Manager);

        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)//ADD ENROLL
        {
            this.enrollTableAdapter.InsertQuery(Convert.ToInt32(textBox19.Text), Convert.ToInt32(textBox21.Text));
            this.enrollTableAdapter.Fill(this.dataSet1.Enroll);
        }

        private void button13_Click(object sender, EventArgs e)//ADD FILM
        {
            this.filmTableAdapter.InsertQuery(textBox25.Text, textBox26.Text);
            this.filmTableAdapter.Fill(this.dataSet1.Film);

        }

        private void button16_Click(object sender, EventArgs e)
        {
            int Film_ID;
            int.TryParse(comboBox5.SelectedValue.ToString(), out Film_ID);
            this.scenarioTableAdapter.InsertQuery(textBox30.Text, textBox31.Text, Film_ID);
            this.scenarioTableAdapter.Fill(this.dataSet1.Scenario);
        }

        private void button2_Click(object sender, EventArgs e)//SEAECH AGENCY
        {
            int ID;
            int.TryParse(textBox5.Text, out ID);
            textBox3.Text = this.agencyTableAdapter.ScalarQuery(ID);
            textBox4.Text = this.agencyTableAdapter.ScalarQuery1(ID);
        }

        private void button3_Click(object sender, EventArgs e)//UPDATE AGENCY
        {
            int ID;
            int.TryParse(textBox5.Text, out ID);
            this.agencyTableAdapter.UpdateQuery(textBox3.Text, textBox4.Text, ID);
            this.agencyTableAdapter.Fill(this.dataSet1.Agency);

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(textBox5.Text, out ID);
            this.agencyTableAdapter.DeleteQuery(ID);
            this.agencyTableAdapter.Fill(this.dataSet1.Agency);


            this.actorTableAdapter.UpdateQuery_Delete_Agency(ID); //BU DELETE ISLEMINI ACTORDA GÖSTERMEK ICIN
            this.actorTableAdapter.Fill(this.dataSet1.Actor);

            this.managerTableAdapter.UpdateQuery_Delete_Agency(ID);
            this.managerTableAdapter.Fill(this.dataSet1.Manager);
        }

        private void button5_Click(object sender, EventArgs e)//ACTOR SEARCH
        {
            int ID;

            int.TryParse(textBox9.Text, out ID);
            textBox10.Text = this.actorTableAdapter.ScalarQuery_FirstName(ID);
            textBox11.Text = this.actorTableAdapter.ScalarQuery_LastName(ID);
            textBox12.Text = Convert.ToString(this.actorTableAdapter.ScalarQuery_Age(ID));
            comboBox2.SelectedValue = this.actorTableAdapter.ScalarQuery_Agency_ID(ID);
        
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)//UPDATE ACTOR
        {
            int ID, Agency_ID, Actor_Age;

            int.TryParse(textBox9.Text, out ID);
            int.TryParse(comboBox2.SelectedValue.ToString(), out Agency_ID);
            int.TryParse(textBox12.Text, out Actor_Age);

            this.actorTableAdapter.UpdateQuery(textBox10.Text, textBox11.Text,Actor_Age,Agency_ID, ID);
            this.actorTableAdapter.Fill(this.dataSet1.Actor);

        }

        private void button20_Click(object sender, EventArgs e)//DELETE ACTOR
        {
            int ID;
            int.TryParse(textBox9.Text, out ID);
            this.actorTableAdapter.DeleteQuery(ID);
            this.actorTableAdapter.Fill(this.dataSet1.Actor);
        }

        private void button8_Click(object sender, EventArgs e)// MANAGER SEARCH
        {
            int ID;
            int.TryParse(textBox20.Text, out ID);
            managername.Text = this.managerTableAdapter.ScalarQuery(ID);
            managersurname.Text = this.managerTableAdapter.ScalarQuery1(ID);
            managerphone.Text = Convert.ToString(this.managerTableAdapter.ScalarQuery2(ID));
            comboBox4.SelectedValue = this.managerTableAdapter.ScalarQuery3(ID);
        }

        private void button9_Click(object sender, EventArgs e)//MANAGER UPDATE
        {
            int ID, Manager_Phone_Num, Agency_ID;

            int.TryParse(textBox20.Text, out ID);
            int.TryParse(comboBox4.SelectedValue.ToString(), out Agency_ID);
            int.TryParse(managerphone.Text, out Manager_Phone_Num);

            this.managerTableAdapter.UpdateQuery(managername.Text, managersurname.Text, Manager_Phone_Num,Agency_ID, ID);
            this.managerTableAdapter.Fill(this.dataSet1.Manager);

        }

        private void button24_Click(object sender, EventArgs e)//MANAGER DELETE
        {
            int ID;
            int.TryParse(textBox20.Text, out ID);
            this.managerTableAdapter.DeleteQuery(ID);
            this.managerTableAdapter.Fill(this.dataSet1.Manager);
          
        }

        private void button14_Click(object sender, EventArgs e)//FILM SEARCH
        {
            int ID;
            int.TryParse(textBox29.Text, out ID);
            textBox27.Text = this.filmTableAdapter.ScalarQuery(ID);
            textBox28.Text = this.filmTableAdapter.ScalarQuery1(ID);
            
            
        }

        private void button22_Click(object sender, EventArgs e)//UPDATE FİLM
        {
            int ID;
            int.TryParse(textBox29.Text, out ID);
            this.filmTableAdapter.UpdateQuery(textBox27.Text, textBox28.Text, ID);
            this.filmTableAdapter.Fill(this.dataSet1.Film);
        }

        private void button15_Click(object sender, EventArgs e)//DELETE FILM
        {
            int ID;
            int.TryParse(textBox29.Text, out ID);
            this.filmTableAdapter.DeleteQuery(ID);
            this.filmTableAdapter.Fill(this.dataSet1.Film);

            this.scenarioTableAdapter.UpdateQuery_Delete_Film(ID); //BU DELETE ISLEMINI SCENARIO DA GÖSTERMEK ICIN
            this.scenarioTableAdapter.Fill(this.dataSet1.Scenario);


        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)//ENROLL SEARCH
        {
            int ID;
            int.TryParse(textBox22.Text, out ID);
            textBox23.Text = Convert.ToString(this.enrollTableAdapter.ScalarQuery(ID));
            textBox24.Text = Convert.ToString(this.enrollTableAdapter.ScalarQuery1(ID));
        }

        private void button12_Click(object sender, EventArgs e)//ENROLL UPDATE
        {
            int ID, Actor_ID, Film_ID;
            int.TryParse(textBox22.Text, out ID);
            int.TryParse(textBox23.Text, out Actor_ID);
            int.TryParse(textBox24.Text, out Film_ID);

            this.enrollTableAdapter.UpdateQuery(Actor_ID,Film_ID, ID);
            this.enrollTableAdapter.Fill(this.dataSet1.Enroll);

        }

        private void button23_Click(object sender, EventArgs e)//DELETE ENROLL
        {
            int ID;
            int.TryParse(textBox22.Text, out ID);
            this.enrollTableAdapter.DeleteQuery(ID);
            this.enrollTableAdapter.Fill(this.dataSet1.Enroll);

            //this.actorTableAdapter.UpdateQuery_Delete_Agency(ID); //BU DELETE ISLEMINI ACTOR DE GÖSTERMEK ICIN
            //this.actorTableAdapter.Fill(this.dataSet1.Actor);

            
            
        }

        private void button17_Click(object sender, EventArgs e)//SEARCH SCENARIO
        {
            int ID;
            int.TryParse(textBox33.Text, out ID);

            textBox34.Text = this.scenarioTableAdapter.ScalarQuery(ID);
            textBox35.Text = this.scenarioTableAdapter.ScalarQuery1(ID);
            comboBox6.SelectedValue = this.scenarioTableAdapter.ScalarQuery2(ID);

        }

        private void button18_Click(object sender, EventArgs e)//UPDATE SCENARIO
        {
            int ID,Film_ID;

            int.TryParse(textBox33.Text, out ID);
            int.TryParse(comboBox6.SelectedValue.ToString(), out Film_ID);
           

            this.scenarioTableAdapter.UpdateQuery(textBox34.Text, textBox35.Text, Film_ID, ID);
            this.scenarioTableAdapter.Fill(this.dataSet1.Scenario);

        }

        private void button21_Click(object sender, EventArgs e)//DELETE SCENARIO
        {
            int ID;
            int.TryParse(textBox33.Text, out ID);
            this.scenarioTableAdapter.DeleteQuery(ID);
            this.scenarioTableAdapter.Fill(this.dataSet1.Scenario);
        }
    }
}
