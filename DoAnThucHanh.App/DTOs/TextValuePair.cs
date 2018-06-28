namespace DoAnThucHanh.App.DTOs
{
    public class TextValuePair
    {
        public TextValuePair(object text, object value)
        {
            this.Text = text;
            this.Value = value;
        }

        public object Text { get; set; }

        public object Value { get; set; }
    }
}
