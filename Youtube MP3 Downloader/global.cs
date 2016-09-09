using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Youtube_MP3_Downloader
    {
        internal class global
            {
                public static string gethtml(string url)
                    {
                        var urlAddress = url;
                        var request = (HttpWebRequest) WebRequest.Create(urlAddress);
                        var response = (HttpWebResponse) request.GetResponse();
                        var data = "";
                        if(response.StatusCode == HttpStatusCode.OK)
                            {
                                var receiveStream = response.GetResponseStream();
                                StreamReader readStream = null;
                                if(response.CharacterSet == null)
                                    {
                                        readStream = new StreamReader(receiveStream);
                                    }
                                else
                                    {
                                        readStream = new StreamReader(receiveStream,
                                            Encoding.GetEncoding(response.CharacterSet));
                                    }
                                data = readStream.ReadToEnd();
                                response.Close();
                                readStream.Close();
                            }
                        return data;
                    }

                public static string download_link(string youtube_url)
                    {
                        var a = gethtml(youtube_url);
                        var html = gethtml(youtube_url);
                        var reg = Regex.Split(html, " ");
                        var url = reg [14];
                        url = url.Replace("href =\"/download/get/", "");
                        url = url.Replace("\"", "");
                        url = url.Replace("href=\"/download/get/?i=", "");
                        url = url.Replace("href=/download/get/", "");
                        var start = "http://www.youtubeinmp3.com/download/get/";
                        var final_url = start + url;
                        return final_url;
                    }
            }
    }