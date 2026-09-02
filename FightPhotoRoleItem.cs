using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001334 RID: 4916
public class FightPhotoRoleItem : GridProxyAbstract<int>
{
	// Token: 0x0600863A RID: 34362 RVA: 0x00235E1C File Offset: 0x0023401C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBtnClick))
		};
	}

	// Token: 0x0600863B RID: 34363 RVA: 0x00235E84 File Offset: 0x00234084
	public override void Refresh(int roleId, bool isSelected, int gridIndex)
	{
		UUITexture texture = base.GetTexture(1);
		if (roleId == 0)
		{
			texture.SetUIActive(false);
			return;
		}
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		int? num = (roleDataById != null) ? new int?(roleDataById.GetRoleSkinId()) : null;
		if (num == null || num.Value == 0)
		{
			num = new int?(ConfigRoleInfoById.GetConfig(roleId, true).Value.SkinId);
		}
		base.SetTextureByPath(ConfigRoleSkinById.GetConfig(num.Value, true).Value.RoleHeadIcon, texture, null, null);
		texture.SetUIActive(true);
	}

	// Token: 0x0600863C RID: 34364 RVA: 0x00235F33 File Offset: 0x00234133
	private void OnBtnClick()
	{
		this.OnBtnClickCallback(base.GridIndex);
	}

	// Token: 0x04003F79 RID: 16249
	[Nullable(1)]
	public Action<int> OnBtnClickCallback = delegate(int index)
	{
	};

	// Token: 0x020076D7 RID: 30423
	private enum EComponents
	{
		// Token: 0x04028EF6 RID: 167670
		BtnRoot,
		// Token: 0x04028EF7 RID: 167671
		TextureRole
	}
}
