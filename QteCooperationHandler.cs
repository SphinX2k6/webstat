using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Struct;

// Token: 0x020017B0 RID: 6064
public class QteCooperationHandler : ICooperationHandler
{
	// Token: 0x0600AB21 RID: 43809 RVA: 0x002DBCA8 File Offset: 0x002D9EA8
	[NullableContext(1)]
	public unsafe bool Trigger(SceneTeamItem goDownRole, SceneTeamItem goBattleRole)
	{
		if (!goBattleRole.IsMyRole())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SceneTeam;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "上场角色为其他玩家的角色";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", goBattleRole.GetCreatureDataId());
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<SceneTeamController>.Instance.TryUseMultiQte(goBattleRole.EntityHandle);
			return true;
		}
		EntityHandle entityHandle = goDownRole.EntityHandle;
		EntityHandle entityHandle2 = goBattleRole.EntityHandle;
		RoleQteComponent component = entityHandle.Entity.GetComponent<RoleQteComponent>();
		RoleQteComponent component2 = entityHandle2.Entity.GetComponent<RoleQteComponent>();
		BaseTagComponent component3 = entityHandle.Entity.GetComponent<BaseTagComponent>();
		if (component == null || component2 == null)
		{
			return false;
		}
		SQteTag qteTagData = component2.GetQteTagData();
		if (qteTagData == null)
		{
			return false;
		}
		BaseTagComponent baseTagComponent = component3;
		<>y__InlineArray2<int> <>y__InlineArray = default(<>y__InlineArray2<int>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<int>, int>(ref <>y__InlineArray, 0) = GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"];
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<int>, int>(ref <>y__InlineArray, 1) = GameplayTagDefine.EGameplayTagId["行为状态.位置状态.水中"];
		ReadOnlySpan<int> readOnlySpan = <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<int>, int>(<>y__InlineArray, 2);
		bool flag = !baseTagComponent.HasAnyTag(readOnlySpan) && component2.IsQteReady(entityHandle);
		bool flag2 = false;
		if (flag)
		{
			component.UseExitSkill(entityHandle2);
			flag2 = component2.ExecuteQte(entityHandle);
		}
		return !(flag2 ? qteTagData.ChangeRoleOnQte : qteTagData.ChangeRole);
	}

	// Token: 0x0600AB22 RID: 43810 RVA: 0x002DBDD3 File Offset: 0x002D9FD3
	public void Clear()
	{
	}
}
