﻿using System.Configuration;

namespace FASTrack.Infrastructure
{
    public class FastrackConfig
    {
        private const int _PAGESIZE = 15;
        private const int _PORT = 25;
        private const string _HOST = "smtp.atmel.com";
        private const string _FROM = "no-reply-acpcron@atmel.com";
        private const string _USERNAME = "no-reply-acpcron";
        private const string _PASSWORD = "no-reply-acpcron";
        private const string _EMAIL_ADMIN = "alexander.diez@atmel.com";

        //format file image upload
        private const string _FILE_EXTENSION = "jpg,png,jpeg,gif,bmp,tif,tiff|images/*";

        public static int PAGESIZE
        {
            get
            {
                AppSettingsReader settingsReader = new AppSettingsReader();
                int pagesize = _PAGESIZE;
                try
                {
                    pagesize = (int)settingsReader.GetValue("PAGESIZE", typeof(int));
                }
                catch { pagesize = _PAGESIZE; }

                return pagesize;
            }
        }

        public static int PORT
        {
            get
            {
                AppSettingsReader settingsReader = new AppSettingsReader();
                int port = _PORT;
                try
                {
                    port = (int)settingsReader.GetValue("PORT", typeof(int));
                }
                catch { port = _PORT; }

                return port;
            }
        }

        public static string HOST
        {
            get
            {
                AppSettingsReader settingsReader = new AppSettingsReader();
                string host = _HOST;
                try
                {
                    host = (string)settingsReader.GetValue("HOST", typeof(string));
                }
                catch { host = _HOST; }

                return host;
            }
        }

        public static string FROM
        {
            get
            {
                AppSettingsReader settingsReader = new AppSettingsReader();
                string from = _FROM;
                try
                {
                    from = (string)settingsReader.GetValue("FROM", typeof(string));
                }
                catch { from = _FROM; }

                return from;
            }
        }

        public static string USERNAME
        {
            get
            {
                AppSettingsReader settingsReader = new AppSettingsReader();
                string userName = _USERNAME;
                try
                {
                    userName = (string)settingsReader.GetValue("USERNAME", typeof(string));
                }
                catch { userName = _USERNAME; }

                return userName;
            }
        }

        public static string PASSWORD
        {
            get
            {
                AppSettingsReader settingsReader = new AppSettingsReader();
                string pass = _PASSWORD;
                try
                {
                    pass = (string)settingsReader.GetValue("PASSWORD", typeof(string));
                }
                catch { pass = _PASSWORD; }

                return pass;
            }
        }

        public static string EMAIL_ADMIN
        {
            get
            {
                AppSettingsReader settingsReader = new AppSettingsReader();
                string email = _EMAIL_ADMIN;
                try
                {
                    email = (string)settingsReader.GetValue("EMAILADMIN", typeof(string));
                }
                catch { email = _EMAIL_ADMIN; }

                return email;
            }
        }

        public static string FILEEXTENSION
        {
            get
            {
                AppSettingsReader settingsReader = new AppSettingsReader();
                string fileExtension = _FILE_EXTENSION;
                try
                {
                    fileExtension = (string)settingsReader.GetValue("FILEEXTENSION", typeof(string));
                }
                catch { fileExtension = _FILE_EXTENSION; }

                return fileExtension;
            }
        }
    }
}