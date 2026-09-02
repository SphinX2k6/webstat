using System;
using System.Runtime.CompilerServices;

// Token: 0x02001926 RID: 6438
public abstract class CommonSort
{
	// Token: 0x0600B91B RID: 47387 RVA: 0x00313AA5 File Offset: 0x00311CA5
	public void InitSortMap()
	{
		if (this.IsInit)
		{
			return;
		}
		this.IsInit = true;
		this.OnInitSortMap();
	}

	// Token: 0x0600B91C RID: 47388
	protected abstract void OnInitSortMap();

	// Token: 0x0600B91D RID: 47389
	[NullableContext(2)]
	public abstract TSortResult GetSortFunctionByRuleId(int ruleId);

	// Token: 0x0400571C RID: 22300
	protected bool IsInit;
}
