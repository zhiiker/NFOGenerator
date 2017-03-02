﻿using System;
using System.Collections.Generic;
using System.Text;
using NFOGenerator.Util;
using NFOGenerator.Model.FileInfo;
using MediaInfoLib;

namespace NFOGenerator.Model.FileInfo
{
    public class ReleaseInfo
    {
        public MediaInfo MI = new MediaInfo();
        public GeneralInfo GI = new GeneralInfo();
        public VideoInfo VI = new VideoInfo();
        public AudioInfo[] AI;
        public SubtitleInfo[] SI;

        public ReleaseInfo()
        {
        }

        public void ReadMediaInfo(string inputFile)
        {
            MI.Open(inputFile);

            this.GI.fileSize = this.GetFileSize(this.MI.Get(StreamKind.General, 0, "FileSize"));
            this.GI.duration = this.GetDuration(this.MI.Get(StreamKind.General, 0, "Duration"));

            this.VI.width = this.MI.Get(StreamKind.Video, 0, "Width");
            this.VI.height = this.MI.Get(StreamKind.Video, 0, "Height");
            this.VI.displayAR = this.MI.Get(StreamKind.Video, 0, "DisplayAspectRatio");
            this.VI.framerate = this.MI.Get(StreamKind.Video, 0, "FrameRate") + " FPS";
            this.VI.bitrate = this.GetBitrate(this.MI.Get(StreamKind.Video, 0, "BitRate"));

            // Create a language name dictionary for both audio and subtitle lookup.
            LangDic languageName = new LangDic();

            this.AI = new AudioInfo[this.MI.Count_Get(StreamKind.Audio)];

            for (int i = 0; i < this.MI.Count_Get(StreamKind.Audio); i++)
            {
                // Get the language code and look it up in the dictionary.
                this.AI[i] = new AudioInfo(this.isSomething(this.MI.Get(StreamKind.Audio, i, "Title"), "Commentary"));
                this.AI[i].audioLang = languageName.GetFullName(this.MI.Get(StreamKind.Audio, i, "Language"));
                this.AI[i].audioCodec = this.MI.Get(StreamKind.Audio, i, "Format");
                this.AI[i].audioChan = this.GetChannels(this.MI.Get(StreamKind.Audio, i, "Channel(s)"));
                this.AI[i].audioBitr = this.GetBitrate(this.MI.Get(StreamKind.Audio, i, "BitRate"));
                this.AI[i].audioCommentator = this.MI.Get(StreamKind.Audio, i, "Title");
                this.AI[i].UpdateAudioInfo();
            }

            this.SI = new SubtitleInfo[this.MI.Count_Get(StreamKind.Text)];

            for (int i = 0; i < this.MI.Count_Get(StreamKind.Text); i++)
            {
                this.SI[i] = new SubtitleInfo();
                this.SI[i].subLang = languageName.GetFullName(this.MI.Get(StreamKind.Text, i, "Language"));
                this.SI[i].subFormat = this.MI.Get(StreamKind.Text, i, "Format");
                this.SI[i].subComment = this.MI.Get(StreamKind.Text, 0, "Title");
                this.SI[i].subForced = (this.isYesOrNo(this.MI.Get(StreamKind.Text, i, "Forced")) || 
                    this.isSomething(this.MI.Get(StreamKind.Text, i, "Title"), "Forced"));
                this.SI[i].subSDH = this.isSomething(this.MI.Get(StreamKind.Text, i, "Title"), "SDH");

                if (this.SI[i].subSDH)
                {
                    if (this.SI[i].subForced)
                    {
                        this.SI[i].subInfoFull = this.SI[i].subLang + " (" + this.SI[i].subFormat + ", SDH, Forced)";
                    }
                    else
                    {
                        this.SI[i].subInfoFull = this.SI[i].subLang + " (" + this.SI[i].subFormat + ", SDH)";
                    }
                }
                else
                {
                    if (this.SI[i].subForced)
                    {
                        this.SI[i].subInfoFull = this.SI[i].subLang + " (" + this.SI[i].subFormat + ", Forced)";
                    }
                    else
                    {
                        this.SI[i].subInfoFull = this.SI[i].subLang + " (" + this.SI[i].subFormat + ")";
                    }
                }
            }
        }

        /*-------------------------------------------------------------------------
         * Protected custom methods down below
         * ------------------------------------------------------------------------*/

        /// <summary>
        /// Decide which unit to display the value in, such as MB or GB, Kbps or Mbps, etc.
        /// This is a simplified method, with 2 value variants in the same decimal spaces, and a default critical value of 1000.
        /// </summary>
        /// <param name="paraSmall">Value in the smaller unit.</param>
        /// <param name="paraBig">Value in the bigger unit.</param>
        /// <param name="unitSmall">Smaller unit.</param>
        /// <param name="unitBig">Bigger unit.</param>
        /// <param name="decimals">Decimal spaces for both values.</param>
        /// <returns></returns>
        protected string GetDisplayUnit(double paraSmall, double paraBig, string unitSmall, string unitBig, int decimals)
        {
            return this.GetDisplayUnit(paraSmall, paraBig, 1000, unitSmall, unitBig, decimals, decimals);
        }

        /// <summary>
        /// Decide which unit to display the value in, such as MB or GB, Kbps or Mbps, etc.
        /// </summary>
        /// <param name="paraSmall">Value in the smaller unit.</param>
        /// <param name="paraBig">Value in the bigger unit.</param>
        /// <param name="criteria">Critical value in between.</param>
        /// <param name="unitSmall">Smaller unit.</param>
        /// <param name="unitBig">Bigger unit.</param>
        /// <param name="decimalSmall">Decimal spaces for the value in smaller unit.</param>
        /// <param name="decimalBig">Decimal spaces for the value in bigger unit.</param>
        /// <returns></returns>
        protected string GetDisplayUnit(double paraSmall, double paraBig, double criteria, string unitSmall, string unitBig,
            int decimalSmall, int decimalBig)
        {
            string result;
            if (paraSmall < criteria)
            {
                result = Math.Round(paraSmall, decimalSmall).ToString() + " " + unitSmall;
            }
            else
            {
                result = Math.Round(paraBig, decimalBig).ToString() + " " + unitBig;
            }
            return result;
        }

        // Get the size of the selected file.
        protected string GetFileSize(string paraFileSize)
        {
            // Calculate the file size.
            Int64 fileSizeBytes = Convert.ToInt64(paraFileSize);
            double fileSizeMBytes;
            double fileSizeGBytes;
            string result;

            // Display the file size in proper format. If it's smaller than 1GB, then display it in MB.
            // Otherwise, display it in GB.
            fileSizeMBytes = Convert.ToDouble(fileSizeBytes) / (1024 * 1024);
            fileSizeGBytes = fileSizeMBytes / 1024;
            result = this.GetDisplayUnit(fileSizeMBytes, fileSizeGBytes, "MB", "GB", 2);
            return result;
        }

        // Calculate the duration.
        protected string GetDuration(string paraDuration)
        {
            Int64 durationMilliSecond = Convert.ToInt64(paraDuration);
            string result;
            DateTime duration = new DateTime(durationMilliSecond * 10000);
            result = duration.ToString("HH") + "h " + duration.ToString("mm") + "mn " + duration.ToString("ss") + "s";
            return result;
        }

        // Calculate the bitrate.
        protected string GetBitrate(string paraBitrate)
        {
            string result;
            Int32 bitrate = Convert.ToInt32(paraBitrate);
            double bitrateKbps = bitrate / 1000;
            double bitrateMbps = bitrateKbps / 1000;
            result = this.GetDisplayUnit(bitrateKbps, bitrateMbps, 10000, "Kbps", "Mbps", 0, 1);
            return result;
        }

        protected string GetChannels(string paraChan)
        {
            string result;
            switch (paraChan)
            {
                case "1":
                    result = "1.0";
                    break;
                case "2":
                    result = "2.0";
                    break;
                case "3":
                    result = "2.1";
                    break;
                case "4":
                    result = "4.0";
                    break;
                case "5":
                    result = "4.1";
                    break;
                case "6":
                    result = "5.1";
                    break;
                case "8":
                    result = "7.1";
                    break;
                default:
                    result = "Unknown";
                    break;
            }
            return result + " channels";
        }

        /// <summary>
        /// Determine if something is something, by checking if the full string contains a sub string.
        /// </summary>
        /// <param name="strFull">Full string.</param>
        /// <param name="strSub">Sub string.</param>
        /// <returns>True or False.</returns>
        protected bool isSomething(string strFull, string strSub)
        {
            if (strFull.Contains(strSub))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool isYesOrNo(string paraYesOrNo)
        {
            if (paraYesOrNo.Contains("Yes"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*-------------------------------------------------------------------------
         * Protected custom methods up above
         * ------------------------------------------------------------------------*/

    }
}