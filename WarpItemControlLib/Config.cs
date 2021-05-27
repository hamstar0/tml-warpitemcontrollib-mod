using System;
using System.ComponentModel;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader.Config;


namespace WarpItemControlLib {
	public partial class WICLibConfig : ModConfig {
		public static WICLibConfig Instance { get; internal set; }



		////////////////

		public override ConfigScope Mode => ConfigScope.ServerSide;



		////////////////

		public bool WarpItemsBlocked { get; set; } = false;


		[Range( 0, 60 * 60 )]
		[DefaultValue( (int)( 3f * 60f ) )]
		public int WarpItemBaseWarmupTickDuration { get; set; } = (int)( 3f * 60f );

		[Range( 0, 60 * 60 )]
		[DefaultValue( (int)( 2.5f * 60f ) )]
		public int RecallPotionBaseWarmupTickDuration { get; set; } = (int)( 2.5f * 60f );


		public bool ChaosStateBlocksWarpItems { get; set; } = false;

		[Range( 0, 10000 )]
		[DefaultValue( 100 )]
		public int ChaosStateHurtsFromWarpItems { get; set; } = 100;

		[Range( 0, 60 * 60 * 60 )]
		[DefaultValue( 10 * 60 )]
		public int ChaosStateTickDurationFromWarp { get; set; } = 10 * 60;


		[DefaultValue( true )]
		public bool WarpWarmupInterruptedByMovement { get; set; } = true;


		////

		public List<ItemDefinition> WarpItems = new List<ItemDefinition> {
			new ItemDefinition(ItemID.MagicMirror),
			new ItemDefinition(ItemID.CellPhone),
			new ItemDefinition(ItemID.IceMirror),
			new ItemDefinition(ItemID.RecallPotion)
		};
	}
}
