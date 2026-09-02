using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D53 RID: 19795
	[NullableContext(1)]
	[Nullable(0)]
	public class ScrollBarInsideComponent : HotKeyComponent
	{
		// Token: 0x06033582 RID: 210306 RVA: 0x00CD8451 File Offset: 0x00CD6651
		public ScrollBarInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033583 RID: 210307 RVA: 0x00CD845C File Offset: 0x00CD665C
		protected override void OnInputAxis(string axisName, float value)
		{
			if (Math.Abs(value) <= 0.1f)
			{
				if (this.TempValue != 0f)
				{
					this.TempValue = 0f;
					ControllerBase<UiNavigationNewController>.Instance.ScrollbarInsideComponentSetValue(base.GetBindButtonTag(), 0f);
				}
				return;
			}
			this.TempValue = value;
			ControllerBase<UiNavigationNewController>.Instance.ScrollbarInsideComponentSetValue(base.GetBindButtonTag(), value);
		}

		// Token: 0x06033584 RID: 210308 RVA: 0x00CD84BC File Offset: 0x00CD66BC
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (string.IsNullOrEmpty(bindButtonTag))
			{
				Singleton<Log>.Instance.Error(ELogModule.UiNavigationHotKey, ELogAuthor.XXJ, "ScrollBar需要配置tag", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			TsUiNavigationBehaviorListener focusListenerInsideListenerByTag = ControllerBase<UiNavigationNewController>.Instance.GetFocusListenerInsideListenerByTag(focusListener, bindButtonTag);
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, focusListenerInsideListenerByTag != null && focusListenerInsideListenerByTag.IsListenerActive(), false);
		}

		// Token: 0x0401DC67 RID: 121959
		private const float THRESHOLD = 0.1f;

		// Token: 0x0401DC68 RID: 121960
		private float TempValue;
	}
}
