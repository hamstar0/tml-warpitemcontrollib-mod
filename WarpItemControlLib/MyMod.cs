using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using HamstarHelpers.Services.Timers;


namespace WarpItemControlLib {
	public partial class WICLibMod : Mod {
		public static string GithubUserName => "hamstar0";
		public static string GithubProjectName => "tml-warpitemcontrollib-mod";


		////////////////

		public static WICLibMod Instance { get; private set; }



		////////////////

		internal static void ShowAlert( string msg ) {
			Timers.SetTimer( "WICAlert_"+msg, 2, false, () => {
				Main.NewText( msg, Color.Yellow );
				return false;
			} );
		}



		////////////////

		public override void Load() {
			WICLibMod.Instance = this;
			WICLibConfig.Instance = ModContent.GetInstance<WICLibConfig>();
		}

		public override void Unload() {
			WICLibConfig.Instance = null;
			WICLibMod.Instance = null;
		}
	}
}