using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace dekanat
{
    public partial class Form1 : Form
    {
        List<Teacher> teachers = new List<Teacher>();
        List<Student> students = new List<Student>();
      
        public Form1()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Text = "";
            foreach(Teacher count in teachers)
            {
                Regex regex = new Regex("^"+textBox1.Text);
                MatchCollection matches = regex.Matches(count.lastname);
                if (matches.Count > 0)
                {
                    string groupsTemp = "";
                    for (int i = 0; i < count.id_group.Length; i++)
                    {
                        groupsTemp += count.id_group[i] + " ";
                    }
                    label4.Text += count.lastname + " " + count.midname + " " + count.firstname + " " + groupsTemp + " \n";

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = textBox10.Text;
            string[] tempArr = temp.Split(' ');
            int[] arr = new int[tempArr.GetLength(0)];
            for (int i = 0; i < tempArr.GetLength(0); i++)
            {
                arr[i] = Convert.ToInt32(tempArr[i]);
            }
            Teacher new_teach = new Teacher(textBox4.Text, textBox6.Text, textBox9.Text, arr);
            
            using (StreamWriter write = new StreamWriter("teacher.txt", true))
            {
                string tempTeacherJS = JsonSerializer.Serialize<Teacher>(new_teach);
                write.WriteLine(tempTeacherJS);
            }
            teachers.Add(new_teach);

            label4.Text += new_teach.lastname + " " + new_teach.midname + " " + new_teach.firstname + " " + textBox10.Text + " \n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student new_stud = new Student(textBox12.Text, textBox11.Text, textBox7.Text, Convert.ToInt32(textBox5.Text));

            using (StreamWriter write = new StreamWriter("student.txt", true))
            {
                string tempStudJS = JsonSerializer.Serialize<Student>(new_stud);
                write.WriteLine(tempStudJS);
            }
           
            students.Add(new_stud);
            label6.Text += new_stud.lastname + " " + new_stud.midname + " " + new_stud.firstname + " " + new_stud.id_group + " \n";
        }
        public void refresh()
        {
            foreach (Teacher count in teachers)
            {
                string groupsTemp = "";
                for (int i = 0; i < count.id_group.Length; i++)
                {
                    groupsTemp += count.id_group[i] + " ";
                }
                label4.Text += count.lastname + " " + count.midname + " " + count.firstname+ " " + groupsTemp + " \n";
            }
            foreach (Student count in students)
            {
                label6.Text += count.lastname + " " + count.midname + " " + count.firstname +" "+ count.id_group +" \n";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader read = new StreamReader("student.txt", true))
            {
                while (!read.EndOfStream)
                {
                    Student restoredStud = JsonSerializer.Deserialize<Student>(read.ReadLine());
                    students.Add(restoredStud);
                    label6.Text += restoredStud.lastname + " " + restoredStud.midname + " " + restoredStud.firstname + " " + restoredStud.id_group + " \n";
                }
            }
            using (StreamReader read = new StreamReader("teacher.txt", true))
            {
                while (!read.EndOfStream)
                {
                    Teacher restoredTeach = JsonSerializer.Deserialize<Teacher>(read.ReadLine());
                    teachers.Add(restoredTeach);
                    string groupsTemp = "";
                    for (int i = 0; i < restoredTeach.id_group.Length; i++)
                    {
                        groupsTemp += restoredTeach.id_group[i] + " ";
                    }
                 
                    label4.Text += restoredTeach.lastname + " " + restoredTeach.midname + " " + restoredTeach.firstname+" " + groupsTemp + " \n";
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label6.Text = "";
            foreach (Student count in students)
            {
                Regex regex = new Regex("^" + textBox3.Text);
                MatchCollection matches = regex.Matches(count.lastname);
                if (matches.Count > 0)
                    label6.Text += count.lastname + " " + count.midname + " " + count.firstname+ " " + count.id_group + " \n";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label4.Text = "";
            label6.Text = "";
            refresh();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
