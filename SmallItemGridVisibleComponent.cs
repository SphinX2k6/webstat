using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A41 RID: 6721
public class SmallItemGridVisibleComponent : SmallItemGridComponent
{
	// Token: 0x0600C06B RID: 49259 RVA: 0x0032D134 File Offset: 0x0032B334
	[NullableContext(1)]
	protected override void OnRefresh(object bVisible)
	{
		this.SetActive((bVisible as bool?).GetValueOrDefault());
	}
}
