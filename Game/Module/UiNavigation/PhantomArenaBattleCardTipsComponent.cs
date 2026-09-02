using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D3A RID: 19770
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleCardTipsComponent : PhantomArenaBattleComponentBase
	{
		// Token: 0x0603352F RID: 210223 RVA: 0x00CD7ADC File Offset: 0x00CD5CDC
		public PhantomArenaBattleCardTipsComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033530 RID: 210224 RVA: 0x00CD7AE8 File Offset: 0x00CD5CE8
		protected override void OnPress(HotKeyMap _)
		{
			TsUiNavigationBehaviorListener currentNavigationFocusListener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
			NavigationSelectableBase navigationSelectableBase = (currentNavigationFocusListener != null) ? currentNavigationFocusListener.GetNavigationComponent() : null;
			if (navigationSelectableBase == null)
			{
				return;
			}
			if (navigationSelectableBase.GetType() == ENavigationSelectableDefine.PhantomArenaOwnHandToggle)
			{
				this.SwitchHandCardTips(navigationSelectableBase);
				return;
			}
			if (navigationSelectableBase.GetType() == ENavigationSelectableDefine.PhantomArenaOwnBattleToggle)
			{
				this.SwitchOwnBattleCardTips(navigationSelectableBase);
				return;
			}
			if (navigationSelectableBase.GetType() == ENavigationSelectableDefine.PhantomArenaOpponentBattleToggle)
			{
				this.SwitchOpponentBattleCardTips(navigationSelectableBase);
			}
		}

		// Token: 0x06033531 RID: 210225 RVA: 0x00CD7B45 File Offset: 0x00CD5D45
		protected override void OnRefreshSelfHotKeyStateImplement()
		{
			if (base.Proxy == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (base.Proxy.GamepadLogic.IsInCardSelectState)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x06033532 RID: 210226 RVA: 0x00CD7B7E File Offset: 0x00CD5D7E
		protected override void OnRefreshSelfHotKeyStateIsMainInVisible()
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x06033533 RID: 210227 RVA: 0x00CD7B89 File Offset: 0x00CD5D89
		protected void SwitchHandCardTips(NavigationSelectableBase navigationComponent)
		{
			NavigationPhantomArenaOwnHandToggle navigationPhantomArenaOwnHandToggle = navigationComponent as NavigationPhantomArenaOwnHandToggle;
			if (navigationPhantomArenaOwnHandToggle == null)
			{
				return;
			}
			navigationPhantomArenaOwnHandToggle.SwitchHandCardTips();
		}

		// Token: 0x06033534 RID: 210228 RVA: 0x00CD7B9B File Offset: 0x00CD5D9B
		protected void SwitchOwnBattleCardTips(NavigationSelectableBase navigationComponent)
		{
			NavigationPhantomArenaOwnBattleToggle navigationPhantomArenaOwnBattleToggle = navigationComponent as NavigationPhantomArenaOwnBattleToggle;
			if (navigationPhantomArenaOwnBattleToggle == null)
			{
				return;
			}
			navigationPhantomArenaOwnBattleToggle.SwitchBattleCardTips();
		}

		// Token: 0x06033535 RID: 210229 RVA: 0x00CD7BAD File Offset: 0x00CD5DAD
		protected void SwitchOpponentBattleCardTips(NavigationSelectableBase navigationComponent)
		{
			NavigationPhantomArenaOpponentBattleToggle navigationPhantomArenaOpponentBattleToggle = navigationComponent as NavigationPhantomArenaOpponentBattleToggle;
			if (navigationPhantomArenaOpponentBattleToggle == null)
			{
				return;
			}
			navigationPhantomArenaOpponentBattleToggle.SwitchBattleCardTips();
		}
	}
}
