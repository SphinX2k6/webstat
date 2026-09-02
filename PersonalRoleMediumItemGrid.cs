using System;
using CSharpScript.Game.Module.Common.MediumItemGrid;

// Token: 0x0200243E RID: 9278
public class PersonalRoleMediumItemGrid : LoopScrollMediumItemGrid<int>
{
	// Token: 0x06011F08 RID: 73480 RVA: 0x004EF97C File Offset: 0x004EDB7C
	protected override void OnRefresh(int data, bool isSelected, int gridIndex)
	{
		this.RoleId = data;
		this.GirdIndex = gridIndex;
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data),
			SkinId = roleInstanceById.GetRoleSkinId(),
			BottomTextId = "Text_LevelShow_Text",
			BottomTextParameter = new object[]
			{
				roleInstanceById.GetLevelData().GetLevel()
			}
		};
		base.Apply<CharacterMediumItemGrid>(parameters);
	}

	// Token: 0x04008C93 RID: 35987
	private int RoleId;

	// Token: 0x04008C94 RID: 35988
	public int GirdIndex;
}
