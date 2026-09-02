using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001D33 RID: 7475
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CollectionTypeItemData : MultiTemplateGridDataBase<MotorFightItemType, CollectionTypeItem>
{
	// Token: 0x0600DC15 RID: 56341 RVA: 0x003B2819 File Offset: 0x003B0A19
	public override int GetTemplateIndex()
	{
		return 0;
	}

	// Token: 0x0600DC16 RID: 56342 RVA: 0x003B281C File Offset: 0x003B0A1C
	public override CollectionTypeItem CreateProxy()
	{
		return new CollectionTypeItem();
	}
}
