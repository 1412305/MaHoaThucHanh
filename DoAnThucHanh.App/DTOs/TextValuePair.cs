namespace DoAnThucHanh.App.DTOs
{
    public class TextValuePair
    {
        public TextValuePair(string text, int value)
        {
            this.Text = text;
            this.Value = value;
        }

        public string Text { get; set; }

        public int Value { get; set; }
    }
}
