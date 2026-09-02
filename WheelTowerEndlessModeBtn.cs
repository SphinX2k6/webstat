using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020016B3 RID: 5811
public class WheelTowerEndlessModeBtn : UiPanelBase
{
	// Token: 0x0600A1A6 RID: 41382 RVA: 0x002A7D38 File Offset: 0x002A5F38
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A1A7 RID: 41383 RVA: 0x002A7E84 File Offset: 0x002A6084
	public void Refresh()
	{
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		WheelTowerData activityData = instance.ActivityData;
		int totalScore = activityData.GetTotalScore(true);
		EScoreLevel totalScoreLevel = instance.GetTotalScoreLevel(totalScore, new bool?(true), null);
		NewTowerScoreLevel? scoreLevelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetScoreLevelConfigById((int)totalScoreLevel);
		if (scoreLevelConfigById != null)
		{
			base.SetTextureByPath(scoreLevelConfigById.Value.Icon, base.GetTexture(1), null, null);
			UUITexture texture = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetColor(FColor.FromHex(scoreLevelConfigById.Value.BgColor));
			}
		}
		bool flag = activityData.IsLevelUnlocked(true);
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 != null)
		{
			item2.SetUIActive(!flag);
		}
		UUIButtonComponent button = base.GetButton(0);
		if (button != null)
		{
			button.SetSelfInteractive(flag);
		}
		if (flag)
		{
			ValueTuple<int, int> bossProgress = instance.GetBossProgress(instance.GetMaxChallengeRound(new bool?(true)), new bool?(true));
			MonsterInfoPreview lastBossInfo = instance.GetLastBossInfo(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "WheelTower_Endless_CurProgress", new <>z__ReadOnlyArray<object>(new object[]
			{
				lastBossInfo.Round,
				bossProgress.Item1,
				bossProgress.Item2
			}));
		}
		NewTowerClimbingLevelRecord levelRecord = activityData.GetLevelRecord(true);
		NewTowerLevel? levelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(levelRecord.LevelId);
		if (levelConfigById != null)
		{
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(levelConfigById.Value.Cond);
			if (!string.IsNullOrEmpty(conditionGroupHintText))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), conditionGroupHintText, Array.Empty<object>());
			}
		}
	}

	// Token: 0x0600A1A8 RID: 41384 RVA: 0x002A803D File Offset: 0x002A623D
	private void OnButtonClick()
	{
		ModelBase<WheelTowerModel>.Instance.SetEndlessMode(true);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerModeDetailView, null, null);
	}
}
