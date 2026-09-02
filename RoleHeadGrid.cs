using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A10 RID: 6672
public class RoleHeadGrid : UiPanelBase
{
	// Token: 0x0600BF46 RID: 48966 RVA: 0x0032998A File Offset: 0x00327B8A
	[NullableContext(1)]
	public RoleHeadGrid(AActor actor)
	{
		base.CreateThenShowByActor(actor, null);
	}

	// Token: 0x17000FA9 RID: 4009
	// (get) Token: 0x0600BF47 RID: 48967 RVA: 0x0032999C File Offset: 0x00327B9C
	private RoleInfo? Config
	{
		get
		{
			if (this.RoleId == 0)
			{
				return null;
			}
			return ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId);
		}
	}

	// Token: 0x0600BF48 RID: 48968 RVA: 0x003299CB File Offset: 0x00327BCB
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture))
		};
	}

	// Token: 0x0600BF49 RID: 48969 RVA: 0x003299F0 File Offset: 0x00327BF0
	private void UpdateHeadTexture()
	{
		RoleInfo? config = this.Config;
		if (config == null)
		{
			return;
		}
		UUITexture texture = base.GetTexture(0);
		if (texture == null)
		{
			return;
		}
		string roleHeadIconBig = config.Value.RoleHeadIconBig;
		if (string.IsNullOrEmpty(roleHeadIconBig))
		{
			return;
		}
		base.SetRoleIcon(roleHeadIconBig, texture, this.RoleId, null, null);
	}

	// Token: 0x0600BF4A RID: 48970 RVA: 0x00329A4C File Offset: 0x00327C4C
	public void Refresh(int roleId)
	{
		this.RoleId = roleId;
		this.UpdateHeadTexture();
	}

	// Token: 0x040059E1 RID: 23009
	private int RoleId;

	// Token: 0x02007CF2 RID: 31986
	private enum EChildType
	{
		// Token: 0x0402A9F7 RID: 174583
		RoleHeadTexture
	}
}
