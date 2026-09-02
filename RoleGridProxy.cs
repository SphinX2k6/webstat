using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200123C RID: 4668
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class RoleGridProxy : GridProxyAbstract<RoleData>
{
	// Token: 0x06007C5D RID: 31837 RVA: 0x0020B6D0 File Offset: 0x002098D0
	protected override void OnStart()
	{
		AActor rootActor = base.GetRootActor();
		if (rootActor == null)
		{
			return;
		}
		this.RoleGrid = new SmallItemGrid();
		this.RoleGrid.CreateThenShowByActor(rootActor, null);
	}

	// Token: 0x06007C5E RID: 31838 RVA: 0x0020B700 File Offset: 0x00209900
	public override void Refresh(RoleData data, bool isSelected, int gridIndex)
	{
		if (this.RoleGrid == null)
		{
			return;
		}
		if (data.RoleId > 0)
		{
			RoleConfig instance = ConfigBase<RoleConfig>.Instance;
			RoleInfo? roleInfo = (instance != null) ? instance.GetRoleConfig(data.RoleId) : null;
			CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
			{
				Data = null,
				ItemConfigId = new int?(data.RoleId),
				SkinId = new int?(0),
				ElementId = new int?((roleInfo != null) ? roleInfo.GetValueOrDefault().ElementId : 0),
				BottomTextId = "Text_LevelShow_Text",
				BottomTextParameter = new object[]
				{
					data.RoleLevel
				}
			};
			this.RoleGrid.ApplyCharacterSmallItemGrid(parameters);
			UUIExtendToggle itemGridExtendToggle = this.RoleGrid.GetItemGridExtendToggle();
			if (itemGridExtendToggle != null)
			{
				itemGridExtendToggle.SetActive(false, false);
			}
			this.RoleGrid.SetExtendToggleEnable(false, false);
			return;
		}
		EmptySmallItemGrid parameters2 = new EmptySmallItemGrid();
		this.RoleGrid.ApplyEmptyWithoutAddSmallItemGrid(parameters2);
		this.RoleGrid.SetExtendToggleEnable(false, false);
	}

	// Token: 0x06007C5F RID: 31839 RVA: 0x0020B80D File Offset: 0x00209A0D
	public override object GetKey(RoleData data, int displayIndex)
	{
		return displayIndex;
	}

	// Token: 0x04003B76 RID: 15222
	[Nullable(2)]
	private SmallItemGrid RoleGrid;
}
