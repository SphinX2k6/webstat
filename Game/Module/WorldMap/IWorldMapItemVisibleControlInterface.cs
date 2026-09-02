using System;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B3B RID: 19259
	public interface IWorldMapItemVisibleControlInterface
	{
		// Token: 0x17008620 RID: 34336
		// (get) Token: 0x060323D3 RID: 205779
		// (set) Token: 0x060323D4 RID: 205780
		EWorldMapShowMode ShowMode { get; set; }

		// Token: 0x060323D5 RID: 205781
		void SetWorldMapSelfShow(EWorldMapShowMode showMode);

		// Token: 0x060323D6 RID: 205782
		void RefreshWorldMapSelfShow(EWorldMapShowMode showMode);
	}
}
