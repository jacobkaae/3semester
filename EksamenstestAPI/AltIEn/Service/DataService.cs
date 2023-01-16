using System;
using AltIEn.Data;
using AltIEn.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace AltIEn.Service
{
	public class DataService
	{
        private RetContext db { get; }

        public DataService(RetContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Seeder noget nyt data i databasen hvis det er nødvendigt.
        /// </summary>
        public void SeedData()
        {
            Random rnd = new Random();

            //Ingrediens ingrediens = db.Ingredienser.FirstOrDefault();
            //if (ingrediens == null)
            //{
            //    db.Ingredienser.Add(new Ingrediens("Karry"));

            //}

            Ret ret = db.Retter.FirstOrDefault();

            if (ret == null)
            {
                db.Retter.Add(new Ret { Navn = "Boller i karry", Ingredienser = new List<Ingrediens> { new Ingrediens("Karry"), new Ingrediens("Ris")} });
                db.Retter.Add(new Ret { Navn = "Smørbrød", Ingredienser = new List<Ingrediens> { new Ingrediens("Rugbrød"), new Ingrediens("Smør"), new Ingrediens("Rullepølse") } });
                db.Retter.Add(new Ret { Navn = "Rissengrød", Ingredienser = new List<Ingrediens> { new Ingrediens("Ris"), new Ingrediens("Sødmælk") } });
            }

            db.SaveChanges();
        }

        // Hent alle retter
        public List<Ret> GetRetter()
        {
            return db.Retter.Include(x => x.Ingredienser).ToList();
        }

        // Hent alle retter
        public List<Ingrediens> GetIngredienser()
        {
            return db.Ingredienser.ToList();
        }

        // Tilføj en ingrediens
        public string AddIngrediens(Ingrediens nyIngrediens)
        {
            db.Ingredienser.Add(new Ingrediens { Navn = nyIngrediens.Navn});

            db.SaveChanges();

            return "Ny ingrediens added";
        }

        //// Hent en specifik post
        //public Post GetPost(int postId)
        //{
        //    Post post = db.Posts.Include(x => x.User).Include(x => x.Comments).Where(x => x.PostId == postId).First();

        //    List<Comment> kommentarer = db.Comments.Include(x => x.User).Where(x => x.PostId == postId).ToList();

        //    post.Comments = kommentarer;

        //    return post;
        //}

        //// Tilføjer en kommentar
        //public string AddComment(Comment newComment)
        //{
        //    db.Comments.Add(new Comment { Date = DateTime.Now, User = newComment.User, Text = newComment.Text, PostId = newComment.PostId });

        //    db.SaveChanges();

        //    return "New comment added";
        //}

        //// Tilføjer en post
        //public string AddPost(Post newPost)
        //{
        //    db.Posts.Add(new Post { Date = DateTime.Now, Title = newPost.Title, Text = newPost.Text, User = newPost.User, TextIsLink = newPost.TextIsLink });

        //    db.SaveChanges();

        //    return "New post added";
        //}

        //// Tilføjer en stemme til en post
        //public string AddVotePost(int postId, bool vote)
        //{
        //    if (vote == true)
        //    {
        //        Post post = db.Posts.Where(x => x.PostId == postId).First();

        //        post.Votes++;
        //    }
        //    else if (vote == false)
        //    {
        //        Post post = db.Posts.Where(x => x.PostId == postId).First();

        //        post.Votes--;
        //    }

        //    db.SaveChanges();

        //    return "Vote added";
        //}

        //// Tilføjer en stemme til en kommentar
        //public string AddVoteComment(int commentId, bool vote)
        //{
        //    if (vote == true)
        //    {
        //        Comment comment = db.Comments.Where(x => x.CommentId == commentId).First();

        //        comment.Votes++;
        //    }
        //    else if (vote == false)
        //    {
        //        Comment comment = db.Comments.Where(x => x.CommentId == commentId).First();

        //        comment.Votes--;
        //    }

        //    db.SaveChanges();

        //    return "Vote added";
        //}
    }
}

