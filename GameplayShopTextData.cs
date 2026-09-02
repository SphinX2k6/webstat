using System;
using System.Runtime.CompilerServices;

// Token: 0x02002397 RID: 9111
[NullableContext(1)]
[Nullable(0)]
public class GameplayShopTextData
{
	// Token: 0x060117D5 RID: 71637 RVA: 0x004D02E8 File Offset: 0x004CE4E8
	public void SetContent(string content)
	{
		this.Content = content;
		this.Data = null;
	}

	// Token: 0x060117D6 RID: 71638 RVA: 0x004D02F8 File Offset: 0x004CE4F8
	[NullableContext(2)]
	public void SetData(TableTextArgNew data)
	{
		this.Data = data;
		this.Content = "";
	}

	// Token: 0x04008932 RID: 35122
	public string Content = "";

	// Token: 0x04008933 RID: 35123
	[Nullable(2)]
	public TableTextArgNew Data;
}
