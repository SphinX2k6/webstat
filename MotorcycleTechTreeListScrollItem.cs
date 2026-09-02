using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200229A RID: 8858
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleTechTreeListScrollItem : GridProxyAbstract<IMotorTechOverviewData>
{
	// Token: 0x06010BE7 RID: 68583 RVA: 0x0049688C File Offset: 0x00494A8C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x06010BE8 RID: 68584 RVA: 0x004968FC File Offset: 0x00494AFC
	[NullableContext(1)]
	public override void Refresh(IMotorTechOverviewData data, bool isSelected, int gridIndex)
	{
		MotorTech? motorTechConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechConfig(data.TechId);
		if (motorTechConfig != null)
		{
			base.SetTextureByPath(motorTechConfig.Value.Icon, base.GetTexture(1), null, null);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(motorTechConfig.Value.Title, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "MotorBike_CurrentTechTree_TechLevelInfo", new <>z__ReadOnlyArray<object>(new object[]
			{
				data.Level,
				localTextNew
			}));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), motorTechConfig.Value.DescSimple, Array.Empty<object>());
		}
		UUIItem item = base.GetItem(0);
		UUIItem uuiitem = item;
		bool bUseChangeColor = gridIndex % 2 != 0;
		FColor? fcolor = new FColor?(item.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x0200856D RID: 34157
	private class EMotorTreeOverviewItemComponent
	{
		// Token: 0x0402D267 RID: 184935
		public const int BgItem = 0;

		// Token: 0x0402D268 RID: 184936
		public const int TexIcon = 1;

		// Token: 0x0402D269 RID: 184937
		public const int TxtAttr = 2;

		// Token: 0x0402D26A RID: 184938
		public const int TxtDesc = 3;
	}
}
