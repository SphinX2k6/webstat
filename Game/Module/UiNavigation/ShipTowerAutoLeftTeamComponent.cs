using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D5C RID: 19804
	public class ShipTowerAutoLeftTeamComponent : HotKeyComponent
	{
		// Token: 0x0603359D RID: 210333 RVA: 0x00CD8699 File Offset: 0x00CD6899
		public ShipTowerAutoLeftTeamComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603359E RID: 210334 RVA: 0x00CD86A9 File Offset: 0x00CD68A9
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.ClickButtonInside(config.BindButtonTag);
			this.AddTickHandle();
		}

		// Token: 0x0603359F RID: 210335 RVA: 0x00CD86C2 File Offset: 0x00CD68C2
		protected override void OnUnRegisterMe()
		{
			this.RemoveTickHandle();
		}

		// Token: 0x060335A0 RID: 210336 RVA: 0x00CD86CA File Offset: 0x00CD68CA
		private void AddTickHandle()
		{
			if (this.TickHandle == -1)
			{
				this.TickHandle = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "NavigationDraggableComponent", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
			}
		}

		// Token: 0x060335A1 RID: 210337 RVA: 0x00CD86FF File Offset: 0x00CD68FF
		private void RemoveTickHandle()
		{
			if (this.TickHandle != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickHandle);
				this.TickHandle = -1;
			}
		}

		// Token: 0x060335A2 RID: 210338 RVA: 0x00CD8724 File Offset: 0x00CD6924
		private void OnTick(float deltaTime)
		{
			TsUiNavigationBehaviorListener currentNavigationFocusListener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
			if (currentNavigationFocusListener == null)
			{
				return;
			}
			NavigationGroup navigationGroup = currentNavigationFocusListener.GetNavigationGroup();
			string nextGroupName = navigationGroup.NextGroupName;
			UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
			NavigationGroup navigationGroup2 = (currentViewHandle != null) ? currentViewHandle.GetActiveNavigationGroupByNameCheckAll(nextGroupName) : null;
			bool flag;
			if (navigationGroup2 == null)
			{
				flag = (null != null);
			}
			else
			{
				List<TsUiNavigationBehaviorListener> activeListenerList = navigationGroup2.ActiveListenerList;
				if (activeListenerList == null)
				{
					flag = (null != null);
				}
				else
				{
					TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = activeListenerList.ElementAtOrDefault(0);
					flag = (((tsUiNavigationBehaviorListener != null) ? tsUiNavigationBehaviorListener.PanelConfig : null) != null);
				}
			}
			if (flag)
			{
				ControllerBase<UiNavigationNewController>.Instance.JumpNavigationGroupByName(navigationGroup.GroupName, nextGroupName);
				this.RemoveTickHandle();
			}
		}

		// Token: 0x060335A3 RID: 210339 RVA: 0x00CD87A4 File Offset: 0x00CD69A4
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
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = ControllerBase<UiNavigationNewController>.Instance.GetFocusListenerInsideListenerByTag(focusListener, bindButtonTag);
			if (tsUiNavigationBehaviorListener == null)
			{
				tsUiNavigationBehaviorListener = focusListener.GetChildListenerByTag(bindButtonTag);
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, tsUiNavigationBehaviorListener != null && tsUiNavigationBehaviorListener.IsListenerActive(), false);
		}

		// Token: 0x0401DC6B RID: 121963
		private int TickHandle = -1;
	}
}
