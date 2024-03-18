using System.Text.Json;
using System.Text.RegularExpressions;

namespace HTMLParser
{
    public class CodeParser
    {
        public CodeParser(string valueToBeParsed)
        {
            ValueToBeParsed = valueToBeParsed;
        }

        public string ValueToBeParsed { get; set; }
        public void Parse()
        {
            IdentityElements(0, ValueToBeParsed.Length - 1);
        }

        public void IdentityElements(int start, int end)
        {
            int i = start;
            while (i >= 0 && i <= end)
            {
                if (ValueToBeParsed[i] == '.' && ValueToBeParsed[i - 1] != ')')
                {
                    Console.WriteLine(ValueToBeParsed[start..i]);
                    IdentityElements(i + 1, end);
                    i = -1;
                }
                else if (ValueToBeParsed[i] == '(')
                {
                    Console.WriteLine($"method name: {ValueToBeParsed[start..i]}");
                    var parameters = ValueToBeParsed[(i + 1)..];

                    parameters = Regex.Replace(parameters, "[)\\]].?(\\w)*", string.Empty);

                    var parameterList = parameters.Split(',');
                    string jsonString = JsonSerializer.Serialize(parameterList);
                    Console.WriteLine($"parameters: {jsonString}");
                    IdentityElements(i + 1 + parameters.Length + 2, end);
                    i = -1;
                }
                else
                {
                    i++;
                }
            }
            if (i > 0)
            {
                if (ValueToBeParsed[start..i].Length > 0)
                {
                    Console.WriteLine(ValueToBeParsed[start..i]);
                }
            }
        }
    }
}
