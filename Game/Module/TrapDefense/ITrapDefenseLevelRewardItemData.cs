using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DE9 RID: 19945
	[NullableContext(1)]
	public interface ITrapDefenseLevelRewardItemData
	{
		// Token: 0x17008896 RID: 34966
		// (get) Token: 0x06033985 RID: 211333
		ETrapDefenseLevelRewardItemType ItemType { get; }

		// Token: 0x17008897 RID: 34967
		// (get) Token: 0x06033986 RID: 211334
		string TypeNameKey { get; }

		// Token: 0x17008898 RID: 34968
		// (get) Token: 0x06033987 RID: 211335
		TrapDefenseLevelData LevelData { get; }
	}
}
