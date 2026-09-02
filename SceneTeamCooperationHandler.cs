using System;
using System.Runtime.CompilerServices;

// Token: 0x020017B1 RID: 6065
public class SceneTeamCooperationHandler : ICooperationHandler
{
	// Token: 0x0600AB24 RID: 43812 RVA: 0x002DBDE0 File Offset: 0x002D9FE0
	[NullableContext(1)]
	public bool Trigger(SceneTeamItem goDownRole, SceneTeamItem goBattleRole)
	{
		EntityHandle entityHandle = goBattleRole.EntityHandle;
		bool isInQte = entityHandle.Entity.GetComponent<RoleQteComponent>().IsInQte;
		bool flag = entityHandle.Entity.CheckGetComponent<RoleTeamComponent>().IsChangeRoleCoolDown();
		if (!isInQte)
		{
			if (flag)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamInCD", Array.Empty<object>());
				return false;
			}
			BaseTagComponent component = goDownRole.EntityHandle.Entity.GetComponent<BaseTagComponent>();
			if (component.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.被击硬直时间"]) && component.HasAnyTag(SceneTeamDefine.beHitTagList))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneTeam;
				ELogAuthor author = ELogAuthor.LYY;
				string message = "被击硬直时间无法换人";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", goDownRole.GetConfigId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
		}
		ControllerBase<SceneTeamController>.Instance.RequestChangeRole(goBattleRole.GetCreatureDataId(), new RequestChangeRoleParams
		{
			FilterSameRole = new bool?(true),
			GoDownWaitSkillEnd = new bool?(true),
			ForceInheritTransform = new bool?(false)
		});
		return true;
	}

	// Token: 0x0600AB25 RID: 43813 RVA: 0x002DBED5 File Offset: 0x002DA0D5
	public void Clear()
	{
	}
}
