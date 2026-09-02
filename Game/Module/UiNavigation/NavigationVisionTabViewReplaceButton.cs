using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CCF RID: 19663
	public class NavigationVisionTabViewReplaceButton : NavigationButton, INavigationInteractClick
	{
		// Token: 0x060332C7 RID: 209607 RVA: 0x00CCFB20 File Offset: 0x00CCDD20
		[NullableContext(1)]
		public NavigationVisionTabViewReplaceButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332C8 RID: 209608 RVA: 0x00CCFB2B File Offset: 0x00CCDD2B
		public void InteractClickHandle()
		{
			UiNavigationGlobalData.VisionReplaceViewFindDefault = true;
		}
	}
}
