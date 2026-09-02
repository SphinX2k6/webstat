using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D5E RID: 19806
	public class ShowOnlyComponent : HotKeyComponent
	{
		// Token: 0x060335A8 RID: 210344 RVA: 0x00CD890F File Offset: 0x00CD6B0F
		public ShowOnlyComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335A9 RID: 210345 RVA: 0x00CD8918 File Offset: 0x00CD6B18
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x060335AA RID: 210346 RVA: 0x00CD8923 File Offset: 0x00CD6B23
		protected override bool OnIsOccupancyFightInput()
		{
			return false;
		}
	}
}
