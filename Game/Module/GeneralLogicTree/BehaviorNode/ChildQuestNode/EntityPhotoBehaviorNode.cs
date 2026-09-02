using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CE2 RID: 23778
	[NullableContext(2)]
	[Nullable(0)]
	public class EntityPhotoBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BF57 RID: 245591 RVA: 0x00F33EAD File Offset: 0x00F320AD
		public EntityPhotoBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BF58 RID: 245592 RVA: 0x00F33EC1 File Offset: 0x00F320C1
		public bool IsOverrideConfig()
		{
			return this.OverrideConfig != null;
		}

		// Token: 0x1700984E RID: 38990
		// (get) Token: 0x0603BF59 RID: 245593 RVA: 0x00F33ECC File Offset: 0x00F320CC
		public unsafe int RangeEntity
		{
			get
			{
				ITakePhoto2Condition overrideConfig = this.OverrideConfig;
				int? num;
				if (overrideConfig == null)
				{
					num = null;
				}
				else
				{
					ITakePhoto2PosCondition posCondition = overrideConfig.PosCondition;
					num = ((posCondition != null) ? new int?(posCondition.RangeEntity) : null);
				}
				int? num2 = num;
				int? num3;
				if (num2 == null)
				{
					ITakePhotoPosCondition takePlace = this.TakePlace;
					num3 = ((takePlace != null) ? new int?(takePlace.RangeEntity) : null);
				}
				else
				{
					num3 = num2;
				}
				int? num4 = num3;
				if (num4 == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Photo;
					ELogAuthor author = ELogAuthor.FZX;
					string message = "拍照节点未配置坐标";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TreeId", this.InnerTreeConfigId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("NodeId", this.InnerNodeId);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return 0;
				}
				return num4.Value;
			}
		}

		// Token: 0x0603BF5A RID: 245594 RVA: 0x00F33FB8 File Offset: 0x00F321B8
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
			ITakePhotoCondition takePhotoCondition = childQuestBtNode.Condition as ITakePhotoCondition;
			if (takePhotoCondition != null)
			{
				this.TakeTime = takePhotoCondition.TimeCondition;
				this.TakePlace = takePhotoCondition.PosCondition;
				this.TakeTargetArray = takePhotoCondition.PhotoTargets;
				return true;
			}
			ITakePhoto2Condition takePhoto2Condition = childQuestBtNode.Condition as ITakePhoto2Condition;
			if (takePhoto2Condition != null)
			{
				this.OverrideConfig = takePhoto2Condition;
				return true;
			}
			return false;
		}

		// Token: 0x0603BF5B RID: 245595 RVA: 0x00F3402A File Offset: 0x00F3222A
		public void UseSubmitNode()
		{
			this.SubmitNode(null);
		}

		// Token: 0x0603BF5C RID: 245596 RVA: 0x00F34034 File Offset: 0x00F32234
		public int? GetDungeonId()
		{
			Blackboard blackboard = this.Blackboard;
			if (blackboard == null)
			{
				return null;
			}
			return new int?(blackboard.DungeonId);
		}

		// Token: 0x04021AFE RID: 137982
		public ITakePhotoPosCondition TakePlace;

		// Token: 0x04021AFF RID: 137983
		public ITakePhotoTimeCondition TakeTime;

		// Token: 0x04021B00 RID: 137984
		[Nullable(1)]
		public List<IPhotoTarget> TakeTargetArray = new List<IPhotoTarget>();

		// Token: 0x04021B01 RID: 137985
		public ITakePhoto2Condition OverrideConfig;
	}
}
