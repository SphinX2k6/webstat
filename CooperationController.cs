using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.DeadRevive;

// Token: 0x020017AD RID: 6061
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class CooperationController : ControllerBase<CooperationController>
{
	// Token: 0x0600AB18 RID: 43800 RVA: 0x002DB808 File Offset: 0x002D9A08
	public void FormationInputHandler(string actionName)
	{
		int num = -1;
		if (!(actionName == "切换角色1"))
		{
			if (!(actionName == "切换角色2"))
			{
				if (!(actionName == "切换角色3"))
				{
					if (actionName == "切换角色4")
					{
						num = 4;
					}
				}
				else
				{
					num = 3;
				}
			}
			else
			{
				num = 2;
			}
		}
		else
		{
			num = 1;
		}
		if (num < 0)
		{
			return;
		}
		BattleUiFormationPanelData formationPanelData = ModelBase<BattleUiModel>.Instance.FormationPanelData;
		long? num2;
		if (formationPanelData == null)
		{
			num2 = null;
		}
		else
		{
			FormationItemData itemData = formationPanelData.GetItemData(num);
			num2 = ((itemData != null) ? new long?(itemData.CreatureDataId) : null);
		}
		long? num3 = num2;
		long valueOrDefault = num3.GetValueOrDefault();
		this.TryCooperate(valueOrDefault);
	}

	// Token: 0x0600AB19 RID: 43801 RVA: 0x002DB8A8 File Offset: 0x002D9AA8
	public unsafe void TryCooperate(long creatureDataId)
	{
		if (ModelBase<SceneTeamModel>.Instance.ChangingRole)
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "在换人请求返回前尝试换人", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		SceneTeamItem getCurrentTeamItem = instance.GetCurrentTeamItem;
		EntityHandle entityHandle = (getCurrentTeamItem != null) ? getCurrentTeamItem.EntityHandle : null;
		if (entityHandle == null || getCurrentTeamItem.GetCreatureDataId() == creatureDataId)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SceneTeam;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "下场角色实体不存在或相同";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		BaseTagComponent baseTagComponent = entityHandle.Entity.CheckGetComponent<BaseTagComponent>();
		SceneTeamItem teamItem = instance.GetTeamItem(creatureDataId, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.CreatureDataId
		});
		if (((teamItem != null) ? teamItem.EntityHandle : null) == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.SceneTeam;
			ELogAuthor author2 = ELogAuthor.LYY;
			string message2 = "上场角色实体不存在";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
			instance3.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		if (!teamItem.IsMyRole())
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.SceneTeam;
			ELogAuthor author3 = ELogAuthor.LYY;
			string message3 = "上场角色为其他玩家的角色";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
			instance4.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			if (teamItem.IsDead())
			{
				ControllerBase<DeadReviveController>.Instance.CheckOtherPlayerReviveCooldown(teamItem.GetPlayerId(), teamItem.GetCreatureDataId());
				return;
			}
			if (!baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]))
			{
				this.CooperateAction(getCurrentTeamItem, teamItem);
			}
			return;
		}
		else
		{
			if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]))
			{
				if (teamItem.IsDead())
				{
					ControllerBase<DeadReviveController>.Instance.TryReviveRoleWhenCurrentRoleDead(teamItem.GetCreatureDataId(), teamItem.GetConfigId);
				}
				return;
			}
			if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.溺水"]))
			{
				return;
			}
			bool flag = ModelBase<TowerModel>.Instance.CheckInTower();
			bool flag2 = ModelBase<ShipTowerModel>.Instance.CheckInBattleShipTower();
			bool flag3 = flag || flag2;
			if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]))
			{
				if (flag3 && !ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("CannotChangeRoleBeforeStartBattle", Array.Empty<object>());
				}
				return;
			}
			if (instance.CurrentGroupType.GetValueOrDefault() != ETeamGroupType.Battle)
			{
				Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "当前正在非战斗编队组，不能切角色", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (teamItem.IsDead())
			{
				if (ModelBase<SceneTeamModel>.Instance.IsAllDid() || flag)
				{
					if (flag)
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InstanceDungeonShieldViewCantOpen", Array.Empty<object>());
					}
					return;
				}
				ControllerBase<DeadReviveController>.Instance.TryReviveRole(teamItem.GetCreatureDataId(), teamItem.GetConfigId, false);
				return;
			}
			else
			{
				EGoBattleResultType egoBattleResultType = teamItem.CanGoBattle();
				if (egoBattleResultType != EGoBattleResultType.Success)
				{
					Log instance5 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.SceneTeam;
					ELogAuthor author4 = ELogAuthor.LYY;
					string message4 = "上场角色无法换人";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Result", egoBattleResultType);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("roleId", teamItem.GetConfigId);
					instance5.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				this.CooperateAction(getCurrentTeamItem, teamItem);
				return;
			}
		}
	}

	// Token: 0x0600AB1A RID: 43802 RVA: 0x002DBBB0 File Offset: 0x002D9DB0
	private void CooperateAction(SceneTeamItem goDownRole, SceneTeamItem goBattleRole)
	{
		ICooperationHandler[] handlers = ModelBase<CooperationModel>.Instance.GetHandlers();
		int num = 0;
		while (num < handlers.Length && !handlers[num].Trigger(goDownRole, goBattleRole))
		{
			num++;
		}
	}
}
