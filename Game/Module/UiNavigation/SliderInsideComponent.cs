using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D68 RID: 19816
	public class SliderInsideComponent : SliderComponent
	{
		// Token: 0x060335C1 RID: 210369 RVA: 0x00CD8A82 File Offset: 0x00CD6C82
		public SliderInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335C2 RID: 210370 RVA: 0x00CD8A8B File Offset: 0x00CD6C8B
		protected override void SetValue(float value)
		{
			ControllerBase<UiNavigationNewController>.Instance.SliderInsideComponentSetValue(base.GetBindButtonTag(), value);
		}

		// Token: 0x060335C3 RID: 210371 RVA: 0x00CD8AA0 File Offset: 0x00CD6CA0
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (StringUtils.IsEmpty(bindButtonTag))
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
			TsUiNavigationBehaviorListener focusListenerInsideListenerByTag = ControllerBase<UiNavigationNewController>.Instance.GetFocusListenerInsideListenerByTag(focusListener, bindButtonTag);
			if (focusListenerInsideListenerByTag == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, focusListenerInsideListenerByTag.IsListenerActive(), false);
		}

		// Token: 0x0401DC76 RID: 121974
		protected const float INTERVAL = 0.05f;

		// Token: 0x0401DC77 RID: 121975
		protected const float SLIDER_DEAD_AREA = 0.4f;

		// Token: 0x0401DC78 RID: 121976
		protected const float DEAD_AREA = 0.073f;

		// Token: 0x0401DC79 RID: 121977
		protected const float SETTING_INTERVAL = 0.01f;
	}
}
