using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005137 RID: 20791
	[NullableContext(2)]
	[Nullable(0)]
	public class RoguelikeAchieveViewInfo : IRoguelikeAchieveViewInfo
	{
		// Token: 0x17008C65 RID: 35941
		// (get) Token: 0x06035860 RID: 219232 RVA: 0x00D702CE File Offset: 0x00D6E4CE
		// (set) Token: 0x06035861 RID: 219233 RVA: 0x00D702D6 File Offset: 0x00D6E4D6
		public ERoguelikeAchieveViewMode Mode { get; set; }

		// Token: 0x17008C66 RID: 35942
		// (get) Token: 0x06035862 RID: 219234 RVA: 0x00D702DF File Offset: 0x00D6E4DF
		// (set) Token: 0x06035863 RID: 219235 RVA: 0x00D702E7 File Offset: 0x00D6E4E7
		public RogueArchiveInfoData TempRecordInfo { get; set; }
	}
}
