using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.MapRogue;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D21 RID: 19745
	public class MapRogueQuicklyMoveComponent : HotKeyComponent
	{
		// Token: 0x060334D7 RID: 210135 RVA: 0x00CD6D90 File Offset: 0x00CD4F90
		public MapRogueQuicklyMoveComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334D8 RID: 210136 RVA: 0x00CD6D9C File Offset: 0x00CD4F9C
		protected override void OnPress(HotKeyMap config)
		{
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			if (gameInfo == null)
			{
				return;
			}
			gameInfo.OnMove(null);
		}

		// Token: 0x060334D9 RID: 210137 RVA: 0x00CD6DC6 File Offset: 0x00CD4FC6
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}
	}
}
