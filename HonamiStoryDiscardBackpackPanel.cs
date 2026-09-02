using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.HonamiStory;
using UnrealEngine;

// Token: 0x02001EF7 RID: 7927
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryDiscardBackpackPanel : HonamiStoryBackpackPanelBase
{
	// Token: 0x0600EBFD RID: 60413 RVA: 0x0040269C File Offset: 0x0040089C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x0600EBFE RID: 60414 RVA: 0x00402738 File Offset: 0x00400938
	protected override void OnStart()
	{
		this.DiscardItemList.Clear();
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		if (HonamiStoryUtil.CheckInHonamiStoryDungeon())
		{
			this.DiscardItemList.Add(new DiscardPair
			{
				NotActive = base.GetItem(4),
				Active = base.GetItem(5)
			});
			if (HonamiStoryUtil.IsMobileView())
			{
				this.DiscardItemList.Add(new DiscardPair
				{
					NotActive = base.GetItem(1),
					Active = base.GetItem(2)
				});
			}
			foreach (IDiscardPair discardPair in this.DiscardItemList)
			{
				discardPair.Active.SetUIActive(false);
				discardPair.NotActive.SetUIActive(true);
			}
		}
	}

	// Token: 0x0600EBFF RID: 60415 RVA: 0x00402830 File Offset: 0x00400A30
	public override bool OnDragBegin([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		if (!HonamiStoryUtil.CheckInHonamiStoryDungeon())
		{
			return true;
		}
		HonamiStoryBackpackData backPackData = ModelBase<HonamiStoryModel>.Instance.GetBackPackData(3, false);
		if (backPackData != null && backPackData.GetItemDataByInstanceId(item.GetIncId(), false) != null)
		{
			return true;
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 != null)
		{
			item2.SetUIActive(true);
		}
		UUIItem item3 = base.GetItem(0);
		if (item3 != null)
		{
			item3.SetUIActive(HonamiStoryUtil.IsMobileView());
		}
		return true;
	}

	// Token: 0x0600EC00 RID: 60416 RVA: 0x00402894 File Offset: 0x00400A94
	public override void OnDragEnd([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		if (!HonamiStoryUtil.CheckInHonamiStoryDungeon())
		{
			return;
		}
		HonamiStoryBackpackData backPackData = ModelBase<HonamiStoryModel>.Instance.GetBackPackData(3, false);
		if (backPackData != null && backPackData.GetItemDataByInstanceId(item.GetIncId(), false) != null)
		{
			return;
		}
		foreach (IDiscardPair discardPair in this.DiscardItemList)
		{
			discardPair.Active.SetUIActive(false);
			discardPair.NotActive.SetUIActive(true);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIItem item3 = base.GetItem(0);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(false);
	}

	// Token: 0x0600EC01 RID: 60417 RVA: 0x00402944 File Offset: 0x00400B44
	public override void OnHover(ULGUIPointerEventData eventData, HonamiStoryInteractOperateAgent operateAgent)
	{
		IDiscardPair hoverDiscardItem = this.GetHoverDiscardItem(eventData);
		if (operateAgent.StartOperateBackpack.GetBackpackType() == 0 || operateAgent.StartOperateBackpack.GetBackpackType() == 2)
		{
			return;
		}
		if (hoverDiscardItem == null)
		{
			return;
		}
		if (this.CurrentDiscardItem == hoverDiscardItem)
		{
			return;
		}
		this.CurrentDiscardItem = hoverDiscardItem;
		this.CurrentDiscardItem.Active.SetUIActive(true);
		this.CurrentDiscardItem.NotActive.SetUIActive(false);
	}

	// Token: 0x0600EC02 RID: 60418 RVA: 0x004029AC File Offset: 0x00400BAC
	public override void OnHoverEnd()
	{
		if (this.CurrentDiscardItem != null)
		{
			this.CurrentDiscardItem.Active.SetUIActive(false);
			this.CurrentDiscardItem.NotActive.SetUIActive(true);
			this.CurrentDiscardItem = null;
		}
	}

	// Token: 0x0600EC03 RID: 60419 RVA: 0x004029E0 File Offset: 0x00400BE0
	public override bool CheckDragItemInViewport(ULGUIPointerEventData eventData)
	{
		foreach (IDiscardPair discardPair in this.DiscardItemList)
		{
			if (HonamiStoryUtil.CheckEventDataInItemViewport(eventData, discardPair.Active, true))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600EC04 RID: 60420 RVA: 0x00402A44 File Offset: 0x00400C44
	public override int GetBackpackType()
	{
		return 4;
	}

	// Token: 0x0600EC05 RID: 60421 RVA: 0x00402A47 File Offset: 0x00400C47
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInSameBackpack(ULGUIPointerEventData eventData, HonamiStoryItemDataBase item)
	{
		return null;
	}

	// Token: 0x0600EC06 RID: 60422 RVA: 0x00402A4A File Offset: 0x00400C4A
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInSendBackpack(ULGUIPointerEventData eventData, HonamiStoryItemDataBase operateItem, HashSet<HonamiStoryItemDataBase> exchangeItemSet)
	{
		return null;
	}

	// Token: 0x0600EC07 RID: 60423 RVA: 0x00402A4D File Offset: 0x00400C4D
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInReceiveBackpack(ULGUIPointerEventData eventData, HonamiStoryItemDataBase operateItem, HashSet<HonamiStoryItemDataBase> exchangeItemSet)
	{
		return null;
	}

	// Token: 0x0600EC08 RID: 60424 RVA: 0x00402A50 File Offset: 0x00400C50
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override HashSet<HonamiStoryItemDataBase> GetExchangeItemSet(ULGUIPointerEventData eventData, HonamiStoryItemDataBase operateItem)
	{
		return new HashSet<HonamiStoryItemDataBase>();
	}

	// Token: 0x0600EC09 RID: 60425 RVA: 0x00402A57 File Offset: 0x00400C57
	public override void OnBackpackLogicStateChange(EHonamiStoryBackpackLogicState state)
	{
	}

	// Token: 0x0600EC0A RID: 60426 RVA: 0x00402A59 File Offset: 0x00400C59
	public override List<HonamiStoryGridItemBase> GetUpdateContextEffectGridItems(HonamiStoryBagUpdateContext updateContext)
	{
		return new List<HonamiStoryGridItemBase>();
	}

	// Token: 0x0600EC0B RID: 60427 RVA: 0x00402A60 File Offset: 0x00400C60
	[return: Nullable(2)]
	private IDiscardPair GetHoverDiscardItem(ULGUIPointerEventData eventData)
	{
		foreach (IDiscardPair discardPair in this.DiscardItemList)
		{
			if (HonamiStoryUtil.CheckEventDataInItemViewport(eventData, discardPair.Active, true))
			{
				return discardPair;
			}
		}
		return null;
	}

	// Token: 0x0400717E RID: 29054
	private readonly List<IDiscardPair> DiscardItemList = new List<IDiscardPair>();

	// Token: 0x0400717F RID: 29055
	[Nullable(2)]
	private IDiscardPair CurrentDiscardItem;

	// Token: 0x02008236 RID: 33334
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C28B RID: 180875
		LeftDiscardItem,
		// Token: 0x0402C28C RID: 180876
		LeftNotHovering,
		// Token: 0x0402C28D RID: 180877
		LeftIsHovering,
		// Token: 0x0402C28E RID: 180878
		RightDiscardItem,
		// Token: 0x0402C28F RID: 180879
		RightNotHovering,
		// Token: 0x0402C290 RID: 180880
		RightIsHovering
	}
}
