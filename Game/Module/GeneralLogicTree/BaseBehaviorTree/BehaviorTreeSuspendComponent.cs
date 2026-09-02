using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.GeneralLogicTree.BaseBehaviorTree
{
	// Token: 0x02005CFB RID: 23803
	[NullableContext(1)]
	[Nullable(0)]
	public class BehaviorTreeSuspendComponent
	{
		// Token: 0x0603C000 RID: 245760 RVA: 0x00F376FE File Offset: 0x00F358FE
		public BehaviorTreeSuspendComponent(long treeIncId, Blackboard blackBoard)
		{
			this.Blackboard = blackBoard;
			this.TreeIncId = treeIncId;
		}

		// Token: 0x0603C001 RID: 245761 RVA: 0x00F37720 File Offset: 0x00F35920
		public EBehaviorTreeSuspendType GetSuspendType()
		{
			if (this.CurSuspendState == EBehaviorTreeSuspendType.None)
			{
				return EBehaviorTreeSuspendType.None;
			}
			if (this.CurSuspendState.HasFlag(EBehaviorTreeSuspendType.Online))
			{
				return EBehaviorTreeSuspendType.Online;
			}
			if (this.CurSuspendState.HasFlag(EBehaviorTreeSuspendType.Occupation))
			{
				return EBehaviorTreeSuspendType.Occupation;
			}
			return EBehaviorTreeSuspendType.None;
		}

		// Token: 0x0603C002 RID: 245762 RVA: 0x00F3776C File Offset: 0x00F3596C
		[NullableContext(2)]
		public string GetSuspendText()
		{
			if (!this.Blackboard.IsSuspend())
			{
				return null;
			}
			string result = null;
			EBehaviorTreeSuspendType suspendType = this.GetSuspendType();
			if (suspendType != EBehaviorTreeSuspendType.Occupation)
			{
				if (suspendType == EBehaviorTreeSuspendType.Online)
				{
					result = ConfigBase<TextConfig>.Instance.GetTextById("SuspendByOnline");
				}
			}
			else if (this.Occupations.Count != 0)
			{
				result = this.ConvertOccupationToTipString(this.Occupations[0]);
			}
			return result;
		}

		// Token: 0x0603C003 RID: 245763 RVA: 0x00F377CE File Offset: 0x00F359CE
		public IReadOnlyList<IOccupationInfo> GetOccupations()
		{
			return this.Occupations;
		}

		// Token: 0x0603C004 RID: 245764 RVA: 0x00F377D8 File Offset: 0x00F359D8
		private string ConvertOccupationToTipString(IOccupationInfo occupation)
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("QuestResourcesIsOccupied");
			TArray<string> tarray = new TArray<string>();
			string occupationResourceName = ConfigBase<QuestNewConfig>.Instance.GetOccupationResourceName(occupation.ResourceName);
			string behaviorTreeName = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTreeName(occupation.TreeIncId);
			tarray.Add(occupationResourceName);
			tarray.Add(behaviorTreeName);
			return UKuroStaticLibrary.KuroFormatText(textById, tarray);
		}

		// Token: 0x0603C005 RID: 245765 RVA: 0x00F37830 File Offset: 0x00F35A30
		public void UpdateOccupations(int nodeId, int curSuspendState, IReadOnlyList<OccupationPbInfo> occupationInfos)
		{
			this.CurSuspendState = (EBehaviorTreeSuspendType)curSuspendState;
			if (curSuspendState == 0)
			{
				this.ClearOccupations();
				return;
			}
			this.Blackboard.RemoveTag(EBehaviorTreeTag.Suspending, "");
			this.Occupations.Clear();
			foreach (OccupationPbInfo occupationPbInfo in occupationInfos)
			{
				long incId = occupationPbInfo.IncId;
				BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(incId), false);
				string questName = "";
				if (behaviorTree != null)
				{
					questName = Singleton<GeneralLogicTreeUtil>.Instance.GetLogicTreeContainer(behaviorTree.BtType, behaviorTree.TreeConfigId).Name;
				}
				this.Occupations.Add(new IOccupationInfo
				{
					ResourceName = occupationPbInfo.ResourceName,
					QuestName = questName,
					TreeIncId = occupationPbInfo.IncId
				});
			}
			this.Blackboard.AddTag(EBehaviorTreeTag.Suspending, "");
			EBehaviorTreeSuspendType suspendType = this.GetSuspendType();
			Singleton<EventSystem>.Instance.Emit<long, int, EBehaviorTreeSuspendType>(EEventName.GeneralLogicTreeSuspend, this.TreeIncId, nodeId, suspendType);
			Singleton<EventSystem>.Instance.EmitWithTarget<long, int, EBehaviorTreeSuspendType>(this.Blackboard, EEventName.GeneralLogicTreeSuspend, this.TreeIncId, nodeId, suspendType);
		}

		// Token: 0x0603C006 RID: 245766 RVA: 0x00F37968 File Offset: 0x00F35B68
		public void ClearOccupations()
		{
			this.Occupations.Clear();
			this.Blackboard.RemoveTag(EBehaviorTreeTag.Suspending, "");
			this.Blackboard.RemoveTag(EBehaviorTreeTag.SuspendingCanShow, "");
			Singleton<EventSystem>.Instance.Emit<long>(EEventName.GeneralLogicTreeCancelSuspend, this.TreeIncId);
			Singleton<EventSystem>.Instance.EmitWithTarget<long>(this.Blackboard, EEventName.GeneralLogicTreeCancelSuspend, this.TreeIncId);
		}

		// Token: 0x04021B61 RID: 138081
		private readonly long TreeIncId;

		// Token: 0x04021B62 RID: 138082
		private readonly Blackboard Blackboard;

		// Token: 0x04021B63 RID: 138083
		private List<IOccupationInfo> Occupations = new List<IOccupationInfo>();

		// Token: 0x04021B64 RID: 138084
		private EBehaviorTreeSuspendType CurSuspendState;
	}
}
