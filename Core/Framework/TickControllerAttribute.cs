using System;

namespace CSharpScript.Core.Framework
{
	// Token: 0x0200712C RID: 28972
	[AttributeUsage(AttributeTargets.Class)]
	public class TickControllerAttribute : Attribute
	{
		// Token: 0x1700A5FC RID: 42492
		// (get) Token: 0x0604629D RID: 287389 RVA: 0x0126D238 File Offset: 0x0126B438
		// (set) Token: 0x0604629E RID: 287390 RVA: 0x0126D240 File Offset: 0x0126B440
		public int Priority { get; private set; }

		// Token: 0x0604629F RID: 287391 RVA: 0x0126D249 File Offset: 0x0126B449
		public TickControllerAttribute(int priority = 0)
		{
			this.Priority = priority;
		}
	}
}
