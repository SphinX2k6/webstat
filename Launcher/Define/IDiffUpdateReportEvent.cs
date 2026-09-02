using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x02004666 RID: 18022
	[NullableContext(1)]
	public interface IDiffUpdateReportEvent
	{
		// Token: 0x0602EFF2 RID: 192498
		void Start(HotPatchLog log, [Nullable(2)] string suffixTag = null);

		// Token: 0x0602EFF3 RID: 192499
		void End(HotPatchLog log, [Nullable(2)] string suffixTag = null);

		// Token: 0x0602EFF4 RID: 192500
		void Event(HotPatchLog log, [Nullable(2)] string suffixTag = null);
	}
}
