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
					return false;
				}
				if( config.Get<bool>( nameof(config.ChaosStateBlocksWarpItems) ) ) {
					if( player.HasBuff(BuffID.ChaosState) ) {
						return false;
					}
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
