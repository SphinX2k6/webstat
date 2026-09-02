using System;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D4C RID: 19788
	public class RoleResetComponent : RoleInteractComponentBase
	{
		// Token: 0x0603356F RID: 210287 RVA: 0x00CD8216 File Offset: 0x00CD6416
		public RoleResetComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033570 RID: 210288 RVA: 0x00CD821F File Offset: 0x00CD641F
		protected override void OnPress(HotKeyMap config)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.NavigationTriggerRoleReset);
		}
	}
}
