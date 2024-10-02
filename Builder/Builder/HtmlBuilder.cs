using System.Runtime.CompilerServices;

class HtmlBuilder{
    private string rootName;

    public HtmlElement root = new HtmlElement();

    public HtmlBuilder(string rootName)
    {
        this.rootName = rootName;
        root.Name = rootName;
    }

    public void AddChild(string childName, string childText)
    {
        HtmlElement e = new HtmlElement(childName, childText);
        root.ChildElements.Add(e);
    }

    public override string ToString()
    {
        return root.ToString();
    }
}