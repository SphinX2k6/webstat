using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.MusicalInstrument;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D29 RID: 19753
	[NullableContext(1)]
	[Nullable(0)]
	public class ZitherCameraZoomComponent : HotKeyComponent
	{
		// Token: 0x060334EF RID: 210159 RVA: 0x00CD707F File Offset: 0x00CD527F
		public ZitherCameraZoomComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334F0 RID: 210160 RVA: 0x00CD7088 File Offset: 0x00CD5288
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			GuqinSubController guqinSubController = ControllerBase<MusicalInstrumentController>.Instance.GetSubController(EInstrumentType.ChineseZither) as GuqinSubController;
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, guqinSubController != null && Singleton<Info>.Instance.IsInGamepad(), false);
		}

		// Token: 0x060334F1 RID: 210161 RVA: 0x00CD70BE File Offset: 0x00CD52BE
		protected override void OnInputAxis(string axisName, float value)
		{
			GuqinSubController guqinSubController = ControllerBase<MusicalInstrumentController>.Instance.GetSubController(EInstrumentType.ChineseZither) as GuqinSubController;
			if (guqinSubController == null)
			{
				return;
			}
			guqinSubController.OnGamepadCameraZoom(axisName, value);
		}
	}
}
