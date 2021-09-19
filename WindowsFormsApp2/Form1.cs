using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
   
    public partial class Form1 : Form
    {
        private
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=contracts;Integrated Security=True; MultipleActiveResultSets = True;";
            string [] cb7;

        // СИСТЕМНОЕ
        private void personsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.personsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.contractsDataSet);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "contractsDataSet.Persons". При необходимости она может быть перемещена или удалена.
            this.personsTableAdapter.Fill(this.contractsDataSet.Persons);

        }


        // Сокрытие TabControl
        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "Сортировать по цене";
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.TabPages.Remove(tabPage12);
            tabControl2.TabPages.Remove(tabPage9);
            tabControl2.TabPages.Remove(tabPage10);
            tabControl2.TabPages.Remove(tabPage3);
            tabControl2.TabPages.Remove(tabPage11);
            tabControl1.TabPages.Remove(tabPage13);
            button4.Enabled = false;
            this.Init();
           


        } 


        //Инициализация всех comboBox
        public void Init()
        {
            //comboBox3
            comboBox3.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("select Objects.adress from Objects");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    string temp = "";
                    while (reader.Read()) // построчно считываем данные
                    {
                        temp = reader.GetValue(0).ToString();
                        comboBox3.Items.Add(temp);
                    }
                    comboBox3.Text = temp;
                }
                command.Connection = connection;
                connection.Dispose();
            }

            //comboBox5
            comboBox5.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int count = 0;
                string[] obj_inf = new string[count];
                string[] obj_inf_t;
                connection.Open();
                string sqlExpression = String.Format("select * from objects");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                int i;
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        count++;
                        obj_inf_t = new string[count];
                        for (i = 0; i < obj_inf_t.Length - 1; i++)
                            obj_inf_t[i] = obj_inf[i];
                        obj_inf_t[count - 1] = reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString() + " " + reader.GetValue(3).ToString() + " ";
                        obj_inf = obj_inf_t;
                    }
                }
                else
                {
                    MessageBox.Show("Нет объектов");
                }
                i = 0;
                while (i < count)
                {
                    String[] words = obj_inf[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    comboBox5.Items.Add(words[0] + " |  " + "Площадь: " + words[1] + "  " + "Стоимость: " + words[2] + "  " + "Адрес: " + words[3]);
                    if (i == 0)
                        comboBox5.Text = words[0] + " |  " + "Площадь: " + words[1] + "  " + "Стоимость: " + words[2] + "  " + "Адрес: " + words[3];
                    i++;
                }
                connection.Dispose();
            }


            comboBox10.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int count = 0;
                string[] obj_inf = new string[count];
                string[] obj_inf_t;
                connection.Open();
                string sqlExpression = String.Format("select * from objects");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                int i;
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        count++;
                        obj_inf_t = new string[count];
                        for (i = 0; i < obj_inf_t.Length - 1; i++)
                            obj_inf_t[i] = obj_inf[i];
                        obj_inf_t[count - 1] = reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString() + " " + reader.GetValue(3).ToString() + " ";
                        obj_inf = obj_inf_t;
                    }
                }
                else
                {
                    MessageBox.Show("Нет объектов");
                }
                i = 0;
                while (i < count)
                {
                    String[] words = obj_inf[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    comboBox10.Items.Add(words[0] + " |  " + "Площадь: " + words[1] + "  " + "Стоимость: " + words[2] + "  " + "Адрес: " + words[3]);
                    if (i == 0)
                        comboBox10.Text = words[0] + " |  " + "Площадь: " + words[1] + "  " + "Стоимость: " + words[2] + "  " + "Адрес: " + words[3];
                    i++;
                }
                connection.Dispose();
            }



            //comboBox2
            comboBox2.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("select Persons.person_name from Persons");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        var temp = reader.GetValue(0).ToString();
                        comboBox2.Items.Add(temp);

                        if (comboBox2.Text.Length == 0)
                        {
                            comboBox2.Text = temp;

                        }

                    }
                }
                command.Connection = connection;
                connection.Dispose();
            }

            //comboBox7
            comboBox7.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int count = 0;
                string[] obj_inf = new string[count];
                string[] obj_inf_t;
                connection.Open();
                string sqlExpression = String.Format("select * from objects");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                int i;
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        count++;
                        obj_inf_t = new string[count];
                        for (i = 0; i < obj_inf_t.Length - 1; i++)
                            obj_inf_t[i] = obj_inf[i];
                        obj_inf_t[count - 1] = reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString() + " " + reader.GetValue(3).ToString() + " ";
                        obj_inf = obj_inf_t;
                    }
                }
                else
                {
                    MessageBox.Show("Нет объектов");
                }
                i = 0;
                while (i < count)
                {
                    String[] words = obj_inf[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    comboBox7.Items.Add(words[0] + " |  " + "Площадь: " + words[1] + "  " + "Стоимость: " + words[2] + "  " + "Адрес: " + words[3]);
                    if (i == 0)
                        comboBox7.Text = words[0] + " |  " + "Площадь: " + words[1] + "  " + "Стоимость: " + words[2] + "  " + "Адрес: " + words[3];
                    i++;
                }
                connection.Dispose();
            }


            //comboBox6
            comboBox6.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int count = 0;
                string[] obj_inf = new string[count];
                string[] obj_inf_t;
                connection.Open();
                string sqlExpression = String.Format("select * from persons");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                int i;
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        count++;
                        obj_inf_t = new string[count];
                        for (i = 0; i < obj_inf_t.Length - 1; i++)
                            obj_inf_t[i] = obj_inf[i];
                        obj_inf_t[count - 1] = reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString() + " " + reader.GetValue(3).ToString() + " ";
                        obj_inf = obj_inf_t;
                    }

                }
                else
                {
                    MessageBox.Show("Нет объектов");
                }
                reader.Close();
                i = 0;
                while (i < count)
                {
                    String[] words = obj_inf[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    command = new SqlCommand(String.Format("select objects.adress from objects where objects.object_id={0}", words[1]), connection);
                    reader = command.ExecuteReader();
                    reader.Read();
                    comboBox6.Items.Add(words[0] + " |  " + "Адрес объекта: " + reader.GetValue(0) + "  " + "Имя: " + words[2] + "  " + "Номер паспорта: " + words[3]);
                    if (i == 0)
                        comboBox6.Text = words[0] + " |  " + "Адрес объекта: " + reader.GetValue(0) + "  " + "Имя: " + words[2] + "  " + "Номер паспорта: " + words[3];
                    i++;
                }
                connection.Dispose();
            }


            //comboBox4
            comboBox4.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int count = 0;
                string[] obj_inf = new string[count];
                string[] obj_inf_t;
                connection.Open();
                string sqlExpression = String.Format("select * from persons");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                int i;
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        count++;
                        obj_inf_t = new string[count];
                        for (i = 0; i < obj_inf_t.Length - 1; i++)
                            obj_inf_t[i] = obj_inf[i];
                        obj_inf_t[count - 1] = reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString() + " " + reader.GetValue(3).ToString() + " ";
                        obj_inf = obj_inf_t;
                    }

                }
                else
                {
                    MessageBox.Show("Нет объектов");
                }
                reader.Close();
                i = 0;
                while (i < count)
                {
                    String[] words = obj_inf[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    command = new SqlCommand(String.Format("select objects.adress from objects where objects.object_id={0}", words[1]), connection);
                    reader = command.ExecuteReader();
                    reader.Read();
                    comboBox4.Items.Add(words[0] + " |  " + "Адрес объекта: " + reader.GetValue(0) + "  " + "Имя: " + words[2] + "  " + "Номер паспорта: " + words[3]);
                    if (i == 0)
                        comboBox4.Text = words[0] + " |  " + "Адрес объекта: " + reader.GetValue(0) + "  " + "Имя: " + words[2] + "  " + "Номер паспорта: " + words[3];
                    i++;
                }
                connection.Dispose();
            }


            //comboBox8
            comboBox8.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int count = 0;
                string[] obj_inf = new string[count];
                string[] obj_inf_t;
                connection.Open();
                string sqlExpression = String.Format("select * from objects");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                int i;
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        count++;
                        obj_inf_t = new string[count];
                        for (i = 0; i < obj_inf_t.Length - 1; i++)
                            obj_inf_t[i] = obj_inf[i];
                        obj_inf_t[count - 1] = reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString() + " " + reader.GetValue(3).ToString() + " ";
                        obj_inf = obj_inf_t;
                    }
                }
                else
                {
                    MessageBox.Show("Нет объектов");
                }
                i = 0;
                while (i < count)
                {
                    String[] words = obj_inf[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    comboBox8.Items.Add(words[0] + " |  " + "Адрес: " + words[3] + "  " + "Площадь: " + words[1]);
                    if (i == 0)
                        comboBox8.Text = words[0] + " |  " + "Адрес: " + words[3] + "  " + "Площадь: " + words[1];
                    i++;
                }
                connection.Dispose();
            }
            //comboBox9
            comboBox9.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("select Persons.person_id, Persons.person_name from Persons");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        var temp = reader.GetValue(0).ToString() + " | " + reader.GetValue(1).ToString();
                        comboBox9.Items.Add(temp);

                        if (comboBox9.Text.Length == 0)
                        {
                            comboBox9.Text = temp;

                        }

                    }
                }
                command.Connection = connection;
                connection.Dispose();
            }
            //comboBox11
            comboBox11.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("select contracts.contract_id, Persons.person_name, objects.adress, objects.cost from Contracts join Persons on Contracts.contract_person_id=person_id join Objects on contracts.contact_object_id=object_id");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        var temp = reader.GetValue(0).ToString() + " |   " + reader.GetValue(1).ToString() + "   " + reader.GetValue(2).ToString() + "   " + reader.GetValue(3).ToString();
                        comboBox11.Items.Add(temp);

                        if (comboBox11.Text.Length == 0)
                        {
                            comboBox11.Text = temp;

                        }

                    }
                }
                command.Connection = connection;
                connection.Dispose();
            }
        }

        //Кнопка принудительного обновления данных
        private void button36_Click_1(object sender, EventArgs e)
        {
            this.Init();
        }

        // ОКНО ЛОГИНА
        private void button2_Click(object sender, EventArgs e)
        {
            string username=richTextBox1.Text;
            string password=textBox1.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("SELECT * FROM [Rights] WHERE [Login] = ('{0}') and [Password] = ('{1}')", username, password);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object _rights= reader.GetValue(3);
                        int rights = int.Parse(_rights.ToString());
                        //ОПРЕДЕЛЕНИЕ КАКИЕ ВКЛАДКИ ДОЛЖНЫ БЫТЬ ДОСТУПНЫ ПОЛЬЗОВАТЕЛЯМ
                        switch (rights)
                        {
                            case 1:
                                if (tabControl1.TabPages.IndexOf(tabPage4) == -1)
                                    tabControl1.TabPages.Insert(1, tabPage4);
                                if (tabControl1.TabPages.IndexOf(tabPage1) != -1)
                                    tabControl1.TabPages.Remove(tabPage1);
                                break;
                            case 2:
                                if (tabControl1.TabPages.IndexOf(tabPage4) == -1)
                                    tabControl1.TabPages.Insert(1, tabPage4);
                                if (tabControl1.TabPages.IndexOf(tabPage5) == -1)
                                    tabControl1.TabPages.Insert(1, tabPage5);
                                if (tabControl1.TabPages.IndexOf(tabPage1) != -1)
                                    tabControl1.TabPages.Remove(tabPage1);
                                break;
                            case 3:
                                if (tabControl1.TabPages.IndexOf(tabPage2) == -1)
                                    tabControl1.TabPages.Insert(1, tabPage2);
                                if (tabControl1.TabPages.IndexOf(tabPage4) == -1)
                                    tabControl1.TabPages.Insert(1, tabPage4);
                                if (tabControl1.TabPages.IndexOf(tabPage5) == -1)
                                    tabControl1.TabPages.Insert(1, tabPage5);
                                if (tabControl1.TabPages.IndexOf(tabPage1) != -1)
                                    tabControl1.TabPages.Remove(tabPage1);
                                break;
                        }
                        button4.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                command.Connection = connection;
                connection.Dispose();
            }
           


        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.IndexOf(tabPage2) != -1)
                tabControl1.TabPages.Remove(tabPage2);
            if (tabControl1.TabPages.IndexOf(tabPage4) != -1)
                tabControl1.TabPages.Remove(tabPage4);
            if (tabControl1.TabPages.IndexOf(tabPage5) != -1)
                tabControl1.TabPages.Remove(tabPage5);
            if (tabControl1.TabPages.IndexOf(tabPage8) != -1)
                tabControl1.TabPages.Remove(tabPage8);
            if (tabControl1.TabPages.IndexOf(tabPage12) != -1)
                    tabControl1.TabPages.Remove(tabPage12);
            if (tabControl1.TabPages.IndexOf(tabPage13) != -1)
                tabControl1.TabPages.Remove(tabPage13);
            if (tabControl1.TabPages.IndexOf(tabPage1) == -1)
                tabControl1.TabPages.Insert(0, tabPage1);
            
            button4.Enabled = false;
            richTextBox1.Text = "";
            textBox1.Text = "";
        }









        //2a
        //8
        //МНОГОТАБЛИЧНЫЙ ЗАПРОС С CASE ВЫРАЖЕНИЕМ
        private void button1_Click(object sender, EventArgs e)
        {
            var date1 = dateTimePicker1.Value.ToShortDateString();
            var date2 = dateTimePicker2.Value.ToShortDateString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("SELECT Objects.cost, Persons.person_name, FORMAT(Contracts_Info.registration_date, 'dd/MM/yyyy', 'en-US'), case registration_date WHEN (SELECT MAX(registration_date) FROM Contracts_Info) then 'Последний подписанный' else '' END Комментарий from Contracts join Contracts_Info on Contracts_Info.contract_id=Contracts.contract_id join Persons on Persons.person_id=Contracts.contract_person_id join Objects on Objects.object_id=Contracts.contact_object_id WHERE Contracts_Info.registration_date>'{0}' and Contracts_Info.registration_date<'{1}' Group BY Objects.cost, Persons.person_name, Contracts_Info.registration_date", date1, date2);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    string temp="";
                    temp=temp+string.Format("{0,20}{1,20}{2,20}{3,20}\n\n", "Стоимость", "Имя владельца", "Дата подписания", "Комментарий");
                    while (reader.Read()) // построчно считываем данные
                    {
                        object cost = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object date = reader.GetValue(2);
                        var tempdate = date.ToString();
                        object comm = reader.GetValue(3);
                        temp = temp + string.Format("{0,20}{1,20}{2,20}{3,35} \n\n\n", cost, name, tempdate, comm);
                    }
                    richTextBox2.Text = temp;
                }
                else
                {
                    MessageBox.Show("За выбранный период контрактов не найдено");
                }
                
                command.Connection = connection;
                connection.Dispose();
            }
        }
       




        //2b
        private void button5_Click_1(object sender, EventArgs e)
        {
            string order;
            string selectedState = comboBox1.SelectedItem.ToString();
            if (selectedState.Equals("Сортировать по цене"))
                order = "cost";
            else
                order = "area";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("select Objects.cost, Objects.area, Objects.adress, Persons.person_name from Persons join Objects on Objects.object_id=Persons.object_own_id  ORDER BY {0} DESC", order);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    string temp = "";
                    temp = temp + string.Format("{0,20}{1,20}{2,20}{3,20}\n\n", "Стоимость", "Площадь", "Местонахождение", "Имя владельца");
                    while (reader.Read()) // построчно считываем данные
                    {
                        object cost = reader.GetValue(0);
                        object area = reader.GetValue(1);
                        object adress = reader.GetValue(2);
                        object name = reader.GetValue(3);
                        temp = temp + string.Format("{0,20}{1,20}{2,20}{3,35} \n\n\n",cost, area, adress, name);
                    }
                    richTextBox2.Text = temp;
                }
                else
                {
                    MessageBox.Show("Нет объектов");
                }

                command.Connection = connection;
                connection.Dispose();
            }
        }
        private void button5_Click_1(object sender, EventArgs e, string s)
        {
            string order;
            string selectedState = comboBox1.SelectedItem.ToString();
            if (selectedState.Equals("Сортировать по цене"))
                order = "cost";
            else
                order = "area";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("select Objects.cost, Objects.area, Objects.adress, Persons.person_name from Persons join Objects on Objects.object_id=Persons.object_own_id  ORDER BY {0} {1}", order, s);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    string temp = "";
                    temp = temp + string.Format("{0,20}{1,20}{2,20}{3,20}\n\n", "Стоимость", "Площадь", "Местонахождение", "Имя владельца");
                    while (reader.Read()) // построчно считываем данные
                    {
                        object cost = reader.GetValue(0);
                        object area = reader.GetValue(1);
                        object adress = reader.GetValue(2);
                        object name = reader.GetValue(3);
                        temp = temp + string.Format("{0,20}{1,20}{2,20}{3,35} \n\n\n", cost, area, adress, name);
                    }
                    richTextBox2.Text = temp;
                }
                else
                {
                    MessageBox.Show("Нет объектов");
                }

                command.Connection = connection;
                connection.Dispose();
            }
        }
        
        
        //ВЫБОР ПОРЯДКА СОРТИРОВКИ В ЗАПРОСЕ ВЫШЕ
        private void button7_Click(object sender, EventArgs e)
        {
            button5_Click_1(this, e, "DESC");

        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            button5_Click_1(this, e, "ASC");
        }






      



        


        //6
        //2e
        //ВВОД ОБЪЕКТОВ
        private void button12_Click(object sender, EventArgs e)
        {
            int richtextbox4;
            int richtextbox5;
            int Count = comboBox7.Items.Count;
            if (!Int32.TryParse(richTextBox4.Text, out richtextbox4))
                MessageBox.Show("Требуется числовое значение в поле 'Площадь'"); 
            if (!Int32.TryParse(richTextBox5.Text, out richtextbox5))
                MessageBox.Show("Требуется числовое значение в поле 'Стоимость'");

            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlExpression = String.Format("EXECUTE add_objects @area={0}, @cost={1}, @address='{2}'", Int32.Parse(richTextBox4.Text), Int32.Parse(richTextBox5.Text), richTextBox6.Text);
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    command.Connection = connection;
                    connection.Dispose();
                }
                this.Init();
                if (comboBox7.Items.Count==Count)
                {
                    MessageBox.Show("Объект по данному адресу уже находится в базе");
                }
                else
                {
                    MessageBox.Show("Запись успешно добавлена");
                    this.Init();
                    richTextBox4.Text = "";
                    richTextBox5.Text = "";
                    richTextBox6.Text = "";
                }
                

            }
            catch
            {
                
            }
            
        }




        //ВВОД ЮР.ЛИЦ
        private void button13_Click(object sender, EventArgs e)
        {
            string b="";
            long temp;
            if(!Int64.TryParse(richTextBox7.Text, out temp))
                MessageBox.Show("Только числовые значения в поле 'номер паспорта'");
            if(richTextBox7.Text.Length!=10)
                MessageBox.Show("10 цифр в номере паспорта");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                connection.Open();
                string SqlExpression = String.Format("select Objects.object_id from Objects where Objects.adress='{0}'", comboBox3.Text);
                SqlCommand command = new SqlCommand(SqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        b = reader.GetValue(0).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Нет объектов");
                }

                command.Connection = connection;
                connection.Dispose();
            }
            
            try {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlExpression = String.Format("insert into Persons values({0}, '{1}', {2})", b, richTextBox8.Text, temp);
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    command.Connection = connection;
                    connection.Dispose();
                }
                MessageBox.Show("Запись успешно добавлена");
                this.Init();
                richTextBox4.Text = "";
                richTextBox5.Text = "";
                richTextBox6.Text = "";
            }
            catch { }
            
        }

        


        //УДАЛЕНИЕ ОБЪЕКТА
        private void button20_Click(object sender, EventArgs e)
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string[] words = comboBox5.Text.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string sqlExpression = String.Format("EXECUTE  delete_objects @id={0}", words[0]);
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    command.Connection = connection;
                    connection.Dispose();
                }
                MessageBox.Show("Собственность удалена");
                this.Init();
            }
            catch { MessageBox.Show("Данный объект содержится в других таблицах"); }
            
        }



        //УДАЛЕНИЕ ЮР ЛИЦА
        private void button29_Click(object sender, EventArgs e)
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string[] words = comboBox4.Text.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string sqlExpression = String.Format("EXECUTE  delete_person @id={0}", words[0]);
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    command.Connection = connection;
                    connection.Dispose();
                    MessageBox.Show("Юр.Лицо удалено");
                    this.Init();
                }
            }
            catch { MessageBox.Show("Данный объект содержится в других таблицах"); }
        }





        //ОБНОВЛЕНИЕ ОБЪЕКТА
        private void button28_Click(object sender, EventArgs e)
        {
            String[] words = comboBox7.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (textBox7.Text.Length == 0)
            {
                textBox7.Text = words[3];
            }
            if (textBox6.Text.Length == 0)
            {
                textBox6.Text = words[5];
            }
            if (textBox5.Text.Length == 0)
            {
                textBox5.Text = words[7];
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlExpression = String.Format("execute update_objects @id={0}, @area={1}, @cost={2}, @address = '{3}'", words[0], textBox7.Text, textBox6.Text, textBox5.Text);
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    command.Connection = connection;
                    connection.Dispose();
                }
                MessageBox.Show("Данные обновлены");
                textBox7.Text = "";
                textBox6.Text = "";
                textBox5.Text = "";
                this.Init();
            }
            catch { }
        }



        //ОБНОВЛЕНИЕ ЮР ЛИЦА
        private void button27_Click(object sender, EventArgs e)
        {
            long temp = -1;

            String[] words = comboBox6.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); 
            String[] words1 = comboBox8.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (textBox3.Text.Length == 0)
            {
                textBox3.Text = words[6];
            }
            if (textBox4.Text.Length == 0)
            {
                textBox4.Text = words[9];
            }
            if (!Int64.TryParse(textBox4.Text, out temp))
                MessageBox.Show("Только числовые значения в поле 'номер паспорта'");
            if (textBox4.Text.Length != 10)
                MessageBox.Show("10 цифр в номере паспорта");
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlExpression = String.Format("execute update_persons @id={0}, @id_obj={1}, @name='{2}', @passport = {3}", words[0], words1[0], textBox3.Text, temp);
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    command.Connection = connection;
                    connection.Dispose();
                }
                MessageBox.Show("Данные обновлены");
                this.Init();
            }
            catch { }
        }



        //ДОБАВЛЕНИЕ ДОГОВОРА
        private void button32_Click(object sender, EventArgs e)
        {
            String[] words = comboBox9.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            String[] words1 = comboBox10.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var date1 = dateTimePicker3.Value.ToShortDateString();
            var date2 = dateTimePicker4.Value.ToShortDateString();
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Поле не может быть пустым");
            }
            else
            {
                
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sqlExpression = String.Format("INSERT INTO contracts VALUES({0},{1},'{2}','{3}')", words[0], words1[0], date1, date2);
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        command.Connection = connection;
                        connection.Dispose();
                    }
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sqlExpression = String.Format("INSERT INTO Contracts_Info VALUES(IDENT_CURRENT('Contracts') , CURRENT_TIMESTAMP,'{0}')", textBox2.Text);
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        command.Connection = connection;
                        connection.Dispose();
                    }
                    MessageBox.Show("Договор добавлен");
                    this.Init();
                }
                catch { }


            }


        }




        //УДАЛЕНИЕ ДОГОВОРА
        private void button35_Click(object sender, EventArgs e)
        {
            String[] words = comboBox11.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlExpression = String.Format("delete from Contracts_Info where Contracts_Info.contract_id={0} delete from Contracts where Contracts.contract_id={0}", words[0]);
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    command.Connection = connection;
                    connection.Dispose();
                }
                MessageBox.Show("Договор удалён");
                comboBox11.Text="";
                this.Init();
            }
            catch { }

        }



        //2d
        //8
        //Отобразить юр. лиц с более чем одним объектом
        private void button30_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("SELECT* from more_than_one_object()");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    string temp = "";
                    temp = temp + string.Format("{0,20}{1,20}\n\n", "Имя", "Количество объектов");
                    while (reader.Read())
                    {
                        object name = reader.GetValue(0);
                        object cost = reader.GetValue(1);
                        temp = temp + string.Format("{0,20}{1,20}\n\n\n", name, cost);
                    }
                    richTextBox3.Text = temp;
                }
                else
                {
                    MessageBox.Show("Таких Юр. Лиц нет ");
                }

                command.Connection = connection;
                connection.Dispose();
            }
        }




        //Отобразить самый  дорогой объект
        private void button31_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("execute most_expensive");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    string temp = "";
                    temp = temp + string.Format("{0,20}{1,20}{2,20}\n\n", "Стоимость", "Адрес", "Площадь");
                    while (reader.Read())
                    {
                        object cost = reader.GetValue(0);
                        object adress = reader.GetValue(1);
                        object area = reader.GetValue(2);
                        temp = temp + string.Format("{0,20}{1,20}{2,20}\n\n", cost, adress, area);
                    }
                    richTextBox3.Text = temp;
                }
                else
                {
                    MessageBox.Show("Объектов нет");
                }

                command.Connection = connection;
                connection.Dispose();
            }
        }

        
        
        
 
       
   





        //Отобразить самый дорогой объект
        private void button36_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("execute most_expensive");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    string temp = "";
                    temp = temp + string.Format("{0,20}{1,20}{2,20}\n\n", "Стоимость", "Адрес", "Площадь");
                    while (reader.Read())
                    {
                        object cost = reader.GetValue(0);
                        object adress = reader.GetValue(1);
                        object area = reader.GetValue(2);
                        temp = temp + string.Format("{0,20}{1,20}{2,20}\n\n", cost, adress, area);
                    }
                    richTextBox3.Text = temp;
                }
                else
                {
                    MessageBox.Show("Объектов нет");
                }

                command.Connection = connection;
                connection.Dispose();
            }
        }


        //2c
        //НЕКОРР WHERE
        private void button11_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("select  Objects.adress, Objects.cost, Objects.area,  FORMAT(Contracts.end_date, 'dd/MM/yyyy', 'en-US') from Contracts join Persons on Persons.person_id=Contracts.contract_person_id join Objects on Objects.object_id=Contracts.contact_object_id where( Contracts.contract_person_id=(select Persons.person_id from Persons where Persons.person_name='{0}') and (Contracts.end_date>CURRENT_TIMESTAMP))", comboBox2.SelectedItem.ToString());
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    string temp = "";
                    temp = temp + string.Format("{0,20}{1,20}{2,20}{3,28}\n\n", "Адрес", "Стоимость", "Площадь", "Дата истечения контракта");
                    while (reader.Read()) // построчно считываем данные
                    {
                        object adress = reader.GetValue(0);
                        object cost = reader.GetValue(1);
                        object area = reader.GetValue(2);
                        object date = reader.GetValue(3);
                        var tempdate = date.ToString();
                        temp = temp + string.Format("{0,20}{1,20}{2,20}{3,35} \n\n\n", adress, cost, area, tempdate);
                    }
                    richTextBox3.Text = temp;
                }
                else
                {
                    MessageBox.Show("Нет контрактов");
                    richTextBox3.Text = "";
                }

                command.Connection = connection;
                connection.Dispose();
            }
        }


        //  2c
        //НЕКОРР SELECT
        private void button37_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("select Objects.adress,(Objects.cost-(SELECT AVG(Objects.cost) from Objects)) as [CURR-AVG], Contracts.end_date as end_date from Objects join Contracts on Objects.object_id=Contracts.contact_object_id");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    string temp = "";
                    temp = temp + string.Format("{0,20}{1,40}\n\n", "Адрес", "Разница со средней ценой");
                    while (reader.Read())
                    {
                        object name = reader.GetValue(0);
                        object cost = reader.GetValue(1);
                        temp = temp + string.Format("{0,20}{1,35}\n\n\n", name, cost);
                    }
                    richTextBox9.Text = temp;
                }
                else
                {
                    MessageBox.Show("Список объектов пуст");
                }

                command.Connection = connection;
                connection.Dispose();
            }
        }


        //  2c
        //НЕКОРР FROM
        private void button9_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("select MAX(my_count) as count from (select  COUNT(*) as my_count from Contracts group by contract_person_id)tmp_d;");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        richTextBox9.Text = String.Format("Макс. количество контрактов с одним человеком = {0}", reader.GetValue(0));
                    }

                }
                else
                {
                    MessageBox.Show("Список объектов пуст");
                }

                command.Connection = connection;
                connection.Dispose();
            }
        }


        //  2c
        //КОРР WHERE
        private void button41_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("select adress, cost, area from Objects where Objects.object_id not in (SELECT contact_object_id FROM Contracts where Contracts.contact_object_id=Objects.object_id)");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    string temp = "";
                    temp = temp + string.Format("{0,20}{1,40}{2,40}\n\n", "Адрес", "Стоимость", "Площадь");
                    while (reader.Read())
                    {
                        object name = reader.GetValue(0);
                        object cost = reader.GetValue(1);
                        object area = reader.GetValue(2);
                        temp = temp + string.Format("{0,20}{1,35}{2, 30}\n\n\n", name, cost, area);
                    }
                    richTextBox9.Text = temp;
                }
                else
                {
                    MessageBox.Show("Список объектов пуст");
                }

                command.Connection = connection;
                connection.Dispose();
            }
        }



        //  2c
        //КОРР SELECT
        private void button42_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("select adress, (select Contracts.end_date from Contracts where Contracts.contact_object_id=Objects.object_id) as end_date from Objects ");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    string temp = "";
                    temp = temp + string.Format("{0,20}{1,40}\n\n", "Адрес", "Дата истечения");
                    while (reader.Read())
                    {
                        object name = reader.GetValue(0);
                        object cost = reader.GetValue(1);
                        if (cost.ToString().Length == 0)
                            cost = "Нет контракта";
                        temp = temp + string.Format("{0,20}{1,35}\n\n\n", name, cost);
                    }
                    richTextBox9.Text = temp;
                }
                else
                {
                    MessageBox.Show("Список объектов пуст");
                }

                command.Connection = connection;
                connection.Dispose();
            }
        }



        //  2c
        //КОРР WHERE
        private void button43_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("SELECT * FROM(SELECT  adress, cost, area from objects WHERE object_id in (SELECT contracts.contact_object_id  FROM Contracts)) tmp_t;");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    string temp = "";
                    temp = temp + string.Format("{0,20}{1,40}{2,30}\n\n", "Адрес", "стоимость", "площадь");
                    while (reader.Read())
                    {
                        object name = reader.GetValue(0);
                        object cost = reader.GetValue(1);
                        object area = reader.GetValue(2);
                        if (cost.ToString().Length == 0)
                            cost = "Нет контракта";
                        temp = temp + string.Format("{0,20}{1,35}{2,35}\n\n\n", name, cost, area);
                    }
                    richTextBox9.Text = temp;
                }
                else
                {
                    MessageBox.Show("Список объектов пуст");
                }

                command.Connection = connection;
                connection.Dispose();
            }
        }







        //7
        //ОБНОВЛЕНИЕ ПРОСРОЧЕННЫХ КОНТРАКТОВ
        private void button38_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("cursorl");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                command.Connection = connection;
                connection.Dispose();
                MessageBox.Show("Контракты продлены");
            }
        }

    




     













        //ПЕРЕКЛЮЧЕНИЯ МЕЖДУ ВКЛАДКАМИ ДОБАВЛЕНИЕ/УДАЛЕНИЕ/ИЗМЕНЕНИЕ
        private void button8_Click(object sender, EventArgs e)
        {

            tabControl1.TabPages.Insert(tabControl1.TabPages.IndexOf(tabPage4), tabPage8);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.SelectedTab = tabPage8;

        }
        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(tabControl1.TabPages.IndexOf(tabPage8), tabPage4);
            tabControl1.SelectedTab = tabPage4;
            tabControl1.TabPages.Remove(tabPage8);

        }
        private void button18_Click(object sender, EventArgs e)
        {
            tabControl2.TabPages.Insert(tabControl2.TabPages.IndexOf(tabPage7), tabPage10);
            tabControl2.TabPages.Remove(tabPage7);
            tabControl2.SelectedTab = tabPage10;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            tabControl2.TabPages.Insert(tabControl2.TabPages.IndexOf(tabPage6), tabPage9);
            tabControl2.TabPages.Remove(tabPage6);
            tabControl2.SelectedTab = tabPage9;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            tabControl2.TabPages.Insert(tabControl2.TabPages.IndexOf(tabPage9), tabPage6);
            tabControl2.TabPages.Remove(tabPage9);
            tabControl2.SelectedTab = tabPage6;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            tabControl2.TabPages.Insert(tabControl2.TabPages.IndexOf(tabPage6), tabPage3);
            tabControl2.TabPages.Remove(tabPage6);
            tabControl2.SelectedTab = tabPage3;
        }
        private void button24_Click(object sender, EventArgs e)
        {
            tabControl2.TabPages.Insert(tabControl2.TabPages.IndexOf(tabPage3), tabPage6);
            tabControl2.TabPages.Remove(tabPage3);
            tabControl2.SelectedTab = tabPage6;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            tabControl2.TabPages.Insert(tabControl2.TabPages.IndexOf(tabPage9), tabPage3);
            tabControl2.TabPages.Remove(tabPage9);
            tabControl2.SelectedTab = tabPage3;
        }
        private void button21_Click(object sender, EventArgs e)
        {
            tabControl2.TabPages.Insert(tabControl2.TabPages.IndexOf(tabPage10), tabPage11);
            tabControl2.TabPages.Remove(tabPage10);
            tabControl2.SelectedTab = tabPage11;
        }
        private void button26_Click(object sender, EventArgs e)
        {
            tabControl2.TabPages.Insert(tabControl2.TabPages.IndexOf(tabPage11), tabPage7);
            tabControl2.TabPages.Remove(tabPage11);
            tabControl2.SelectedTab = tabPage7;
        }
        private void button25_Click(object sender, EventArgs e)
        {
            tabControl2.TabPages.Insert(tabControl2.TabPages.IndexOf(tabPage11), tabPage10);
            tabControl2.TabPages.Remove(tabPage11);
            tabControl2.SelectedTab = tabPage10;
        }
        private void button23_Click(object sender, EventArgs e)
        {
            tabControl2.TabPages.Insert(tabControl2.TabPages.IndexOf(tabPage3), tabPage9);
            tabControl2.TabPages.Remove(tabPage3);
            tabControl2.SelectedTab = tabPage9;
        }
        private void button19_Click(object sender, EventArgs e)
        {
            tabControl2.TabPages.Insert(tabControl2.TabPages.IndexOf(tabPage7), tabPage11);
            tabControl2.TabPages.Remove(tabPage7);
            tabControl2.SelectedTab = tabPage11;
        }
        private void button22_Click(object sender, EventArgs e)
        {
            tabControl2.TabPages.Insert(tabControl2.TabPages.IndexOf(tabPage10), tabPage7);
            tabControl2.TabPages.Remove(tabPage10);
            tabControl2.SelectedTab = tabPage7;
        }
        private void button33_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(tabControl1.TabPages.IndexOf(tabPage5), tabPage12);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.SelectedTab = tabPage12;
        }
        private void button34_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(tabControl1.TabPages.IndexOf(tabPage12), tabPage5);
            tabControl1.TabPages.Remove(tabPage12);
            tabControl1.SelectedTab = tabPage5;
        }

        private void button40_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(tabControl1.TabPages.IndexOf(tabPage8), tabPage13);
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.SelectedTab = tabPage13;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(tabControl1.TabPages.IndexOf(tabPage13), tabPage8);
            tabControl1.TabPages.Remove(tabPage13);
            tabControl1.SelectedTab = tabPage8;
        }



































        //ПУСТЫЕ ФУНКЦИИ
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        } 
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        { }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void personsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        private void tabPage6_Click(object sender, EventArgs e)
        {


        }
        private void button9_Click(object sender, EventArgs e)
        {

        }
        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void tabPage6_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void tabControl2_Click(object sender, EventArgs e)
        {

        }
        private void tabPage6_Enter(object sender, EventArgs e)
        {

        }
        private void richTextBox8_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

            }
        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
   
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
   
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    }
}

