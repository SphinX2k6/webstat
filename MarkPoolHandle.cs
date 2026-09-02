using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;

// Token: 0x02002245 RID: 8773
[NullableContext(1)]
[Nullable(0)]
public class MarkPoolHandle : IMarkPoolHandle
{
	// Token: 0x17001470 RID: 5232
	// (get) Token: 0x060108F2 RID: 67826 RVA: 0x00487408 File Offset: 0x00485608
	// (set) Token: 0x060108F3 RID: 67827 RVA: 0x00487410 File Offset: 0x00485610
	public double RecycleTimeStamp { get; set; }

	// Token: 0x17001471 RID: 5233
	// (get) Token: 0x060108F4 RID: 67828 RVA: 0x00487419 File Offset: 0x00485619
	// (set) Token: 0x060108F5 RID: 67829 RVA: 0x00487421 File Offset: 0x00485621
	public MarkPanelBase Obj { get; set; }

	// Token: 0x17001472 RID: 5234
	// (get) Token: 0x060108F6 RID: 67830 RVA: 0x0048742A File Offset: 0x0048562A
	// (set) Token: 0x060108F7 RID: 67831 RVA: 0x00487432 File Offset: 0x00485632
	public int? RefCount { get; set; }
}
