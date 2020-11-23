using System;
using Terraria;
using Terraria.ModLoader;
using HamstarHelpers.Helpers.Debug;


namespace WarpItemControlLib {
	partial class WICPlayer : ModPlayer {
		public bool IsWarpEnabled { get; internal set; } = false;

		public string WarpDeniedMessage { get; internal set; } = "Warp items disabled.";


		////////////////

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
