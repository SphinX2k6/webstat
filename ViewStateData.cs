using System;
using System.Runtime.CompilerServices;

// Token: 0x020013B4 RID: 5044
[NullableContext(2)]
[Nullable(0)]
internal class ViewStateData
{
	// Token: 0x06008B33 RID: 35635 RVA: 0x0024AB55 File Offset: 0x00248D55
	public ViewStateData(EBusinessSkipDefine viewState, Action exitFunc, Delegate enterFunc)
	{
		this.ViewState = viewState;
		this.ExitFunc = exitFunc;
		this.EnterFunc = enterFunc;
	}

	// Token: 0x04004106 RID: 16646
	public EBusinessSkipDefine ViewState;

	// Token: 0x04004107 RID: 16647
	public Action ExitFunc;

	// Token: 0x04004108 RID: 16648
	public Delegate EnterFunc;

	// Token: 0x04004109 RID: 16649
	[Nullable(1)]
	public object[] Params = Array.Empty<object>();
}
