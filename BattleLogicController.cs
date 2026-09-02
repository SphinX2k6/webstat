using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.UI.Manager;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200346A RID: 13418
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class BattleLogicController : ControllerBase<BattleLogicController>
{
	// Token: 0x0601C3B1 RID: 115633 RVA: 0x0086C07C File Offset: 0x0086A27C
	[CombatListen(ENotifyMessageId.EntityLivingStatusNotify, true, false)]
	public static void ExecuteEntityLivingStatus(Entity entity, EntityLivingStatusNotify notify, [Nullable(2)] CombatCommon combatCommon = null)
	{
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entity.Id);
		if (entityById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "[CreatureController.EntityLivingStatusNotify] EntityLivingStatusNotify失败, Entity无效或不存在。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", notify.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		long value = Singleton<MathUtils>.Instance.LongToBigInt((combatCommon != null) ? combatCommon.MessageId : 0L);
		Singleton<MathUtils>.Instance.LongToBigInt((combatCommon != null) ? combatCommon.PreMessageId : 0L);
		switch (notify.LivingStatus)
		{
		case LivingStatus.Alive:
			BattleLogicController.ExecuteReviveLogic(entityById);
			break;
		case LivingStatus.Dead:
		{
			BattleLogicController.BroadcastDead(entityById);
			bool flag = false;
			for (int i = 0; i < notify.DropVisionItem.Count; i++)
			{
				DropVisionItemResult dropVisionItemResult = notify.DropVisionItem[i];
				if (dropVisionItemResult.Drop)
				{
					int playerId = dropVisionItemResult.PlayerId;
					int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
					if (playerId == id.GetValueOrDefault() & id != null)
					{
						CharacterAttachComponent component = entity.GetComponent<CharacterAttachComponent>();
						if (component != null)
						{
							component.DetachFromHost(true, false, false, null);
						}
						entity.Disable("[BattleLogicController.BattleLogicController] 被收服的Entity先隐藏");
						flag = true;
						Singleton<EventSystem>.Instance.Emit<int>(EEventName.CharOnRoleDead, entity.Id);
						Singleton<EventSystem>.Instance.EmitWithTarget(entity, EEventName.CharOnRoleDeadTargetSelf);
					}
				}
			}
			if (!flag)
			{
				BaseDeathComponent component2 = entity.GetComponent<BaseDeathComponent>();
				if (component2 == null)
				{
					return;
				}
				component2.ExecuteDeath(new long?(value));
				return;
			}
			break;
		}
		case LivingStatus.Init:
			break;
		default:
			return;
		}
	}

	// Token: 0x0601C3B2 RID: 115634 RVA: 0x0086C1F8 File Offset: 0x0086A3F8
	public static void OnEntityLivingStatusNotify(EntityLivingStatusNotify notify)
	{
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(Singleton<MathUtils>.Instance.LongToNumber(notify.Id));
		if (entity == null || !entity.Valid || entity.Entity == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "[CreatureController.EntityLivingStatusNotify] EntityLivingStatusNotify失败, Entity无效或不存在。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", notify.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		BattleLogicController.ExecuteEntityLivingStatus(entity.Entity, notify, null);
	}

	// Token: 0x0601C3B3 RID: 115635 RVA: 0x0086C274 File Offset: 0x0086A474
	private static void ExecuteReviveLogic(EntityHandle handle)
	{
		if (!handle.Valid)
		{
			return;
		}
		if (!handle.IsInit)
		{
			WorldEntity entity = handle.Entity;
			CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
			if (creatureDataComponent == null)
			{
				return;
			}
			creatureDataComponent.SetLivingStatus(LivingStatus.Alive);
			return;
		}
		else
		{
			WorldEntity entity2 = handle.Entity;
			if (entity2 == null)
			{
				return;
			}
			RoleDeathComponent component = entity2.GetComponent<RoleDeathComponent>();
			if (component == null)
			{
				return;
			}
			component.ExecuteRevive();
			return;
		}
	}

	// Token: 0x0601C3B4 RID: 115636 RVA: 0x0086C2CC File Offset: 0x0086A4CC
	private static void BroadcastDead(EntityHandle handle)
	{
		BaseActorComponent component = handle.Entity.GetComponent<BaseActorComponent>();
		AActor aactor = (component != null) ? component.Owner : null;
		BP_EventManager_C bpEventManager = GlobalData.BpEventManager;
		if (bpEventManager == null)
		{
			return;
		}
		当有角色死亡时 当有角色死亡时 = bpEventManager.当有角色死亡时;
		if (当有角色死亡时 == null)
		{
			return;
		}
		当有角色死亡时.Broadcast(aactor as TsBaseCharacter);
	}

	// Token: 0x0400E350 RID: 58192
	[StaticVariableRuleIgnore]
	private static readonly Stat BroadcastDeadStat = Stat.Create("BattleLogicController.BroadcastDeadStat", "", "STATGROUP_KuroBattle");

	// Token: 0x0400E351 RID: 58193
	[StaticVariableRuleIgnore]
	private static readonly Stat DisableEntityStat = Stat.Create("BattleLogicController.DisableEntityStat", "", "STATGROUP_KuroBattle");

	// Token: 0x0400E352 RID: 58194
	[StaticVariableRuleIgnore]
	private static readonly Stat ExecuteDeadLogicStat = Stat.Create("BattleLogicController.ExecuteDeadLogicStat", "", "STATGROUP_KuroBattle");

	// Token: 0x0400E353 RID: 58195
	[StaticVariableRuleIgnore]
	private static readonly Stat ExecuteReviveLogicStat = Stat.Create("BattleLogicController.ExecuteReviveLogicStat", "", "STATGROUP_KuroBattle");
}
