
namespace PNR_File_Maker
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            txtFlightNumber = new System.Windows.Forms.TextBox();
            txtNoofSeatofFlight = new System.Windows.Forms.TextBox();
            txtAircraftType = new System.Windows.Forms.TextBox();
            txtNoOfBusinessClassRows = new System.Windows.Forms.TextBox();
            txtNoOfPremiumClassRows = new System.Windows.Forms.TextBox();
            txtArrivalDate = new System.Windows.Forms.TextBox();
            txtDestinationPort = new System.Windows.Forms.TextBox();
            txtOriginPort = new System.Windows.Forms.TextBox();
            txtNoofPassengers = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            dataGridView = new System.Windows.Forms.DataGridView();
            btnLoad = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnNew = new System.Windows.Forms.Button();
            dtArrivalTime = new System.Windows.Forms.DateTimePicker();
            dtDepartureTime = new System.Windows.Forms.DateTimePicker();
            txtDepartureDate = new System.Windows.Forms.TextBox();
            btnCopyPax = new System.Windows.Forms.Button();
            btnAddPax = new System.Windows.Forms.Button();
            btnDelPax = new System.Windows.Forms.Button();
            btnRndPax = new System.Windows.Forms.Button();
            btnClearPax = new System.Windows.Forms.Button();
            toolTipCtrl = new System.Windows.Forms.ToolTip(components);
            btnAutoGenerate = new System.Windows.Forms.Button();
            label11 = new System.Windows.Forms.Label();
            txtNoOfEconomyClassRows = new System.Windows.Forms.TextBox();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            txtRequiredPax = new System.Windows.Forms.TextBox();
            txtFileCount = new System.Windows.Forms.TextBox();
            label16 = new System.Windows.Forms.Label();
            txtFlightPrefix = new System.Windows.Forms.TextBox();
            txtDelayTime = new System.Windows.Forms.TextBox();
            label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // txtFlightNumber
            // 
            txtFlightNumber.Location = new System.Drawing.Point(255, 12);
            txtFlightNumber.Name = "txtFlightNumber";
            txtFlightNumber.Size = new System.Drawing.Size(128, 31);
            txtFlightNumber.TabIndex = 0;
            // 
            // txtNoofSeatofFlight
            // 
            txtNoofSeatofFlight.Location = new System.Drawing.Point(988, 12);
            txtNoofSeatofFlight.Name = "txtNoofSeatofFlight";
            txtNoofSeatofFlight.Size = new System.Drawing.Size(84, 31);
            txtNoofSeatofFlight.TabIndex = 2;
            // 
            // txtAircraftType
            // 
            txtAircraftType.Location = new System.Drawing.Point(194, 65);
            txtAircraftType.Name = "txtAircraftType";
            txtAircraftType.Size = new System.Drawing.Size(368, 31);
            txtAircraftType.TabIndex = 3;
            // 
            // txtNoOfBusinessClassRows
            // 
            txtNoOfBusinessClassRows.Location = new System.Drawing.Point(800, 102);
            txtNoOfBusinessClassRows.Name = "txtNoOfBusinessClassRows";
            txtNoOfBusinessClassRows.Size = new System.Drawing.Size(82, 31);
            txtNoOfBusinessClassRows.TabIndex = 4;
            txtNoOfBusinessClassRows.TextChanged += txtNoOfBusinessClassRows_TextChanged;
            // 
            // txtNoOfPremiumClassRows
            // 
            txtNoOfPremiumClassRows.Location = new System.Drawing.Point(800, 65);
            txtNoOfPremiumClassRows.Name = "txtNoOfPremiumClassRows";
            txtNoOfPremiumClassRows.Size = new System.Drawing.Size(82, 31);
            txtNoOfPremiumClassRows.TabIndex = 5;
            txtNoOfPremiumClassRows.TextChanged += txtNoOfPremiumClassRows_TextChanged;
            // 
            // txtArrivalDate
            // 
            txtArrivalDate.Location = new System.Drawing.Point(800, 206);
            txtArrivalDate.Name = "txtArrivalDate";
            txtArrivalDate.Size = new System.Drawing.Size(150, 31);
            txtArrivalDate.TabIndex = 10;
            // 
            // txtDestinationPort
            // 
            txtDestinationPort.Location = new System.Drawing.Point(800, 169);
            txtDestinationPort.Name = "txtDestinationPort";
            txtDestinationPort.Size = new System.Drawing.Size(273, 31);
            txtDestinationPort.TabIndex = 9;
            // 
            // txtOriginPort
            // 
            txtOriginPort.Location = new System.Drawing.Point(194, 169);
            txtOriginPort.Name = "txtOriginPort";
            txtOriginPort.Size = new System.Drawing.Size(273, 31);
            txtOriginPort.TabIndex = 6;
            // 
            // txtNoofPassengers
            // 
            txtNoofPassengers.Location = new System.Drawing.Point(732, 12);
            txtNoofPassengers.Name = "txtNoofPassengers";
            txtNoofPassengers.Size = new System.Drawing.Size(84, 31);
            txtNoofPassengers.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(126, 25);
            label1.TabIndex = 10;
            label1.Text = "Flight Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(568, 139);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(184, 25);
            label2.TabIndex = 11;
            label2.Text = "No of Economy Rows";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 65);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(111, 25);
            label3.TabIndex = 12;
            label3.Text = "Aircraft Type";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(568, 102);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(225, 25);
            label4.TabIndex = 13;
            label4.Text = "No Of Business Class Rows";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(568, 65);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(229, 25);
            label5.TabIndex = 14;
            label5.Text = "No Of Premium Class Rows";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(568, 206);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(147, 25);
            label6.TabIndex = 19;
            label6.Text = "Arrival Date Time";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(12, 206);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(176, 25);
            label7.TabIndex = 18;
            label7.Text = "Departure Date Time";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(568, 169);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(139, 25);
            label8.TabIndex = 17;
            label8.Text = "Destination Port";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(12, 169);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(98, 25);
            label9.TabIndex = 16;
            label9.Text = "Origin Port";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(568, 12);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(150, 25);
            label10.TabIndex = 15;
            label10.Text = "No of Passengers";
            // 
            // dataGridView
            // 
            dataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            dataGridView.Location = new System.Drawing.Point(21, 272);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.RowTemplate.Height = 33;
            dataGridView.Size = new System.Drawing.Size(1051, 399);
            dataGridView.TabIndex = 12;
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
            dataGridView.RowsAdded += dataGridView_RowsAdded;
            dataGridView.RowsRemoved += dataGridView_RowsRemoved;
            // 
            // btnLoad
            // 
            btnLoad.Font = new System.Drawing.Font("Wingdings", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnLoad.Location = new System.Drawing.Point(1117, 77);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new System.Drawing.Size(60, 60);
            btnLoad.TabIndex = 14;
            btnLoad.Text = "1";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnSave.Location = new System.Drawing.Point(1117, 143);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(60, 60);
            btnSave.TabIndex = 15;
            btnSave.Text = "<";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnNew
            // 
            btnNew.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnNew.Location = new System.Drawing.Point(1117, 11);
            btnNew.Name = "btnNew";
            btnNew.Size = new System.Drawing.Size(60, 60);
            btnNew.TabIndex = 13;
            btnNew.Text = "2";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // dtArrivalTime
            // 
            dtArrivalTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            dtArrivalTime.Location = new System.Drawing.Point(956, 206);
            dtArrivalTime.Name = "dtArrivalTime";
            dtArrivalTime.Size = new System.Drawing.Size(117, 31);
            dtArrivalTime.TabIndex = 11;
            dtArrivalTime.ValueChanged += dtArrivalTime_ValueChanged;
            // 
            // dtDepartureTime
            // 
            dtDepartureTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            dtDepartureTime.Location = new System.Drawing.Point(350, 206);
            dtDepartureTime.Name = "dtDepartureTime";
            dtDepartureTime.Size = new System.Drawing.Size(117, 31);
            dtDepartureTime.TabIndex = 8;
            dtDepartureTime.ValueChanged += dtDepartureTime_ValueChanged;
            // 
            // txtDepartureDate
            // 
            txtDepartureDate.Location = new System.Drawing.Point(194, 206);
            txtDepartureDate.Name = "txtDepartureDate";
            txtDepartureDate.Size = new System.Drawing.Size(150, 31);
            txtDepartureDate.TabIndex = 7;
            // 
            // btnCopyPax
            // 
            btnCopyPax.Font = new System.Drawing.Font("Wingdings", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnCopyPax.Location = new System.Drawing.Point(1078, 419);
            btnCopyPax.Name = "btnCopyPax";
            btnCopyPax.Size = new System.Drawing.Size(40, 40);
            btnCopyPax.TabIndex = 17;
            btnCopyPax.Text = "4";
            btnCopyPax.UseVisualStyleBackColor = true;
            btnCopyPax.Click += btnDuplicateRow_Click;
            // 
            // btnAddPax
            // 
            btnAddPax.Font = new System.Drawing.Font("Wingdings", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnAddPax.Location = new System.Drawing.Point(1078, 373);
            btnAddPax.Name = "btnAddPax";
            btnAddPax.Size = new System.Drawing.Size(40, 40);
            btnAddPax.TabIndex = 16;
            btnAddPax.Text = "!";
            btnAddPax.UseVisualStyleBackColor = true;
            btnAddPax.Click += btnAddPax_Click;
            // 
            // btnDelPax
            // 
            btnDelPax.Font = new System.Drawing.Font("Wingdings", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnDelPax.Location = new System.Drawing.Point(1078, 465);
            btnDelPax.Name = "btnDelPax";
            btnDelPax.Size = new System.Drawing.Size(40, 40);
            btnDelPax.TabIndex = 18;
            btnDelPax.Text = "\"";
            btnDelPax.UseVisualStyleBackColor = true;
            btnDelPax.Click += btnDelPax_Click;
            // 
            // btnRndPax
            // 
            btnRndPax.Font = new System.Drawing.Font("Wingdings", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRndPax.Location = new System.Drawing.Point(1078, 511);
            btnRndPax.Name = "btnRndPax";
            btnRndPax.Size = new System.Drawing.Size(40, 40);
            btnRndPax.TabIndex = 20;
            btnRndPax.Text = "I";
            btnRndPax.UseVisualStyleBackColor = true;
            btnRndPax.Click += btnRndPax_Click;
            // 
            // btnClearPax
            // 
            btnClearPax.Font = new System.Drawing.Font("Wingdings", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnClearPax.Location = new System.Drawing.Point(1078, 557);
            btnClearPax.Name = "btnClearPax";
            btnClearPax.Size = new System.Drawing.Size(40, 40);
            btnClearPax.TabIndex = 21;
            btnClearPax.Text = "M";
            btnClearPax.UseVisualStyleBackColor = true;
            btnClearPax.Click += btnClearPax_Click;
            // 
            // btnAutoGenerate
            // 
            btnAutoGenerate.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnAutoGenerate.Location = new System.Drawing.Point(1117, 220);
            btnAutoGenerate.Name = "btnAutoGenerate";
            btnAutoGenerate.Size = new System.Drawing.Size(60, 60);
            btnAutoGenerate.TabIndex = 22;
            btnAutoGenerate.Text = ":";
            btnAutoGenerate.UseVisualStyleBackColor = true;
            btnAutoGenerate.Click += btnAutoGenerate_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(12, 122);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(166, 25);
            label11.TabIndex = 23;
            label11.Text = "Required Pax Count";
            // 
            // txtNoOfEconomyClassRows
            // 
            txtNoOfEconomyClassRows.Location = new System.Drawing.Point(800, 139);
            txtNoOfEconomyClassRows.Name = "txtNoOfEconomyClassRows";
            txtNoOfEconomyClassRows.Size = new System.Drawing.Size(82, 31);
            txtNoOfEconomyClassRows.TabIndex = 24;
            txtNoOfEconomyClassRows.TextChanged += txtNoOfEconomyClassRows_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(894, 68);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(56, 25);
            label12.TabIndex = 25;
            label12.Text = "1-2-1";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(894, 102);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(56, 25);
            label13.TabIndex = 26;
            label13.Text = "2-2-2";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(894, 139);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(56, 25);
            label14.TabIndex = 27;
            label14.Text = "3-4-3";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(857, 15);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(105, 25);
            label15.TabIndex = 28;
            label15.Text = "No of Seats";
            // 
            // txtRequiredPax
            // 
            txtRequiredPax.Location = new System.Drawing.Point(194, 119);
            txtRequiredPax.Name = "txtRequiredPax";
            txtRequiredPax.Size = new System.Drawing.Size(84, 31);
            txtRequiredPax.TabIndex = 29;
            // 
            // txtFileCount
            // 
            txtFileCount.Location = new System.Drawing.Point(433, 122);
            txtFileCount.Name = "txtFileCount";
            txtFileCount.Size = new System.Drawing.Size(84, 31);
            txtFileCount.TabIndex = 30;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(327, 122);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(91, 25);
            label16.TabIndex = 31;
            label16.Text = "File Count";
            // 
            // txtFlightPrefix
            // 
            txtFlightPrefix.Location = new System.Drawing.Point(194, 12);
            txtFlightPrefix.Name = "txtFlightPrefix";
            txtFlightPrefix.Size = new System.Drawing.Size(55, 31);
            txtFlightPrefix.TabIndex = 32;
            // 
            // txtDelayTime
            // 
            txtDelayTime.Location = new System.Drawing.Point(488, 12);
            txtDelayTime.Name = "txtDelayTime";
            txtDelayTime.Size = new System.Drawing.Size(55, 31);
            txtDelayTime.TabIndex = 33;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(416, 12);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(56, 25);
            label17.TabIndex = 34;
            label17.Text = "Delay";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1205, 684);
            Controls.Add(label17);
            Controls.Add(txtDelayTime);
            Controls.Add(txtFlightPrefix);
            Controls.Add(label16);
            Controls.Add(txtFileCount);
            Controls.Add(txtRequiredPax);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(txtNoOfEconomyClassRows);
            Controls.Add(label11);
            Controls.Add(btnAutoGenerate);
            Controls.Add(btnClearPax);
            Controls.Add(btnRndPax);
            Controls.Add(btnDelPax);
            Controls.Add(btnAddPax);
            Controls.Add(btnCopyPax);
            Controls.Add(txtDepartureDate);
            Controls.Add(dtDepartureTime);
            Controls.Add(dtArrivalTime);
            Controls.Add(btnNew);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);
            Controls.Add(dataGridView);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtArrivalDate);
            Controls.Add(txtDestinationPort);
            Controls.Add(txtOriginPort);
            Controls.Add(txtNoofPassengers);
            Controls.Add(txtNoOfPremiumClassRows);
            Controls.Add(txtNoOfBusinessClassRows);
            Controls.Add(txtAircraftType);
            Controls.Add(txtNoofSeatofFlight);
            Controls.Add(txtFlightNumber);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMain";
            Text = "API File Maker";
            FormClosing += frmMain_FormClosing;
            FormClosed += frmMain_FormClosed;
            Load += frmMain_Load;
            Shown += frmMain_Shown;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtFlightNumber;
        private System.Windows.Forms.TextBox txtNoofSeatofFlight;
        private System.Windows.Forms.TextBox txtAircraftType;
        private System.Windows.Forms.TextBox txtNoOfBusinessClassRows;
        private System.Windows.Forms.TextBox txtNoOfPremiumClassRows;
        private System.Windows.Forms.TextBox txtArrivalDate;
        private System.Windows.Forms.TextBox txtDestinationPort;
        private System.Windows.Forms.TextBox txtOriginPort;
        private System.Windows.Forms.TextBox txtNoofPassengers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DateTimePicker dtArrivalTime;
        private System.Windows.Forms.DateTimePicker dtDepartureTime;
        private System.Windows.Forms.TextBox txtDepartureDate;
        private System.Windows.Forms.Button btnCopyPax;
        private System.Windows.Forms.Button btnAddPax;
        private System.Windows.Forms.Button btnDelPax;
        private System.Windows.Forms.Button btnRndPax;
        private System.Windows.Forms.Button btnClearPax;
        private System.Windows.Forms.ToolTip toolTipCtrl;
        private System.Windows.Forms.Button btnAutoGenerate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNoOfEconomyClassRows;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRequiredPax;
        private System.Windows.Forms.TextBox txtFileCount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtFlightPrefix;
        private System.Windows.Forms.TextBox txtDelayTime;
        private System.Windows.Forms.Label label17;
    }
}

