using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F1B RID: 7963
public class HonamiStoryTipsRoleItem : UiPanelBase
{
	// Token: 0x0600EE22 RID: 60962 RVA: 0x004108A0 File Offset: 0x0040EAA0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite))
		};
	}

	// Token: 0x0600EE23 RID: 60963 RVA: 0x004108FA File Offset: 0x0040EAFA
	protected override void OnStart()
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetPivot(new FVector2D(0f, 0f));
	}

	// Token: 0x0600EE24 RID: 60964 RVA: 0x0041091C File Offset: 0x0040EB1C
	public void Refresh(int id)
	{
		base.SetRoleIcon(ConfigBase<RoleConfig>.Instance.GetRoleConfig(id).Value.RoleHeadIconCircle, base.GetTexture(0), id, null, null);
	}

	// Token: 0x02008287 RID: 33415
	private enum ERole
	{
		// Token: 0x0402C45F RID: 181343
		Icon,
		// Token: 0x0402C460 RID: 181344
		Sprite,
		// Token: 0x0402C461 RID: 181345
		SpriteBg
	}
}
