using System;
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

		[Range( 0f, 60f * 60f )]
		[DefaultValue( (int)( 3f * 60f ) )]
		public int WarpChargeDurationFrames = (int)( 3f * 60f );
	}
}
