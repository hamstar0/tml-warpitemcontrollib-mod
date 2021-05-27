using System;
using Terraria;
using Terraria.ModLoader;


namespace WarpItemControlLib {
	public static class WarpItemControlLibAPI {
		public static void EnableWarpItemsForPlayer( Player player, bool isEnabled, string warpDeniedMessage ) {
			var myplayer = player.GetModPlayer<WICPlayer>();
			myplayer.IsWarpEnabled = isEnabled;
			myplayer.WarpDeniedMessage = warpDeniedMessage;
		}

		public static bool AreWarpItemsEnabledForPlayer( Player player, out string warpDeniedMessage ) {
			var myplayer = player.GetModPlayer<WICPlayer>();
			warpDeniedMessage = myplayer.WarpDeniedMessage;
			return myplayer.IsWarpEnabled;
		}
	}
}
