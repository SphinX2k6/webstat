using System;
using System.Runtime.CompilerServices;

// Token: 0x02002575 RID: 9589
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class SettingViewLeftDialogItemData : MultiTemplateGridDataBase<PhoneMsgDialogItemData, PhoneMsgDialogItem>
{
	// Token: 0x06012A76 RID: 76406 RVA: 0x00524C3B File Offset: 0x00522E3B
	public override int GetTemplateIndex()
	{
		return 1;
	}

	// Token: 0x06012A77 RID: 76407 RVA: 0x00524C3E File Offset: 0x00522E3E
	public override PhoneMsgDialogItem CreateProxy()
	{
		return new PhoneMsgDialogItem
		{
			OnToggleCallBack = this.OnToggleCallBack
		};
	}

	// Token: 0x06012A78 RID: 76408 RVA: 0x00524C51 File Offset: 0x00522E51
	public SettingViewLeftDialogItemData(PhoneMsgDialogItemData dialogData)
	{
		base.Data = dialogData;
	}

	// Token: 0x06012A79 RID: 76409 RVA: 0x00524C60 File Offset: 0x00522E60
	public int GetDialogId()
	{
		return base.Data.DialogId;
	}

	// Token: 0x040091BC RID: 37308
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, PhoneMsgDialogItemData> OnToggleCallBack;
}
