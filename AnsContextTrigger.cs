using System;
using System.Runtime.CompilerServices;

// Token: 0x02002C7D RID: 11389
[NullableContext(1)]
[Nullable(0)]
public class AnsContextTrigger
{
	// Token: 0x17001E07 RID: 7687
	// (get) Token: 0x06016D8A RID: 93578 RVA: 0x006567D1 File Offset: 0x006549D1
	public Action<UiAnsContextBase> OnBegin { get; }

	// Token: 0x17001E08 RID: 7688
	// (get) Token: 0x06016D8B RID: 93579 RVA: 0x006567D9 File Offset: 0x006549D9
	public Action<UiAnsContextBase> OnEnd { get; }

	// Token: 0x06016D8C RID: 93580 RVA: 0x006567E1 File Offset: 0x006549E1
	public AnsContextTrigger(Action<UiAnsContextBase> onBegin, Action<UiAnsContextBase> onEnd)
	{
		this.OnBegin = onBegin;
		this.OnEnd = onEnd;
	}
}
