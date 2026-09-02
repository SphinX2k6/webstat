using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001244 RID: 4676
public class BabelTowerSettlementRoleItem : GridProxyAbstract<int>
{
	// Token: 0x06007C94 RID: 31892 RVA: 0x0020C60C File Offset: 0x0020A80C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007C95 RID: 31893 RVA: 0x0020C654 File Offset: 0x0020A854
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(data).Value;
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(data, true);
		int num = (roleDataById != null) ? roleDataById.GetRoleSkinId() : value.SkinId;
		RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(num);
		UUITexture texture = base.GetTexture(0);
		if (roleSkinConfig != null)
		{
			base.SetTextureByPath(roleSkinConfig.GetValueOrDefault().Card, texture, null, null);
			return;
		}
		base.SetRoleSkinIcon(value.Card, texture, num, null, null);
	}

	// Token: 0x020075B5 RID: 30133
	private class EComponent
	{
		// Token: 0x040289B4 RID: 166324
		public const int IconTexture = 0;
	}
}
