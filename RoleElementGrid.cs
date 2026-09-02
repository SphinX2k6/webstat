using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A0F RID: 6671
public class RoleElementGrid : UiPanelBase
{
	// Token: 0x0600BF41 RID: 48961 RVA: 0x0032987A File Offset: 0x00327A7A
	[NullableContext(1)]
	public RoleElementGrid(AActor actor)
	{
		base.CreateThenShowByActor(actor, null);
	}

	// Token: 0x17000FA8 RID: 4008
	// (get) Token: 0x0600BF42 RID: 48962 RVA: 0x0032988C File Offset: 0x00327A8C
	private ElementInfo? Config
	{
		get
		{
			if (this.ElementId == 0)
			{
				return null;
			}
			return ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(this.ElementId);
		}
	}

	// Token: 0x0600BF43 RID: 48963 RVA: 0x003298BB File Offset: 0x00327ABB
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUISprite))
		};
	}

	// Token: 0x0600BF44 RID: 48964 RVA: 0x003298F4 File Offset: 0x00327AF4
	private void UpdateElementTexture()
	{
		UUITexture texture = base.GetTexture(0);
		UUISprite sprite = base.GetSprite(1);
		if (texture == null || sprite == null)
		{
			return;
		}
		ElementInfo? config = this.Config;
		if (config == null)
		{
			return;
		}
		FColor color = FColor.FromHex(config.Value.ElementColor);
		sprite.SetColor(color);
		string icon = config.Value.Icon;
		if (string.IsNullOrEmpty(icon))
		{
			return;
		}
		base.SetElementIcon(icon, texture, this.ElementId, null);
	}

	// Token: 0x0600BF45 RID: 48965 RVA: 0x0032997B File Offset: 0x00327B7B
	public void Refresh(int elementId)
	{
		this.ElementId = elementId;
		this.UpdateElementTexture();
	}

	// Token: 0x040059E0 RID: 23008
	private int ElementId;

	// Token: 0x02007CF1 RID: 31985
	private enum EChildType
	{
		// Token: 0x0402A9F4 RID: 174580
		TextureElement,
		// Token: 0x0402A9F5 RID: 174581
		SpriteBg
	}
}
