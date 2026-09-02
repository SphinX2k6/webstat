using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CE4 RID: 23780
	[NullableContext(1)]
	[Nullable(0)]
	public class GetItemBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BF64 RID: 245604 RVA: 0x00F341C8 File Offset: 0x00F323C8
		public GetItemBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BF65 RID: 245605 RVA: 0x00F341D4 File Offset: 0x00F323D4
		protected bool OnCreate(IChildQuestBtNode config)
		{
			if (!base.OnCreate(config))
			{
				return false;
			}
			IGetItemQuestCondition getItemQuestCondition = config.Condition as IGetItemQuestCondition;
			if (getItemQuestCondition == null)
			{
				return false;
			}
			this.ItemMaxCount = getItemQuestCondition.Items.Count;
			this.TrackTextRuleInner = ENodeTrackTextRule.Progress;
			return true;
		}

		// Token: 0x0603BF66 RID: 245606 RVA: 0x00F34216 File Offset: 0x00F32416
		protected override bool OnUpdateProgress(ChildQuestNodeProgress progress)
		{
			this.Progress = progress.GetItem;
			return true;
		}

		// Token: 0x0603BF67 RID: 245607 RVA: 0x00F34225 File Offset: 0x00F32425
		public override string GetProgress()
		{
			return this.ItemMaxCount.ToString();
		}

		// Token: 0x0603BF68 RID: 245608 RVA: 0x00F34234 File Offset: 0x00F32434
		public override string GetProgressMax()
		{
			GetItemProgress progress = this.Progress;
			string text;
			if (progress == null)
			{
				text = null;
			}
			else
			{
				RepeatedField<GetItemCount> info = progress.Info;
				text = ((info != null) ? info.Count.ToString() : null);
			}
			return text ?? "0";
		}

		// Token: 0x04021B04 RID: 137988
		[Nullable(2)]
		private GetItemProgress Progress;

		// Token: 0x04021B05 RID: 137989
		private int ItemMaxCount;
	}
}
