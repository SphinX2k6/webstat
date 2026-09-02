using System;
using System.Runtime.CompilerServices;

// Token: 0x02002588 RID: 9608
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class OtherChatGridData : MultiTemplateGridDataBase<PhoneMsgChatData, PhoneMsgOtherChatItem>
{
	// Token: 0x06012AD2 RID: 76498 RVA: 0x00526236 File Offset: 0x00524436
	public OtherChatGridData(PhoneMsgChatData data)
	{
		base.Data = data;
	}

	// Token: 0x06012AD3 RID: 76499 RVA: 0x00526245 File Offset: 0x00524445
	public override int GetTemplateIndex()
	{
		return 0;
	}

	// Token: 0x06012AD4 RID: 76500 RVA: 0x00526248 File Offset: 0x00524448
	public override PhoneMsgOtherChatItem CreateProxy()
	{
		return new PhoneMsgOtherChatItem
		{
			OnItemClickDelegate = this.OnItemClickDelegate
		};
	}

	// Token: 0x040091F7 RID: 37367
	[Nullable(2)]
	public Action<int> OnItemClickDelegate;
}
