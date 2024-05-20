class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

   public Reference(string referenceText)
{
    string[] parts = referenceText.Split(' ', ':', '-');

   
    if (parts.Length >= 4)
    {
        _book = parts[0];
        _chapter  = int.Parse(parts[1]);
        _verseStart = int.Parse(parts[2]);
        _verseEnd = int.Parse(parts[3]);
    }
    else
    {
     
    }
}

}
