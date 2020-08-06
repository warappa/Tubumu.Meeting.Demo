﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Tubumu.Core.Extensions;
using TubumuMeeting.Mediasoup;

namespace TubumuMeeting.Meeting.Server
{
    public partial class Room : IEquatable<Room>
    {
        public string RoomId { get; }

        public string Name { get; }

        public bool Equals(Room other)
        {
            return RoomId == other.RoomId;
        }

        public override int GetHashCode()
        {
            return RoomId.GetHashCode();
        }
    }

    public partial class Room
    {
        /// <summary>
        /// Logger factory for create logger.
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;

        /// <summary>
        /// Logger.
        /// </summary>
        private readonly ILogger<Room> _logger;

        private readonly object _locker = new object();

        public bool Closed { get; private set; }

        public Dictionary<string, Peer> Peers { get; } = new Dictionary<string, Peer>();

        public Room(ILoggerFactory loggerFactory, string roomId, string name)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<Room>();

            RoomId = roomId;
            Name = name.IsNullOrWhiteSpace() ? "Default" : name;
            Closed = false;
        }

        public void Close()
        {
            _logger.LogError($"Close() | Room:{RoomId}");

            CheckClosed();
            lock (_locker)
            {
                CheckClosed();

                if (Closed)
                {
                    return;
                }

                Closed = true;
            }
        }

        private void CheckClosed()
        {
            if (Closed)
            {
                throw new Exception("Room was closed");
            }
        }
    }
}
