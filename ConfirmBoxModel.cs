using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001A85 RID: 6789
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ConfirmBoxModel : ModelBase<ConfirmBoxModel>
{
	// Token: 0x0600C23B RID: 49723 RVA: 0x00332C21 File Offset: 0x00330E21
	protected override bool OnClear()
	{
		this.NotShowAgainSet.Clear();
		return true;
	}

	// Token: 0x04005D21 RID: 23841
	public readonly HashSet<EConfirmBoxConfigId> NotShowAgainSet = new HashSet<EConfirmBoxConfigId>();
}
