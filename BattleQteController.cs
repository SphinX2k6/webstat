using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Component;

// Token: 0x0200260A RID: 9738
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class BattleQteController : ControllerBase<BattleQteController>
{
	// Token: 0x06013178 RID: 78200 RVA: 0x0054B46C File Offset: 0x0054966C
	[return: Nullable(2)]
	public BattleQteContext StartBattleQte(int battleQteId, long messageId, EntityHandle entityHandle, EBattleQteSource source)
	{
		BattleQteController.<>c__DisplayClass0_0 CS$<>8__locals1 = new BattleQteController.<>c__DisplayClass0_0();
		string text = null;
		if (ControllerBase<CommonQteController>.Instance.IsInQte())
		{
			text = "当前存在执行中的Qte, 无法开始新的Qte";
		}
		else if (ControllerBase<CommonQteController>.Instance.IsPreloading())
		{
			text = "Qte预加载中, 无法开始新的Qte";
		}
		else
		{
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			if (instance != null && instance.IsMulti)
			{
				text = "联机状态下不能触发战斗Qte";
			}
			else if (Singleton<Time>.Instance.FlowTimeDilation == 0f)
			{
				text = "副本时停中, 不能触发战斗Qte";
			}
			else
			{
				SceneTeamModel instance2 = ModelBase<SceneTeamModel>.Instance;
				SceneTeamItem sceneTeamItem = (instance2 != null) ? instance2.GetCurrentTeamItem : null;
				EntityHandle entityHandle2 = (sceneTeamItem != null) ? sceneTeamItem.EntityHandle : null;
				WorldEntity worldEntity = (entityHandle2 != null) ? entityHandle2.Entity : null;
				if (entityHandle2 == null || !entityHandle2.Valid || worldEntity == null)
				{
					text = "当前角色实体无效, 不能触发战斗Qte";
				}
				else if (sceneTeamItem != null && sceneTeamItem.IsDead())
				{
					text = "当前角色已死亡, 不能触发战斗Qte";
				}
				else
				{
					PawnTimeScaleComponent component = worldEntity.GetComponent<PawnTimeScaleComponent>();
					if (component != null && component.HasPauseLock())
					{
						text = "当前角色大招时停中, 不能触发战斗Qte";
					}
				}
			}
		}
		if (text != null)
		{
			return null;
		}
		BattleQteController.<>c__DisplayClass0_0 CS$<>8__locals2 = CS$<>8__locals1;
		BattleQteModel instance3 = ModelBase<BattleQteModel>.Instance;
		CS$<>8__locals2.context = ((instance3 != null) ? instance3.CreateBattleQteContext(battleQteId, messageId, entityHandle, source) : null);
		if (CS$<>8__locals1.context == null)
		{
			return null;
		}
		CommonQteContextBase commonQteContextBase = ControllerBase<CommonQteController>.Instance.StartQte(CS$<>8__locals1.context.CommonQteId, delegate(CommonQteContextBase _)
		{
			CS$<>8__locals1.context.QteSuccess();
		}, delegate(CommonQteContextBase _)
		{
			CS$<>8__locals1.context.QteFail();
		}, EQteSource.Battle, null);
		if (commonQteContextBase != null)
		{
			CS$<>8__locals1.context.CommonQteHandleId = commonQteContextBase.HandleId;
			BattleQteModel instance4 = ModelBase<BattleQteModel>.Instance;
			if (instance4 != null)
			{
				instance4.SetCurrentBattleQte(CS$<>8__locals1.context);
			}
			return CS$<>8__locals1.context;
		}
		return null;
	}
}
