// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Text;

HtmlBuilder builder = new HtmlBuilder("ul");

builder.AddChild("li", "hello");
builder.AddChild("li", "world");

Console.WriteLine(builder);