namespace BankAccounts
{
    public class Client
    {
        public string Name { get; private set; }
        private string id; // RG, CPF or CNPJ
        private string email;

        public Client(string name, string id, string email)
        {
            this.Name = name;
            this.id = id;
            this.email = email;
        }

        public string GetID()
        {
            return id;
        }

        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }
    }
}