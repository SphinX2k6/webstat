using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A16 RID: 6678
[NullableContext(1)]
[Nullable(0)]
public class SmallItemGridBlackComponent : SmallItemGridComponent
{
	// Token: 0x0600BFC5 RID: 49093 RVA: 0x0032BCDA File Offset: 0x00329EDA
	protected override string GetResourceId()
	{
		return "UiItem_ItemBDark";
	}

	// Token: 0x0600BFC6 RID: 49094 RVA: 0x0032BCE4 File Offset: 0x00329EE4
	protected override void OnRefresh(object bVisible)
	{
		this.SetActive((bVisible as bool?).GetValueOrDefault());
	}
}
