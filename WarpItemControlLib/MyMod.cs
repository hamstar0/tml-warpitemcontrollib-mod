using Terraria.ModLoader;


namespace WarpItemControlLib {
	public class WICLibMod : Mod {
		public static string GithubUserName => "hamstar0";
		public static string GithubProjectName => "tml-warpitemcontrollib-mod";


		////////////////

		public static WICLibMod Instance { get; private set; }



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