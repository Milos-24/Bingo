using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo;

internal class User
{
    public string name { get; set; }
    public int score { get; set; }
    public int[] numbers { get; set; }
    public User(string name, int score, int[] numbers)
    {
        this.name = name;
        this.score = score;
        this.numbers = numbers;
    }
}
