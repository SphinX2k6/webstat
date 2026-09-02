using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D38 RID: 19768
	[NullableContext(2)]
	[Nullable(0)]
	public class PhantomArenaBattleCardRecycleComponent : LongTimeToTriggerComponent
	{
		// Token: 0x06033524 RID: 210212 RVA: 0x00CD7780 File Offset: 0x00CD5980
		public PhantomArenaBattleCardRecycleComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x170087D3 RID: 34771
		// (get) Token: 0x06033525 RID: 210213 RVA: 0x00CD778C File Offset: 0x00CD598C
		protected PhantomArenaBattleProxy Proxy
		{
			get
			{
				if (this.ProxyInternal == null)
				{
					UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PhantomArenaBattleView);
					this.ProxyInternal = (((viewByName != null) ? viewByName.OpenParam : null) as PhantomArenaBattleProxy);
				}
				return this.ProxyInternal;
			}
		}

		// Token: 0x06033526 RID: 210214 RVA: 0x00CD77CE File Offset: 0x00CD59CE
		[NullableContext(1)]
		protected override void ClickButton(string tag)
		{
			if (this.Proxy != null)
			{
				this.Proxy.GamepadLogic.TriggerRecycleCard();
			}
		}

		// Token: 0x06033527 RID: 210215 RVA: 0x00CD77E8 File Offset: 0x00CD59E8
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			if (this.Proxy == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (!this.Proxy.GamepadLogic.IsInCardSelectState)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (this.Proxy.IsInPanelInteract && !this.Proxy.IsMainInVisible)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x0401DC53 RID: 121939
		protected PhantomArenaBattleProxy ProxyInternal;
	}
}
