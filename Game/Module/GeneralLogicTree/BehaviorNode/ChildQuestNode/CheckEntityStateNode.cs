using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CDA RID: 23770
	[NullableContext(1)]
	[Nullable(0)]
	public class CheckEntityStateNode : ChildQuestNodeBase
	{
		// Token: 0x0603BEFF RID: 245503 RVA: 0x00F3274C File Offset: 0x00F3094C
		public CheckEntityStateNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x17009845 RID: 38981
		// (get) Token: 0x0603BF00 RID: 245504 RVA: 0x00F32760 File Offset: 0x00F30960
		protected override List<int> CorrelativeEntities
		{
			get
			{
				return this.InnerCorrelativeEntities;
			}
		}

		// Token: 0x0603BF01 RID: 245505 RVA: 0x00F32768 File Offset: 0x00F30968
		protected override bool OnCreate(IBtNode nodeConfig)
		{
			IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return false;
			}
			if (!base.OnCreate(nodeConfig))
			{
				return false;
			}
			ICheckEntityStateQuestCondition checkEntityStateQuestCondition = childQuestBtNode.Condition as ICheckEntityStateQuestCondition;
			if (checkEntityStateQuestCondition == null)
			{
				return false;
			}
			this.InnerCorrelativeEntities.Clear();
			if (checkEntityStateQuestCondition.Conditions != null)
			{
				this.InnerCorrelativeEntities.EnsureCapacity(checkEntityStateQuestCondition.Conditions.Count);
				foreach (IEntityStateCondition entityStateCondition in checkEntityStateQuestCondition.Conditions)
				{
					this.InnerCorrelativeEntities.Add(entityStateCondition.EntityId);
				}
			}
			this.TrackTextRuleInner = ENodeTrackTextRule.Progress;
			return true;
		}

		// Token: 0x0603BF02 RID: 245506 RVA: 0x00F32820 File Offset: 0x00F30A20
		protected override bool OnUpdateProgress(ChildQuestNodeProgress progress)
		{
			if (progress.EntityStateList == null)
			{
				return false;
			}
			this.Progress = progress.EntityStateList;
			return true;
		}

		// Token: 0x0603BF03 RID: 245507 RVA: 0x00F3283C File Offset: 0x00F30A3C
		public override string GetProgress()
		{
			EntityStateProgress progress = this.Progress;
			string text;
			if (progress == null)
			{
				text = null;
			}
			else
			{
				RepeatedField<int> entityId = progress.EntityId;
				text = ((entityId != null) ? entityId.Count.ToString() : null);
			}
			return text ?? "0";
		}

		// Token: 0x0603BF04 RID: 245508 RVA: 0x00F32878 File Offset: 0x00F30A78
		public override string GetProgressMax()
		{
			return this.InnerCorrelativeEntities.Count.ToString();
		}

		// Token: 0x04021ADF RID: 137951
		[Nullable(2)]
		private EntityStateProgress Progress;

		// Token: 0x04021AE0 RID: 137952
		private readonly List<int> InnerCorrelativeEntities = new List<int>();
	}
}
