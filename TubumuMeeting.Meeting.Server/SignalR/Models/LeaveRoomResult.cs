﻿namespace TubumuMeeting.Meeting.Server
{
    public class LeaveRoomResult
    {
        public Peer Peer { get; set; }

        public Peer[] OtherPeers { get; set; }
    }
}