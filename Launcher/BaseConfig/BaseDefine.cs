using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x0200468D RID: 18061
	[NullableContext(1)]
	[Nullable(0)]
	public static class BaseDefine
	{
		// Token: 0x0602F073 RID: 192627 RVA: 0x00B24BCD File Offset: 0x00B22DCD
		public static string GetPublicConfigPath()
		{
			return UBlueprintPathsLibrary.ProjectConfigDir() + "/Kuro/KuroPublicConfig.ini";
		}

		// Token: 0x0602F074 RID: 192628 RVA: 0x00B24BDE File Offset: 0x00B22DDE
		public static string GetLocalGameDataPath()
		{
			return UBlueprintPathsLibrary.ProjectConfigDir() + "../Saved/SaveGames/AkiSaveGame.conf";
		}

		// Token: 0x0401ACD0 RID: 109776
		public const int TRYLIMIT = 10;

		// Token: 0x0401ACD1 RID: 109777
		public const string USESDK = "1";

		// Token: 0x0401ACD2 RID: 109778
		public const string SDKON = "sdkon";

		// Token: 0x0401ACD3 RID: 109779
		public const string SDKOFF = "sdkoff";

		// Token: 0x0401ACD4 RID: 109780
		public const string EDITOR = "editor";

		// Token: 0x0401ACD5 RID: 109781
		public const string PACK = "pack";

		// Token: 0x0401ACD6 RID: 109782
		public const bool TESTCDNON = false;

		// Token: 0x0401ACD7 RID: 109783
		public const string TESTNOTICEURL = "";
	}
}
