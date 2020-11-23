using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.Players;
using Terraria.DataStructures;


namespace WarpItemControlLib {
	class WICItem : GlobalItem {
		public override bool CanUseItem( Item item, Player player ) {
			switch( item.type ) {
			case ItemID.MagicMirror:
			case ItemID.CellPhone:
			case ItemID.IceMirror:
			case ItemID.RecallPotion:
				if( player.HasBuff( BuffID.ChaosState ) ) {
					if( WICLibConfig.Instance.ChaosStateBlocksWarpItems ) {
						return false;
					}
				}
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
				if( player.HasBuff( BuffID.ChaosState ) ) {
					if( WICLibConfig.Instance.ChaosStateHurtsFromWarpItems > 0 ) {
						PlayerHelpers.RawHurt(
							player: player,
							deathReason: PlayerDeathReason.ByCustomReason(" disintegrated"),
							damage: WICLibConfig.Instance.ChaosStateHurtsFromWarpItems,
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
