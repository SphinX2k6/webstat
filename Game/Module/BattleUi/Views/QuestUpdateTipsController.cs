using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006070 RID: 24688
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestUpdateTipsController : MissionPanelControllerBase
	{
		// Token: 0x17009ACB RID: 39627
		// (get) Token: 0x0603E414 RID: 254996 RVA: 0x00FE48C5 File Offset: 0x00FE2AC5
		protected override EMissionPanelControllerType ControllerType
		{
			get
			{
				return EMissionPanelControllerType.QuestUpdateTipsController;
			}
		}

		// Token: 0x0603E415 RID: 254997 RVA: 0x00FE48C8 File Offset: 0x00FE2AC8
		public QuestUpdateTipsController(LevelSequencePlayer sequencePlayer, BattleQuestUpdateTipsView questUpdateTipsView, Func<bool> checkMissionItemViewShowEmptyHandle, UUIItem missionItemViewRootNode)
		{
			this.SequencePlayer = sequencePlayer;
			this.QuestUpdateTipsView = questUpdateTipsView;
			this.CheckMissionItemViewShowEmptyHandle = checkMissionItemViewShowEmptyHandle;
			this.MissionItemViewRootNode = missionItemViewRootNode;
			this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
		}

		// Token: 0x0603E416 RID: 254998 RVA: 0x00FE4908 File Offset: 0x00FE2B08
		public override void OnDestroy()
		{
			this.SequencePlayer.Clear();
			this.QuestUpdateTipsView.Destroy(null);
			if (this.StayTimer != null && TimerSystem.Instance.Has(this.StayTimer))
			{
				TimerHandle stayTimer = this.StayTimer;
				if (stayTimer == null)
				{
					return;
				}
				stayTimer.Remove();
			}
		}

		// Token: 0x0603E417 RID: 254999 RVA: 0x00FE4957 File Offset: 0x00FE2B57
		public override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.QuestUpdateTipsClickTrack, new Action(this.OnQuestUpdateTipsClickTrack));
		}

		// Token: 0x0603E418 RID: 255000 RVA: 0x00FE4975 File Offset: 0x00FE2B75
		public override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.QuestUpdateTipsClickTrack, new Action(this.OnQuestUpdateTipsClickTrack));
		}

		// Token: 0x0603E419 RID: 255001 RVA: 0x00FE4994 File Offset: 0x00FE2B94
		public void OnPanelShow()
		{
			this.SequencePlayer.ResumeSequence();
			if (TimerSystem.Instance.Has(this.StayTimer) && TimerSystem.Instance.IsPause(this.StayTimer))
			{
				TimerSystem.Instance.Resume(this.StayTimer);
			}
		}

		// Token: 0x0603E41A RID: 255002 RVA: 0x00FE49E1 File Offset: 0x00FE2BE1
		public void OnPanelHide()
		{
			this.SequencePlayer.PauseSequence();
			if (TimerSystem.Instance.Has(this.StayTimer))
			{
				TimerSystem.Instance.Pause(this.StayTimer, null);
			}
		}

		// Token: 0x0603E41B RID: 255003 RVA: 0x00FE4A14 File Offset: 0x00FE2C14
		[NullableContext(0)]
		public UniTask<bool> ShowQuestUpdateTipsHandle([Nullable(1)] ShowQuestUpdateTipsProcess process)
		{
			QuestUpdateTipsController.<ShowQuestUpdateTipsHandle>d__20 <ShowQuestUpdateTipsHandle>d__;
			<ShowQuestUpdateTipsHandle>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowQuestUpdateTipsHandle>d__.<>4__this = this;
			<ShowQuestUpdateTipsHandle>d__.process = process;
			<ShowQuestUpdateTipsHandle>d__.<>1__state = -1;
			<ShowQuestUpdateTipsHandle>d__.<>t__builder.Start<QuestUpdateTipsController.<ShowQuestUpdateTipsHandle>d__20>(ref <ShowQuestUpdateTipsHandle>d__);
			return <ShowQuestUpdateTipsHandle>d__.<>t__builder.Task;
		}

		// Token: 0x0603E41C RID: 255004 RVA: 0x00FE4A5F File Offset: 0x00FE2C5F
		private void SetQuestUpdateTipsViewVisible(bool bVisible)
		{
			this.QuestUpdateTipsView.SetUiActive(bVisible);
			this.MissionItemViewRootNode.SetUIActive(!bVisible);
		}

		// Token: 0x0603E41D RID: 255005 RVA: 0x00FE4A7C File Offset: 0x00FE2C7C
		private float GetTimerStayTime(int questId)
		{
			Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(questId);
			if (quest == null)
			{
				return 20f;
			}
			int? questUpdateShowTime = ConfigBase<QuestNewConfig>.Instance.GetQuestUpdateShowTime((int)quest.Type);
			if (questUpdateShowTime == null)
			{
				return 20f;
			}
			return (float)(questUpdateShowTime.Value * 1000);
		}

		// Token: 0x0603E41E RID: 255006 RVA: 0x00FE4ACC File Offset: 0x00FE2CCC
		private void OnSequenceClose(string sequenceName)
		{
			if (!(sequenceName == "MissionIn"))
			{
				if (!(sequenceName == "MissionOut"))
				{
					return;
				}
				if (this.MissionSequenceType == EQuestUpdateTipsStep.QuestUpdateStart)
				{
					CustomPromise<bool> questUpdateStartMissionOutPromise = this.QuestUpdateStartMissionOutPromise;
					if (questUpdateStartMissionOutPromise != null && questUpdateStartMissionOutPromise.IsPending)
					{
						this.QuestUpdateStartMissionOutPromise.SetResult(true);
						return;
					}
				}
				else if (this.MissionSequenceType == EQuestUpdateTipsStep.QuestUpdateEnd)
				{
					CustomPromise<bool> questUpdateEndMissionOutPromise = this.QuestUpdateEndMissionOutPromise;
					if (questUpdateEndMissionOutPromise != null && questUpdateEndMissionOutPromise.IsPending)
					{
						this.QuestUpdateEndMissionOutPromise.SetResult(true);
					}
				}
			}
			else if (this.MissionSequenceType == EQuestUpdateTipsStep.QuestUpdateStart)
			{
				CustomPromise<bool> questUpdateStartMissionInPromise = this.QuestUpdateStartMissionInPromise;
				if (questUpdateStartMissionInPromise != null && questUpdateStartMissionInPromise.IsPending)
				{
					this.QuestUpdateStartMissionInPromise.SetResult(true);
					return;
				}
			}
			else if (this.MissionSequenceType == EQuestUpdateTipsStep.QuestUpdateEnd)
			{
				CustomPromise<bool> questUpdateEndMissionInPromise = this.QuestUpdateEndMissionInPromise;
				if (questUpdateEndMissionInPromise != null && questUpdateEndMissionInPromise.IsPending)
				{
					this.QuestUpdateEndMissionInPromise.SetResult(true);
					return;
				}
			}
		}

		// Token: 0x0603E41F RID: 255007 RVA: 0x00FE4BA0 File Offset: 0x00FE2DA0
		private void QuestUpdateTipsEnd(ShowQuestUpdateTipsProcess process)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Log;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "MissionPanel:QuestUpdateTipsEnd - AllOver";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("processId", process.Info.QuestId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.QuestUpdateTipsView.OnAfterPlayHideSequence();
			this.MissionSequenceType = EQuestUpdateTipsStep.None;
			this.QuestUpdateTipsTrackBtnClick = false;
		}

		// Token: 0x0603E420 RID: 255008 RVA: 0x00FE4BFC File Offset: 0x00FE2DFC
		private void OnQuestUpdateTipsClickTrack()
		{
			Singleton<Log>.Instance.Info(ELogModule.Log, ELogAuthor.YSQ, "MissionPanel:Press Track", default(ReadOnlySpan<ValueTuple<string, object>>));
			switch (this.MissionSequenceType)
			{
			case EQuestUpdateTipsStep.QuestUpdateStart:
				this.SequencePlayer.StopCurrentSequence(true, true);
				break;
			case EQuestUpdateTipsStep.QuestUpdateStay:
			{
				if (TimerSystem.Instance.Has(this.StayTimer))
				{
					TimerSystem.Instance.Remove(this.StayTimer);
				}
				CustomPromise<bool> questUpdateStayPromise = this.QuestUpdateStayPromise;
				if (questUpdateStayPromise != null)
				{
					questUpdateStayPromise.SetResult(true);
				}
				break;
			}
			}
			this.QuestUpdateTipsTrackBtnClick = true;
		}

		// Token: 0x04022E56 RID: 142934
		private EQuestUpdateTipsStep MissionSequenceType;

		// Token: 0x04022E57 RID: 142935
		[Nullable(2)]
		private TimerHandle StayTimer;

		// Token: 0x04022E58 RID: 142936
		[Nullable(2)]
		private CustomPromise<bool> QuestUpdateStartMissionOutPromise;

		// Token: 0x04022E59 RID: 142937
		[Nullable(2)]
		private CustomPromise<bool> QuestUpdateStartMissionInPromise;

		// Token: 0x04022E5A RID: 142938
		[Nullable(2)]
		private CustomPromise<bool> QuestUpdateStayPromise;

		// Token: 0x04022E5B RID: 142939
		[Nullable(2)]
		private CustomPromise<bool> QuestUpdateEndMissionOutPromise;

		// Token: 0x04022E5C RID: 142940
		[Nullable(2)]
		private CustomPromise<bool> QuestUpdateEndMissionInPromise;

		// Token: 0x04022E5D RID: 142941
		private bool QuestUpdateTipsTrackBtnClick;

		// Token: 0x04022E5E RID: 142942
		private readonly LevelSequencePlayer SequencePlayer;

		// Token: 0x04022E5F RID: 142943
		private readonly BattleQuestUpdateTipsView QuestUpdateTipsView;

		// Token: 0x04022E60 RID: 142944
		private readonly Func<bool> CheckMissionItemViewShowEmptyHandle;

		// Token: 0x04022E61 RID: 142945
		private readonly UUIItem MissionItemViewRootNode;
	}
}
