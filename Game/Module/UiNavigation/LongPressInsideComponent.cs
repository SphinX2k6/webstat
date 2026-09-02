using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D16 RID: 19734
	public class LongPressInsideComponent : HotKeyComponent
	{
		// Token: 0x060334A5 RID: 210085 RVA: 0x00CD65D6 File Offset: 0x00CD47D6
		public LongPressInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334A6 RID: 210086 RVA: 0x00CD65DF File Offset: 0x00CD47DF
		protected override void OnRelease(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.SimulationPointUpInside(config.BindButtonTag, config.Id, this.PressListener);
		}

		// Token: 0x060334A7 RID: 210087 RVA: 0x00CD65FF File Offset: 0x00CD47FF
		protected override void OnPress(HotKeyMap config)
		{
			this.PressListener = ControllerBase<UiNavigationNewController>.Instance.SimulationPointDownInside(config.BindButtonTag, config.Id);
		}

		// Token: 0x060334A8 RID: 210088 RVA: 0x00CD6620 File Offset: 0x00CD4820
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (string.IsNullOrEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (!base.IsLinkListener(focusListener.GetOwner()))
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			TsUiNavigationBehaviorListener childListenerByTag = focusListener.GetChildListenerByTag(bindButtonTag);
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, childListenerByTag != null && childListenerByTag.IsListenerActive(), false);
		}

		// Token: 0x0401DC4E RID: 121934
		[Nullable(2)]
		protected TsUiNavigationBehaviorListener PressListener;
	}
}
