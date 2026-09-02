using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D23 RID: 11555
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WeeklyChallengeItem : GridProxyAbstract<WeeklyChallengeTaskData>
{
	// Token: 0x06017525 RID: 95525 RVA: 0x00677570 File Offset: 0x00675770
	protected unsafe override void OnRegisterComponent()
	{
		int num = 16;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickGoToButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickHelpButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06017526 RID: 95526 RVA: 0x00677810 File Offset: 0x00675A10
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyChallengeItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyChallengeItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06017527 RID: 95527 RVA: 0x00677853 File Offset: 0x00675A53
	protected override void OnStart()
	{
		this.TagItemLayout = new GenericLayout<WeeklyChallengeTagItem, string>(base.GetHorizontalLayout(4), new Func<WeeklyChallengeTagItem>(this.CreateTagItem), null, false, true);
	}

	// Token: 0x06017528 RID: 95528 RVA: 0x00677876 File Offset: 0x00675A76
	private WeeklyChallengeTagItem CreateTagItem()
	{
		return new WeeklyChallengeTagItem();
	}

	// Token: 0x06017529 RID: 95529 RVA: 0x00677880 File Offset: 0x00675A80
	public override void Refresh(WeeklyChallengeTaskData data, bool isSelected, int gridIndex)
	{
		int configId = data.ConfigId;
		if (configId == 0)
		{
			base.GetItem(13).SetUIActive(true);
			base.GetItem(12).SetUIActive(false);
			return;
		}
		WeeklyFrameHelp? playConfigById = ConfigBase<WeeklyChallengeConfig>.Instance.GetPlayConfigById(configId);
		if (playConfigById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WeeklyChallenge;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "WeeklyChallengeItem Config not found";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", data.ConfigId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.ConfigData = new WeeklyFrameHelp?(playConfigById.Value);
		this.IsUnlocked = data.IsUnlocked;
		base.GetText(2).ShowTextNew(this.ConfigData.Value.Name);
		base.GetText(6).SetText(this.ConfigData.Value.Score.ToString(), true);
		base.GetText(7).ShowTextNew(this.ConfigData.Value.Time);
		base.SetTextureByPath(this.ConfigData.Value.BgPic, base.GetTexture(1), null, null);
		string[] array = this.ConfigData.Value.Tag();
		if (array != null && array.Length != 0)
		{
			this.TagItemLayout.RefreshByData(new List<string>(array), null, false);
		}
		base.GetItem(10).SetUIActive(!data.IsUnlocked);
		if (!data.IsUnlocked)
		{
			int unlockCondition = this.ConfigData.Value.UnlockCondition;
			ConditionGroup? conditionGroupConfig = ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(unlockCondition);
			if (conditionGroupConfig == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.WeeklyChallenge;
				ELogAuthor author2 = ELogAuthor.LRC;
				string message2 = "WeeklyChallengeItem ConditionInfo not found";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ConditionId", unlockCondition);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			else
			{
				FunctionalPanelConditionLock panelLock = this.PanelLock;
				if (panelLock != null)
				{
					panelLock.SetTextByTextId(conditionGroupConfig.Value.HintText, Array.Empty<string>());
				}
			}
		}
		FunctionalPanelConditionLock panelLock2 = this.PanelLock;
		if (panelLock2 != null)
		{
			panelLock2.SetUiActive(!data.IsUnlocked);
		}
		WeeklyPlayData weeklyPlayData = ModelBase<WeeklyChallengeModel>.Instance.GetWeeklyPlayData(configId);
		bool uiactive = weeklyPlayData != null && weeklyPlayData.HasRecord;
		base.GetItem(14).SetUIActive(uiactive);
		FColor color = FColor.FromHex(this.ConfigData.Value.ItemColor);
		base.GetSprite(15).SetColor(color);
		base.GetItem(12).SetUIActive(true);
		base.GetItem(13).SetUIActive(false);
	}

	// Token: 0x0601752A RID: 95530 RVA: 0x00677B0C File Offset: 0x00675D0C
	private void OnClickLockButton()
	{
		if (this.ConfigData == null)
		{
			return;
		}
		this.ReportRedClearEvent();
		ModelBase<DailyActivityModel>.Instance.MarkWeeklyPlayOpened();
		int unlockCondition = this.ConfigData.Value.UnlockCondition;
		Condition? conditionConfig = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(unlockCondition);
		int accessType = -1;
		if (conditionConfig != null && conditionConfig.GetValueOrDefault().AccessId > 0)
		{
			accessType = ConfigBase<GetWayConfig>.Instance.GetConfigById(conditionConfig.Value.AccessId).Value.SkipName;
		}
		bool isFinished = ControllerBase<LevelGeneralController>.Instance.CheckCondition(unlockCondition.ToString(), null, false, Array.Empty<object>());
		ActivityConditionData item = new ActivityConditionData
		{
			ConditionId = unlockCondition,
			ConditionTextId = ((conditionConfig != null) ? conditionConfig.GetValueOrDefault().Description : null),
			IsFinished = isFinished,
			AccessId = ((conditionConfig != null) ? conditionConfig.GetValueOrDefault().AccessId : 0),
			AccessType = accessType
		};
		List<IActivityConditionData> dataList = new List<IActivityConditionData>
		{
			item
		};
		ConditionGroupData param = new ConditionGroupData(unlockCondition, dataList, "", false);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonConditionView, param, null);
	}

	// Token: 0x0601752B RID: 95531 RVA: 0x00677C54 File Offset: 0x00675E54
	private void OnClickHelpButton()
	{
		if (this.ConfigData == null)
		{
			return;
		}
		ControllerBase<HelpController>.Instance.OpenHelpById(this.ConfigData.Value.HelpId);
	}

	// Token: 0x0601752C RID: 95532 RVA: 0x00677C8C File Offset: 0x00675E8C
	private void OnClickGoToButton()
	{
		if (this.ConfigData == null)
		{
			return;
		}
		this.ReportRedClearEvent();
		ModelBase<DailyActivityModel>.Instance.MarkWeeklyPlayOpened();
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("DungeonDetection", Array.Empty<object>());
			return;
		}
		WeeklyChallengeGoToClickLogData weeklyChallengeGoToClickLogData = new WeeklyChallengeGoToClickLogData();
		weeklyChallengeGoToClickLogData.i_activity_id = this.ConfigData.Value.Id;
		weeklyChallengeGoToClickLogData.i_activity_type = this.ConfigData.Value.ActivityType;
		weeklyChallengeGoToClickLogData.i_unlock = ((this.IsUnlocked > false) ? 1 : 0);
		ControllerBase<LogReportController>.Instance.LogReport(weeklyChallengeGoToClickLogData);
		SkipTaskManager.RunByConfigId(this.ConfigData.Value.AccessPathId, null);
	}

	// Token: 0x0601752D RID: 95533 RVA: 0x00677D44 File Offset: 0x00675F44
	private void ReportRedClearEvent()
	{
		int valueOrDefault = ModelBase<DailyActivityModel>.Instance.GetFirstOpenTabTime(DailyActivityDefine.EDailyActivityMainTab.Weekly).GetValueOrDefault();
		if ((int)ModelBase<WeeklyChallengeModel>.Instance.WeeklyEndTime != valueOrDefault)
		{
			WeeklyChallengeRedClearLogEvent weeklyChallengeRedClearLogEvent = new WeeklyChallengeRedClearLogEvent();
			weeklyChallengeRedClearLogEvent.i_season_id = ModelBase<WeeklyChallengeModel>.Instance.WeeklyConfigId;
			weeklyChallengeRedClearLogEvent.i_type = this.ConfigData.Value.Id;
			ControllerBase<LogReportController>.Instance.LogReport(weeklyChallengeRedClearLogEvent);
		}
	}

	// Token: 0x0400B32F RID: 45871
	private WeeklyFrameHelp? ConfigData;

	// Token: 0x0400B330 RID: 45872
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WeeklyChallengeTagItem, string> TagItemLayout;

	// Token: 0x0400B331 RID: 45873
	[Nullable(2)]
	private FunctionalPanelConditionLock PanelLock;

	// Token: 0x0400B332 RID: 45874
	private bool IsUnlocked;

	// Token: 0x02008FE8 RID: 36840
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x04030499 RID: 197785
		ClickButton,
		// Token: 0x0403049A RID: 197786
		IconTexture,
		// Token: 0x0403049B RID: 197787
		NameText,
		// Token: 0x0403049C RID: 197788
		HelpButton,
		// Token: 0x0403049D RID: 197789
		TagHorizontalLayout,
		// Token: 0x0403049E RID: 197790
		TagItem,
		// Token: 0x0403049F RID: 197791
		ScoreText,
		// Token: 0x040304A0 RID: 197792
		TimeText,
		// Token: 0x040304A1 RID: 197793
		GoToItem,
		// Token: 0x040304A2 RID: 197794
		GoToText,
		// Token: 0x040304A3 RID: 197795
		LockPanel,
		// Token: 0x040304A4 RID: 197796
		LockItem,
		// Token: 0x040304A5 RID: 197797
		InfoPanel,
		// Token: 0x040304A6 RID: 197798
		EmptyPanel,
		// Token: 0x040304A7 RID: 197799
		ArchiveItem,
		// Token: 0x040304A8 RID: 197800
		ColorSprite
	}
}
