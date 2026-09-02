using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018A5 RID: 6309
[NullableContext(1)]
[Nullable(0)]
public class CommonItemSelectView<[Nullable(0)] T> : UiPanelBase where T : ItemDataBase
{
	// Token: 0x0600B542 RID: 46402 RVA: 0x003041FB File Offset: 0x003023FB
	[NullableContext(2)]
	public CommonItemSelectView(UUIItem commonItemActor = null)
	{
		if (commonItemActor != null)
		{
			base.CreateThenShowByActor(commonItemActor.GetOwner(), null);
		}
	}

	// Token: 0x0600B543 RID: 46403 RVA: 0x00304214 File Offset: 0x00302414
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x0600B544 RID: 46404 RVA: 0x00304284 File Offset: 0x00302484
	private void RefreshEmptyItem(List<T> itemDataBaseList)
	{
		base.GetItem(3).SetUIActive(itemDataBaseList == null || itemDataBaseList.Count <= 0);
	}

	// Token: 0x0600B545 RID: 46405 RVA: 0x003042A4 File Offset: 0x003024A4
	public void UpdateSelectableComponent(ESelectableComponentType selectableComponentType, List<T> itemDataBaseList, List<ISelectedData> selectedDataList, SelectableComponentData data, [Nullable(2)] CommonIntensifyPropExpData expData = null)
	{
		if (this.SelectableComponent == null)
		{
			if (selectableComponentType == ESelectableComponentType.Normal)
			{
				this.SelectableComponent = new SelectableComponent<T>();
			}
			else
			{
				this.SelectableComponent = new VisionRecoverySelectableComponent<T>();
			}
			this.SelectableComponent.InitLoopScroller(base.GetLoopScrollViewComponent(0), base.GetItem(1), data);
		}
		this.SetMaxSize(data.MaxSelectedGridNum);
		this.SetOnlyGold(data.OnlyGold);
		this.RefreshEmptyItem(itemDataBaseList);
		this.SelectableComponent.UpdateComponent(itemDataBaseList, selectedDataList, expData);
	}

	// Token: 0x0600B546 RID: 46406 RVA: 0x0030431F File Offset: 0x0030251F
	public List<ISelectedData> GetCurrentSelectedData()
	{
		return this.SelectableComponent.GetCurrentSelectedData();
	}

	// Token: 0x0600B547 RID: 46407 RVA: 0x0030432C File Offset: 0x0030252C
	public void UpdateByDataList(List<T> itemDataBaseList)
	{
		this.SelectableComponent.UpdateDataList(itemDataBaseList);
		this.RefreshEmptyItem(itemDataBaseList);
	}

	// Token: 0x0600B548 RID: 46408 RVA: 0x00304341 File Offset: 0x00302541
	public void RefreshPartByIndex(int index)
	{
		this.SelectableComponent.RefreshPartByIndex(index);
	}

	// Token: 0x0600B549 RID: 46409 RVA: 0x0030434F File Offset: 0x0030254F
	public void UpdateChangeItemSelectList()
	{
		this.SelectableComponent.UpdateChangeItemSelectList();
	}

	// Token: 0x0600B54A RID: 46410 RVA: 0x0030435C File Offset: 0x0030255C
	public void SetMaxSize(int maxSize)
	{
		this.SelectableComponent.SetMaxSize(maxSize);
	}

	// Token: 0x0600B54B RID: 46411 RVA: 0x0030436A File Offset: 0x0030256A
	public void SetOnlyGold(bool onlyGold)
	{
		this.SelectableComponent.SetOnlyGold(onlyGold);
	}

	// Token: 0x0600B54C RID: 46412 RVA: 0x00304378 File Offset: 0x00302578
	protected override void OnBeforeDestroy()
	{
		SelectableComponent<T> selectableComponent = this.SelectableComponent;
		if (selectableComponent == null)
		{
			return;
		}
		selectableComponent.Destroy(null);
	}

	// Token: 0x04005598 RID: 21912
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private SelectableComponent<T> SelectableComponent;

	// Token: 0x02007C2F RID: 31791
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A6A6 RID: 173734
		LoopScrooller,
		// Token: 0x0402A6A7 RID: 173735
		LoopItem,
		// Token: 0x0402A6A8 RID: 173736
		FilterItem,
		// Token: 0x0402A6A9 RID: 173737
		EmptyItem
	}
}
