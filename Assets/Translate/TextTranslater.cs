using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CoffeeR.Translate
{
    /// <summary>
    /// 翻訳テキストクラス
    /// </summary>
    public sealed class Translater
    {
        List<TranslatedText> TranslatedTextList;

        public Translater(string csvDatasString)
        {
            TranslatedTextList = new List<TranslatedText>();

            var csvDatas = new List<string[]>();
            var reader = new StringReader(csvDatasString);

            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                csvDatas.Add(line.Split(','));
            }

            for (var i = 1; i < csvDatas.Count; i++)
            {
                TranslatedTextList.Add(new TranslatedText(int.Parse(csvDatas[i][0]), (Language)Enum.Parse(typeof(Language), csvDatas[i][1]), csvDatas[i][2]));
            }
        }

        /// <summary>
        /// 翻訳されたテキストを返す
        /// </summary>
        /// <param name="id">テキストのID</param>
        /// <param name="language">テキストの言語</param>
        /// <returns></returns>
        public string GetText(int id, Language language)
        {
            return TranslatedTextList.Where(x => x.Id == id && x.Language == language).FirstOrDefault().Text;
        }
    }

    /// <summary>
    /// 翻訳されたテキストのクラス
    /// </summary>
    internal sealed class TranslatedText
    {
        public int Id { get; private set; }
        public Language Language { get; private set; }
        public string Text { get; private set; }

        public TranslatedText(int id, Language language, string text)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id is not minus.");
            }

            Id = id;
            Language = language;
            Text = text;
        }

    }

    /// <summary>
    /// 言語
    /// </summary>
    public enum Language
    {
        Japanese,
        English
    }

    /// <summary>
    /// Enumを文字列へ高速にキャストする拡張
    /// </summary>
    public static class LanguageEnumEx
    {
        public static String ToStringFromEnum(this Language value)
        {
            switch (value)
            {
                case Language.Japanese: return "Japanese";
                case Language.English: return "English";
                default: throw new InvalidOperationException();
            }
        }
    }
}