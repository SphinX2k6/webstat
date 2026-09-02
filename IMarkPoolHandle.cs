using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;

// Token: 0x02002241 RID: 8769
[NullableContext(1)]
public interface IMarkPoolHandle
{
	// Token: 0x1700146D RID: 5229
	// (get) Token: 0x060108DB RID: 67803
	// (set) Token: 0x060108DC RID: 67804
	double RecycleTimeStamp { get; set; }

	// Token: 0x1700146E RID: 5230
	// (get) Token: 0x060108DD RID: 67805
	// (set) Token: 0x060108DE RID: 67806
	MarkPanelBase Obj { get; set; }

	// Token: 0x1700146F RID: 5231
	// (get) Token: 0x060108DF RID: 67807
	// (set) Token: 0x060108E0 RID: 67808
	int? RefCount { get; set; }
}
