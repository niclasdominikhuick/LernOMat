using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lern_O_Mat
{
    class Controller : IController
    {
        public static String[] currentQuestion;
        public static String[] currentAnswer;
        public static int currentPosition = 0;
        public static int currentWordlength;
        public static Boolean learn = true;

        public static Boolean LoginLogin(String username, String password)
        {
            Boolean result = Model.CheckUser(username, password);

            if (result == true)
            {
                Model.currentUserName = username;
                Model.CheckUserData();
            }

            return result;
        }
        public static String LoginCreateUser(String username, String password)
        {
            if (Model.CheckUser(username, password) == false)
            {
                Model.CreateUser(username, password);
                return "Benutzer wurde erfolgreich erstellt.";
            }
            else
            {
                return "Benutzer existiert bereits.";
            }
        }

        public static IEnumerable<XAttribute> GetWordboxlistController()
        {
            try
            {
                return Model.GetWordboxlist();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void EditWordboxAddWordbox(String question, String answer)
        {
            Model.AddWordbox(question, answer);
        }

        public static void EditWordboxDeleteWordbox(String wordboxname)
        {
            Model.DeleteWordBox(wordboxname);
        }

        public static void EditWordsAddWord(String wordboxname, String question, String answer)
        {
            Model.AddWord(wordboxname, question, answer);
        }

        public static void ConvertCSVtoXML(String wordboxname, String pfad)
        {
            String[] lines = Model.GetCSVData(pfad);

            for (int i = 3; i < lines.Length; i++)
            {
                String[] words = lines[i].Split(';');
                Model.AddWord(wordboxname, words[0], words[1]);
            }
        }

        public static String GetQuestiontopicController(String wordboxname)
        {
            return Model.GetQuestiontopic(wordboxname);
        }

        public static String GetAnswertopicController(String wordboxname)
        {
            return Model.GetAnswertopic(wordboxname);
        }

        public static IEnumerable<XElement> GetQuestionsController(String questiontopic)
        {
            return Model.GetQuestions(questiontopic);
        }

        public static IEnumerable<XElement> GetAnswersController(String answertopic)
        {
            return Model.GetAnswers(answertopic);
        }

        public static String StartLearn(String wordboxname)
        {
            currentWordlength = Controller.GetQuestionsController(Controller.GetQuestiontopicController(wordboxname)).Count();
            currentPosition = 0;
            return "HIER IST ENDE";
        }

        public static String GetLearnQuestion()
        {
            return currentQuestion[currentPosition];
        }

        public static String GetLearnAnswer()
        {
            return currentAnswer[currentPosition];
        }

        public static Boolean LearnCheck(String answer)
        {
            if (answer == currentAnswer[currentPosition])
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
