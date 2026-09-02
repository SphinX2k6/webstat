using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation.UIComponent
{
	// Token: 0x02004D84 RID: 19844
	public class NavigationNextLatest : HotKeyComponent
	{
		// Token: 0x06033635 RID: 210485 RVA: 0x00CDA7F2 File Offset: 0x00CD89F2
		public NavigationNextLatest(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033636 RID: 210486 RVA: 0x00CDA7FB File Offset: 0x00CD89FB
		protected override void OnRelease(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.HandleCommonConsumeNavigationToLast(config.BindButtonTag);
		}

		// Token: 0x06033637 RID: 210487 RVA: 0x00CDA810 File Offset: 0x00CD8A10
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			NavigationGroup navigationGroup = focusListener.GetNavigationGroup();
			string bindButtonTag = base.GetBindButtonTag();
			string text;
			if (!string.IsNullOrEmpty(bindButtonTag))
			{
				text = navigationGroup.GroupNameMap.GetValueOrDefault(bindButtonTag);
			}
			else
			{
				text = navigationGroup.NextGroupName;
			}
			if (string.IsNullOrEmpty(text))
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			NavigationGroup activeNavigationGroupByNameCheckAll = viewHandle.GetActiveNavigationGroupByNameCheckAll(text);
			if (activeNavigationGroupByNameCheckAll == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			bool isActive = activeNavigationGroupByNameCheckAll.ActiveListenerList.Count > 0;
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, isActive, false);
		}
	}
}
