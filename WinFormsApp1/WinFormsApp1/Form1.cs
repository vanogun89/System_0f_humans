using Excel = Microsoft.Office.Interop.Excel;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Text = "���� �����������";

            //���������� ������ �� excel
            ReadDataExcel();

            // ��������� ��������� ��� ����� � �������
            Size = new Size(600, 450);
            panel1.Visible = true;
            panel1.Location = new Point(0, 0);

            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // ������ �� ������ 1
        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("�� �� ������� �����", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("�� �� ����� �������� � ���� \"�����\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("�� �� ����� �������� � ���� \"������\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (checkLogin(textBox1.Text) != "Ok")
                {
                    MessageBox.Show(checkLogin(textBox1.Text), "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (checkPassword(textBox2.Text) != "Ok")
                {
                    MessageBox.Show(checkPassword(textBox2.Text), "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }      
                else
                {                   
                    string login = textBox1.Text;
                    string password = textBox2.Text;

                    if (comboBox1.SelectedIndex == 0) // ���� ������ ����� "����"
                    {
                        int uniqueNumber = FindUniqueNumber(login);

                        if (uniqueNumber == -1)
                        {
                            MessageBox.Show("�������� ����� ��� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (uniqueNumber != -1 && StaticUser.users[uniqueNumber].Password != password)
                        {
                            MessageBox.Show("�������� ����� ��� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int levelAccess = FindLevelAccess(login);
                            if (levelAccess == 0)
                            {
                                SetDisign(2);
                            }
                            else if (levelAccess == 1)
                            {
                                SetDisign(3);
                            }
                        }
                    }
                    else if (comboBox1.SelectedIndex == 1) // ���� ������ ����� "�����������"
                    {
                        int uniqueNumber = FindUniqueNumber(login);
                        if (uniqueNumber == -1)
                        {
                            SetDisign(1);
                        }
                        else
                        {
                            MessageBox.Show("����� ������������ ����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // ������ �� ������ 1

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ������������ ���������� ��� ���� � ������� ��� ������ ������

        void SetDisign(int number)
        {
            switch (number)
            {
                case 0: // ���� �����
                    Size = new Size(600, 450);
                    Text = "���� �����";
                    panel1.Visible = true;
                    panel1.Location = new Point(0, 0);

                    textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.SelectedIndex = -1;

                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = false;

                    break;
                case 1: // ����������� ������������
                    Size = new Size(550, 600);
                    Text = "���� �����������";
                    panel2.Visible = true;
                    panel2.Location = new Point(0, 0);

                    button4.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    textBox6.Enabled = true;
                    textBox7.Enabled = true;

                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();

                    panel1.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = false;

                    break;
                case 2: // ������ ������������
                    Size = new Size(700, 550);
                    Text = "������ ������������";
                    panel3.Visible = true;
                    panel3.Location = new Point(0, 0);

                    label10.Text = "�� ����� ��� ����������: " + textBox1.Text;

                    button15.Visible = false;
                    button7.Enabled = true;
                    comboBox2.Enabled = true;

                    comboBox2.SelectedIndex = -1;
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    textBox12.Clear();

                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                    textBox10.Enabled = false;
                    textBox11.Enabled = false;
                    textBox12.Enabled = false;

                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = false;

                    break;

                case 3: // ������ ������
                    Size = new Size(700, 550);
                    Text = "������ ��������������";
                    panel4.Visible = true;
                    panel4.Location = new Point(0, 0);

                    label25.Text = "�� ����� ��� admin: " + textBox1.Text;

                    comboBox5.Items.Clear();
                    for (int i = 0; i < StaticUser.counterUsers; i++)
                    {
                        comboBox5.Items.Add(i);
                    }

                    button16.Visible = false;
                    button11.Enabled = true;

                    comboBox3.SelectedIndex = -1;
                    textBox13.Clear();
                    textBox14.Clear();
                    textBox15.Clear();
                    textBox16.Clear();
                    textBox17.Clear();

                    textBox13.Enabled = false;
                    textBox14.Enabled = false;
                    textBox15.Enabled = false;
                    textBox16.Enabled = false;
                    textBox17.Enabled = false;

                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel5.Visible = false;

                    break;

                case 4: // ������ ������ ��� ������ ���� �������������
                    Size = new Size(950, 700);
                    Text = "������ ��������������";
                    panel5.Visible = true;
                    panel5.Location = new Point(0, 0);
                    dataGridView1.Rows.Clear();

                    comboBox4.SelectedIndex = -1;
                    textBox19.Clear();

                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;

                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int FindLevelAccess(string login)
        {
            int levelAccess = -1;
            for (int i = 0; i < StaticUser.counterUsers; i++)
            {
                if (StaticUser.users[i].Login == login)
                {
                    levelAccess = StaticUser.users[i].LevelAccess;
                }
            }
            return levelAccess;
        }

        int FindUniqueNumber(string login)
        {
            int uniqueNumber = -1;
            for (int i = 0; i < StaticUser.counterUsers; i++)
            {
                if (StaticUser.users[i].Login == login)
                {
                    uniqueNumber = StaticUser.users[i].UniqueNumber;
                }
            }
            return uniqueNumber;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"���\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"�������\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"e-mail\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"���������� �������\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"���������� ������\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (textBox2.Text != textBox7.Text)
                {
                    MessageBox.Show("������ �� ���������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AddUser();

                    button4.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    textBox7.Enabled = false;
                }
            }
        }

        void AddUser()
        {
            StaticUser.users[StaticUser.counterUsers] = new User();
            StaticUser.users[StaticUser.counterUsers].UniqueNumber = StaticUser.counterUsers;
            StaticUser.users[StaticUser.counterUsers].Login = textBox1.Text;
            StaticUser.users[StaticUser.counterUsers].Password = textBox2.Text;
            StaticUser.users[StaticUser.counterUsers].FirstName = textBox3.Text;
            StaticUser.users[StaticUser.counterUsers].FullName = textBox4.Text;
            StaticUser.users[StaticUser.counterUsers].Email = textBox5.Text;
            StaticUser.users[StaticUser.counterUsers].NumberPhone = textBox6.Text;
            StaticUser.users[StaticUser.counterUsers].DataRegistration = DateTime.Now.ToString("dd.MM.yyyy");

            StaticUser.counterUsers++;

            WriteInExcel(StaticUser.users[StaticUser.counterUsers], StaticUser.counterUsers);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetDisign(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SetDisign(0);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            int uniqueNumber = FindUniqueNumber(login);

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("�� �� ������� ��������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox2.SelectedIndex == 0)
            {
                textBox11.Text = StaticUser.users[uniqueNumber].FirstName;
                textBox12.Text = StaticUser.users[uniqueNumber].FullName;
                textBox10.Text = StaticUser.users[uniqueNumber].Email;
                textBox9.Text = StaticUser.users[uniqueNumber].NumberPhone;
                textBox8.Text = StaticUser.users[uniqueNumber].Password;

            }
            else if (comboBox2.SelectedIndex == 1)
            {

                textBox11.Text = StaticUser.users[uniqueNumber].FirstName;
                textBox12.Text = StaticUser.users[uniqueNumber].FullName;
                textBox10.Text = StaticUser.users[uniqueNumber].Email;
                textBox9.Text = StaticUser.users[uniqueNumber].NumberPhone;
                textBox8.Text = StaticUser.users[uniqueNumber].Password;

                textBox8.Enabled = true;
                textBox9.Enabled = true;
                textBox10.Enabled = true;
                textBox11.Enabled = true;
                textBox12.Enabled = true;

                button15.Visible = true;
                button7.Enabled = false;
                comboBox2.Enabled = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int uniqueNumber = comboBox5.SelectedIndex;

            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("�� �� ������� ��������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox3.SelectedIndex == 0)
            {
                if (comboBox5.SelectedIndex == -1)
                {
                    MessageBox.Show("�������� ������������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    if (StaticUser.users[uniqueNumber].LevelAccess == 1)
                    {
                        MessageBox.Show("� ����� ������������ ���� ���������� ��������������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        StaticUser.users[uniqueNumber].LevelAccess = 1;
                        comboBox3.SelectedIndex = -1;
                        comboBox5.SelectedIndex = -1;
                        ChangeUserinExcel(uniqueNumber);
                    }
                }
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                if (comboBox5.SelectedIndex == -1)
                {
                    MessageBox.Show("�������� ������������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    textBox17.Text = StaticUser.users[uniqueNumber].FirstName;
                    textBox16.Text = StaticUser.users[uniqueNumber].FullName;
                    textBox15.Text = StaticUser.users[uniqueNumber].Email;
                    textBox14.Text = StaticUser.users[uniqueNumber].NumberPhone;
                    textBox13.Text = Convert.ToString(StaticUser.users[uniqueNumber].LevelAccess);
                }

            }
            else if (comboBox3.SelectedIndex == 2)
            {
                if (comboBox5.SelectedIndex == -1)
                {
                    MessageBox.Show("�������� ������������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    textBox17.Text = StaticUser.users[uniqueNumber].FirstName;
                    textBox16.Text = StaticUser.users[uniqueNumber].FullName;
                    textBox15.Text = StaticUser.users[uniqueNumber].Email;
                    textBox14.Text = StaticUser.users[uniqueNumber].NumberPhone;
                    textBox13.Text = Convert.ToString(StaticUser.users[uniqueNumber].LevelAccess);

                    //textBox13.Enabled = true;
                    textBox14.Enabled = true;
                    textBox15.Enabled = true;
                    textBox16.Enabled = true;
                    textBox17.Enabled = true;

                    button16.Visible = true;
                    button11.Enabled = false;

                    ChangeUserinExcel(uniqueNumber);
                }
            }
            else if (comboBox3.SelectedIndex == 3)
            {
                if (comboBox5.SelectedIndex == -1)
                {
                    MessageBox.Show("�������� ������������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    textBox17.Text = StaticUser.users[uniqueNumber].FirstName;
                    textBox16.Text = StaticUser.users[uniqueNumber].FullName;
                    textBox15.Text = StaticUser.users[uniqueNumber].Email;
                    textBox14.Text = StaticUser.users[uniqueNumber].NumberPhone;
                    textBox13.Text = Convert.ToString(StaticUser.users[uniqueNumber].LevelAccess);

                    textBox17.Enabled = false;
                    textBox16.Enabled = false;
                    textBox15.Enabled = false;
                    textBox14.Enabled = false;
                    textBox13.Enabled = false;

                    button17.Visible = true;
                    button17.Location = new System.Drawing.Point(430, 330);
                    button11.Enabled = false;
                }
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        void ChangeUserPanel3(int uniqueNumber)
        {
            StaticUser.users[uniqueNumber].FirstName = textBox11.Text;
            StaticUser.users[uniqueNumber].FullName = textBox12.Text;
            StaticUser.users[uniqueNumber].Email = textBox10.Text;
            StaticUser.users[uniqueNumber].NumberPhone = textBox9.Text;
            StaticUser.users[uniqueNumber].Password = textBox8.Text;

            ChangeUserinExcel(uniqueNumber);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"���\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox12.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"�������\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"e-mail\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (textBox9.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"���������� �������\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"���������� ������\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (checkPassword(textBox8.Text) != "Ok")
            {
                MessageBox.Show(checkPassword(textBox8.Text), "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string login = textBox1.Text;
                int uniqueNumber = FindUniqueNumber(login);
                ChangeUserPanel3(uniqueNumber);

                button15.Visible = false;
                button7.Enabled = true;
                comboBox2.Enabled = true;

                comboBox2.SelectedIndex = -1;
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();

                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                textBox11.Enabled = false;
                textBox12.Enabled = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SetDisign(0);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox17.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"���\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox16.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"�������\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox15.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"e-mail\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (textBox14.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"���������� �������\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (textBox13.Text == "")
            {
                MessageBox.Show("�� �� ����� �������� � ���� \"������� �������\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (textBox13.Text == "1")
            {
                MessageBox.Show("�� �� ������ �������� ���������� �� ��������������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int uniqueNumber = comboBox5.SelectedIndex;
                ChangeUserPanel4(uniqueNumber);

                button16.Visible = false;
                button11.Enabled = true;

                comboBox3.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;

                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();

                textBox13.Enabled = false;
                textBox14.Enabled = false;
                textBox15.Enabled = false;
                textBox16.Enabled = false;
                textBox17.Enabled = false;
            }   
        }

        void ChangeUserPanel4(int uniqueNumber)
        {
            StaticUser.users[uniqueNumber].FirstName = textBox17.Text;
            StaticUser.users[uniqueNumber].FullName = textBox16.Text;
            StaticUser.users[uniqueNumber].Email = textBox15.Text;
            StaticUser.users[uniqueNumber].NumberPhone = textBox14.Text;
            StaticUser.users[uniqueNumber].LevelAccess = Convert.ToInt16(textBox13.Text);

            ChangeUserinExcel(uniqueNumber);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int uniqueNumber = comboBox5.SelectedIndex;
            if (StaticUser.users[uniqueNumber].LevelAccess == 1)
            {
                MessageBox.Show("�� �� ������ ������� ��������������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = uniqueNumber; i < StaticUser.counterUsers - 1; i++)
                {
                    StaticUser.users[i].UniqueNumber = StaticUser.users[i + 1].UniqueNumber;
                    StaticUser.users[i].Login = StaticUser.users[i + 1].Login;
                    StaticUser.users[i].Password = StaticUser.users[i + 1].Password;
                    StaticUser.users[i].FirstName = StaticUser.users[i + 1].FirstName;
                    StaticUser.users[i].FullName = StaticUser.users[i + 1].FullName;
                    StaticUser.users[i].Email = StaticUser.users[i + 1].Email;
                    StaticUser.users[i].NumberPhone = StaticUser.users[i + 1].NumberPhone;
                    StaticUser.users[i].LevelAccess = StaticUser.users[i + 1].LevelAccess;
                }

                StaticUser.counterUsers--;

                DeleteUserInExcel(StaticUser.counterUsers, uniqueNumber);
            }

            textBox17.Enabled = true;
            textBox16.Enabled = true;
            textBox15.Enabled = true;
            textBox14.Enabled = true;
            textBox13.Enabled = true;

            button17.Visible = false;
            button11.Enabled = true;

            comboBox3.SelectedIndex = -1;

            comboBox5.Items.Clear();
            for (int i = 0; i < StaticUser.counterUsers; i++)
            {
                comboBox5.Items.Add(i);
            }
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("�������� �������� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox4.SelectedIndex == 0)
                {
                    for (int i = 0; i < StaticUser.counterUsers; i++)
                    {

                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = StaticUser.users[i].UniqueNumber;
                        dataGridView1.Rows[i].Cells[1].Value = StaticUser.users[i].LevelAccess;
                        dataGridView1.Rows[i].Cells[2].Value = StaticUser.users[i].Login;
                        dataGridView1.Rows[i].Cells[3].Value = StaticUser.users[i].Password;
                        dataGridView1.Rows[i].Cells[4].Value = StaticUser.users[i].Email;
                        dataGridView1.Rows[i].Cells[5].Value = StaticUser.users[i].NumberPhone;
                        dataGridView1.Rows[i].Cells[6].Value = StaticUser.users[i].DataRegistration;
                    }
                    comboBox4.SelectedIndex = -1;
                    textBox19.Clear();
                }
                else if (textBox19.Text == "")
                {
                    MessageBox.Show("�� �� ����� �������� � ���� \"������\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (comboBox4.SelectedIndex == 1)
                    {
                        int k = 0;
                        for (int i = 0; i < StaticUser.counterUsers; i++)
                        {
                            if (StaticUser.users[i].Login == textBox19.Text)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[k].Cells[0].Value = StaticUser.users[i].UniqueNumber;
                                dataGridView1.Rows[k].Cells[1].Value = StaticUser.users[i].LevelAccess;
                                dataGridView1.Rows[k].Cells[2].Value = StaticUser.users[i].Login;
                                dataGridView1.Rows[k].Cells[3].Value = StaticUser.users[i].Password;
                                dataGridView1.Rows[k].Cells[4].Value = StaticUser.users[i].Email;
                                dataGridView1.Rows[k].Cells[5].Value = StaticUser.users[i].NumberPhone;
                                dataGridView1.Rows[k].Cells[6].Value = StaticUser.users[i].DataRegistration;
                                k++;
                            }

                        }
                        if (k == 0)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[0].Cells[0].Value = "����� ������������� ���";
                        }
                    }

                    if (comboBox4.SelectedIndex == 2)
                    {
                        int num;
                        bool isNum = int.TryParse(textBox19.Text, out num);
                        if (isNum is true)
                        {
                            int k = 0;
                            for (int i = 0; i < StaticUser.counterUsers; i++)
                            {
                                if (StaticUser.users[i].LevelAccess == num)
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1.Rows[k].Cells[0].Value = StaticUser.users[i].UniqueNumber;
                                    dataGridView1.Rows[k].Cells[1].Value = StaticUser.users[i].LevelAccess;
                                    dataGridView1.Rows[k].Cells[2].Value = StaticUser.users[i].Login;
                                    dataGridView1.Rows[k].Cells[3].Value = StaticUser.users[i].Password;
                                    dataGridView1.Rows[k].Cells[4].Value = StaticUser.users[i].Email;
                                    dataGridView1.Rows[k].Cells[5].Value = StaticUser.users[i].NumberPhone;
                                    dataGridView1.Rows[k].Cells[6].Value = StaticUser.users[i].DataRegistration;
                                    k++;
                                }

                            }
                            if (k == 0)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[0].Cells[0].Value = "����� ������������� ���";
                            }
                        }
                        else
                        {
                            MessageBox.Show("������� ����� ����� � ���� \"������\" ", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (comboBox4.SelectedIndex == 3)
                    {
                        int k = 0;
                        for (int i = 0; i < StaticUser.counterUsers; i++)
                        {
                            if (StaticUser.users[i].Email == textBox19.Text)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[k].Cells[0].Value = StaticUser.users[i].UniqueNumber;
                                dataGridView1.Rows[k].Cells[1].Value = StaticUser.users[i].LevelAccess;
                                dataGridView1.Rows[k].Cells[2].Value = StaticUser.users[i].Login;
                                dataGridView1.Rows[k].Cells[3].Value = StaticUser.users[i].Password;
                                dataGridView1.Rows[k].Cells[4].Value = StaticUser.users[i].Email;
                                dataGridView1.Rows[k].Cells[5].Value = StaticUser.users[i].NumberPhone;
                                dataGridView1.Rows[k].Cells[6].Value = StaticUser.users[i].UniqueNumber;
                                dataGridView1.Rows[k].Cells[7].Value = StaticUser.users[i].DataRegistration;
                                k++;
                            }

                        }
                        if (k == 0)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[0].Cells[0].Value = "����� ������������� ���";
                        }
                    }

                    if (comboBox4.SelectedIndex == 4)
                    {
                        int k = 0;
                        for (int i = 0; i < StaticUser.counterUsers; i++)
                        {
                            if (StaticUser.users[i].NumberPhone == textBox19.Text)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[k].Cells[0].Value = StaticUser.users[i].UniqueNumber;
                                dataGridView1.Rows[k].Cells[1].Value = StaticUser.users[i].LevelAccess;
                                dataGridView1.Rows[k].Cells[2].Value = StaticUser.users[i].Login;
                                dataGridView1.Rows[k].Cells[3].Value = StaticUser.users[i].Password;
                                dataGridView1.Rows[k].Cells[4].Value = StaticUser.users[i].Email;
                                dataGridView1.Rows[k].Cells[5].Value = StaticUser.users[i].NumberPhone;
                                dataGridView1.Rows[k].Cells[6].Value = StaticUser.users[i].UniqueNumber;
                                dataGridView1.Rows[k].Cells[7].Value = StaticUser.users[i].DataRegistration;
                                k++;
                            }

                        }
                        if (k == 0)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[0].Cells[0].Value = "����� ������������� ���";
                        }
                    }
                    comboBox4.SelectedIndex = -1;
                    textBox19.Clear();
                }
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            SetDisign(3);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SetDisign(0);
        }

        void ReadDataExcel()
        {
            Excel.Application excelApp = new Excel.Application();                                  // �������� ������ �� COM-�����
            Excel.Workbook excelBook = excelApp.Workbooks.Open(Environment.CurrentDirectory + "\\Data.xlsx");        // ��������� excel ����
            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            StaticUser.counterUsers = Convert.ToInt16(workSheet.Cells[1, "A"].Text.ToString());

            for (int i = 0; i < StaticUser.counterUsers; i++)
            {
                StaticUser.users[i] = new User();
                StaticUser.users[i].UniqueNumber = Convert.ToInt16(workSheet.Cells[i + 3, "A"].Text.ToString());
                StaticUser.users[i].LevelAccess = Convert.ToInt16(workSheet.Cells[i + 3, "B"].Text.ToString());
                StaticUser.users[i].Login = workSheet.Cells[i + 3, "C"].Text.ToString();
                StaticUser.users[i].Password = workSheet.Cells[i + 3, "D"].Text.ToString();
                StaticUser.users[i].FirstName = workSheet.Cells[i + 3, "E"].Text.ToString();
                StaticUser.users[i].FullName = workSheet.Cells[i + 3, "F"].Text.ToString();
                StaticUser.users[i].Email = workSheet.Cells[i + 3, "G"].Text.ToString();
                StaticUser.users[i].NumberPhone = workSheet.Cells[i + 3, "H"].Text.ToString();
                StaticUser.users[i].DataRegistration = workSheet.Cells[i + 3, "I"].Text.ToString();

            }

            excelApp.Workbooks.Close();
            MessageBox.Show("���������� ������ ������ �������, ������������� � �������: " + StaticUser.counterUsers, "��������", MessageBoxButtons.OK);

        }

        void WriteInExcel(User user, int counterUsers)
        {
            Excel.Application excelApp = new Excel.Application();                   // �������� ������ �� COM-�����
            Excel.Workbook excelBook = excelApp.Workbooks.Open(Environment.CurrentDirectory + "\\Data.xlsx");        // ��������� excel ����
            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            workSheet.Cells[1, "A"] = Convert.ToString(counterUsers);
            workSheet.Cells[counterUsers + 2, "A"] = Convert.ToString(StaticUser.users[counterUsers - 1].UniqueNumber);
            workSheet.Cells[counterUsers + 2, "B"] = Convert.ToString(StaticUser.users[counterUsers - 1].LevelAccess);
            workSheet.Cells[counterUsers + 2, "C"] = Convert.ToString(StaticUser.users[counterUsers - 1].Login);
            workSheet.Cells[counterUsers + 2, "D"] = Convert.ToString(StaticUser.users[counterUsers - 1].Password);
            workSheet.Cells[counterUsers + 2, "E"] = Convert.ToString(StaticUser.users[counterUsers - 1].FirstName);
            workSheet.Cells[counterUsers + 2, "F"] = Convert.ToString(StaticUser.users[counterUsers - 1].FullName);
            workSheet.Cells[counterUsers + 2, "G"] = Convert.ToString(StaticUser.users[counterUsers - 1].Email);
            workSheet.Cells[counterUsers + 2, "H"] = Convert.ToString(StaticUser.users[counterUsers - 1].NumberPhone);
            workSheet.Cells[counterUsers + 2, "I"] = Convert.ToString(StaticUser.users[counterUsers - 1].DataRegistration);

            excelApp.Workbooks.Close();
        }

        void DeleteUserInExcel(int counterUser, int uniqueNumber)
        {
            Excel.Application excelApp = new Excel.Application();                   // �������� ������ �� COM-�����
            Excel.Workbook excelBook = excelApp.Workbooks.Open(Environment.CurrentDirectory + "\\Data.xlsx");       // ��������� excel ����
            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            workSheet.Cells[1, "A"] = Convert.ToString(counterUser);

            for (int i = uniqueNumber; i <= counterUser; i++)
            {
                workSheet.Cells[i + 3, "A"] = i;
                workSheet.Cells[i + 3, "B"] = workSheet.Cells[i + 4, "B"];
                workSheet.Cells[i + 3, "C"] = workSheet.Cells[i + 4, "C"];
                workSheet.Cells[i + 3, "D"] = workSheet.Cells[i + 4, "D"];
                workSheet.Cells[i + 3, "E"] = workSheet.Cells[i + 4, "E"];
                workSheet.Cells[i + 3, "F"] = workSheet.Cells[i + 4, "F"];
                workSheet.Cells[i + 3, "G"] = workSheet.Cells[i + 4, "G"];
                workSheet.Cells[i + 3, "H"] = workSheet.Cells[i + 4, "H"];
                workSheet.Cells[i + 3, "I"] = workSheet.Cells[i + 4, "I"];
            }

            workSheet.Cells[counterUser + 3, "A"].Clear();
            excelApp.Workbooks.Close();
        }

        void ChangeUserinExcel(int uniqueNumber)
        {
            Excel.Application excelApp = new Excel.Application();                   // �������� ������ �� COM-�����
            Excel.Workbook excelBook = excelApp.Workbooks.Open(Environment.CurrentDirectory + "\\Data.xlsx");       // ��������� excel ����
            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            workSheet.Cells[uniqueNumber + 3, "A"] = Convert.ToString(StaticUser.users[uniqueNumber].UniqueNumber);
            workSheet.Cells[uniqueNumber + 3, "B"] = Convert.ToString(StaticUser.users[uniqueNumber].LevelAccess);
            workSheet.Cells[uniqueNumber + 3, "C"] = Convert.ToString(StaticUser.users[uniqueNumber].Login);
            workSheet.Cells[uniqueNumber + 3, "D"] = Convert.ToString(StaticUser.users[uniqueNumber].Password);
            workSheet.Cells[uniqueNumber + 3, "E"] = Convert.ToString(StaticUser.users[uniqueNumber].FirstName);
            workSheet.Cells[uniqueNumber + 3, "F"] = Convert.ToString(StaticUser.users[uniqueNumber].FullName);
            workSheet.Cells[uniqueNumber + 3, "G"] = Convert.ToString(StaticUser.users[uniqueNumber].Email);
            workSheet.Cells[uniqueNumber + 3, "H"] = Convert.ToString(StaticUser.users[uniqueNumber].NumberPhone);
            workSheet.Cells[uniqueNumber + 3, "I"] = Convert.ToString(StaticUser.users[uniqueNumber].DataRegistration);

            //excelBook.SaveAs(@"Data.XLSX");
            excelApp.Workbooks.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SetDisign(4);
        }

        string checkLogin(string login)
        {
            string a = "Ok";
            if (login.Length < 5)
            {
                a = "����� ������ ��������� �� ����� 5 ��������";
            }
            else if (login.Length > 20)
            {
                a = "����� �� ����� ��������� ����� 20 ��������";
            }
            else
            {
                bool b = true;
                foreach (char c in login)
                {
                    if (b == true && ((int)c > 64 && (int)c < 91 || (int)c > 96 && (int)c < 123 || (int)c > 47 && (int)c < 58))
                    {
                        b = true;
                    }
                    else
                    {
                        a = "����� ������ ��������� ������ ����� �������� ��� �������� �����";
                        b = false;
                    }
                }
            }
            return a;
        }

        string checkPassword(string password)
        {
            string a = "Ok";
            if (password.Length < 5)
            {
                a = "������ ������ ��������� �� ����� 5 ��������";
            }
            else if (password.Length > 20)
            {
                a = "������ �� ����� ��������� ����� 20 ��������";
            }
            else
            {
                bool b = true;
                foreach (char c in password)
                {
                    if (b == true && !(c >= '�' && c <= '�' || c >= '�' && c <= '�'))
                    {
                        b = true;
                      
                    }
                    else
                    {
                        a = "������ �� ����� ��������� ����� ���������";
                        b = false;
                    }
                }
            }
            return a;
        }
    }
}