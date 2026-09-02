using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200289C RID: 10396
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SuccessDescriptionItem : GridProxyAbstract<SingleText>
{
	// Token: 0x0601495D RID: 84317 RVA: 0x005B3195 File Offset: 0x005B1395
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x0601495E RID: 84318 RVA: 0x005B31B8 File Offset: 0x005B13B8
	public void SetDescriptionText(SingleText text)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), text.TextId, text.Params ?? Array.Empty<string>());
	}

	// Token: 0x0601495F RID: 84319 RVA: 0x005B31E0 File Offset: 0x005B13E0
	public override void Refresh(SingleText data, bool isSelected, int gridIndex)
	{
		this.SetDescriptionText(data);
	}
}
