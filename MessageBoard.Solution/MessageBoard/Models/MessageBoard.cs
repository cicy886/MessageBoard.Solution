using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public MessageBoardContext(DbContextOptions<MessageBoardContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Message>()
          .HasData(
              new Message { MessageId = 1, UserName = "Matilda", Age = 17, Date = "11-14-2021", MessageDescription = "hey pablo " },
              new Message { MessageId = 2, UserName = "Rexie", Age = 21, Date = "06-31-1908", MessageDescription = "oooooh you nasty" },
              new Message { MessageId = 3, UserName = "Matilda", Age = 35, Date = "09-26-1998", MessageDescription = "who are you sisi" },
              new Message { MessageId = 4, UserName = "Pip", Age = 15, Date = "02-10-1996", MessageDescription = "My butt itches"},
              new Message { MessageId = 5, UserName = "Bartholomew", Age = 22, Date = "11-15-1999", MessageDescription = "ya that sisi is one looker" }
          );
    }
    public DbSet<Message> Messages { get; set; }
  }
}