using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D5D RID: 19805
	public class ShipTowerSwitchRightTeamComponent : HotKeyComponent
	{
		// Token: 0x060335A4 RID: 210340 RVA: 0x00CD8819 File Offset: 0x00CD6A19
		public ShipTowerSwitchRightTeamComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335A5 RID: 210341 RVA: 0x00CD8824 File Offset: 0x00CD6A24
		protected override void OnRelease(HotKeyMap config)
		{
			TsUiNavigationBehaviorListener triggerListener = this.GetTriggerListener();
			if (triggerListener != null)
			{
				ControllerBase<UiNavigationNewController>.Instance.InteractClickByListener(triggerListener);
			}
		}

		// Token: 0x060335A6 RID: 210342 RVA: 0x00CD8848 File Offset: 0x00CD6A48
		[NullableContext(2)]
		private TsUiNavigationBehaviorListener GetTriggerListener()
		{
			UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
			string bindButtonTag = base.GetBindButtonTag();
			if (bindButtonTag == null)
			{
				return null;
			}
			List<TsUiNavigationBehaviorListener> list = (currentViewHandle != null) ? currentViewHandle.GetActiveListenerListByTag(bindButtonTag) : null;
			if (list == null)
			{
				return null;
			}
			TsUiNavigationBehaviorListener result = null;
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in list)
			{
				UUIExtendToggle uuiextendToggle = tsUiNavigationBehaviorListener.GetSelectableComponent() as UUIExtendToggle;
				if (uuiextendToggle != null && uuiextendToggle.GetToggleState() != EToggleState.ETT_Checked)
				{
					result = tsUiNavigationBehaviorListener;
					break;
				}
			}
			return result;
		}

		// Token: 0x060335A7 RID: 210343 RVA: 0x00CD88E0 File Offset: 0x00CD6AE0
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			if (StringUtils.IsEmpty(base.GetBindButtonTag()))
			{
				return;
			}
			bool isShowLeftTeamPanel = ModelBase<ShipTowerModel>.Instance.IsShowLeftTeamPanel;
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, isShowLeftTeamPanel, false);
		}
	}
}
