using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x02001707 RID: 5895
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerTotalScoreSharePanel : UiPanelBase
{
	// Token: 0x0600A34F RID: 41807 RVA: 0x002B2570 File Offset: 0x002B0770
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A350 RID: 41808 RVA: 0x002B26C4 File Offset: 0x002B08C4
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerTotalScoreSharePanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerTotalScoreSharePanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A351 RID: 41809 RVA: 0x002B2707 File Offset: 0x002B0907
	private WheelTowerShareTeamItem CreateTeamItem()
	{
		return new WheelTowerShareTeamItem();
	}

	// Token: 0x0600A352 RID: 41810 RVA: 0x002B2710 File Offset: 0x002B0910
	private UniTask LoadSeasonBgItem()
	{
		WheelTowerTotalScoreSharePanel.<LoadSeasonBgItem>d__7 <LoadSeasonBgItem>d__;
		<LoadSeasonBgItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadSeasonBgItem>d__.<>4__this = this;
		<LoadSeasonBgItem>d__.<>1__state = -1;
		<LoadSeasonBgItem>d__.<>t__builder.Start<WheelTowerTotalScoreSharePanel.<LoadSeasonBgItem>d__7>(ref <LoadSeasonBgItem>d__);
		return <LoadSeasonBgItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600A353 RID: 41811 RVA: 0x002B2754 File Offset: 0x002B0954
	protected override void OnStart()
	{
		WheelTowerSeasonBgItem seasonBgItem = this.SeasonBgItem;
		if (seasonBgItem != null)
		{
			seasonBgItem.GetSequencePlayer().PlaySequence("Start", false, null);
		}
		int maxChallengeRound = ModelBase<WheelTowerModel>.Instance.GetMaxChallengeRound(null);
		ValueTuple<int, int> bossProgress = ModelBase<WheelTowerModel>.Instance.GetBossProgress(maxChallengeRound, null);
		int item = bossProgress.Item1;
		int item2 = bossProgress.Item2;
		MonsterInfoPreview bossInfoByRound = ModelBase<WheelTowerModel>.Instance.GetBossInfoByRound(maxChallengeRound, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "Share_NewTowerTotal_1002", new <>z__ReadOnlySingleElementList<object>(bossInfoByRound.Round));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Share_NewTowerTotal_1003", new <>z__ReadOnlyArray<object>(new object[]
		{
			item,
			item2
		}));
		int totalScore = ModelBase<WheelTowerModel>.Instance.GetTotalScore();
		UUIText text = base.GetText(4);
		if (text != null)
		{
			text.SetText(totalScore.ToString(), true);
		}
		RepeatedField<TeamChallengeInfo> teamChallengeInfos = ModelBase<WheelTowerModel>.Instance.GetCurrentLevelRecord(null).TeamChallengeInfos;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "Share_NewTowerTotal_1001", new <>z__ReadOnlySingleElementList<object>(teamChallengeInfos.Count.ToString()));
		List<TeamChallengeInfo> data = (from t in teamChallengeInfos
		orderby t.TeamScore descending
		select t).Take(this.SHARE_TEAM_MAX_NUM).ToList<TeamChallengeInfo>();
		GenericLayout<WheelTowerShareTeamItem, TeamChallengeInfo> teamScrollLayout = this.TeamScrollLayout;
		if (teamScrollLayout != null)
		{
			teamScrollLayout.RefreshByData(data, null, false);
		}
		int seasonId = ModelBase<WheelTowerModel>.Instance.ActivityData.SeasonId;
		if (seasonId != 0)
		{
			NewTowerSeason? seasonConfig = ConfigBase<WheelTowerConfig>.Instance.GetSeasonConfig(seasonId);
			base.SetTextureByPath(seasonConfig.Value.VersionIconMain, base.GetTexture(2), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), seasonConfig.Value.Name, Array.Empty<object>());
		}
		EScoreLevel totalScoreLevel = ModelBase<WheelTowerModel>.Instance.GetTotalScoreLevel(totalScore, null, null);
		base.SetTextureByPath(ConfigBase<WheelTowerConfig>.Instance.GetScoreLevelConfigById((int)totalScoreLevel).Value.Icon, base.GetTexture(3), null, null);
	}

	// Token: 0x0600A354 RID: 41812 RVA: 0x002B29B0 File Offset: 0x002B0BB0
	protected override void OnFinishShow()
	{
		WheelTowerSeasonBgItem seasonBgItem = this.SeasonBgItem;
		if (seasonBgItem == null)
		{
			return;
		}
		seasonBgItem.StopAllTweenAndSpine();
	}

	// Token: 0x0600A355 RID: 41813 RVA: 0x002B29C2 File Offset: 0x002B0BC2
	public AActor GetBlurOverrideActor()
	{
		AUIBaseActor rootActor = this.RootActor;
		return (((rootActor != null) ? rootActor.GetComponentByClass(TsUiBlur.StaticClass()) : null) as TsUiBlur).OverrideItem;
	}

	// Token: 0x04004DBE RID: 19902
	private int SHARE_TEAM_MAX_NUM = 5;

	// Token: 0x04004DBF RID: 19903
	public GenericLayout<WheelTowerShareTeamItem, TeamChallengeInfo> TeamScrollLayout;

	// Token: 0x04004DC0 RID: 19904
	private WheelTowerSeasonBgItem SeasonBgItem;

	// Token: 0x02007A53 RID: 31315
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x04029EFF RID: 171775
		BgItem,
		// Token: 0x04029F00 RID: 171776
		TextSeasonTitle,
		// Token: 0x04029F01 RID: 171777
		SeasonTexture,
		// Token: 0x04029F02 RID: 171778
		TextureScoreLevel,
		// Token: 0x04029F03 RID: 171779
		TextScore,
		// Token: 0x04029F04 RID: 171780
		TextBossTurn,
		// Token: 0x04029F05 RID: 171781
		TextBossProgress,
		// Token: 0x04029F06 RID: 171782
		ScrollViewTeam,
		// Token: 0x04029F07 RID: 171783
		ScrollViewTeamItem,
		// Token: 0x04029F08 RID: 171784
		TeamNum
	}
}
