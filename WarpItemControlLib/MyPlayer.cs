using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using HamstarHelpers.Helpers.Debug;


namespace WarpItemControlLib {
	class WICItem : GlobalItem {
		public override bool CanUseItem( Item item, Player player ) {
			switch( item.type ) {
			case ItemID.MagicMirror:
			case ItemID.CellPhone:
			case ItemID.IceMirror:
			case ItemID.RecallPotion:
				//Main.NewText( "3" );
				break;
			}
			return base.CanUseItem( item, player );
		}


		public override bool UseItem( Item item, Player player ) {
			switch( item.type ) {
			case ItemID.MagicMirror:
			case ItemID.CellPhone:
			case ItemID.IceMirror:
			case ItemID.RecallPotion:
				Main.NewText( "2 - pIT:"+player.itemTime+", pIA:"+player.itemAnimation+" ("+player.itemAnimationMax+"), iT:"+item.useTime );
				break;
			}
			return base.UseItem( item, player );
		}
	}




	partial class WICPlayer : ModPlayer {
		private float WarpPercent = 0f;
		private bool IsEndingWarp = false;



		////////////////

		public override bool PreItemCheck() {
			Item useItem = this.player.inventory[this.player.selectedItem];

			if( useItem != null && !useItem.IsAir && this.player.itemTime > 0 ) {   // Item in use
				if( !this.IsEndingWarp ) {
					if( Main.mouseItem != null && !Main.mouseItem.IsAir && useItem.IsTheSameAs( Main.mouseItem ) ) {
						useItem = Main.mouseItem;
					}

					this.IsEndingWarp = !this.CheckWarpItem( useItem );
				}
			} else {
				if( this.IsEndingWarp ) {
					this.IsEndingWarp = false;
					this.WarpPercent = 0f;
				}
			}

			return base.PreItemCheck();
		}

		////
		
		private bool CheckWarpItem( Item warpItem ) {
			switch( warpItem.type ) {
			case ItemID.MagicMirror:
			case ItemID.CellPhone:
			case ItemID.IceMirror:
			case ItemID.RecallPotion:
				/*var pIT = player.itemTime;
				var pIA = player.itemAnimation;
				var iT = useItem.useTime;*/
				return this.RunWarpSequence( warpItem );
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
			float unit = 1f / ( 60f * 5f );

			this.WarpPercent += unit;

			float invPerc = 1f - this.WarpPercent;
			int useTime = (int)( invPerc * (float)warpItem.useTime );

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
