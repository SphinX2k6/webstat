using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005214 RID: 21012
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleSettleInfoRoleGrid : LoopScrollMediumItemGrid<RogueResGainData>
	{
		// Token: 0x06035DF0 RID: 220656 RVA: 0x00D8F000 File Offset: 0x00D8D200
		protected override void OnRefresh(RogueResGainData data, bool isSelected, int gridIndex)
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(data.RogueResRole.RoleIdOrTrialRoleId, true);
			if (roleDataById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RogueBattle;
				ELogAuthor author = ELogAuthor.LPH;
				string message = "刷新角色信息失败，角色配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId:", data.RogueResRole.RoleIdOrTrialRoleId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
			{
				ItemConfigId = new int?(data.RogueResRole.RoleIdOrTrialRoleId),
				SkinId = roleDataById.GetRoleSkinId(),
				ElementId = new int?(roleDataById.GetElementInfo().Value.Id),
				Data = data,
				IsTrialRoleVisible = new bool?(roleDataById.IsTrialRole())
			};
			base.Apply<CharacterMediumItemGrid>(parameters);
			ItemGridComponent component = base.RefreshComponent(typeof(<RogueBattleSettleInfoRoleGrid>F0E37ABE6599E9F57B3333E379A1AB96877BE20C8298B0836CD56EC51AFB66B94__RogueBattleSettleInfoRoleGridLevelComponent), new bool?(true), data);
			base.SetComponentVisible(component, true);
		}
	}
}
