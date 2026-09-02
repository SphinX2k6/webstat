using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006685 RID: 26245
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingBuffOverviewData : IMowingBuffOverviewData
	{
		// Token: 0x17009FE7 RID: 40935
		// (get) Token: 0x060418E1 RID: 268513 RVA: 0x010D0E57 File Offset: 0x010CF057
		// (set) Token: 0x060418E2 RID: 268514 RVA: 0x010D0E5F File Offset: 0x010CF05F
		public IMowingBuffIntroduceData IntroduceData { get; set; }

		// Token: 0x17009FE8 RID: 40936
		// (get) Token: 0x060418E3 RID: 268515 RVA: 0x010D0E68 File Offset: 0x010CF068
		// (set) Token: 0x060418E4 RID: 268516 RVA: 0x010D0E70 File Offset: 0x010CF070
		public IMowingBuffGridGroupData[] BuffGroupData { get; set; }
	}
}
