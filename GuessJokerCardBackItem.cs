using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001128 RID: 4392
public class GuessJokerCardBackItem : UiPanelBase
{
	// Token: 0x060072CC RID: 29388 RVA: 0x001DFED3 File Offset: 0x001DE0D3
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x060072CD RID: 29389 RVA: 0x001DFF0C File Offset: 0x001DE10C
	protected override void OnStart()
	{
		base.GetItem(0).SetUIActive(false);
		base.GetItem(1).SetUIActive(false);
	}

	// Token: 0x060072CE RID: 29390 RVA: 0x001DFF28 File Offset: 0x001DE128
	protected override void OnBeforeDestroy()
	{
		base.GetItem(0).SetUIActive(false);
		base.GetItem(1).SetUIActive(false);
	}

	// Token: 0x020074AA RID: 29866
	private class EComponentDefine
	{
		// Token: 0x040284AF RID: 165039
		public const int ChooseCardItem = 0;

		// Token: 0x040284B0 RID: 165040
		public const int SelectCardItem = 1;
	}
}
