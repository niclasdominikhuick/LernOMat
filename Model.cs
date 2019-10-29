using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace Lern_O_Mat
{
    class Model : IModel
    {
        public static String currentUserName;

        public static Boolean CheckUser(String username, String password)
        {
            XDocument doc = XDocument.Load("Database.xml");
            IEnumerable<XElement> userlist = doc.Descendants("user").Where(e => e.Element("name").Value == username).Where(e => e.Element("password").Value == password);
            return Convert.ToBoolean(userlist.ToList<XElement>().Count);
        }
        public static void CreateUser(String username, String password)
        {
            XDocument doc = XDocument.Load("Database.xml");
            doc.Element("userlist").Add(
                new XElement("user",
                    new XElement("name", username),
                    new XElement("password", password)
                )
            );

            doc.Save("Database.xml");
        }

        public static void CheckUserData()
        {
            try
            {
                XDocument udoc = XDocument.Load(currentUserName + ".xml");
            }
            catch (Exception)
            {
                XDocument udoc = new XDocument(
                    new XElement("wordboxlist"
                    )
                );

                udoc.Save(currentUserName + ".xml");
            }
        }

        public static IEnumerable<XAttribute> GetWordboxlist()
        {
            XDocument udoc = XDocument.Load(currentUserName + ".xml");
            IEnumerable<XAttribute> wordboxlist = udoc.Descendants("wordboxlist").Elements().Attributes();
            return wordboxlist;
        }

        public static void AddWordbox(String questiontopic, String answertopic)
        {
            XDocument udoc = XDocument.Load(currentUserName + ".xml");
            udoc.Element("wordboxlist").Add(
                    new XElement(questiontopic + "-" + answertopic,
                        new XAttribute("wordboxname", questiontopic + "-" + answertopic),
                        new XElement("questiontopic", questiontopic),
                        new XElement("answertopic", answertopic),
                        new XElement("words")
                                )
                        );

            udoc.Save(currentUserName + ".xml");
        }

        public static void DeleteWordBox(String wordboxname)
        {
            XDocument udoc = XDocument.Load(currentUserName + ".xml");
            udoc.Element("wordboxlist").Element(wordboxname).RemoveAll();
            udoc.Save(currentUserName + ".xml");
        }

        public static void AddWord(String wordboxname, String question, String answer)
        {
            XDocument udoc = XDocument.Load(currentUserName + ".xml");
            udoc.Element("wordboxlist").Element(wordboxname).Element("words").Add(
                new XElement("word",
                    new XElement("position", 1),
                    new XElement(udoc.Element("wordboxlist").Element(wordboxname).Element("questiontopic").Value, question),
                    new XElement(udoc.Element("wordboxlist").Element(wordboxname).Element("answertopic").Value, answer)
                            )
                        );

            udoc.Save(currentUserName + ".xml");
        }

        public static String GetQuestiontopic(String wordboxname)
        {
            XDocument udoc = XDocument.Load(currentUserName + ".xml");
            return udoc.Element("wordboxlist").Element(wordboxname).Element("questiontopic").Value;
        }

        public static String GetAnswertopic(String wordboxname)
        {
            XDocument udoc = XDocument.Load(currentUserName + ".xml");
            return udoc.Element("wordboxlist").Element(wordboxname).Element("answertopic").Value;
        }

        public static IEnumerable<XElement> GetQuestions(String questiontopic)
        {
            XDocument udoc = XDocument.Load(currentUserName + ".xml");
            return udoc.Descendants("word").Elements(questiontopic);
        }

        public static IEnumerable<XElement> GetAnswers(String answertopic)
        {
            XDocument udoc = XDocument.Load(currentUserName + ".xml");
            return udoc.Descendants("word").Elements(answertopic);
        }

        public static String[] GetCSVData(String pfad)
        {
            String[] lines = File.ReadAllLines(pfad);
            return lines;
        }
    }
}
