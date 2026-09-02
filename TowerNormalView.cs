using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002BFA RID: 11258
[NullableContext(2)]
[Nullable(0)]
public class TowerNormalView : UiViewBase
{
	// Token: 0x0601676B RID: 92011 RVA: 0x0063DB3E File Offset: 0x0063BD3E
	[NullableContext(1)]
	public TowerNormalView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601676C RID: 92012 RVA: 0x0063DB50 File Offset: 0x0063BD50
	protected unsafe override void OnRegisterComponent()
	{
		int num = 23;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 6;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickRewardBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickChangeTowerBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickShopBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnLowRiskChange));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnHighRiskChange));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(18, new Action<EToggleState>(this.OnOverLockChange));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601676D RID: 92013 RVA: 0x0063DF6C File Offset: 0x0063C16C
	private UniTask BackToBattleView()
	{
		TowerNormalView.<BackToBattleView>d__12 <BackToBattleView>d__;
		<BackToBattleView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<BackToBattleView>d__.<>4__this = this;
		<BackToBattleView>d__.<>1__state = -1;
		<BackToBattleView>d__.<>t__builder.Start<TowerNormalView.<BackToBattleView>d__12>(ref <BackToBattleView>d__);
		return <BackToBattleView>d__.<>t__builder.Task;
	}

	// Token: 0x0601676E RID: 92014 RVA: 0x0063DFAF File Offset: 0x0063C1AF
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnTowerRewardReceived, new Action(this.RefreshRewardProgress));
	}

	// Token: 0x0601676F RID: 92015 RVA: 0x0063DFCD File Offset: 0x0063C1CD
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTowerRewardReceived, new Action(this.RefreshRewardProgress));
	}

	// Token: 0x06016770 RID: 92016 RVA: 0x0063DFEC File Offset: 0x0063C1EC
	protected override void OnStart()
	{
		int? num = this.OpenParam as int?;
		if (ModelBase<TowerModel>.Instance.CheckInTower())
		{
			ControllerBase<TowerController>.Instance.ClearAllHatredInTower();
		}
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.AreaLayout = new GenericLayout<TowerAreaItem, int>(base.GetHorizontalLayout(1), new Func<TowerAreaItem>(this.InitItem), base.GetItem(19).GetOwner() as AUIBaseActor, false, true);
		this.RedAreaLayout = new GenericLayout<TowerAreaItem, int>(base.GetHorizontalLayout(1), new Func<TowerAreaItem>(this.InitItem), base.GetItem(17).GetOwner() as AUIBaseActor, false, true);
		this.IsLowRiskClear = ModelBase<TowerModel>.Instance.GetDifficultyIsClear(1);
		this.IsHighRiskClear = ModelBase<TowerModel>.Instance.GetDifficultyIsClear(2);
		this.IsVariationRiskClear = ModelBase<TowerModel>.Instance.GetDifficultyIsClear(3);
		if (num != null)
		{
			int? num2 = num;
			int num3 = 0;
			if (!(num2.GetValueOrDefault() == num3 & num2 != null))
			{
				this.ChangeDifficulty(num.Value);
				switch (num.Value)
				{
				case 1:
					this.CurrentToggle = base.GetExtendToggle(4);
					goto IL_1B4;
				case 2:
					this.CurrentToggle = base.GetExtendToggle(5);
					goto IL_1B4;
				case 3:
					goto IL_1B4;
				case 4:
					this.CurrentToggle = base.GetExtendToggle(18);
					goto IL_1B4;
				default:
					goto IL_1B4;
				}
			}
		}
		if (this.IsLowRiskClear && !this.IsVariationRiskClear)
		{
			this.ChangeDifficulty(2);
			this.CurrentToggle = base.GetExtendToggle(5);
		}
		else if (!this.IsVariationRiskClear && !this.IsLowRiskClear)
		{
			this.ChangeDifficulty(1);
			this.CurrentToggle = base.GetExtendToggle(4);
		}
		else
		{
			this.ChangeDifficulty(4);
			this.CurrentToggle = base.GetExtendToggle(18);
		}
		IL_1B4:
		UUIExtendToggle currentToggle = this.CurrentToggle;
		if (currentToggle != null)
		{
			currentToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}
		base.GetItem(7).SetUIActive(this.IsLowRiskClear);
		base.GetItem(8).SetUIActive(ModelBase<TowerModel>.Instance.GetDifficultyIsClear(2));
		base.GetItem(20).SetUIActive(ModelBase<TowerModel>.Instance.GetDifficultyIsClear(4));
		this.TitleItem = new TowerTitleItem(base.GetItem(0), delegate()
		{
			if (ModelBase<TowerModel>.Instance.CheckInTower())
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.LeaveTowerOnTowerView);
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					ControllerBase<TowerController>.Instance.LeaveTower();
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			this.BackToBattleView();
		});
		this.TitleItem.RefreshText("InstanceDungeonTitle_31_CommonText", Array.Empty<string>());
		this.RefreshRewardProgress();
		this.AddHomeBtnExtraCallback();
	}

	// Token: 0x06016771 RID: 92017 RVA: 0x0063E243 File Offset: 0x0063C443
	private void AddHomeBtnExtraCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			TowerNormalView.<>c.<<AddHomeBtnExtraCallback>b__16_0>d <<AddHomeBtnExtraCallback>b__16_0>d;
			<<AddHomeBtnExtraCallback>b__16_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExtraCallback>b__16_0>d.<>1__state = -1;
			<<AddHomeBtnExtraCallback>b__16_0>d.<>t__builder.Start<TowerNormalView.<>c.<<AddHomeBtnExtraCallback>b__16_0>d>(ref <<AddHomeBtnExtraCallback>b__16_0>d);
			return <<AddHomeBtnExtraCallback>b__16_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x06016772 RID: 92018 RVA: 0x0063E274 File Offset: 0x0063C474
	protected override void OnBeforeShow()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.TowerReward, base.GetItem(6), null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.TowerRewardByDifficulties, base.GetItem(11), null, 1);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.TowerRewardByDifficulties, base.GetItem(12), null, 2);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.TowerRewardByDifficulties, base.GetItem(13), null, 3);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.TowerRewardByDifficulties, base.GetItem(22), null, 4);
		ModelBase<TowerModel>.Instance.CurrentSelectDifficulties = this.CurrentDifficulty;
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotTowerReward);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotTowerRewardByDifficulties, 1);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotTowerRewardByDifficulties, 2);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotTowerRewardByDifficulties, 3);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotTowerRewardByDifficulties, 4);
	}

	// Token: 0x06016773 RID: 92019 RVA: 0x0063E354 File Offset: 0x0063C554
	protected override void OnBeforeDestroy()
	{
		ControllerBase<InstanceDungeonEntranceController>.Instance.RestoreDungeonEntranceEntity();
		if (this.AreaLayout != null)
		{
			this.AreaLayout = null;
		}
		this.CurrentToggle = null;
		TowerTitleItem titleItem = this.TitleItem;
		if (titleItem != null)
		{
			titleItem.Destroy(null);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		ControllerBase<InstanceDungeonEntranceController>.Instance.RestoreDungeonEntranceEntity();
	}

	// Token: 0x06016774 RID: 92020 RVA: 0x0063E3B8 File Offset: 0x0063C5B8
	protected override void OnAfterHide()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.TowerReward, base.GetItem(6), 0);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.TowerRewardByDifficulties, base.GetItem(11), 1);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.TowerRewardByDifficulties, base.GetItem(12), 2);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.TowerRewardByDifficulties, base.GetItem(13), 3);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.TowerRewardByDifficulties, base.GetItem(22), 4);
	}

	// Token: 0x06016775 RID: 92021 RVA: 0x0063E42D File Offset: 0x0063C62D
	[NullableContext(1)]
	private TowerAreaItem InitItem()
	{
		return new TowerAreaItem();
	}

	// Token: 0x06016776 RID: 92022 RVA: 0x0063E434 File Offset: 0x0063C634
	private void OnLowRiskChange(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		UUIExtendToggle currentToggle = this.CurrentToggle;
		if (currentToggle != null)
		{
			currentToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentToggle = base.GetExtendToggle(4);
		this.LevelSequencePlayer.StopCurrentSequence(false, false);
		this.LevelSequencePlayer.PlaySequencePurely("Switch", false, false, null, null, false);
		this.ChangeDifficulty(1);
	}

	// Token: 0x06016777 RID: 92023 RVA: 0x0063E49C File Offset: 0x0063C69C
	private void OnHighRiskChange(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		UUIExtendToggle currentToggle = this.CurrentToggle;
		if (currentToggle != null)
		{
			currentToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentToggle = base.GetExtendToggle(5);
		this.LevelSequencePlayer.StopCurrentSequence(false, false);
		this.LevelSequencePlayer.PlaySequencePurely("Switch", false, false, null, null, false);
		this.ChangeDifficulty(2);
	}

	// Token: 0x06016778 RID: 92024 RVA: 0x0063E504 File Offset: 0x0063C704
	private void OnOverLockChange(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		UUIExtendToggle currentToggle = this.CurrentToggle;
		if (currentToggle != null)
		{
			currentToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentToggle = base.GetExtendToggle(18);
		this.LevelSequencePlayer.StopCurrentSequence(false, false);
		this.LevelSequencePlayer.PlaySequencePurely("Switch", false, false, null, null, false);
		this.ChangeDifficulty(4);
	}

	// Token: 0x06016779 RID: 92025 RVA: 0x0063E56C File Offset: 0x0063C76C
	private void ChangeDifficulty(int difficulty)
	{
		ModelBase<TowerModel>.Instance.CurrentSelectDifficulties = difficulty;
		this.CurrentDifficulty = difficulty;
		this.RefreshTowerLockState();
		int[] difficultyAllAreaFirstFloor = ModelBase<TowerModel>.Instance.GetDifficultyAllAreaFirstFloor(difficulty, false);
		if (this.CurrentDifficulty == 4)
		{
			this.AreaLayout.RefreshByData(Array.Empty<int>(), null, false);
			this.RedAreaLayout.RefreshByData(difficultyAllAreaFirstFloor.ToList<int>(), null, false);
			if (!ModelBase<TowerModel>.Instance.CurrentTowerLock)
			{
				ModelBase<TowerModel>.Instance.SetOverLockHasShow();
			}
		}
		else
		{
			this.RedAreaLayout.RefreshByData(Array.Empty<int>(), null, false);
			this.AreaLayout.RefreshByData(difficultyAllAreaFirstFloor.ToList<int>(), null, false);
		}
		this.RefreshRewardProgress();
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotTowerReward);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotTowerRewardByDifficulties, this.CurrentDifficulty);
	}

	// Token: 0x0601677A RID: 92026 RVA: 0x0063E638 File Offset: 0x0063C838
	private void OnClickRewardBtn()
	{
		TowerModel instance = ModelBase<TowerModel>.Instance;
		float? num = (instance != null) ? new float?(instance.GetDifficultyRewardProgress(ModelBase<TowerModel>.Instance.CurrentSelectDifficulties)) : null;
		float num2 = (float)1;
		if (num.GetValueOrDefault() == num2 & num != null)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("HaveAllReward", Array.Empty<object>());
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerRewardView, null, delegate(bool success, int viewId)
		{
			base.AddChildViewById(viewId);
		});
	}

	// Token: 0x0601677B RID: 92027 RVA: 0x0063E6B8 File Offset: 0x0063C8B8
	private void OnClickChangeTowerBtn()
	{
		if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TowerVariationView) != null)
		{
			base.CloseMe(null);
			return;
		}
		Singleton<UiManager>.Instance.OpenViewAsync(EUiViewName.TowerVariationView, null, null);
	}

	// Token: 0x0601677C RID: 92028 RVA: 0x0063E6F8 File Offset: 0x0063C8F8
	private void OnClickShopBtn()
	{
		ControllerBase<PayShopController>.Instance.OpenPayShopViewWithTab(PayShopDefine.EPayShopTabType.ActivityShop, 0);
	}

	// Token: 0x0601677D RID: 92029 RVA: 0x0063E708 File Offset: 0x0063C908
	private void RefreshRewardProgress()
	{
		TowerModel instance = ModelBase<TowerModel>.Instance;
		float? num = (instance != null) ? new float?(instance.GetDifficultyRewardProgress(ModelBase<TowerModel>.Instance.CurrentSelectDifficulties)) : null;
		UUISprite sprite = base.GetSprite(9);
		if (sprite != null)
		{
			sprite.SetFillAmount(num.Value);
		}
		float? num2 = num;
		float num3 = (float)1;
		if (num2.GetValueOrDefault() == num3 & num2 != null)
		{
			UUIItem item = base.GetItem(15);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(16);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(true);
			return;
		}
		else
		{
			UUIItem item3 = base.GetItem(15);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(16);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0601677E RID: 92030 RVA: 0x0063E7C0 File Offset: 0x0063C9C0
	private void RefreshTowerLockState()
	{
		switch (this.CurrentDifficulty)
		{
		case 1:
			ModelBase<TowerModel>.Instance.CurrentTowerLock = false;
			base.GetItem(21).SetUIActive(false);
			return;
		case 2:
			ModelBase<TowerModel>.Instance.CurrentTowerLock = !this.IsLowRiskClear;
			base.GetItem(21).SetUIActive(false);
			return;
		case 4:
			ModelBase<TowerModel>.Instance.CurrentTowerLock = !this.IsHighRiskClear;
			base.GetItem(21).SetUIActive(ModelBase<TowerModel>.Instance.CurrentTowerLock);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CycleTower;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "逆境深塔选择难度时异常";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("难度", this.CurrentDifficulty);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0400ADE2 RID: 44514
	private UUIExtendToggle CurrentToggle;

	// Token: 0x0400ADE3 RID: 44515
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerAreaItem, int> AreaLayout;

	// Token: 0x0400ADE4 RID: 44516
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerAreaItem, int> RedAreaLayout;

	// Token: 0x0400ADE5 RID: 44517
	private bool IsLowRiskClear;

	// Token: 0x0400ADE6 RID: 44518
	private bool IsHighRiskClear;

	// Token: 0x0400ADE7 RID: 44519
	private bool IsVariationRiskClear;

	// Token: 0x0400ADE8 RID: 44520
	private TowerTitleItem TitleItem;

	// Token: 0x0400ADE9 RID: 44521
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400ADEA RID: 44522
	private int CurrentDifficulty = 1;

	// Token: 0x02008EF1 RID: 36593
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0403004F RID: 196687
		TitleItem,
		// Token: 0x04030050 RID: 196688
		TowerLayout,
		// Token: 0x04030051 RID: 196689
		RewardBtn,
		// Token: 0x04030052 RID: 196690
		ChangeTowerBtn,
		// Token: 0x04030053 RID: 196691
		LowRiskToggle,
		// Token: 0x04030054 RID: 196692
		HighRiskToggle,
		// Token: 0x04030055 RID: 196693
		RedDotItem,
		// Token: 0x04030056 RID: 196694
		LowFinishItem,
		// Token: 0x04030057 RID: 196695
		HighFinishItem,
		// Token: 0x04030058 RID: 196696
		RewardProgressSprite,
		// Token: 0x04030059 RID: 196697
		ShopBtn,
		// Token: 0x0403005A RID: 196698
		LowRiskRedDotItem,
		// Token: 0x0403005B RID: 196699
		HighRiskRedDotItem,
		// Token: 0x0403005C RID: 196700
		VariationRiskRedDotItem,
		// Token: 0x0403005D RID: 196701
		RewardShowItem,
		// Token: 0x0403005E RID: 196702
		RewardDownItem,
		// Token: 0x0403005F RID: 196703
		RewardDownBgItem,
		// Token: 0x04030060 RID: 196704
		RedTowerItem,
		// Token: 0x04030061 RID: 196705
		OverLockToggle,
		// Token: 0x04030062 RID: 196706
		WhiteTowerItem,
		// Token: 0x04030063 RID: 196707
		OverLockFinishItem,
		// Token: 0x04030064 RID: 196708
		OverLockTipsItem,
		// Token: 0x04030065 RID: 196709
		OverLockRedDotItem
	}
}
