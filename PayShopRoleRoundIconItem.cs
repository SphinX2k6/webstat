using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023E4 RID: 9188
public class PayShopRoleRoundIconItem : UiPanelBase
{
	// Token: 0x06011C72 RID: 72818 RVA: 0x004E3A33 File Offset: 0x004E1C33
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture))
		};
	}

	// Token: 0x06011C73 RID: 72819 RVA: 0x004E3A58 File Offset: 0x004E1C58
	[NullableContext(1)]
	public void SetIconByPath(string path)
	{
		base.SetTextureByPath(path, base.GetTexture(0), null, null);
	}

	// Token: 0x0200871D RID: 34589
	private enum EComponents
	{
		// Token: 0x0402DB3F RID: 187199
		TextureIcon
	}
}
