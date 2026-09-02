using System;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005938 RID: 22840
	public interface IFetterStarLvData
	{
		// Token: 0x17009450 RID: 37968
		// (get) Token: 0x06039F26 RID: 237350
		// (set) Token: 0x06039F27 RID: 237351
		int StageLv { get; set; }

		// Token: 0x17009451 RID: 37969
		// (get) Token: 0x06039F28 RID: 237352
		// (set) Token: 0x06039F29 RID: 237353
		int StageStarLv { get; set; }

		// Token: 0x17009452 RID: 37970
		// (get) Token: 0x06039F2A RID: 237354
		// (set) Token: 0x06039F2B RID: 237355
		int CurrentLv { get; set; }

		// Token: 0x17009453 RID: 37971
		// (get) Token: 0x06039F2C RID: 237356
		// (set) Token: 0x06039F2D RID: 237357
		int MaxLv { get; set; }
	}
}
