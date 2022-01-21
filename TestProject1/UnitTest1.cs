using System;
using System.Linq;
using WorldeSolver;
using Xunit;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var word = "drink";
        Assert.Equal(1, word.IndexOf("r", StringComparison.Ordinal));
    }
    
    
    [Fact]
    public void Test2()
    {
        var wordCache = Words.GetWords();
        
        wordCache = wordCache.Where(x => !x.Contains('s')).ToArray();
        wordCache = wordCache.Where(x => !x.Contains('t')).ToArray();
        wordCache = wordCache.Where(x => !x.Contains('u')).ToArray();
        wordCache = wordCache.Where(x => !x.Contains('m')).ToArray();
        wordCache = wordCache.Where(x => x.Contains('p')).ToArray();
        
        Assert.DoesNotContain("tweed", wordCache);
        
    }
}