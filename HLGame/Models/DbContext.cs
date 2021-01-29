using HLGame.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HLGame.Models
{
    public class DbContext : IDBContext
    {
        const string path = @"C:\Scores\HighScores.xml";
        public IGame GetGame(int ID)
        {
            throw new NotImplementedException();
        }

        public IHighScore[] GetHighScores()
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<IHighScore[]>(json);
            }

        }

        public bool SaveGame()
        {
            throw new NotImplementedException();
        }

        public bool SaveHighScore(IHighScore Score)
        {
            var Scores = GetHighScores();

            var limittotop3 = true;
            int iteration = 0 ;
            foreach(var RecordScore in Scores)
            {
                if (Score.Time < RecordScore.Time)
                {
                    break;
                }
                iteration += 1;
            }

            Scores.ToList().Insert(iteration, Score);


            string json = JsonConvert.SerializeObject(Scores);
            //write string to file
            System.IO.File.WriteAllText(path, json);

            return true;

        }
    }
}
