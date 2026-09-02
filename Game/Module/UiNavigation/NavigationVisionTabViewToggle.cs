using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CD0 RID: 19664
	public class NavigationVisionTabViewToggle : NavigationDragComponent, INavigationInteractClick, INavigationInteractFailClick
	{
		// Token: 0x060332C9 RID: 209609 RVA: 0x00CCFB33 File Offset: 0x00CCDD33
		[NullableContext(1)]
		public NavigationVisionTabViewToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332CA RID: 209610 RVA: 0x00CCFB3E File Offset: 0x00CCDD3E
		public void InteractClickFailHandle()
		{
			UiNavigationGlobalData.VisionReplaceViewFindDefault = false;
		}

		// Token: 0x060332CB RID: 209611 RVA: 0x00CCFB46 File Offset: 0x00CCDD46
		public void InteractClickHandle()
		{
			UiNavigationGlobalData.VisionReplaceViewFindDefault = false;
		}
	}
}
