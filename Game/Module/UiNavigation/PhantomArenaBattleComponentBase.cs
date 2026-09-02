using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D3B RID: 19771
	[NullableContext(2)]
	[Nullable(0)]
	public class PhantomArenaBattleComponentBase : HotKeyComponent
	{
		// Token: 0x06033536 RID: 210230 RVA: 0x00CD7BBF File Offset: 0x00CD5DBF
		public PhantomArenaBattleComponentBase(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x170087D4 RID: 34772
		// (get) Token: 0x06033537 RID: 210231 RVA: 0x00CD7BC8 File Offset: 0x00CD5DC8
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

		// Token: 0x06033538 RID: 210232 RVA: 0x00CD7C0C File Offset: 0x00CD5E0C
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			if (this.Proxy == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (!this.Proxy.IsInPanelInteract)
			{
				this.OnRefreshSelfHotKeyStateImplement();
				return;
			}
			if (this.Proxy.IsMainInVisible)
			{
				this.OnRefreshSelfHotKeyStateIsMainInVisible();
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
		}

		// Token: 0x06033539 RID: 210233 RVA: 0x00CD7C5C File Offset: 0x00CD5E5C
		protected virtual void OnRefreshSelfHotKeyStateImplement()
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x0603353A RID: 210234 RVA: 0x00CD7C67 File Offset: 0x00CD5E67
		protected virtual void OnRefreshSelfHotKeyStateIsMainInVisible()
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
		}

		// Token: 0x0401DC54 RID: 121940
		private PhantomArenaBattleProxy ProxyInternal;
	}
}
