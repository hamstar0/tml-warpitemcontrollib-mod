using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Services.Timers;


namespace WarpItemControlLib {
	partial class WICPlayer : ModPlayer {
		private void RunWarpInterruptDecisions( Item anyOrNoItem ) {
			var config = WICLibConfig.Instance;

			if( !config.Get<bool>(nameof(config.WarpWarmupInterruptedByMovement)) ) {
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
					if( this.player.whoAmI == Main.myPlayer ) {
						Timers.SetTimer( "WICWarpMoveInterrupt", 2, false, () => {
							Main.NewText( "Warping interrupted by movement.", Color.Yellow );
							return false;
						} );
					}

					this.EndWarp();
				}
				break;
			}
		}
	}
}
