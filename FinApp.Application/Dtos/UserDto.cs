namespace FinApp.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserDto(int id, string uid , string name, string email)
        {
            Id = id;
            Uid = uid;
            Name = name;
            Email = email;
        }
    }
}
