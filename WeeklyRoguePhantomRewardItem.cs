using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002D30 RID: 11568
public class WeeklyRoguePhantomRewardItem : GridProxyAbstract<WeeklyRoguePhantomRewardInfo>
{
	// Token: 0x06017590 RID: 95632 RVA: 0x00679220 File Offset: 0x00677420
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickReduce))
		};
	}

	// Token: 0x06017591 RID: 95633 RVA: 0x006792F8 File Offset: 0x006774F8
	protected override void OnStart()
	{
		this.InventoryGiftItem = new InventoryGiftCellItem();
		this.InventoryGiftItem.Initialize(base.GetItem(0).GetOwner());
		base.GetExtendToggle(3).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
		this.ElementLayout = new GenericLayout<WeeklyRogueRewardFetterItem, int>(base.GetHorizontalLayout(4), new Func<WeeklyRogueRewardFetterItem>(this.CreateFetter), null, false, true);
	}

	// Token: 0x06017592 RID: 95634 RVA: 0x00679368 File Offset: 0x00677568
	public override void Refresh(WeeklyRoguePhantomRewardInfo data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		RogueWeeklyBF? blackFlowerConfig = ConfigBase<WeeklyRogueConfig>.Instance.GetBlackFlowerConfig(data.AreaAwardId);
		if (blackFlowerConfig == null)
		{
			return;
		}
		this.SilentAreaId = blackFlowerConfig.Value.Id;
		GiftItemData giftItemData = new GiftItemData(blackFlowerConfig.Value.ShowItemId, 0, 0);
		this.InventoryGiftItem.RefreshByConfigId(giftItemData);
		List<int> source = new List<int>
		{
			blackFlowerConfig.Value.IconId1,
			blackFlowerConfig.Value.IconId2
		};
		GenericLayout<WeeklyRogueRewardFetterItem, int> elementLayout = this.ElementLayout;
		if (elementLayout != null)
		{
			elementLayout.RefreshByData(source.ToList<int>(), null, false);
		}
		SilentAreaDetection? silentAreaDetectionConfById = ConfigBase<AdventureGuideConfig>.Instance.GetSilentAreaDetectionConfById(blackFlowerConfig.Value.SilentAreaDetectionId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), silentAreaDetectionConfById.Value.Name, Array.Empty<object>());
		UUIItem item = base.GetItem(6);
		if (item != null)
		{
			item.SetUIActive(!data.IsActive);
		}
		if (data.IsActive)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			if (extendToggle != null)
			{
				extendToggle.RootUIComp.Get().SetRaycastTarget(true);
			}
			if (this.IsSelectOnCb != null)
			{
				this.SetSelected(this.IsSelectOnCb(data.AreaAwardId), false);
			}
			return;
		}
		UUIButtonComponent button = base.GetButton(2);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(3);
		if (extendToggle2 == null)
		{
			return;
		}
		extendToggle2.RootUIComp.Get().SetRaycastTarget(false);
	}

	// Token: 0x06017593 RID: 95635 RVA: 0x00679503 File Offset: 0x00677703
	[NullableContext(1)]
	private WeeklyRogueRewardFetterItem CreateFetter()
	{
		return new WeeklyRogueRewardFetterItem();
	}

	// Token: 0x06017594 RID: 95636 RVA: 0x0067950A File Offset: 0x0067770A
	public override void OnSelected(bool fireEvent)
	{
		if (this.IsSelectOnCb != null)
		{
			this.SetSelected(this.IsSelectOnCb(this.SilentAreaId), false);
		}
	}

	// Token: 0x06017595 RID: 95637 RVA: 0x0067952C File Offset: 0x0067772C
	private void SetSelected(bool bSelectOn, bool bFireEvent = false)
	{
		base.GetExtendToggle(3).SetToggleState(bSelectOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent, false, false);
		base.GetButton(2).RootUIComp.Get().SetUIActive(bSelectOn);
	}

	// Token: 0x06017596 RID: 95638 RVA: 0x0067956A File Offset: 0x0067776A
	private void OnClickReduce()
	{
		this.SetSelected(false, true);
	}

	// Token: 0x06017597 RID: 95639 RVA: 0x00679574 File Offset: 0x00677774
	private void OnToggleStateChange(EToggleState state)
	{
		bool flag = state == EToggleState.ETT_Checked;
		base.GetButton(2).RootUIComp.Get().SetUIActive(flag);
		if (this.OnToggleStateChangeFunction != null)
		{
			this.OnToggleStateChangeFunction(base.GetExtendToggle(3), base.GetButton(2), this.SilentAreaId, flag);
		}
	}

	// Token: 0x0400B34E RID: 45902
	protected WeeklyRoguePhantomRewardInfo Data;

	// Token: 0x0400B34F RID: 45903
	protected int SilentAreaId;

	// Token: 0x0400B350 RID: 45904
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayout<WeeklyRogueRewardFetterItem, int> ElementLayout;

	// Token: 0x0400B351 RID: 45905
	[Nullable(1)]
	protected InventoryGiftCellItem InventoryGiftItem;

	// Token: 0x0400B352 RID: 45906
	[Nullable(2)]
	public Func<int, bool> IsSelectOnCb;

	// Token: 0x0400B353 RID: 45907
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<UUIExtendToggle, UUIButtonComponent, int, bool> OnToggleStateChangeFunction;

	// Token: 0x02008FF4 RID: 36852
	private enum EDefine
	{
		// Token: 0x040304D5 RID: 197845
		Item,
		// Token: 0x040304D6 RID: 197846
		TxtName,
		// Token: 0x040304D7 RID: 197847
		BtnReduce,
		// Token: 0x040304D8 RID: 197848
		Toggle,
		// Token: 0x040304D9 RID: 197849
		ElementLayout,
		// Token: 0x040304DA RID: 197850
		ElementItem,
		// Token: 0x040304DB RID: 197851
		PanelLock
	}
}
