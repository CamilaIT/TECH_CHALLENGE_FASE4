namespace Challenge.Producer.Message.Models
{
    public class CreateMessage
    {

        public string Mensagem { get; set; }


        public CreateMessage(string mensagem)
        {

            Mensagem = mensagem;
        }
    }
}
