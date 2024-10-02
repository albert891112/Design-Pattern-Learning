using System.Runtime.CompilerServices;
using System.Text;

class HtmlElement{
    public string? Name { get; set; }
    public string? Text { get; set; }

    private const int numSpace = 2;

    public List<HtmlElement> ChildElements { get; set; } = new List<HtmlElement>();

    public HtmlElement(){}
    public HtmlElement(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public  string ToStringImpl(int indent){

        StringBuilder sb = new StringBuilder();
        string i = new string(' ', numSpace * indent);

        sb.AppendLine($"{i}<{Name}>");
        if(!string.IsNullOrWhiteSpace(Text)){
            sb.Append(new string(' ', numSpace * (indent + 1)));
            sb.AppendLine(Text);
        }
        foreach(var c in ChildElements){
            sb.Append(c.ToStringImpl(indent + 1));
        }

        sb.AppendLine($"{i}</{Name}>");

        return sb.ToString();
    }


    public override string ToString()
    {
        return ToStringImpl(0);
    }
}