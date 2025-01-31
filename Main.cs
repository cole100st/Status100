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
        {
            base.OnPluginInit();
            AAMenu.Menu.AddBizTabLine(PluginInformations, new List<Life.BizSystem.Activity.Type> { Activity.Type.None }, null, $"{Format.Color("Ouvrir", Format.Colors.Success)} {Format.Color("/", Format.Colors.Grey)} {Format.Color("Fermer", Format.Colors.Error)}", aaMenu =>
            {
                var player = PanelHelper.ReturnPlayerFromPanel(aaMenu);
                if (Status.ContainsKey(player.biz.Id))
                {
                    if (Status[player.biz.Id] == true)
                    {
                        SendClose(player.biz.BizName);
                        player.Notify(Format.Color("Succès", Format.Colors.Success), "Vous avez fermé l'entreprise", NotificationManager.Type.Success);
                        Status.Remove(player.biz.Id);
                    }
                }
                else
                {
                    Status.Add(player.biz.Id, true);
                    SendOpen(player.biz.BizName);
                    player.Notify(Format.Color("Succès", Format.Colors.Success), "Vous avez ouvert l'entreprise", NotificationManager.Type.Success);
                }
            });
            AAMenu.Menu.AddDocumentTabLine(PluginInformations, Format.Color("Annuaire des Entreprises", Format.Colors.Purple), aaMenu =>
            {
                var player = PanelHelper.ReturnPlayerFromPanel(aaMenu);
                OpenMenu(player);
            });
