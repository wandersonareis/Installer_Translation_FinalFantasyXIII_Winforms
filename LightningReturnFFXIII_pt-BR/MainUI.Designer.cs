using SaaUI;

namespace LightningReturnFFXIII_pt_BR
{
    partial class MainUi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUi));
            this.textBoxGameLocation = new System.Windows.Forms.TextBox();
            this.btnCredit = new SaaUI.SaaButton();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.linkVHG = new System.Windows.Forms.LinkLabel();
            this.labelLocation = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.btnUpdate = new SaaUI.SaaButton();
            this.btnUninstall = new SaaUI.SaaButton();
            this.btnInstall = new SaaUI.SaaButton();
            this.btnGameLocation = new SaaUI.SaaButton();
            this.saaProgressBar = new SaaUI.SaaProgressBar();
            this.SuspendLayout();
            // 
            // textBoxGameLocation
            // 
            this.textBoxGameLocation.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textBoxGameLocation.AllowDrop = true;
            this.textBoxGameLocation.BackColor = System.Drawing.Color.White;
            this.textBoxGameLocation.Font = new System.Drawing.Font("FOT-NewRodin Pro DB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxGameLocation.Location = new System.Drawing.Point(109, 164);
            this.textBoxGameLocation.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxGameLocation.Name = "textBoxGameLocation";
            this.textBoxGameLocation.PlaceholderText = "Diretório onde o jogo está instalado";
            this.textBoxGameLocation.ReadOnly = true;
            this.textBoxGameLocation.Size = new System.Drawing.Size(383, 31);
            this.textBoxGameLocation.TabIndex = 1;
            this.textBoxGameLocation.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxGameLocation_DragDrop);
            this.textBoxGameLocation.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxGameLocation_DragEnter);
            // 
            // btnCredit
            // 
            this.btnCredit.AccessibleDescription = "Use para conhecer os envolvidos no projeto";
            this.btnCredit.AccessibleName = "Informações";
            this.btnCredit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnCredit.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnCredit.BackColorAngle = 354F;
            this.btnCredit.Border = 3;
            this.btnCredit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnCredit.BorderColor2 = System.Drawing.Color.Transparent;
            this.btnCredit.BorderColorAngle = 180;
            this.btnCredit.ClickColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnCredit.ClickColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnCredit.EnableDoubleBuffering = true;
            this.btnCredit.Font = new System.Drawing.Font("FOT-NewRodin Pro DB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCredit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(76)))), ((int)(((byte)(95)))));
            this.btnCredit.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.btnCredit.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnCredit.Icon = null;
            this.btnCredit.IconOffsetX = 5F;
            this.btnCredit.IconOffsetY = 5F;
            this.btnCredit.IconSize = new System.Drawing.Size(20, 20);
            this.btnCredit.Location = new System.Drawing.Point(14, 315);
            this.btnCredit.Margin = new System.Windows.Forms.Padding(4);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Radius.BottomRight = 7;
            this.btnCredit.Radius.TopLeft = 7;
            this.btnCredit.Size = new System.Drawing.Size(477, 26);
            this.btnCredit.TabIndex = 5;
            this.btnCredit.TextOffsetX = 0F;
            this.btnCredit.TextOffsetY = -2F;
            this.btnCredit.Value = "Informações / Créditos";
            this.btnCredit.Click += new System.EventHandler(this.BtnCredit_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.listBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLog.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxLog.Font = new System.Drawing.Font("FOT-NewRodin Pro DB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listBoxLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(76)))), ((int)(((byte)(95)))));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(15, 357);
            this.listBoxLog.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(476, 274);
            this.listBoxLog.TabIndex = 7;
            this.listBoxLog.TabStop = false;
            this.listBoxLog.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxLog_DrawItem);
            this.listBoxLog.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListBoxLog_MeasureItem);
            // 
            // linkVHG
            // 
            this.linkVHG.AutoSize = true;
            this.linkVHG.BackColor = System.Drawing.Color.Transparent;
            this.linkVHG.Location = new System.Drawing.Point(14, 9);
            this.linkVHG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkVHG.Name = "linkVHG";
            this.linkVHG.Size = new System.Drawing.Size(68, 15);
            this.linkVHG.TabIndex = 9;
            this.linkVHG.TabStop = true;
            this.linkVHG.Text = "TriboGamer";
            this.linkVHG.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkVHG_LinkClicked);
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.BackColor = System.Drawing.Color.Transparent;
            this.labelLocation.Font = new System.Drawing.Font("FOT-NewRodin Pro DB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(76)))), ((int)(((byte)(95)))));
            this.labelLocation.Location = new System.Drawing.Point(16, 142);
            this.labelLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(103, 19);
            this.labelLocation.TabIndex = 10;
            this.labelLocation.Text = "Pasta do jogo";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbVersion
            // 
            this.lbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbVersion.AutoSize = true;
            this.lbVersion.BackColor = System.Drawing.Color.Transparent;
            this.lbVersion.ForeColor = System.Drawing.Color.DimGray;
            this.lbVersion.Location = new System.Drawing.Point(90, 9);
            this.lbVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(0, 15);
            this.lbVersion.TabIndex = 12;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnUpdate.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnUpdate.BackColorAngle = 354F;
            this.btnUpdate.Border = 3;
            this.btnUpdate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnUpdate.BorderColor2 = System.Drawing.Color.Transparent;
            this.btnUpdate.BorderColorAngle = 360;
            this.btnUpdate.ClickColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnUpdate.ClickColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnUpdate.EnableDoubleBuffering = true;
            this.btnUpdate.Font = new System.Drawing.Font("FOT-NewRodin Pro DB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(76)))), ((int)(((byte)(95)))));
            this.btnUpdate.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.btnUpdate.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnUpdate.Icon = null;
            this.btnUpdate.IconOffsetX = 5F;
            this.btnUpdate.IconOffsetY = 5F;
            this.btnUpdate.IconSize = new System.Drawing.Size(20, 20);
            this.btnUpdate.Location = new System.Drawing.Point(14, 205);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Radius.TopLeft = 7;
            this.btnUpdate.Size = new System.Drawing.Size(237, 32);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.TextOffsetX = 0F;
            this.btnUpdate.TextOffsetY = -2F;
            this.btnUpdate.Value = "Atualizar pacote de tradução";
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnUninstall
            // 
            this.btnUninstall.AccessibleDescription = "Use para desinstalar a tradução";
            this.btnUninstall.AccessibleName = "Desinstalar a tradução";
            this.btnUninstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnUninstall.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnUninstall.BackColorAngle = 180F;
            this.btnUninstall.Border = 3;
            this.btnUninstall.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnUninstall.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnUninstall.BorderColorAngle = 180;
            this.btnUninstall.ClickColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnUninstall.ClickColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnUninstall.EnableDoubleBuffering = true;
            this.btnUninstall.Font = new System.Drawing.Font("FOT-NewRodin Pro DB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUninstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(76)))), ((int)(((byte)(95)))));
            this.btnUninstall.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnUninstall.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.btnUninstall.Icon = null;
            this.btnUninstall.IconOffsetX = 5F;
            this.btnUninstall.IconOffsetY = 5F;
            this.btnUninstall.IconSize = new System.Drawing.Size(20, 20);
            this.btnUninstall.Location = new System.Drawing.Point(255, 205);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Radius.BottomRight = 7;
            this.btnUninstall.Size = new System.Drawing.Size(236, 32);
            this.btnUninstall.TabIndex = 16;
            this.btnUninstall.TextOffsetX = 0F;
            this.btnUninstall.TextOffsetY = -2F;
            this.btnUninstall.Value = "Desinstalar a tradução";
            this.btnUninstall.Click += new System.EventHandler(this.BtnUninstall_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.AccessibleDescription = "Use para instalar a tradução";
            this.btnInstall.AccessibleName = "Instalar";
            this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstall.AutoSize = true;
            this.btnInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnInstall.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnInstall.BackColorAngle = 354F;
            this.btnInstall.Border = 3;
            this.btnInstall.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnInstall.BorderColor2 = System.Drawing.Color.Transparent;
            this.btnInstall.BorderColorAngle = 180;
            this.btnInstall.ClickColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnInstall.ClickColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnInstall.EnableDoubleBuffering = true;
            this.btnInstall.Font = new System.Drawing.Font("FOT-NewRodin Pro DB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(76)))), ((int)(((byte)(95)))));
            this.btnInstall.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.btnInstall.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnInstall.Icon = null;
            this.btnInstall.IconOffsetX = 5F;
            this.btnInstall.IconOffsetY = 5F;
            this.btnInstall.IconSize = new System.Drawing.Size(20, 20);
            this.btnInstall.Location = new System.Drawing.Point(14, 243);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Radius.BottomRight = 7;
            this.btnInstall.Radius.TopLeft = 7;
            this.btnInstall.Size = new System.Drawing.Size(477, 32);
            this.btnInstall.TabIndex = 17;
            this.btnInstall.TextOffsetX = 0F;
            this.btnInstall.TextOffsetY = -2F;
            this.btnInstall.Value = "Instalar a tradução pt-BR";
            this.btnInstall.Click += new System.EventHandler(this.BtnInstall_Click);
            // 
            // btnGameLocation
            // 
            this.btnGameLocation.AccessibleDescription = "Aponte para  o diretório onde o jogo está instalado";
            this.btnGameLocation.AccessibleName = "Diretório do jogo";
            this.btnGameLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnGameLocation.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnGameLocation.BackColorAngle = 354F;
            this.btnGameLocation.Border = 3;
            this.btnGameLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnGameLocation.BorderColor2 = System.Drawing.Color.Transparent;
            this.btnGameLocation.BorderColorAngle = 360;
            this.btnGameLocation.ClickColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnGameLocation.ClickColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnGameLocation.EnableDoubleBuffering = true;
            this.btnGameLocation.Font = new System.Drawing.Font("FOT-NewRodin Pro DB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGameLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(76)))), ((int)(((byte)(95)))));
            this.btnGameLocation.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.btnGameLocation.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.btnGameLocation.Icon = null;
            this.btnGameLocation.IconOffsetX = 5F;
            this.btnGameLocation.IconOffsetY = 5F;
            this.btnGameLocation.IconSize = new System.Drawing.Size(20, 20);
            this.btnGameLocation.Location = new System.Drawing.Point(16, 167);
            this.btnGameLocation.Name = "btnGameLocation";
            this.btnGameLocation.Radius.BottomRight = 7;
            this.btnGameLocation.Radius.TopLeft = 7;
            this.btnGameLocation.Size = new System.Drawing.Size(87, 26);
            this.btnGameLocation.TabIndex = 18;
            this.btnGameLocation.TextOffsetX = 0F;
            this.btnGameLocation.TextOffsetY = -2F;
            this.btnGameLocation.Value = "Diretório";
            this.btnGameLocation.Click += new System.EventHandler(this.BtnGameLocation_Click);
            // 
            // saaProgressBar
            // 
            this.saaProgressBar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.saaProgressBar.Color = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.saaProgressBar.DecimalPoints = 2;
            this.saaProgressBar.Display = SaaUI.SaaCircularProgressDisplayValue.Percent;
            this.saaProgressBar.Location = new System.Drawing.Point(14, 287);
            this.saaProgressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saaProgressBar.Maximum = 100;
            this.saaProgressBar.Minimum = 0;
            this.saaProgressBar.Name = "saaProgressBar";
            this.saaProgressBar.Prefix = "";
            this.saaProgressBar.RoundedStyle = false;
            this.saaProgressBar.Size = new System.Drawing.Size(477, 21);
            this.saaProgressBar.Step = 10;
            this.saaProgressBar.Suffix = "%";
            this.saaProgressBar.TabIndex = 19;
            this.saaProgressBar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(76)))), ((int)(((byte)(95)))));
            this.saaProgressBar.TextFont = new System.Drawing.Font("FOT-NewRodin Pro DB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saaProgressBar.TextOffset = new System.Drawing.Point(0, -1);
            this.saaProgressBar.Value = 0;
            this.saaProgressBar.Vertical = false;
            // 
            // MainUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(514, 661);
            this.Controls.Add(this.saaProgressBar);
            this.Controls.Add(this.btnGameLocation);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.linkVHG);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.btnCredit);
            this.Controls.Add(this.textBoxGameLocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(530, 700);
            this.MinimumSize = new System.Drawing.Size(530, 700);
            this.Name = "MainUi";
            this.Text = "Lightning Return FF13™ pt-BR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainUi_FormClosing);
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.Shown += new System.EventHandler(this.MainUI_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxGameLocation;
        private SaaUI.SaaButton btnCredit;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.LinkLabel linkVHG;
        private System.Windows.Forms.Label labelLocation;
        private Label lbVersion;
        private SaaUI.SaaButton btnUpdate;
        private SaaUI.SaaButton btnUninstall;
        private SaaUI.SaaButton btnInstall;
        private SaaUI.SaaButton btnGameLocation;
        private SaaUI.SaaProgressBar saaProgressBar;
    }
}

