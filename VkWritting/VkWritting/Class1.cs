using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkWritting
{
    public class Peer
    {
        public int id { get; set; }
        public string type { get; set; }
        public int local_id { get; set; }
    }
    public class SortId
    {
        public int major_id { get; set; }
        public int minor_id { get; set; }
    }
    public class CanWrite
    {
        public bool allowed { get; set; }
    }
    public class Item
    {
        public Peer peer { get; set; }
        public int last_message_id { get; set; }
        public int in_read { get; set; }
        public int out_read { get; set; }
        public SortId sort_id { get; set; }
        public bool is_marked_unread { get; set; }
        public bool important { get; set; }
        public CanWrite can_write { get; set; }
    }
    public class OnlineInfo
    {
        public bool visible { get; set; }
        public int last_seen { get; set; }
        public bool is_online { get; set; }
        public int app_id { get; set; }
        public bool is_mobile { get; set; }
    }
    public class Profile
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool is_closed { get; set; }
        public bool can_access_closed { get; set; }
        public int sex { get; set; }
        public string screen_name { get; set; }
        public string photo_50 { get; set; }
        public string photo_100 { get; set; }
        public int online { get; set; }
        public OnlineInfo online_info { get; set; }
    }
    public class Response
    {
        public int count { get; set; }
        public List<Item> items { get; set; }
        public List<Profile> profiles { get; set; }
    }

    public class Root
    {
        public Response response { get; set; }
    }
}
