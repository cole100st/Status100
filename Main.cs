using Life.Network;
using System;
using ModKit.Utils;
using ModKit.Helper;
using System.Collections.Generic;
using Life;
using Life.DB;
using Life.BizSystem;
using Format = ModKit.Helper.TextFormattingHelper;
using Life.UI;

namespace Statu100ST
{
    public class Main : ModKit.ModKit
    {
        public static Dictionary<int, bool> Status = new Dictionary<int, bool>();

        public Main(IGameAPI api) : base(api)
        {
            PluginInformations = new ModKit.Interfaces.PluginInformations(AssemblyHelper.GetName(), "1.1.1", "COLE100");
        }

        public override void OnPluginInit()
