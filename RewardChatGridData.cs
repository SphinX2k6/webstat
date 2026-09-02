using System;
using System.Runtime.CompilerServices;

// Token: 0x02002583 RID: 9603
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class RewardChatGridData : MultiTemplateGridDataBase<PhoneMsgChatData, RewardChatItem>
{
	// Token: 0x06012AC2 RID: 76482 RVA: 0x00525FAF File Offset: 0x005241AF
	public RewardChatGridData(PhoneMsgChatData data)
	{
		base.Data = data;
	}

	// Token: 0x06012AC3 RID: 76483 RVA: 0x00525FBE File Offset: 0x005241BE
	public override int GetTemplateIndex()
	{
		return 5;
	}

	// Token: 0x06012AC4 RID: 76484 RVA: 0x00525FC1 File Offset: 0x005241C1
	public override RewardChatItem CreateProxy()
	{
		return new RewardChatItem
		{
			OnRewardClick = this.OnRewardClick
		};
	}

	// Token: 0x040091DF RID: 37343
	[Nullable(2)]
	public Action OnRewardClick;
}
