using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CE3 RID: 23779
	public class FinishArcadeGameplayNode : ChildQuestNodeBase
	{
		// Token: 0x0603BF5D RID: 245597 RVA: 0x00F3405F File Offset: 0x00F3225F
		public FinishArcadeGameplayNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BF5E RID: 245598 RVA: 0x00F34068 File Offset: 0x00F32268
		[NullableContext(1)]
		protected override bool OnCreate(IBtNode nodeConfig)
		{
			if (!base.OnCreate(nodeConfig))
			{
				return false;
			}
			IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return false;
			}
			IFinishArcadeGameplay finishArcadeGameplay = childQuestBtNode.Condition as IFinishArcadeGameplay;
			if (finishArcadeGameplay == null)
			{
				return false;
			}
			this.GameplayType = new EArcadeGameplayType?(finishArcadeGameplay.ArcadeGameplay.Type);
			IArcadeGameplayBase arcadeGameplay = finishArcadeGameplay.ArcadeGameplay;
			IArcadeGameplayDropCatch arcadeGameplayDropCatch = arcadeGameplay as IArcadeGameplayDropCatch;
			int levelId;
			if (arcadeGameplayDropCatch == null)
			{
				IArcadeGameplayTetrisBoardGame arcadeGameplayTetrisBoardGame = arcadeGameplay as IArcadeGameplayTetrisBoardGame;
				if (arcadeGameplayTetrisBoardGame == null)
				{
					levelId = 0;
				}
				else
				{
					levelId = arcadeGameplayTetrisBoardGame.LevelId;
				}
			}
			else
			{
				levelId = arcadeGameplayDropCatch.LevelId;
			}
			this.LevelId = levelId;
			return true;
		}

		// Token: 0x0603BF5F RID: 245599 RVA: 0x00F340F3 File Offset: 0x00F322F3
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.GameplayType = null;
			this.LevelId = 0;
		}

		// Token: 0x0603BF60 RID: 245600 RVA: 0x00F3410E File Offset: 0x00F3230E
		protected override void AddEventsOnChildQuestStart()
		{
			base.AddEventsOnChildQuestStart();
			Singleton<EventSystem>.Instance.Add<EArcadeGameplayType, int>(EEventName.OnArcadeGameplayFinish, new Action<EArcadeGameplayType, int>(this.OnGameplayFinish));
		}

		// Token: 0x0603BF61 RID: 245601 RVA: 0x00F34132 File Offset: 0x00F32332
		protected override void RemoveEventsOnChildQuestEnd()
		{
			Singleton<EventSystem>.Instance.Remove<EArcadeGameplayType, int>(EEventName.OnArcadeGameplayFinish, new Action<EArcadeGameplayType, int>(this.OnGameplayFinish));
			base.RemoveEventsOnChildQuestEnd();
		}

		// Token: 0x0603BF62 RID: 245602 RVA: 0x00F34158 File Offset: 0x00F32358
		private void OnGameplayFinish(EArcadeGameplayType type, int levelId)
		{
			if (this.GameplayType == null)
			{
				return;
			}
			EArcadeGameplayType? gameplayType = this.GameplayType;
			if (!(gameplayType.GetValueOrDefault() == type & gameplayType != null))
			{
				return;
			}
			if (this.LevelId == 0 || levelId == this.LevelId)
			{
				this.SubmitNode(null);
			}
		}

		// Token: 0x0603BF63 RID: 245603 RVA: 0x00F341A9 File Offset: 0x00F323A9
		protected override void OnAfterSubmit(bool submitSuccess)
		{
			base.OnAfterSubmit(submitSuccess);
			if (submitSuccess)
			{
				this.GameplayType = null;
				this.LevelId = 0;
			}
		}

		// Token: 0x04021B02 RID: 137986
		private EArcadeGameplayType? GameplayType;

		// Token: 0x04021B03 RID: 137987
		private int LevelId;
	}
}
