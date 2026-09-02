using System;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D22 RID: 19746
	public class MapTravelTaskNavigationNextComponent : NavigationGroupNextComponent
	{
		// Token: 0x060334DA RID: 210138 RVA: 0x00CD6DD1 File Offset: 0x00CD4FD1
		public MapTravelTaskNavigationNextComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334DB RID: 210139 RVA: 0x00CD6DDA File Offset: 0x00CD4FDA
		protected override void JumpToNextGroupListener()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.MapTravelTaskNavigationNext);
		}

		// Token: 0x060334DC RID: 210140 RVA: 0x00CD6DEC File Offset: 0x00CD4FEC
		protected override void OnRelease(HotKeyMap config)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.MapTravelTaskNavigationNext);
		}
	}
}
