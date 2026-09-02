using System;
using System.Runtime.CompilerServices;

// Token: 0x02001D2F RID: 7471
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class CollectionGridItemData : MultiTemplateGridDataBase<MotorcycleArrowCollectionItemData, CollectionGridItem>
{
	// Token: 0x0600DBFF RID: 56319 RVA: 0x003B2352 File Offset: 0x003B0552
	public override int GetTemplateIndex()
	{
		return 1;
	}

	// Token: 0x0600DC00 RID: 56320 RVA: 0x003B2358 File Offset: 0x003B0558
	public override CollectionGridItem CreateProxy()
	{
		CollectionGridItem proxy = new CollectionGridItem();
		proxy.OnClickCb = delegate(MotorcycleArrowCollectionItemData data)
		{
			this.OnClickCb(data, proxy);
		};
		return proxy;
	}

	// Token: 0x04006939 RID: 26937
	public Action<MotorcycleArrowCollectionItemData, CollectionGridItem> OnClickCb;
}
