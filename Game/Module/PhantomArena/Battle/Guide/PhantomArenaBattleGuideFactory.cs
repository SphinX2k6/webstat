using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Guide
{
	// Token: 0x02005610 RID: 22032
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleGuideFactory
	{
		// Token: 0x0603829E RID: 230046 RVA: 0x00E38EA0 File Offset: 0x00E370A0
		public static IPhantomArenaTabViewModelBase GetGuideData(EBvbPlayerOperationType type, BvbPlayerOperationConstraint data)
		{
			Func<EBvbPlayerOperationType, BvbPlayerOperationConstraint, IPhantomArenaTabViewModelBase> func;
			if (!PhantomArenaBattleGuideFactory.GuideDataMap.TryGetValue(type, out func))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "声骸竞技场定制引导类型不存在!代码未进行注册";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
				defaultInterpolatedStringHandler.AppendLiteral("未注册的声骸竞技场定制类型: ");
				defaultInterpolatedStringHandler.AppendFormatted<EBvbPlayerOperationType>(type);
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return func(type, data);
		}

		// Token: 0x04020163 RID: 131427
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EBvbPlayerOperationType, Func<EBvbPlayerOperationType, BvbPlayerOperationConstraint, IPhantomArenaTabViewModelBase>> GuideDataMap = new Dictionary<EBvbPlayerOperationType, Func<EBvbPlayerOperationType, BvbPlayerOperationConstraint, IPhantomArenaTabViewModelBase>>
		{
			{
				EBvbPlayerOperationType.BvbDeploy,
				(EBvbPlayerOperationType type, BvbPlayerOperationConstraint data) => new PhantomArenaBattleGuideSettingCard(type, data)
			},
			{
				EBvbPlayerOperationType.BvbEvolution,
				(EBvbPlayerOperationType type, BvbPlayerOperationConstraint data) => new PhantomArenaBattleGuideEvolveCard(type, data)
			},
			{
				EBvbPlayerOperationType.BvbChangeHandCard,
				(EBvbPlayerOperationType type, BvbPlayerOperationConstraint data) => new PhantomArenaBattleGuideMagicUseCardFromHand(type, data)
			},
			{
				EBvbPlayerOperationType.BvbChangeBoardCard,
				(EBvbPlayerOperationType type, BvbPlayerOperationConstraint data) => new PhantomArenaBattleGuideMagicUseCardFromMonster(type, data)
			},
			{
				EBvbPlayerOperationType.BvbRecycleHandCard,
				(EBvbPlayerOperationType type, BvbPlayerOperationConstraint data) => new PhantomArenaBattleGuideRecycleCardFromHand(type, data)
			},
			{
				EBvbPlayerOperationType.BvbRecycleBoardCard,
				(EBvbPlayerOperationType type, BvbPlayerOperationConstraint data) => new PhantomArenaBattleGuideRecycleCardFromMonster(type, data)
			},
			{
				EBvbPlayerOperationType.BvbEndTurn,
				(EBvbPlayerOperationType type, BvbPlayerOperationConstraint data) => new PhantomArenaBattleGuideEndTime(type, data)
			},
			{
				EBvbPlayerOperationType.BvbUseItemCardSkill,
				(EBvbPlayerOperationType type, BvbPlayerOperationConstraint data) => new PhantomArenaBattleGuideUseItemCardSkill(type, data)
			},
			{
				EBvbPlayerOperationType.BvbUseFieldCardSkill,
				(EBvbPlayerOperationType type, BvbPlayerOperationConstraint data) => new PhantomArenaBattleGuideUseFieldCardSkill(type, data)
			},
			{
				EBvbPlayerOperationType.BvbSelectCard,
				(EBvbPlayerOperationType type, BvbPlayerOperationConstraint data) => new PhantomArenaBattleGuideSelectCard(type, data)
			}
		};
	}
}
