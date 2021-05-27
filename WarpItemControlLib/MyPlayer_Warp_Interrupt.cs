using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using HamstarHelpers.Helpers.Debug;


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

			var warpItems = config.Get<List<ItemDefinition>>( nameof(config.WarpItems) );

			//switch( item.type ) {
			//case ItemID.MagicMirror:
			//case ItemID.CellPhone:
			//case ItemID.IceMirror:
			//case ItemID.RecallPotion:
			if( warpItems.Contains( new ItemDefinition(anyOrNoItem.type) ) ) {
				if( this.player.velocity.X != 0 || this.player.velocity.Y != 0 ) {
					if( this.player.whoAmI == Main.myPlayer ) {
						WICLibMod.ShowAlert( "Warping interrupted by movement." );
					}

					this.EndWarp();
				}
			}
		}
	}
}
