﻿using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;
using HamstarHelpers.Classes.UI.ModConfig;


namespace WarpItemControlLib {
	class MyFloatInputElement : FloatInputElement { }




	public partial class WICLibConfig : ModConfig {
		public static WICLibConfig Instance { get; internal set; }



		////////////////

		public override ConfigScope Mode => ConfigScope.ServerSide;



		////////////////

		public bool WarpItemsBlocked { get; set; } = false;


		[Range( 0, 60 * 60 )]
		[DefaultValue( (int)( 3f * 60f ) )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public int WarpItemBaseWarmupTickDuration { get; set; } = (int)( 3f * 60f );

		[Range( 0, 60 * 60 )]
		[DefaultValue( (int)( 2.5f * 60f ) )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public int RecallPotionBaseWarmupTickDuration { get; set; } = (int)( 2.5f * 60f );


		public bool ChaosStateBlocksWarpItems { get; set; } = false;

		[Range( 0, 10000 )]
		[DefaultValue( 100 )]
		public int ChaosStateHurtsFromWarpItems { get; set; } = 100;


		[DefaultValue( true )]
		public bool WarpWarmupInterruptedByMovement { get; set; } = true;
	}
}
