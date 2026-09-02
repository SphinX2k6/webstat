using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.MusicalInstrument;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D2B RID: 19755
	public class ZitherLowPitchComponent : HotKeyComponent
	{
		// Token: 0x060334F6 RID: 210166 RVA: 0x00CD717A File Offset: 0x00CD537A
		public ZitherLowPitchComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334F7 RID: 210167 RVA: 0x00CD7184 File Offset: 0x00CD5384
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			GuqinSubController guqinSubController = ControllerBase<MusicalInstrumentController>.Instance.GetSubController(EInstrumentType.ChineseZither) as GuqinSubController;
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, guqinSubController != null, false);
		}

		// Token: 0x060334F8 RID: 210168 RVA: 0x00CD71B0 File Offset: 0x00CD53B0
		protected override void OnPress(HotKeyMap config)
		{
			GuqinSubController guqinSubController = ControllerBase<MusicalInstrumentController>.Instance.GetSubController(EInstrumentType.ChineseZither) as GuqinSubController;
			if (guqinSubController != null)
			{
				GuqinView view = guqinSubController.GetView();
				if (view == null)
				{
					return;
				}
				view.OnGamepadPressPitch(EZitherGamepadPitchType.Low);
			}
		}

		// Token: 0x060334F9 RID: 210169 RVA: 0x00CD71E4 File Offset: 0x00CD53E4
		protected override void OnRelease(HotKeyMap config)
		{
			GuqinSubController guqinSubController = ControllerBase<MusicalInstrumentController>.Instance.GetSubController(EInstrumentType.ChineseZither) as GuqinSubController;
			if (guqinSubController != null)
			{
				GuqinView view = guqinSubController.GetView();
				if (view == null)
				{
					return;
				}
				view.OnGamepadReleasePitch(EZitherGamepadPitchType.Low);
			}
		}
	}
}
