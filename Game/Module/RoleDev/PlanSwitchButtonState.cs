using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x0200504B RID: 20555
	[NullableContext(1)]
	[Nullable(0)]
	public class PlanSwitchButtonState : IPlanSwitchButtonState
	{
		// Token: 0x17008B3E RID: 35646
		// (get) Token: 0x06034EC3 RID: 216771 RVA: 0x00D469A6 File Offset: 0x00D44BA6
		// (set) Token: 0x06034EC4 RID: 216772 RVA: 0x00D469AE File Offset: 0x00D44BAE
		public bool IsShow { get; set; }

		// Token: 0x17008B3F RID: 35647
		// (get) Token: 0x06034EC5 RID: 216773 RVA: 0x00D469B7 File Offset: 0x00D44BB7
		// (set) Token: 0x06034EC6 RID: 216774 RVA: 0x00D469BF File Offset: 0x00D44BBF
		public string Text { get; set; }

		// Token: 0x17008B40 RID: 35648
		// (get) Token: 0x06034EC7 RID: 216775 RVA: 0x00D469C8 File Offset: 0x00D44BC8
		// (set) Token: 0x06034EC8 RID: 216776 RVA: 0x00D469D0 File Offset: 0x00D44BD0
		public bool IsHighlight { get; set; }
	}
}
