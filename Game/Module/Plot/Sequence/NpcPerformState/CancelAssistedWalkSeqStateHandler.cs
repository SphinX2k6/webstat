using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move.AssistedWalk;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move.AttachMove;

namespace CSharpScript.Game.Module.Plot.Sequence.NpcPerformState
{
	// Token: 0x0200539C RID: 21404
	[NullableContext(1)]
	[Nullable(0)]
	public class CancelAssistedWalkSeqStateHandler : SeqNpcPerformStateHandler
	{
		// Token: 0x17008DAB RID: 36267
		// (get) Token: 0x0603694D RID: 223565 RVA: 0x00DCCAB1 File Offset: 0x00DCACB1
		public override ENpcGroupPerformType PerformType
		{
			get
			{
				return ENpcGroupPerformType.CancelSupportedWalking;
			}
		}

		// Token: 0x17008DAC RID: 36268
		// (get) Token: 0x0603694E RID: 223566 RVA: 0x00DCCAB4 File Offset: 0x00DCACB4
		public override ENpcRelationType RelationType
		{
			get
			{
				return ENpcRelationType.CancelAssistedWalk;
			}
		}

		// Token: 0x0603694F RID: 223567 RVA: 0x00DCCAB8 File Offset: 0x00DCACB8
		[return: Nullable(2)]
		public override NpcRelation Capture(string key)
		{
			if (Singleton<AttachMoveUtils>.Instance.GetRelation(key) == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "[SeqNpcPerformState] 取消搀扶登记失败：关系表中查不到 Key";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Key", key);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return new CancelAssistedWalkSeqRelation
			{
				Key = key
			};
		}

		// Token: 0x06036950 RID: 223568 RVA: 0x00DCCB08 File Offset: 0x00DCAD08
		public unsafe override void OnBattleCharacterHidden(NpcRelation relation, string reason)
		{
			CancelAssistedWalkSeqRelation cancelAssistedWalkSeqRelation = relation as CancelAssistedWalkSeqRelation;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "[SeqNpcPerformState] 实机角色隐藏后解除搀扶";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", cancelAssistedWalkSeqRelation.Key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			Singleton<AssistedWalkUtils>.Instance.RequestStopAssistedWalk(cancelAssistedWalkSeqRelation.Key, reason, global::EHandType.Right);
		}

		// Token: 0x06036951 RID: 223569 RVA: 0x00DCCB88 File Offset: 0x00DCAD88
		public override void Restore(NpcRelation relation, string reason)
		{
			CancelAssistedWalkSeqRelation cancelAssistedWalkSeqRelation = relation as CancelAssistedWalkSeqRelation;
			if (Singleton<AttachMoveUtils>.Instance.GetRelation(cancelAssistedWalkSeqRelation.Key) == null)
			{
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "[SeqNpcPerformState] 取消搀扶兜底补解";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Key", cancelAssistedWalkSeqRelation.Key);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<AssistedWalkUtils>.Instance.RequestStopAssistedWalk(cancelAssistedWalkSeqRelation.Key, reason, global::EHandType.Right);
		}
	}
}
