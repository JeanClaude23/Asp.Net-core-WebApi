using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class IsgAsset
    {
        public long Id { get; set; }
        public string? HighResolutionPath { get; set; }
        public string? ThumbPath { get; set; }
        public string? PreviewPath { get; set; }
    }
}
