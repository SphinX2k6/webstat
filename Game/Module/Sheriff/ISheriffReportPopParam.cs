using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FC1 RID: 20417
	[NullableContext(1)]
	public interface ISheriffReportPopParam
	{
		// Token: 0x17008A88 RID: 35464
		// (get) Token: 0x06034A95 RID: 215701
		// (set) Token: 0x06034A96 RID: 215702
		int CriminalId { get; set; }

		// Token: 0x17008A89 RID: 35465
		// (get) Token: 0x06034A97 RID: 215703
		// (set) Token: 0x06034A98 RID: 215704
		Action CloseCallback { get; set; }
	}
}
