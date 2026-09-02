using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CA1 RID: 19617
	public class NavigationCalabashDetailExitButton : NavigationButton
	{
		// Token: 0x06033202 RID: 209410 RVA: 0x00CCDB08 File Offset: 0x00CCBD08
		[NullableContext(1)]
		public NavigationCalabashDetailExitButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033203 RID: 209411 RVA: 0x00CCDB13 File Offset: 0x00CCBD13
		protected override void OnButtonClick()
		{
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
		}
	}
}
