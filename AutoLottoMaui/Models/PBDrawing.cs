﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Drawing;
//
//    var pbDrawing = PbDrawing.FromJson(jsonString);

namespace AutoLottoMaui.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PbDrawing
    {
        [JsonProperty("draw_date")]
        public DateTimeOffset DrawDate { get; set; }

        [JsonProperty("winning_numbers")]
        public string WinningNumbers { get; set; }

        [JsonProperty("mega_ball")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long MegaBall { get; set; }

        [JsonProperty("multiplier")]
        public string Multiplier { get; set; }
    }

    public partial class PbDrawing
    {
        public static List<PbDrawing> FromJson(string json) => JsonConvert.DeserializeObject<List<PbDrawing>>(json, Converter.Settings);
    }

    
}

