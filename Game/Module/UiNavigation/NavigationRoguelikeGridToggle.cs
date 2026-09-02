using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CC4 RID: 19652
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationRoguelikeGridToggle : NavigationToggle
	{
		// Token: 0x060332A6 RID: 209574 RVA: 0x00CCF365 File Offset: 0x00CCD565
		public NavigationRoguelikeGridToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332A7 RID: 209575 RVA: 0x00CCF370 File Offset: 0x00CCD570
		protected override bool OnHandlePointerSelect(ULGUIPointerEventData eventData)
		{
			UUIExtendToggle uuiextendToggle = this.Selectable as UUIExtendToggle;
			if (uuiextendToggle.ToggleState == EToggleState.ETT_UnChecked && eventData != null && eventData.inputType == ELGUIPointerInputType.Navigation && uuiextendToggle.bToggleOnSelect)
			{
				ControllerBase<UiNavigationNewController>.Instance.InteractClickByListener(this.Listener);
			}
			base.ScrollToSelectableComponent(uuiextendToggle);
			return base.IsAllowNavigationByGroup();
		}

		// Token: 0x060332A8 RID: 209576 RVA: 0x00CCF3C7 File Offset: 0x00CCD5C7
		protected override bool OnIsIgnoreScrollOrLayoutCheck()
		{
			return true;
		}
	}
}
