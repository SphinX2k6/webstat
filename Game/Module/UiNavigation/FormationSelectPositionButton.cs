using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CB7 RID: 19639
	public class FormationSelectPositionButton : NavigationButton
	{
		// Token: 0x0603326F RID: 209519 RVA: 0x00CCEB4A File Offset: 0x00CCCD4A
		[NullableContext(1)]
		public FormationSelectPositionButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033270 RID: 209520 RVA: 0x00CCEB55 File Offset: 0x00CCCD55
		protected override void OnInit()
		{
			base.OnInit();
		}

		// Token: 0x06033271 RID: 209521 RVA: 0x00CCEB5D File Offset: 0x00CCCD5D
		protected override void OnNotifyFocusListener(bool isSameListener)
		{
			ControllerBase<FormationDragController>.Instance.SetGamePadSelectPosition(int.Parse(this.ParamList[0]));
		}
	}
}
