using System;
using Terraria;


namespace WarpItemControlLib {
	public static class WarpItemControlLibAPI {
		public static void EnableWarpItemsForPlayer( Player player, bool isEnabled ) {
			var myplayer = player.GetModPlayer<WICPlayer>();
			myplayer.IsWarpEnabled = isEnabled;
		}

		public static bool AreWarpItemsEnabledForPlayer( Player player ) {
			var myplayer = player.GetModPlayer<WICPlayer>();
			return myplayer.IsWarpEnabled;
		}
	}
}
