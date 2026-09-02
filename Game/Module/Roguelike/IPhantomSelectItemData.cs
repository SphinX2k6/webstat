using System;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005110 RID: 20752
	public interface IPhantomSelectItemData
	{
		// Token: 0x17008C55 RID: 35925
		// (get) Token: 0x0603576C RID: 218988
		// (set) Token: 0x0603576D RID: 218989
		int PhantomId { get; set; }

		// Token: 0x17008C56 RID: 35926
		// (get) Token: 0x0603576E RID: 218990
		// (set) Token: 0x0603576F RID: 218991
		int Index { get; set; }

		// Token: 0x17008C57 RID: 35927
		// (get) Token: 0x06035770 RID: 218992
		// (set) Token: 0x06035771 RID: 218993
		bool IsLock { get; set; }
	}
}
