using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using HamstarHelpers.Services.Timers;


namespace WarpItemControlLib {
	public class WICLibMod : Mod {
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

		public WICLibMod() {
			WICLibMod.Instance = this;
		}

		////////////////

		public override void Load() {
			WICLibConfig.Instance = ModContent.GetInstance<WICLibConfig>();
		}

		public override void Unload() {
			WICLibConfig.Instance = null;
			WICLibMod.Instance = null;
		}
	}
}