using System;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DAA RID: 19882
	public interface ITrapDefenseLevelModeData<out TLevelData> where TLevelData : TrapDefenseLevelModeDataBase
	{
		// Token: 0x17008816 RID: 34838
		// (get) Token: 0x060337FA RID: 210938
		// (set) Token: 0x060337FB RID: 210939
		int ActivityId { get; set; }
	}
}
