using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D4A RID: 11594
[NullableContext(1)]
[Nullable(0)]
public class WeeklyRoguePhantomRewardView : UiViewBase
{
	// Token: 0x0601763D RID: 95805 RVA: 0x0067C486 File Offset: 0x0067A686
	public WeeklyRoguePhantomRewardView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0601763E RID: 95806 RVA: 0x0067C498 File Offset: 0x0067A698
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.OnHelpButtonClick))
		};
	}

	// Token: 0x0601763F RID: 95807 RVA: 0x0067C56D File Offset: 0x0067A76D
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPowerChanged, new Action(this.OnPowerChange));
	}

	// Token: 0x06017640 RID: 95808 RVA: 0x0067C58B File Offset: 0x0067A78B
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPowerChanged, new Action(this.OnPowerChange));
	}

	// Token: 0x06017641 RID: 95809 RVA: 0x0067C5AC File Offset: 0x0067A7AC
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyRoguePhantomRewardView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyRoguePhantomRewardView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06017642 RID: 95810 RVA: 0x0067C5F0 File Offset: 0x0067A7F0
	protected override void OnStart()
	{
		this.PhantomLoopScrollView = new LoopScrollView<WeeklyRoguePhantomRewardItem, WeeklyRoguePhantomRewardInfo>(base.GetLoopScrollViewComponent(1), (AUIBaseActor)base.GetItem(2).GetOwner(), new Func<WeeklyRoguePhantomRewardItem>(this.InitRewardItem), false);
		this.RefreshLayout();
		this.RefreshState();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "WeeklyRouge_BonusWindow_Title", Array.Empty<object>());
	}

	// Token: 0x06017643 RID: 95811 RVA: 0x0067C654 File Offset: 0x0067A854
	protected override void OnBeforeShow()
	{
		PowerCurrencyItem overPowerCurrencyItem = this.OverPowerCurrencyItem;
		if (overPowerCurrencyItem != null)
		{
			UUIItem originalItem = overPowerCurrencyItem.GetOriginalItem();
			if (originalItem != null)
			{
				IUiPopFrameInterface childPopView = this.ChildPopView;
				UUIItem inParent;
				if (childPopView == null)
				{
					inParent = null;
				}
				else
				{
					CommonPopViewBase popItem = childPopView.PopItem;
					inParent = ((popItem != null) ? popItem.GetCostParent() : null);
				}
				originalItem.SetUIParent(inParent, false);
			}
		}
		PowerCurrencyItem powerCurrencyItem = this.PowerCurrencyItem;
		if (powerCurrencyItem != null)
		{
			UUIItem originalItem2 = powerCurrencyItem.GetOriginalItem();
			if (originalItem2 != null)
			{
				IUiPopFrameInterface childPopView2 = this.ChildPopView;
				UUIItem inParent2;
				if (childPopView2 == null)
				{
					inParent2 = null;
				}
				else
				{
					CommonPopViewBase popItem2 = childPopView2.PopItem;
					inParent2 = ((popItem2 != null) ? popItem2.GetCostParent() : null);
				}
				originalItem2.SetUIParent(inParent2, false);
			}
		}
		this.PowerCurrencyItem.ShowWithoutText(5);
		PowerCurrencyItem powerCurrencyItem2 = this.PowerCurrencyItem;
		if (powerCurrencyItem2 != null)
		{
			powerCurrencyItem2.SetButtonFunction(delegate(int _)
			{
				ControllerBase<PowerController>.Instance.OpenPowerView(EPowerMenuType.Supply, 0);
			});
		}
		this.RefreshState();
	}

	// Token: 0x06017644 RID: 95812 RVA: 0x0067C719 File Offset: 0x0067A919
	protected override void OnBeforeDestroy()
	{
		Action closeCallBack = this.InfoData.CloseCallBack;
		if (closeCallBack == null)
		{
			return;
		}
		closeCallBack();
	}

	// Token: 0x06017645 RID: 95813 RVA: 0x0067C730 File Offset: 0x0067A930
	private bool RewardByCount(int count)
	{
		if (this.CurSelectedAreaId == -1)
		{
			return false;
		}
		int value = count * this.InfoData.SinglePowerCost;
		if (!ModelBase<PowerModel>.Instance.IsPowerEnough(new int?(value)))
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("ReceiveLevelPlayPowerNotEnough");
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(textById);
			ControllerBase<PowerController>.Instance.OpenPowerView(EPowerMenuType.Supply, ModelBase<PowerModel>.Instance.GetCurrentNeedPower(new int?(value)));
			return false;
		}
		this.InfoData.RewardCallBack(count, this.CurSelectedAreaId);
		base.CloseMe(null);
		return true;
	}

	// Token: 0x06017646 RID: 95814 RVA: 0x0067C7C0 File Offset: 0x0067A9C0
	private UniTask InitCurrency()
	{
		WeeklyRoguePhantomRewardView.<InitCurrency>d__18 <InitCurrency>d__;
		<InitCurrency>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCurrency>d__.<>4__this = this;
		<InitCurrency>d__.<>1__state = -1;
		<InitCurrency>d__.<>t__builder.Start<WeeklyRoguePhantomRewardView.<InitCurrency>d__18>(ref <InitCurrency>d__);
		return <InitCurrency>d__.<>t__builder.Task;
	}

	// Token: 0x06017647 RID: 95815 RVA: 0x0067C804 File Offset: 0x0067AA04
	protected void RefreshLayout()
	{
		List<int> availableSilentArea = this.InfoData.AvailableSilentArea;
		IEnumerable<RogueWeeklyBF> blackFlowerConfigAll = ConfigBase<WeeklyRogueConfig>.Instance.GetBlackFlowerConfigAll();
		List<WeeklyRoguePhantomRewardInfo> list = new List<WeeklyRoguePhantomRewardInfo>();
		foreach (RogueWeeklyBF rogueWeeklyBF in blackFlowerConfigAll)
		{
			WeeklyRoguePhantomRewardInfo item = new WeeklyRoguePhantomRewardInfo
			{
				IsActive = availableSilentArea.Contains(rogueWeeklyBF.Id),
				AreaAwardId = rogueWeeklyBF.Id,
				SortId = rogueWeeklyBF.SortId
			};
			list.Add(item);
		}
		list.Sort(delegate(WeeklyRoguePhantomRewardInfo a, WeeklyRoguePhantomRewardInfo b)
		{
			if (a.IsActive == b.IsActive)
			{
				return b.SortId - a.SortId;
			}
			if (!a.IsActive)
			{
				return 1;
			}
			return -1;
		});
		this.PhantomLoopScrollView.RefreshByData(list, false, null, false);
	}

	// Token: 0x06017648 RID: 95816 RVA: 0x0067C8D8 File Offset: 0x0067AAD8
	protected void RefreshState()
	{
		this.RefreshStateTxt();
		bool isEnable = this.CurSelectedAreaId != -1;
		PowerRewardButtonItem singleButtonItem = this.SingleButtonItem;
		if (singleButtonItem != null)
		{
			singleButtonItem.SetIsEnable(isEnable);
		}
		PowerRewardButtonItem doubleButtonItem = this.DoubleButtonItem;
		if (doubleButtonItem != null)
		{
			doubleButtonItem.SetIsEnable(isEnable);
		}
		this.PhantomLoopScrollView.RefreshAllGridProxies();
	}

	// Token: 0x06017649 RID: 95817 RVA: 0x0067C928 File Offset: 0x0067AB28
	protected void RefreshStateTxt()
	{
		string textStringId = "Text_SelectRewardFromPool_Text";
		object[] args = new object[]
		{
			1,
			(this.CurSelectedAreaId != -1) ? 1 : 0,
			1
		};
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textStringId, args);
	}

	// Token: 0x0601764A RID: 95818 RVA: 0x0067C97B File Offset: 0x0067AB7B
	private WeeklyRoguePhantomRewardItem InitRewardItem()
	{
		return new WeeklyRoguePhantomRewardItem
		{
			IsSelectOnCb = new Func<int, bool>(this.GetToggleStateSelected),
			OnToggleStateChangeFunction = new Action<UUIExtendToggle, UUIButtonComponent, int, bool>(this.OnToggleStateChange)
		};
	}

	// Token: 0x0601764B RID: 95819 RVA: 0x0067C9A6 File Offset: 0x0067ABA6
	private void OnPowerChange()
	{
		PowerRewardButtonItem singleButtonItem = this.SingleButtonItem;
		if (singleButtonItem != null)
		{
			singleButtonItem.RefreshPowerState();
		}
		PowerRewardButtonItem doubleButtonItem = this.DoubleButtonItem;
		if (doubleButtonItem == null)
		{
			return;
		}
		doubleButtonItem.RefreshPowerState();
	}

	// Token: 0x0601764C RID: 95820 RVA: 0x0067C9C9 File Offset: 0x0067ABC9
	private void OnHelpButtonClick()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(463);
	}

	// Token: 0x0601764D RID: 95821 RVA: 0x0067C9DA File Offset: 0x0067ABDA
	private bool GetToggleStateSelected(int awardId)
	{
		return this.CurSelectedAreaId == awardId;
	}

	// Token: 0x0601764E RID: 95822 RVA: 0x0067C9E5 File Offset: 0x0067ABE5
	private void OnToggleStateChange(UUIExtendToggle toggle, UUIButtonComponent reduceButton, int id, bool isSelected)
	{
		this.CurSelectedAreaId = (isSelected ? id : -1);
		this.RefreshState();
	}

	// Token: 0x0400B385 RID: 45957
	[Nullable(2)]
	private PowerCurrencyItem PowerCurrencyItem;

	// Token: 0x0400B386 RID: 45958
	[Nullable(2)]
	private PowerCurrencyItem OverPowerCurrencyItem;

	// Token: 0x0400B387 RID: 45959
	protected LoopScrollView<WeeklyRoguePhantomRewardItem, WeeklyRoguePhantomRewardInfo> PhantomLoopScrollView;

	// Token: 0x0400B388 RID: 45960
	protected WeeklyRogueRewardPopViewData InfoData;

	// Token: 0x0400B389 RID: 45961
	[Nullable(2)]
	private PowerRewardButtonItem SingleButtonItem;

	// Token: 0x0400B38A RID: 45962
	[Nullable(2)]
	private PowerRewardButtonItem DoubleButtonItem;

	// Token: 0x0400B38B RID: 45963
	private int CurSelectedAreaId = -1;

	// Token: 0x0400B38C RID: 45964
	private const int HELP_ID = 463;

	// Token: 0x02009012 RID: 36882
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0403056A RID: 197994
		TxtTitle,
		// Token: 0x0403056B RID: 197995
		LoopScroll,
		// Token: 0x0403056C RID: 197996
		RewardItem,
		// Token: 0x0403056D RID: 197997
		TxtSelected,
		// Token: 0x0403056E RID: 197998
		BtnLeft,
		// Token: 0x0403056F RID: 197999
		BtnRight,
		// Token: 0x04030570 RID: 198000
		BtnHelpInfo
	}
}
