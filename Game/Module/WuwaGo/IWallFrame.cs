using System;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004A9C RID: 19100
	public interface IWallFrame
	{
		// Token: 0x170084B3 RID: 33971
		// (get) Token: 0x06031CEF RID: 204015
		// (set) Token: 0x06031CF0 RID: 204016
		int WallNormalX { get; set; }

		// Token: 0x170084B4 RID: 33972
		// (get) Token: 0x06031CF1 RID: 204017
		// (set) Token: 0x06031CF2 RID: 204018
		int WallNormalY { get; set; }

		// Token: 0x170084B5 RID: 33973
		// (get) Token: 0x06031CF3 RID: 204019
		// (set) Token: 0x06031CF4 RID: 204020
		int WallTangentX { get; set; }

		// Token: 0x170084B6 RID: 33974
		// (get) Token: 0x06031CF5 RID: 204021
		// (set) Token: 0x06031CF6 RID: 204022
		int WallTangentY { get; set; }

		// Token: 0x170084B7 RID: 33975
		// (get) Token: 0x06031CF7 RID: 204023
		// (set) Token: 0x06031CF8 RID: 204024
		int OwnerSign { get; set; }

		// Token: 0x170084B8 RID: 33976
		// (get) Token: 0x06031CF9 RID: 204025
		// (set) Token: 0x06031CFA RID: 204026
		float OwnerOffsetX { get; set; }

		// Token: 0x170084B9 RID: 33977
		// (get) Token: 0x06031CFB RID: 204027
		// (set) Token: 0x06031CFC RID: 204028
		float OwnerOffsetY { get; set; }
	}
}
