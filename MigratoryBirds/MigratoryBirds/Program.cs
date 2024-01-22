using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MigratoryBirds
{
  internal class Program
  {
    static void Main(string[] args)
    {
      //var arr = new List<int>{ 1, 4, 4, 4, 5, 3 };
      var src = File.ReadAllText("TextFile1.txt");
      List<int> arr = new List<int>(Array.ConvertAll(src.Split(','), int.Parse));

      int result = migratoryBirds(arr);
      Console.WriteLine(result);
    }

    private static int migratoryBirds(List<int> arr)
    {
      var list = arr.GroupBy(x => x).ToDictionary(p => p.Key, q => q.Count()).OrderByDescending(r=>r.Value).ThenBy(x=>x.Key);
      return list.FirstOrDefault().Key;
    }
  }
}