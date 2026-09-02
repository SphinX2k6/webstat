using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A3B RID: 6715
public class SmallItemGridSelectedFlagComponent : SmallItemGridVisibleComponent
{
	// Token: 0x0600C04A RID: 49226 RVA: 0x0032CCDD File Offset: 0x0032AEDD
	[NullableContext(2)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBRoleSel";
	}

	// Token: 0x0600C04B RID: 49227 RVA: 0x0032CCE4 File Offset: 0x0032AEE4
	[NullableContext(1)]
	protected override void OnRefresh(object bVisible)
	{
		base.OnRefresh(bVisible);
		base.SetUiActive((bool)bVisible);
	}

	// Token: 0x0600C04C RID: 49228 RVA: 0x0032CCF9 File Offset: 0x0032AEF9
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}
}
