using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200126B RID: 4715
[NullableContext(1)]
[Nullable(0)]
public class BlackCoastActivityMainView : UiViewBase
{
	// Token: 0x06007DC8 RID: 32200 RVA: 0x00212F0D File Offset: 0x0021110D
	public BlackCoastActivityMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06007DC9 RID: 32201 RVA: 0x00212F18 File Offset: 0x00211118
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.ButtonWeaponFunction));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.ButtonQuestFunction));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.ButtonIconFunction));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007DCA RID: 32202 RVA: 0x00213110 File Offset: 0x00211310
	protected override UniTask OnBeforeStartAsync()
	{
		BlackCoastActivityMainView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BlackCoastActivityMainView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007DCB RID: 32203 RVA: 0x00213154 File Offset: 0x00211354
	protected override void OnStart()
	{
		UUITexture textureIcon = base.GetTexture(2);
		textureIcon.SetUIActive(false);
		base.SetItemIcon(textureIcon, this.ActivityBaseData.GetProgressItemId, null, delegate(bool _)
		{
			textureIcon.SetUIActive(true);
		});
	}

	// Token: 0x06007DCC RID: 32204 RVA: 0x002131AC File Offset: 0x002113AC
	protected override void OnBeforeShow()
	{
		ControllerBase<ActivityController>.Instance.CheckIsActivityClose(null, new int?(this.ActivityBaseData.Id));
		this.RefreshDataProgress();
		this.RefreshStageLayout();
		base.GetButton(6).RootUIComp.Get().SetUIActive(this.ActivityBaseData.GetCurrentLockQuestId() != null);
	}

	// Token: 0x06007DCD RID: 32205 RVA: 0x00213214 File Offset: 0x00211414
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<RewardPopupData>(EEventName.RefreshRewardPopUp, new Action<RewardPopupData>(this.OnRefreshRewardPopUp));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRewardLayout));
	}

	// Token: 0x06007DCE RID: 32206 RVA: 0x0021324E File Offset: 0x0021144E
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshRewardPopUp, new Action<RewardPopupData>(this.OnRefreshRewardPopUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRewardLayout));
	}

	// Token: 0x06007DCF RID: 32207 RVA: 0x00213288 File Offset: 0x00211488
	private void RefreshDataProgress()
	{
		base.GetText(3).SetText(this.ActivityBaseData.GetProgressItemCount().ToString() + "/", true);
		base.GetText(4).SetText(this.ActivityBaseData.GetProgressItemTotal().ToString(), true);
		this.RewardPanel.Refresh();
	}

	// Token: 0x06007DD0 RID: 32208 RVA: 0x002132EA File Offset: 0x002114EA
	private void RefreshStageLayout()
	{
		this.StageLayout.RefreshByData(this.ActivityBaseData.GetAllStages().ToList<BlackCoastStageInfo>(), null, false);
	}

	// Token: 0x06007DD1 RID: 32209 RVA: 0x00213309 File Offset: 0x00211509
	private BlackCoastStageItem OnCreateStageItem()
	{
		return new BlackCoastStageItem
		{
			OpenTaskView = new Action<int>(this.OnOpenTaskView),
			NewFlagRedDot = ((int stageId) => this.ActivityBaseData.HasNewStageFlag(stageId))
		};
	}

	// Token: 0x06007DD2 RID: 32210 RVA: 0x00213334 File Offset: 0x00211534
	private void OnRefreshRewardLayout(int activityId)
	{
		if (this.ActivityBaseData != null && this.ActivityBaseData.Id == activityId)
		{
			this.RewardPanel.RefreshLayout();
		}
	}

	// Token: 0x06007DD3 RID: 32211 RVA: 0x00213357 File Offset: 0x00211557
	private void OnRefreshRewardPopUp(RewardPopupData data)
	{
		this.RewardPopup.Refresh(data);
	}

	// Token: 0x06007DD4 RID: 32212 RVA: 0x00213365 File Offset: 0x00211565
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06007DD5 RID: 32213 RVA: 0x0021336E File Offset: 0x0021156E
	private void OnOpenTaskView(int stageId)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BlackCoastActivityTaskView, new object[]
		{
			this.ActivityBaseData,
			stageId
		}, null);
	}

	// Token: 0x06007DD6 RID: 32214 RVA: 0x00213398 File Offset: 0x00211598
	private void ButtonWeaponFunction()
	{
		WeaponPreviewViewParam weaponPreviewViewParam = new WeaponPreviewViewParam();
		WeaponDataBase[] previewWeaponDataList = this.ActivityBaseData.GetPreviewWeaponDataList();
		weaponPreviewViewParam.WeaponDataList = previewWeaponDataList;
		weaponPreviewViewParam.SelectedIndex = 0;
		WeaponPreviewViewParam param = weaponPreviewViewParam;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponPreviewView, param, null);
	}

	// Token: 0x06007DD7 RID: 32215 RVA: 0x002133D6 File Offset: 0x002115D6
	private void ButtonQuestFunction()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.ActivityBaseData.GetCurrentLockQuestId(), null);
	}

	// Token: 0x06007DD8 RID: 32216 RVA: 0x002133F8 File Offset: 0x002115F8
	private void ButtonIconFunction()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ActivityBaseData.GetProgressItemId, true, null);
	}

	// Token: 0x04003C62 RID: 15458
	protected ActivityBlackCoastData ActivityBaseData;

	// Token: 0x04003C63 RID: 15459
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003C64 RID: 15460
	private BlackCoastRewardPanel RewardPanel;

	// Token: 0x04003C65 RID: 15461
	private CommonRewardPopup RewardPopup;

	// Token: 0x04003C66 RID: 15462
	private GenericLayout<BlackCoastStageItem, BlackCoastStageInfo> StageLayout;

	// Token: 0x020075E0 RID: 30176
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028A5B RID: 166491
		public const int Caption = 0;

		// Token: 0x04028A5C RID: 166492
		public const int ButtonWeapon = 1;

		// Token: 0x04028A5D RID: 166493
		public const int DataIcon = 2;

		// Token: 0x04028A5E RID: 166494
		public const int DataCount = 3;

		// Token: 0x04028A5F RID: 166495
		public const int DataTotal = 4;

		// Token: 0x04028A60 RID: 166496
		public const int ProgressBar = 5;

		// Token: 0x04028A61 RID: 166497
		public const int ButtonQuest = 6;

		// Token: 0x04028A62 RID: 166498
		public const int StageLayout = 7;

		// Token: 0x04028A63 RID: 166499
		public const int StageCard = 8;

		// Token: 0x04028A64 RID: 166500
		public const int ButtonIcon = 9;
	}
}
