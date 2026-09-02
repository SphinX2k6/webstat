using System;
using System.Runtime.CompilerServices;

// Token: 0x0200257B RID: 9595
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class TipsChatGridData : MultiTemplateGridDataBase<PhoneMsgChatData, TipsChatItem>
{
	// Token: 0x06012A9D RID: 76445 RVA: 0x00525501 File Offset: 0x00523701
	public TipsChatGridData(PhoneMsgChatData data)
	{
		base.Data = data;
	}

	// Token: 0x06012A9E RID: 76446 RVA: 0x00525510 File Offset: 0x00523710
	public override int GetTemplateIndex()
	{
		return 2;
	}

	// Token: 0x06012A9F RID: 76447 RVA: 0x00525513 File Offset: 0x00523713
	public override TipsChatItem CreateProxy()
	{
		return new TipsChatItem();
	}
}
