using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006689 RID: 26249
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingRiskInstanceRecommendData : IMowingRiskInstanceRecommendData
	{
		// Token: 0x17009FF4 RID: 40948
		// (get) Token: 0x060418FD RID: 268541 RVA: 0x010D0ECD File Offset: 0x010CF0CD
		// (set) Token: 0x060418FE RID: 268542 RVA: 0x010D0ED5 File Offset: 0x010CF0D5
		public string TextId { get; set; }

		// Token: 0x17009FF5 RID: 40949
		// (get) Token: 0x060418FF RID: 268543 RVA: 0x010D0EDE File Offset: 0x010CF0DE
		// (set) Token: 0x06041900 RID: 268544 RVA: 0x010D0EE6 File Offset: 0x010CF0E6
		public string[] TextArgs { get; set; }

		// Token: 0x17009FF6 RID: 40950
		// (get) Token: 0x06041901 RID: 268545 RVA: 0x010D0EEF File Offset: 0x010CF0EF
		// (set) Token: 0x06041902 RID: 268546 RVA: 0x010D0EF7 File Offset: 0x010CF0F7
		public int RecommendLevel { get; set; }
	}
}
