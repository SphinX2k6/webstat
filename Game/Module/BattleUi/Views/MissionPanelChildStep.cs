using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200604F RID: 24655
	[NullableContext(1)]
	[Nullable(0)]
	public class MissionPanelChildStep : StepWithStatusItem, IStaticVariableResetter
	{
		// Token: 0x0603E322 RID: 254754 RVA: 0x00FE1608 File Offset: 0x00FDF808
		public MissionPanelChildStep(EMissionItemView viewId, int stepId) : base(viewId, stepId)
		{
		}

		// Token: 0x0603E323 RID: 254755 RVA: 0x00FE166B File Offset: 0x00FDF86B
		static MissionPanelChildStep()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(MissionPanelChildStep.CreateStaticDefaultValue), new Action(MissionPanelChildStep.ResetStaticDefaultValue));
		}

		// Token: 0x0603E324 RID: 254756 RVA: 0x00FE168A File Offset: 0x00FDF88A
		public static void CreateStaticDefaultValue()
		{
			MissionPanelChildStep.UnlockAnimEventPlayTag = 0;
		}

		// Token: 0x0603E325 RID: 254757 RVA: 0x00FE1692 File Offset: 0x00FDF892
		public static void ResetStaticDefaultValue()
		{
			MissionPanelChildStep.UnlockAnimEventPlayTag = 0;
		}

		// Token: 0x0603E326 RID: 254758 RVA: 0x00FE169C File Offset: 0x00FDF89C
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(6, typeof(UUISprite)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(7, typeof(UUIItem)));
		}

		// Token: 0x0603E327 RID: 254759 RVA: 0x00FE1700 File Offset: 0x00FDF900
		protected override UniTask OnBeforeStartAsync()
		{
			MissionPanelChildStep.<OnBeforeStartAsync>d__26 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MissionPanelChildStep.<OnBeforeStartAsync>d__26>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E328 RID: 254760 RVA: 0x00FE1744 File Offset: 0x00FDF944
		protected override void OnStart()
		{
			base.OnStart();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
			this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnSequencePlayEvent));
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUISprite sprite = base.GetSprite(6);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(7);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUISizeControlByOther uuisizeControlByOther = this.RootActor.GetComponentByClass(UUISizeControlByOther.StaticClass()) as UUISizeControlByOther;
			if (uuisizeControlByOther != null)
			{
				uuisizeControlByOther.bSizeZeroWhenNotActive = true;
			}
			else
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.XDW, "MissionPanelChildStep 无法获取UISizeControlByOther", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.UpdateRootVisibleByTextVisible();
		}

		// Token: 0x0603E329 RID: 254761 RVA: 0x00FE181E File Offset: 0x00FDFA1E
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
			if (this.DeferHideForCompleteAnimDelayHandle != null)
			{
				TimerSystem.Instance.Remove(this.DeferHideForCompleteAnimDelayHandle);
				this.DeferHideForCompleteAnimDelayHandle = null;
			}
		}

		// Token: 0x0603E32A RID: 254762 RVA: 0x00FE185C File Offset: 0x00FDFA5C
		protected override void OnAfterShow()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.ResumeSequence();
			}
			this.UpdateRootVisibleByTextVisible();
		}

		// Token: 0x0603E32B RID: 254763 RVA: 0x00FE1875 File Offset: 0x00FDFA75
		protected override void OnAfterHide()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PauseSequence();
		}

		// Token: 0x17009A85 RID: 39557
		// (get) Token: 0x0603E32C RID: 254764 RVA: 0x00FE1887 File Offset: 0x00FDFA87
		public override bool IsDescribeTextVisible
		{
			get
			{
				return this.IsDeferHideForCompleteAnim || base.IsDescribeTextVisible;
			}
		}

		// Token: 0x0603E32D RID: 254765 RVA: 0x00FE189C File Offset: 0x00FDFA9C
		public UniTask StartShow(bool bSkipAnim)
		{
			MissionPanelChildStep.<StartShow>d__33 <StartShow>d__;
			<StartShow>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartShow>d__.<>4__this = this;
			<StartShow>d__.bSkipAnim = bSkipAnim;
			<StartShow>d__.<>1__state = -1;
			<StartShow>d__.<>t__builder.Start<MissionPanelChildStep.<StartShow>d__33>(ref <StartShow>d__);
			return <StartShow>d__.<>t__builder.Task;
		}

		// Token: 0x0603E32E RID: 254766 RVA: 0x00FE18E8 File Offset: 0x00FDFAE8
		public UniTask EndShow(bool bSkipAnim)
		{
			MissionPanelChildStep.<EndShow>d__34 <EndShow>d__;
			<EndShow>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EndShow>d__.<>4__this = this;
			<EndShow>d__.bSkipAnim = bSkipAnim;
			<EndShow>d__.<>1__state = -1;
			<EndShow>d__.<>t__builder.Start<MissionPanelChildStep.<EndShow>d__34>(ref <EndShow>d__);
			return <EndShow>d__.<>t__builder.Task;
		}

		// Token: 0x0603E32F RID: 254767 RVA: 0x00FE1933 File Offset: 0x00FDFB33
		public override bool CheckVisible()
		{
			bool result = base.CheckVisible();
			this.UpdateRootVisibleByTextVisible();
			return result;
		}

		// Token: 0x0603E330 RID: 254768 RVA: 0x00FE1944 File Offset: 0x00FDFB44
		public override UniTask OnReset()
		{
			MissionPanelChildStep.<OnReset>d__36 <OnReset>d__;
			<OnReset>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnReset>d__.<>4__this = this;
			<OnReset>d__.<>1__state = -1;
			<OnReset>d__.<>t__builder.Start<MissionPanelChildStep.<OnReset>d__36>(ref <OnReset>d__);
			return <OnReset>d__.<>t__builder.Task;
		}

		// Token: 0x0603E331 RID: 254769 RVA: 0x00FE1988 File Offset: 0x00FDFB88
		protected override void UpdateStepInfo()
		{
			this.UpdateSpriteAndColor();
			this.UpdatePreCondition();
			base.UpdateStepInfo();
			if (this.DescribeTextVisible)
			{
				this.LastValidDescribeText = this.DescribeTextComp.GetText();
			}
			if (this.IsDeferHideForCompleteAnim)
			{
				this.DescribeTextComp.SetText(this.LastValidDescribeText, true);
				this.DescribeTextVisible = true;
			}
			this.UpdateRootVisibleByTextVisible();
			this.UpdateProgressBar();
		}

		// Token: 0x0603E332 RID: 254770 RVA: 0x00FE19ED File Offset: 0x00FDFBED
		private void UpdateProgressBar()
		{
		}

		// Token: 0x0603E333 RID: 254771 RVA: 0x00FE19EF File Offset: 0x00FDFBEF
		private void UpdateRootVisibleByTextVisible()
		{
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.IsDescribeTextVisible);
		}

		// Token: 0x0603E334 RID: 254772 RVA: 0x00FE1A08 File Offset: 0x00FDFC08
		private void UpdatePreCondition()
		{
			if (this.IsUnlockAnimPlaying)
			{
				return;
			}
			bool flag = this.CheckMeetPreCondition();
			if (this.IsMeetPreCondition != flag)
			{
				if (flag)
				{
					this.PlayUnlockAnim().Forget();
					return;
				}
				this.IsMeetPreCondition = false;
				this.DescribeTextComp.SetColor(this.GrayColor);
				UUISprite sprite = base.GetSprite(6);
				if (sprite != null)
				{
					sprite.SetAlpha(1f);
				}
				UUISprite sprite2 = base.GetSprite(6);
				if (sprite2 != null)
				{
					sprite2.SetUIActive(true);
				}
				BehaviorTreeStepTextInfo behaviorTreeStepTextInfo = this.Config as BehaviorTreeStepTextInfo;
				if (behaviorTreeStepTextInfo != null)
				{
					behaviorTreeStepTextInfo.UsePreStateText = true;
				}
			}
		}

		// Token: 0x0603E335 RID: 254773 RVA: 0x00FE1A98 File Offset: 0x00FDFC98
		public UniTask PlayUnlockAnim()
		{
			MissionPanelChildStep.<PlayUnlockAnim>d__41 <PlayUnlockAnim>d__;
			<PlayUnlockAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayUnlockAnim>d__.<>4__this = this;
			<PlayUnlockAnim>d__.<>1__state = -1;
			<PlayUnlockAnim>d__.<>t__builder.Start<MissionPanelChildStep.<PlayUnlockAnim>d__41>(ref <PlayUnlockAnim>d__);
			return <PlayUnlockAnim>d__.<>t__builder.Task;
		}

		// Token: 0x0603E336 RID: 254774 RVA: 0x00FE1ADB File Offset: 0x00FDFCDB
		protected override bool CheckCanShowStatusRoot()
		{
			if (!this.IsMeetPreCondition)
			{
				return this.UnlockAnimEventPlay;
			}
			return base.CheckCanShowStatusRoot();
		}

		// Token: 0x0603E337 RID: 254775 RVA: 0x00FE1AF2 File Offset: 0x00FDFCF2
		protected override bool CheckCanUpdateStatusNode()
		{
			return this.IsMeetPreCondition;
		}

		// Token: 0x0603E338 RID: 254776 RVA: 0x00FE1AFC File Offset: 0x00FDFCFC
		protected bool CheckMeetPreCondition()
		{
			BehaviorTreeStepTextInfo behaviorTreeStepTextInfo = this.Config as BehaviorTreeStepTextInfo;
			if (behaviorTreeStepTextInfo == null)
			{
				return true;
			}
			GeneralLogicTreeModel instance = ModelBase<GeneralLogicTreeModel>.Instance;
			IMissionItemViewShowData showData = this.ShowData;
			BaseBehaviorTree behaviorTree = instance.GetBehaviorTree(new long?(((showData != null) ? new long?(showData.Id) : null).Value), false);
			if (behaviorTree == null || behaviorTree.BtType == BtType.Quest)
			{
				return true;
			}
			IQuestScheduleType questScheduleType = behaviorTreeStepTextInfo.QuestScheduleType;
			if (questScheduleType.Type == EQuestScheduleType.ChildQuestCompleted)
			{
				IQuestScheduleChildQuestCompleted questScheduleChildQuestCompleted = questScheduleType as IQuestScheduleChildQuestCompleted;
				ITitlePreState titlePreState = (questScheduleChildQuestCompleted != null) ? questScheduleChildQuestCompleted.TitlePreState : null;
				if (titlePreState != null)
				{
					GeneralLogicTreeContext context = GeneralLogicTreeContext.Create(behaviorTree.BtType, behaviorTree.TreeIncId, behaviorTree.TreeConfigId, 0, null);
					return ControllerBase<LevelGeneralController>.Instance.CheckConditionNew(titlePreState.SwitchConditions, null, context, null);
				}
			}
			return true;
		}

		// Token: 0x0603E339 RID: 254777 RVA: 0x00FE1BCC File Offset: 0x00FDFDCC
		private void UpdateSpriteAndColor()
		{
			if (this.Config == null)
			{
				return;
			}
			OneOf<string, EQuestScheduleType> oneOf = EQuestScheduleType.None;
			FishingEntrustStepTextInfo fishingEntrustStepTextInfo = this.Config as FishingEntrustStepTextInfo;
			if (fishingEntrustStepTextInfo != null)
			{
				oneOf = fishingEntrustStepTextInfo.QuestScheduleType;
			}
			else
			{
				BehaviorTreeStepTextInfo behaviorTreeStepTextInfo = this.Config as BehaviorTreeStepTextInfo;
				if (behaviorTreeStepTextInfo != null && behaviorTreeStepTextInfo.QuestScheduleType != null)
				{
					oneOf = behaviorTreeStepTextInfo.QuestScheduleType.Type;
				}
			}
			if (this.CurType == oneOf)
			{
				return;
			}
			this.CurType = oneOf;
			if (oneOf.IsT1)
			{
				if (oneOf.AsT1 == "FishingEntrust")
				{
					this.CompletedColor = new FColor?(this.GreenColor);
					this.FailedColor = new FColor?(this.GrayColor);
					string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MissionState");
					string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MissionComplete");
					string resourcePath3 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MissionLose");
					this.SetSpriteByPath(resourcePath, this.StepStatusNode, true, null, null);
					this.SetSpriteByPath(resourcePath2, this.StepSuccess, true, null, null);
					this.SetSpriteByPath(resourcePath3, this.StepLose, true, null, null);
					return;
				}
			}
			else
			{
				EQuestScheduleType asT = oneOf.AsT2;
				if (asT == EQuestScheduleType.ChildQuestCompleted)
				{
					this.CompletedColor = new FColor?(this.GreenColor);
					this.FailedColor = new FColor?(this.GrayColor);
					string resourcePath4 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MissionState");
					string resourcePath5 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MissionComplete");
					string resourcePath6 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MissionLose");
					this.SetSpriteByPath(resourcePath4, this.StepStatusNode, true, null, null);
					this.SetSpriteByPath(resourcePath5, this.StepSuccess, true, null, null);
					this.SetSpriteByPath(resourcePath6, this.StepLose, true, null, null);
					return;
				}
				if (asT - EQuestScheduleType.TimeLeft > 1)
				{
					return;
				}
				object obj = (oneOf == EQuestScheduleType.Condition) ? ((IQuestScheduleMeetCondition)((BehaviorTreeStepTextInfo)this.Config).QuestScheduleType).IconType : ((IQuestScheduleTimeLeft)((BehaviorTreeStepTextInfo)this.Config).QuestScheduleType).IconType;
				this.CompletedColor = new FColor?(this.WhiteColor);
				this.FailedColor = new FColor?(this.GrayColor);
				object obj2 = obj;
				string resourceId = (obj2 == 1) ? "SP_DailyTowerStarBg" : "SP_ComStateOffline";
				string resourcePath7 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
				this.SetSpriteByPath(resourcePath7, this.StepStatusNode, true, null, null);
				string resourceId2 = (obj2 == 1) ? "SP_DailyTowerStar" : "SP_ComStateOnline";
				string resourcePath8 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId2);
				this.SetSpriteByPath(resourcePath8, this.StepSuccess, true, null, null);
				this.SetSpriteByPath(resourcePath7, this.StepLose, true, null, null);
			}
		}

		// Token: 0x0603E33A RID: 254778 RVA: 0x00FE1EBC File Offset: 0x00FE00BC
		protected override void OnStatusChanged(EStatusType status, EStepStatusRefreshReason reason)
		{
			string text = null;
			switch (status)
			{
			case EStatusType.None:
				this.DescribeTextComp.SetColor(this.WhiteColor);
				break;
			case EStatusType.Success:
				text = "Success";
				break;
			case EStatusType.Fail:
				text = "Fail";
				break;
			}
			if (!string.IsNullOrEmpty(text))
			{
				this.LevelSequencePlayer.StopCurrentSequence(true, true);
				this.LevelSequencePlayer.PlayLevelSequenceByName(text, false, null, false);
				if (reason == EStepStatusRefreshReason.StatusChange)
				{
					this.IsDeferHideForCompleteAnim = !this.CheckOriginalTextVisible();
					return;
				}
				this.LevelSequencePlayer.EndSequenceLastFrame(text);
				this.IsDeferHideForCompleteAnim = !this.CheckOriginalTextVisible();
				if (this.IsDeferHideForCompleteAnim)
				{
					this.DeferHideForCompleteAnimDelayHandle = TimerSystem.Instance.Delay(delegate(float _)
					{
						this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
						this.DeferHideForCompleteAnimDelayHandle = null;
					}, 1000f, null, null, true, 1f);
					return;
				}
			}
			else
			{
				this.IsDeferHideForCompleteAnim = false;
			}
		}

		// Token: 0x0603E33B RID: 254779 RVA: 0x00FE1F98 File Offset: 0x00FE0198
		protected override UniTask OnConfigRefresh(IMissionItemViewShowData showData, [Nullable(2)] MissionViewStepTextInfoBase config)
		{
			MissionPanelChildStep.<OnConfigRefresh>d__47 <OnConfigRefresh>d__;
			<OnConfigRefresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnConfigRefresh>d__.<>4__this = this;
			<OnConfigRefresh>d__.showData = showData;
			<OnConfigRefresh>d__.config = config;
			<OnConfigRefresh>d__.<>1__state = -1;
			<OnConfigRefresh>d__.<>t__builder.Start<MissionPanelChildStep.<OnConfigRefresh>d__47>(ref <OnConfigRefresh>d__);
			return <OnConfigRefresh>d__.<>t__builder.Task;
		}

		// Token: 0x0603E33C RID: 254780 RVA: 0x00FE1FEC File Offset: 0x00FE01EC
		private bool CheckOriginalTextVisible()
		{
			StepControllerBase stepControllerBase;
			return (!this.StepControllers.TryGetValue(EStepControllerType.MotionArtText, out stepControllerBase) || !stepControllerBase.Enable) && this.ShowData != null && this.Config != null && !StringUtils.IsBlank(MissionViewStepTextUtil.GetStepTextByConfig(this.ShowData.Id, this.Config));
		}

		// Token: 0x0603E33D RID: 254781 RVA: 0x00FE2048 File Offset: 0x00FE0248
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Success")
			{
				UUIText describeTextComp = this.DescribeTextComp;
				if (describeTextComp != null)
				{
					describeTextComp.SetColor(this.CompletedColor.Value);
				}
				if (this.IsDeferHideForCompleteAnim && this.DeferHideForCompleteAnimDelayHandle == null)
				{
					this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
					return;
				}
			}
			else if (sequenceName == "Fail")
			{
				UUIText describeTextComp2 = this.DescribeTextComp;
				if (describeTextComp2 != null)
				{
					describeTextComp2.SetColor(this.FailedColor.Value);
				}
				if (this.IsDeferHideForCompleteAnim && this.DeferHideForCompleteAnimDelayHandle == null)
				{
					this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
					return;
				}
			}
			else if (sequenceName == "Start")
			{
				CustomPromise<bool> startSequencePromise = this.StartSequencePromise;
				if (startSequencePromise != null && startSequencePromise.IsPending)
				{
					this.StartSequencePromise.SetResult(true);
					return;
				}
			}
			else if (sequenceName == "Close")
			{
				CustomPromise<bool> closeSequencePromise = this.CloseSequencePromise;
				if (closeSequencePromise != null && closeSequencePromise.IsPending)
				{
					this.CloseSequencePromise.SetResult(true);
				}
				this.IsDeferHideForCompleteAnim = false;
				if (this.DeferHideForCompleteAnimDelayHandle != null)
				{
					TimerSystem.Instance.Remove(this.DeferHideForCompleteAnimDelayHandle);
					this.DeferHideForCompleteAnimDelayHandle = null;
					return;
				}
			}
			else if (sequenceName == "Unlock")
			{
				CustomPromise<bool> unlockSequenceEndPromise = this.UnlockSequenceEndPromise;
				if (unlockSequenceEndPromise != null && unlockSequenceEndPromise.IsPending)
				{
					this.UnlockSequenceEndPromise.SetResult(true);
				}
			}
		}

		// Token: 0x0603E33E RID: 254782 RVA: 0x00FE21BE File Offset: 0x00FE03BE
		private void OnActivitySequenceEmitEvent(string sequenceName)
		{
			this.OnSequencePlayEvent(sequenceName, null);
		}

		// Token: 0x0603E33F RID: 254783 RVA: 0x00FE21C8 File Offset: 0x00FE03C8
		private void OnSequencePlayEvent(string sequenceName, string _)
		{
			if (sequenceName == "Unlock")
			{
				if (this.CurUnlockAnimEventTag == MissionPanelChildStep.UnlockAnimEventPlayTag)
				{
					CustomPromise<bool> unlockSequenceEventPromise = this.UnlockSequenceEventPromise;
					if (unlockSequenceEventPromise != null && unlockSequenceEventPromise.IsPending)
					{
						this.UnlockSequenceEventPromise.SetResult(true);
					}
				}
				MissionPanelChildStep.UnlockAnimEventPlayTag++;
			}
		}

		// Token: 0x04022DCC RID: 142796
		private const string UNLOCK_ANIM = "Unlock";

		// Token: 0x04022DCD RID: 142797
		private readonly FColor WhiteColor = FColor.FromHex("ECE5D8FF");

		// Token: 0x04022DCE RID: 142798
		private readonly FColor GrayColor = FColor.FromHex("ADADADFF");

		// Token: 0x04022DCF RID: 142799
		private readonly FColor GreenColor = FColor.FromHex("C9F797FF");

		// Token: 0x04022DD0 RID: 142800
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022DD1 RID: 142801
		[Nullable(2)]
		private CustomPromise<bool> StartSequencePromise;

		// Token: 0x04022DD2 RID: 142802
		[Nullable(2)]
		private CustomPromise<bool> CloseSequencePromise;

		// Token: 0x04022DD3 RID: 142803
		[Nullable(2)]
		private CustomPromise<bool> UnlockSequenceEndPromise;

		// Token: 0x04022DD4 RID: 142804
		[Nullable(2)]
		private CustomPromise<bool> UnlockSequenceEventPromise;

		// Token: 0x04022DD5 RID: 142805
		private FColor? CompletedColor;

		// Token: 0x04022DD6 RID: 142806
		private FColor? FailedColor;

		// Token: 0x04022DD7 RID: 142807
		[Nullable(new byte[]
		{
			0,
			1
		})]
		private OneOf<string, EQuestScheduleType> CurType = EQuestScheduleType.None;

		// Token: 0x04022DD8 RID: 142808
		private bool IsMeetPreCondition = true;

		// Token: 0x04022DD9 RID: 142809
		private bool IsUnlockAnimPlaying;

		// Token: 0x04022DDA RID: 142810
		private bool UnlockAnimEventPlay;

		// Token: 0x04022DDB RID: 142811
		private bool IsDeferHideForCompleteAnim;

		// Token: 0x04022DDC RID: 142812
		[Nullable(2)]
		private TimerHandle DeferHideForCompleteAnimDelayHandle;

		// Token: 0x04022DDD RID: 142813
		private string LastValidDescribeText = string.Empty;

		// Token: 0x04022DDE RID: 142814
		private static int UnlockAnimEventPlayTag;

		// Token: 0x04022DDF RID: 142815
		private int CurUnlockAnimEventTag;

		// Token: 0x0200C113 RID: 49427
		[NullableContext(0)]
		private enum EChildComponent
		{
			// Token: 0x0403B744 RID: 243524
			Root = 5,
			// Token: 0x0403B745 RID: 243525
			LockIcon,
			// Token: 0x0403B746 RID: 243526
			ProgressBar
		}
	}
}
