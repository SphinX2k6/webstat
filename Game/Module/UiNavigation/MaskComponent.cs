using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D27 RID: 19751
	public class MaskComponent : HotKeyComponent
	{
		// Token: 0x060334E9 RID: 210153 RVA: 0x00CD6FBE File Offset: 0x00CD51BE
		public MaskComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334EA RID: 210154 RVA: 0x00CD6FC8 File Offset: 0x00CD51C8
		protected override void OnPress(HotKeyMap config)
		{
			UUIItem uuiitem = this.RootItem.GetRootCanvas().GetOwner().RootComponent as UUIItem;
			if (uuiitem != null)
			{
				ControllerBase<UiNavigationNewController>.Instance.SimulateClickItem(uuiitem, null);
			}
		}

		// Token: 0x060334EB RID: 210155 RVA: 0x00CD7008 File Offset: 0x00CD5208
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}
	}
}
