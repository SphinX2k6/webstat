using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A6F RID: 6767
public class TeamPlayerSelectionComponent : UiPanelBase
{
	// Token: 0x0600C1AD RID: 49581 RVA: 0x0032FF95 File Offset: 0x0032E195
	[NullableContext(1)]
	public TeamPlayerSelectionComponent(UUIItem parent)
	{
		base.CreateThenShowByActor(parent.GetOwner(), null);
	}

	// Token: 0x0600C1AE RID: 49582 RVA: 0x0032FFAA File Offset: 0x0032E1AA
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUISprite))
		};
	}

	// Token: 0x0600C1AF RID: 49583 RVA: 0x0032FFE3 File Offset: 0x0032E1E3
	protected override void OnBeforeDestroy()
	{
		this.RoleId = null;
		this.TeamNumber = null;
		this.IsSet = false;
	}

	// Token: 0x0600C1B0 RID: 49584 RVA: 0x00330004 File Offset: 0x0032E204
	public void SetRoleId(int roleId)
	{
		this.RoleId = new int?(roleId);
	}

	// Token: 0x0600C1B1 RID: 49585 RVA: 0x00330012 File Offset: 0x0032E212
	public void SetTeamNumber(int teamNumber)
	{
		this.TeamNumber = new int?(teamNumber);
	}

	// Token: 0x0600C1B2 RID: 49586 RVA: 0x00330020 File Offset: 0x0032E220
	public void RefreshItem()
	{
		UUITexture texture = base.GetTexture(0);
		string roleHeadIconBig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId.Value).Value.RoleHeadIconBig;
		base.SetTextureByPath(roleHeadIconBig, texture, null, null);
		UUISprite sprite = base.GetSprite(1);
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_Online");
		defaultInterpolatedStringHandler.AppendFormatted<int?>(this.TeamNumber);
		defaultInterpolatedStringHandler.AppendLiteral("PIcon");
		string resourcePath = instance.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
		this.SetSpriteByPath(resourcePath, sprite, false, null, null);
		this.IsSet = true;
	}

	// Token: 0x04005AA5 RID: 23205
	private int? RoleId;

	// Token: 0x04005AA6 RID: 23206
	private int? TeamNumber;

	// Token: 0x04005AA7 RID: 23207
	public bool IsSet;
}
