using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020017EF RID: 6127
[Nullable(new byte[]
{
	0,
	1
})]
public class CalabashCollectStageItem : GridProxyAbstract<ICalabashDevelopRewardInfoData>
{
	// Token: 0x0600AE27 RID: 44583 RVA: 0x002E4ED4 File Offset: 0x002E30D4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x0600AE28 RID: 44584 RVA: 0x002E4F44 File Offset: 0x002E3144
	[NullableContext(1)]
	public override void Refresh(ICalabashDevelopRewardInfoData data, bool isSelected, int gridIndex)
	{
		UUIText text = base.GetText(0);
		text.ShowTextNew(data.Info);
		UUIItem uuiitem = text;
		bool isUnlock = data.IsUnlock;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(isUnlock, fcolor);
		UUIText text2 = base.GetText(1);
		text2.SetText(data.Num.ToString(), true);
		UUIItem uuiitem2 = text2;
		bool isUnlock2 = data.IsUnlock;
		fcolor = new FColor?(text2.changeColor);
		uuiitem2.SetChangeColor(isUnlock2, fcolor);
		base.GetItem(2).SetUIActive(data.IsUnlock);
		base.GetItem(3).SetUIActive(!data.IsUnlock);
	}

	// Token: 0x02007B68 RID: 31592
	private enum EComponent
	{
		// Token: 0x0402A2FE RID: 172798
		StageText,
		// Token: 0x0402A2FF RID: 172799
		ExpText,
		// Token: 0x0402A300 RID: 172800
		UnlockItem,
		// Token: 0x0402A301 RID: 172801
		LockItem
	}
}
