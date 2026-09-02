using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CF9 RID: 23801
	[NullableContext(1)]
	[Nullable(0)]
	public class WaitSceneReferenceEntityPlaySequenceNode : TickBehaviorNode
	{
		// Token: 0x0603BFF0 RID: 245744 RVA: 0x00F36D88 File Offset: 0x00F34F88
		public WaitSceneReferenceEntityPlaySequenceNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x17009854 RID: 38996
		// (get) Token: 0x0603BFF1 RID: 245745 RVA: 0x00F36DA7 File Offset: 0x00F34FA7
		protected override List<int> CorrelativeEntities
		{
			get
			{
				return this.InnerCorrelativeEntities;
			}
		}

		// Token: 0x0603BFF2 RID: 245746 RVA: 0x00F36DB0 File Offset: 0x00F34FB0
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
			WaitUntilLevelSequenceReachMark waitUntilLevelSequenceReachMark = childQuestBtNode.Condition as WaitUntilLevelSequenceReachMark;
			if (waitUntilLevelSequenceReachMark == null)
			{
				return false;
			}
			this.PbDataId = waitUntilLevelSequenceReachMark.EntityId;
			this.InnerCorrelativeEntities.Clear();
			this.InnerCorrelativeEntities.Add(this.PbDataId);
			this.Mark = waitUntilLevelSequenceReachMark.Mark;
			return true;
		}

		// Token: 0x0603BFF3 RID: 245747 RVA: 0x00F36E1A File Offset: 0x00F3501A
		protected override void OnStart(ENodeStatusUpdateReason reason)
		{
			base.OnStart(reason);
			this.SubmitSuccess = false;
		}

		// Token: 0x0603BFF4 RID: 245748 RVA: 0x00F36E2C File Offset: 0x00F3502C
		protected unsafe override void OnTick(float delta)
		{
			if (this.SubmitSuccess)
			{
				return;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.PbDataId);
			bool flag;
			if (entityByPbDataId == null)
			{
				flag = true;
			}
			else
			{
				WorldEntity entity = entityByPbDataId.Entity;
				flag = !((entity != null) ? new bool?(entity.Valid) : null).GetValueOrDefault();
			}
			if (flag || !entityByPbDataId.Entity.IsInit)
			{
				return;
			}
			SceneItemReferenceComponent component = entityByPbDataId.Entity.GetComponent<SceneItemReferenceComponent>();
			if (component == null)
			{
				base.RemoveTimer();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GeneralLogicTree;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "WaitSceneReferenceEntityPlaySequenceNode.OnTick:找不到实体身上的SceneItemReferenceComponent组件";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("treeConfigId", base.TreeConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("nodeId", base.NodeId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("pbDataId", this.PbDataId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			if (!component.IsPlayToMarkFinished(this.Mark))
			{
				return;
			}
			this.SubmitNode(null);
		}

		// Token: 0x0603BFF5 RID: 245749 RVA: 0x00F36F4E File Offset: 0x00F3514E
		protected override void OnAfterSubmit(bool submitSuccess)
		{
			base.OnAfterSubmit(submitSuccess);
			this.SubmitSuccess = submitSuccess;
		}

		// Token: 0x04021B4F RID: 138063
		private int PbDataId;

		// Token: 0x04021B50 RID: 138064
		private string Mark = "";

		// Token: 0x04021B51 RID: 138065
		private bool SubmitSuccess;

		// Token: 0x04021B52 RID: 138066
		private readonly List<int> InnerCorrelativeEntities = new List<int>();
	}
}
