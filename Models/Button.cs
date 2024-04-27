namespace TodoList.Models.Button
{
    public class ButtonProps
    {
        public string Action { get; set; }
        public string Method { get; set; }
        public string ClassNames { get; set; } = "";
        public string Text { get; set; } = "";
        public List<InputProps> Input { get; set; }
    }
    public class InputProps
    {
        public string? Type { get; set; } = "text";
        public dynamic? Value { get; set; } = "";
        public string? Name { get; set; } = "";
    }
}
