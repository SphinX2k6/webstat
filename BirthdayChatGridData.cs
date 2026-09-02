using System;
using System.Runtime.CompilerServices;

// Token: 0x02002581 RID: 9601
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BirthdayChatGridData : MultiTemplateGridDataBase<PhoneMsgChatData, BirthdayChatItem>
{
	// Token: 0x06012AB5 RID: 76469 RVA: 0x00525BA7 File Offset: 0x00523DA7
	public BirthdayChatGridData(PhoneMsgChatData data)
	{
		base.Data = data;
	}

	// Token: 0x06012AB6 RID: 76470 RVA: 0x00525BB6 File Offset: 0x00523DB6
	public override int GetTemplateIndex()
	{
		return 4;
	}

	// Token: 0x06012AB7 RID: 76471 RVA: 0x00525BB9 File Offset: 0x00523DB9
	public override BirthdayChatItem CreateProxy()
	{
		return new BirthdayChatItem();
	}
}
