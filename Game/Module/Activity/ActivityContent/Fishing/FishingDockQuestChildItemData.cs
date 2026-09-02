using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200680E RID: 26638
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingDockQuestChildItemData : IFishingDockQuestChildItemData
	{
		// Token: 0x1700A17E RID: 41342
		// (get) Token: 0x0604265A RID: 271962 RVA: 0x01104F7D File Offset: 0x0110317D
		// (set) Token: 0x0604265B RID: 271963 RVA: 0x01104F85 File Offset: 0x01103185
		public string DesText { get; set; }

		// Token: 0x1700A17F RID: 41343
		// (get) Token: 0x0604265C RID: 271964 RVA: 0x01104F8E File Offset: 0x0110318E
		// (set) Token: 0x0604265D RID: 271965 RVA: 0x01104F96 File Offset: 0x01103196
		public int MaxCount { get; set; }

		// Token: 0x1700A180 RID: 41344
		// (get) Token: 0x0604265E RID: 271966 RVA: 0x01104F9F File Offset: 0x0110319F
		// (set) Token: 0x0604265F RID: 271967 RVA: 0x01104FA7 File Offset: 0x011031A7
		public int CurrentCount { get; set; }
	}
}
