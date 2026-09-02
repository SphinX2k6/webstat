using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002ACB RID: 10955
public class SurvivorsRogueCardAttributeItem : UiPanelBase
{
	// Token: 0x06015E9F RID: 89759 RVA: 0x00616854 File Offset: 0x00614A54
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x06015EA0 RID: 89760 RVA: 0x006168AE File Offset: 0x00614AAE
	public void SetIsUp(bool bUp)
	{
		base.GetItem(0).SetUIActive(!bUp);
		base.GetItem(1).SetUIActive(bUp);
	}

	// Token: 0x06015EA1 RID: 89761 RVA: 0x006168CD File Offset: 0x00614ACD
	[NullableContext(2)]
	public void SetTextureIcon(string path)
	{
		if (!string.IsNullOrEmpty(path))
		{
			base.SetTextureShowUntilLoaded(path, base.GetTexture(2), null);
		}
	}
}
