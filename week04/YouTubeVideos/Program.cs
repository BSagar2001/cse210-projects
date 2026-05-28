using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Basics Tutorial", "CodeMaster", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful."));
        video1.AddComment(new Comment("Charlie", "Thanks for explaining clearly."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Learn OOP in C#", "TechGuru", 850);
        video2.AddComment(new Comment("David", "OOP finally makes sense."));
        video2.AddComment(new Comment("Saiki", "Excellent examples."));
        video2.AddComment(new Comment("Arisu", "This helped with my homework."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Top 10 Coding Tips", "DevWorld", 420);
        video3.AddComment(new Comment("Grace", "Tip #4 was awesome."));
        video3.AddComment(new Comment("Mahesh", "Really informative."));
        video3.AddComment(new Comment("Karina", "I learned a lot."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("How to Build Classes", "ProgrammingPro", 720);
        video4.AddComment(new Comment("Laura", "Nice explanation."));
        video4.AddComment(new Comment("Karen", "Very easy to follow."));
        video4.AddComment(new Comment("Leo", "Can you make more videos like this?"));
        videos.Add(video4);

        // Display videos and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine();
        }
    }
}