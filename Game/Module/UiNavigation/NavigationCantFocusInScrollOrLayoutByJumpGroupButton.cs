using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CA2 RID: 19618
	public class NavigationCantFocusInScrollOrLayoutByJumpGroupButton : NavigationButton
	{
		// Token: 0x06033204 RID: 209412 RVA: 0x00CCDB1F File Offset: 0x00CCBD1F
		[NullableContext(1)]
		public NavigationCantFocusInScrollOrLayoutByJumpGroupButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033205 RID: 209413 RVA: 0x00CCDB2A File Offset: 0x00CCBD2A
		protected override bool OnCanFocusInScrollOrLayout()
		{
			return false;
		}
	}
}
