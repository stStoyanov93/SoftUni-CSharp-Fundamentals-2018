namespace Forum.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Forum.Models;

    public class DataMapper
    {
        private const string DATA_PATH = "../data/";
        private const string CONFIG_PATH = "config.ini";
        private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

        private static readonly Dictionary<string, string> config;

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

        private static void EnsureConfigFile(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                File.WriteAllText(configFilePath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static Dictionary<string, string> LoadConfig(string configFilePath)
        {
            EnsureConfigFile(configFilePath);

            var content = ReadLines(configFilePath);

            var config = content
                .Select(l => l.Split('='))
                .ToDictionary(t => t[0], t => DATA_PATH + t[1]);

            return config;
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);

            var lines = File.ReadAllLines(path);

            return lines;
        }

        private static void WriteLines (string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        public static List<Category> LoadCategories()
        {
            var categories = new List<Category>();

            var dataLines = ReadLines(config["categories"]);

            foreach (var l in dataLines)
            {
                var arguments = l.Split(";", StringSplitOptions.RemoveEmptyEntries);

                var id = int.Parse(arguments[0]);
                var name = arguments[1];
                var postIds = arguments[2]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var category = new Category(id, name, postIds);

                categories.Add(category);
            }

            return categories;
        }

        public static void SaveCategories(List<Category> categories)
        {
            List<string> lines = new List<string>();

            foreach (var category in categories)
            {
                const string categoryFormat = "{0};{1};{2}";
                string line = string.Format(categoryFormat, category.Id, category.Name, string.Join(",", category.PostIds));

                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            var dataLines = ReadLines(config["users"]);

            foreach (var l in dataLines)
            {
                var arguments = l.Split(";");
                var id = int.Parse(arguments[0]);
                var username = arguments[1];
                var password = arguments[2];

                List<int> postIds = new List<int>();

                if (arguments[3].Length != 0)
                {
                    postIds = arguments[3]
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
                }

                var user = new User(id, username, password, postIds);

                users.Add(user);

            }

            return users;
        }

        public static void SaveUsers(List<User> users)
        {
            List<string> lines = new List<string>();

            foreach (var user in users)
            {
                const string userFormat = "{0};{1};{2};{3}";
                string line = string.Format(userFormat, user.Id, user.Username, user.Password, string.Join(",", user.PostIds));

                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }

        public static List<Post> LoadPosts()
        {
            List<Post> posts = new List<Post>();
            var dataLines = ReadLines(config["posts"]);

            foreach (var l in dataLines)
            {
                var arguments = l.Split(";");
                var id = int.Parse(arguments[0]);
                var title = arguments[1];
                var content = arguments[2];
                var categoryId = int.Parse(arguments[3]);
                var authorId = int.Parse(arguments[4]);

                List<int> replyIds = new List<int>();

                if (arguments[5].Length != 0)
                {
                    replyIds = arguments[5]
                       .Split(',', StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToList();
                }

                var post = new Post(id, title, content, categoryId, authorId, replyIds);
                posts.Add(post);
            }

            return posts;
        }

        public static void SavePosts(List<Post> posts)
        {
            List<string> lines = new List<string>();

            foreach (var post in posts)
            {
                const string postFormat = "{0};{1};{2};{3};{4};{5}";
                string line = string.Format(postFormat, post.Id, post.Title, post.Content, post.CategoryId, post.AuthorId, string.Join(",", post.ReplyIds));

                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        public static List<Reply> LoadReplies()
        {
            List<Reply> replies = new List<Reply>();
            var dataLines = ReadLines(config["replies"]);

            foreach (var l in dataLines)
            {
                var args = l.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var content = args[1];
                var authorId = int.Parse(args[2]);
                var postIds = int.Parse(args[3]);
                var reply = new Reply(id, content, authorId, postIds);
                replies.Add(reply);
            }

            return replies;
        }

        public static void SaveReplies(List<Reply> replies)
        {
            List<string> lines = new List<string>();

            foreach (var reply in replies)
            {
                const string postFormat = "{0};{1};{2};{3}";
                string line = string.Format(postFormat, reply.Id, reply.Content, reply.AuthorId, reply.PostId);

                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
}
