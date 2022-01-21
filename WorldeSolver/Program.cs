using WorldeSolver;

var word = Words.GetWeightedWord();
var wordCache = Words.GetWords();

Console.WriteLine(word);
var input = Console.ReadLine();

while (!string.Equals(input, "fin", StringComparison.Ordinal))
{
    var intValues = input!.Select(s => int.Parse(s.ToString()))
        .ToArray();

    // 0 - Wrong Letter
    // 1 - Right Letter wrong place
    // 2 - Right Letter right place

    // we have won
    if (intValues.All(v => v == 2))
        break;
    
    for (var i = 0; i < intValues.Length; i++)
    {
        switch (intValues[i])
        {
            // Eliminate the words that contain letters that aren't in the word
            case 0:
                wordCache = wordCache.Where(x => !x.Contains(word[i])).ToArray();
                break;
            
            // Eliminate any word that doesn't have the letters we know about and any that have the right letter in the wrong place
            case 1:
                wordCache = wordCache.Where(x => x.Contains(word[i]) && x.IndexOf(word[i]) != i).ToArray();
                break;
            
            // Get the words with the letter in the right place
            default:
            {
                if (intValues[i] == 2)
                {
                    wordCache = wordCache.Where(x => x.IndexOf(word[i]) == i).ToArray();;
                }

                break;
            }
        }
    }

    word = Words.GetRandomWord(wordCache);
    Console.WriteLine(word);
    input = Console.ReadLine();
}
