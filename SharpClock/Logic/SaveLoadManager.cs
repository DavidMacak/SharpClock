using System;
using System.Collections.Generic;
using System.IO;

namespace SharpClock.Logic
{
    public class SaveLoadManager
    {
        /* TODO
         * opravit padání programu když neexistuje txt
         * 
         * Upravit záznam
         * Smazat záznam
         * 
         */

        string path = "lessons.txt";

        public void CheckFile()
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        public void SaveFile()
        {
            CheckFile();

        }

        public void AddNewRecord(string elapsedTime)
        {
            CheckFile();

            using StreamWriter file = new(path,append:true);
            file.WriteLine("{0} {1} {2}", DateTime.Now.Date.ToString("dd/MM/yyyy"), elapsedTime, GetTitle());
        }

        public void EditRecord()
        {
            CheckFile();

        }

        public void DeleteRecord()
        {
            CheckFile();

        }

        public string GetTitle()
        {
            string output;

            var dialog = new GetTitleDialog();

            dialog.ShowDialog();

            output = dialog.DialogTextBox.Text;

            return output;
        }

        public List<Lesson> GetRecords()
        {
            CheckFile();

            List<Lesson> lessons = new List<Lesson>();

            foreach(string line in File.ReadLines(path))
            {
                Lesson lesson = new Lesson();
                string[] lessonInfo = GetDateString(line);

                lesson.LessonDate = lessonInfo[0];
                lesson.LessonDuration = lessonInfo[1];
                lesson.Title = lessonInfo[2];

                lessons.Add(lesson);
            }

            return lessons;
        }

        private string[] GetDateString(string line)
        {
            string[] output = line.Split(' ', 3);
            return output;
        }

    }
}
