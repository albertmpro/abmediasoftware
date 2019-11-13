using System;
using System.Collections.Generic;
using System.Text;

namespace abmediaplatform
{
    public class Docs
    {
        #region Html Genrator's 
        /// <summary>
        /// Create Html Document 
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_description"></param>
        /// <param name="_author"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        public static string HtmlDoc(string _title, string _description, string _author, string _keywords)
        {
            var str = $"<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset= \"utf-8\" />\n<meta name=\"viewport\" content=\"width = device - width,initial-scale=1\">\n<meta name=\"description\" content=\"{_description}\"  />\n<meta name=\"author\" content=\"{_author}\" />\n<meta name=\"keywords\" content=\"{_keywords}\"  />\n<title>{_title}</title>\n</head>\n<body>\n\n</body>\n</html> ";

            return str;
        }
        /// <summary>
        /// Create Html doc with stylesheet
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_description"></param>
        /// <param name="_author">Author</param>
        /// <param name="_keywords">Keywords</param>
        /// <param name="_stylesheetlink">Style Sheet</param>
        /// <returns></returns>
        public static string HtmlDoc(string _title, string _description, string _author, string _keywords, string _stylesheetlink)
        {
            var str = $"<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset= \"utf-8\" />\n<meta name=\"viewport\" content=\"width = device - width,initial-scale=1\">\n<meta name=\"description\" content=\"{_description}\"  />\n<meta name=\"author\" content=\"{_author}\" />\n<meta name=\"keywords\" content=\"{_keywords}\"  />\n<title>{_title}</title>\n<link rel=\"\" type=\"text/css\" media=\"screen\" href=\"{_stylesheetlink}\" />\n</head>\n<body>\n\n</body>\n</html> ";


            return str;
        }
        /// <summary>
        /// Create Html Document with Javascript and Css File
        /// </summary>
        /// <param name="_title">Title</param>
        /// <param name="_description">Description</param>
        /// <param name="_author">Author</param>
        /// <param name="_keywords">Keywords</param>
        /// <param name="_stylesheetlink">StyeSheet File</param>
        /// <param name="_jslink">JavaScript File</param>
        /// <returns></returns>
        public static string HtmlDoc(string _title, string _description, string _author, string _keywords, string _stylesheetlink, string _jslink)
        {
            var str = $"<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset= \"utf-8\" />\n<meta name=\"viewport\" content=\"width = device - width,initial-scale=+1\">\n<meta name=\"description\" content=\"{_description}\"  />\n<meta name=\"author\" content=\"{_author}\" />\n<meta name=\"keywords\" content=\"{_keywords}\"  />\n<title>{_title}</title>\n<link rel=\"\" type=\"text/css\" media=\"screen\" href=\"{_stylesheetlink}\" />\n</head>\n<body>\n\n<script src=\"{_jslink}\"></script>\n</body>\n</html>";


            return str;
        }
        #endregion

        #region WordPress Theme 

        public static string WPStyle(string _themeName, string _author)
        {
            var name = $"/*\nTheme Name:{_themeName}\nAuthor:{_author}*/\n";


            var rv = $"{name}\n";

            return rv;
        }

        /// <summary>
        /// Gets the index.php for a WordPress Theme
        /// </summary>
        public static string WPIndex
        {
            get
            {
                var rv = "<?php \n\nif (have_posts()) :\nwhile (have_posts()): the_post();\n\n get_template_part('content');\nendwhile;\nelse :\n echo\"No thing found!\";\nendif;\n?>\n<?php\n\n?>";

                return rv;
            }
        }
        /// <summary>
        /// Gets the header.php for WordPress Theme 
        /// </summary>
        public static string WPHeader
        {
            get
            {
                var rv = "<!DOCTYPE html>\n<html>\n<head>\n<title><?php bloginfo('name'); ?></title>\n<?php wp_head(); // Hook for WordPress ?>\n</head>\n<body <?php body_class();?>  >";

                return rv;
            }
        }
        /// <summary>
        /// Gets the page.php for the WordPress Theme
        /// </summary>
        public static string WPPage
        {
            get
            {
                var rv = "<?php\n\nget_header(); ?>\n\n<div id = \"primary\" class=\"content-area\">\n<main id =\"main\" class=\"site-main\" role=\"main\">\n<?php\n\n// Start the loop.\nwhile (have_posts() ) : the_post();\n// Include the page content template.\nget_template_part( 'content', 'page' );\n// If comments are open or we have at least one comment, load up the comment template.\nif (comments_open() || get_comments_number() ) :\ncomments_template();\nendif;\n// End the loop.\nendwhile;\n?>\n</main><!-- .site-main -->\n</div><!-- .content-area -->\n\n<?php get_footer(); ?>\n";

                return rv;
            }
        }
        /// <summary>
        /// Gets the footer.php for the WordPress Theme 
        /// </summary>
        public static string WPFooter
        {
            get
            {
                var rv = "\n<?php wp_footer();?>\n\n</body>\n</html> ";
                return rv;
            }
        }
        /// <summary>
        /// Gets the function.php for the WordPress Theme 
        /// </summary>
        public static string WPFunctions
        {
            get
            {
                return "<?php\n\n\n?>";
            }
        }



        #endregion
    }
}
