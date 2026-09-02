using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020011C0 RID: 4544
public class ArtemisQteRingSingleAreaItem : UiPanelBase
{
	// Token: 0x060077A7 RID: 30631 RVA: 0x001F5458 File Offset: 0x001F3658
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x060077A8 RID: 30632 RVA: 0x001F5491 File Offset: 0x001F3691
	protected override void OnBeforeDestroy()
	{
		this.ProgressParamName = null;
	}

	// Token: 0x060077A9 RID: 30633 RVA: 0x001F549F File Offset: 0x001F369F
	public void SetFillAmount(float amount)
	{
		UUITexture texture = base.GetTexture(0);
		if (texture != null)
		{
			texture.SetFillAmount(amount);
		}
		UUITexture texture2 = base.GetTexture(1);
		if (texture2 == null)
		{
			return;
		}
		texture2.SetFillAmount(amount);
	}

	// Token: 0x060077AA RID: 30634 RVA: 0x001F54C6 File Offset: 0x001F36C6
	public void SetCustomMaterialScalarParameter(float amount)
	{
		UUITexture texture = base.GetTexture(0);
		if (texture != null)
		{
			texture.SetCustomMaterialScalarParameter(this.ProgressParamName, amount);
		}
		UUITexture texture2 = base.GetTexture(1);
		if (texture2 == null)
		{
			return;
		}
		texture2.SetCustomMaterialScalarParameter(this.ProgressParamName, amount);
	}

	// Token: 0x060077AB RID: 30635 RVA: 0x001F54F9 File Offset: 0x001F36F9
	public void SetHighLight(bool isHighLight)
	{
		base.GetTexture(0).SetUIActive(!isHighLight);
		base.GetTexture(1).SetUIActive(isHighLight);
	}

	// Token: 0x040039F1 RID: 14833
	private FName ProgressParamName = new FName("Progress");

	// Token: 0x02007517 RID: 29975
	private class EComponents
	{
		// Token: 0x040286CE RID: 165582
		public const int TextureArea = 0;

		// Token: 0x040286CF RID: 165583
		public const int TextureAreaHighLight = 1;
	}
}
