using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020029AE RID: 10670
public class ShipTowerCoverRoleItem : GridProxyAbstract<int>
{
	// Token: 0x06015469 RID: 87145 RVA: 0x005E56E0 File Offset: 0x005E38E0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture))
		};
	}

	// Token: 0x0601546A RID: 87146 RVA: 0x005E5704 File Offset: 0x005E3904
	public override void Refresh(int roleId, bool isSelected, int gridIndex)
	{
		base.SetRoleIcon(ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value.RoleHeadIcon, base.GetTexture(0), roleId, null, null);
	}

	// Token: 0x02008D00 RID: 36096
	private static class EChildType
	{
		// Token: 0x0402F6DE RID: 194270
		public const int TextureRole = 0;
	}
}
