using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher
{
	// Token: 0x0200448F RID: 17551
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherNetworkDetectionResultLog : LauncherNetworkDetectionBaseLog
	{
		// Token: 0x0401A4A9 RID: 107689
		public new string event_id = "1066";

		// Token: 0x0401A4AA RID: 107690
		public float f_avg_ping;

		// Token: 0x0401A4AB RID: 107691
		public int i_cost_time;

		// Token: 0x0401A4AC RID: 107692
		public int i_pocket_lossrt;

		// Token: 0x0401A4AD RID: 107693
		public int i_result_id;

		// Token: 0x0401A4AE RID: 107694
		public int i_type;

		// Token: 0x0401A4AF RID: 107695
		public string s_trace_id = "";
	}
}
