using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Duration { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int duration)
    {
        Title = title;
        Author = author;
        Duration = duration;
        Comments = new List<Comment>();
    }
}

class Comment
{
    public string Text { get; set; }
    public string CommenterName { get; set; }

    public Comment(string text, string commenterName)
    {
        Text = text;
        CommenterName = commenterName;
    }
}

class Program1
{
    static void Main(string[] args)
    {
        Video video = new Video("Introduction to Programming", "John Doe", 120);
        video.Comments.Add(new Comment("Great video!", "Alice"));
        video.Comments.Add(new Comment("Thanks for sharing!", "Bob"));

        Console.WriteLine("Video Details:");
        Console.WriteLine($"Title: {video.Title}");
        Console.WriteLine($"Author: {video.Author}");
        Console.WriteLine($"Duration: {video.Duration} seconds");
        Console.WriteLine("Comments:");
        foreach (Comment comment in video.Comments)
        {
            Console.WriteLine($"- {comment.Text} (By: {comment.CommenterName})");
        }
    }
}
