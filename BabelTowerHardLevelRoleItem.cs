using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200121A RID: 4634
internal class BabelTowerHardLevelRoleItem : GridProxyAbstract<int>
{
	// Token: 0x06007B10 RID: 31504 RVA: 0x00202D20 File Offset: 0x00200F20
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007B11 RID: 31505 RVA: 0x00202D8C File Offset: 0x00200F8C
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		RoleModel instance = ModelBase<RoleModel>.Instance;
		RoleDataBase roleDataBase = (instance != null) ? instance.GetRoleDataById(data, true) : null;
		if (roleDataBase == null)
		{
			return;
		}
		base.SetRoleSkinIcon(roleDataBase.GetRoleConfig().Card, base.GetTexture(2), roleDataBase.GetRoleSkinId(), null, null);
	}
}
