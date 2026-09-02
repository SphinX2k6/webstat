using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Letter
{
	// Token: 0x02005A1B RID: 23067
	[NullableContext(1)]
	public interface IWriteLetterViewOpenParam
	{
		// Token: 0x170094CC RID: 38092
		// (get) Token: 0x0603A663 RID: 239203
		// (set) Token: 0x0603A664 RID: 239204
		string FlowListName { get; set; }

		// Token: 0x170094CD RID: 38093
		// (get) Token: 0x0603A665 RID: 239205
		// (set) Token: 0x0603A666 RID: 239206
		int FlowId { get; set; }

		// Token: 0x170094CE RID: 38094
		// (get) Token: 0x0603A667 RID: 239207
		// (set) Token: 0x0603A668 RID: 239208
		int StateId { get; set; }

		// Token: 0x170094CF RID: 38095
		// (get) Token: 0x0603A669 RID: 239209
		// (set) Token: 0x0603A66A RID: 239210
		ELetterStyle LetterStyle { get; set; }

		// Token: 0x170094D0 RID: 38096
		// (get) Token: 0x0603A66B RID: 239211
		// (set) Token: 0x0603A66C RID: 239212
		[Nullable(2)]
		string GameplayId { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170094D1 RID: 38097
		// (get) Token: 0x0603A66D RID: 239213
		// (set) Token: 0x0603A66E RID: 239214
		int? LetterId { get; set; }
	}
}
