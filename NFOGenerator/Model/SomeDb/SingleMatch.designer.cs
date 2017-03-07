﻿/// Copyright 2017 Jevenski C. Woodsmann. All Rights Reserved
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
/// 
///     http://www.apache.org/licenses/LICENSE-2.0
/// 
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.

namespace NFOGenerator.Model.SomeDb
{
    partial class SingleMatch
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleMatch));
            this.picIMDbPoster = new System.Windows.Forms.PictureBox();
            this.lblIMDbTitle = new System.Windows.Forms.Label();
            this.txtIMDbTitle = new System.Windows.Forms.TextBox();
            this.lblIMDbYear = new System.Windows.Forms.Label();
            this.txtIMDbYear = new System.Windows.Forms.TextBox();
            this.lnkSomeDbLink = new System.Windows.Forms.LinkLabel();
            this.lblIMDbLink = new System.Windows.Forms.Label();
            this.btnIMDbSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picIMDbPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // picIMDbPoster
            // 
            this.picIMDbPoster.Image = ((System.Drawing.Image)(resources.GetObject("picIMDbPoster.Image")));
            this.picIMDbPoster.Location = new System.Drawing.Point(10, 10);
            this.picIMDbPoster.Margin = new System.Windows.Forms.Padding(10);
            this.picIMDbPoster.Name = "picIMDbPoster";
            this.picIMDbPoster.Size = new System.Drawing.Size(150, 200);
            this.picIMDbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIMDbPoster.TabIndex = 0;
            this.picIMDbPoster.TabStop = false;
            // 
            // lblIMDbTitle
            // 
            this.lblIMDbTitle.AutoSize = true;
            this.lblIMDbTitle.Location = new System.Drawing.Point(166, 13);
            this.lblIMDbTitle.Name = "lblIMDbTitle";
            this.lblIMDbTitle.Size = new System.Drawing.Size(41, 12);
            this.lblIMDbTitle.TabIndex = 1;
            this.lblIMDbTitle.Text = "Title:";
            // 
            // txtIMDbTitle
            // 
            this.txtIMDbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIMDbTitle.Location = new System.Drawing.Point(213, 10);
            this.txtIMDbTitle.Margin = new System.Windows.Forms.Padding(10);
            this.txtIMDbTitle.Name = "txtIMDbTitle";
            this.txtIMDbTitle.ReadOnly = true;
            this.txtIMDbTitle.Size = new System.Drawing.Size(215, 21);
            this.txtIMDbTitle.TabIndex = 2;
            // 
            // lblIMDbYear
            // 
            this.lblIMDbYear.AutoSize = true;
            this.lblIMDbYear.Location = new System.Drawing.Point(166, 40);
            this.lblIMDbYear.Name = "lblIMDbYear";
            this.lblIMDbYear.Size = new System.Drawing.Size(35, 12);
            this.lblIMDbYear.TabIndex = 3;
            this.lblIMDbYear.Text = "Year:";
            // 
            // txtIMDbYear
            // 
            this.txtIMDbYear.Location = new System.Drawing.Point(213, 37);
            this.txtIMDbYear.Name = "txtIMDbYear";
            this.txtIMDbYear.ReadOnly = true;
            this.txtIMDbYear.Size = new System.Drawing.Size(52, 21);
            this.txtIMDbYear.TabIndex = 4;
            // 
            // lnkSomeDbLink
            // 
            this.lnkSomeDbLink.ActiveLinkColor = System.Drawing.Color.Brown;
            this.lnkSomeDbLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkSomeDbLink.AutoSize = true;
            this.lnkSomeDbLink.Location = new System.Drawing.Point(211, 65);
            this.lnkSomeDbLink.Name = "lnkSomeDbLink";
            this.lnkSomeDbLink.Size = new System.Drawing.Size(113, 12);
            this.lnkSomeDbLink.TabIndex = 6;
            this.lnkSomeDbLink.TabStop = true;
            this.lnkSomeDbLink.Text = "(SomeDb link here)";
            this.lnkSomeDbLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkIMDbLink_LinkClicked);
            // 
            // lblIMDbLink
            // 
            this.lblIMDbLink.AutoSize = true;
            this.lblIMDbLink.Location = new System.Drawing.Point(166, 65);
            this.lblIMDbLink.Name = "lblIMDbLink";
            this.lblIMDbLink.Size = new System.Drawing.Size(35, 12);
            this.lblIMDbLink.TabIndex = 1;
            this.lblIMDbLink.Text = "Link:";
            // 
            // btnIMDbSelect
            // 
            this.btnIMDbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIMDbSelect.Location = new System.Drawing.Point(353, 185);
            this.btnIMDbSelect.Name = "btnIMDbSelect";
            this.btnIMDbSelect.Size = new System.Drawing.Size(75, 23);
            this.btnIMDbSelect.TabIndex = 7;
            this.btnIMDbSelect.Text = "Select";
            this.btnIMDbSelect.UseVisualStyleBackColor = true;
            this.btnIMDbSelect.Click += new System.EventHandler(this.btnIMDbSelect_Click);
            // 
            // SingleMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnIMDbSelect);
            this.Controls.Add(this.lnkSomeDbLink);
            this.Controls.Add(this.txtIMDbYear);
            this.Controls.Add(this.lblIMDbYear);
            this.Controls.Add(this.txtIMDbTitle);
            this.Controls.Add(this.lblIMDbLink);
            this.Controls.Add(this.lblIMDbTitle);
            this.Controls.Add(this.picIMDbPoster);
            this.Name = "SingleMatch";
            this.Size = new System.Drawing.Size(438, 218);
            ((System.ComponentModel.ISupportInitialize)(this.picIMDbPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIMDbPoster;
        private System.Windows.Forms.Label lblIMDbTitle;
        private System.Windows.Forms.TextBox txtIMDbTitle;
        private System.Windows.Forms.Label lblIMDbYear;
        private System.Windows.Forms.TextBox txtIMDbYear;
        private System.Windows.Forms.LinkLabel lnkSomeDbLink;
        private System.Windows.Forms.Label lblIMDbLink;
        public System.Windows.Forms.Button btnIMDbSelect;
    }
}