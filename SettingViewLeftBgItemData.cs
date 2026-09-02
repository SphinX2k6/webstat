using System;
using System.Runtime.CompilerServices;

// Token: 0x02002576 RID: 9590
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class SettingViewLeftBgItemData : MultiTemplateGridDataBase<PhoneMsgBgItemData, PhoneMsgBgItem>
{
	// Token: 0x06012A7A RID: 76410 RVA: 0x00524C6D File Offset: 0x00522E6D
	public override int GetTemplateIndex()
	{
		return 0;
	}

	// Token: 0x06012A7B RID: 76411 RVA: 0x00524C70 File Offset: 0x00522E70
	public override PhoneMsgBgItem CreateProxy()
	{
		return new PhoneMsgBgItem
		{
			OnToggleCallBack = this.OnToggleCallBack
		};
	}

	// Token: 0x06012A7C RID: 76412 RVA: 0x00524C83 File Offset: 0x00522E83
	public SettingViewLeftBgItemData(PhoneMsgBgItemData bgData)
	{
		base.Data = bgData;
	}

	// Token: 0x06012A7D RID: 76413 RVA: 0x00524C92 File Offset: 0x00522E92
	public int GetBgId()
	{
		return base.Data.BgId;
	}

	// Token: 0x040091BD RID: 37309
	public int Index;

	// Token: 0x040091BE RID: 37310
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, PhoneMsgBgItemData> OnToggleCallBack;
}
