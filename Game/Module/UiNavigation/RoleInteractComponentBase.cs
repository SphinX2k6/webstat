using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D48 RID: 19784
	public class RoleInteractComponentBase : HotKeyComponent
	{
		// Token: 0x06033567 RID: 210279 RVA: 0x00CD81AD File Offset: 0x00CD63AD
		public RoleInteractComponentBase(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033568 RID: 210280 RVA: 0x00CD81B6 File Offset: 0x00CD63B6
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}
	}
}
