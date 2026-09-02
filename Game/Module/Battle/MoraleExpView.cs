using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F35 RID: 24373
	[NullableContext(2)]
	[Nullable(0)]
	public class MoraleExpView : BattleVisibleChildView
	{
		// Token: 0x0603D3A7 RID: 250791 RVA: 0x00F91D3C File Offset: 0x00F8FF3C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D3A8 RID: 250792 RVA: 0x00F91F18 File Offset: 0x00F90118
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleExpView.<OnBeforeStartAsync>d__28 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleExpView.<OnBeforeStartAsync>d__28>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D3A9 RID: 250793 RVA: 0x00F91F5C File Offset: 0x00F9015C
		protected override void OnStart()
		{
			this.AddExpBar = base.GetSprite(0);
			this.ChangeExpBar = base.GetSprite(1);
			this.LevelText = base.GetArtText(2);
			this.ExpValuePanel = base.GetItem(3);
			this.AddExpText = base.GetText(4);
			this.CurrentExpText = base.GetText(5);
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
			MoraleAnimItem moraleAnimItem = this.MoraleAnimItem;
			if (moraleAnimItem != null)
			{
				moraleAnimItem.SetUiActive(false);
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEnd), false);
		}

		// Token: 0x0603D3AA RID: 250794 RVA: 0x00F9205D File Offset: 0x00F9025D
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.MiniMap);
			base.SetVisible(1, false);
			this.AddEvents();
		}

		// Token: 0x0603D3AB RID: 250795 RVA: 0x00F9207B File Offset: 0x00F9027B
		public override void Reset()
		{
			this.RemoveEvents();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.IsPendingChangeInfo = false;
			MoraleAnimItem moraleAnimItem = this.MoraleAnimItem;
			if (moraleAnimItem != null)
			{
				moraleAnimItem.Clear();
			}
			base.Reset();
		}

		// Token: 0x0603D3AC RID: 250796 RVA: 0x00F920B4 File Offset: 0x00F902B4
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnMoraleExpChanged, new Action<int, int, int, int>(this.OnMoraleExpChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMoralePromptShow, new Action(this.OnMoralePromptShow));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMoralePlayIndomitableLevelAnim, new Action(this.OnMoralePlayIndomitableLevelAnim));
			Singleton<EventSystem>.Instance.Add(EEventName.LoadingViewOnAfterShow, new Action(this.OnRefreshPendingChangeInfo));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMoraleBattleFail, new Action(this.OnMoraleBattleFail));
		}

		// Token: 0x0603D3AD RID: 250797 RVA: 0x00F9216C File Offset: 0x00F9036C
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMoraleExpChanged, new Action<int, int, int, int>(this.OnMoraleExpChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMoralePromptShow, new Action(this.OnMoralePromptShow));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMoralePlayIndomitableLevelAnim, new Action(this.OnMoralePlayIndomitableLevelAnim));
			Singleton<EventSystem>.Instance.Remove(EEventName.LoadingViewOnAfterShow, new Action(this.OnRefreshPendingChangeInfo));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMoraleBattleFail, new Action(this.OnMoraleBattleFail));
		}

		// Token: 0x0603D3AE RID: 250798 RVA: 0x00F92221 File Offset: 0x00F90421
		protected override void OnShowBattleChildView()
		{
			this.RefreshMoraleInfo();
		}

		// Token: 0x0603D3AF RID: 250799 RVA: 0x00F92229 File Offset: 0x00F90429
		[NullableContext(1)]
		private void OnSequenceEnd(string sequenceName)
		{
			if (sequenceName == "Close" && !ModelBase<MoraleBattleModel>.Instance.IsMoraleActive())
			{
				base.SetVisible(1, false);
			}
		}

		// Token: 0x0603D3B0 RID: 250800 RVA: 0x00F9224C File Offset: 0x00F9044C
		public void StartShow()
		{
			this.IsShowMoraleUi = true;
			this.RefreshMoraleInfo();
			base.SetVisible(1, true);
			this.PlayStartShowAnim();
			this.OnBattleStateChanged(ControllerBase<FormationDataController>.Instance.GlobalIsInFight);
		}

		// Token: 0x0603D3B1 RID: 250801 RVA: 0x00F92279 File Offset: 0x00F90479
		public void EndShow()
		{
			this.IsShowMoraleUi = false;
			this.PlayEndShowAnim();
		}

		// Token: 0x0603D3B2 RID: 250802 RVA: 0x00F92288 File Offset: 0x00F90488
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
			MoraleAnimItem moraleAnimItem = this.MoraleAnimItem;
			if (moraleAnimItem != null)
			{
				moraleAnimItem.PlayStartShowAnim();
			}
			MoraleAnimItem moraleAnimItem2 = this.MoraleAnimItem;
			if (moraleAnimItem2 == null)
			{
				return;
			}
			moraleAnimItem2.SetUiActive(true);
		}

		// Token: 0x0603D3B3 RID: 250803 RVA: 0x00F922F0 File Offset: 0x00F904F0
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
			MoraleAnimItem moraleAnimItem = this.MoraleAnimItem;
			if (moraleAnimItem != null)
			{
				moraleAnimItem.PlayEndShowAnim();
			}
			MoraleAnimItem moraleAnimItem2 = this.MoraleAnimItem;
			if (moraleAnimItem2 == null)
			{
				return;
			}
			moraleAnimItem2.SetUiActive(true);
		}

		// Token: 0x0603D3B4 RID: 250804 RVA: 0x00F92358 File Offset: 0x00F90558
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

		// Token: 0x0603D3B5 RID: 250805 RVA: 0x00F923B8 File Offset: 0x00F905B8
		public void Tick(float delta)
		{
			if (!base.GetVisible() || this.ProgressAnimSpeed == 0f)
			{
				return;
			}
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
			int moraleLevelUpExp = ModelBase<MoraleBattleModel>.Instance.GetMoraleLevelUpExp(new int?(value));
			UUIText currentExpText = this.CurrentExpText;
			if (currentExpText == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
			defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Floor((double)((float)moraleLevelUpExp * this.CurrentExpProgress)));
			defaultInterpolatedStringHandler.AppendLiteral(" / ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(moraleLevelUpExp);
			currentExpText.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603D3B6 RID: 250806 RVA: 0x00F9277C File Offset: 0x00F9097C
		private void RefreshMoraleInfo()
		{
			int num = ModelBase<MoraleBattleModel>.Instance.GetMoraleLevel();
			float num2 = ModelBase<MoraleBattleModel>.Instance.GetMoraleCurrentExpProgress();
			if (this.IsPendingChangeInfo && ModelBase<MoraleBattleModel>.Instance.GetMoraleIndomitableLevel() > 1)
			{
				num = 1;
				num2 = 0f;
			}
			this.CurrentLevel = num;
			this.TargetLevel = num;
			UUIArtText levelText = this.LevelText;
			if (levelText != null)
			{
				levelText.SetText(num.ToString());
			}
			this.CurrentExpProgress = num2;
			float fillAmount = Singleton<MathUtils>.Instance.RangeClamp(num2, 0f, 1f, 0f, 0.3f);
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
			this.MaxLevel = ModelBase<MoraleBattleModel>.Instance.GetMoraleMaxLevel();
			this.RefreshLevelMaxItem();
		}

		// Token: 0x0603D3B7 RID: 250807 RVA: 0x00F92848 File Offset: 0x00F90A48
		private void OnMoraleExpChanged(int oldExp, int newExp, int oldLevel, int newLevel)
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
			int num = newLevel - oldLevel;
			if (num != 0)
			{
				if (newLevel == this.MaxLevel)
				{
					num--;
				}
				else if (oldLevel == this.MaxLevel)
				{
					num++;
				}
			}
			float moraleCurrentExpProgress = ModelBase<MoraleBattleModel>.Instance.GetMoraleCurrentExpProgress();
			float num2 = (float)num + moraleCurrentExpProgress - this.CurrentExpProgress;
			this.ProgressAnimSpeed = num2 / 1000f;
			this.CurrentLevel = oldLevel;
			this.TargetLevel = newLevel;
			this.TargetExpProgress = moraleCurrentExpProgress;
			this.IsAddProgress = (this.ProgressAnimSpeed >= 0f);
			this.IsLevelUp = (newLevel > oldLevel && this.IsNeedLevelUpAnim);
			int moraleLevelUpExp = ModelBase<MoraleBattleModel>.Instance.GetMoraleLevelUpExp(new int?(oldLevel));
			UUIText currentExpText = this.CurrentExpText;
			if (currentExpText != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(oldExp);
				defaultInterpolatedStringHandler.AppendLiteral(" / ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(moraleLevelUpExp);
				currentExpText.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			int value = newExp - oldExp;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.AddExpText, "PrefabTextItem_147616326_Text", new <>z__ReadOnlySingleElementList<object>(Math.Abs(value)));
			UUIItem expValuePanel = this.ExpValuePanel;
			if (expValuePanel != null)
			{
				expValuePanel.SetUIActive(this.IsNeedLevelUpAnim && this.ProgressAnimSpeed != 0f);
			}
			MoraleAnimItem moraleAnimItem = this.MoraleAnimItem;
			if (moraleAnimItem == null)
			{
				return;
			}
			moraleAnimItem.SetUiActive(false);
		}

		// Token: 0x0603D3B8 RID: 250808 RVA: 0x00F929B0 File Offset: 0x00F90BB0
		private void OnBattleStateChanged(bool isInBattleState)
		{
			if (!this.IsShowMoraleUi)
			{
				return;
			}
			UUITexture texture = base.GetTexture(8);
			if (texture != null)
			{
				texture.SetUIActive(!isInBattleState);
			}
			UUISprite addExpBar = this.AddExpBar;
			FColor? fcolor;
			if (addExpBar != null)
			{
				fcolor = new FColor?(this.AddExpBar.changeColor);
				addExpBar.SetChangeColor(isInBattleState, fcolor);
			}
			UUIArtText levelText = this.LevelText;
			if (levelText != null)
			{
				fcolor = new FColor?(this.LevelText.changeColor);
				levelText.SetChangeColor(isInBattleState, fcolor);
			}
			UUITexture texture2 = base.GetTexture(9);
			if (texture2 != null)
			{
				fcolor = new FColor?(base.GetTexture(9).changeColor);
				texture2.SetChangeColor(isInBattleState, fcolor);
			}
			UUITexture texture3 = base.GetTexture(10);
			if (texture3 != null)
			{
				fcolor = new FColor?(base.GetTexture(10).changeColor);
				texture3.SetChangeColor(isInBattleState, fcolor);
			}
			UUITexture texture4 = base.GetTexture(11);
			if (texture4 != null)
			{
				fcolor = new FColor?(base.GetTexture(11).changeColor);
				texture4.SetChangeColor(isInBattleState, fcolor);
			}
			UUISprite sprite = base.GetSprite(12);
			if (sprite == null)
			{
				return;
			}
			fcolor = new FColor?(base.GetSprite(12).changeColor);
			sprite.SetChangeColor(isInBattleState, fcolor);
		}

		// Token: 0x0603D3B9 RID: 250809 RVA: 0x00F92AC9 File Offset: 0x00F90CC9
		private void OnMoralePromptShow()
		{
			this.PlayStartShowAnim();
		}

		// Token: 0x0603D3BA RID: 250810 RVA: 0x00F92AD1 File Offset: 0x00F90CD1
		private void OnRefreshPendingChangeInfo()
		{
			if (this.IsPendingChangeInfo)
			{
				this.RefreshMoraleInfo();
				this.IsPendingChangeInfo = false;
			}
		}

		// Token: 0x0603D3BB RID: 250811 RVA: 0x00F92AE8 File Offset: 0x00F90CE8
		private void OnMoraleBattleFail()
		{
			this.IsPendingChangeInfo = true;
		}

		// Token: 0x0603D3BC RID: 250812 RVA: 0x00F92AF4 File Offset: 0x00F90CF4
		private void OnMoralePlayIndomitableLevelAnim()
		{
			int moraleIndomitableLevel = ModelBase<MoraleBattleModel>.Instance.GetMoraleIndomitableLevel();
			if (moraleIndomitableLevel > 1 && this.TargetLevel < moraleIndomitableLevel)
			{
				this.IsNeedLevelUpAnim = false;
				this.OnMoraleExpChanged(0, 0, 1, moraleIndomitableLevel);
				this.IsNeedLevelUpAnim = true;
			}
		}

		// Token: 0x0603D3BD RID: 250813 RVA: 0x00F92B34 File Offset: 0x00F90D34
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
					MoraleAnimItem moraleAnimItem = this.MoraleAnimItem;
					if (moraleAnimItem != null)
					{
						moraleAnimItem.PlayLevelUpAnim();
					}
					MoraleAnimItem moraleAnimItem2 = this.MoraleAnimItem;
					if (moraleAnimItem2 != null)
					{
						moraleAnimItem2.SetUiActive(true);
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

		// Token: 0x0603D3BE RID: 250814 RVA: 0x00F92B83 File Offset: 0x00F90D83
		private void RefreshLevelMaxItem()
		{
			if (this.CurrentLevel == this.MaxLevel)
			{
				UUIItem item = base.GetItem(7);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(true);
				return;
			}
			else
			{
				UUIItem item2 = base.GetItem(7);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
		}

		// Token: 0x04022567 RID: 140647
		private const float UI_BAR_MIN_PERCENT = 0f;

		// Token: 0x04022568 RID: 140648
		private const float UI_BAR_MAX_PERCENT = 0.3f;

		// Token: 0x04022569 RID: 140649
		private const float PROGRESS_ANIM_DURATION = 1000f;

		// Token: 0x0402256A RID: 140650
		private const float EXP_TEXT_STAY_DURATION = 2000f;

		// Token: 0x0402256B RID: 140651
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat TickStatsObject = Stat.Create("[BattleView]MoraleExpView", "", "");

		// Token: 0x0402256C RID: 140652
		private UUISprite AddExpBar;

		// Token: 0x0402256D RID: 140653
		private UUISprite ChangeExpBar;

		// Token: 0x0402256E RID: 140654
		private UUIArtText LevelText;

		// Token: 0x0402256F RID: 140655
		private UUIItem ExpValuePanel;

		// Token: 0x04022570 RID: 140656
		private UUIText AddExpText;

		// Token: 0x04022571 RID: 140657
		private UUIText CurrentExpText;

		// Token: 0x04022572 RID: 140658
		private MoraleAnimItem MoraleAnimItem;

		// Token: 0x04022573 RID: 140659
		private int CurrentLevel;

		// Token: 0x04022574 RID: 140660
		private float CurrentExpProgress;

		// Token: 0x04022575 RID: 140661
		private int TargetLevel;

		// Token: 0x04022576 RID: 140662
		private float TargetExpProgress;

		// Token: 0x04022577 RID: 140663
		private float ProgressAnimSpeed;

		// Token: 0x04022578 RID: 140664
		private bool IsAddProgress = true;

		// Token: 0x04022579 RID: 140665
		private bool IsLevelUp;

		// Token: 0x0402257A RID: 140666
		private int MaxLevel;

		// Token: 0x0402257B RID: 140667
		private bool IsPendingChangeInfo;

		// Token: 0x0402257C RID: 140668
		private bool IsNeedLevelUpAnim = true;

		// Token: 0x0402257D RID: 140669
		private bool IsShowMoraleUi;

		// Token: 0x0402257E RID: 140670
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0402257F RID: 140671
		private TimerHandle ExpTextTimer;

		// Token: 0x0200BF57 RID: 48983
		[NullableContext(0)]
		private enum EVisibleReason
		{
			// Token: 0x0403AE56 RID: 241238
			Default = 1
		}

		// Token: 0x0200BF58 RID: 48984
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403AE58 RID: 241240
			AddExpBar,
			// Token: 0x0403AE59 RID: 241241
			ChangeExpBar,
			// Token: 0x0403AE5A RID: 241242
			LevelText,
			// Token: 0x0403AE5B RID: 241243
			ExpValuePanel,
			// Token: 0x0403AE5C RID: 241244
			AddExpText,
			// Token: 0x0403AE5D RID: 241245
			CurrentExpText,
			// Token: 0x0403AE5E RID: 241246
			MoraleAnimItem,
			// Token: 0x0403AE5F RID: 241247
			LevelMaxItem,
			// Token: 0x0403AE60 RID: 241248
			LevelMaxLightTexture,
			// Token: 0x0403AE61 RID: 241249
			LevelMaxBgTexture,
			// Token: 0x0403AE62 RID: 241250
			LevelMaxText,
			// Token: 0x0403AE63 RID: 241251
			LevelBgTexture,
			// Token: 0x0403AE64 RID: 241252
			LevelBgSprite
		}
	}
}
