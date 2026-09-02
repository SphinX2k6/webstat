using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001893 RID: 6291
public class BigElementItem : UiPanelBase
{
	// Token: 0x0600B47A RID: 46202 RVA: 0x0030180B File Offset: 0x002FFA0B
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x0600B47B RID: 46203 RVA: 0x00301844 File Offset: 0x002FFA44
	protected override void OnStart()
	{
	}

	// Token: 0x0600B47C RID: 46204 RVA: 0x00301848 File Offset: 0x002FFA48
	public void Refresh(int elementId)
	{
		if (this.ElementId == elementId)
		{
			return;
		}
		this.ElementId = elementId;
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
		string icon4Pure = elementConfig.Value.Icon4Pure;
		if (StringUtils.IsEmpty(icon4Pure))
		{
			return;
		}
		FColor color = FColor.FromHex(elementConfig.Value.ElementColor);
		base.GetSprite(0).SetColor(color);
		base.SetTextureByPath(icon4Pure, texture, null, null);
	}

	// Token: 0x0400554F RID: 21839
	private int ElementId;

	// Token: 0x02007C0D RID: 31757
	private enum EChildComponentType
	{
		// Token: 0x0402A61E RID: 173598
		ElementBg,
		// Token: 0x0402A61F RID: 173599
		ElementTexture,
		// Token: 0x0402A620 RID: 173600
		Panel
	}
}
