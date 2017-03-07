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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NFOGenerator.Model.SomeDb
{
    public partial class SingleMatch : UserControl
    {
        private SearchResults sr;
        
        public SingleMatch(SearchResults sr)
        {
            InitializeComponent();
            this.sr = sr;
        }

        /// <summary>
        /// Add movie info to search result control.
        /// </summary>
        /// <param name="paraPoster">Link to poster.</param>
        /// <param name="paraTitle">Movie title.</param>
        /// <param name="paraYear">Release year.</param>
        /// <param name="paraID">IMDb ID.</param>
        public void DisplayMovie(string paraPoster, string paraTitle, string paraYear, string paraID)
        {
            this.picIMDbPoster.ImageLocation = paraPoster;
            this.txtIMDbTitle.Text = paraTitle;
            this.txtIMDbYear.Text = paraYear;
            if (paraID != "")
            {
                this.lnkSomeDbLink.Text = "http://www.imdb.com/title/" + paraID + "/";
            }
            else
            {
                this.lnkSomeDbLink.Text = "";
            }
        }

        private void lnkIMDbLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.lnkSomeDbLink.Text);
        }

        private void btnIMDbSelect_Click(object sender, EventArgs e)
        {
            this.sr.LogSelectedMovie(this.txtIMDbTitle.Text, this.txtIMDbYear.Text, this.lnkSomeDbLink.Text);
            this.sr.Close();
        }
    }
}