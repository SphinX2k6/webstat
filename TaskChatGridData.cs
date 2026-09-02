using System;
using System.Runtime.CompilerServices;

// Token: 0x0200257F RID: 9599
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class TaskChatGridData : MultiTemplateGridDataBase<PhoneMsgChatData, TaskChatItem>
{
	// Token: 0x06012AAA RID: 76458 RVA: 0x0052580B File Offset: 0x00523A0B
	public TaskChatGridData(PhoneMsgChatData data)
	{
		base.Data = data;
	}

	// Token: 0x06012AAB RID: 76459 RVA: 0x0052581A File Offset: 0x00523A1A
	public override int GetTemplateIndex()
	{
		return 3;
	}

	// Token: 0x06012AAC RID: 76460 RVA: 0x0052581D File Offset: 0x00523A1D
	public override TaskChatItem CreateProxy()
	{
		return new TaskChatItem();
	}
}
