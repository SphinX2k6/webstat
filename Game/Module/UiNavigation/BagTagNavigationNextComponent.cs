using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CE4 RID: 19684
	public class BagTagNavigationNextComponent : NavigationGroupNextComponent
	{
		// Token: 0x060333B1 RID: 209841 RVA: 0x00CD40D3 File Offset: 0x00CD22D3
		public BagTagNavigationNextComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333B2 RID: 209842 RVA: 0x00CD40DC File Offset: 0x00CD22DC
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
			string value = null;
			if (!string.IsNullOrEmpty(bindButtonTag))
			{
				navigationGroup.GroupNameMap.TryGetValue(bindButtonTag, out value);
			}
			else
			{
				value = navigationGroup.NextGroupName;
			}
			if (string.IsNullOrEmpty(value))
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			NavigationGroup navigationGroupByName = viewHandle.GetNavigationGroupByName(navigationGroup.NextGroupName);
			if (navigationGroupByName == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			TsUiNavigationBehaviorListener defaultListener = navigationGroupByName.DefaultListener;
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, defaultListener != null && defaultListener.IsScrollOrLayoutActive(), false);
		}
	}
}
