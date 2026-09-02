using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020019F7 RID: 6647
public class MiniElementItem : UiPanelBase
{
	// Token: 0x0600BE48 RID: 48712 RVA: 0x0032634F File Offset: 0x0032454F
	[NullableContext(2)]
	public MiniElementItem(int elementId, UUIItem parentUiItem = null, AActor rootActor = null)
	{
		this.ElementId = elementId;
		if (rootActor == null && parentUiItem != null)
		{
			base.CreateThenShowByResourceIdAsync("UiItem_MiniElement_Prefab", parentUiItem, false);
			return;
		}
		base.CreateThenShowByActor(rootActor, null);
	}

	// Token: 0x0600BE49 RID: 48713 RVA: 0x0032637B File Offset: 0x0032457B
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x0600BE4A RID: 48714 RVA: 0x003263B4 File Offset: 0x003245B4
	protected override void OnStart()
	{
		this.RefreshMiniElement(this.ElementId);
	}

	// Token: 0x0600BE4B RID: 48715 RVA: 0x003263C4 File Offset: 0x003245C4
	public void RefreshMiniElement(int elementId)
	{
		UUITexture texture = base.GetTexture(1);
		if (texture == null)
		{
			return;
		}
		ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(elementId);
		if (elementConfig == null)
		{
			return;
		}
		if (string.IsNullOrEmpty(elementConfig.Value.Icon5))
		{
			return;
		}
		FColor color = FColor.FromHex(elementConfig.Value.ElementColor);
		base.GetSprite(0).SetColor(color);
		base.SetTextureByPath(elementConfig.Value.Icon5, texture, null, null);
	}

	// Token: 0x04005982 RID: 22914
	private readonly int ElementId;

	// Token: 0x02007CE2 RID: 31970
	private enum EChildComponentType
	{
		// Token: 0x0402A9B5 RID: 174517
		ElementBg,
		// Token: 0x0402A9B6 RID: 174518
		ElementTexture
	}
}
