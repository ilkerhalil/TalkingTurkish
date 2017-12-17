namespace TalkingTurkishCore.Exception
{
    public class NotFoundLanguage : System.Exception
    {
        public NotFoundLanguage(string code)
            :base($"Languge not found {code}")
        {
            
        }

    }
}