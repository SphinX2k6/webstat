using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006684 RID: 26244
	[NullableContext(1)]
	public interface IMowingBuffOverviewData
	{
		// Token: 0x17009FE5 RID: 40933
		// (get) Token: 0x060418DD RID: 268509
		// (set) Token: 0x060418DE RID: 268510
		IMowingBuffIntroduceData IntroduceData { get; set; }

		// Token: 0x17009FE6 RID: 40934
		// (get) Token: 0x060418DF RID: 268511
		// (set) Token: 0x060418E0 RID: 268512
		IMowingBuffGridGroupData[] BuffGroupData { get; set; }
	}
}
