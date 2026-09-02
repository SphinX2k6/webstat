using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D4B RID: 19787
	public class RoleZoomComponent : RoleInteractComponentBase
	{
		// Token: 0x0603356D RID: 210285 RVA: 0x00CD81F9 File Offset: 0x00CD63F9
		public RoleZoomComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603356E RID: 210286 RVA: 0x00CD8202 File Offset: 0x00CD6402
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			Singleton<EventSystem>.Instance.Emit<string, float>(EEventName.NavigationTriggerRoleZoom, axisName, value);
		}
	}
}
