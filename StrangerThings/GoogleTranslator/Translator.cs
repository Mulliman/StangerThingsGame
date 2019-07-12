using Google.Cloud.Translation.V2;

namespace GoogleTranslator
{
    public class Translator
    {
        private readonly string _jsonPath;

        public Translator(string jsonPath)
        {
            _jsonPath = jsonPath;
        }

        public string TranslatePhrase(string phrase, string language)
        {
            var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromFile(_jsonPath);

            TranslationClient client = TranslationClient.Create(credential);
            TranslationResult result = client.TranslateText(phrase, language);

            return result.TranslatedText;
        }

        public string TranslatePhraseToEnglish(string phrase, string language)
        {
            var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromFile(_jsonPath);

            TranslationClient client = TranslationClient.Create(credential);
            TranslationResult result = client.TranslateText(phrase, LanguageCodes.English, language);

            return result.TranslatedText;
        }
    }
}