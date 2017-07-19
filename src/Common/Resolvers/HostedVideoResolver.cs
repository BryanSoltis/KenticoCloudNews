﻿using Common.Models;
using KenticoCloud.Delivery.InlineContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Resolvers
{
    public class HostedVideoResolver : IInlineContentItemsResolver<HostedVideo>
    {
        public string Resolve(ResolvedContentItemData<HostedVideo> data)
        {
            var selected = data.Item.Video.FirstOrDefault()?.Codename;

            switch (selected)
            {
                case "vimeo":
                    return
                        $"<iframe class=\"hosted-video__wrapper\" src=\"https://player.vimeo.com/video/{data.Item.VideoId}?title=0&byline=0&portrait=0\" width=\"640\" " +
                        $"height=\"360\" frameborder=\"0\" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>";

                case "youtube":
                    return $"<iframe class=\"hosted-video__wrapper\" width=\"560\" height=\"315\" " +
                           $"src=\"https://www.youtube.com/embed/{data.Item.VideoId}\" frameborder=\"0\" allowfullscreen></iframe>";
            }

            return string.Empty;
        }
    }
}