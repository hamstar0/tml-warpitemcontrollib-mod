using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using HamstarHelpers.Helpers.Debug;


namespace WarpItemControlLib {
	partial class WICPlayer : ModPlayer {
		private float WarpPercent = 0f;
		private bool IsEndingWarp = false;



		////////////////

		public override bool PreItemCheck() {
			var config = WICLibConfig.Instance;
			if( config.WarpItemBaseWarmupTickDuration > 0 ) {
				this.RunWarpDecisionsForItem( this.player.HeldItem );
			}

			return base.PreItemCheck();
		}

		////

		private void RunWarpDecisionsForItem( Item useItem ) {
			if( useItem != null && !useItem.IsAir && this.player.itemTime > 0 ) {   // Item in use
				if( !this.IsEndingWarp ) {
					if( Main.mouseItem != null && !Main.mouseItem.IsAir && useItem.IsTheSameAs( Main.mouseItem ) ) {
						useItem = Main.mouseItem;
					}

					this.IsEndingWarp = !this.RunWarpSequenceForItem( useItem );
				}
			} else {
				if( this.IsEndingWarp ) {
					this.IsEndingWarp = false;
					this.WarpPercent = 0f;
				}
			}
		}

		private bool RunWarpSequenceForItem( Item anyItem ) {
			switch( anyItem.type ) {
			case ItemID.MagicMirror:
			case ItemID.CellPhone:
			case ItemID.IceMirror:
			case ItemID.RecallPotion:
				/*var pIT = player.itemTime;
				var pIA = player.itemAnimation;
				var iT = useItem.useTime;*/
				return this.RunWarpSequence( anyItem );
				/*string dbg = "1 - t: "+player.teleporting+", tt:"+player.teleportTime+", pIT:"+pIT+", pIA:"+pIA+" ("+player.itemAnimationMax+"), iT:"+iT
					+" - pIT2:"+player.itemTime+", pIA2:"+player.itemAnimation+" ("+player.itemAnimationMax+"), iT2:"+useItem.useTime;
				LogHelpers.Log( dbg );
				Main.NewText( dbg );*/
			default:
				return false;
			}
		}

		////

		private bool RunWarpSequence( Item warpItem ) {
			var config = WICLibConfig.Instance;

			float unit = 1f / config.WarpItemBaseWarmupTickDuration;
			if( warpItem.type == ItemID.RecallPotion ) {
				unit = 1f / config.RecallPotionBaseWarmupTickDuration;
			}

			this.WarpPercent += unit;

			float invPerc = 1f - this.WarpPercent;
			int useTime = (int)(invPerc * (float)warpItem.useTime);

			bool isWarping = this.WarpPercent < 1f && useTime > 3;

			if( isWarping ) {
				int animTime = Math.Max( (int)(invPerc * (float)this.player.itemAnimationMax) - 1, 0 );

				this.player.itemTime = useTime;
				this.player.itemAnimation = animTime;
			}

			return isWarping;
		}
	}
}
