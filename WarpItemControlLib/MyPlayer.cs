using System;
using Terraria;
using Terraria.ModLoader;
using HamstarHelpers.Helpers.Debug;


namespace WarpItemControlLib {
	partial class WICPlayer : ModPlayer {
		private float CustomWarpPercent = 0f;
		private bool IsEndingCustomWarp = false;



		////////////////

		public override bool PreItemCheck() {
			Item heldItem = this.player.HeldItem;

			this.RunCustomWarpDecisionsForItem( heldItem );
			this.RunWarpInterruptDecisions( heldItem );

			return base.PreItemCheck();
		}
	}
}
