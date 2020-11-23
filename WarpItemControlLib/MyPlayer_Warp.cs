using System;
using Terraria;
using Terraria.ModLoader;
using HamstarHelpers.Helpers.Debug;


namespace WarpItemControlLib {
	partial class WICPlayer : ModPlayer {
		private void EndWarp() {
			this.IsEndingCustomWarp = false;
			this.CustomWarpPercent = 0f;

			this.player.itemAnimation = 0;
			this.player.itemTime = 0;
		}
	}
}
