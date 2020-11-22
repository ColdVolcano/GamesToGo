﻿using System.Net.Http;
using osu.Framework.IO.Network;

namespace GamesToGo.App.Online
{
    public class UploadUserImageRequest : APIRequest
    {
        private readonly byte[] image;

        public UploadUserImageRequest(byte[] image)
        {
            this.image = image;
        }

        protected override WebRequest CreateWebRequest()
        {
            var req = base.CreateWebRequest();
            req.Method = HttpMethod.Post;
            req.AddParameter("Name", @"salchipapa");
            req.AddFile("File", image);
            return req;
        }
        protected override string Target => "Users/UploadImage";
    }
}
