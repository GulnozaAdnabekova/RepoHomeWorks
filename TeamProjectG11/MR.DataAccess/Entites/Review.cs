using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MR.DataAccess.Entites;

public class Review
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public RatingMovie Rating{get; set;}
    public string? Comment {  get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;

    //public movieId int
}
public enum RatingMovie
{
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10
}

