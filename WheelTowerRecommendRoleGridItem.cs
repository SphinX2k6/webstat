using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x0200164F RID: 5711
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WheelTowerRecommendRoleGridItem : LoopScrollMediumItemGrid<RoleDataWithBranch>
{
	// Token: 0x0600A05A RID: 41050 RVA: 0x0029F5DC File Offset: 0x0029D7DC
	protected override void OnRefresh(RoleDataWithBranch data, bool isSelected, int gridIndex)
	{
		int num = data.RoleId;
		if (ModelBase<RoleModel>.Instance.IsMainRole(data.RoleId))
		{
			num = ModelBase<RoleModel>.Instance.GetCorrectMainRoleConfig(data.RoleId).Value.Id;
		}
		bool flag = ModelBase<RoleModel>.Instance.IsHasRole(num);
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(num);
		if (roleConfig == null)
		{
			return;
		}
		CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
		{
			ItemConfigId = new int?(num),
			SkinId = roleConfig.Value.SkinId,
			BottomTextId = roleConfig.Value.Name,
			ElementId = new int?(roleConfig.Value.ElementId),
			IsDisable = new bool?(!flag),
			SkillBranchIndex = ((data.SkillBranchIndex > -1) ? new int?(data.SkillBranchIndex) : null)
		};
		base.SetUseFixedAsync(true);
		base.Apply<CharacterMediumItemGrid>(parameters);
	}

	// Token: 0x0600A05B RID: 41051 RVA: 0x0029F6E3 File Offset: 0x0029D8E3
	protected override bool OnCanExecuteChange()
	{
		return false;
	}
}
