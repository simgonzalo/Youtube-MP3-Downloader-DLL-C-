namespace Youtube_MP3_Downloader
{
    public class Main
    {
        public static string get_Download_link(string youtube_Url)
        {
            return global.download_link("http://www.youtubeinmp3.com/widget/button/?color=ba1717&amp;video=" + youtube_Url);
        }
    }
}