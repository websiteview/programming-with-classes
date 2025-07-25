using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("The Future of AI", "TechSavvy", 320);
        video1.AddComment(new Comment("Alice", "This was super informative."));
        video1.AddComment(new Comment("Bob", "Loved the graphics!"));
        video1.AddComment(new Comment("Charlie", "AI is going to change everything."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Baking 101", "ChefMia", 540);
        video2.AddComment(new Comment("Daisy", "Looks so yummy!"));
        video2.AddComment(new Comment("Eli", "Tried it, came out great."));
        video2.AddComment(new Comment("Fiona", "Can you do gluten-free next time?"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Workout for Beginners", "FitLife", 600);
        video3.AddComment(new Comment("George", "This really helped my routine."));
        video3.AddComment(new Comment("Hannah", "I was sweating in 5 minutes!"));
        video3.AddComment(new Comment("Isaac", "Can you make a 10-minute version?"));
        videos.Add(video3);

        // Display each video and its comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
