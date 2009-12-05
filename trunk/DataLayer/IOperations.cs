using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DataEntities;
using HtmlAgilityPack;

namespace DataLayer
{
    public interface IOperations
    {
        Profile GetProfileForUid(string uid); 
    }

    public class Operations : IOperations
    {
        private const string baseUrl = "http://codebits.eu";
        private Dictionary<string, Profile> profileCache;

        public Operations()
        {
            profileCache = new Dictionary<string, Profile>();
        }

        public Profile GetProfileForUid(string uid)
        {
            if (!profileCache.ContainsKey(uid))
            {
                profileCache[uid] = LoadProfileFromSite(uid);
            }
            return profileCache[uid];
        }

        private Profile LoadProfileFromSite(string uid)
        {
            var scraper = new HtmlDocument();
            var page = new WebClient().DownloadString(baseUrl + "/" + uid);
            scraper.LoadHtml(page);

            var profile = new Profile();
            HtmlNode card = scraper.DocumentNode.SelectSingleNode("//div[@class='vcard']");
            profile.ID = uid;
            profile.Name = card.TextInNode("//p[@id='u_name']");
            profile.Blog = card.TextInNode("//p[@id='u_blog']/a");
            profile.PhotoUrl = card.SelectSingleNode("//img[@class='photo']").Attributes["src"].Value;
            
            profile.Twitter = card.TextInNode("//p[@id='u_twitter']/a").Replace("http://twitter.com/","");

            profile.Skills = card.SelectNodes("//p[@id='u_skills']/a").Select(node => new Skill(node.InnerText));
            profile.Friends = (card
                .SelectNodes("//a[@rel='contact']") ?? new HtmlNodeCollection(card))
                .Select(node => node.Attributes["href"].Value.Replace("/", ""))
                .Select(friendUid => GetProfileForUid(friendUid));

            var projectNode = scraper.DocumentNode.SelectNodes("//p")
                .SingleOrDefault(n => n.ChildNodes
                                          .Any(a => a.Name == "a"
                                                    && a.Attributes["href"].Value.StartsWith("/intra/s/project/")));

            if (projectNode != null)
            {
                string projectDescription = projectNode.InnerText.Split(new []{"\n"}, 2, StringSplitOptions.RemoveEmptyEntries)[1];
                profile.Project = new Project(projectNode.DescendantNodes().First().InnerText, projectDescription);
            }
            return profile;
        }
    }

    public static class HtmlDocumentExtensions
    {
        public static string TextInNode(this HtmlDocument self, string xpath)
        {
            HtmlNode node = self.DocumentNode.SelectSingleNode(xpath);
            return node != null ? node.InnerText: String.Empty;
        }

        public static string TextInNode(this HtmlNode self, string xpath)
        {
            HtmlNode node = self.SelectSingleNode(xpath);
            return node != null ? node.InnerText : String.Empty;
        }
    }
}
