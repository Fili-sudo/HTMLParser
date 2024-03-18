using System.Text.RegularExpressions;

namespace HTMLParser
{
    public class HtmlParser
    {
        private const string _pattern = "@[A-Za-z_0-9]*";
        private readonly Regex _regex = new(_pattern, RegexOptions.Compiled);

        public IEnumerable<HtmlExpression> Parse(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                var stringed = reader.ReadToEnd();
                return _regex.Matches(stringed)
                    .Select(x => new HtmlExpression()
                    {
                        Text = x.Value,
                        TextValue = x.Value.TrimStart('@')
                    }).DistinctBy(x => x.TextValue)
                    .ToList();
            }
        }

        public void ParseValuesOneByOne(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                var stringed = reader.ReadToEnd();
                var match = _regex.Match(stringed);

                while (match.Success)
                {
                    var htmlExpression = new HtmlExpression()
                    {
                        Text = match.Value,
                        TextValue = match.Value.TrimStart('@')
                    };
                    Console.WriteLine($"{htmlExpression.TextValue}, {htmlExpression.Text}");

                    match = match.NextMatch();
                }
            }
        }

        private string ReplaceOccurrence(Match match)
        {
            return "x";
        }
    }
}
