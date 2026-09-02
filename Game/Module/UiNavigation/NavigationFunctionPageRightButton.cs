using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CA7 RID: 19623
	public class NavigationFunctionPageRightButton : NavigationButton
	{
		// Token: 0x06033210 RID: 209424 RVA: 0x00CCDD37 File Offset: 0x00CCBF37
		[NullableContext(1)]
		public NavigationFunctionPageRightButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033211 RID: 209425 RVA: 0x00CCDD44 File Offset: 0x00CCBF44
		protected override void OnButtonClick()
		{
			SpecialPanelHandleBase panelHandle = this.PanelHandle;
			if (((panelHandle != null) ? new ESpecialPanelHandleDefine?(panelHandle.GetType()) : null) == ESpecialPanelHandleDefine.FunctionView)
			{
				FunctionViewPanelHandle functionViewPanelHandle = this.PanelHandle as FunctionViewPanelHandle;
				if (functionViewPanelHandle == null)
				{
					return;
				}
				functionViewPanelHandle.FindNextFocusListener();
			}
		}
	}
}
