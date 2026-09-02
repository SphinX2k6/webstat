using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CB5 RID: 19637
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationSlider : NavigationSelectableBase
	{
		// Token: 0x0603325C RID: 209500 RVA: 0x00CCE851 File Offset: 0x00CCCA51
		public NavigationSlider(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x0603325D RID: 209501 RVA: 0x00CCE85C File Offset: 0x00CCCA5C
		protected override bool OnHandlePointerSelect(ULGUIPointerEventData eventData)
		{
			return false;
		}
	}
}
