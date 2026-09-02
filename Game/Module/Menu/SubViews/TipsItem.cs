using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x020057A2 RID: 22434
	public class TipsItem : UiPanelBase
	{
		// Token: 0x060390B0 RID: 233648 RVA: 0x00E748D0 File Offset: 0x00E72AD0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
			};
		}

		// Token: 0x060390B1 RID: 233649 RVA: 0x00E7492A File Offset: 0x00E72B2A
		protected override void OnBeforeShow()
		{
			base.GetSprite(0).SetUIActive(false);
			base.SetButtonUiActive(2, false);
		}
	}
}
