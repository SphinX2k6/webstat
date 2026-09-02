using System;
using UnrealEngine;

// Token: 0x02001633 RID: 5683
public class WheelTowerCoverRecordRoleGridItem : LoopScrollSmallItemGrid<int>
{
	// Token: 0x0600A015 RID: 40981 RVA: 0x0029DCDB File Offset: 0x0029BEDB
	protected override void OnStart()
	{
		base.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
	}

	// Token: 0x0600A016 RID: 40982 RVA: 0x0029DD04 File Offset: 0x0029BF04
	protected override void OnRefresh(int roleId, bool isSelected, int gridIndex)
	{
		int num = ModelBase<WheelTowerModel>.Instance.TryGetRealRoleId(roleId);
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num, true);
		if (roleDataById == null)
		{
			return;
		}
		CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
		{
			Data = roleDataById,
			ItemConfigId = new int?(num),
			SkinId = new int?(roleDataById.GetRoleConfig().SkinId),
			BottomText = roleDataById.GetName(null),
			ElementId = new int?(roleDataById.GetRoleConfig().ElementId)
		};
		base.SetUseFixedAsync(true);
		base.Apply<CharacterSmallItemGrid>(parameters);
	}
}
