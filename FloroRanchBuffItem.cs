using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C4A RID: 7242
[Nullable(new byte[]
{
	0,
	1
})]
public class FloroRanchBuffItem : GridProxyAbstract<FloroRanchBuffData>
{
	// Token: 0x0600D342 RID: 54082 RVA: 0x00384994 File Offset: 0x00382B94
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D343 RID: 54083 RVA: 0x00384A84 File Offset: 0x00382C84
	protected override void OnStart()
	{
		ITermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(3),
			ViewType = ETermExplanationViewType.Center,
			Style = new ETermExplanationViewStyle?(ETermExplanationViewStyle.FloroRanch),
			ReportType = ETermExplanationReportType.FloroRanch
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0600D344 RID: 54084 RVA: 0x00384ACA File Offset: 0x00382CCA
	protected override void OnBeforeDestroy()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(3));
	}

	// Token: 0x0600D345 RID: 54085 RVA: 0x00384AE0 File Offset: 0x00382CE0
	[NullableContext(1)]
	public override void Refresh(FloroRanchBuffData data, bool isSelected, int gridIndex)
	{
		int remindDay = data.RemindDay;
		bool flag = remindDay > 0;
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		if (flag)
		{
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetText(remindDay.ToString(), true);
			}
		}
		UUIText text2 = base.GetText(3);
		if (text2 != null)
		{
			text2.ShowTextNew(data.GetBuffName());
		}
		UUITexture texture = base.GetTexture(4);
		if (texture != null)
		{
			texture.SetUIActive(false);
		}
		UUIText text3 = base.GetText(5);
		if (text3 == null)
		{
			return;
		}
		text3.SetUIActive(false);
	}

	// Token: 0x02007F5B RID: 32603
	private class EComponentDefine
	{
		// Token: 0x0402B5AD RID: 177581
		public const int Item = 0;

		// Token: 0x0402B5AE RID: 177582
		public const int CountItem = 1;

		// Token: 0x0402B5AF RID: 177583
		public const int CountNum = 2;

		// Token: 0x0402B5B0 RID: 177584
		public const int NameText = 3;

		// Token: 0x0402B5B1 RID: 177585
		public const int CurrencyTexture = 4;

		// Token: 0x0402B5B2 RID: 177586
		public const int CurrencyText = 5;
	}
}
