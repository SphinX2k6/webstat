using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006688 RID: 26248
	[NullableContext(1)]
	public interface IMowingRiskInstanceRecommendData
	{
		// Token: 0x17009FF1 RID: 40945
		// (get) Token: 0x060418F7 RID: 268535
		// (set) Token: 0x060418F8 RID: 268536
		string TextId { get; set; }

		// Token: 0x17009FF2 RID: 40946
		// (get) Token: 0x060418F9 RID: 268537
		// (set) Token: 0x060418FA RID: 268538
		string[] TextArgs { get; set; }

		// Token: 0x17009FF3 RID: 40947
		// (get) Token: 0x060418FB RID: 268539
		// (set) Token: 0x060418FC RID: 268540
		int RecommendLevel { get; set; }
	}
}
