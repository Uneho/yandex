using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thirdYandexCopy
{
    internal class Program
    {
        static int[] CalculateSecondaryScores(int n, int[] scores)
        {
            int[] secondaryScores = new int[scores.Length];

            for (int i = 0; i < scores.Length; i++)
            {
                int primaryScore = scores[i];
                int secondaryScore = 0;

                if (primaryScore > 0)
                {
                    secondaryScore += primaryScore * primaryScore;
                }

                if (i < scores.Length - 1 && primaryScore > 0)
                {
                    int bonusScore = Math.Min(primaryScore, scores[i + 1]);
                    secondaryScore += bonusScore;
                }

                secondaryScores[i] = secondaryScore;
            }

            return secondaryScores;
        }

        static int CalculateTotalScore(int[] secondaryScores)
        {
            int totalScore = 0;

            foreach (int score in secondaryScores)
            {
                totalScore += score;
            }

            return totalScore;
        }

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]); // максимальное количество первичных баллов
            int m = int.Parse(input[1]); // количество оценок критериев

            int[] scores = new int[m];

            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < m; i++)
            {
                scores[i] = int.Parse(input[i]);
            }

            int[] secondaryScores = CalculateSecondaryScores(n, scores);
            int totalScore = CalculateTotalScore(secondaryScores);

            Console.WriteLine(totalScore);

            Console.Read();
        }
    }
}
