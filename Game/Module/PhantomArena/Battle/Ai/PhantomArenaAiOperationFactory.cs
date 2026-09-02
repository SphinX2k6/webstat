using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x02005647 RID: 22087
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaAiOperationFactory
	{
		// Token: 0x060384C6 RID: 230598 RVA: 0x00E40AF4 File Offset: 0x00E3ECF4
		public static NpcAiOperation GetAiOperation(EPhantomArenaAiOperationType type, object param)
		{
			if (!PhantomArenaAiOperationFactory.AiOperationMap.ContainsKey(type))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "Ai操作类型不存在!代码未进行注册";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
				defaultInterpolatedStringHandler.AppendLiteral("未注册的Buff类型: ");
				defaultInterpolatedStringHandler.AppendFormatted<EPhantomArenaAiOperationType>(type);
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return PhantomArenaAiOperationFactory.AiOperationMap[type](param);
		}

		// Token: 0x04020200 RID: 131584
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EPhantomArenaAiOperationType, Func<object, NpcAiOperation>> AiOperationMap = new Dictionary<EPhantomArenaAiOperationType, Func<object, NpcAiOperation>>
		{
			{
				EPhantomArenaAiOperationType.SettingCard,
				(object param) => new SettingCardOperation((NpcPhantomBattleEnterSlotInfo)param)
			},
			{
				EPhantomArenaAiOperationType.EvolveCard,
				(object param) => new EvolveCardOperation((NpcPhantomBattleEvolveInfo)param)
			},
			{
				EPhantomArenaAiOperationType.ChangeCard,
				(object param) => new ChangeCardOperation((NpcPhantomBattleSlotInsteadInfo)param)
			},
			{
				EPhantomArenaAiOperationType.UseCardSkill,
				(object param) => new UseCardSkillOperation((NpcPhantomBattleCardSkillInfo)param)
			},
			{
				EPhantomArenaAiOperationType.UseRoleSkill,
				(object param) => new UseRoleSkillOperation((NpcPhantomBattleCardRoleSkillInfo)param)
			},
			{
				EPhantomArenaAiOperationType.AddBuff,
				(object param) => new AddBuffOperation((PhantomBattleBuffTriggerInfo)param)
			},
			{
				EPhantomArenaAiOperationType.BackToLibrary,
				(object param) => new BackToLibraryOperation((NpcPhantomBattleBackCardLibrary)param)
			},
			{
				EPhantomArenaAiOperationType.SkillTrigger,
				(object param) => new SkillTriggerOperation((PhantomBattleSkillTriggerInfo)param)
			},
			{
				EPhantomArenaAiOperationType.GamerStatus,
				(object param) => new GamerStatusOperation((NpcPhantomBattleGamerStatusInfo)param)
			},
			{
				EPhantomArenaAiOperationType.CardAttr,
				(object param) => new CardAttrOperation((NpcPhantomBattleCardAttrInfo)param)
			},
			{
				EPhantomArenaAiOperationType.DiscardCard,
				(object param) => new DiscardCardOperation((NpcPhantomBattleDiscardInfo)param)
			},
			{
				EPhantomArenaAiOperationType.FourCostTask,
				(object param) => new FourCostTaskOperation((NpcPhantomFourCTaskDealCardInfo)param)
			},
			{
				EPhantomArenaAiOperationType.LeaveSlot,
				(object param) => new LeaveSlotOperation((NpcPhantomLeaveSlot)param)
			},
			{
				EPhantomArenaAiOperationType.BackSlotCardLibrary,
				(object param) => new BackSlotCardLibraryOperation((NpcPhantomBattleBackSlotCardLibrary)param)
			},
			{
				EPhantomArenaAiOperationType.ReserveCard,
				(object param) => new ReserveCardOperation((NpcPhantomBattleReserveCardInfo)param)
			},
			{
				EPhantomArenaAiOperationType.NpcCardUpdate,
				(object param) => new NpcCardUpdateOperation((PhantomBattleNpcCardUpdateInfo)param)
			},
			{
				EPhantomArenaAiOperationType.ClickCardSkill,
				(object param) => new ClickCardSkillOperation((NpcPhantomBattleCardDurableSkillInfo)param)
			}
		};
	}
}
