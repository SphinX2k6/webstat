using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CB1 RID: 19633
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationScrollbar : NavigationSelectableBase
	{
		// Token: 0x06033227 RID: 209447 RVA: 0x00CCDFE8 File Offset: 0x00CCC1E8
		public NavigationScrollbar(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033228 RID: 209448 RVA: 0x00CCDFF3 File Offset: 0x00CCC1F3
		protected override bool OnHandlePointerSelect(ULGUIPointerEventData eventData)
		{
			return false;
		}
	}
}
