using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CD8 RID: 23768
	public class AwakeAndLoadEntityNode : TickBehaviorNode
	{
		// Token: 0x0603BEF5 RID: 245493 RVA: 0x00F32327 File Offset: 0x00F30527
		public AwakeAndLoadEntityNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BEF6 RID: 245494 RVA: 0x00F32330 File Offset: 0x00F30530
		[NullableContext(1)]
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
			IAwakeAndLoadEntityCondition awakeAndLoadEntityCondition = childQuestBtNode.Condition as IAwakeAndLoadEntityCondition;
			if (awakeAndLoadEntityCondition == null)
			{
				return false;
			}
			this.EntityIds = awakeAndLoadEntityCondition.EntityIds;
			this.IntervalTime = 1000f;
			this.NeedCheckVisible = awakeAndLoadEntityCondition.IsWaitForShow.GetValueOrDefault();
			return true;
		}

		// Token: 0x0603BEF7 RID: 245495 RVA: 0x00F32394 File Offset: 0x00F30594
		protected unsafe override void OnTick(float _)
		{
			if (this.SubmitState != 0)
			{
				return;
			}
			if (this.EntityIds == null || this.EntityIds.Count == 0)
			{
				this.Submit();
				return;
			}
			foreach (int num in this.EntityIds)
			{
				if (ModelBase<CreatureModel>.Instance.GetEntityData(new int?(num), null) == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Entity;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "GeneralLogicTree.AwakeAndLoadEntityNode 找不到实体配置";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", num);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num);
					if (entityByPbDataId == null)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Entity;
						ELogAuthor author2 = ELogAuthor.YSQ;
						string message2 = "GeneralLogicTree.AwakeAndLoadEntityNode AOI范围外的实体";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TreeConfigId", base.TreeConfigId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("NodeId", base.NodeId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("pbDataId", num);
						instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					}
					else
					{
						if (!entityByPbDataId.IsInit)
						{
							return;
						}
						SceneItemManipulatableComponent component = entityByPbDataId.Entity.GetComponent<SceneItemManipulatableComponent>();
						if (component != null && !component.LoadingBaseConfigFinish)
						{
							return;
						}
						SceneItemActorComponent component2 = entityByPbDataId.Entity.GetComponent<SceneItemActorComponent>();
						if (this.NeedCheckVisible && component2 != null && !component2.GetIsSceneInteractionLoadCompleted())
						{
							return;
						}
					}
				}
			}
			this.Submit();
		}

		// Token: 0x0603BEF8 RID: 245496 RVA: 0x00F32550 File Offset: 0x00F30750
		private void Submit()
		{
			if (this.Blackboard.ContainTag(EBehaviorTreeTag.RollbackWaiting))
			{
				return;
			}
			if (this.Blackboard.IsSuspend())
			{
				return;
			}
			this.OnBeforeSubmitNode();
			ControllerBase<GeneralLogicTreeController>.Instance.RequestSubmitAwakeAndLoadEntityNode(this.Context, new Action<bool>(this.OnAfterSubmitNode));
		}

		// Token: 0x0603BEF9 RID: 245497 RVA: 0x00F3259C File Offset: 0x00F3079C
		private void OnBeforeSubmitNode()
		{
			this.SubmitState = 1;
		}

		// Token: 0x0603BEFA RID: 245498 RVA: 0x00F325A5 File Offset: 0x00F307A5
		private void OnAfterSubmitNode(bool submitSuccess)
		{
			this.SubmitState = (submitSuccess ? 2 : 0);
		}

		// Token: 0x04021AD8 RID: 137944
		[Nullable(2)]
		private List<int> EntityIds;

		// Token: 0x04021AD9 RID: 137945
		private int SubmitState;

		// Token: 0x04021ADA RID: 137946
		private bool NeedCheckVisible;

		// Token: 0x0200BD64 RID: 48484
		private class ESubmitState
		{
			// Token: 0x0403A577 RID: 238967
			public const int BeforeSubmit = 0;

			// Token: 0x0403A578 RID: 238968
			public const int Submitting = 1;

			// Token: 0x0403A579 RID: 238969
			public const int Submitted = 2;
		}
	}
}
