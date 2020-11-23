using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using HamstarHelpers.Helpers.Debug;


namespace WarpItemControlLib {
	partial class WICPlayer : ModPlayer {
		private void RunWarpInterruptDecisions( Item anyOrNoItem ) {
			if( !WICLibConfig.Instance.WarpWarmupInterruptedByMovement ) {
				return;
			}
			if( anyOrNoItem == null || anyOrNoItem.IsAir || this.player.itemTime == 0 ) {   // Item not in use
				return;
			}

			switch( anyOrNoItem.type ) {
			case ItemID.MagicMirror:
			case ItemID.CellPhone:
			case ItemID.IceMirror:
			case ItemID.RecallPotion:
				if( this.player.velocity.X != 0 || this.player.velocity.Y != 0 ) {
					this.EndWarp();
				}
				break;
			}
		}
	}
}
