using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MingSu
{
	// Token: 0x02005737 RID: 22327
	[NullableContext(1)]
	[Nullable(0)]
	public class UpData : IUpData
	{
		// Token: 0x1700912F RID: 37167
		// (get) Token: 0x06038D10 RID: 232720 RVA: 0x00E645ED File Offset: 0x00E627ED
		// (set) Token: 0x06038D11 RID: 232721 RVA: 0x00E645F5 File Offset: 0x00E627F5
		public int UseCoreCount { get; set; }

		// Token: 0x17009130 RID: 37168
		// (get) Token: 0x06038D12 RID: 232722 RVA: 0x00E645FE File Offset: 0x00E627FE
		// (set) Token: 0x06038D13 RID: 232723 RVA: 0x00E64606 File Offset: 0x00E62806
		public string CoreName { get; set; } = "";
	}
}
