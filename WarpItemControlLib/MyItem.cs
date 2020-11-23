using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.Players;


namespace WarpItemControlLib {
	class WICItem : GlobalItem {
		public override bool CanUseItem( Item item, Player player ) {
			var config = WICLibConfig.Instance;

			switch( item.type ) {
			case ItemID.MagicMirror:
			case ItemID.CellPhone:
			case ItemID.IceMirror:
			case ItemID.RecallPotion:
				if( config.Get<bool>( nameof(config.WarpItemsBlocked) ) ) {
					if( player.whoAmI == Main.myPlayer ) {
						WICLibMod.ShowAlert( "Warp items disabled by config." );
					}
					return false;
				}
				if( config.Get<bool>( nameof(config.ChaosStateBlocksWarpItems) ) ) {
					if( player.HasBuff(BuffID.ChaosState) ) {
						if( player.whoAmI == Main.myPlayer ) {
							WICLibMod.ShowAlert( "Warp items disabled by Chaos State." );
						}
						return false;
					}
				}

				var myplayer = player.GetModPlayer<WICPlayer>();
				if( !myplayer.IsWarpEnabled ) {
					if( player.whoAmI == Main.myPlayer ) {
						WICLibMod.ShowAlert( myplayer.WarpDeniedMessage );
					}
					return false;
				}

				break;
			}
			return base.CanUseItem( item, player );
		}


		public override bool UseItem( Item item, Player player ) {
			var config = WICLibConfig.Instance;

			switch( item.type ) {
			case ItemID.MagicMirror:
			case ItemID.CellPhone:
			case ItemID.IceMirror:
			case ItemID.RecallPotion:
				if( player.HasBuff( BuffID.ChaosState ) ) {
					int hurtAmt = config.Get<int>( nameof(config.ChaosStateHurtsFromWarpItems) );

					if( hurtAmt > 0 ) {
						PlayerHelpers.RawHurt(
							player: player,
							deathReason: PlayerDeathReason.ByCustomReason(" disintegrated"),
							damage: hurtAmt,
							direction: 0
						);
						return false;
					}
				}
				break;
			}
			return base.UseItem( item, player );
		}
	}
}
