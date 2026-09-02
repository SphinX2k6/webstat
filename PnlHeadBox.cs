using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F33 RID: 7987
public class PnlHeadBox : UiPanelBase
{
	// Token: 0x0600EECE RID: 61134 RVA: 0x0041463C File Offset: 0x0041283C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EECF RID: 61135 RVA: 0x004146A8 File Offset: 0x004128A8
	public void RefreshView(int roleId)
	{
		base.GetSprite(0).SetUIActive(roleId == 0);
		base.GetTexture(1).SetUIActive(roleId != 0);
		if (roleId != 0)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
			if (roleConfig == null)
			{
				return;
			}
			RoleSkinData roleSkinDataByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataByRoleId(roleId);
			string path = (roleSkinDataByRoleId != null) ? roleSkinDataByRoleId.GetRoleSkinConfig().RoleHeadIconLarge : roleConfig.Value.RoleHeadIconLarge;
			base.SetRoleIconByRoleIdOrSkinId(path, base.GetTexture(1), roleId, new int?(roleConfig.Value.SkinId), null, null);
		}
	}
}
