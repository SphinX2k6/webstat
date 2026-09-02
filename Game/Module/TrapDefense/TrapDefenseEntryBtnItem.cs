using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E0C RID: 19980
	public class TrapDefenseEntryBtnItem : UiPanelBase
	{
		// Token: 0x06033AAB RID: 211627 RVA: 0x00CE9587 File Offset: 0x00CE7787
		public TrapDefenseEntryBtnItem(ETrapDefenseLevelType mode)
		{
			this.Mode = mode;
		}

		// Token: 0x06033AAC RID: 211628 RVA: 0x00CE9598 File Offset: 0x00CE7798
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033AAD RID: 211629 RVA: 0x00CE976A File Offset: 0x00CE796A
		protected override void OnStart()
		{
			this.BindRedDot();
			this.RefreshByMode();
		}

		// Token: 0x06033AAE RID: 211630 RVA: 0x00CE9778 File Offset: 0x00CE7978
		protected override void OnBeforeDestroy()
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.TrapDefenseMainLevel);
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.TrapDefenseRougeLevel);
		}

		// Token: 0x06033AAF RID: 211631 RVA: 0x00CE9798 File Offset: 0x00CE7998
		public void RefreshUnlockTimer()
		{
			if (ModelBase<TrapDefenseModel>.Instance.RougeModeData.ModeIsOpen())
			{
				return;
			}
			double unlockRemainTime = ModelBase<TrapDefenseModel>.Instance.RougeModeData.GetUnlockRemainTime();
			string item = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(unlockRemainTime).CountDownText ?? "";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), ETrapDefenseTextKey.RogueUnlockCountDown.ToString(), new <>z__ReadOnlySingleElementList<object>(item));
		}

		// Token: 0x06033AB0 RID: 211632 RVA: 0x00CE9808 File Offset: 0x00CE7A08
		public void RefreshByMode()
		{
			if (this.Mode == ETrapDefenseLevelType.Mainline)
			{
				this.RefreshLevelMode();
				return;
			}
			if (this.Mode == ETrapDefenseLevelType.RougeNormal)
			{
				this.RefreshRogueMode();
			}
		}

		// Token: 0x06033AB1 RID: 211633 RVA: 0x00CE982C File Offset: 0x00CE7A2C
		private void RefreshLevelMode()
		{
			ValueTuple<int, int> modeStarProgress = ModelBase<TrapDefenseModel>.Instance.LevelModeData.GetModeStarProgress();
			int item = modeStarProgress.Item1;
			int item2 = modeStarProgress.Item2;
			UUIArtText artText = base.GetArtText(3);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(item);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
			artText.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
			TrapDefenseLevelData nextChallengeData = ModelBase<TrapDefenseModel>.Instance.LevelModeData.GetNextChallengeData();
			if (nextChallengeData != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), nextChallengeData.Config.Name, Array.Empty<object>());
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), nextChallengeData.GetDifficultyUiInfo().NameKey.ToString(), Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "", Array.Empty<object>());
			base.GetText(5).SetText("", true);
		}

		// Token: 0x06033AB2 RID: 211634 RVA: 0x00CE9918 File Offset: 0x00CE7B18
		private void RefreshRogueMode()
		{
			bool flag = ModelBase<TrapDefenseModel>.Instance.RougeModeData.ModeIsOpen();
			base.GetText(2).SetUIActive(flag);
			ValueTuple<int, int> modeStarProgress = ModelBase<TrapDefenseModel>.Instance.RougeModeData.GetModeStarProgress();
			int item = modeStarProgress.Item1;
			int item2 = modeStarProgress.Item2;
			UUIArtText artText = base.GetArtText(3);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(item);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
			artText.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
			int endlessPassedMaxWaveTimes = ModelBase<TrapDefenseModel>.Instance.RougeModeData.GetEndlessPassedMaxWaveTimes();
			base.GetText(4).SetUIActive(endlessPassedMaxWaveTimes > 0);
			base.GetText(5).SetUIActive(endlessPassedMaxWaveTimes > 0);
			if (endlessPassedMaxWaveTimes > 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), ETrapDefenseTextKey.EndlessRogueBestRecord.ToString(), Array.Empty<object>());
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), ETrapDefenseTextKey.EndlessRogueBestWaves.ToString(), new <>z__ReadOnlySingleElementList<object>(endlessPassedMaxWaveTimes));
			}
			bool flag2 = ModelBase<TrapDefenseModel>.Instance.RougeModeData.CanEnterRougeMode();
			base.GetItem(8).SetUIActive(flag && flag2);
			base.GetItem(9).SetUIActive(!flag || !flag2);
			this.RefreshUnlockTimer();
			if (!flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), ETrapDefenseTextKey.RogueUnlockTimeLimit.ToString(), Array.Empty<object>());
				return;
			}
			if (!flag2 && ModelBase<TrapDefenseModel>.Instance.RougeModeData.GetUnlockRemainTime() <= 0.0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), ETrapDefenseTextKey.RogueUnlockStageLimit.ToString(), Array.Empty<object>());
			}
		}

		// Token: 0x06033AB3 RID: 211635 RVA: 0x00CE9ACC File Offset: 0x00CE7CCC
		private void BindRedDot()
		{
			UUIItem item = base.GetItem(6);
			if (this.Mode == ETrapDefenseLevelType.Mainline)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.TrapDefenseMainLevel, item, null, 0);
				return;
			}
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.TrapDefenseRougeModeOpen, item, null, 0);
		}

		// Token: 0x06033AB4 RID: 211636 RVA: 0x00CE9B10 File Offset: 0x00CE7D10
		private void OnBtnClick()
		{
			if (this.Mode == ETrapDefenseLevelType.Mainline)
			{
				TrapDefenseLevelData nextChallengeData = ModelBase<TrapDefenseModel>.Instance.LevelModeData.GetNextChallengeData();
				TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
				int? id = (nextChallengeData != null) ? new int?(nextChallengeData.Id) : null;
				ETrapDefenseDifficultyLevel? difficulty2;
				if (nextChallengeData != null)
				{
					int difficulty = nextChallengeData.Config.Difficulty;
					difficulty2 = new ETrapDefenseDifficultyLevel?((ETrapDefenseDifficultyLevel)((nextChallengeData != null) ? new int?(nextChallengeData.Config.Difficulty) : null).Value);
				}
				else
				{
					difficulty2 = null;
				}
				instance.OpenViewMainLevelMode(id, difficulty2, null);
				return;
			}
			ModelBase<TrapDefenseModel>.Instance.OpenViewRougeLevelMode(null, null);
		}

		// Token: 0x0401DED5 RID: 122581
		public readonly ETrapDefenseLevelType Mode;

		// Token: 0x0200AD80 RID: 44416
		private class EComponentDefine
		{
			// Token: 0x04035E1F RID: 220703
			public const int BtnSelf = 0;

			// Token: 0x04035E20 RID: 220704
			public const int TextTitle = 1;

			// Token: 0x04035E21 RID: 220705
			public const int TextScoreLabel = 2;

			// Token: 0x04035E22 RID: 220706
			public const int ArtTextScore = 3;

			// Token: 0x04035E23 RID: 220707
			public const int TextLevelLabel = 4;

			// Token: 0x04035E24 RID: 220708
			public const int TextLevelProgress = 5;

			// Token: 0x04035E25 RID: 220709
			public const int ItemRedDot = 6;

			// Token: 0x04035E26 RID: 220710
			public const int TextLockTips = 7;

			// Token: 0x04035E27 RID: 220711
			public const int ItemUnlockPanel = 8;

			// Token: 0x04035E28 RID: 220712
			public const int ItemLockPanel = 9;

			// Token: 0x04035E29 RID: 220713
			public const int ItemLevelInfo = 10;
		}
	}
}
