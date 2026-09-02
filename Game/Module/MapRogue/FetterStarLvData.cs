using System;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005939 RID: 22841
	public class FetterStarLvData : IFetterStarLvData
	{
		// Token: 0x17009454 RID: 37972
		// (get) Token: 0x06039F2E RID: 237358 RVA: 0x00EAAAC0 File Offset: 0x00EA8CC0
		// (set) Token: 0x06039F2F RID: 237359 RVA: 0x00EAAAC8 File Offset: 0x00EA8CC8
		public int StageLv { get; set; }

		// Token: 0x17009455 RID: 37973
		// (get) Token: 0x06039F30 RID: 237360 RVA: 0x00EAAAD1 File Offset: 0x00EA8CD1
		// (set) Token: 0x06039F31 RID: 237361 RVA: 0x00EAAAD9 File Offset: 0x00EA8CD9
		public int StageStarLv { get; set; }

		// Token: 0x17009456 RID: 37974
		// (get) Token: 0x06039F32 RID: 237362 RVA: 0x00EAAAE2 File Offset: 0x00EA8CE2
		// (set) Token: 0x06039F33 RID: 237363 RVA: 0x00EAAAEA File Offset: 0x00EA8CEA
		public int CurrentLv { get; set; }

		// Token: 0x17009457 RID: 37975
		// (get) Token: 0x06039F34 RID: 237364 RVA: 0x00EAAAF3 File Offset: 0x00EA8CF3
		// (set) Token: 0x06039F35 RID: 237365 RVA: 0x00EAAAFB File Offset: 0x00EA8CFB
		public int MaxLv { get; set; }
	}
}
