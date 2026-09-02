using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024D9 RID: 9433
public class PhantomInteractListLongPressPanel : UiPanelBase
{
	// Token: 0x060124F1 RID: 74993 RVA: 0x00508896 File Offset: 0x00506A96
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite))
		};
	}

	// Token: 0x060124F2 RID: 74994 RVA: 0x005088BC File Offset: 0x00506ABC
	public void SetFillProgress(float progress)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite != null)
		{
			sprite.SetFillAmount(progress);
		}
	}

	// Token: 0x020087E6 RID: 34790
	private enum EComponent
	{
		// Token: 0x0402DE9B RID: 188059
		SpriteFill
	}
}
