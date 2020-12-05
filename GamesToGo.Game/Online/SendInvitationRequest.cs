﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using osu.Framework.IO.Network;

namespace GamesToGo.Game.Online
{
    public class SendInvitationRequest : APIRequest
    {
        private int receiver;
        public SendInvitationRequest(int receiver)
        {
            this.receiver = receiver;
        }

        protected override WebRequest CreateWebRequest()
        {
            var req = base.CreateWebRequest();
            req.Method = HttpMethod.Post;
            req.AddParameter("receiver", @$"{receiver}");
            return req;
        }
        protected override string Target => "Users/SendInvitation";
    }
}
