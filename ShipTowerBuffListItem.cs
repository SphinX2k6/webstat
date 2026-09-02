using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029A6 RID: 10662
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerBuffListItem : GridProxyAbstract<ShipTowerBuffQuality>
{
	// Token: 0x0601541E RID: 87070 RVA: 0x005E427C File Offset: 0x005E247C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x0601541F RID: 87071 RVA: 0x005E42D8 File Offset: 0x005E24D8
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerBuffListItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerBuffListItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015420 RID: 87072 RVA: 0x005E431C File Offset: 0x005E251C
	public override UniTask RefreshAsync(ShipTowerBuffQuality data, bool isSelected, int gridIndex)
	{
		ShipTowerBuffListItem.<RefreshAsync>d__8 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<ShipTowerBuffListItem.<RefreshAsync>d__8>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015421 RID: 87073 RVA: 0x005E4368 File Offset: 0x005E2568
	public override void Refresh(ShipTowerBuffQuality data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		GenericLayout<ShipTowerBuffItem, ShipTowerBuffData> itemLayout = this.ItemLayout;
		if (itemLayout != null)
		{
			ShipTowerBuffQuality itemData = this.ItemData;
			itemLayout.RefreshByData(((itemData != null) ? itemData.BuffList : null) ?? new List<ShipTowerBuffData>(), null, true);
		}
		base.GetText(0).ShowTextNew(this.ItemData.Title);
	}

	// Token: 0x06015422 RID: 87074 RVA: 0x005E43C1 File Offset: 0x005E25C1
	private ShipTowerBuffItem CreateBuffItem()
	{
		return new ShipTowerBuffItem
		{
			OnItemClickCallback = this.OnItemClickCallback,
			GetStageIdCallback = this.GetStageIdCallback,
			AllComponentLoadedCallback = this.BuffComponentLoadedCallback
		};
	}

	// Token: 0x06015423 RID: 87075 RVA: 0x005E43EC File Offset: 0x005E25EC
	public void UpdateBuffInfo()
	{
		GenericLayout<ShipTowerBuffItem, ShipTowerBuffData> itemLayout = this.ItemLayout;
		List<ShipTowerBuffItem> list = (itemLayout != null) ? itemLayout.GetLayoutItemList() : null;
		if (list == null)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			list[i].UpdateBuffInfo();
		}
	}

	// Token: 0x06015424 RID: 87076 RVA: 0x005E4430 File Offset: 0x005E2630
	public void UpdateBuffSelected()
	{
		GenericLayout<ShipTowerBuffItem, ShipTowerBuffData> itemLayout = this.ItemLayout;
		List<ShipTowerBuffItem> list = (itemLayout != null) ? itemLayout.GetLayoutItemList() : null;
		if (list == null)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			list[i].UpdateBuffSelected();
		}
	}

	// Token: 0x06015425 RID: 87077 RVA: 0x005E4474 File Offset: 0x005E2674
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (this.ItemData == null || this.ItemData.BuffList.Count == 0)
		{
			return null;
		}
		if (configParams.Length != 3)
		{
			return null;
		}
		int num;
		if (!int.TryParse(configParams[2], out num) || num < 0 || num >= this.ItemData.BuffList.Count)
		{
			return null;
		}
		GenericLayout<ShipTowerBuffItem, ShipTowerBuffData> itemLayout = this.ItemLayout;
		UUIItem uuiitem = (itemLayout != null) ? itemLayout.GetItemByIndex(num) : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x0400A3ED RID: 41965
	[Nullable(2)]
	private ShipTowerBuffQuality ItemData;

	// Token: 0x0400A3EE RID: 41966
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ShipTowerBuffItem, ShipTowerBuffData> ItemLayout;

	// Token: 0x0400A3EF RID: 41967
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ShipTowerBuffData> OnItemClickCallback;

	// Token: 0x0400A3F0 RID: 41968
	[Nullable(2)]
	public Func<int?> GetStageIdCallback;

	// Token: 0x0400A3F1 RID: 41969
	[Nullable(2)]
	public Action BuffComponentLoadedCallback;

	// Token: 0x02008CEE RID: 36078
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F68D RID: 194189
		public const int TxtTitle = 0;

		// Token: 0x0402F68E RID: 194190
		public const int GridLayoutItemList = 1;

		// Token: 0x0402F68F RID: 194191
		public const int ItemItem = 2;
	}
}
