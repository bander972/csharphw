
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;


    namespace Exercise9
    {
        /// <summary>
        /// 改进书上例子9-10的爬虫程序。
        //（1）只爬取某个指定网站上的网页 
        //（2）只有当爬取的是html/html/aspx/jsp等网页时，才解析并爬取下一级URL。
        //（3）相对地址(test/page.html, ./test/page.html, ../test2/page2.html, /test3/page.html)转成完整地址进行爬取。
        //（4） 尝试使用Winform来配置初始URL，启动爬虫，显示已经爬取的URL和错误的URL信息。

        /// </summary>
        /* 源程序：
         private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args) {
          SimpleCrawler myCrawler = new SimpleCrawler();
          string startUrl = "http://www.cnblogs.com/dstang2000/";
          if (args.Length >= 1) startUrl = args[0];
          myCrawler.urls.Add(startUrl, false);//加入初始页面
          new Thread(myCrawler.Crawl).Start();
        }

        private void Crawl() {
          Console.WriteLine("开始爬行了.... ");
          while (true) {
            string current = null;
            foreach (string url in urls.Keys) {
              if ((bool)urls[url]) continue;
              current = url;
            }

            if (current == null || count > 10) break;
            Console.WriteLine("爬行" + current + "页面!");
            string html = DownLoad(current); // 下载
            urls[current] = true;
            count++;
            Parse(html);//解析,并加入新的链接
            Console.WriteLine("爬行结束");
          }
        }

        public string DownLoad(string url) {
          try {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string html = webClient.DownloadString(url);
            string fileName = count.ToString();
            File.WriteAllText(fileName, html, Encoding.UTF8);
            return html;
          }
          catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return "";
          }
        }

        private void Parse(string html) {
          string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
          MatchCollection matches = new Regex(strRef).Matches(html);
          foreach (Match match in matches) {
            strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                      .Trim('"', '\"', '#', '>');
            if (strRef.Length == 0) continue;
            if (urls[strRef] == null) urls[strRef] = false;
          }
        }
        */
        public class SimpleCrawler
        {
            public bool Stopped = false;
            public static event Action<SimpleCrawler, string, string> DownloadMsg;
            public HashSet<String> urlsDownloaded { get; } = new HashSet<String>();
            public Queue<string> waitUrls = new Queue<string>();
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            public static readonly string urlRegex = @"^(?<site>(?<protocol>^[a-zA-z]+)://(?<host>[\w.-]+)(\:d+)?($|/))(\w+/)*(?<file>[^#?]*)";//过滤
            private int count = 0;//已爬取网站数
            public int MaxPage { get; set; }
            public string StartUrl { get; set; }
         
            public string RootUrl => SimpleCrawler.getRoot(StartUrl);//根地址
        public string HostFilter { get; set; }
        //文件过滤规则
        public string FileFilter { get; set; }
        public SimpleCrawler()
            {
                StartUrl = "https://www.runoob.com/html/html-tutorial.html";
                count = 0;
                MaxPage = 10;
        }
        

            private static string fixUrl(string url, string pageUrl)
            {

                if (url.Contains("://"))
                { //完整路径
                    return url;
                }
                if (url.StartsWith("//"))
                {
                    Match urlMatch = Regex.Match(pageUrl, urlRegex);
                    string protocal = urlMatch.Groups["protocal"].Value;
                    return protocal + ":" + url;
                }
                if (url.StartsWith("/"))
                {
                    Match urlMatch = Regex.Match(pageUrl, urlRegex);
                    String site = urlMatch.Groups["site"].Value;
                    return site.EndsWith("/") ? site + url.Substring(1) : site + url;
                }

                if (url.StartsWith("../"))
                {
                    url = url.Substring(3);
                    int idx = pageUrl.LastIndexOf('/');
                    return fixUrl(url, pageUrl.Substring(0, idx));
                }

                if (url.StartsWith("./"))
                {
                    return fixUrl(url.Substring(2), pageUrl);
                }
                //非上述开头的相对路径
                int end = pageUrl.LastIndexOf("/");
                return pageUrl.Substring(0, end) + "/" + url;
            }
            public static string getRoot(string url)
            {
                int index = 0;
                //找到第三个/对应的index
                for (int i = 0; i < 3 && index < url.Length; index++)
                {
                    if (url[index] == '/') i++;
                }
                if (index == url.Length) return url;//说明是一级地址
                else return url.Substring(0, index - 1);
            }
            public bool CompareRootUrl(string url1, string url2)
            {
                int index1 = url1.IndexOf("//");
                int index2 = url2.IndexOf("//");
                url1 = url1.Substring(index1 + 2);
                url2 = url2.Substring(index2 + 2);
                if (url1 == url2) return true;
                return false;
            }

        public void crawl()
        {
            urlsDownloaded.Clear();
            waitUrls.Clear();
            waitUrls.Enqueue(StartUrl);

            while (waitUrls.Count != 0&&count<MaxPage)
            {
                string current = waitUrls.Dequeue();

                if (count >= MaxPage || Stopped)
                {
                    Console.WriteLine(current, "总共爬取" + count + "个页面");
                    break;
                }
                try {
                    if (urlsDownloaded.Contains(current)) continue;//已被爬取，跳过
                    DownloadMsg(this, current, "success");
                    string html = DownLoad(current);
                    Parse(current, html);
                    urlsDownloaded.Add(current);
                    count++;
                } catch (Exception e)
                {
                    DownloadMsg(this,current,"Error:"+e.Message);
                }
            }
        }
            public string DownLoad(string url)
            {
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.Encoding = Encoding.UTF8;
                    string html = webClient.DownloadString(url);
                    string fileName = count.ToString();
                    File.WriteAllText(fileName, html, Encoding.UTF8);
                    return html;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return "";
                }
            }

            private void Parse(string html, string pageUrl)//修改网址格式
            {
                MatchCollection matches = new Regex(strRef).Matches(html);
                foreach (Match match in matches)//对所有匹配的url进行筛选和转换
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                        .Trim('"', '\"', '#', '>', '?'); ;
                    if (strRef.Length == 0) continue;
                    // 相对url转换，绝对url判断
                    if (strRef.IndexOf("//") == -1) strRef = fixUrl(pageUrl, strRef);
                    else if (!CompareRootUrl(RootUrl, getRoot(strRef))) continue;
                    if (urlsDownloaded.Contains(strRef)) continue;
                    //SendMsg(strRef);
                    waitUrls.Enqueue(strRef);
                }
            }
        }
    }
