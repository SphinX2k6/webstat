using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D45 RID: 19781
	public class PlotNextPageComponent : HotKeyComponent
	{
		// Token: 0x06033558 RID: 210264 RVA: 0x00CD7F9A File Offset: 0x00CD619A
		public PlotNextPageComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033559 RID: 210265 RVA: 0x00CD7FA3 File Offset: 0x00CD61A3
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.NavigationRefreshPlotNextPage, new Action<bool>(this.NavigationRefreshPlotNextPage));
		}

		// Token: 0x0603355A RID: 210266 RVA: 0x00CD7FC1 File Offset: 0x00CD61C1
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationRefreshPlotNextPage, new Action<bool>(this.NavigationRefreshPlotNextPage));
		}

		// Token: 0x0603355B RID: 210267 RVA: 0x00CD7FDF File Offset: 0x00CD61DF
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.ClickButton(config.BindButtonTag);
		}

		// Token: 0x0603355C RID: 210268 RVA: 0x00CD7FF4 File Offset: 0x00CD61F4
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (StringUtils.IsEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener activeListenerByTag = viewHandle.GetActiveListenerByTag(bindButtonTag);
			this.Listener = activeListenerByTag;
			TsUiNavigationBehaviorListener listener = this.Listener;
			bool flag = listener != null && listener.IsListenerActive();
			bool canClick = ModelBase<PlotModel>.Instance.CanClick;
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, flag && canClick, false);
		}

		// Token: 0x0603355D RID: 210269 RVA: 0x00CD804C File Offset: 0x00CD624C
		private void NavigationRefreshPlotNextPage(bool isActive)
		{
			TsUiNavigationBehaviorListener listener = this.Listener;
			bool flag = listener != null && listener.IsListenerActive();
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, flag && isActive, false);
		}

		// Token: 0x0401DC5D RID: 121949
		[Nullable(2)]
		private TsUiNavigationBehaviorListener Listener;
	}
}
