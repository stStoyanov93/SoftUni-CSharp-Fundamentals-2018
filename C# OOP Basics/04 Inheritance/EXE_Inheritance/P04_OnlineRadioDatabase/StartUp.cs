using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_OnlineRadioDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numberOfSongs = int.Parse(Console.ReadLine());
            var songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                var inputParams = Console.ReadLine().Split(';');
                var artistName = inputParams[0];
                var songName = inputParams[1];

                try
                {
                    var time = inputParams[2]
                        .Split(':')
                        .Select(int.Parse)
                        .ToArray();

                    var inputMinutes = time[0];
                    var inputSeconds = time[1];

                    var song = new Song(artistName, songName, inputMinutes, inputSeconds);
                    songs.Add(song);
                    Console.WriteLine($"Song added.");
                }
                catch (InvalidSongException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid song length.");
                }
            }

            var minutes = songs.Sum(m => m.Minutes);

            var seconds = songs.Sum(s => s.Seconds);
            seconds += minutes * 60;

            var remainingMinutes = seconds / 60;
            var remainingSeconds = seconds % 60;
            var hours = remainingMinutes / 60;
            remainingMinutes %= 60;

            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: {hours}h {remainingMinutes}m {remainingSeconds}s");
        }
    }
}
