using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001767 RID: 5991
[NullableContext(2)]
[Nullable(0)]
public class PeriodicityChallengeTypeItem : GridProxyAbstract<EDungeonType>
{
	// Token: 0x0600A860 RID: 43104 RVA: 0x002CCF50 File Offset: 0x002CB150
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A861 RID: 43105 RVA: 0x002CD188 File Offset: 0x002CB388
	protected override void OnStart()
	{
		this.Toggle = base.GetExtendToggle(0);
		UUIExtendToggle toggle = this.Toggle;
		if (toggle != null)
		{
			toggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
		}
		base.GetItem(2).SetUIActive(false);
		base.GetItem(12).SetUIActive(false);
		base.GetText(10).SetUIActive(false);
		base.GetItem(11).SetUIActive(false);
	}

	// Token: 0x0600A862 RID: 43106 RVA: 0x002CD1FC File Offset: 0x002CB3FC
	[NullableContext(1)]
	public void BindOnToggleFunc(Action<int, UUIExtendToggle> toggleFunc)
	{
		this.ToggleFunc = delegate(int curId, UUIExtendToggle toggle)
		{
			toggleFunc(curId, toggle);
		};
	}

	// Token: 0x0600A863 RID: 43107 RVA: 0x002CD228 File Offset: 0x002CB428
	[NullableContext(1)]
	public void BindCanToggleExecuteChange(Func<int, bool> toggle)
	{
		this.OnCanToggleClicked = toggle;
	}

	// Token: 0x0600A864 RID: 43108 RVA: 0x002CD231 File Offset: 0x002CB431
	private bool CanToggleExecuteChange()
	{
		return this.OnCanToggleClicked == null || this.OnCanToggleClicked((int)this.TypeId);
	}

	// Token: 0x0600A865 RID: 43109 RVA: 0x002CD250 File Offset: 0x002CB450
	public override void Refresh(EDungeonType data, bool isSelected, int gridIndex)
	{
		this.TypeId = data;
		SecondaryGuideData value = ConfigBase<AdventureGuideConfig>.Instance.GetSecondaryGuideDataConf((int)this.TypeId).Value;
		UUIText text = base.GetText(4);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, value.Text, Array.Empty<object>());
		this.SetSpriteByPath(value.Icon, base.GetSprite(3), false, null, null);
		this.SetSpriteByPath(value.Icon, base.GetSprite(13), false, null, null);
		this.Toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.RefreshSubText();
		this.RefreshDoubleIcon();
	}

	// Token: 0x0600A866 RID: 43110 RVA: 0x002CD2F8 File Offset: 0x002CB4F8
	public void RefreshSubText()
	{
		IPeriodicityChallengeTypeData periodicityChallengeTypeData = null;
		if (this.TypeId == EDungeonType.Tower)
		{
			periodicityChallengeTypeData = this.GetTowerData();
		}
		else if (this.TypeId == EDungeonType.ShipTower)
		{
			periodicityChallengeTypeData = this.GetShipTowerData();
		}
		else if (this.TypeId == EDungeonType.WeeklyRogue)
		{
			periodicityChallengeTypeData = this.GetWeeklyRougeData();
		}
		else if (this.TypeId == EDungeonType.WheelTower)
		{
			periodicityChallengeTypeData = this.GetWheelTowerData();
		}
		if (periodicityChallengeTypeData == null)
		{
			return;
		}
		base.GetItem(7).SetUIActive(periodicityChallengeTypeData.IsFinish);
		base.GetItem(2).SetUIActive(periodicityChallengeTypeData.RedPoint);
		base.GetText(8).SetText(periodicityChallengeTypeData.SubText, true);
		SecondaryGuideData? secondaryGuideDataConf = ConfigBase<AdventureGuideConfig>.Instance.GetSecondaryGuideDataConf((int)this.TypeId);
		if (secondaryGuideDataConf != null && secondaryGuideDataConf.Value.TimeOutDay > 0 && this.IsTimeOutType())
		{
			bool uiactive = periodicityChallengeTypeData.LeftTime <= (float)(secondaryGuideDataConf.Value.TimeOutDay * Singleton<TimeUtil>.Instance.OneDaySeconds);
			base.GetItem(12).SetUIActive(uiactive);
		}
	}

	// Token: 0x0600A867 RID: 43111 RVA: 0x002CD3F4 File Offset: 0x002CB5F4
	private IPeriodicityChallengeTypeData GetTowerData()
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10055))
		{
			return null;
		}
		TowerModel instance = ModelBase<TowerModel>.Instance;
		double num = (double)((int)Singleton<MathUtils>.Instance.LongToNumber(instance.TowerEndTime.Value)) - Singleton<TimeUtil>.Instance.GetServerTime();
		int difficultyMaxStars = instance.GetDifficultyMaxStars(3, false);
		int difficultyAllStars = instance.GetDifficultyAllStars(3, false);
		float difficultyRewardProgress = instance.GetDifficultyRewardProgress(3);
		int maxDifficulty = ModelBase<TowerModel>.Instance.GetMaxDifficulty();
		string newTowerDifficultTitle = ConfigBase<TowerClimbConfig>.Instance.GetNewTowerDifficultTitle(maxDifficulty);
		return new PeriodicityChallengeTypeData
		{
			LeftTime = ((num > 0.0) ? ((float)num) : 0f),
			CurrentNum = difficultyMaxStars,
			TotalNum = difficultyAllStars,
			IsFinish = (difficultyRewardProgress == 1f),
			RedPoint = ModelBase<AdventureGuideModel>.Instance.GetPeriodicityRedDot(EPeriodicityChallengeType.TowerVariation, ModelBase<TowerModel>.Instance.CurrentSeason),
			SubText = newTowerDifficultTitle
		};
	}

	// Token: 0x0600A868 RID: 43112 RVA: 0x002CD4D4 File Offset: 0x002CB6D4
	private IPeriodicityChallengeTypeData GetShipTowerData()
	{
		ActivityShipTowerController instance = ControllerBase<ActivityShipTowerController>.Instance;
		ActivityShipTowerData activityShipTowerData = (instance != null) ? instance.Data : null;
		if (activityShipTowerData == null || !activityShipTowerData.IsUnLock())
		{
			return null;
		}
		ShipTowerModel instance2 = ModelBase<ShipTowerModel>.Instance;
		ValueTuple<int, int> endlessRewardProgressNumData = instance2.GetEndlessRewardProgressNumData();
		int item = endlessRewardProgressNumData.Item1;
		int item2 = endlessRewardProgressNumData.Item2;
		return new PeriodicityChallengeTypeData
		{
			LeftTime = (float)instance2.GetRemainTime(),
			CurrentNum = item,
			TotalNum = item2,
			IsFinish = (item == item2 && item != 0),
			RedPoint = ModelBase<AdventureGuideModel>.Instance.GetPeriodicityRedDot(EPeriodicityChallengeType.ShipTowerPeriodicity, ModelBase<ShipTowerModel>.Instance.CurSeason),
			SubText = instance2.GetCurrentStageSeasonName2()
		};
	}

	// Token: 0x0600A869 RID: 43113 RVA: 0x002CD574 File Offset: 0x002CB774
	private IPeriodicityChallengeTypeData GetWeeklyRougeData()
	{
		WeeklyRogueData activityDataNew = ModelBase<WeeklyRogueModel>.Instance.ActivityDataNew;
		if (activityDataNew == null || !activityDataNew.IsUnLock())
		{
			return null;
		}
		int score = activityDataNew.Score;
		RogueWeeklyCycle? cycleConfig = activityDataNew.GetCycleConfig();
		int totalNum = (cycleConfig != null) ? cycleConfig.GetValueOrDefault().MaxScore : 0;
		WeeklyRogueModel instance = ModelBase<WeeklyRogueModel>.Instance;
		WeeklyRogueData weeklyRogueData = (instance != null) ? instance.ActivityData : null;
		string text;
		if (weeklyRogueData == null)
		{
			text = null;
		}
		else
		{
			cycleConfig = weeklyRogueData.GetCycleConfig();
			text = ((cycleConfig != null) ? cycleConfig.GetValueOrDefault().CycleName : null);
		}
		string key = text ?? "";
		return new PeriodicityChallengeTypeData
		{
			LeftTime = (float)activityDataNew.GetCycleRemainTime(),
			CurrentNum = score,
			TotalNum = totalNum,
			IsFinish = activityDataNew.IsScoreRewardAllReceive(),
			RedPoint = ModelBase<AdventureGuideModel>.Instance.GetPeriodicityRedDot(EPeriodicityChallengeType.WeeklyRogue, ModelBase<WeeklyRogueModel>.Instance.CycleId),
			SubText = (ConfigBase<TextConfig>.Instance.GetMultiTextByKey(key) ?? "")
		};
	}

	// Token: 0x0600A86A RID: 43114 RVA: 0x002CD66C File Offset: 0x002CB86C
	private IPeriodicityChallengeTypeData GetWheelTowerData()
	{
		WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
		if (activityData == null || !activityData.IsUnLock() || !activityData.IsInCycle())
		{
			return null;
		}
		string key = activityData.IsLevelUnlocked(true) ? "WheelTowerModeTitle_Endless" : "WheelTowerModeTitle_Normal";
		return new PeriodicityChallengeTypeData
		{
			LeftTime = (float)activityData.GetCycleRemainTime(),
			CurrentNum = 0,
			TotalNum = 0,
			IsFinish = activityData.GetExDataFinishShowStateExternal(),
			RedPoint = activityData.CheckFirstOpenPage(),
			SubText = (ConfigBase<TextConfig>.Instance.GetMultiTextByKey(key) ?? "")
		};
	}

	// Token: 0x0600A86B RID: 43115 RVA: 0x002CD704 File Offset: 0x002CB904
	public void RefreshDoubleIcon()
	{
		object adventureUpActivity = ControllerBase<ActivityDoubleRewardController>.Instance.GetAdventureUpActivity(this.TypeId);
		bool flag = ModelBase<ActivityRegressModel>.Instance.IsHasDoubleDrop(this.TypeId);
		bool uiactive = adventureUpActivity != null || flag;
		base.GetItem(1).SetUIActive(uiactive);
	}

	// Token: 0x0600A86C RID: 43116 RVA: 0x002CD745 File Offset: 0x002CB945
	private void OnToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.ToggleFunc((int)this.TypeId, this.Toggle);
		}
	}

	// Token: 0x0600A86D RID: 43117 RVA: 0x002CD762 File Offset: 0x002CB962
	public override void OnSelected(bool bFireEvent)
	{
		if (bFireEvent)
		{
			this.SetSelectToggle(EToggleState.ETT_Checked);
		}
	}

	// Token: 0x0600A86E RID: 43118 RVA: 0x002CD76E File Offset: 0x002CB96E
	public void SetSelectToggle(EToggleState state = EToggleState.ETT_Checked)
	{
		base.GetExtendToggle(0).SetToggleStateForce(state, false, true, false);
		this.ToggleFunc((int)this.TypeId, this.Toggle);
	}

	// Token: 0x0600A86F RID: 43119 RVA: 0x002CD797 File Offset: 0x002CB997
	public void OnlySetSelectToggle(EToggleState state = EToggleState.ETT_Checked)
	{
		base.GetExtendToggle(0).SetToggleStateForce(state, false, true, false);
	}

	// Token: 0x0600A870 RID: 43120 RVA: 0x002CD7A9 File Offset: 0x002CB9A9
	public UUIExtendToggle GetSelfToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x0600A871 RID: 43121 RVA: 0x002CD7B4 File Offset: 0x002CB9B4
	public UUIItem GetButtonItem()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return null;
		}
		return extendToggle.RootUIComp.Get();
	}

	// Token: 0x0600A872 RID: 43122 RVA: 0x002CD7DB File Offset: 0x002CB9DB
	public bool IsTimeOutType()
	{
		return this.TypeId == EDungeonType.Tower || this.TypeId == EDungeonType.ShipTower || this.TypeId == EDungeonType.WeeklyRogue || this.TypeId == EDungeonType.WheelTower;
	}

	// Token: 0x04004F58 RID: 20312
	private EDungeonType TypeId = EDungeonType.Mat;

	// Token: 0x04004F59 RID: 20313
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, UUIExtendToggle> ToggleFunc;

	// Token: 0x04004F5A RID: 20314
	private Func<int, bool> OnCanToggleClicked;

	// Token: 0x04004F5B RID: 20315
	private UUIExtendToggle Toggle;

	// Token: 0x02007AC7 RID: 31431
	[NullableContext(0)]
	private enum ENodeDefine
	{
		// Token: 0x0402A0E1 RID: 172257
		Toggle,
		// Token: 0x0402A0E2 RID: 172258
		DoubleTip,
		// Token: 0x0402A0E3 RID: 172259
		RedDotItem,
		// Token: 0x0402A0E4 RID: 172260
		Icon,
		// Token: 0x0402A0E5 RID: 172261
		TypeText,
		// Token: 0x0402A0E6 RID: 172262
		SubItemA,
		// Token: 0x0402A0E7 RID: 172263
		DoingItem,
		// Token: 0x0402A0E8 RID: 172264
		FinishItem,
		// Token: 0x0402A0E9 RID: 172265
		SubText,
		// Token: 0x0402A0EA RID: 172266
		SubItemB,
		// Token: 0x0402A0EB RID: 172267
		SubItemBText,
		// Token: 0x0402A0EC RID: 172268
		SubItemBIconItem,
		// Token: 0x0402A0ED RID: 172269
		TimeOutItem,
		// Token: 0x0402A0EE RID: 172270
		SprIconR
	}
}
