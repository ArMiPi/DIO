namespace BankAccounts
{
    public class Client
    {
        public string Name { get; private set; }
        private int id; // RG, CPF or CNPJ
        private string email;

        public Client(string name, int id, string email)
        {
            this.Name = name;
            this.id = id;
            this.email = email;
        }

        public int GetID()
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