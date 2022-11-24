using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HousekeeperV2.Models;
using Microsoft.EntityFrameworkCore;

namespace HousekeeperV2.Controller
{
    internal class Logic
    {
        DBHousekeeper dB = new DBHousekeeper();
        public List<Teacher> OutputAllTeachers()
        {
            using (var client = new DBHousekeeper())
            {
                client.Database.EnsureCreated();
            }
            List<Teacher> teachers = new List<Teacher>();
            teachers = dB.Teachers.ToList();
            return teachers;
        }
        public List<Key> OutputAllKey()
        {
            List<Key> keys = new List<Key>();
            keys = dB.Keys.Where(s => s.teacher == null).ToList();
            return keys;
        }
        public List<string> IssuedKeyList()
        {
            var t = dB.Teachers.Include(s => s.key).Where(s => s.key.Count != 0).ToList();
            List<string> teachers = new List<string>();
            foreach (Teacher teacher in t)
            {
                foreach (Key key in teacher.key)
                {
                    teachers.Add(teacher.Name + " Выдан ключ: " + key.Name);
                }
            }
            return teachers;
        }
        public List<string> HistorusDay()
        {
            string[] date = DateTime.Now.ToString().Split(" ");
            
            List<string> strings = new List<string>();
            var history = dB.histories.ToList();
            foreach (histories histories in history)
            {
                string[] historyData = histories.historie.ToString().Split(" ");
                if (historyData[historyData.Length - 2] == date[date.Length - 2])
                {
                    strings.Add(histories.historie);
                }
            }
            return strings;
        }
        private void HistoriesAdd(string massage)
        {
            string time = DateTime.Now.ToString();
            massage += " дата: " + time;
            histories histories = new histories();
            histories.historie = massage;
            dB.histories.Add(histories);
            dB.SaveChanges();
        }
        public string IssuedTeacherKey(object teacherObj, object keyObj)
        {
            if (teacherObj is Teacher && keyObj is Key)
            {
                Teacher teacher = teacherObj as Teacher;
                Key key = keyObj as Key;

                List<object> result = new List<object>();
                Teacher teacherDb = dB.Teachers.Include(s=>s.key).SingleOrDefault(s => s.Id == teacher.Id);
                Key keyDb = dB.Keys.SingleOrDefault(s => s.Id == key.Id);
                if (teacherDb != null && keyDb != null)
                {
                    teacherDb.key.Add(keyDb);
                    keyDb.teacher = teacherDb;
                    dB.SaveChanges();
                    string message =" Преподавателю: " + teacher.Name + "\n Выдан ключ № " + key.Name;
                    HistoriesAdd(message);
                    return message;
                }
                else
                    return "Выберите преподавателя и ключ";
            }
            else
                return "Выберите преподавателя и ключ";
        }
        public string ReturnTeacherToKey(string teacher)
        {
            if (teacher != null)
            {

                string[] name = teacher.Split(" ");
                Teacher teacherDb = dB.Teachers.SingleOrDefault(s => s.Name == (name[0]+" " + name[1]+" " + name[2]));
                Key key = dB.Keys.SingleOrDefault(s => s.Name == name[name.Length-1]);
                if (teacherDb != null)
                {
                    key.teacher = null;
                    teacherDb.key.Remove(key);
                    dB.SaveChanges();
                    string message = " Преподаватель: " + teacherDb.Name + " вернул ключ";
                    HistoriesAdd(message);
                    return message;
                }
                else
                    return "Нет преподователя в списке";
            }
            else
                return "Выберите преподавателя!";
        }
        public bool InputAdmin(string Log_text, string Pas_text)
        {
            string[] text = new string[2];
            using (StreamReader readtext = new StreamReader("LogAndPass.txt"))
            {
                using (StreamReader fs = new StreamReader("LogAndPass.txt"))
                {
                    int i = 0;
                    while (true)
                    {

                        string temp = fs.ReadLine();
                        if (temp == null) break;
                        text[i] = temp;
                        i++;
                    }
                }
            }

            if (Log_text == text[0] && Pas_text == text[1])
            {
                return true;
            }
            else
                return false;
        }
    }
}
