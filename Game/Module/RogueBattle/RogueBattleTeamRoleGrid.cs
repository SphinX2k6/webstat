using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200522C RID: 21036
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleTeamRoleGrid : LoopScrollMediumItemGrid<IRogueBattleTeamRoleGridInfo>
	{
		// Token: 0x06035E50 RID: 220752 RVA: 0x00D90DD4 File Offset: 0x00D8EFD4
		protected override void OnRefresh(IRogueBattleTeamRoleGridInfo data, bool isSelected, int gridIndex)
		{
			int dataId = data.RoleData.GetDataId();
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(dataId, true);
			RoleInfo roleConfig = roleDataById.GetRoleConfig();
			int incIdByRoleId = ModelBase<RogueBattleModel>.Instance.GetIncIdByRoleId(dataId);
			RogueResRole roleInfoById = ModelBase<RogueBattleModel>.Instance.GetRoleInfoById(incIdByRoleId);
			int roleIndex = ModelBase<RoleSelectModel>.Instance.GetRoleIndex(dataId);
			int roleSkinId = roleDataById.GetRoleSkinId();
			IMediumLevelAndStar lvAndStar = new MediumLevelAndStar
			{
				Star = new int?(roleInfoById.Level)
			};
			CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
			{
				ItemConfigId = new int?(dataId),
				SkinId = roleSkinId,
				Index = ((roleIndex > 0) ? new int?(roleIndex) : null),
				ElementId = new int?(roleConfig.ElementId),
				FrameEffect = new bool?(data.IsLinkOn),
				LvAndStar = lvAndStar,
				Data = data
			};
			base.Apply<CharacterMediumItemGrid>(parameters);
			bool bSelected = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Contains(dataId);
			this.SetSelected(bSelected, true);
		}

		// Token: 0x06035E51 RID: 220753 RVA: 0x00D90ED2 File Offset: 0x00D8F0D2
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
		}

		// Token: 0x06035E52 RID: 220754 RVA: 0x00D90EDC File Offset: 0x00D8F0DC
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x06035E53 RID: 220755 RVA: 0x00D90EE6 File Offset: 0x00D8F0E6
		public void OnForceSelected(bool bSelected)
		{
			this.SetSelected(bSelected, true);
		}
	}
}
