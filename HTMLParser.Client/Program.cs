using HTMLParser;
using HtmlParser = HTMLParser.HtmlParser;

var directory = Directory.GetCurrentDirectory();
var filePath = Path.Combine(directory, "HtmlFiles\\ExamplePage1.html");

using FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);
var htmlParser = new HtmlParser();
//var parsed = htmlParser.Parse(fileStream);

htmlParser.ParseValuesOneByOne(fileStream);

//foreach (var item in parsed)
//{
//    Console.WriteLine($"{item.Text}, {item.TextValue}");
//}

Console.WriteLine();
var codeParser = new CodeParser("Object1.Object2.Show(\"something\", 2, 2.3).Object3");
codeParser.Parse();
