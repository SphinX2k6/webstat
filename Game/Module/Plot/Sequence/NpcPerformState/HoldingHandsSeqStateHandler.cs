using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.Sequence.NpcPerformState
{
	// Token: 0x0200539D RID: 21405
	[NullableContext(1)]
	[Nullable(0)]
	public class HoldingHandsSeqStateHandler : SeqNpcPerformStateHandler
	{
		// Token: 0x17008DAD RID: 36269
		// (get) Token: 0x06036953 RID: 223571 RVA: 0x00DCCBF5 File Offset: 0x00DCADF5
		public override ENpcGroupPerformType PerformType
		{
			get
			{
				return ENpcGroupPerformType.HandInHand;
			}
		}

		// Token: 0x17008DAE RID: 36270
		// (get) Token: 0x06036954 RID: 223572 RVA: 0x00DCCBF8 File Offset: 0x00DCADF8
		public override ENpcRelationType RelationType
		{
			get
			{
				return ENpcRelationType.HoldingHands;
			}
		}

		// Token: 0x06036955 RID: 223573 RVA: 0x00DCCBFB File Offset: 0x00DCADFB
		[return: Nullable(2)]
		public override NpcRelation Capture(string key)
		{
			return ModelBase<HoldingHandsModel>.Instance.GetRelation(key);
		}

		// Token: 0x06036956 RID: 223574 RVA: 0x00DCCC08 File Offset: 0x00DCAE08
		public unsafe override void Restore(NpcRelation relation, string reason)
		{
			HoldingHandsRelation holdingHandsRelation = relation as HoldingHandsRelation;
			CharacterModel instance = ModelBase<CharacterModel>.Instance;
			CharacterHoldingHandsComponent leader = holdingHandsRelation.Leader;
			EntityHandle handleByEntity = instance.GetHandleByEntity((leader != null) ? leader.Entity : null);
			CharacterModel instance2 = ModelBase<CharacterModel>.Instance;
			CharacterHoldingHandsComponent follower = holdingHandsRelation.Follower;
			EntityHandle handleByEntity2 = instance2.GetHandleByEntity((follower != null) ? follower.Entity : null);
			if (handleByEntity == null || handleByEntity2 == null)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "[SeqNpcPerformState] 牵手者获取失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("leaderHandle", handleByEntity);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("followerHandle", handleByEntity2);
				instance3.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			ControllerBase<HoldingHandsController>.Instance.RequestHoldHands(holdingHandsRelation.Key, handleByEntity, handleByEntity2, holdingHandsRelation.LeaderHandType, new bool?(false), false, reason);
		}
	}
}
