using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002787 RID: 10119
public class CommonElementItem : GridProxyAbstract<int>
{
	// Token: 0x06013F90 RID: 81808 RVA: 0x00590E7B File Offset: 0x0058F07B
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x06013F91 RID: 81809 RVA: 0x00590EB4 File Offset: 0x0058F0B4
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.Update(data);
		this.RefreshPanel();
	}

	// Token: 0x06013F92 RID: 81810 RVA: 0x00590EC3 File Offset: 0x0058F0C3
	public void Update(int elementId)
	{
		this.ElementId = elementId;
	}

	// Token: 0x06013F93 RID: 81811 RVA: 0x00590ECC File Offset: 0x0058F0CC
	public void RefreshPanel()
	{
		ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(this.ElementId);
		if (elementConfig == null)
		{
			return;
		}
		FColor color = FColor.FromHex(elementConfig.Value.ElementColor);
		base.GetSprite(0).SetColor(color);
		base.SetTextureByPath(elementConfig.Value.Icon5, base.GetTexture(1), null, null);
	}

	// Token: 0x04009B8B RID: 39819
	private int ElementId;

	// Token: 0x02008B40 RID: 35648
	private enum ECommonElementCom
	{
		// Token: 0x0402EF07 RID: 192263
		ElementBgSprite,
		// Token: 0x0402EF08 RID: 192264
		ElementIconTexture
	}
}
