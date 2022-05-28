using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class ClientEfConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.Property(c => c.PhoneNumber).HasMaxLength(9).IsRequired();

            builder.HasIndex(c => c.PhoneNumber).IsUnique();

            var clients = new List<Client>()
            {
                new Client {IdPerson = 2, FirstName = "Jan", LastName = "Kowalski", Email = "j.kowalski@gmail.com", Password = new PasswordHasher<Client>().HashPassword(new Client(), "Admin1234#"), Avatar = "https://cdn.pixabay.com/photo/2017/10/11/12/38/sport-2840947_960_720.png", PhoneNumber = "123123123", DateOfBirth = new DateTime(1992,2,2)},
                new Client {IdPerson = 3, FirstName = "Michał", LastName = "Kowalski", Email = "m.kowalski@gmail.com", Password = new PasswordHasher<Client>().HashPassword(new Client(), "Admin13#"), Avatar = null, PhoneNumber = "123123124", DateOfBirth = null},
                new Client {IdPerson = 4, FirstName = "Bartek", LastName = "Kowalski", Email = "b.kowalski@gmail.com", Password = new PasswordHasher<Client>().HashPassword(new Client(), "Admin1444#"), Avatar = null, PhoneNumber = "123123125", DateOfBirth = null},
                new Client {IdPerson = 5, FirstName = "Szymon", LastName = "Kowalski", Email = "s.kowalski@gmail.com", Password = new PasswordHasher<Client>().HashPassword(new Client(), "Admin124534#"), Avatar = null, PhoneNumber = "123123126", DateOfBirth = null},
                new Client {IdPerson = 6, FirstName = "Tymek", LastName = "Kowalski", Email = "t.kowalski@gmail.com", Password = new PasswordHasher<Client>().HashPassword(new Client(), "Admin1265434#"), Avatar = null, PhoneNumber = "123123127", DateOfBirth = null},
                new Client {IdPerson = 7, FirstName = "Magda", LastName = "Kowalska", Email = "m.kowalska@gmail.com", Password = new PasswordHasher<Client>().HashPassword(new Client(), "Admin1756234#"), Avatar = null, PhoneNumber = "123123128", DateOfBirth = null},
                new Client {IdPerson = 8, FirstName = "Ola", LastName = "Kowalska", Email = "o.kowalska@gmail.com", Password = new PasswordHasher<Client>().HashPassword(new Client(), "Admin187234#"), Avatar = null, PhoneNumber = "123123129", DateOfBirth = null},
                new Client {IdPerson = 9, FirstName = "Ewa", LastName = "Kowalska", Email = "e.kowalska@gmail.com", Password = new PasswordHasher<Client>().HashPassword(new Client(), "Admin1287634#"), Avatar = null, PhoneNumber = "123166129", DateOfBirth = null},
            };

            builder.HasData(clients);
        }
    }
}
