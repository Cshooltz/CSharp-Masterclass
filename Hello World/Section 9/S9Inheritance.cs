using System;
using System.Timers;
using System.Collections.Generic;
using System.Text;

namespace CSMasterClass
{
    // This file is for lesson 103 in Section 9
    class S9Inheritance
    {
        public static void Run()
        {
            Post post1 = new Post("Thanks for the birthday wishes", true, "Collin");
            Console.WriteLine(post1);

            ImagePost imagePost1 = new ImagePost("Check out my new shoes!", "Collin", "https://images.com/shoes", true);
            Console.WriteLine(imagePost1);

            VideoPost videoPost1 = new VideoPost("Check out this sweet new game!", "Collin", "https://videos.com/game", 15, true);
            Console.WriteLine(videoPost1);

            Console.WriteLine("Press any key to stop the video.");
            videoPost1.Play();
            Console.ReadKey();
            if (videoPost1.IsPlaying) videoPost1.Stop();

            return;
        }
    }

    class Post
    {
        private static int currentPostId;

        // Properties
        protected int ID { get; set; }
        protected string Title { get; set; }
        protected string SendByUsername { get; set; }
        protected bool IsPublic { get; set; }

        public Post()
        {
            ID = 0;
            Title = "My First Post";
            IsPublic = true;
            SendByUsername = "Rayleigh Tridith";
        }

        // Instance constructor
        public Post(string title, bool isPublic, string sendByUsername)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.SendByUsername = sendByUsername;
            this.IsPublic = isPublic;
        }

        protected int GetNextID()
        {
            return ++currentPostId;
        }

        public void Update(string title, bool isPublic)
        {
            this.Title = title;
            this.IsPublic = isPublic;
        }

        public override string ToString()
        {
            return $"{this.ID} - {this.Title} - by {SendByUsername}";
            // could also use String.Format("{0} - {1} - by {2}", this.ID, this.Title, SendByUsername);
        }
    }

    class ImagePost:Post
    {
        public string ImageURL { get; set; }

        public ImagePost()
        {

        }

        public ImagePost(string title, string sendByUsername, string imageURL, bool isPublic)
        {
            this.GetNextID();
            this.Title = title;
            this.SendByUsername = sendByUsername;
            this.IsPublic = isPublic;

            this.ImageURL = imageURL;
        }

        public override string ToString()
        {
            return $"{this.ID} - {this.Title} - {this.ImageURL} - by {SendByUsername}";
        }

    }

    class VideoPost : Post
    {
        public string VideoURL { get; set; }
        public int VideoLength { get; set; } // in seconds
        protected Timer VideoTimer;
        protected DateTime StartTime;
        protected double StopTime { get; set; }
        public bool IsPlaying { get; set; } = false;
        

        public VideoPost()
        {

        }

        public VideoPost(string title, string sendByUsername, string videoURL, int videoLength, bool isPublic)
        {
            this.GetNextID();
            this.Title = title;
            this.SendByUsername = sendByUsername;
            this.IsPublic = isPublic;

            this.VideoURL = videoURL;
            this.VideoLength = videoLength;
        }

        public override string ToString()
        {
            return $"{this.ID} - {this.Title} - {this.VideoURL} - {this.VideoLength} - by {SendByUsername}";
        }

        public void Play()
        {
            if (IsPlaying) return;
            int MaxEntries = 10;
            int CurrentEntries = 0;
            
            StartTime = DateTime.Now;
            VideoTimer = new Timer(1000);
            VideoTimer.Elapsed += VideoElapsed;
            VideoTimer.AutoReset = true;
            
            StartTime = DateTime.Now;
            VideoTimer.Enabled = true;
            IsPlaying = true;
            Console.Write("Time elapsed (s): ");
            return;

            void VideoElapsed(Object source, ElapsedEventArgs e)
            {
                StopTime = e.SignalTime.Subtract(StartTime).TotalSeconds;
                Console.Write($"{(int)StopTime} ");
                CurrentEntries++;
                if (CurrentEntries >= MaxEntries)
                {
                    Console.WriteLine("");
                    CurrentEntries = 0;
                }
                if (StopTime >= (double)VideoLength) Stop();
                return;
            }
        }

        public void Play(int startTime)
        {
            // This is a stub.
            Console.WriteLine("Play(int startTime) is a stub.");
            return;
        }

        public void Stop()
        {
            try
            {
                if (VideoTimer.Enabled == true)
                {
                    VideoTimer.Enabled = false;
                    StopTime = DateTime.Now.Subtract(StartTime).TotalSeconds;
                    if (StopTime >= (double)VideoLength) Console.WriteLine($"\nVideo completed at {VideoLength} seconds.");
                    else Console.WriteLine($"\nVideo stopped at {StopTime} seconds.");
                    VideoTimer.Dispose();
                    IsPlaying = false;
                }
            }
            catch
            {
                Console.WriteLine("Timer could not be disposed of correctly.");
            }
            return;
        }
    }
}
