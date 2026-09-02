using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001F5F RID: 8031
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class HonamiStoryItemCollectItemView : GridProxyAbstract<HonamiStoryItemCollectionData>
{
	// Token: 0x0600F069 RID: 61545 RVA: 0x0041B634 File Offset: 0x00419834
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x0600F06A RID: 61546 RVA: 0x0041B6E0 File Offset: 0x004198E0
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(() => this.CanToggleChange == null || this.CanToggleChange(base.GridIndex));
		this.ItemIconBox = new SmallItemGrid();
		this.ItemIconBox.Initialize(base.GetItem(1).GetOwner());
	}

	// Token: 0x0600F06B RID: 61547 RVA: 0x0041B72C File Offset: 0x0041992C
	[NullableContext(1)]
	public override void Refresh(HonamiStoryItemCollectionData itemData, bool isSelected, int gridIndex)
	{
		this.ItemData = itemData;
		base.GetExtendToggle(0).SetEnable(this.ItemData.State == EHonamiStoryCollectState.Unfinished);
		base.GetSprite(4).SetUIActive(this.ItemData.State == EHonamiStoryCollectState.Finished);
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = itemData,
			ItemConfigId = new int?(itemData.Id)
		};
		this.ItemIconBox.Apply<PropSmallItemGrid>(parameters);
		HonamiStoryItem? honamiStoryItem = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryItem(itemData.Id);
		this.ItemIconBox.SetIconByPath(honamiStoryItem.Value.IconSmall);
		this.ItemIconBox.SetQuality(new int?(itemData.Id));
		this.ItemIconBox.SetLockBlackVisible(itemData.State == EHonamiStoryCollectState.Unfinished);
		if (this.ItemData.State != EHonamiStoryCollectState.Unfinished)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.ItemData.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.ItemData.Desc, Array.Empty<object>());
			return;
		}
		base.GetText(2).SetText("???", true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.ItemData.GetConfig.Access, Array.Empty<object>());
	}

	// Token: 0x0600F06C RID: 61548 RVA: 0x0041B87E File Offset: 0x00419A7E
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x0600F06D RID: 61549 RVA: 0x0041B891 File Offset: 0x00419A91
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600F06E RID: 61550 RVA: 0x0041B8A4 File Offset: 0x00419AA4
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.ItemData != null)
		{
			Action<int, HonamiStoryItemCollectionData> onClickToggleBack = this.OnClickToggleBack;
			if (onClickToggleBack == null)
			{
				return;
			}
			onClickToggleBack(base.GridIndex, this.ItemData);
		}
	}

	// Token: 0x04007388 RID: 29576
	private HonamiStoryItemCollectionData ItemData;

	// Token: 0x04007389 RID: 29577
	private SmallItemGrid ItemIconBox;

	// Token: 0x0400738A RID: 29578
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, HonamiStoryItemCollectionData> OnClickToggleBack;

	// Token: 0x0400738B RID: 29579
	public Func<int, bool> CanToggleChange;

	// Token: 0x020082EC RID: 33516
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C63F RID: 181823
		TogIllustrated,
		// Token: 0x0402C640 RID: 181824
		ItemBaseBox,
		// Token: 0x0402C641 RID: 181825
		TxtTitle,
		// Token: 0x0402C642 RID: 181826
		TxtDesc,
		// Token: 0x0402C643 RID: 181827
		SprGift
	}
}
