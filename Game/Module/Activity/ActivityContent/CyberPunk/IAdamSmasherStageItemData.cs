using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006972 RID: 26994
	[NullableContext(1)]
	public interface IAdamSmasherStageItemData
	{
		// Token: 0x1700A1D9 RID: 41433
		// (get) Token: 0x06042FC0 RID: 274368
		int StageId { get; }

		// Token: 0x1700A1DA RID: 41434
		// (get) Token: 0x06042FC1 RID: 274369
		string IndexText { get; }

		// Token: 0x1700A1DB RID: 41435
		// (get) Token: 0x06042FC2 RID: 274370
		string Name { get; }

		// Token: 0x1700A1DC RID: 41436
		// (get) Token: 0x06042FC3 RID: 274371
		bool IsUnlocked { get; }

		// Token: 0x1700A1DD RID: 41437
		// (get) Token: 0x06042FC4 RID: 274372
		bool IsHard { get; }
	}
}
