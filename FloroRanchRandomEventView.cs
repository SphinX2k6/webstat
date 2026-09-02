using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C3E RID: 7230
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchRandomEventView : UiViewBase
{
	// Token: 0x0600D2C1 RID: 53953 RVA: 0x00380EE8 File Offset: 0x0037F0E8
	public FloroRanchRandomEventView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D2C2 RID: 53954 RVA: 0x00380EFC File Offset: 0x0037F0FC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickConfirmButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickHideButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D2C3 RID: 53955 RVA: 0x00381114 File Offset: 0x0037F314
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchRandomEventView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchRandomEventView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D2C4 RID: 53956 RVA: 0x00381158 File Offset: 0x0037F358
	protected override void OnBeforeShow()
	{
		global::FloroRanchActivityData currentActivityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
		base.GetButton(8).SetSelfInteractive(this.SelectedChoiceId != 0);
		base.GetSpine(4).SetAnimation(0, "idle", true);
		this.ShowAllToy();
		this.UiBlur.SetEnableUiBlur(true);
		UUIInturnAnimController uuiinturnAnimController = base.GetVerticalLayout(6).GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
		if (uuiinturnAnimController != null)
		{
			uuiinturnAnimController.Play("", -1, false);
		}
		if (currentActivityData != null)
		{
			FloroRanchAudioData floroRanchRandomAudioDataByType = ModelBase<FloroRanchModel>.Instance.GetFloroRanchRandomAudioDataByType(EFloroRanchAudioType.Event, currentActivityData.GetVoiceCharacterType());
			string text = (floroRanchRandomAudioDataByType != null) ? floroRanchRandomAudioDataByType.GetAudioText() : null;
			string text2 = (floroRanchRandomAudioDataByType != null) ? floroRanchRandomAudioDataByType.GetAudioEvent() : null;
			if (string.IsNullOrEmpty(text))
			{
				UUIItem item = base.GetItem(2);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), text, Array.Empty<object>());
				if (!string.IsNullOrEmpty(text2))
				{
					this.EventHandle = Singleton<AudioSystem>.Instance.PostEvent(text2);
				}
				UUIItem item2 = base.GetItem(2);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(true);
			}
		}
	}

	// Token: 0x0600D2C5 RID: 53957 RVA: 0x0038126C File Offset: 0x0037F46C
	protected override void OnBeforeHide()
	{
		this.UiBlur.SetEnableUiBlur(false);
		if (this.EventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.EventHandle, EAudioActionType.Stop, null);
			this.EventHandle = 0;
		}
	}

	// Token: 0x0600D2C6 RID: 53958 RVA: 0x003812AE File Offset: 0x0037F4AE
	private void InitUiBlur()
	{
		this.UiBlur = UE.NewObject<TsUiBlur>(this.RootActor, null, EObjectFlags.RF_NoFlags);
		this.UiBlur.SetEnableUiBlur(false);
	}

	// Token: 0x0600D2C7 RID: 53959 RVA: 0x003812D0 File Offset: 0x0037F4D0
	private UniTask CreateToyItem(int point)
	{
		FloroRanchRandomEventView.<CreateToyItem>d__14 <CreateToyItem>d__;
		<CreateToyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateToyItem>d__.<>4__this = this;
		<CreateToyItem>d__.point = point;
		<CreateToyItem>d__.<>1__state = -1;
		<CreateToyItem>d__.<>t__builder.Start<FloroRanchRandomEventView.<CreateToyItem>d__14>(ref <CreateToyItem>d__);
		return <CreateToyItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D2C8 RID: 53960 RVA: 0x0038131C File Offset: 0x0037F51C
	private void ShowAllToy()
	{
		int enableToyCount = ModelBase<FloroRanchGamePlayModel>.Instance.EnableToyCount;
		for (int i = 0; i < enableToyCount; i++)
		{
			if (ModelBase<FloroRanchGamePlayModel>.Instance.GetToyEntityByPoint(i) != null)
			{
				this.ShowToy(i);
			}
			else
			{
				this.HideToy(i);
			}
		}
	}

	// Token: 0x0600D2C9 RID: 53961 RVA: 0x00381360 File Offset: 0x0037F560
	private void ShowToy(int point)
	{
		FloroRanchToyGridItem floroRanchToyGridItem;
		if (this.ToyItemMap.TryGetValue(point, out floroRanchToyGridItem))
		{
			FloroRanchEntityBase toyEntityByPoint = ModelBase<FloroRanchGamePlayModel>.Instance.GetToyEntityByPoint(point);
			floroRanchToyGridItem.PlayShowAnim(toyEntityByPoint);
		}
	}

	// Token: 0x0600D2CA RID: 53962 RVA: 0x00381390 File Offset: 0x0037F590
	private void HideToy(int point)
	{
		FloroRanchToyGridItem floroRanchToyGridItem;
		if (this.ToyItemMap.TryGetValue(point, out floroRanchToyGridItem))
		{
			floroRanchToyGridItem.SetInfoPanelActive(false);
		}
	}

	// Token: 0x0600D2CB RID: 53963 RVA: 0x003813B4 File Offset: 0x0037F5B4
	private void SetToyListActive(bool isActive)
	{
		base.GetItem(10).SetAlpha(isActive > false);
	}

	// Token: 0x0600D2CC RID: 53964 RVA: 0x003813C8 File Offset: 0x0037F5C8
	private void ToySellCallback(int point)
	{
		this.HideToy(point);
		this.ShowAllToy();
	}

	// Token: 0x0600D2CD RID: 53965 RVA: 0x003813D8 File Offset: 0x0037F5D8
	private void OnClickToyItem(int point)
	{
		if (point < 0)
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchShopTipView, new FloroRanchShopTipViewParam
		{
			ToyPoint = point,
			SellCallback = new Action<int>(this.ToySellCallback),
			ShowToyListCallback = new Action<bool>(this.SetToyListActive)
		}, null);
		FloroRanchToyGridItem floroRanchToyGridItem;
		if (this.ToyItemMap.TryGetValue(point, out floroRanchToyGridItem) && floroRanchToyGridItem != null)
		{
			floroRanchToyGridItem.SetSelectState(false);
		}
	}

	// Token: 0x0600D2CE RID: 53966 RVA: 0x00381450 File Offset: 0x0037F650
	private FloroRanchRandomEventItem InitEventItem()
	{
		FloroRanchRandomEventItem floroRanchRandomEventItem = new FloroRanchRandomEventItem();
		floroRanchRandomEventItem.BindClickCallback(new Action<int, int>(this.OnClickEventItem));
		return floroRanchRandomEventItem;
	}

	// Token: 0x0600D2CF RID: 53967 RVA: 0x0038146C File Offset: 0x0037F66C
	private void OnClickConfirmButton()
	{
		global::FloroRanchActivityData activityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
		if (activityData == null)
		{
			return;
		}
		FloroRanchWeeklyChoice? floroRanchWeeklyChoiceById = ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchWeeklyChoiceById(this.SelectedChoiceId);
		if (floroRanchWeeklyChoiceById != null)
		{
			int needRemoveToyCount = floroRanchWeeklyChoiceById.Value.NeedRemoveToyCount;
			int needEmptyGridCount = floroRanchWeeklyChoiceById.Value.NeedEmptyGridCount;
			if (needRemoveToyCount > 0)
			{
				int toyRelateQuality = floroRanchWeeklyChoiceById.Value.ToyRelateQuality;
				List<FloroRanchEntityBase> showToyEntityList = ModelBase<FloroRanchGamePlayModel>.Instance.GetShowToyEntityList();
				int num = 0;
				foreach (FloroRanchEntityBase floroRanchEntityBase in showToyEntityList)
				{
					FloroRanchToyDataComponent floroRanchToyDataComponent = floroRanchEntityBase.CheckGetComponent<FloroRanchToyDataComponent>();
					if (((floroRanchToyDataComponent != null) ? floroRanchToyDataComponent.ToyData : null) != null && floroRanchToyDataComponent.ToyData.CheckCanSell() && (toyRelateQuality <= 0 || floroRanchToyDataComponent.ToyData.GetToyQualityData().Id == toyRelateQuality))
					{
						num++;
					}
				}
				if (num < needRemoveToyCount)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_EventBlockTip", Array.Empty<object>());
					return;
				}
			}
			int num2 = needEmptyGridCount - needRemoveToyCount;
			if (num2 > 0 && ModelBase<FloroRanchGamePlayModel>.Instance.EnableToyCount - ModelBase<FloroRanchGamePlayModel>.Instance.GetCurToyCount() < num2)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FloroRanchEventToyGridNotEnough);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					this.SendEventChoiceRequest(activityData);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			int getToyRelateQuality = floroRanchWeeklyChoiceById.Value.GetToyRelateQuality;
			if (getToyRelateQuality > 0)
			{
				List<int> races = ModelBase<FloroRanchGamePlayModel>.Instance.Races;
				Dictionary<int, FloroRanchToyData> floroRanchToyDataMap = ModelBase<FloroRanchModel>.Instance.GetFloroRanchToyDataMap();
				int num3 = 0;
				foreach (KeyValuePair<int, FloroRanchToyData> keyValuePair in floroRanchToyDataMap)
				{
					int num4;
					FloroRanchToyData floroRanchToyData;
					keyValuePair.Deconstruct(out num4, out floroRanchToyData);
					int id = num4;
					FloroRanchToyData floroRanchToyData2 = floroRanchToyData;
					if (floroRanchToyData2.GetRarity() == getToyRelateQuality && activityData.IsToyUnlocked(id))
					{
						int toyType = floroRanchToyData2.GetToyType();
						if (toyType == 1)
						{
							num3++;
						}
						else if (toyType == 2 && races.Contains(floroRanchToyData2.GetRace()))
						{
							num3++;
						}
					}
				}
				List<FloroRanchEntityBase> showToyEntityList2 = ModelBase<FloroRanchGamePlayModel>.Instance.GetShowToyEntityList();
				int num5 = 0;
				foreach (FloroRanchEntityBase floroRanchEntityBase2 in showToyEntityList2)
				{
					FloroRanchToyDataComponent floroRanchToyDataComponent2 = floroRanchEntityBase2.CheckGetComponent<FloroRanchToyDataComponent>();
					bool flag;
					if (floroRanchToyDataComponent2 == null)
					{
						flag = false;
					}
					else
					{
						FloroRanchToyData toyData = floroRanchToyDataComponent2.ToyData;
						int? num6 = (toyData != null) ? new int?(toyData.GetToyQualityData().Id) : null;
						int num4 = getToyRelateQuality;
						flag = (num6.GetValueOrDefault() == num4 & num6 != null);
					}
					if (flag)
					{
						num5++;
					}
				}
				if (num3 - num5 < needEmptyGridCount)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("WeeklyFarm_SameToyTip", Array.Empty<object>());
					return;
				}
			}
		}
		this.SendEventChoiceRequest(activityData);
	}

	// Token: 0x0600D2D0 RID: 53968 RVA: 0x00381778 File Offset: 0x0037F978
	private void OnClickEventItem(int gridIndex, int choiceId)
	{
		if (this.SelectedChoiceId == choiceId)
		{
			return;
		}
		this.SelectedChoiceId = choiceId;
		this.EventLayout.SelectGridProxy(gridIndex, false);
		base.GetButton(8).SetSelfInteractive(true);
	}

	// Token: 0x0600D2D1 RID: 53969 RVA: 0x003817A8 File Offset: 0x0037F9A8
	private void SendEventChoiceRequest(global::FloroRanchActivityData activityData)
	{
		int id = activityData.Id;
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		ControllerBase<FloroRanchController>.Instance.SendFloroRanchEventChoiceRequest(id, subInstanceId, this.EventData.IncId, this.SelectedChoiceId, delegate(FloroRanchEventChoiceResponse response)
		{
			base.CloseMe(null);
			Action closeCallback = this.CloseCallback;
			if (closeCallback == null)
			{
				return;
			}
			closeCallback();
		});
	}

	// Token: 0x0600D2D2 RID: 53970 RVA: 0x003817F0 File Offset: 0x0037F9F0
	private void OnClickHideButton()
	{
		ModelBase<FloroRanchGamePlayModel>.Instance.HideRecordView();
	}

	// Token: 0x04006466 RID: 25702
	[Nullable(2)]
	private FloroRanchPlayEvent EventData;

	// Token: 0x04006467 RID: 25703
	[Nullable(2)]
	private Action CloseCallback;

	// Token: 0x04006468 RID: 25704
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<FloroRanchRandomEventItem, int> EventLayout;

	// Token: 0x04006469 RID: 25705
	private int SelectedChoiceId;

	// Token: 0x0400646A RID: 25706
	private readonly Dictionary<int, FloroRanchToyGridItem> ToyItemMap = new Dictionary<int, FloroRanchToyGridItem>();

	// Token: 0x0400646B RID: 25707
	[Nullable(2)]
	private TsUiBlur UiBlur;

	// Token: 0x0400646C RID: 25708
	private int EventHandle;

	// Token: 0x02007F40 RID: 32576
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402B4F7 RID: 177399
		public const int InfoPanel = 0;

		// Token: 0x0402B4F8 RID: 177400
		public const int EventTitle = 1;

		// Token: 0x0402B4F9 RID: 177401
		public const int ChatPanel = 2;

		// Token: 0x0402B4FA RID: 177402
		public const int ChatText = 3;

		// Token: 0x0402B4FB RID: 177403
		public const int Spine = 4;

		// Token: 0x0402B4FC RID: 177404
		public const int BarItem = 5;

		// Token: 0x0402B4FD RID: 177405
		public const int EventLayout = 6;

		// Token: 0x0402B4FE RID: 177406
		public const int EventItem = 7;

		// Token: 0x0402B4FF RID: 177407
		public const int ConfirmButton = 8;

		// Token: 0x0402B500 RID: 177408
		public const int HideButton = 9;

		// Token: 0x0402B501 RID: 177409
		public const int ToyLayout = 10;

		// Token: 0x0402B502 RID: 177410
		public const int ToyItemTemplate = 11;
	}
}
