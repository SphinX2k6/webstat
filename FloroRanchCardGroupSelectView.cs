using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C27 RID: 7207
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchCardGroupSelectView : UiViewBase
{
	// Token: 0x0600D186 RID: 53638 RVA: 0x00379A0F File Offset: 0x00377C0F
	public FloroRanchCardGroupSelectView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D187 RID: 53639 RVA: 0x00379A30 File Offset: 0x00377C30
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
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
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnCloseView));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickHideButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D188 RID: 53640 RVA: 0x00379BE4 File Offset: 0x00377DE4
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchCardGroupSelectView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchCardGroupSelectView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D189 RID: 53641 RVA: 0x00379C27 File Offset: 0x00377E27
	protected override void OnBeforeShow()
	{
		TsUiBlur uiBlur = this.UiBlur;
		if (uiBlur == null)
		{
			return;
		}
		uiBlur.SetEnableUiBlur(true);
	}

	// Token: 0x0600D18A RID: 53642 RVA: 0x00379C3A File Offset: 0x00377E3A
	protected override void OnBeforeHide()
	{
		TsUiBlur uiBlur = this.UiBlur;
		if (uiBlur == null)
		{
			return;
		}
		uiBlur.SetEnableUiBlur(false);
	}

	// Token: 0x0600D18B RID: 53643 RVA: 0x00379C4D File Offset: 0x00377E4D
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnAnimEvent));
	}

	// Token: 0x0600D18C RID: 53644 RVA: 0x00379C6B File Offset: 0x00377E6B
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnAnimEvent));
	}

	// Token: 0x0600D18D RID: 53645 RVA: 0x00379C8C File Offset: 0x00377E8C
	private void RefreshCardList()
	{
		this.CardLayout.RefreshByDataAsync(this.CardIdList, false, null).ContinueWith(delegate()
		{
			this.PlayCardAppearAnim();
			this.SelectedGridIndexSet.Clear();
			for (int i = 0; i < this.CardIdList.Count; i++)
			{
				this.SelectedGridIndexSet.Add(i);
			}
			base.GetButton(3).SetSelfInteractive(this.SelectedGridIndexSet.Count > 0);
			foreach (FloroRanchCardItem floroRanchCardItem in this.CardLayout.GetLayoutItemList())
			{
				floroRanchCardItem.SetToggleState(true);
			}
		});
	}

	// Token: 0x0600D18E RID: 53646 RVA: 0x00379CC8 File Offset: 0x00377EC8
	private void PlayCardAppearAnim()
	{
		if (this.TimerId != null)
		{
			this.ClearTimerId();
		}
		List<FloroRanchCardItem> itemList = this.CardLayout.GetLayoutItemList();
		int totalCount = itemList.Count;
		if (totalCount == 0)
		{
			return;
		}
		int curIndex = 0;
		this.TimerId = TimerSystem.GameplayTimeInstance.Loop(delegate(float _)
		{
			int curIndex;
			if (curIndex < totalCount)
			{
				itemList[curIndex].PlayAppearAnim();
				curIndex = curIndex;
				curIndex++;
			}
		}, 50f, totalCount, 1f, null, null, true);
	}

	// Token: 0x0600D18F RID: 53647 RVA: 0x00379D4A File Offset: 0x00377F4A
	private void ClearTimerId()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.TimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
		}
		this.TimerId = null;
	}

	// Token: 0x0600D190 RID: 53648 RVA: 0x00379D76 File Offset: 0x00377F76
	protected override void OnBeforeDestroy()
	{
		this.ClearTimerId();
	}

	// Token: 0x0600D191 RID: 53649 RVA: 0x00379D7E File Offset: 0x00377F7E
	private void InitUiBlur()
	{
		AUIBaseActor rootActor = this.RootActor;
		this.UiBlur = (((rootActor != null) ? rootActor.GetComponentByClass(TsUiBlur.StaticClass()) : null) as TsUiBlur);
		TsUiBlur uiBlur = this.UiBlur;
		if (uiBlur == null)
		{
			return;
		}
		uiBlur.SetEnableUiBlur(false);
	}

	// Token: 0x0600D192 RID: 53650 RVA: 0x00379DB8 File Offset: 0x00377FB8
	private FloroRanchCardItem CreateCardItem()
	{
		FloroRanchCardItem floroRanchCardItem = new FloroRanchCardItem();
		global::FloroRanchActivityData currentActivityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
		floroRanchCardItem.SetActivityDataType((currentActivityData != null) ? currentActivityData.ActivityDataType : EFloroRanchActivityDataType.Normal);
		floroRanchCardItem.SetToggleCallBack(new Action<int, int>(this.CardToggleClick));
		return floroRanchCardItem;
	}

	// Token: 0x0600D193 RID: 53651 RVA: 0x00379DFC File Offset: 0x00377FFC
	public void CardToggleClick(int gridIndex, int cardId)
	{
		if (this.SelectedGridIndexSet.Contains(gridIndex))
		{
			this.SelectedGridIndexSet.Remove(gridIndex);
		}
		else
		{
			this.SelectedGridIndexSet.Add(gridIndex);
		}
		base.GetButton(3).SetSelfInteractive(this.SelectedGridIndexSet.Count > 0);
	}

	// Token: 0x0600D194 RID: 53652 RVA: 0x00379E50 File Offset: 0x00378050
	private void OnClickConfirmBtn()
	{
		global::FloroRanchActivityData activityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
		if (activityData == null)
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FloroRanchCardGroupSelect);
		Action<FloroRanchPlaySelectCardGroupResponse> <>9__1;
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			List<int> list = new List<int>();
			foreach (int index in this.SelectedGridIndexSet)
			{
				list.Add(this.CardIdList[index]);
			}
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.FloroRanchCardInGameRedDot, null) ?? new HashSet<int>();
			foreach (int item in list)
			{
				if (!hashSet.Contains(item))
				{
					hashSet.Add(item);
				}
			}
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.FloroRanchCardInGameRedDot, hashSet);
			int id = activityData.Id;
			int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
			FloroRanchController instance = ControllerBase<FloroRanchController>.Instance;
			int activityId = id;
			int subInstanceId2 = subInstanceId;
			int[] cardIdList = list.ToArray();
			Action<FloroRanchPlaySelectCardGroupResponse> callback;
			if ((callback = <>9__1) == null)
			{
				callback = (<>9__1 = delegate(FloroRanchPlaySelectCardGroupResponse response)
				{
					this.OnCloseView();
				});
			}
			instance.SendFloroRanchPlaySelectCardGroupRequest(activityId, subInstanceId2, cardIdList, callback);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600D195 RID: 53653 RVA: 0x00379EB4 File Offset: 0x003780B4
	private void OnAnimEvent(string param)
	{
		if (param == EFloroRanchAnimEvent.ListShow.ToString())
		{
			this.RefreshCardList();
		}
	}

	// Token: 0x0600D196 RID: 53654 RVA: 0x00379EDE File Offset: 0x003780DE
	private void OnCloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600D197 RID: 53655 RVA: 0x00379EE7 File Offset: 0x003780E7
	private void OnClickHideButton()
	{
		ModelBase<FloroRanchGamePlayModel>.Instance.HideRecordView();
	}

	// Token: 0x040063FE RID: 25598
	private GenericLayout<FloroRanchCardItem, int> CardLayout;

	// Token: 0x040063FF RID: 25599
	private List<int> CardIdList = new List<int>();

	// Token: 0x04006400 RID: 25600
	private readonly HashSet<int> SelectedGridIndexSet = new HashSet<int>();

	// Token: 0x04006401 RID: 25601
	private FloroRanchCurrencyItem ItemCost;

	// Token: 0x04006402 RID: 25602
	[Nullable(2)]
	private TimerHandle TimerId;

	// Token: 0x04006403 RID: 25603
	[Nullable(2)]
	private TsUiBlur UiBlur;

	// Token: 0x02007F01 RID: 32513
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B372 RID: 177010
		public const int LayoutCard = 0;

		// Token: 0x0402B373 RID: 177011
		public const int ItemCard = 1;

		// Token: 0x0402B374 RID: 177012
		public const int ButtonRefresh = 2;

		// Token: 0x0402B375 RID: 177013
		public const int ButtonConfirm = 3;

		// Token: 0x0402B376 RID: 177014
		public const int ButtonSkip = 4;

		// Token: 0x0402B377 RID: 177015
		public const int HideButton = 5;

		// Token: 0x0402B378 RID: 177016
		public const int ItemCost = 6;

		// Token: 0x0402B379 RID: 177017
		public const int ItemHidePanel = 7;
	}
}
