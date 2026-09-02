using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CC3 RID: 19651
	public class NavigationQuestTitleToggle : NavigationToggle
	{
		// Token: 0x060332A4 RID: 209572 RVA: 0x00CCF350 File Offset: 0x00CCD550
		[NullableContext(1)]
		public NavigationQuestTitleToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332A5 RID: 209573 RVA: 0x00CCF35B File Offset: 0x00CCD55B
		protected override bool OnCanFocusInScrollOrLayout()
		{
			bool isInteractive = this.IsInteractive;
			return false;
		}
	}
}
