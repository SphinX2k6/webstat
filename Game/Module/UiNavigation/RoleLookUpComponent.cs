using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D49 RID: 19785
	public class RoleLookUpComponent : RoleInteractComponentBase
	{
		// Token: 0x06033569 RID: 210281 RVA: 0x00CD81C1 File Offset: 0x00CD63C1
		public RoleLookUpComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603356A RID: 210282 RVA: 0x00CD81CA File Offset: 0x00CD63CA
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.NavigationTriggerRoleLookUp, value);
		}
	}
}
