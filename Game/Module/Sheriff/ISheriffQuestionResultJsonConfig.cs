using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FB0 RID: 20400
	[NullableContext(1)]
	[JsonConverter(typeof(SheriffQuestionResultJsonConfigConverter))]
	public interface ISheriffQuestionResultJsonConfig
	{
		// Token: 0x17008A5E RID: 35422
		// (get) Token: 0x06034A38 RID: 215608
		// (set) Token: 0x06034A39 RID: 215609
		List<int> ClueCombination { get; set; }

		// Token: 0x17008A5F RID: 35423
		// (get) Token: 0x06034A3A RID: 215610
		// (set) Token: 0x06034A3B RID: 215611
		List<string> ReasoningStateId { get; set; }

		// Token: 0x17008A60 RID: 35424
		// (get) Token: 0x06034A3C RID: 215612
		// (set) Token: 0x06034A3D RID: 215613
		List<string> ResultDesc { get; set; }

		// Token: 0x17008A61 RID: 35425
		// (get) Token: 0x06034A3E RID: 215614
		// (set) Token: 0x06034A3F RID: 215615
		int? NextQuestionId { get; set; }

		// Token: 0x17008A62 RID: 35426
		// (get) Token: 0x06034A40 RID: 215616
		// (set) Token: 0x06034A41 RID: 215617
		int? CaseProgressId { get; set; }

		// Token: 0x17008A63 RID: 35427
		// (get) Token: 0x06034A42 RID: 215618
		// (set) Token: 0x06034A43 RID: 215619
		int? EndingId { get; set; }
	}
}
