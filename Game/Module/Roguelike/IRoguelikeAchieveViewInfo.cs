using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005136 RID: 20790
	[NullableContext(2)]
	public interface IRoguelikeAchieveViewInfo
	{
		// Token: 0x17008C63 RID: 35939
		// (get) Token: 0x0603585C RID: 219228
		// (set) Token: 0x0603585D RID: 219229
		ERoguelikeAchieveViewMode Mode { get; set; }

		// Token: 0x17008C64 RID: 35940
		// (get) Token: 0x0603585E RID: 219230
		// (set) Token: 0x0603585F RID: 219231
		RogueArchiveInfoData TempRecordInfo { get; set; }
	}
}
