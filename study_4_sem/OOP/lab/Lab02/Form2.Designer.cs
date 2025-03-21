namespace Lab02
{
    partial class Form2 : System.Windows.Forms.Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.cmbSpecialization = new System.Windows.Forms.ComboBox();
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.trackCourse = new System.Windows.Forms.TrackBar();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblCourseValue = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.numAverageGrade = new System.Windows.Forms.NumericUpDown();
            this.lblAverageGrade = new System.Windows.Forms.Label();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.lblGender = new System.Windows.Forms.Label();
            this.grpAddress = new System.Windows.Forms.GroupBox();
            this.txtApartment = new System.Windows.Forms.TextBox();
            this.lblApartment = new System.Windows.Forms.Label();
            this.txtHouse = new System.Windows.Forms.TextBox();
            this.lblHouse = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.mtxtPostalCode = new System.Windows.Forms.MaskedTextBox();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.grpWorkPlace = new System.Windows.Forms.GroupBox();
            this.numSalary = new System.Windows.Forms.NumericUpDown();
            this.lblSalary = new System.Windows.Forms.Label();
            this.numExperience = new System.Windows.Forms.NumericUpDown();
            this.lblExperience = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.btnSaveJson = new System.Windows.Forms.Button();
            this.btnLoadJson = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackCourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAverageGrade)).BeginInit();
            this.grpAddress.SuspendLayout();
            this.grpWorkPlace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExperience)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFullName.Location = new System.Drawing.Point(16, 60);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(400, 26);
            this.txtFullName.TabIndex = 30;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Location = new System.Drawing.Point(16, 40);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(41, 16);
            this.lblFullName.TabIndex = 21;
            this.lblFullName.Text = "ФИО:";
            this.lblFullName.Click += new System.EventHandler(this.lblFullName_Click);
            // 
            // cmbSpecialization
            // 
            this.cmbSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialization.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbSpecialization.FormattingEnabled = true;
            this.cmbSpecialization.Items.AddRange(new object[] {
            "Программирование",
            "Дизайн",
            "Маркетинг",
            "Менеджмент"});
            this.cmbSpecialization.Location = new System.Drawing.Point(16, 120);
            this.cmbSpecialization.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSpecialization.Name = "cmbSpecialization";
            this.cmbSpecialization.Size = new System.Drawing.Size(400, 28);
            this.cmbSpecialization.TabIndex = 28;
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.BackColor = System.Drawing.Color.Transparent;
            this.lblSpecialization.Location = new System.Drawing.Point(16, 100);
            this.lblSpecialization.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(111, 16);
            this.lblSpecialization.TabIndex = 17;
            this.lblSpecialization.Text = "Специальность:";
            this.lblSpecialization.Click += new System.EventHandler(this.lblSpecialization_Click);
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpBirthDate.Location = new System.Drawing.Point(455, 217);
            this.dtpBirthDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(227, 26);
            this.dtpBirthDate.TabIndex = 27;
            this.dtpBirthDate.ValueChanged += new System.EventHandler(this.dtpBirthDate_ValueChanged);
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.BackColor = System.Drawing.Color.Transparent;
            this.lblBirthDate.Location = new System.Drawing.Point(452, 197);
            this.lblBirthDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(109, 16);
            this.lblBirthDate.TabIndex = 15;
            this.lblBirthDate.Text = "Дата рождения:";
            // 
            // trackCourse
            // 
            this.trackCourse.Location = new System.Drawing.Point(16, 187);
            this.trackCourse.Maximum = 4;
            this.trackCourse.Minimum = 1;
            this.trackCourse.Name = "trackCourse";
            this.trackCourse.Size = new System.Drawing.Size(182, 56);
            this.trackCourse.TabIndex = 26;
            this.trackCourse.Value = 1;
            this.trackCourse.Scroll += new System.EventHandler(this.trackCourse_Scroll);
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.BackColor = System.Drawing.Color.Transparent;
            this.lblCourse.Location = new System.Drawing.Point(16, 166);
            this.lblCourse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(41, 16);
            this.lblCourse.TabIndex = 13;
            this.lblCourse.Text = "Курс:";
            // 
            // lblCourseValue
            // 
            this.lblCourseValue.AutoSize = true;
            this.lblCourseValue.BackColor = System.Drawing.Color.Transparent;
            this.lblCourseValue.Location = new System.Drawing.Point(202, 187);
            this.lblCourseValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCourseValue.Name = "lblCourseValue";
            this.lblCourseValue.Size = new System.Drawing.Size(14, 16);
            this.lblCourseValue.TabIndex = 14;
            this.lblCourseValue.Text = "1";
            // 
            // txtGroup
            // 
            this.txtGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtGroup.Location = new System.Drawing.Point(16, 261);
            this.txtGroup.Margin = new System.Windows.Forms.Padding(4);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(182, 26);
            this.txtGroup.TabIndex = 25;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblGroup.Location = new System.Drawing.Point(16, 241);
            this.lblGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(57, 16);
            this.lblGroup.TabIndex = 11;
            this.lblGroup.Text = "Группа:";
            // 
            // numAverageGrade
            // 
            this.numAverageGrade.DecimalPlaces = 1;
            this.numAverageGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numAverageGrade.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAverageGrade.Location = new System.Drawing.Point(16, 311);
            this.numAverageGrade.Margin = new System.Windows.Forms.Padding(4);
            this.numAverageGrade.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAverageGrade.Name = "numAverageGrade";
            this.numAverageGrade.Size = new System.Drawing.Size(182, 26);
            this.numAverageGrade.TabIndex = 24;
            this.numAverageGrade.ValueChanged += new System.EventHandler(this.numAverageGrade_ValueChanged);
            // 
            // lblAverageGrade
            // 
            this.lblAverageGrade.AutoSize = true;
            this.lblAverageGrade.BackColor = System.Drawing.Color.Transparent;
            this.lblAverageGrade.Location = new System.Drawing.Point(16, 291);
            this.lblAverageGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAverageGrade.Name = "lblAverageGrade";
            this.lblAverageGrade.Size = new System.Drawing.Size(102, 16);
            this.lblAverageGrade.TabIndex = 9;
            this.lblAverageGrade.Text = "Средний балл:";
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(455, 297);
            this.rbMale.Margin = new System.Windows.Forms.Padding(4);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(86, 20);
            this.rbMale.TabIndex = 6;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Мужской";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(549, 297);
            this.rbFemale.Margin = new System.Windows.Forms.Padding(4);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(87, 20);
            this.rbFemale.TabIndex = 5;
            this.rbFemale.Text = "Женский";
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Location = new System.Drawing.Point(452, 277);
            this.lblGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(36, 16);
            this.lblGender.TabIndex = 7;
            this.lblGender.Text = "Пол:";
            // 
            // grpAddress
            // 
            this.grpAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(252)))), ((int)(((byte)(235)))));
            this.grpAddress.Controls.Add(this.txtApartment);
            this.grpAddress.Controls.Add(this.lblApartment);
            this.grpAddress.Controls.Add(this.txtHouse);
            this.grpAddress.Controls.Add(this.lblHouse);
            this.grpAddress.Controls.Add(this.txtStreet);
            this.grpAddress.Controls.Add(this.lblStreet);
            this.grpAddress.Controls.Add(this.mtxtPostalCode);
            this.grpAddress.Controls.Add(this.lblPostalCode);
            this.grpAddress.Controls.Add(this.txtCity);
            this.grpAddress.Controls.Add(this.lblCity);
            this.grpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpAddress.Location = new System.Drawing.Point(16, 364);
            this.grpAddress.Margin = new System.Windows.Forms.Padding(4);
            this.grpAddress.Name = "grpAddress";
            this.grpAddress.Padding = new System.Windows.Forms.Padding(4);
            this.grpAddress.Size = new System.Drawing.Size(400, 338);
            this.grpAddress.TabIndex = 4;
            this.grpAddress.TabStop = false;
            this.grpAddress.Text = "Адрес";
            // 
            // txtApartment
            // 
            this.txtApartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtApartment.Location = new System.Drawing.Point(7, 295);
            this.txtApartment.Margin = new System.Windows.Forms.Padding(4);
            this.txtApartment.Name = "txtApartment";
            this.txtApartment.Size = new System.Drawing.Size(380, 26);
            this.txtApartment.TabIndex = 0;
            this.txtApartment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApartment_KeyPress);
            // 
            // lblApartment
            // 
            this.lblApartment.AutoSize = true;
            this.lblApartment.Location = new System.Drawing.Point(7, 271);
            this.lblApartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApartment.Name = "lblApartment";
            this.lblApartment.Size = new System.Drawing.Size(95, 20);
            this.lblApartment.TabIndex = 1;
            this.lblApartment.Text = "Квартира:";
            // 
            // txtHouse
            // 
            this.txtHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtHouse.Location = new System.Drawing.Point(7, 241);
            this.txtHouse.Margin = new System.Windows.Forms.Padding(4);
            this.txtHouse.Name = "txtHouse";
            this.txtHouse.Size = new System.Drawing.Size(380, 26);
            this.txtHouse.TabIndex = 2;
            this.txtHouse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHouse_KeyPress);
            // 
            // lblHouse
            // 
            this.lblHouse.AutoSize = true;
            this.lblHouse.Location = new System.Drawing.Point(7, 217);
            this.lblHouse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHouse.Name = "lblHouse";
            this.lblHouse.Size = new System.Drawing.Size(49, 20);
            this.lblHouse.TabIndex = 3;
            this.lblHouse.Text = "Дом:";
            // 
            // txtStreet
            // 
            this.txtStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtStreet.Location = new System.Drawing.Point(7, 176);
            this.txtStreet.Margin = new System.Windows.Forms.Padding(4);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(380, 26);
            this.txtStreet.TabIndex = 4;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(7, 152);
            this.lblStreet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(65, 20);
            this.lblStreet.TabIndex = 5;
            this.lblStreet.Text = "Улица:";
            // 
            // mtxtPostalCode
            // 
            this.mtxtPostalCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.mtxtPostalCode.Location = new System.Drawing.Point(7, 118);
            this.mtxtPostalCode.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtPostalCode.Mask = "000000";
            this.mtxtPostalCode.Name = "mtxtPostalCode";
            this.mtxtPostalCode.Size = new System.Drawing.Size(380, 26);
            this.mtxtPostalCode.TabIndex = 6;
            this.mtxtPostalCode.ValidatingType = typeof(int);
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Location = new System.Drawing.Point(7, 94);
            this.lblPostalCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(75, 20);
            this.lblPostalCode.TabIndex = 7;
            this.lblPostalCode.Text = "Индекс:";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCity.Location = new System.Drawing.Point(7, 64);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(380, 26);
            this.txtCity.TabIndex = 8;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(7, 40);
            this.lblCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(66, 20);
            this.lblCity.TabIndex = 9;
            this.lblCity.Text = "Город:";
            // 
            // grpWorkPlace
            // 
            this.grpWorkPlace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(252)))), ((int)(((byte)(235)))));
            this.grpWorkPlace.Controls.Add(this.numSalary);
            this.grpWorkPlace.Controls.Add(this.lblSalary);
            this.grpWorkPlace.Controls.Add(this.numExperience);
            this.grpWorkPlace.Controls.Add(this.lblExperience);
            this.grpWorkPlace.Controls.Add(this.txtPosition);
            this.grpWorkPlace.Controls.Add(this.lblPosition);
            this.grpWorkPlace.Controls.Add(this.txtCompany);
            this.grpWorkPlace.Controls.Add(this.lblCompany);
            this.grpWorkPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpWorkPlace.Location = new System.Drawing.Point(455, 364);
            this.grpWorkPlace.Margin = new System.Windows.Forms.Padding(4);
            this.grpWorkPlace.Name = "grpWorkPlace";
            this.grpWorkPlace.Padding = new System.Windows.Forms.Padding(4);
            this.grpWorkPlace.Size = new System.Drawing.Size(400, 338);
            this.grpWorkPlace.TabIndex = 3;
            this.grpWorkPlace.TabStop = false;
            this.grpWorkPlace.Text = "Место работы";
            this.grpWorkPlace.Enter += new System.EventHandler(this.grpWorkPlace_Enter);
            // 
            // numSalary
            // 
            this.numSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numSalary.Location = new System.Drawing.Point(8, 271);
            this.numSalary.Margin = new System.Windows.Forms.Padding(4);
            this.numSalary.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSalary.Name = "numSalary";
            this.numSalary.Size = new System.Drawing.Size(380, 26);
            this.numSalary.TabIndex = 0;
            this.numSalary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numSalary_KeyPress);
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(7, 247);
            this.lblSalary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(96, 20);
            this.lblSalary.TabIndex = 1;
            this.lblSalary.Text = "Зарплата:";
            this.lblSalary.Click += new System.EventHandler(this.lblSalary_Click);
            // 
            // numExperience
            // 
            this.numExperience.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numExperience.Location = new System.Drawing.Point(8, 196);
            this.numExperience.Margin = new System.Windows.Forms.Padding(4);
            this.numExperience.Name = "numExperience";
            this.numExperience.Size = new System.Drawing.Size(380, 26);
            this.numExperience.TabIndex = 2;
            this.numExperience.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numExperience_KeyPress);
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(7, 172);
            this.lblExperience.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(58, 20);
            this.lblExperience.TabIndex = 3;
            this.lblExperience.Text = "Стаж:";
            // 
            // txtPosition
            // 
            this.txtPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtPosition.Location = new System.Drawing.Point(8, 128);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(4);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(380, 26);
            this.txtPosition.TabIndex = 4;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.BackColor = System.Drawing.Color.Transparent;
            this.lblPosition.Location = new System.Drawing.Point(4, 100);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(108, 20);
            this.lblPosition.TabIndex = 5;
            this.lblPosition.Text = "Должность:";
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCompany.Location = new System.Drawing.Point(8, 70);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(380, 26);
            this.txtCompany.TabIndex = 6;
            this.txtCompany.TextChanged += new System.EventHandler(this.txtCompany_TextChanged);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(7, 46);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(97, 20);
            this.lblCompany.TabIndex = 7;
            this.lblCompany.Text = "Компания:";
            // 
            // btnSaveJson
            // 
            this.btnSaveJson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(199)))), ((int)(((byte)(245)))));
            this.btnSaveJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSaveJson.Location = new System.Drawing.Point(224, 728);
            this.btnSaveJson.Name = "btnSaveJson";
            this.btnSaveJson.Size = new System.Drawing.Size(200, 40);
            this.btnSaveJson.TabIndex = 4;
            this.btnSaveJson.Text = "Сохранить JSON";
            this.btnSaveJson.UseVisualStyleBackColor = false;
            this.btnSaveJson.Click += new System.EventHandler(this.btnSaveJson_Click);
            // 
            // btnLoadJson
            // 
            this.btnLoadJson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(199)))), ((int)(((byte)(245)))));
            this.btnLoadJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLoadJson.Location = new System.Drawing.Point(432, 728);
            this.btnLoadJson.Name = "btnLoadJson";
            this.btnLoadJson.Size = new System.Drawing.Size(200, 40);
            this.btnLoadJson.TabIndex = 6;
            this.btnLoadJson.Text = "Загрузить JSON";
            this.btnLoadJson.UseVisualStyleBackColor = false;
            this.btnLoadJson.Click += new System.EventHandler(this.btnLoadJson_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(199)))), ((int)(((byte)(245)))));
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCalculate.Location = new System.Drawing.Point(16, 728);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(200, 40);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(199)))), ((int)(((byte)(245)))));
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNext.Location = new System.Drawing.Point(669, 728);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(71, 40);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "→";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(199)))), ((int)(((byte)(245)))));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAdd.Location = new System.Drawing.Point(746, 728);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 40);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(904, 797);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnLoadJson);
            this.Controls.Add(this.btnSaveJson);
            this.Controls.Add(this.grpWorkPlace);
            this.Controls.Add(this.grpAddress);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.numAverageGrade);
            this.Controls.Add(this.lblAverageGrade);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.trackCourse);
            this.Controls.Add(this.lblCourseValue);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.cmbSpecialization);
            this.Controls.Add(this.lblSpecialization);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnNext);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Информация о студенте";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackCourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAverageGrade)).EndInit();
            this.grpAddress.ResumeLayout(false);
            this.grpAddress.PerformLayout();
            this.grpWorkPlace.ResumeLayout(false);
            this.grpWorkPlace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExperience)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.ComboBox cmbSpecialization;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.TrackBar trackCourse;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblCourseValue;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.NumericUpDown numAverageGrade;
        private System.Windows.Forms.Label lblAverageGrade;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.GroupBox grpAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.MaskedTextBox mtxtPostalCode;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtHouse;
        private System.Windows.Forms.Label lblHouse;
        private System.Windows.Forms.TextBox txtApartment;
        private System.Windows.Forms.Label lblApartment;
        private System.Windows.Forms.GroupBox grpWorkPlace;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.NumericUpDown numExperience;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.NumericUpDown numSalary;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Button btnSaveJson;
        private System.Windows.Forms.Button btnLoadJson;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAdd;
    }
}