using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using HamstarHelpers.Helpers.Debug;


namespace WarpItemControlLib {
	partial class WICPlayer : ModPlayer {
		private void RunCustomWarpDecisionsForItem( Item anyOrNoItem ) {
			var config = WICLibConfig.Instance;

			if( config.Get<int>( nameof(config.WarpItemBaseWarmupTickDuration) ) == 0 ) {
				return;
			}

			if( anyOrNoItem != null && !anyOrNoItem.IsAir && this.player.itemTime > 0 ) {   // Item in use
				if( Main.mouseItem != null && !Main.mouseItem.IsAir && anyOrNoItem.IsTheSameAs( Main.mouseItem ) ) {
					anyOrNoItem = Main.mouseItem;
				}

				if( !this.IsEndingCustomWarp ) {
					this.IsEndingCustomWarp = !this.RunCustomWarpForItem( anyOrNoItem );
				}
			} else {
				if( this.IsEndingCustomWarp ) {
					this.EndWarp();
				}
			}
		}
		
		////

		private bool RunCustomWarpForItem( Item anyItem ) {
			var config = WICLibConfig.Instance;
			var warpItems = config.Get<List<ItemDefinition>>( nameof( config.WarpItems ) );

			//switch( item.type ) {
			//case ItemID.MagicMirror:
			//case ItemID.CellPhone:
			//case ItemID.IceMirror:
			//case ItemID.RecallPotion:
			if( warpItems.Contains( new ItemDefinition(anyItem.type) ) ) {
				/*var pIT = player.itemTime;
				var pIA = player.itemAnimation;
				var iT = useItem.useTime;*/
				return this.RunCustomWarp( anyItem );
				/*string dbg = "1 - t: "+player.teleporting+", tt:"+player.teleportTime+", pIT:"+pIT+", pIA:"+pIA+" ("+player.itemAnimationMax+"), iT:"+iT
					+" - pIT2:"+player.itemTime+", pIA2:"+player.itemAnimation+" ("+player.itemAnimationMax+"), iT2:"+useItem.useTime;
				LogHelpers.Log( dbg );
				Main.NewText( dbg );*/
			} else {
				return false;
			}
		}

		////

		private bool RunCustomWarp( Item warpItem ) {
			var config = WICLibConfig.Instance;

			float unit = 1f / (float)config.Get<int>( nameof(config.WarpItemBaseWarmupTickDuration) );
			if( warpItem.type == ItemID.RecallPotion ) {
				unit = 1f / (float)config.Get<int>( nameof(config.RecallPotionBaseWarmupTickDuration) );
			}

			this.CustomWarpPercent += unit;

			float invPerc = 1f - this.CustomWarpPercent;
			int useTime = (int)(invPerc * (float)warpItem.useTime);

			bool isWarping = this.CustomWarpPercent < 1f && useTime > 3;

			if( isWarping ) {
				int animTime = Math.Max( (int)(invPerc * (float)this.player.itemAnimationMax) - 1, 0 );

				this.player.itemTime = useTime;
				this.player.itemAnimation = animTime;
			}

			return isWarping;
		}
	}
}
