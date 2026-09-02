using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CB2 RID: 19634
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationSelectable : NavigationSelectableBase
	{
		// Token: 0x06033229 RID: 209449 RVA: 0x00CCDFF6 File Offset: 0x00CCC1F6
		public NavigationSelectable(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x0603322A RID: 209450 RVA: 0x00CCE001 File Offset: 0x00CCC201
		protected override bool OnHandlePointerSelect(ULGUIPointerEventData eventData)
		{
			return false;
		}
	}
}
