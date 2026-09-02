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
	// Token: 0x02005F2A RID: 24362
	[NullableContext(2)]
	[Nullable(0)]
	public class FlagChallengeTempExpView : BattleVisibleChildView
	{
		// Token: 0x0603D2E5 RID: 250597 RVA: 0x00F8C5A0 File Offset: 0x00F8A7A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D2E6 RID: 250598 RVA: 0x00F8C66C File Offset: 0x00F8A86C
		protected override UniTask OnCreateAsync()
		{
			FlagChallengeTempExpView.<OnCreateAsync>d__20 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<FlagChallengeTempExpView.<OnCreateAsync>d__20>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D2E7 RID: 250599 RVA: 0x00F8C6B0 File Offset: 0x00F8A8B0
		protected override void OnStart()
		{
			base.InitChildType(EBattleUiChild.RoleState);
			this.AddEvents();
			this.MaxLevel = ModelBase<FlagChallengeBattleModel>.Instance.GetTempFlagChallengeMaxLevel();
			this.ExpItemTweenInterval = Math.Max(20, ConfigBase<FlagChallengeConfig>.Instance.GetTempExpItemInterval());
			this.CrossLevelDiff = ConfigBase<FlagChallengeConfig>.Instance.GetTempExpCrossLevel();
			this.LevelText = base.GetArtText(0);
			this.ItemPanel = base.GetItem(2);
			this.LevelMaxSprite = base.GetSprite(1);
			UUISprite levelMaxSprite = this.LevelMaxSprite;
			if (levelMaxSprite != null)
			{
				levelMaxSprite.SetUIActive(false);
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.LevelAnimItem = base.GetItem(4);
			UUIItem levelAnimItem = this.LevelAnimItem;
			if (levelAnimItem != null)
			{
				levelAnimItem.SetUIActive(false);
			}
			FRotator frotator = new FRotator(0f, 180f, 0f);
			for (int i = 0; i < this.ExpItems.Count; i++)
			{
				FlagChallengeTempExpItem flagChallengeTempExpItem = this.ExpItems[i];
				flagChallengeTempExpItem.SetIndex(i);
				if (i % 2 == 1)
				{
					flagChallengeTempExpItem.GetRootItem().SetUIRelativeRotation(frotator);
				}
				flagChallengeTempExpItem.GetRootItem().SetUIParent(this.ItemPanel, false);
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
		}

		// Token: 0x0603D2E8 RID: 250600 RVA: 0x00F8C7FC File Offset: 0x00F8A9FC
		protected override void OnBeforeDestroy()
		{
			foreach (FlagChallengeTempExpItem flagChallengeTempExpItem in this.ExpItems)
			{
				flagChallengeTempExpItem.Clean();
			}
			this.ExpItems.Clear();
			base.OnBeforeDestroy();
		}

		// Token: 0x0603D2E9 RID: 250601 RVA: 0x00F8C860 File Offset: 0x00F8AA60
		public override void Reset()
		{
			this.RemoveEvents();
			base.Reset();
		}

		// Token: 0x0603D2EA RID: 250602 RVA: 0x00F8C870 File Offset: 0x00F8AA70
		private UniTask AddExpItem()
		{
			FlagChallengeTempExpView.<AddExpItem>d__24 <AddExpItem>d__;
			<AddExpItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AddExpItem>d__.<>4__this = this;
			<AddExpItem>d__.<>1__state = -1;
			<AddExpItem>d__.<>t__builder.Start<FlagChallengeTempExpView.<AddExpItem>d__24>(ref <AddExpItem>d__);
			return <AddExpItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D2EB RID: 250603 RVA: 0x00F8C8B3 File Offset: 0x00F8AAB3
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnFlagChallengeTempExpChanged, new Action<int, int, int, int>(this.OnFlagChallengeTempExpChanged));
		}

		// Token: 0x0603D2EC RID: 250604 RVA: 0x00F8C8D1 File Offset: 0x00F8AAD1
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeTempExpChanged, new Action<int, int, int, int>(this.OnFlagChallengeTempExpChanged));
		}

		// Token: 0x0603D2ED RID: 250605 RVA: 0x00F8C8EF File Offset: 0x00F8AAEF
		protected override void OnShowBattleChildView()
		{
			this.RefreshFlagChallengeInfo();
		}

		// Token: 0x0603D2EE RID: 250606 RVA: 0x00F8C8F7 File Offset: 0x00F8AAF7
		protected override void OnHideBattleChildView()
		{
			this.StopCurrentState();
			this.AnimState = FlagChallengeTempExpView.EAnimState.None;
		}

		// Token: 0x0603D2EF RID: 250607 RVA: 0x00F8C908 File Offset: 0x00F8AB08
		private void RefreshFlagChallengeInfo()
		{
			FlagChallengeBattleModel instance = ModelBase<FlagChallengeBattleModel>.Instance;
			this.CurrentLevel = instance.GetTempLevel();
			this.TargetLevel = this.CurrentLevel;
			this.TargetExpProgress = instance.GetTempExpProgress();
			this.MaxLevel = instance.GetTempFlagChallengeMaxLevel();
			this.ResetAllItem(this.TargetExpProgress, null);
			this.RefreshTempLevelText(this.TargetLevel);
			bool uiactive = this.TargetLevel == this.MaxLevel;
			UUIItem levelAnimItem = this.LevelAnimItem;
			if (levelAnimItem != null)
			{
				levelAnimItem.SetUIActive(uiactive);
			}
			UUISprite levelMaxSprite = this.LevelMaxSprite;
			if (levelMaxSprite == null)
			{
				return;
			}
			levelMaxSprite.SetUIActive(uiactive);
		}

		// Token: 0x0603D2F0 RID: 250608 RVA: 0x00F8C9A0 File Offset: 0x00F8ABA0
		private void RefreshTempLevelText(int tempLevel)
		{
			int num = ModelBase<FlagChallengeBattleModel>.Instance.GetCalculatedLevel() + tempLevel;
			UUIArtText levelText = this.LevelText;
			if (levelText == null)
			{
				return;
			}
			levelText.SetText(num.ToString());
		}

		// Token: 0x0603D2F1 RID: 250609 RVA: 0x00F8C9D4 File Offset: 0x00F8ABD4
		private void OnFlagChallengeTempExpChanged(int oldExp, int newExp, int oldLevel, int newLevel)
		{
			if (!base.GetVisible())
			{
				return;
			}
			if (oldExp == newExp && oldLevel == newLevel)
			{
				return;
			}
			FlagChallengeBattleModel instance = ModelBase<FlagChallengeBattleModel>.Instance;
			if (newLevel == oldLevel)
			{
				this.IsAddProgress = (newExp > oldExp);
			}
			else
			{
				this.IsAddProgress = (newLevel > oldLevel);
				this.MaxLevel = instance.GetTempFlagChallengeMaxLevel();
			}
			if (this.IsAddProgress)
			{
				bool flag = false;
				if (this.AnimState != FlagChallengeTempExpView.EAnimState.CrossLevel && newLevel - oldLevel >= this.CrossLevelDiff)
				{
					flag = true;
				}
				if (this.AnimState == FlagChallengeTempExpView.EAnimState.None && !flag)
				{
					ref ValueTuple<int, int> tempLevelExpRange = instance.GetTempLevelExpRange(oldLevel);
					int tempLevelUpExp = instance.GetTempLevelUpExp(new int?(oldLevel));
					int item = tempLevelExpRange.Item1;
					float progress = (float)(oldExp - item) / (float)tempLevelUpExp;
					this.TargetExpProgress = instance.GetTempExpProgress();
					this.CurrentLevel = oldLevel;
					this.TargetLevel = newLevel;
					this.RefreshTempLevelText(oldLevel);
					this.ResetAllItem(progress, null);
					this.PlayTweenByNextItem(true);
					return;
				}
				if (this.AnimState == FlagChallengeTempExpView.EAnimState.CrossLevel || flag)
				{
					this.TargetExpProgress = instance.GetTempExpProgress();
					this.CurrentLevel = newLevel;
					this.TargetLevel = newLevel;
					if (flag)
					{
						this.PlayCrossLevelAnim();
						return;
					}
				}
				else
				{
					if (this.AnimState == FlagChallengeTempExpView.EAnimState.StepByStep)
					{
						this.TargetExpProgress = instance.GetTempExpProgress();
						this.TargetLevel = newLevel;
						return;
					}
					if (this.AnimState == FlagChallengeTempExpView.EAnimState.ReduceLevel || this.AnimState == FlagChallengeTempExpView.EAnimState.ReduceExp)
					{
						this.TargetExpProgress = instance.GetTempExpProgress();
						this.TargetLevel = newLevel;
						this.IsPendingPlayNext = true;
						return;
					}
				}
			}
			else
			{
				this.TargetExpProgress = instance.GetTempExpProgress();
				this.CurrentLevel = newLevel;
				this.TargetLevel = newLevel;
				this.ResetAllItem(this.TargetExpProgress, new EFlagChallengeExpItemTweenAnimType?(EFlagChallengeExpItemTweenAnimType.Red));
				this.RefreshTempLevelText(newLevel);
				if (oldLevel == newLevel)
				{
					this.PlayReduceExpAnim();
					return;
				}
				this.PlayReduceLevelAnim();
			}
		}

		// Token: 0x0603D2F2 RID: 250610 RVA: 0x00F8CB7C File Offset: 0x00F8AD7C
		[NullableContext(1)]
		private void OnSequenceEndEvent(string sequenceName)
		{
			if (sequenceName == "YJ" && this.AnimState == FlagChallengeTempExpView.EAnimState.CrossLevel)
			{
				this.AnimState = FlagChallengeTempExpView.EAnimState.None;
				this.PlayLevelUpAnim();
				this.ResetAllItem(this.TargetExpProgress, null);
				this.RefreshTempLevelText(this.TargetLevel);
				UUIItem levelAnimItem = this.LevelAnimItem;
				if (levelAnimItem != null)
				{
					levelAnimItem.SetUIActive(false);
				}
				if (this.TargetLevel == this.MaxLevel)
				{
					this.PlayMaxLevelAnim();
					return;
				}
			}
			else if ((sequenceName == "Decline" && this.AnimState == FlagChallengeTempExpView.EAnimState.ReduceLevel) || (sequenceName == "Decline01" && this.AnimState == FlagChallengeTempExpView.EAnimState.ReduceExp))
			{
				this.AnimState = FlagChallengeTempExpView.EAnimState.None;
				if (this.IsPendingPlayNext)
				{
					this.PlayTweenByNextItem(false);
					this.IsPendingPlayNext = false;
				}
			}
		}

		// Token: 0x0603D2F3 RID: 250611 RVA: 0x00F8CC40 File Offset: 0x00F8AE40
		private void PlayLevelUpAnim()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlaySequencePurely("Up", false, false, null, null, false);
		}

		// Token: 0x0603D2F4 RID: 250612 RVA: 0x00F8CC70 File Offset: 0x00F8AE70
		private void PlayCrossLevelAnim()
		{
			this.StopCurrentState();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("YJ", false, false, null, null, false);
			}
			UUIItem levelAnimItem = this.LevelAnimItem;
			if (levelAnimItem != null)
			{
				levelAnimItem.SetUIActive(true);
			}
			this.AnimState = FlagChallengeTempExpView.EAnimState.CrossLevel;
		}

		// Token: 0x0603D2F5 RID: 250613 RVA: 0x00F8CCC0 File Offset: 0x00F8AEC0
		private void PlayReduceExpAnim()
		{
			this.StopCurrentState();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("Decline01", false, false, null, null, false);
			}
			UUIItem itemPanel = this.ItemPanel;
			if (itemPanel != null)
			{
				itemPanel.SetUIActive(true);
			}
			UUIItem levelAnimItem = this.LevelAnimItem;
			if (levelAnimItem != null)
			{
				levelAnimItem.SetUIActive(false);
			}
			UUISprite levelMaxSprite = this.LevelMaxSprite;
			if (levelMaxSprite != null)
			{
				levelMaxSprite.SetUIActive(false);
			}
			this.AnimState = FlagChallengeTempExpView.EAnimState.ReduceExp;
		}

		// Token: 0x0603D2F6 RID: 250614 RVA: 0x00F8CD34 File Offset: 0x00F8AF34
		private void PlayReduceLevelAnim()
		{
			this.StopCurrentState();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("Decline", false, false, null, null, false);
			}
			UUIItem itemPanel = this.ItemPanel;
			if (itemPanel != null)
			{
				itemPanel.SetUIActive(true);
			}
			UUIItem levelAnimItem = this.LevelAnimItem;
			if (levelAnimItem != null)
			{
				levelAnimItem.SetUIActive(false);
			}
			UUISprite levelMaxSprite = this.LevelMaxSprite;
			if (levelMaxSprite != null)
			{
				levelMaxSprite.SetUIActive(false);
			}
			this.AnimState = FlagChallengeTempExpView.EAnimState.ReduceLevel;
		}

		// Token: 0x0603D2F7 RID: 250615 RVA: 0x00F8CDA8 File Offset: 0x00F8AFA8
		private void PlayMaxLevelAnim()
		{
			this.StopCurrentState();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("MaxStart", false, false, null, null, false);
			}
			UUIItem levelAnimItem = this.LevelAnimItem;
			if (levelAnimItem != null)
			{
				levelAnimItem.SetUIActive(true);
			}
			UUISprite levelMaxSprite = this.LevelMaxSprite;
			if (levelMaxSprite != null)
			{
				levelMaxSprite.SetUIActive(true);
			}
			this.AnimState = FlagChallengeTempExpView.EAnimState.MaxLevel;
		}

		// Token: 0x0603D2F8 RID: 250616 RVA: 0x00F8CE0C File Offset: 0x00F8B00C
		private void StopCurrentState()
		{
			switch (this.AnimState)
			{
			case FlagChallengeTempExpView.EAnimState.CrossLevel:
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null && levelSequencePlayer.IsPlayingSequence("YJ"))
				{
					LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
					if (levelSequencePlayer2 == null)
					{
						return;
					}
					levelSequencePlayer2.StopSequenceByKey("YJ", false, true);
					return;
				}
				break;
			}
			case FlagChallengeTempExpView.EAnimState.ReduceExp:
			{
				LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
				if (levelSequencePlayer3 != null && levelSequencePlayer3.IsPlayingSequence("Decline01"))
				{
					LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
					if (levelSequencePlayer4 == null)
					{
						return;
					}
					levelSequencePlayer4.StopSequenceByKey("Decline01", false, true);
					return;
				}
				break;
			}
			case FlagChallengeTempExpView.EAnimState.ReduceLevel:
			{
				LevelSequencePlayer levelSequencePlayer5 = this.LevelSequencePlayer;
				if (levelSequencePlayer5 != null && levelSequencePlayer5.IsPlayingSequence("Decline"))
				{
					LevelSequencePlayer levelSequencePlayer6 = this.LevelSequencePlayer;
					if (levelSequencePlayer6 == null)
					{
						return;
					}
					levelSequencePlayer6.StopSequenceByKey("Decline", false, true);
					return;
				}
				break;
			}
			case FlagChallengeTempExpView.EAnimState.MaxLevel:
			{
				LevelSequencePlayer levelSequencePlayer7 = this.LevelSequencePlayer;
				if (levelSequencePlayer7 != null && levelSequencePlayer7.IsPlayingSequence("MaxStart"))
				{
					LevelSequencePlayer levelSequencePlayer8 = this.LevelSequencePlayer;
					if (levelSequencePlayer8 != null)
					{
						levelSequencePlayer8.StopSequenceByKey("MaxStart", false, true);
					}
				}
				AUIBaseActor rootActor = this.RootActor;
				if (rootActor == null)
				{
					return;
				}
				rootActor.StopSequenceByKey("MaxLoop");
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0603D2F9 RID: 250617 RVA: 0x00F8CF18 File Offset: 0x00F8B118
		private void ResetAllItem(float progress, EFlagChallengeExpItemTweenAnimType? playTween = null)
		{
			this.CurrentItemIndex = -1;
			foreach (FlagChallengeTempExpItem flagChallengeTempExpItem in this.ExpItems)
			{
				flagChallengeTempExpItem.Reset();
				if (flagChallengeTempExpItem.IsShowItem(progress))
				{
					this.CurrentItemIndex = flagChallengeTempExpItem.GetIndex();
					flagChallengeTempExpItem.ShowItem();
					if (playTween != null)
					{
						flagChallengeTempExpItem.PlayTweenAnim(playTween.Value);
					}
				}
				else
				{
					flagChallengeTempExpItem.HideItem(true);
				}
			}
		}

		// Token: 0x0603D2FA RID: 250618 RVA: 0x00F8CFAC File Offset: 0x00F8B1AC
		private void PlayTweenByNextItem(bool needOffset = false)
		{
			int num = this.IsAddProgress ? (this.CurrentItemIndex + 1) : (this.CurrentItemIndex - 1);
			if (needOffset && !this.IsAddProgress)
			{
				num++;
			}
			if (num >= 10)
			{
				if (this.CurrentLevel != this.TargetLevel)
				{
					this.CurrentLevel++;
					this.RefreshTempLevelText(this.CurrentLevel);
					this.ResetAllItem(0f, null);
					this.PlayLevelUpAnim();
					if (this.CurrentLevel == this.MaxLevel)
					{
						this.PlayMaxLevelAnim();
						return;
					}
					this.PlayTweenByNextItem(false);
					return;
				}
				else
				{
					if (this.CurrentLevel == this.MaxLevel - 1 && this.TargetExpProgress == 1f)
					{
						this.PlayMaxLevelAnim();
						return;
					}
					this.AnimState = FlagChallengeTempExpView.EAnimState.None;
					return;
				}
			}
			else if (num < 0)
			{
				if (this.CurrentLevel != this.TargetLevel)
				{
					this.CurrentLevel--;
					this.RefreshTempLevelText(this.CurrentLevel);
					this.ResetAllItem(1f, null);
					this.PlayTweenByNextItem(true);
					return;
				}
				this.AnimState = FlagChallengeTempExpView.EAnimState.None;
				return;
			}
			else
			{
				FlagChallengeTempExpItem flagChallengeTempExpItem = this.ExpItems[num];
				float progress = this.TargetExpProgress;
				if (this.CurrentLevel < this.TargetLevel)
				{
					progress = 1f;
				}
				else if (this.CurrentLevel > this.TargetLevel)
				{
					progress = 0f;
				}
				if (!this.IsAddProgress)
				{
					if (flagChallengeTempExpItem.IsHideItem(progress))
					{
						this.CurrentItemIndex = num;
						flagChallengeTempExpItem.HideItem(true);
						this.DelayPlayNextTween();
					}
					return;
				}
				if (flagChallengeTempExpItem.IsShowItem(progress))
				{
					this.CurrentItemIndex = num;
					flagChallengeTempExpItem.ShowItem();
					flagChallengeTempExpItem.PlayTweenIn();
					this.DelayPlayNextTween();
					this.AnimState = FlagChallengeTempExpView.EAnimState.StepByStep;
					return;
				}
				this.AnimState = FlagChallengeTempExpView.EAnimState.None;
				return;
			}
		}

		// Token: 0x0603D2FB RID: 250619 RVA: 0x00F8D15B File Offset: 0x00F8B35B
		private void DelayPlayNextTween()
		{
			this.StopPlayNextTween();
			this.TweenAnimTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.TweenAnimTimer = null;
				this.PlayTweenByNextItem(false);
			}, (float)Math.Max(20, this.ExpItemTweenInterval), null, null, true, 1f);
		}

		// Token: 0x0603D2FC RID: 250620 RVA: 0x00F8D195 File Offset: 0x00F8B395
		private void StopPlayNextTween()
		{
			if (this.TweenAnimTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TweenAnimTimer);
			}
			this.TweenAnimTimer = null;
		}

		// Token: 0x0603D2FD RID: 250621 RVA: 0x00F8D1B7 File Offset: 0x00F8B3B7
		public override void ShowBattleVisibleChildView(bool checkVisible = false)
		{
			base.ShowBattleVisibleChildView(checkVisible);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnMoraleTempExpViewVisibleChanged, true);
		}

		// Token: 0x0603D2FE RID: 250622 RVA: 0x00F8D1D1 File Offset: 0x00F8B3D1
		public override void HideBattleVisibleChildView()
		{
			base.HideBattleVisibleChildView();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnMoraleTempExpViewVisibleChanged, false);
		}

		// Token: 0x040224EA RID: 140522
		private UUIArtText LevelText;

		// Token: 0x040224EB RID: 140523
		private UUIItem ItemPanel;

		// Token: 0x040224EC RID: 140524
		private UUISprite LevelMaxSprite;

		// Token: 0x040224ED RID: 140525
		private UUIItem LevelAnimItem;

		// Token: 0x040224EE RID: 140526
		[Nullable(1)]
		private readonly List<FlagChallengeTempExpItem> ExpItems = new List<FlagChallengeTempExpItem>();

		// Token: 0x040224EF RID: 140527
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040224F0 RID: 140528
		private int CurrentLevel;

		// Token: 0x040224F1 RID: 140529
		private int TargetLevel;

		// Token: 0x040224F2 RID: 140530
		private int MaxLevel;

		// Token: 0x040224F3 RID: 140531
		private float TargetExpProgress;

		// Token: 0x040224F4 RID: 140532
		private bool IsAddProgress;

		// Token: 0x040224F5 RID: 140533
		private int CurrentItemIndex = -1;

		// Token: 0x040224F6 RID: 140534
		private TimerHandle TweenAnimTimer;

		// Token: 0x040224F7 RID: 140535
		private FlagChallengeTempExpView.EAnimState AnimState;

		// Token: 0x040224F8 RID: 140536
		private bool IsPendingPlayNext;

		// Token: 0x040224F9 RID: 140537
		private int ExpItemTweenInterval = 20;

		// Token: 0x040224FA RID: 140538
		private int CrossLevelDiff = 3;

		// Token: 0x0200BF3A RID: 48954
		[NullableContext(0)]
		private enum EAnimState
		{
			// Token: 0x0403ADCA RID: 241098
			None,
			// Token: 0x0403ADCB RID: 241099
			StepByStep,
			// Token: 0x0403ADCC RID: 241100
			CrossLevel,
			// Token: 0x0403ADCD RID: 241101
			ReduceExp,
			// Token: 0x0403ADCE RID: 241102
			ReduceLevel,
			// Token: 0x0403ADCF RID: 241103
			MaxLevel
		}

		// Token: 0x0200BF3B RID: 48955
		[NullableContext(0)]
		private enum EComponentType
		{
			// Token: 0x0403ADD1 RID: 241105
			LevelText,
			// Token: 0x0403ADD2 RID: 241106
			LevelMaxSprite,
			// Token: 0x0403ADD3 RID: 241107
			ItemPanel,
			// Token: 0x0403ADD4 RID: 241108
			UnitItem,
			// Token: 0x0403ADD5 RID: 241109
			LevelAnimItem
		}
	}
}
