using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A32 RID: 6706
[NullableContext(1)]
[Nullable(0)]
public class SmallItemGridNotFoundComponent : SmallItemGridVisibleComponent
{
	// Token: 0x0600C025 RID: 49189 RVA: 0x0032C8C3 File Offset: 0x0032AAC3
	protected override string GetResourceId()
	{
		return "UiItem_ItemBNotFound";
	}

	// Token: 0x0600C026 RID: 49190 RVA: 0x0032C8CC File Offset: 0x0032AACC
	protected override void OnRefresh(object bVisible)
	{
		base.OnRefresh(bVisible);
		this.SetActive((bVisible as bool?).GetValueOrDefault());
	}

	// Token: 0x0600C027 RID: 49191 RVA: 0x0032C8F9 File Offset: 0x0032AAF9
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}
}
