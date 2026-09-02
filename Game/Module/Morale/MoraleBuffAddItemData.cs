using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x0200570B RID: 22283
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleBuffAddItemData : IMoraleBuffAddItemData
	{
		// Token: 0x1700911D RID: 37149
		// (get) Token: 0x06038B79 RID: 232313 RVA: 0x00E5C86A File Offset: 0x00E5AA6A
		// (set) Token: 0x06038B7A RID: 232314 RVA: 0x00E5C872 File Offset: 0x00E5AA72
		public string IconPath { get; set; } = "";

		// Token: 0x1700911E RID: 37150
		// (get) Token: 0x06038B7B RID: 232315 RVA: 0x00E5C87B File Offset: 0x00E5AA7B
		// (set) Token: 0x06038B7C RID: 232316 RVA: 0x00E5C883 File Offset: 0x00E5AA83
		public string NameKey { get; set; } = "";

		// Token: 0x1700911F RID: 37151
		// (get) Token: 0x06038B7D RID: 232317 RVA: 0x00E5C88C File Offset: 0x00E5AA8C
		// (set) Token: 0x06038B7E RID: 232318 RVA: 0x00E5C894 File Offset: 0x00E5AA94
		public string Value { get; set; } = "";
	}
}
