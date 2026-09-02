using System;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200569E RID: 22174
	public class RogueResTrialRoleItem : LoopScrollMediumItemGrid<int>
	{
		// Token: 0x06038756 RID: 231254 RVA: 0x00E4DAEC File Offset: 0x00E4BCEC
		protected override void OnRefresh(int roleId, bool isSelected, int gridIndex)
		{
			RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value;
			CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
			{
				ItemConfigId = new int?(roleId),
				SkinId = value.SkinId,
				BottomTextId = value.Name,
				ElementId = new int?(value.ElementId),
				Data = value
			};
			base.Apply<CharacterMediumItemGrid>(parameters);
		}
	}
}
