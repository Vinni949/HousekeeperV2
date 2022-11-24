using HousekeeperV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousekeeperV2.Controllers
{
    public class AdminController
    {
        DBHousekeeper dB = new DBHousekeeper();
        public List<string> AdminHistories()
        {
            List<string> strings = new List<string>();
            var history = dB.histories.ToList();
            foreach (histories histories in history)
            {
                strings.Add(histories.historie);
            }
            return strings; 
        }
        public string AddTeacher(string teacherName)
        {
            if (teacherName != null)
            {
                Teacher teacher = new Teacher();
                teacher.Name = teacherName;
                List<Key> keys = new List<Key>();
                teacher.key = keys;
                dB.Teachers.Add(teacher);
                dB.SaveChanges();
                return "Добавлен преподователь.";
            }
            else
                return "Не введено имя!";
        }
        public string AddKey(string KeyNumber)
        {
            if (KeyNumber != null)
            {
                Models.Key key = new Models.Key();
                key.Name = KeyNumber;
                dB.Keys.Add(key);
                dB.SaveChanges();
                return "Добавлен ключ.";
            }
            else
                return "Не введен ключ!";
        }
        public string DeletedTeacher(int id)
        {
            Teacher teacher = dB.Teachers.SingleOrDefault(s => s.Id == id);
            if (teacher != null)
            {
                dB.Teachers.Remove(teacher);
                dB.SaveChanges();
                return "Преподователь удален.";
            }
            else
                return "Введены не верные данные.";
        }
        public string DeletedKey(int id)
        {
            Key key = dB.Keys.SingleOrDefault(s => s.Id == id);
            if (key != null)
            {
                dB.Keys.Remove(key);
                dB.SaveChanges();
                return "Ключ удален.";
            }
            else
                return "Введены не верные данные!";
        }
    }
}
