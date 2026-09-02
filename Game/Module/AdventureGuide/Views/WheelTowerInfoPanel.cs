using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.AdventureGuide.Views
{
	// Token: 0x020061C2 RID: 25026
	public class WheelTowerInfoPanel : UiPanelBase
	{
		// Token: 0x0603F294 RID: 258708 RVA: 0x01036504 File Offset: 0x01034704
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F295 RID: 258709 RVA: 0x010365F4 File Offset: 0x010347F4
		public void Refresh(bool isEndless)
		{
			WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
			int totalScore = instance.ActivityData.GetTotalScore(isEndless);
			UUIText text = base.GetText(7);
			if (text != null)
			{
				text.SetText(totalScore.ToString(), true);
			}
			EScoreLevel totalScoreLevel = instance.GetTotalScoreLevel(totalScore, new bool?(isEndless), null);
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(totalScoreLevel > EScoreLevel.None);
			}
			NewTowerScoreLevel? scoreLevelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetScoreLevelConfigById((int)totalScoreLevel);
			if (totalScoreLevel > EScoreLevel.None && scoreLevelConfigById != null)
			{
				base.SetTextureByPath(scoreLevelConfigById.Value.Icon, base.GetTexture(2), null, null);
				UUITexture texture = base.GetTexture(1);
				if (texture != null)
				{
					texture.SetColor(FColor.FromHex(scoreLevelConfigById.Value.BgColor));
				}
			}
			bool flag = instance.ActivityData.IsLevelUnlocked(true);
			if (isEndless && !flag)
			{
				UUIText text2 = base.GetText(3);
				if (text2 != null)
				{
					text2.SetUIActive(false);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "WheelTower_Endless_NoRecord", Array.Empty<object>());
				return;
			}
			ValueTuple<int, int> bossProgress = instance.GetBossProgress(instance.GetMaxChallengeRound(new bool?(isEndless)), new bool?(isEndless));
			UUIText text3 = base.GetText(5);
			if (text3 != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
				defaultInterpolatedStringHandler.AppendLiteral("(");
				defaultInterpolatedStringHandler.AppendFormatted<int>(bossProgress.Item1);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(bossProgress.Item2);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			UUIText text4 = base.GetText(3);
			if (text4 != null)
			{
				text4.SetUIActive(isEndless);
			}
			if (isEndless)
			{
				MonsterInfoPreview lastBossInfo = instance.GetLastBossInfo(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "WheelTowerEndlessFinishedNum", new <>z__ReadOnlySingleElementList<object>(lastBossInfo.Round));
			}
		}
	}
}
