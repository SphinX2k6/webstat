using System;
using System.Runtime.CompilerServices;

// Token: 0x0200258B RID: 9611
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class SelfChatGridData : MultiTemplateGridDataBase<PhoneMsgChatData, PhoneMsgSelfChatItem>
{
	// Token: 0x06012AF9 RID: 76537 RVA: 0x00527082 File Offset: 0x00525282
	public SelfChatGridData(PhoneMsgChatData data)
	{
		base.Data = data;
	}

	// Token: 0x06012AFA RID: 76538 RVA: 0x00527091 File Offset: 0x00525291
	public override int GetTemplateIndex()
	{
		return 1;
	}

	// Token: 0x06012AFB RID: 76539 RVA: 0x00527094 File Offset: 0x00525294
	public override PhoneMsgSelfChatItem CreateProxy()
	{
		return new PhoneMsgSelfChatItem
		{
			OnOptionItemClickDelegate = this.OnOptionItemClickDelegate,
			OnItemClickDelegate = this.OnItemClickDelegate
		};
	}

	// Token: 0x0400921E RID: 37406
	[Nullable(2)]
	public Action<int, int> OnOptionItemClickDelegate;

	// Token: 0x0400921F RID: 37407
	[Nullable(2)]
	public Action<int> OnItemClickDelegate;
}
