using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FAD RID: 20397
	[NullableContext(1)]
	[JsonConverter(typeof(SheriffQuestionJsonConfigConverter))]
	public interface ISheriffQuestionJsonConfig
	{
		// Token: 0x17008A5A RID: 35418
		// (get) Token: 0x06034A2C RID: 215596
		// (set) Token: 0x06034A2D RID: 215597
		int QuestionId { get; set; }

		// Token: 0x17008A5B RID: 35419
		// (get) Token: 0x06034A2E RID: 215598
		// (set) Token: 0x06034A2F RID: 215599
		List<ISheriffQuestionResultJsonConfig> ResultConfigs { get; set; }
	}
}
