using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CED RID: 19693
	public class CommonConsumeNavigationNext : HotKeyComponent
	{
		// Token: 0x060333D6 RID: 209878 RVA: 0x00CD46BD File Offset: 0x00CD28BD
		public CommonConsumeNavigationNext(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333D7 RID: 209879 RVA: 0x00CD46C6 File Offset: 0x00CD28C6
		protected override void OnRelease(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.HandleCommonConsumeNavigation(config.BindButtonTag);
		}

		// Token: 0x060333D8 RID: 209880 RVA: 0x00CD46DC File Offset: 0x00CD28DC
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
			string text = null;
			if (!string.IsNullOrEmpty(bindButtonTag))
			{
				navigationGroup.GroupNameMap.TryGetValue(bindButtonTag, out text);
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
