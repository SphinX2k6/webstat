using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.MusicalInstrument;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D2A RID: 19754
	public class ZitherHighPitchComponent : HotKeyComponent
	{
		// Token: 0x060334F2 RID: 210162 RVA: 0x00CD70DC File Offset: 0x00CD52DC
		public ZitherHighPitchComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334F3 RID: 210163 RVA: 0x00CD70E8 File Offset: 0x00CD52E8
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			GuqinSubController guqinSubController = ControllerBase<MusicalInstrumentController>.Instance.GetSubController(EInstrumentType.ChineseZither) as GuqinSubController;
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, guqinSubController != null, false);
		}

		// Token: 0x060334F4 RID: 210164 RVA: 0x00CD7114 File Offset: 0x00CD5314
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
				view.OnGamepadPressPitch(EZitherGamepadPitchType.High);
			}
		}

		// Token: 0x060334F5 RID: 210165 RVA: 0x00CD7148 File Offset: 0x00CD5348
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
				view.OnGamepadReleasePitch(EZitherGamepadPitchType.High);
			}
		}
	}
}
