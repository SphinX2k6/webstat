using System;
using System.Runtime.CompilerServices;

// Token: 0x020022F4 RID: 8948
public class MotorcycleDiyEditPartTabItem : MotorcycleDiyPartTabItem
{
	// Token: 0x06010EFE RID: 69374 RVA: 0x004A37E9 File Offset: 0x004A19E9
	[NullableContext(1)]
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		base.OnRefresh(data, isSelected, gridIndex);
		base.SetPreviewRedDotVisible(false);
	}
}
