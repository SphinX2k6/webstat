using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using UnrealEngine;

// Token: 0x02002487 RID: 9351
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class PhantomConfigRemoveItemGrid : LoopScrollMediumItemGrid<PhantomItemData>
{
	// Token: 0x06012256 RID: 74326 RVA: 0x004FD4B4 File Offset: 0x004FB6B4
	protected override void OnStart()
	{
		this.GetItemGridExtendToggle().OnStateChange.Add(new Action<EToggleState>(this.OnToggleClicked));
	}

	// Token: 0x06012257 RID: 74327 RVA: 0x004FD4D2 File Offset: 0x004FB6D2
	protected override void OnBeforeDestroy()
	{
		this.GetItemGridExtendToggle().OnStateChange.Remove(new Action<EToggleState>(this.OnToggleClicked));
	}

	// Token: 0x06012258 RID: 74328 RVA: 0x004FD4F0 File Offset: 0x004FB6F0
	protected override void OnRefresh(PhantomItemData data, bool isSelected, int gridIndex)
	{
		this.CurData = data;
		this.RefreshPrivate(data);
	}

	// Token: 0x06012259 RID: 74329 RVA: 0x004FD500 File Offset: 0x004FB700
	private void RefreshPrivate(PhantomItemData data)
	{
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(data.GetUniqueId());
		if (phantomBattleData == null)
		{
			return;
		}
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.GetConfigId()),
			IsLockVisible = new bool?(data.GetIsLock()),
			IsDeprecate = new bool?(data.GetIsDeprecated()),
			StarLevel = new int?(data.GetQuality()),
			QualityId = new int?(phantomBattleData.GetQuality()),
			Level = new int?(phantomBattleData.GetCost()),
			IsLevelTextUseChangeColor = new bool?(true),
			BottomTextId = "VisionLevel",
			BottomTextParameter = new object[]
			{
				phantomBattleData.GetPhantomLevel()
			},
			VisionFetterGroupId = new int?(phantomBattleData.GetFetterGroupId()),
			IsOmitBottomText = new bool?(true)
		};
		this.SetSelected(false, false);
		base.Apply<PropMediumItemGrid>(parameters);
	}

	// Token: 0x0601225A RID: 74330 RVA: 0x004FD5F4 File Offset: 0x004FB7F4
	private void OnToggleClicked(EToggleState state)
	{
		this.SetSelected(false, false);
		if (this.CurData != null)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(this.CurData.GetUniqueId(), this.CurData.GetConfigId(), true, null);
		}
	}

	// Token: 0x04008D99 RID: 36249
	[Nullable(2)]
	protected PhantomItemData CurData;
}
