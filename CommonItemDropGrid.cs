using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020018A2 RID: 6306
[NullableContext(2)]
[Nullable(0)]
public class CommonItemDropGrid : GridProxyAbstract<TItem>
{
	// Token: 0x0600B51C RID: 46364 RVA: 0x00303A17 File Offset: 0x00301C17
	[NullableContext(1)]
	public void Initialize(AActor rootActor)
	{
		this.CreateThenShowByActor(rootActor);
	}

	// Token: 0x0600B51D RID: 46365 RVA: 0x00303A20 File Offset: 0x00301C20
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUINiagara));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnItemButtonClicked));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B51E RID: 46366 RVA: 0x00303AE8 File Offset: 0x00301CE8
	public override void Refresh(TItem data, bool isSelected, int gridIndex)
	{
		if (data.Equals(default(TItem)))
		{
			return;
		}
		InventoryDefine.IGetItemData itemData = data.ItemData;
		if (itemData == null)
		{
			return;
		}
		this.RefreshByItemInfo(itemData.ItemId, data.Count, new int?(itemData.IncId));
	}

	// Token: 0x0600B51F RID: 46367 RVA: 0x00303B30 File Offset: 0x00301D30
	public void RefreshByItemInfo(int configId, int count, int? uniqueId = null)
	{
		this.UniqueId = uniqueId.GetValueOrDefault();
		this.ConfigId = configId;
		this.Count = count;
		this.ItemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ConfigId);
		if (this.ItemConfig == null)
		{
			return;
		}
		PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
		propSmallItemGrid.Data = new object[]
		{
			configId,
			uniqueId
		};
		propSmallItemGrid.ItemConfigId = new int?(this.ConfigId);
		SmallItemGridBase smallItemGridBase = propSmallItemGrid;
		string bottomText;
		if (count <= 0)
		{
			bottomText = "";
		}
		else
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(count);
			bottomText = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		smallItemGridBase.BottomText = bottomText;
		PropSmallItemGrid parameters = propSmallItemGrid;
		this.ItemGrid.Apply<PropSmallItemGrid>(parameters);
		this.SetQualityEffect(this.ItemConfig.QualityId, null);
	}

	// Token: 0x0600B520 RID: 46368 RVA: 0x00303BF8 File Offset: 0x00301DF8
	public UniTask AsyncRefreshByItemInfo(int configId, int count, int? uniqueId = null)
	{
		CommonItemDropGrid.<AsyncRefreshByItemInfo>d__11 <AsyncRefreshByItemInfo>d__;
		<AsyncRefreshByItemInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AsyncRefreshByItemInfo>d__.<>4__this = this;
		<AsyncRefreshByItemInfo>d__.configId = configId;
		<AsyncRefreshByItemInfo>d__.count = count;
		<AsyncRefreshByItemInfo>d__.uniqueId = uniqueId;
		<AsyncRefreshByItemInfo>d__.<>1__state = -1;
		<AsyncRefreshByItemInfo>d__.<>t__builder.Start<CommonItemDropGrid.<AsyncRefreshByItemInfo>d__11>(ref <AsyncRefreshByItemInfo>d__);
		return <AsyncRefreshByItemInfo>d__.<>t__builder.Task;
	}

	// Token: 0x0600B521 RID: 46369 RVA: 0x00303C54 File Offset: 0x00301E54
	private void SetQualityEffect(int qualityId, Action loadedCallback = null)
	{
		QualityInfo? itemQualityConfig = ConfigBase<InventoryConfig>.Instance.GetItemQualityConfig(qualityId);
		if (itemQualityConfig == null)
		{
			return;
		}
		string dropItemQualityNiagaraPath = itemQualityConfig.Value.DropItemQualityNiagaraPath;
		if (StringUtils.IsEmpty(dropItemQualityNiagaraPath))
		{
			return;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraSystem>(dropItemQualityNiagaraPath, delegate([Nullable(2)] UNiagaraSystem niagaraSystem, string _)
		{
			this.GetUiNiagara(2).SetNiagaraSystem(niagaraSystem);
			if (loadedCallback != null)
			{
				loadedCallback();
			}
		}, 100, "js_undefined");
	}

	// Token: 0x0600B522 RID: 46370 RVA: 0x00303CC3 File Offset: 0x00301EC3
	public override void Clear()
	{
		this.ItemConfig = null;
		this.OnClickedCallback = null;
	}

	// Token: 0x0600B523 RID: 46371 RVA: 0x00303CD3 File Offset: 0x00301ED3
	protected override void OnStart()
	{
		this.ItemGrid = new SmallItemGrid();
		this.ItemGrid.Initialize(base.GetItem(1).GetOwner());
	}

	// Token: 0x0600B524 RID: 46372 RVA: 0x00303CF7 File Offset: 0x00301EF7
	public int GetUniqueId()
	{
		return this.UniqueId;
	}

	// Token: 0x0600B525 RID: 46373 RVA: 0x00303CFF File Offset: 0x00301EFF
	public int GetConfigId()
	{
		return this.ConfigId;
	}

	// Token: 0x0600B526 RID: 46374 RVA: 0x00303D07 File Offset: 0x00301F07
	public ItemConfig GetItemConfig()
	{
		return this.ItemConfig;
	}

	// Token: 0x0600B527 RID: 46375 RVA: 0x00303D0F File Offset: 0x00301F0F
	[NullableContext(1)]
	public void BindOnClicked(Action<CommonItemDropGrid> onClickedCallback)
	{
		this.OnClickedCallback = onClickedCallback;
	}

	// Token: 0x0600B528 RID: 46376 RVA: 0x00303D18 File Offset: 0x00301F18
	private void OnItemButtonClicked()
	{
		if (this.OnClickedCallback != null)
		{
			this.OnClickedCallback(this);
		}
	}

	// Token: 0x04005588 RID: 21896
	private int UniqueId;

	// Token: 0x04005589 RID: 21897
	private int ConfigId;

	// Token: 0x0400558A RID: 21898
	public int Count;

	// Token: 0x0400558B RID: 21899
	private ItemConfig ItemConfig;

	// Token: 0x0400558C RID: 21900
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<CommonItemDropGrid> OnClickedCallback;

	// Token: 0x0400558D RID: 21901
	private SmallItemGrid ItemGrid;

	// Token: 0x02007C26 RID: 31782
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402A679 RID: 173689
		ItemButton,
		// Token: 0x0402A67A RID: 173690
		ItemGridItem,
		// Token: 0x0402A67B RID: 173691
		QualityEffect
	}
}
