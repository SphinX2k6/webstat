using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C38 RID: 7224
[NullableContext(2)]
[Nullable(0)]
public class FloroRanchMainView : UiViewBase
{
	// Token: 0x0600D285 RID: 53893 RVA: 0x0037F56E File Offset: 0x0037D76E
	[NullableContext(1)]
	public FloroRanchMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D286 RID: 53894 RVA: 0x0037F578 File Offset: 0x0037D778
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnDungeonSelectBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D287 RID: 53895 RVA: 0x0037F74C File Offset: 0x0037D94C
	protected override void OnStart()
	{
		new PopupCaptionItem(base.GetItem(0)).SetCloseCallBack(new Action(this.OnCloseBtnClick));
		this.ActivityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
		this.LimitRewardBtn = new ButtonItem(base.GetItem(1));
		this.LimitRewardBtn.SetFunction(new Action<int>(this.OnLimitRewardBtnClick));
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(this.ActivityData.IsInLimitTime());
		}
		this.PermanentRewardBtn = new ButtonItem(base.GetItem(2));
		this.PermanentRewardBtn.SetFunction(new Action<int>(this.OnPermanentRewardBtnClick));
		this.SkillBtn = new ButtonItem(base.GetItem(3));
		this.SkillBtn.SetFunction(new Action<int>(this.OnSkillBtnClick));
		this.HandBookBtn = new ButtonItem(base.GetItem(4));
		this.HandBookBtn.SetFunction(new Action<int>(this.OnHandBookBtnClick));
		this.TechnologyBtn = new ButtonItem(base.GetItem(5));
		this.TechnologyBtn.SetFunction(new Action<int>(this.OnTechnologyBtnClick));
	}

	// Token: 0x0600D288 RID: 53896 RVA: 0x0037F874 File Offset: 0x0037DA74
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.FloroRanchDataRedDot, new Action(this.OnRefreshData));
		Singleton<EventSystem>.Instance.Add(EEventName.FloroRanchSettlement, new Action(this.OnFloroRanchSettlement));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x0600D289 RID: 53897 RVA: 0x0037F8D8 File Offset: 0x0037DAD8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.FloroRanchDataRedDot, new Action(this.OnRefreshData));
		Singleton<EventSystem>.Instance.Remove(EEventName.FloroRanchSettlement, new Action(this.OnFloroRanchSettlement));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x0600D28A RID: 53898 RVA: 0x0037F939 File Offset: 0x0037DB39
	protected override void OnBeforeShow()
	{
		this.RefreshView();
		this.RefreshTimeText();
		this.RefreshData();
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.RefreshTimeText();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x0600D28B RID: 53899 RVA: 0x0037F978 File Offset: 0x0037DB78
	private void RefreshData()
	{
		bool redDotVisible = this.ActivityData.IsSkillHasRedDot();
		ButtonItem skillBtn = this.SkillBtn;
		if (skillBtn != null)
		{
			skillBtn.SetRedDotVisible(redDotVisible);
		}
		ButtonItem handBookBtn = this.HandBookBtn;
		if (handBookBtn != null)
		{
			handBookBtn.SetRedDotVisible(this.ActivityData.IsHandBookHasRedDot());
		}
		string technologyProgress = this.ActivityData.GetTechnologyProgress();
		ButtonItem technologyBtn = this.TechnologyBtn;
		if (technologyBtn != null)
		{
			technologyBtn.SetText(technologyProgress);
		}
		ButtonItem technologyBtn2 = this.TechnologyBtn;
		if (technologyBtn2 == null)
		{
			return;
		}
		technologyBtn2.SetRedDotVisible(this.ActivityData.HasAnyTechPointCanUnlock());
	}

	// Token: 0x0600D28C RID: 53900 RVA: 0x0037F9F8 File Offset: 0x0037DBF8
	public void RefreshView()
	{
		string permanentRewardProgress = this.ActivityData.GetPermanentRewardProgress();
		ButtonItem permanentRewardBtn = this.PermanentRewardBtn;
		if (permanentRewardBtn != null)
		{
			permanentRewardBtn.SetText(permanentRewardProgress);
		}
		ButtonItem permanentRewardBtn2 = this.PermanentRewardBtn;
		if (permanentRewardBtn2 != null)
		{
			permanentRewardBtn2.SetRedDotVisible(this.ActivityData.IsPermanentTaskHasRedDot());
		}
		ButtonItem limitRewardBtn = this.LimitRewardBtn;
		if (limitRewardBtn != null)
		{
			limitRewardBtn.SetRedDotVisible(this.ActivityData.IsLimitTaskHasRedDot());
		}
		string handBookProgress = this.ActivityData.GetHandBookProgress();
		ButtonItem handBookBtn = this.HandBookBtn;
		if (handBookBtn != null)
		{
			handBookBtn.SetText(handBookProgress);
		}
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetUIActive(this.ActivityData.IsDungeonHasRedDot());
		}
		bool flag = this.ActivityData.HasUnFinishedSubIns();
		string textStringId = flag ? "Farm_ContinueGame" : "Farm_NewGame";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), textStringId, Array.Empty<object>());
		UUIItem item2 = base.GetItem(8);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(flag);
	}

	// Token: 0x0600D28D RID: 53901 RVA: 0x0037FADC File Offset: 0x0037DCDC
	private void RefreshTimeText()
	{
		if (!this.ActivityData.IsInLimitTime() && this.TimerHandle != null)
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(this.ActivityData.IsInLimitTime());
			}
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityData.GetLimitTimeActivityEndTime(), "{0}");
		ButtonItem limitRewardBtn = this.LimitRewardBtn;
		if (limitRewardBtn == null)
		{
			return;
		}
		limitRewardBtn.SetText(remainTimeText);
	}

	// Token: 0x0600D28E RID: 53902 RVA: 0x0037FB5F File Offset: 0x0037DD5F
	protected override void OnBeforeHide()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
		this.IsRequesting = false;
	}

	// Token: 0x0600D28F RID: 53903 RVA: 0x0037FB88 File Offset: 0x0037DD88
	private void OnRefreshData()
	{
		this.RefreshData();
	}

	// Token: 0x0600D290 RID: 53904 RVA: 0x0037FB90 File Offset: 0x0037DD90
	private void OnFloroRanchSettlement()
	{
		this.RefreshView();
	}

	// Token: 0x0600D291 RID: 53905 RVA: 0x0037FB98 File Offset: 0x0037DD98
	private void OnRefreshCommonActivityRedDot(int _)
	{
		this.RefreshView();
	}

	// Token: 0x0600D292 RID: 53906 RVA: 0x0037FBA0 File Offset: 0x0037DDA0
	private void OnLimitRewardBtnClick(int _)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchLimitRewardView, null, null);
	}

	// Token: 0x0600D293 RID: 53907 RVA: 0x0037FBB3 File Offset: 0x0037DDB3
	private void OnPermanentRewardBtnClick(int _)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchPermanentRewardView, null, null);
	}

	// Token: 0x0600D294 RID: 53908 RVA: 0x0037FBC8 File Offset: 0x0037DDC8
	private void OnSkillBtnClick(int _)
	{
		FloroRanchSkillViewParam floroRanchSkillViewParam = new FloroRanchSkillViewParam
		{
			CanSelect = false,
			ActivityDataType = EFloroRanchActivityDataType.Normal
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchSkillView, floroRanchSkillViewParam, null);
	}

	// Token: 0x0600D295 RID: 53909 RVA: 0x0037FC05 File Offset: 0x0037DE05
	private void OnHandBookBtnClick(int _)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchHandBookView, null, null);
	}

	// Token: 0x0600D296 RID: 53910 RVA: 0x0037FC18 File Offset: 0x0037DE18
	private void OnTechnologyBtnClick(int _)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchTechnologyView, null, null);
	}

	// Token: 0x0600D297 RID: 53911 RVA: 0x0037FC2C File Offset: 0x0037DE2C
	private void OnDungeonSelectBtnClick()
	{
		if (this.IsRequesting)
		{
			return;
		}
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ConnectBan", Array.Empty<object>());
			return;
		}
		if (this.ActivityData.HasUnFinishedSubIns())
		{
			FloroRanchSubDungeonData subDungeonData = this.ActivityData.GetUnFinishedSubDungeonData();
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FloroRanchArchive);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(this.ActivityData.GetFloroRanchDungeonData(subDungeonData.InstanceId).GetDungeonName(), null);
			EFloroRanchDifficulty difficulty = (EFloroRanchDifficulty)subDungeonData.Difficulty;
			string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(FloroRanchDefine.FloroRanchDifficultyTextId[difficulty], null);
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				localTextNew,
				localTextNew2,
				this.ActivityData.GetSavedStage().ToString()
			});
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			this.IsRequesting = true;
			bool isConfirmed = false;
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				isConfirmed = true;
				ControllerBase<FloroRanchController>.Instance.SendFloroRanchAbandonArchiveRequest(this.ActivityData.Id, subDungeonData.Id, delegate(FloroRanchSettleResponse _)
				{
					this.IsRequesting = false;
					Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchDungeonSelectView, null, null);
				});
			};
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				isConfirmed = true;
				ControllerBase<FloroRanchController>.Instance.SendFloroRanchStartPlayRequest(this.ActivityData.Id, subDungeonData.Id, null, null, delegate(FloroRanchStartPlayResponse response)
				{
					if (response == null)
					{
						this.IsRequesting = false;
					}
				});
			};
			confirmBoxDataNew.DestroyFunction = delegate()
			{
				if (!isConfirmed)
				{
					this.IsRequesting = false;
				}
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchDungeonSelectView, null, null);
	}

	// Token: 0x0600D298 RID: 53912 RVA: 0x0037FD7E File Offset: 0x0037DF7E
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x04006451 RID: 25681
	private global::FloroRanchActivityData ActivityData;

	// Token: 0x04006452 RID: 25682
	private ButtonItem LimitRewardBtn;

	// Token: 0x04006453 RID: 25683
	private ButtonItem PermanentRewardBtn;

	// Token: 0x04006454 RID: 25684
	private ButtonItem SkillBtn;

	// Token: 0x04006455 RID: 25685
	private ButtonItem HandBookBtn;

	// Token: 0x04006456 RID: 25686
	private ButtonItem TechnologyBtn;

	// Token: 0x04006457 RID: 25687
	private TimerHandle TimerHandle;

	// Token: 0x04006458 RID: 25688
	private bool IsRequesting;

	// Token: 0x02007F34 RID: 32564
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B4B4 RID: 177332
		public const int ItemCaption = 0;

		// Token: 0x0402B4B5 RID: 177333
		public const int ItemLimitRewardBtn = 1;

		// Token: 0x0402B4B6 RID: 177334
		public const int ItemPermanentRewardBtn = 2;

		// Token: 0x0402B4B7 RID: 177335
		public const int ItemSkillBtn = 3;

		// Token: 0x0402B4B8 RID: 177336
		public const int ItemHandBookBtn = 4;

		// Token: 0x0402B4B9 RID: 177337
		public const int ItemTechnologyBtn = 5;

		// Token: 0x0402B4BA RID: 177338
		public const int DungeonSelectBtn = 6;

		// Token: 0x0402B4BB RID: 177339
		public const int TextDungeonSelectBtn = 7;

		// Token: 0x0402B4BC RID: 177340
		public const int ItemHasRecord = 8;

		// Token: 0x0402B4BD RID: 177341
		public const int ItemDungeonSelectRedDot = 9;

		// Token: 0x0402B4BE RID: 177342
		public const int ItemMask = 10;
	}
}
