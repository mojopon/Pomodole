﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodole
{
    public class ConfigurationFileManager : IConfigurationFileManager
    {
        private ConfigurationFileManager() { }
        private static IConfigurationFileManager instance;
        public static IConfigurationFileManager GetInstance()
        {
            if (instance == null)
            {
                if (App.ServiceType == ServiceType.Production)
                {
                    instance = new ConfigurationFileManager();
                }
            }
            return instance;
        }

        public static void SetInstance(IConfigurationFileManager configurationFileManager)
        {
            instance = configurationFileManager;
        }


        public T Load<T>(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            try {
                using (StreamReader reader = new StreamReader(GetFilePath(fileName), new System.Text.UTF8Encoding(false)))
                {
                    T obj = (T)serializer.Deserialize(reader);
                    Console.WriteLine("Load succeed");
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default(T);
            }
        }

        public void Save<T> (T obj, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            try {
                using (StreamWriter writer = new StreamWriter(GetFilePath(fileName), false, new System.Text.UTF8Encoding(false)))
                {
                    Console.WriteLine("File Saved");
                    serializer.Serialize(writer, obj);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private string GetFilePath(string fileName)
        {
            return Directory.GetCurrentDirectory() + @"\" + fileName;
        }
    }
}
