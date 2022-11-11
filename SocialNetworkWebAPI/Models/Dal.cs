using System.Data;
using System.Reflection.Metadata.Ecma335;

using MySqlConnector;

namespace SocialNetworkWebAPI.Models
    {
    public class Dal
        {
        public Response User(User user,MySqlConnection connection)
            {
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO User(Name,Email,Password,PhoneNo,IsActive,IsApproved) VALUES ('"+user.Name+ "','" + user.Email+"','"  + user.Password+ "','"  + user.PhoneNo + "',1,0)", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
                {
                response.StatusCode = 200;
                response.StatusMessage = "User successful";

                }
            else
                {
                response.StatusCode = 100;
                response.StatusMessage = "User Failed";
                }
            return response;
            }
        public Response Login(User user,MySqlConnection connection)
            {
            Response response = new Response();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM User WHERE Email = '"+user.Email+"' AND Password = '"+user.Password+"'",connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            if(dt.Rows.Count > 0)
                {
                response.StatusCode = 200;
                response.StatusMessage = "Login Successful";
                User reg = new User();
                reg.Id = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                /*reg.Name = Convert.ToString(dt.Rows[0]["Name"]);*/
                reg.Email = Convert.ToString(dt.Rows[0]["Email"]);
                response.User = reg;
                }
            else
                {
                response.StatusCode = 100;
                response.StatusMessage = "Login Failed";
                response.User = null;
                }
            return response;
            }
        public Response UserApproval(User user,MySqlConnection connection)
            {
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("UPDATE User SET IsApproved = 1 WHERE Id= '"+user.Id+"' AND IsActive = 1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
                {
                response.StatusCode = 200;
                response.StatusMessage = "User approved";
                }
            else
                {
                response.StatusCode = 100;
                response.StatusMessage = "User approval failed";
                }
            return response;
            }
        public Response AddNews(News news, MySqlConnection connection)
            {
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO News(Title,Content,Email,IsActive,CreatedOn) VALUES('"+news.Title+"', '"+news.Content+"', '"+news.Email+"', 1, GETDATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
                {
                response.StatusCode = 200;
                response.StatusMessage = "News created";
                }
            else
                {
                response.StatusCode = 100;
                response.StatusMessage = "News creation failed";
                }
            return response;
            }
        public Response NewsList(MySqlConnection connection)
            {
            Response response = new Response();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM News WHERE IsActive = 1", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<News> lstNews = new List<News>();

            if(dt.Rows.Count > 0)
                {
                for(int i = 0; i < dt.Rows.Count; i++)
                    {
                    News news = new News();
                    news.Id = Convert.ToInt32((string)dt.Rows[i]["ID"]);
                    news.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    news.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    news.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    news.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    news.CreatedOn = Convert.ToString(dt.Rows[i]["CreatedOn"]);
                    lstNews.Add(news);
                    }
                if(lstNews.Count > 0)
                    {
                    response.StatusCode = 200;
                    response.StatusMessage = "News data found";
                    response.listNews = lstNews;
                    }
                else
                    {
                    response.StatusCode = 100;
                    response.StatusMessage = "No news data found";
                    response.listNews = null;
                    }
               
                }
            else
                {
                response.StatusCode = 100;
                response.StatusMessage = "No news data found";
                response.listNews = null;
                }

            return response;
            }
        public Response UserList(User user, MySqlConnection connection)
            {
            Response response = new Response();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM User WHERE IsActive = 1 AND UserType = '"+user.UserType+"'", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<User> lstuser = new List<User>();

            if(dt.Rows.Count > 0)
                {
                for(int i = 0; i < dt.Rows.Count; i++)
                    {
                    User reg = new User();
                    reg.Id = Convert.ToInt32((dt.Rows[i]["ID"]));
                    reg.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    reg.Email = Convert.ToString((string)dt.Rows[i]["Email"]);
                    reg.IsApproved = Convert.ToInt32((dt.Rows[i]["IsApproved"]));
                    reg.Password = Convert.ToString((string)dt.Rows[i]["Password"]);
                    reg.UserType = Convert.ToString(dt.Rows[i]["UserType"]);
                    reg.PhoneNo = Convert.ToString(dt.Rows[i]["PhoneNo"]);
                    lstuser.Add(reg);

                    }
                if(lstuser.Count > 0)
                    {
                    response.StatusCode = 200;
                    response.StatusMessage = "User data found";
                    response.listUser = lstuser;
                    }
                else
                    {
                    response.StatusCode = 100;
                    response.StatusMessage = "No User data found";
                    response.listUser = null;
                    }

                }
            else
                {
                response.StatusCode = 100;
                response.StatusMessage = "No User data found";
                response.User = null;
                }

            return response;
            }
        public Response AddArticle(Article article,MySqlConnection connection)
            {
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Article(Title,Content,Email,Image,IsActive,IsApproved) VALUES('"+article.Title+"', '"+article.Content+"', '"+article.Email+"','"+article.Image+"', 1,0) ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
                {
                response.StatusCode = 200;
                response.StatusMessage = "Article created";
                }
            else
                {
                response.StatusCode = 100;
                response.StatusMessage = "Article creation failed";
                }
            return response;
            }
        public Response ArticleList(Article article, MySqlConnection connection)
            {
            Response response = new Response();
            MySqlDataAdapter da = null;
            if(article.type == "User")
                {
                new MySqlDataAdapter("SELECT * FROM Article WHERE Email = '"+article.Email+"' AND IsActive = 1", connection);
                }
            if(article.type == "Page")
                {
                new MySqlDataAdapter("SELECT * FROM Article WHERE IsActive = 1", connection);
                }
           
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Article> lstArticle = new List<Article>();

            if(dt.Rows.Count > 0)
                {
                for(int i = 0; i < dt.Rows.Count; i++)
                    {
                    Article art = new Article();
                    art.Id = Convert.ToInt32((string)dt.Rows[i]["ID"]);
                    art.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    art.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    art.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    art.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    art.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    lstArticle.Add(article);
                    }
                if(lstArticle.Count > 0)
                    {
                    response.StatusCode = 200;
                    response.StatusMessage = "Article data found";
                    response.listArticle = lstArticle;
                    }
                else
                    {
                    response.StatusCode = 100;
                    response.StatusMessage = "No Article data found";
                    response.listArticle = null;
                    }

                }
            else
                {
                response.StatusCode = 100;
                response.StatusMessage = "No listArticles data found";
                response.listArticle = null;
                }

            return response;
            }
        public Response ArticleApproval(Article article,MySqlConnection connection)
            {
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("UPDATE Article SET IsApproved = 1 WHERE Id= '"+article.Id+"' AND IsActive = 1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
                {
                response.StatusCode = 200;
                response.StatusMessage = "Article approved";
                }
            else
                {
                response.StatusCode = 100;
                response.StatusMessage = "Article approval failed";
                }
            return response;
            }
        public Response StaffUser(Staff staff,MySqlConnection connection)
            {
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Staff(Name,Email,Password,IsActive) VALUES ('"+staff.Name+ "','" + staff.Email+"','"  + staff.Password+ "',1)", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
                {
                response.StatusCode = 200;
                response.StatusMessage = "Staff User successful";

                }
            else
                {
                response.StatusCode = 100;
                response.StatusMessage = "Staff User Failed";
                }
            return response;
            }
        public Response DeleteStaff(Staff staff,MySqlConnection connection)
            {
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Staff WHERE Id= '"+staff.Id+ "' AND IsActive = 1", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
                {
                response.StatusCode = 200;
                response.StatusMessage = "Staff deleted successfully";

                }
            else
                {
                response.StatusCode = 100;
                response.StatusMessage = "Staff deletion Failed";
                }
            return response;
            }
        public Response AddEvent(Events events,MySqlConnection connection)
            {
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Events(Title,Content,Email,IsActive,CreatedOn) VALUES('"+events.Title+"', '"+events.Content+"', '"+events.Email+"', 1,GETDATE()) ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
                {
                response.StatusCode = 200;
                response.StatusMessage = "Event created";
                }
            else
                {
                response.StatusCode = 100;
                response.StatusMessage = "Event creation failed";
                }
            return response;
            }
        public Response EventList(MySqlConnection connection)
            {
            Response response = new Response();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM Events WHERE IsActive = 1",connection);

            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Events> lstEvents = new List<Events>();

            if(dt.Rows.Count > 0)
                {
                for(int i = 0; i < dt.Rows.Count; i++)
                    {
                    Events event_ = new Events();
                    event_.Id = Convert.ToInt32((string)dt.Rows[i]["ID"]);
                    event_.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    event_.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    event_.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    event_.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    event_.CreatedOn = Convert.ToString(dt.Rows[i]["CreatedOn"]);
                    lstEvents.Add(event_);
                    }
                if(lstEvents.Count > 0)
                    {
                    response.StatusCode = 200;
                    response.StatusMessage = "Event data found";
                    response.listEvents = lstEvents;
                    }
                else
                    {
                    response.StatusCode = 100;
                    response.StatusMessage = "No Event data found";
                    response.listEvents = null;
                    }

                }
            else
                {
                response.StatusCode = 100;
                response.StatusMessage = "No listArticles data found";
                response.listArticle = null;
                }

            return response;
            }
        }
    }
