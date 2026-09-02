using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001569 RID: 5481
public class ActivityRegressDoubleDropChallengeItem : UiPanelBase
{
	// Token: 0x17000D29 RID: 3369
	// (get) Token: 0x060099D0 RID: 39376 RVA: 0x00284407 File Offset: 0x00282607
	public EActivityRegressDoubleDropEntryType EntryType { get; }

	// Token: 0x060099D1 RID: 39377 RVA: 0x0028440F File Offset: 0x0028260F
	public ActivityRegressDoubleDropChallengeItem(EActivityRegressDoubleDropEntryType entryType)
	{
		this.EntryType = entryType;
	}

	// Token: 0x060099D2 RID: 39378 RVA: 0x00284420 File Offset: 0x00282620
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x060099D3 RID: 39379 RVA: 0x002844F4 File Offset: 0x002826F4
	protected override void OnStart()
	{
		base.OnStart();
		UUIItem item = base.GetItem(2);
		this.ConfirmButtonItem = new ButtonItem(item);
		this.ConfirmButtonItem.SetFunction(new Action<int>(this.OnConfirmBtnClick));
	}

	// Token: 0x060099D4 RID: 39380 RVA: 0x00284532 File Offset: 0x00282732
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		this.UpdateVisual();
	}

	// Token: 0x060099D5 RID: 39381 RVA: 0x00284540 File Offset: 0x00282740
	private void UpdateVisual()
	{
		this.UpdateUnlockState();
		this.UpdateRestTimes();
	}

	// Token: 0x060099D6 RID: 39382 RVA: 0x00284550 File Offset: 0x00282750
	private void UpdateUnlockState()
	{
		RegressDoubleDrop? doubleDropConfig = ConfigBase<ActivityRegressConfig>.Instance.GetDoubleDropConfig(ModelBase<ActivityRegressModel>.Instance.Grade);
		if (doubleDropConfig == null)
		{
			return;
		}
		RegressDoubleDrop value = doubleDropConfig.Value;
		bool flag = ModelBase<ActivityRegressModel>.Instance.ActivityData.IsDoubleDropUnlock(this.EntryType);
		string text = "";
		bool uiactive = false;
		if (this.EntryType == EActivityRegressDoubleDropEntryType.WorldBoss)
		{
			int bossUnLock = value.BossUnLock;
			ConditionGroup? conditionGroup = ConfigBase<ActivityRegressConfig>.Instance.GetConditionGroup(bossUnLock);
			text = (((conditionGroup != null) ? conditionGroup.GetValueOrDefault().HintText : null) ?? "");
			uiactive = ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByDungeonType(EDungeonType.Boss);
		}
		if (this.EntryType == EActivityRegressDoubleDropEntryType.WeeklyDungeon)
		{
			int weekUnLock = value.WeekUnLock;
			ConditionGroup? conditionGroup2 = ConfigBase<ActivityRegressConfig>.Instance.GetConditionGroup(weekUnLock);
			text = (((conditionGroup2 != null) ? conditionGroup2.GetValueOrDefault().HintText : null) ?? "");
			uiactive = ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByDungeonType(EDungeonType.Weekly);
		}
		if (!flag && !StringUtils.IsEmpty(text))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), text, Array.Empty<object>());
		}
		this.ConfirmButtonItem.SetUiActive(flag);
		base.GetItem(3).SetUIActive(!flag);
		base.GetItem(7).SetUIActive(uiactive);
	}

	// Token: 0x060099D7 RID: 39383 RVA: 0x00284698 File Offset: 0x00282898
	private void UpdateRestTimes()
	{
		bool flag = ModelBase<ActivityRegressModel>.Instance.ActivityData.IsDoubleDropUnlock(this.EntryType);
		int doubleDropRestTimes = ModelBase<ActivityRegressModel>.Instance.GetDoubleDropRestTimes(this.EntryType);
		int doubleDropMaxTimes = ModelBase<ActivityRegressModel>.Instance.GetDoubleDropMaxTimes(this.EntryType);
		UUIText text = base.GetText(6);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Recall_double_reward_tips", new <>z__ReadOnlyArray<object>(new object[]
		{
			flag ? doubleDropRestTimes : doubleDropMaxTimes,
			doubleDropMaxTimes
		}));
	}

	// Token: 0x060099D8 RID: 39384 RVA: 0x00284718 File Offset: 0x00282918
	private void OnConfirmBtnClick(int _)
	{
		ERegressGrade grade = ModelBase<ActivityRegressModel>.Instance.Grade;
		RegressDoubleDrop? doubleDropConfig = ConfigBase<ActivityRegressConfig>.Instance.GetDoubleDropConfig(grade);
		if (doubleDropConfig == null)
		{
			return;
		}
		RegressDoubleDrop value = doubleDropConfig.Value;
		if (this.EntryType == EActivityRegressDoubleDropEntryType.WorldBoss)
		{
			ActivityRegressHelper.ReportRecallLog1024New(EReportLogEventNewType.DoubleDrop, 0, 1);
			SkipTaskManager.RunByConfigId(value.WorldBossAccessPathId, null);
			return;
		}
		if (this.EntryType == EActivityRegressDoubleDropEntryType.WeeklyDungeon)
		{
			ActivityRegressHelper.ReportRecallLog1024New(EReportLogEventNewType.DoubleDrop, 0, 2);
			SkipTaskManager.RunByConfigId(value.WeekAccessPathId, null);
		}
	}

	// Token: 0x040046FD RID: 18173
	[Nullable(2)]
	private ButtonItem ConfirmButtonItem;

	// Token: 0x0200792D RID: 31021
	private class EActivityRegressDoubleDropChallengeItemComponents
	{
		// Token: 0x04029A31 RID: 170545
		public const int TxtName = 0;

		// Token: 0x04029A32 RID: 170546
		public const int TxtTips = 1;

		// Token: 0x04029A33 RID: 170547
		public const int BtnConfirmA = 2;

		// Token: 0x04029A34 RID: 170548
		public const int PnlLock = 3;

		// Token: 0x04029A35 RID: 170549
		public const int TxtLock = 4;

		// Token: 0x04029A36 RID: 170550
		public const int PnlTips = 5;

		// Token: 0x04029A37 RID: 170551
		public const int TxtNum = 6;

		// Token: 0x04029A38 RID: 170552
		public const int IsPreOpenItem = 7;
	}
}
