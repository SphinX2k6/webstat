using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C28 RID: 7208
[NullableContext(2)]
[Nullable(0)]
public class FloroRanchCardSelectView : UiViewBase
{
	// Token: 0x0600D199 RID: 53657 RVA: 0x00379F98 File Offset: 0x00378198
	[NullableContext(1)]
	public FloroRanchCardSelectView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D19A RID: 53658 RVA: 0x00379FA8 File Offset: 0x003781A8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickRefreshBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickSkipBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickHideButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D19B RID: 53659 RVA: 0x0037A228 File Offset: 0x00378428
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchCardSelectView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchCardSelectView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D19C RID: 53660 RVA: 0x0037A26B File Offset: 0x0037846B
	protected override void OnBeforeShow()
	{
		this.RefreshView();
		this.UiBlur.SetEnableUiBlur(true);
	}

	// Token: 0x0600D19D RID: 53661 RVA: 0x0037A27F File Offset: 0x0037847F
	protected override void OnBeforeHide()
	{
		this.UiBlur.SetEnableUiBlur(false);
	}

	// Token: 0x0600D19E RID: 53662 RVA: 0x0037A290 File Offset: 0x00378490
	private void RefreshView()
	{
		FloroRanchGacha gachaData = this.GachaData;
		bool flag = gachaData != null && gachaData.AllowedRefresh;
		UUIButtonComponent button = base.GetButton(2);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(flag);
			}
		}
		if (flag)
		{
			FloroRanchCurrencyData diamondData = ModelBase<FloroRanchGamePlayModel>.Instance.DiamondData;
			base.SetTextureByPath(diamondData.ConfigData.GetSmallIcon(), base.GetTexture(8), null, null);
			int freeTimes = this.GachaData.FreeTimes;
			UUIText text = base.GetText(10);
			if (text != null)
			{
				text.ShowTextNew((freeTimes > 0) ? "Farm_Edit5" : "Farm_Edit4");
			}
			UUIText text2 = base.GetText(9);
			if (freeTimes > 0)
			{
				text2.SetText("-0", true);
				text2.useChangeColor = false;
				UUIItem item = base.GetItem(11);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIText text3 = base.GetText(12);
				if (text3 != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(freeTimes);
					text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				}
			}
			else
			{
				int amount = diamondData.GetAmount();
				int count = this.GachaData.Cost[0].Count;
				bool flag2 = amount >= count;
				UUIText uuitext = text2;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("-");
				defaultInterpolatedStringHandler.AppendFormatted<int>(count);
				uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				text2.useChangeColor = !flag2;
				UUIItem item2 = base.GetItem(11);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
			}
		}
		this.CurrencyItem.SetCurrencyData(ModelBase<FloroRanchGamePlayModel>.Instance.DiamondData);
	}

	// Token: 0x0600D19F RID: 53663 RVA: 0x0037A42C File Offset: 0x0037862C
	private UniTask RefreshCardLayout()
	{
		FloroRanchCardSelectView.<RefreshCardLayout>d__15 <RefreshCardLayout>d__;
		<RefreshCardLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCardLayout>d__.<>4__this = this;
		<RefreshCardLayout>d__.<>1__state = -1;
		<RefreshCardLayout>d__.<>t__builder.Start<FloroRanchCardSelectView.<RefreshCardLayout>d__15>(ref <RefreshCardLayout>d__);
		return <RefreshCardLayout>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1A0 RID: 53664 RVA: 0x0037A46F File Offset: 0x0037866F
	private void ClearTimerId()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.TimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
		}
		this.TimerId = null;
	}

	// Token: 0x0600D1A1 RID: 53665 RVA: 0x0037A49B File Offset: 0x0037869B
	protected override void OnBeforeDestroy()
	{
		this.ClearTimerId();
	}

	// Token: 0x0600D1A2 RID: 53666 RVA: 0x0037A4A3 File Offset: 0x003786A3
	private void InitUiBlur()
	{
		AUIBaseActor rootActor = this.RootActor;
		this.UiBlur = (((rootActor != null) ? rootActor.GetComponentByClass(TsUiBlur.StaticClass()) : null) as TsUiBlur);
		this.UiBlur.SetEnableUiBlur(false);
	}

	// Token: 0x0600D1A3 RID: 53667 RVA: 0x0037A4D8 File Offset: 0x003786D8
	[NullableContext(1)]
	private void OnRefreshCacheResponse(FloroRanchPlayGachaRefreshResponse response)
	{
		if (response == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanch, ELogAuthor.CXJ, "刷新抽卡请求，返回数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.GachaData = response.Task;
		this.DeselectCard();
		this.RefreshView();
		this.RefreshCardLayout().Forget();
		ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
	}

	// Token: 0x0600D1A4 RID: 53668 RVA: 0x0037A538 File Offset: 0x00378738
	[NullableContext(1)]
	private FloroRanchCardItem CreateCardItem()
	{
		FloroRanchCardItem floroRanchCardItem = new FloroRanchCardItem();
		global::FloroRanchActivityData currentActivityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
		floroRanchCardItem.SetActivityDataType((currentActivityData != null) ? currentActivityData.ActivityDataType : EFloroRanchActivityDataType.Normal);
		floroRanchCardItem.SetToggleCallBack(new Action<int, int>(this.CardToggleClick));
		floroRanchCardItem.SetCanToggleExecuteFunction(new Func<int, bool>(this.CanCardToggleExecuteChange));
		return floroRanchCardItem;
	}

	// Token: 0x0600D1A5 RID: 53669 RVA: 0x0037A58B File Offset: 0x0037878B
	public void CardToggleClick(int gridIndex, int cardId)
	{
		if (this.CardLayout.GetSelectedGridIndex() == gridIndex)
		{
			return;
		}
		this.SelectedCardId = cardId;
		this.CardLayout.SelectGridProxy(gridIndex, false);
		UUIButtonComponent button = base.GetButton(3);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(true);
	}

	// Token: 0x0600D1A6 RID: 53670 RVA: 0x0037A5C2 File Offset: 0x003787C2
	private void DeselectCard()
	{
		this.CardLayout.DeselectCurrentGridProxy();
		this.SelectedCardId = 0;
		UUIButtonComponent button = base.GetButton(3);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(false);
	}

	// Token: 0x0600D1A7 RID: 53671 RVA: 0x0037A5E8 File Offset: 0x003787E8
	private bool CanCardToggleExecuteChange(int gridIndex)
	{
		return this.CardLayout.GetSelectedGridIndex() != gridIndex;
	}

	// Token: 0x0600D1A8 RID: 53672 RVA: 0x0037A5FC File Offset: 0x003787FC
	private void OnClickRefreshBtn()
	{
		if (!this.IsFreeClick)
		{
			return;
		}
		if (!this.GachaData.AllowedRefresh)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.LRC, "抽卡刷新 allowedRefresh 为 false", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (ModelBase<FloroRanchGamePlayModel>.Instance.DiamondData.GetAmount() < this.GachaData.Cost[0].Count)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_MoneyNotEnough", Array.Empty<object>());
			return;
		}
		int id = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData().Id;
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		this.IsFreeClick = false;
		ControllerBase<FloroRanchController>.Instance.FloroRanchPlayRefreshGachaRequest(id, subInstanceId, this.GachaData.IncId, delegate(FloroRanchPlayGachaRefreshResponse response)
		{
			this.OnRefreshCacheResponse(response);
			this.IsFreeClick = true;
		});
	}

	// Token: 0x0600D1A9 RID: 53673 RVA: 0x0037A6C0 File Offset: 0x003788C0
	private void OnClickConfirmBtn()
	{
		if (!this.IsFreeClick)
		{
			return;
		}
		global::FloroRanchActivityData currentActivityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
		int id = currentActivityData.Id;
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		if (this.SelectedCardId == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ChooseCard", Array.Empty<object>());
			return;
		}
		if (ModelBase<FloroRanchGamePlayModel>.Instance.OwnCardEntityCount >= currentActivityData.CardLimitCount)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhrolovaFarm_AnimalMax", Array.Empty<object>());
			return;
		}
		HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.FloroRanchCardInGameRedDot, null) ?? new HashSet<int>();
		if (!hashSet.Contains(this.SelectedCardId))
		{
			hashSet.Add(this.SelectedCardId);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.FloroRanchCardInGameRedDot, hashSet);
		}
		this.IsFreeClick = false;
		ControllerBase<FloroRanchController>.Instance.FloroRanchPlayGachaRequest(id, subInstanceId, this.SelectedCardId, this.GachaData.IncId, delegate(FloroRanchPlayGachaResponse _)
		{
			base.CloseMe(null);
			Action closeCallback = this.CloseCallback;
			if (closeCallback != null)
			{
				closeCallback();
			}
			this.IsFreeClick = true;
		});
	}

	// Token: 0x0600D1AA RID: 53674 RVA: 0x0037A7A4 File Offset: 0x003789A4
	private void OnClickSkipBtn()
	{
		if (!this.IsFreeClick)
		{
			return;
		}
		base.CloseMe(null);
		Action closeCallback = this.CloseCallback;
		if (closeCallback != null)
		{
			closeCallback();
		}
		if (this.GachaData != null)
		{
			int activityId = ModelBase<FloroRanchGamePlayModel>.Instance.ActivityId;
			int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
			this.IsFreeClick = false;
			ControllerBase<FloroRanchController>.Instance.SendFloroRanchCloseTaskRequest(activityId, subInstanceId, this.GachaData.IncId, delegate(FloroRanchCloseTaskResponse response)
			{
				this.IsFreeClick = true;
			});
		}
	}

	// Token: 0x0600D1AB RID: 53675 RVA: 0x0037A81A File Offset: 0x00378A1A
	private void OnClickHideButton()
	{
		if (!this.IsFreeClick)
		{
			return;
		}
		ModelBase<FloroRanchGamePlayModel>.Instance.HideRecordView();
	}

	// Token: 0x04006404 RID: 25604
	private FloroRanchGacha GachaData;

	// Token: 0x04006405 RID: 25605
	private Action CloseCallback;

	// Token: 0x04006406 RID: 25606
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<FloroRanchCardItem, int> CardLayout;

	// Token: 0x04006407 RID: 25607
	private FloroRanchCurrencyItem CurrencyItem;

	// Token: 0x04006408 RID: 25608
	private int SelectedCardId;

	// Token: 0x04006409 RID: 25609
	private TimerHandle TimerId;

	// Token: 0x0400640A RID: 25610
	private TsUiBlur UiBlur;

	// Token: 0x0400640B RID: 25611
	private bool IsFreeClick = true;

	// Token: 0x02007F05 RID: 32517
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B384 RID: 177028
		public const int LayoutCard = 0;

		// Token: 0x0402B385 RID: 177029
		public const int ItemCard = 1;

		// Token: 0x0402B386 RID: 177030
		public const int ButtonRefresh = 2;

		// Token: 0x0402B387 RID: 177031
		public const int ButtonConfirm = 3;

		// Token: 0x0402B388 RID: 177032
		public const int ButtonSkip = 4;

		// Token: 0x0402B389 RID: 177033
		public const int HideButton = 5;

		// Token: 0x0402B38A RID: 177034
		public const int ItemCost = 6;

		// Token: 0x0402B38B RID: 177035
		public const int ItemHidePanel = 7;

		// Token: 0x0402B38C RID: 177036
		public const int RefreshTexture = 8;

		// Token: 0x0402B38D RID: 177037
		public const int RefreshPrice = 9;

		// Token: 0x0402B38E RID: 177038
		public const int RefreshButtonText = 10;

		// Token: 0x0402B38F RID: 177039
		public const int RefreshTimePanel = 11;

		// Token: 0x0402B390 RID: 177040
		public const int RefreshTimeText = 12;
	}
}
