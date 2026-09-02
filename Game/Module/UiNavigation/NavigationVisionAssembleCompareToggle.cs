using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CCD RID: 19661
	public class NavigationVisionAssembleCompareToggle : NavigationToggle
	{
		// Token: 0x060332C0 RID: 209600 RVA: 0x00CCF7EC File Offset: 0x00CCD9EC
		[NullableContext(1)]
		public NavigationVisionAssembleCompareToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332C1 RID: 209601 RVA: 0x00CCF7F7 File Offset: 0x00CCD9F7
		protected override void OnToggleClick(EToggleState state)
		{
			(this.PanelHandle as VisionAssemblePanelHandle).IsInCompare = (state == EToggleState.ETT_Checked);
		}
	}
}
