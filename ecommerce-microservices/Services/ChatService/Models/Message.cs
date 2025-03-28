namespace ChatService.Models
{
    //dbye kaydetme işlemi olsa kullanılacaktı
    public class Message
    {
        public string User { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
