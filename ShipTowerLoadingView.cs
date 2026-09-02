using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020029BD RID: 10685
public class ShipTowerLoadingView : LoadingViewBase
{
	// Token: 0x060154F8 RID: 87288 RVA: 0x005E80ED File Offset: 0x005E62ED
	[NullableContext(1)]
	public ShipTowerLoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060154F9 RID: 87289 RVA: 0x005E80F6 File Offset: 0x005E62F6
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x060154FA RID: 87290 RVA: 0x005E8119 File Offset: 0x005E6319
	protected override void UpdateProgressRate(float rate)
	{
	}

	// Token: 0x060154FB RID: 87291 RVA: 0x005E811B File Offset: 0x005E631B
	protected override void UpdateProgressValue(float value)
	{
		this.SetTextProgressValue(0, value, "%");
	}

	// Token: 0x02008D16 RID: 36118
	private static class EChildType
	{
		// Token: 0x0402F75B RID: 194395
		public const int TxtProgress = 0;
	}
}
