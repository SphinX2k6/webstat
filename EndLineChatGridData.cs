using System;
using System.Runtime.CompilerServices;

// Token: 0x02002585 RID: 9605
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EndLineChatGridData : MultiTemplateGridDataBase<bool, EndLineChatItem>
{
	// Token: 0x06012ACD RID: 76493 RVA: 0x00526213 File Offset: 0x00524413
	public EndLineChatGridData(bool data)
	{
		base.Data = data;
	}

	// Token: 0x06012ACE RID: 76494 RVA: 0x00526222 File Offset: 0x00524422
	public override int GetTemplateIndex()
	{
		return 6;
	}

	// Token: 0x06012ACF RID: 76495 RVA: 0x00526225 File Offset: 0x00524425
	public override EndLineChatItem CreateProxy()
	{
		return new EndLineChatItem();
	}
}
