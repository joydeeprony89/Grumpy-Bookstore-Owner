using System;

namespace Grumpy_Bookstore_Owner
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] customers = new int[] { 1, 0, 1, 2, 1, 1, 7, 5 };
      int X = 3;
      int[] grumpy = new int[] { 0, 1, 0, 1, 0, 1, 0, 1 };
      Solution s = new Solution();
      var answer = s.MaxSatisfied(customers, grumpy, X);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public int MaxSatisfied(int[] customers, int[] grumpy, int x)
    {
      int res = 0, max = 0;

      for (int i = 0, extra = 0; i < grumpy.Length; i++)
      {
        if (grumpy[i] == 0)
          res += customers[i];//take sum when owner isn't grumpy cause this is what greedy looks like
        else
          extra += customers[i];//include in window 

        if (i >= x && grumpy[i - x] == 1)//when we have reached our window limit(x), it's time to slide it
          extra -= customers[i - x];//exclude (i - x)th index value from window

        max = Math.Max(max, extra);//store the maximum extra we can get using super powers
      }
      return res + max;
    }
  }
}
