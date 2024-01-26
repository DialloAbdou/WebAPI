namespace MiniApi
{
    public class ArticleService
    {
        private List<Article> _articles = new List<Article>()
        {
              new Article(1, "Marteau"),
              new Article(2, "Scie")

        };

        public List<Article> GetAllArticles() => _articles;

        public Article AddArticle(string title)
        {
            var article=  new Article(_articles.Max(a=>a.Id)+1, title);
            _articles.Add(article);
            return article;
        }
       
    }
}
