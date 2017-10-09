using SQLite.Net.Attributes;

namespace TimeScale.Model
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Nome: {0}", Name);
        }
    }
}
