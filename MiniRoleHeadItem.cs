using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020019F9 RID: 6649
public class MiniRoleHeadItem : UiPanelBase
{
	// Token: 0x0600BE4F RID: 48719 RVA: 0x003264C4 File Offset: 0x003246C4
	[NullableContext(1)]
	public MiniRoleHeadItem(UUIItem parentUiItem, int roleConfigId)
	{
		base.CreateThenShowByResourceIdAsync("UiItem_MiniRoleHead_Prefab", parentUiItem, false);
		this.RoleConfigId = roleConfigId;
	}

	// Token: 0x0600BE50 RID: 48720 RVA: 0x003264E1 File Offset: 0x003246E1
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture))
		};
	}

	// Token: 0x0600BE51 RID: 48721 RVA: 0x00326504 File Offset: 0x00324704
	protected override void OnStart()
	{
		UUITexture texture = base.GetTexture(0);
		if (texture == null)
		{
			return;
		}
		RoleInfo? config = ConfigRoleInfoById.GetConfig(this.RoleConfigId, true);
		if (config == null)
		{
			return;
		}
		string roleHeadIconBig = config.Value.RoleHeadIconBig;
		if (string.IsNullOrEmpty(roleHeadIconBig))
		{
			return;
		}
		base.SetRoleIcon(roleHeadIconBig, texture, this.RoleConfigId, null, null);
	}

	// Token: 0x04005983 RID: 22915
	private readonly int RoleConfigId;

	// Token: 0x02007CE4 RID: 31972
	private enum EChildType
	{
		// Token: 0x0402A9BB RID: 174523
		RoleHeadTexture
	}
}
