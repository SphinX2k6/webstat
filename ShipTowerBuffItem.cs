using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020029A5 RID: 10661
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerBuffItem : LoopScrollMediumItemGrid<ShipTowerBuffData>
{
	// Token: 0x06015413 RID: 87059 RVA: 0x005E4032 File Offset: 0x005E2232
	[NullableContext(1)]
	protected override void OnRefresh(ShipTowerBuffData data, bool isSelected, int gridIndex)
	{
		this.BuffData = data;
		this.UpdateBuffInfo();
		this.UpdateBuffSelected();
		if (data.IsSelected)
		{
			this.OnExtendToggleStateChanged(EToggleState.ETT_Checked);
		}
	}

	// Token: 0x06015414 RID: 87060 RVA: 0x005E4058 File Offset: 0x005E2258
	public void UpdateBuffInfo()
	{
		ShipTowerBuffData buffData = this.BuffData;
		Func<int?> getStageIdCallback = this.GetStageIdCallback;
		int? stageId = (getStageIdCallback != null) ? getStageIdCallback() : null;
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			ItemConfigId = new int?(buffData.ItemId),
			IsLockVisible = new bool?(!buffData.IsUnlock),
			IsDisable = new bool?(!buffData.IsCanUse(stageId)),
			Level = (buffData.IsUnlimited(stageId) ? null : new int?(buffData.CanUseCount)),
			IsLevelInfinite = (buffData.IsUnlimited(stageId) ? new bool?(true) : null),
			BottomTextId = buffData.ItemNameKey,
			IsNewVisible = new bool?(buffData.IsFirstGet()),
			Data = buffData
		};
		base.Apply<PropMediumItemGrid>(parameters);
	}

	// Token: 0x06015415 RID: 87061 RVA: 0x005E4138 File Offset: 0x005E2338
	public void OnForceSelected()
	{
		this.SetSelected(true, true);
	}

	// Token: 0x06015416 RID: 87062 RVA: 0x005E4142 File Offset: 0x005E2342
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x06015417 RID: 87063 RVA: 0x005E414C File Offset: 0x005E234C
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
	}

	// Token: 0x06015418 RID: 87064 RVA: 0x005E4156 File Offset: 0x005E2356
	protected override void OnBeforeDestroy()
	{
		ShipTowerBuffData buffData = this.BuffData;
		if (buffData == null)
		{
			return;
		}
		buffData.ClearSelected();
	}

	// Token: 0x06015419 RID: 87065 RVA: 0x005E4168 File Offset: 0x005E2368
	protected override void OnExtendToggleStateChanged(EToggleState state)
	{
		ShipTowerBuffData buffData = this.BuffData;
		if (buffData != null)
		{
			buffData.SetSelected(true);
		}
		IScrollViewDelegate<IGridProxy<ShipTowerBuffData>, ShipTowerBuffData> scrollViewDelegate = base.ScrollViewDelegate;
		if (scrollViewDelegate != null)
		{
			scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
		}
		Action<ShipTowerBuffData> onItemClickCallback = this.OnItemClickCallback;
		if (onItemClickCallback == null)
		{
			return;
		}
		onItemClickCallback(this.BuffData);
	}

	// Token: 0x0601541A RID: 87066 RVA: 0x005E41BB File Offset: 0x005E23BB
	protected override bool OnCanExecuteChange()
	{
		ShipTowerBuffData buffData = this.BuffData;
		return buffData == null || !buffData.IsSelected;
	}

	// Token: 0x0601541B RID: 87067 RVA: 0x005E41D4 File Offset: 0x005E23D4
	public void UpdateBuffState()
	{
		this.UpdateBuffInfo();
	}

	// Token: 0x0601541C RID: 87068 RVA: 0x005E41DC File Offset: 0x005E23DC
	public void UpdateBuffSelected()
	{
		ShipTowerBuffData buffData = this.BuffData;
		bool? flag = (buffData != null) ? new bool?(buffData.IsSelected) : null;
		bool? isLastSelected = this.IsLastSelected;
		if (flag.GetValueOrDefault() == isLastSelected.GetValueOrDefault() & flag != null == (isLastSelected != null))
		{
			return;
		}
		ShipTowerBuffData buffData2 = this.BuffData;
		this.SetSelected(buffData2 != null && buffData2.IsSelected, true);
		ShipTowerBuffData buffData3 = this.BuffData;
		this.IsLastSelected = ((buffData3 != null) ? new bool?(buffData3.IsSelected) : null);
	}

	// Token: 0x0400A3E9 RID: 41961
	protected ShipTowerBuffData BuffData;

	// Token: 0x0400A3EA RID: 41962
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ShipTowerBuffData> OnItemClickCallback;

	// Token: 0x0400A3EB RID: 41963
	public Func<int?> GetStageIdCallback;

	// Token: 0x0400A3EC RID: 41964
	private bool? IsLastSelected;
}
