using Microsoft.EntityFrameworkCore;
using ObjectiveTestExercise.Context.Models;

namespace ObjectiveTestExercise.Context
{
    public class ObjectiveContext : DbContext
    {
        public ObjectiveContext(DbContextOptions<ObjectiveContext> options)
        : base(options)
        {

        }

        public DbSet<Subscribe> Subscribes { get; set; }
    }
}
