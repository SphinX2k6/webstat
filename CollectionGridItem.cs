using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001D2E RID: 7470
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CollectionGridItem : SyncGridProxyAbstract<MotorcycleArrowCollectionItemData>
{
	// Token: 0x0600DBFA RID: 56314 RVA: 0x003B22C6 File Offset: 0x003B04C6
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0600DBFB RID: 56315 RVA: 0x003B22E9 File Offset: 0x003B04E9
	protected override void OnStart()
	{
		base.OnStart();
		this.GridItem = new CollectionGridItemPanel();
		this.GridItem.CreateThenShowByActor(base.GetItem(0).GetOwner());
		this.GridItem.OnClickCallBack = this.OnClickCb;
	}

	// Token: 0x0600DBFC RID: 56316 RVA: 0x003B2324 File Offset: 0x003B0524
	public override void Refresh(MotorcycleArrowCollectionItemData data)
	{
		CollectionGridItemPanel gridItem = this.GridItem;
		if (gridItem == null)
		{
			return;
		}
		gridItem.Refresh(data);
	}

	// Token: 0x0600DBFD RID: 56317 RVA: 0x003B2337 File Offset: 0x003B0537
	public void SetToggleState(bool state)
	{
		CollectionGridItemPanel gridItem = this.GridItem;
		if (gridItem == null)
		{
			return;
		}
		gridItem.SetToggleState(state);
	}

	// Token: 0x04006937 RID: 26935
	[Nullable(2)]
	private CollectionGridItemPanel GridItem;

	// Token: 0x04006938 RID: 26936
	public Action<MotorcycleArrowCollectionItemData> OnClickCb;

	// Token: 0x020080BD RID: 32957
	[NullableContext(0)]
	private static class ECollectionGridItemComponents
	{
		// Token: 0x0402BC88 RID: 179336
		public const int ItemBaseGrid = 0;
	}
}
