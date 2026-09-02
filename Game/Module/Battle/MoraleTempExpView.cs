using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F3B RID: 24379
	[NullableContext(2)]
	[Nullable(0)]
	public class MoraleTempExpView : BattleVisibleChildView
	{
		// Token: 0x0603D3FF RID: 250879 RVA: 0x00F93868 File Offset: 0x00F91A68
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

		// Token: 0x0603D400 RID: 250880 RVA: 0x00F93934 File Offset: 0x00F91B34
		protected override UniTask OnCreateAsync()
		{
			MoraleTempExpView.<OnCreateAsync>d__25 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<MoraleTempExpView.<OnCreateAsync>d__25>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D401 RID: 250881 RVA: 0x00F93978 File Offset: 0x00F91B78
		protected override void OnStart()
		{
			base.OnStart();
			base.InitChildType(EBattleUiChild.RoleState);
			this.AddEvents();
			this.MaxLevel = ModelBase<MoraleBattleModel>.Instance.GetTempMoraleMaxLevel();
			this.ExpUnitTweenInterval = Math.Max(20, ConfigCommonParamById.GetIntConfig("MoraleTempExpUnitInterval").GetValueOrDefault(20));
			this.CrossLevelDiff = ConfigCommonParamById.GetIntConfig("MoraleTempExpCrossLevel").GetValueOrDefault(3);
			this.LevelText = base.GetArtText(0);
			this.UnitPanel = base.GetItem(2);
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
			for (int i = 0; i < this.ExpUnits.Count; i++)
			{
				MoraleTempExpUnit moraleTempExpUnit = this.ExpUnits[i];
				moraleTempExpUnit.SetIndex(i);
				if (i % 2 == 1)
				{
					moraleTempExpUnit.GetRootItem().SetUIRelativeRotation(frotator);
				}
				moraleTempExpUnit.GetRootItem().SetUIParent(this.UnitPanel, false);
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
		}

		// Token: 0x0603D402 RID: 250882 RVA: 0x00F93ADC File Offset: 0x00F91CDC
		protected override void OnBeforeDestroy()
		{
			foreach (MoraleTempExpUnit moraleTempExpUnit in this.ExpUnits)
			{
				moraleTempExpUnit.Clean();
			}
			this.ExpUnits.Clear();
			base.OnBeforeDestroy();
		}

		// Token: 0x0603D403 RID: 250883 RVA: 0x00F93B40 File Offset: 0x00F91D40
		public override void Reset()
		{
			this.RemoveEvents();
			base.Reset();
		}

		// Token: 0x0603D404 RID: 250884 RVA: 0x00F93B50 File Offset: 0x00F91D50
		private UniTask AddExpUnit()
		{
			MoraleTempExpView.<AddExpUnit>d__29 <AddExpUnit>d__;
			<AddExpUnit>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AddExpUnit>d__.<>4__this = this;
			<AddExpUnit>d__.<>1__state = -1;
			<AddExpUnit>d__.<>t__builder.Start<MoraleTempExpView.<AddExpUnit>d__29>(ref <AddExpUnit>d__);
			return <AddExpUnit>d__.<>t__builder.Task;
		}

		// Token: 0x0603D405 RID: 250885 RVA: 0x00F93B93 File Offset: 0x00F91D93
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnMoraleTempExpChanged, new Action<int, int, int, int>(this.OnMoraleTempExpChanged));
		}

		// Token: 0x0603D406 RID: 250886 RVA: 0x00F93BB1 File Offset: 0x00F91DB1
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMoraleTempExpChanged, new Action<int, int, int, int>(this.OnMoraleTempExpChanged));
		}

		// Token: 0x0603D407 RID: 250887 RVA: 0x00F93BCF File Offset: 0x00F91DCF
		protected override void OnShowBattleChildView()
		{
			this.RefreshMoraleInfo();
		}

		// Token: 0x0603D408 RID: 250888 RVA: 0x00F93BD7 File Offset: 0x00F91DD7
		protected override void OnHideBattleChildView()
		{
			this.StopCurrentState();
			this.AnimState = MoraleTempExpView.EAnimState.None;
		}

		// Token: 0x0603D409 RID: 250889 RVA: 0x00F93BE8 File Offset: 0x00F91DE8
		private void RefreshMoraleInfo()
		{
			MoraleBattleModel instance = ModelBase<MoraleBattleModel>.Instance;
			this.CurrentLevel = instance.GetTempMoraleLevel();
			this.TargetLevel = this.CurrentLevel;
			this.TargetExpProgress = instance.GetTempMoraleExpProgress();
			this.MaxLevel = instance.GetTempMoraleMaxLevel();
			this.ResetAllUnit(this.TargetExpProgress, null);
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

		// Token: 0x0603D40A RID: 250890 RVA: 0x00F93C80 File Offset: 0x00F91E80
		private void RefreshTempLevelText(int tempLevel)
		{
			int num = ModelBase<MoraleBattleModel>.Instance.GetMoraleLevel() + tempLevel;
			UUIArtText levelText = this.LevelText;
			if (levelText == null)
			{
				return;
			}
			levelText.SetText(num.ToString());
		}

		// Token: 0x0603D40B RID: 250891 RVA: 0x00F93CB4 File Offset: 0x00F91EB4
		private void OnMoraleTempExpChanged(int oldExp, int newExp, int oldLevel, int newLevel)
		{
			if (!base.GetVisible())
			{
				return;
			}
			if (oldExp == newExp && oldLevel == newLevel)
			{
				return;
			}
			MoraleBattleModel instance = ModelBase<MoraleBattleModel>.Instance;
			if (newLevel == oldLevel)
			{
				this.IsAddProgress = (newExp > oldExp);
			}
			else
			{
				this.IsAddProgress = (newLevel > oldLevel);
				this.MaxLevel = instance.GetTempMoraleMaxLevel();
			}
			if (this.IsAddProgress)
			{
				bool flag = false;
				if (this.AnimState != MoraleTempExpView.EAnimState.CrossLevel && newLevel - oldLevel >= this.CrossLevelDiff)
				{
					flag = true;
				}
				if (this.AnimState == MoraleTempExpView.EAnimState.None && !flag)
				{
					ref ValueTuple<int, int> tempLevelExpRange = instance.GetTempLevelExpRange(oldLevel);
					int tempMoraleLevelUpExp = instance.GetTempMoraleLevelUpExp(new int?(oldLevel));
					int item = tempLevelExpRange.Item1;
					float progress = (float)(oldExp - item) / (float)tempMoraleLevelUpExp;
					this.TargetExpProgress = instance.GetTempMoraleExpProgress();
					this.CurrentLevel = oldLevel;
					this.TargetLevel = newLevel;
					this.RefreshTempLevelText(oldLevel);
					this.ResetAllUnit(progress, null);
					this.PlayTweenByNextUnit(true);
					return;
				}
				if (this.AnimState == MoraleTempExpView.EAnimState.CrossLevel || flag)
				{
					this.TargetExpProgress = instance.GetTempMoraleExpProgress();
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
					if (this.AnimState == MoraleTempExpView.EAnimState.StepByStep)
					{
						this.TargetExpProgress = instance.GetTempMoraleExpProgress();
						this.TargetLevel = newLevel;
						return;
					}
					if (this.AnimState == MoraleTempExpView.EAnimState.ReduceLevel || this.AnimState == MoraleTempExpView.EAnimState.ReduceExp)
					{
						this.TargetExpProgress = instance.GetTempMoraleExpProgress();
						this.TargetLevel = newLevel;
						this.IsPendingPlayNext = true;
						return;
					}
				}
			}
			else
			{
				this.TargetExpProgress = instance.GetTempMoraleExpProgress();
				this.CurrentLevel = newLevel;
				this.TargetLevel = newLevel;
				this.ResetAllUnit(this.TargetExpProgress, new MoraleTempExpView.ETweenAnimType?(MoraleTempExpView.ETweenAnimType.Red));
				this.RefreshTempLevelText(newLevel);
				if (oldLevel == newLevel)
				{
					this.PlayReduceExpAnim();
					return;
				}
				this.PlayReduceLevelAnim();
			}
		}

		// Token: 0x0603D40C RID: 250892 RVA: 0x00F93E5C File Offset: 0x00F9205C
		[NullableContext(1)]
		private void OnSequenceEndEvent(string sequenceName)
		{
			if (sequenceName == "YJ" && this.AnimState == MoraleTempExpView.EAnimState.CrossLevel)
			{
				this.AnimState = MoraleTempExpView.EAnimState.None;
				this.PlayLevelUpAnim();
				this.ResetAllUnit(this.TargetExpProgress, null);
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
			else if ((sequenceName == "Decline" && this.AnimState == MoraleTempExpView.EAnimState.ReduceLevel) || (sequenceName == "Decline01" && this.AnimState == MoraleTempExpView.EAnimState.ReduceExp))
			{
				this.AnimState = MoraleTempExpView.EAnimState.None;
				if (this.IsPendingPlayNext)
				{
					this.PlayTweenByNextUnit(false);
					this.IsPendingPlayNext = false;
				}
			}
		}

		// Token: 0x0603D40D RID: 250893 RVA: 0x00F93F20 File Offset: 0x00F92120
		private void PlayLevelUpAnim()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlaySequencePurely("Up", false, false, null, null, false);
		}

		// Token: 0x0603D40E RID: 250894 RVA: 0x00F93F50 File Offset: 0x00F92150
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
			this.AnimState = MoraleTempExpView.EAnimState.CrossLevel;
		}

		// Token: 0x0603D40F RID: 250895 RVA: 0x00F93FA0 File Offset: 0x00F921A0
		private void PlayReduceExpAnim()
		{
			this.StopCurrentState();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("Decline01", false, false, null, null, false);
			}
			UUIItem unitPanel = this.UnitPanel;
			if (unitPanel != null)
			{
				unitPanel.SetUIActive(true);
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
			this.AnimState = MoraleTempExpView.EAnimState.ReduceExp;
		}

		// Token: 0x0603D410 RID: 250896 RVA: 0x00F94014 File Offset: 0x00F92214
		private void PlayReduceLevelAnim()
		{
			this.StopCurrentState();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("Decline", false, false, null, null, false);
			}
			UUIItem unitPanel = this.UnitPanel;
			if (unitPanel != null)
			{
				unitPanel.SetUIActive(true);
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
			this.AnimState = MoraleTempExpView.EAnimState.ReduceLevel;
		}

		// Token: 0x0603D411 RID: 250897 RVA: 0x00F94088 File Offset: 0x00F92288
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
			this.AnimState = MoraleTempExpView.EAnimState.MaxLevel;
		}

		// Token: 0x0603D412 RID: 250898 RVA: 0x00F940EC File Offset: 0x00F922EC
		private void StopCurrentState()
		{
			switch (this.AnimState)
			{
			case MoraleTempExpView.EAnimState.CrossLevel:
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
			case MoraleTempExpView.EAnimState.ReduceExp:
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
			case MoraleTempExpView.EAnimState.ReduceLevel:
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
			case MoraleTempExpView.EAnimState.MaxLevel:
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

		// Token: 0x0603D413 RID: 250899 RVA: 0x00F941F8 File Offset: 0x00F923F8
		private void ResetAllUnit(float progress, MoraleTempExpView.ETweenAnimType? playTween = null)
		{
			this.CurrentUnitIndex = -1;
			foreach (MoraleTempExpUnit moraleTempExpUnit in this.ExpUnits)
			{
				moraleTempExpUnit.Reset();
				if (moraleTempExpUnit.IsShowUnit(progress))
				{
					this.CurrentUnitIndex = moraleTempExpUnit.Index;
					moraleTempExpUnit.ShowUnit();
					if (playTween != null)
					{
						moraleTempExpUnit.PlayTweenAnim(playTween.Value);
					}
				}
				else
				{
					moraleTempExpUnit.HideUnit(true);
				}
			}
		}

		// Token: 0x0603D414 RID: 250900 RVA: 0x00F9428C File Offset: 0x00F9248C
		private void PlayTweenByNextUnit(bool needOffset = false)
		{
			int num = this.IsAddProgress ? (this.CurrentUnitIndex + 1) : (this.CurrentUnitIndex - 1);
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
					this.ResetAllUnit(0f, null);
					this.PlayLevelUpAnim();
					if (this.CurrentLevel == this.MaxLevel)
					{
						this.PlayMaxLevelAnim();
						return;
					}
					this.PlayTweenByNextUnit(false);
					return;
				}
				else
				{
					if (this.CurrentLevel == this.MaxLevel - 1 && this.TargetExpProgress == 1f)
					{
						this.PlayMaxLevelAnim();
						return;
					}
					this.AnimState = MoraleTempExpView.EAnimState.None;
					return;
				}
			}
			else if (num < 0)
			{
				if (this.CurrentLevel != this.TargetLevel)
				{
					this.CurrentLevel--;
					this.RefreshTempLevelText(this.CurrentLevel);
					this.ResetAllUnit(1f, null);
					this.PlayTweenByNextUnit(true);
					return;
				}
				this.AnimState = MoraleTempExpView.EAnimState.None;
				return;
			}
			else
			{
				MoraleTempExpUnit moraleTempExpUnit = this.ExpUnits[num];
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
					if (moraleTempExpUnit.IsHideUnit(progress))
					{
						this.CurrentUnitIndex = num;
						moraleTempExpUnit.HideUnit(true);
						this.DelayPlayNextTween();
					}
					return;
				}
				if (moraleTempExpUnit.IsShowUnit(progress))
				{
					this.CurrentUnitIndex = num;
					moraleTempExpUnit.ShowUnit();
					moraleTempExpUnit.PlayTweenIn();
					this.DelayPlayNextTween();
					this.AnimState = MoraleTempExpView.EAnimState.StepByStep;
					return;
				}
				this.AnimState = MoraleTempExpView.EAnimState.None;
				return;
			}
		}

		// Token: 0x0603D415 RID: 250901 RVA: 0x00F9443B File Offset: 0x00F9263B
		private void DelayPlayNextTween()
		{
			this.StopPlayNextTween();
			this.TweenAnimTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.TweenAnimTimer = null;
				this.PlayTweenByNextUnit(false);
			}, (float)Math.Max(20, this.ExpUnitTweenInterval), null, null, true, 1f);
		}

		// Token: 0x0603D416 RID: 250902 RVA: 0x00F94475 File Offset: 0x00F92675
		private void StopPlayNextTween()
		{
			if (this.TweenAnimTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TweenAnimTimer);
			}
			this.TweenAnimTimer = null;
		}

		// Token: 0x0603D417 RID: 250903 RVA: 0x00F94497 File Offset: 0x00F92697
		public override void ShowBattleVisibleChildView(bool checkVisible = false)
		{
			base.ShowBattleVisibleChildView(checkVisible);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnMoraleTempExpViewVisibleChanged, true);
		}

		// Token: 0x0603D418 RID: 250904 RVA: 0x00F944B1 File Offset: 0x00F926B1
		public override void HideBattleVisibleChildView()
		{
			base.HideBattleVisibleChildView();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnMoraleTempExpViewVisibleChanged, false);
		}

		// Token: 0x040225A1 RID: 140705
		private const int EXP_UNIT_COUNT = 10;

		// Token: 0x040225A2 RID: 140706
		public const float EXP_PROGRESS_STEP = 0.1f;

		// Token: 0x040225A3 RID: 140707
		private const int EXP_UNIT_TWEEN_INTERVAL = 20;

		// Token: 0x040225A4 RID: 140708
		private const int CROSS_LEVEL_DIFF = 3;

		// Token: 0x040225A5 RID: 140709
		private UUIArtText LevelText;

		// Token: 0x040225A6 RID: 140710
		private UUIItem UnitPanel;

		// Token: 0x040225A7 RID: 140711
		private UUISprite LevelMaxSprite;

		// Token: 0x040225A8 RID: 140712
		private UUIItem LevelAnimItem;

		// Token: 0x040225A9 RID: 140713
		[Nullable(1)]
		private readonly List<MoraleTempExpUnit> ExpUnits = new List<MoraleTempExpUnit>();

		// Token: 0x040225AA RID: 140714
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040225AB RID: 140715
		private int CurrentLevel = 1;

		// Token: 0x040225AC RID: 140716
		private int TargetLevel = 1;

		// Token: 0x040225AD RID: 140717
		private int MaxLevel = 1;

		// Token: 0x040225AE RID: 140718
		private float TargetExpProgress;

		// Token: 0x040225AF RID: 140719
		private bool IsAddProgress = true;

		// Token: 0x040225B0 RID: 140720
		private int CurrentUnitIndex = -1;

		// Token: 0x040225B1 RID: 140721
		private TimerHandle TweenAnimTimer;

		// Token: 0x040225B2 RID: 140722
		private MoraleTempExpView.EAnimState AnimState;

		// Token: 0x040225B3 RID: 140723
		private bool IsPendingPlayNext;

		// Token: 0x040225B4 RID: 140724
		private int ExpUnitTweenInterval = 20;

		// Token: 0x040225B5 RID: 140725
		private int CrossLevelDiff = 3;

		// Token: 0x0200BF62 RID: 48994
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403AE88 RID: 241288
			LevelText,
			// Token: 0x0403AE89 RID: 241289
			LevelMaxSprite,
			// Token: 0x0403AE8A RID: 241290
			UnitPanel,
			// Token: 0x0403AE8B RID: 241291
			UnitItem,
			// Token: 0x0403AE8C RID: 241292
			LevelAnimItem
		}

		// Token: 0x0200BF63 RID: 48995
		[NullableContext(0)]
		private enum EAnimState
		{
			// Token: 0x0403AE8E RID: 241294
			None,
			// Token: 0x0403AE8F RID: 241295
			StepByStep,
			// Token: 0x0403AE90 RID: 241296
			CrossLevel,
			// Token: 0x0403AE91 RID: 241297
			ReduceExp,
			// Token: 0x0403AE92 RID: 241298
			ReduceLevel,
			// Token: 0x0403AE93 RID: 241299
			MaxLevel
		}

		// Token: 0x0200BF64 RID: 48996
		[NullableContext(0)]
		public enum ETweenAnimType
		{
			// Token: 0x0403AE95 RID: 241301
			In,
			// Token: 0x0403AE96 RID: 241302
			Out,
			// Token: 0x0403AE97 RID: 241303
			Break,
			// Token: 0x0403AE98 RID: 241304
			Red
		}
	}
}
