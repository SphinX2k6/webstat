using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x0200260B RID: 9739
public static class BattleQteCustomAction
{
	// Token: 0x0601317A RID: 78202 RVA: 0x0054B5F4 File Offset: 0x005497F4
	public static void battleQteChangeRole(int? roleId = null)
	{
		SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
		if (getCurrentTeamItem != null)
		{
			EntityHandle entityHandle = getCurrentTeamItem.EntityHandle;
			bool? flag;
			if (entityHandle == null)
			{
				flag = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				if (entity == null)
				{
					flag = null;
				}
				else
				{
					BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
					flag = ((component != null) ? new bool?(component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"])) : null);
				}
			}
			bool? flag2 = flag;
			if (flag2.GetValueOrDefault())
			{
				return;
			}
		}
		List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false);
		int count = teamItems.Count;
		int num = teamItems.IndexOf(getCurrentTeamItem);
		for (int i = 1; i < count; i++)
		{
			int num2 = num + i;
			if (num2 >= count)
			{
				num2 -= count;
			}
			SceneTeamItem sceneTeamItem = teamItems[num2];
			if ((roleId == null || roleId.Value == 0 || ConfigBase<RoleConfig>.Instance.GetBaseRoleId(sceneTeamItem.GetConfigId) == roleId.Value) && sceneTeamItem != null && sceneTeamItem.CanGoBattle() == EGoBattleResultType.Success)
			{
				ControllerBase<CooperationController>.Instance.TryCooperate(sceneTeamItem.GetCreatureDataId());
				return;
			}
		}
	}
}
