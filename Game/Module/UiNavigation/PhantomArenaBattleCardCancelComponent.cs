using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D37 RID: 19767
	[NullableContext(2)]
	[Nullable(0)]
	public class PhantomArenaBattleCardCancelComponent : PhantomArenaBattleComponentBase
	{
		// Token: 0x0603351F RID: 210207 RVA: 0x00CD7583 File Offset: 0x00CD5783
		public PhantomArenaBattleCardCancelComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033520 RID: 210208 RVA: 0x00CD758C File Offset: 0x00CD578C
		protected override void OnPress(HotKeyMap config)
		{
			if (base.Proxy != null)
			{
				int index = base.Proxy.GamepadLogic.SelectedCard.Data.Index;
				int handIndex = base.Proxy.GamepadLogic.HandIndex;
				base.Proxy.GamepadLogic.CancelSelectedCard();
				Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
				if (index != -1)
				{
					TsUiNavigationBehaviorListener ownBattleSlotListenerByIndex = this.GetOwnBattleSlotListenerByIndex(index);
					ControllerBase<UiNavigationNewController>.Instance.SwitchNavigationFocus(ownBattleSlotListenerByIndex);
					return;
				}
				if (handIndex != -1)
				{
					TsUiNavigationBehaviorListener ownHandCardListenerByIndex = this.GetOwnHandCardListenerByIndex(handIndex);
					ControllerBase<UiNavigationNewController>.Instance.SwitchNavigationFocus(ownHandCardListenerByIndex);
				}
			}
		}

		// Token: 0x06033521 RID: 210209 RVA: 0x00CD7616 File Offset: 0x00CD5816
		protected override void OnRefreshSelfHotKeyStateImplement()
		{
			if (base.Proxy == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (!base.Proxy.GamepadLogic.IsInCardSelectState)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x06033522 RID: 210210 RVA: 0x00CD7650 File Offset: 0x00CD5850
		private TsUiNavigationBehaviorListener GetOwnBattleSlotListenerByIndex(int index)
		{
			TsUiNavigationBehaviorListener currentNavigationFocusListener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
			NavigationGroup navigationGroup = (currentNavigationFocusListener != null) ? currentNavigationFocusListener.GetNavigationGroup() : null;
			if (navigationGroup == null)
			{
				return null;
			}
			List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in navigationGroup.ListenerList)
			{
				if (tsUiNavigationBehaviorListener.GetNavigationComponent().GetType() == ENavigationSelectableDefine.PhantomArenaOwnBattleToggle)
				{
					list.Add(tsUiNavigationBehaviorListener);
				}
			}
			if (list.Count <= index)
			{
				return null;
			}
			return list[index];
		}

		// Token: 0x06033523 RID: 210211 RVA: 0x00CD76E8 File Offset: 0x00CD58E8
		private TsUiNavigationBehaviorListener GetOwnHandCardListenerByIndex(int index)
		{
			TsUiNavigationBehaviorListener currentNavigationFocusListener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
			NavigationGroup navigationGroup = (currentNavigationFocusListener != null) ? currentNavigationFocusListener.GetNavigationGroup() : null;
			if (navigationGroup == null)
			{
				return null;
			}
			List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in navigationGroup.ListenerList)
			{
				if (tsUiNavigationBehaviorListener.GetNavigationComponent().GetType() == ENavigationSelectableDefine.PhantomArenaOwnHandToggle)
				{
					list.Add(tsUiNavigationBehaviorListener);
				}
			}
			if (list.Count <= index)
			{
				return null;
			}
			return list[index];
		}
	}
}
