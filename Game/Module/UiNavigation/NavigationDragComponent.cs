using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CB0 RID: 19632
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationDragComponent : NavigationSelectableBase
	{
		// Token: 0x06033225 RID: 209445 RVA: 0x00CCDFDA File Offset: 0x00CCC1DA
		public NavigationDragComponent(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033226 RID: 209446 RVA: 0x00CCDFE5 File Offset: 0x00CCC1E5
		protected override bool OnHandlePointerSelect(ULGUIPointerEventData eventData)
		{
			return false;
		}
	}
}
