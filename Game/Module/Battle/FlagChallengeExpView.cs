using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.FlagChallenge;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F19 RID: 24345
	[NullableContext(2)]
	[Nullable(0)]
	public class FlagChallengeExpView : BattleVisibleChildView
	{
		// Token: 0x0603D25E RID: 250462 RVA: 0x00F893CC File Offset: 0x00F875CC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D25F RID: 250463 RVA: 0x00F895C8 File Offset: 0x00F877C8
		protected override UniTask OnBeforeStartAsync()
		{
			FlagChallengeExpView.<OnBeforeStartAsync>d__35 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FlagChallengeExpView.<OnBeforeStartAsync>d__35>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D260 RID: 250464 RVA: 0x00F8960C File Offset: 0x00F8780C
		protected override void OnStart()
		{
			this.AddExpBar = base.GetSprite(0);
			this.ChangeExpBar = base.GetSprite(1);
			this.LevelText = base.GetArtText(2);
			this.ExpValuePanel = base.GetItem(3);
			this.AddExpText = base.GetText(4);
			this.CurrentExpText = base.GetText(5);
			this.LevelMaxLightTexture = base.GetTexture(8);
			this.LevelMaxBgTexture = base.GetTexture(9);
			this.LevelMaxText = base.GetTexture(10);
			this.LevelBgSprite = base.GetSprite(12);
			this.DisableItem = base.GetItem(13);
			UUISprite addExpBar = this.AddExpBar;
			if (addExpBar != null)
			{
				addExpBar.SetFillAmount(0f);
			}
			UUISprite changeExpBar = this.ChangeExpBar;
			if (changeExpBar != null)
			{
				changeExpBar.SetFillAmount(0f);
			}
			UUIArtText levelText = this.LevelText;
			if (levelText != null)
			{
				levelText.SetText("1");
			}
			UUIItem expValuePanel = this.ExpValuePanel;
			if (expValuePanel != null)
			{
				expValuePanel.SetUIActive(false);
			}
			UUISprite changeExpBar2 = this.ChangeExpBar;
			if (changeExpBar2 != null)
			{
				changeExpBar2.SetUIActive(false);
			}
			FlagChallengeAnimItem flagChallengeAnimItem = this.FlagChallengeAnimItem;
			if (flagChallengeAnimItem != null)
			{
				flagChallengeAnimItem.SetUiActive(false);
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEnd), false);
		}

		// Token: 0x0603D261 RID: 250465 RVA: 0x00F89752 File Offset: 0x00F87952
		protected override void OnBeforeDestroy()
		{
			if (this.ExpTextTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.ExpTextTimer);
				this.ExpTextTimer = null;
			}
		}

		// Token: 0x0603D262 RID: 250466 RVA: 0x00F89774 File Offset: 0x00F87974
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.MiniMap);
			base.SetVisible(1, false);
			this.AddEvents();
		}

		// Token: 0x0603D263 RID: 250467 RVA: 0x00F89792 File Offset: 0x00F87992
		public override void Reset()
		{
			this.RemoveEvents();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.IsPendingChangeInfo = false;
			FlagChallengeAnimItem flagChallengeAnimItem = this.FlagChallengeAnimItem;
			if (flagChallengeAnimItem != null)
			{
				flagChallengeAnimItem.Clear();
			}
			base.Reset();
		}

		// Token: 0x0603D264 RID: 250468 RVA: 0x00F897CC File Offset: 0x00F879CC
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnFlagChallengeExpChanged, new Action<int, int, int, int>(this.OnFlagChallengeExpChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.LoadingViewOnAfterShow, new Action(this.OnRefreshPendingChangeInfo));
		}

		// Token: 0x0603D265 RID: 250469 RVA: 0x00F89830 File Offset: 0x00F87A30
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeExpChanged, new Action<int, int, int, int>(this.OnFlagChallengeExpChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.LoadingViewOnAfterShow, new Action(this.OnRefreshPendingChangeInfo));
		}

		// Token: 0x0603D266 RID: 250470 RVA: 0x00F89891 File Offset: 0x00F87A91
		[NullableContext(1)]
		private void OnSequenceEnd(string sequenceName)
		{
			if (sequenceName == "Close" && !ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
			{
				base.SetVisible(1, false);
			}
		}

		// Token: 0x0603D267 RID: 250471 RVA: 0x00F898B4 File Offset: 0x00F87AB4
		public void StartShow()
		{
			this.IsShowFlagChallengeUi = true;
			this.RefreshFlagChallengeInfo();
			base.SetVisible(1, true);
			this.PlayStartShowAnim();
			this.OnBattleStateChanged(ControllerBase<FormationDataController>.Instance.GlobalIsInFight);
		}

		// Token: 0x0603D268 RID: 250472 RVA: 0x00F898E1 File Offset: 0x00F87AE1
		public void EndShow()
		{
			this.IsShowFlagChallengeUi = false;
			this.PlayEndShowAnim();
		}

		// Token: 0x0603D269 RID: 250473 RVA: 0x00F898F0 File Offset: 0x00F87AF0
		private void PlayStartShowAnim()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlaySequencePurely("Start", false, false, null, null, false);
			}
			FlagChallengeAnimItem flagChallengeAnimItem = this.FlagChallengeAnimItem;
			if (flagChallengeAnimItem != null)
			{
				flagChallengeAnimItem.PlayStartShowAnim();
			}
			FlagChallengeAnimItem flagChallengeAnimItem2 = this.FlagChallengeAnimItem;
			if (flagChallengeAnimItem2 == null)
			{
				return;
			}
			flagChallengeAnimItem2.SetUiActive(true);
		}

		// Token: 0x0603D26A RID: 250474 RVA: 0x00F89958 File Offset: 0x00F87B58
		private void PlayEndShowAnim()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlaySequencePurely("Close", false, false, null, null, false);
			}
			FlagChallengeAnimItem flagChallengeAnimItem = this.FlagChallengeAnimItem;
			if (flagChallengeAnimItem != null)
			{
				flagChallengeAnimItem.PlayEndShowAnim();
			}
			FlagChallengeAnimItem flagChallengeAnimItem2 = this.FlagChallengeAnimItem;
			if (flagChallengeAnimItem2 == null)
			{
				return;
			}
			flagChallengeAnimItem2.SetUiActive(true);
		}

		// Token: 0x0603D26B RID: 250475 RVA: 0x00F899C0 File Offset: 0x00F87BC0
		private void PlayLevelUpAnim()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null && levelSequencePlayer.IsPlayingSequence("Up"))
			{
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.StopSequenceByKey("Up", false, true);
				}
			}
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 == null)
			{
				return;
			}
			levelSequencePlayer3.PlaySequencePurely("Up", false, false, null, null, false);
		}

		// Token: 0x0603D26C RID: 250476 RVA: 0x00F89A20 File Offset: 0x00F87C20
		public void Tick(float delta)
		{
			if (!base.GetVisible() || this.ProgressAnimSpeed == 0f)
			{
				this.IsPlaying = false;
				return;
			}
			this.IsPlaying = true;
			float num = delta * this.ProgressAnimSpeed;
			this.CurrentExpProgress += num;
			float num2 = 0f;
			if (this.CurrentLevel == this.TargetLevel)
			{
				num2 = this.TargetExpProgress;
				if (this.IsAddProgress)
				{
					this.CurrentExpProgress = Math.Min(this.TargetExpProgress, this.CurrentExpProgress);
				}
				else
				{
					this.CurrentExpProgress = Math.Max(this.TargetExpProgress, this.CurrentExpProgress);
				}
				if (this.CurrentExpProgress == this.TargetExpProgress)
				{
					num2 = 0f;
					this.ProgressAnimSpeed = 0f;
					this.DelayHideExpText();
				}
			}
			else
			{
				if (this.IsAddProgress)
				{
					num2 = 1f;
				}
				if (this.IsAddProgress && this.CurrentExpProgress > 1f)
				{
					int num3 = (int)Math.Floor((double)this.CurrentExpProgress);
					this.CurrentLevel = Math.Min(this.MaxLevel, Math.Min(this.TargetLevel, this.CurrentLevel + num3));
					UUIArtText levelText = this.LevelText;
					if (levelText != null)
					{
						levelText.SetText(this.CurrentLevel.ToString());
					}
					this.PlayLevelUpAnim();
					if (this.CurrentLevel == this.TargetLevel)
					{
						if (this.CurrentLevel == this.MaxLevel)
						{
							this.CurrentExpProgress = 1f;
							this.RefreshLevelMaxItem();
						}
						else
						{
							this.CurrentExpProgress = Math.Min(this.TargetExpProgress, this.CurrentExpProgress - 1f);
						}
					}
					else
					{
						this.CurrentExpProgress -= (float)num3;
					}
				}
				else if (!this.IsAddProgress && this.CurrentExpProgress < 0f)
				{
					int num4 = (int)Math.Abs(Math.Floor((double)this.CurrentExpProgress));
					this.CurrentLevel = Math.Min(this.MaxLevel, Math.Max(this.TargetLevel, this.CurrentLevel - num4));
					UUIArtText levelText2 = this.LevelText;
					if (levelText2 != null)
					{
						levelText2.SetText(this.CurrentLevel.ToString());
					}
					if (this.CurrentLevel == this.TargetLevel)
					{
						this.CurrentExpProgress = Math.Max(this.TargetExpProgress, this.CurrentExpProgress + 1f);
					}
					else
					{
						this.CurrentExpProgress += (float)num4;
					}
				}
				else if (!this.IsAddProgress && this.CurrentLevel == this.MaxLevel)
				{
					this.CurrentLevel = Math.Max(this.TargetLevel, this.CurrentLevel - 1);
					UUIArtText levelText3 = this.LevelText;
					if (levelText3 != null)
					{
						levelText3.SetText(this.CurrentLevel.ToString());
					}
					this.RefreshLevelMaxItem();
				}
			}
			float fillAmount = Singleton<MathUtils>.Instance.RangeClamp(this.CurrentExpProgress, 0f, 1f, 0f, 0.3f);
			UUISprite addExpBar = this.AddExpBar;
			if (addExpBar != null)
			{
				addExpBar.SetFillAmount(fillAmount);
			}
			if (num2 > 0f && this.IsAddProgress)
			{
				float fillAmount2 = Singleton<MathUtils>.Instance.RangeClamp(num2, 0f, 1f, 0f, 0.3f);
				UUISprite changeExpBar = this.ChangeExpBar;
				if (changeExpBar != null)
				{
					changeExpBar.SetFillAmount(fillAmount2);
				}
				UUISprite changeExpBar2 = this.ChangeExpBar;
				if (changeExpBar2 != null)
				{
					changeExpBar2.SetUIActive(true);
				}
			}
			else
			{
				UUISprite changeExpBar3 = this.ChangeExpBar;
				if (changeExpBar3 != null)
				{
					changeExpBar3.SetUIActive(false);
				}
			}
			int value = (this.CurrentLevel == this.MaxLevel) ? (this.CurrentLevel - 1) : this.CurrentLevel;
			int targetLevelUpExp = ModelBase<FlagChallengeModel>.Instance.GetTargetLevelUpExp(ModelBase<FlagChallengeBattleModel>.Instance.ActivityId, new int?(value));
			UUIText currentExpText = this.CurrentExpText;
			if (currentExpText == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
			defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Floor((double)((float)targetLevelUpExp * this.CurrentExpProgress)));
			defaultInterpolatedStringHandler.AppendLiteral(" / ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(targetLevelUpExp);
			currentExpText.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603D26D RID: 250477 RVA: 0x00F89DFC File Offset: 0x00F87FFC
		private void RefreshFlagChallengeInfo()
		{
			int activityId = ModelBase<FlagChallengeBattleModel>.Instance.ActivityId;
			int calculatedLevel = ModelBase<FlagChallengeModel>.Instance.GetCalculatedLevel(activityId);
			int calculatedLevelExp = ModelBase<FlagChallengeModel>.Instance.GetCalculatedLevelExp(activityId);
			float targetLevelExpProgress = ModelBase<FlagChallengeModel>.Instance.GetTargetLevelExpProgress(activityId, new int?(calculatedLevel), new int?(calculatedLevelExp));
			this.CurrentLevel = calculatedLevel;
			this.TargetLevel = calculatedLevel;
			UUIArtText levelText = this.LevelText;
			if (levelText != null)
			{
				levelText.SetText(calculatedLevel.ToString());
			}
			this.CurrentExpProgress = targetLevelExpProgress;
			float fillAmount = Singleton<MathUtils>.Instance.RangeClamp(targetLevelExpProgress, 0f, 1f, 0f, 0.3f);
			UUISprite addExpBar = this.AddExpBar;
			if (addExpBar != null)
			{
				addExpBar.SetFillAmount(fillAmount);
			}
			UUISprite changeExpBar = this.ChangeExpBar;
			if (changeExpBar != null)
			{
				changeExpBar.SetUIActive(false);
			}
			this.MaxLevel = ModelBase<FlagChallengeModel>.Instance.GetMaxLevel(activityId);
			this.RefreshLevelMaxItem();
		}

		// Token: 0x0603D26E RID: 250478 RVA: 0x00F89ED0 File Offset: 0x00F880D0
		private void OnFlagChallengeExpChanged(int oldExp, int newExp, int oldLevel, int newLevel)
		{
			if (!base.GetVisible())
			{
				return;
			}
			if (newLevel < oldLevel || newExp < oldExp)
			{
				this.IsPendingChangeInfo = true;
				return;
			}
			int num = this.IsPlaying ? this.CacheOldLevel : oldLevel;
			int num2 = this.IsPlaying ? this.CacheOldExp : oldExp;
			int num3 = newLevel - num;
			if (num3 != 0)
			{
				if (newLevel == this.MaxLevel)
				{
					num3--;
				}
				else if (num == this.MaxLevel)
				{
					num3++;
				}
			}
			int activityId = ModelBase<FlagChallengeBattleModel>.Instance.ActivityId;
			float targetLevelExpProgress = ModelBase<FlagChallengeModel>.Instance.GetTargetLevelExpProgress(activityId, new int?(newLevel), new int?(newExp));
			float num4 = (float)num3 + targetLevelExpProgress - this.CurrentExpProgress;
			this.ProgressAnimSpeed = num4 / 1000f;
			this.TargetLevel = newLevel;
			this.TargetExpProgress = targetLevelExpProgress;
			this.IsAddProgress = (this.ProgressAnimSpeed >= 0f);
			this.IsLevelUp = (newLevel > num);
			if (!this.IsPlaying)
			{
				this.CurrentLevel = oldLevel;
				int targetLevelUpExp = ModelBase<FlagChallengeModel>.Instance.GetTargetLevelUpExp(activityId, new int?(oldLevel));
				UUIText currentExpText = this.CurrentExpText;
				if (currentExpText != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(oldExp);
					defaultInterpolatedStringHandler.AppendLiteral(" / ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(targetLevelUpExp);
					currentExpText.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				}
				this.CacheOldLevel = oldLevel;
				this.CacheOldExp = oldExp;
			}
			int value = newExp - num2;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.AddExpText, "PrefabTextItem_147616326_Text", new <>z__ReadOnlySingleElementList<object>(Math.Abs(value)));
			UUIItem expValuePanel = this.ExpValuePanel;
			if (expValuePanel != null)
			{
				expValuePanel.SetUIActive(this.ProgressAnimSpeed != 0f);
			}
			FlagChallengeAnimItem flagChallengeAnimItem = this.FlagChallengeAnimItem;
			if (flagChallengeAnimItem == null)
			{
				return;
			}
			flagChallengeAnimItem.SetUiActive(false);
		}

		// Token: 0x0603D26F RID: 250479 RVA: 0x00F8A080 File Offset: 0x00F88280
		private void OnBattleStateChanged(bool isInBattleState)
		{
			if (!this.IsShowFlagChallengeUi)
			{
				return;
			}
			UUITexture levelMaxLightTexture = this.LevelMaxLightTexture;
			if (levelMaxLightTexture != null)
			{
				levelMaxLightTexture.SetUIActive(!isInBattleState);
			}
			UUISprite addExpBar = this.AddExpBar;
			if (addExpBar != null)
			{
				FColor? fcolor = new FColor?(this.AddExpBar.changeColor);
				addExpBar.SetChangeColor(isInBattleState, fcolor);
			}
			UUIArtText levelText = this.LevelText;
			if (levelText != null)
			{
				FColor? fcolor = new FColor?(this.LevelText.changeColor);
				levelText.SetChangeColor(isInBattleState, fcolor);
			}
			UUIArtText levelText2 = this.LevelText;
			if (levelText2 != null)
			{
				levelText2.SetUIActive(!isInBattleState);
			}
			UUITexture levelMaxBgTexture = this.LevelMaxBgTexture;
			if (levelMaxBgTexture != null)
			{
				FColor? fcolor = new FColor?(this.LevelMaxBgTexture.changeColor);
				levelMaxBgTexture.SetChangeColor(isInBattleState, fcolor);
			}
			UUITexture levelMaxText = this.LevelMaxText;
			if (levelMaxText != null)
			{
				FColor? fcolor = new FColor?(this.LevelMaxText.changeColor);
				levelMaxText.SetChangeColor(isInBattleState, fcolor);
			}
			UUISprite levelBgSprite = this.LevelBgSprite;
			if (levelBgSprite != null)
			{
				FColor? fcolor = new FColor?(this.LevelBgSprite.changeColor);
				levelBgSprite.SetChangeColor(isInBattleState, fcolor);
			}
			UUIItem disableItem = this.DisableItem;
			if (disableItem == null)
			{
				return;
			}
			disableItem.SetUIActive(isInBattleState);
		}

		// Token: 0x0603D270 RID: 250480 RVA: 0x00F8A18A File Offset: 0x00F8838A
		private void OnRefreshPendingChangeInfo()
		{
			if (this.IsPendingChangeInfo)
			{
				this.RefreshFlagChallengeInfo();
				this.IsPendingChangeInfo = false;
			}
		}

		// Token: 0x0603D271 RID: 250481 RVA: 0x00F8A1A4 File Offset: 0x00F883A4
		private void DelayHideExpText()
		{
			if (this.ExpTextTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.ExpTextTimer);
			}
			this.ExpTextTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				if (this.IsLevelUp)
				{
					FlagChallengeAnimItem flagChallengeAnimItem = this.FlagChallengeAnimItem;
					if (flagChallengeAnimItem != null)
					{
						flagChallengeAnimItem.PlayLevelUpAnim();
					}
					FlagChallengeAnimItem flagChallengeAnimItem2 = this.FlagChallengeAnimItem;
					if (flagChallengeAnimItem2 != null)
					{
						flagChallengeAnimItem2.SetUiActive(true);
					}
				}
				UUIItem expValuePanel = this.ExpValuePanel;
				if (expValuePanel != null)
				{
					expValuePanel.SetUIActive(false);
				}
				this.ExpTextTimer = null;
			}, 2000f, null, null, true, 1f);
		}

		// Token: 0x0603D272 RID: 250482 RVA: 0x00F8A1F3 File Offset: 0x00F883F3
		private void RefreshLevelMaxItem()
		{
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.CurrentLevel == this.MaxLevel);
		}

		// Token: 0x0603D273 RID: 250483 RVA: 0x00F8A214 File Offset: 0x00F88414
		[NullableContext(1)]
		public UUIItem GetLevelBgTextureItem()
		{
			return base.GetTexture(11);
		}

		// Token: 0x04022494 RID: 140436
		private const float UI_BAR_MIN_PERCENT = 0f;

		// Token: 0x04022495 RID: 140437
		private const float UI_BAR_MAX_PERCENT = 0.3f;

		// Token: 0x04022496 RID: 140438
		private const float PROGRESS_ANIM_DURATION = 1000f;

		// Token: 0x04022497 RID: 140439
		private const float EXP_TEXT_STAY_DURATION = 2000f;

		// Token: 0x04022498 RID: 140440
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat TickStatsObject = Stat.Create("[BattleView]FlagChallengeExpView", "", "");

		// Token: 0x04022499 RID: 140441
		private UUISprite AddExpBar;

		// Token: 0x0402249A RID: 140442
		private UUISprite ChangeExpBar;

		// Token: 0x0402249B RID: 140443
		private UUIArtText LevelText;

		// Token: 0x0402249C RID: 140444
		private UUIItem ExpValuePanel;

		// Token: 0x0402249D RID: 140445
		private UUIText AddExpText;

		// Token: 0x0402249E RID: 140446
		private UUIText CurrentExpText;

		// Token: 0x0402249F RID: 140447
		private UUITexture LevelMaxLightTexture;

		// Token: 0x040224A0 RID: 140448
		private UUITexture LevelMaxBgTexture;

		// Token: 0x040224A1 RID: 140449
		private UUITexture LevelMaxText;

		// Token: 0x040224A2 RID: 140450
		private UUISprite LevelBgSprite;

		// Token: 0x040224A3 RID: 140451
		private UUIItem DisableItem;

		// Token: 0x040224A4 RID: 140452
		private FlagChallengeAnimItem FlagChallengeAnimItem;

		// Token: 0x040224A5 RID: 140453
		private int CacheOldExp;

		// Token: 0x040224A6 RID: 140454
		private int CacheOldLevel;

		// Token: 0x040224A7 RID: 140455
		private bool IsPlaying;

		// Token: 0x040224A8 RID: 140456
		private int CurrentLevel;

		// Token: 0x040224A9 RID: 140457
		private float CurrentExpProgress;

		// Token: 0x040224AA RID: 140458
		private int TargetLevel;

		// Token: 0x040224AB RID: 140459
		private float TargetExpProgress;

		// Token: 0x040224AC RID: 140460
		private float ProgressAnimSpeed;

		// Token: 0x040224AD RID: 140461
		private bool IsAddProgress = true;

		// Token: 0x040224AE RID: 140462
		private bool IsLevelUp;

		// Token: 0x040224AF RID: 140463
		private int MaxLevel;

		// Token: 0x040224B0 RID: 140464
		private bool IsPendingChangeInfo;

		// Token: 0x040224B1 RID: 140465
		private bool IsShowFlagChallengeUi;

		// Token: 0x040224B2 RID: 140466
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040224B3 RID: 140467
		private TimerHandle ExpTextTimer;

		// Token: 0x0200BF1D RID: 48925
		[NullableContext(0)]
		private enum EVisibleReason
		{
			// Token: 0x0403AD30 RID: 240944
			Default = 1
		}

		// Token: 0x0200BF1E RID: 48926
		[NullableContext(0)]
		private enum EComponentType
		{
			// Token: 0x0403AD32 RID: 240946
			AddExpBar,
			// Token: 0x0403AD33 RID: 240947
			ChangeExpBar,
			// Token: 0x0403AD34 RID: 240948
			LevelText,
			// Token: 0x0403AD35 RID: 240949
			ExpValuePanel,
			// Token: 0x0403AD36 RID: 240950
			AddExpText,
			// Token: 0x0403AD37 RID: 240951
			CurrentExpText,
			// Token: 0x0403AD38 RID: 240952
			MoraleAnimItem,
			// Token: 0x0403AD39 RID: 240953
			LevelMaxItem,
			// Token: 0x0403AD3A RID: 240954
			LevelMaxLightTexture,
			// Token: 0x0403AD3B RID: 240955
			LevelMaxBgTexture,
			// Token: 0x0403AD3C RID: 240956
			LevelMaxText,
			// Token: 0x0403AD3D RID: 240957
			LevelBgTexture,
			// Token: 0x0403AD3E RID: 240958
			LevelBgSprite,
			// Token: 0x0403AD3F RID: 240959
			DisableItem
		}
	}
}
