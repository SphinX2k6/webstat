using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D3D RID: 19773
	public class PhantomArenaBattleNavigationNextComponent : NavigationGroupNextComponent
	{
		// Token: 0x0603353E RID: 210238 RVA: 0x00CD7CAA File Offset: 0x00CD5EAA
		public PhantomArenaBattleNavigationNextComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603353F RID: 210239 RVA: 0x00CD7CB4 File Offset: 0x00CD5EB4
		protected override void OnInit()
		{
			base.OnInit();
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PhantomArenaBattleDetailsView);
			this.Proxy = (((viewByName != null) ? viewByName.OpenParam : null) as PhantomArenaBattleDetailsViewProxy);
		}

		// Token: 0x06033540 RID: 210240 RVA: 0x00CD7CEE File Offset: 0x00CD5EEE
		protected override void JumpToNextGroupListener()
		{
			base.JumpToNextGroupListener();
			if (this.Proxy != null)
			{
				this.Proxy.SetIsInGamepadNavigation(true);
			}
		}

		// Token: 0x06033541 RID: 210241 RVA: 0x00CD7D0A File Offset: 0x00CD5F0A
		protected override void OnRelease(HotKeyMap config)
		{
			base.OnRelease(config);
			if (this.Proxy != null)
			{
				this.Proxy.SetIsInGamepadNavigation(true);
			}
		}

		// Token: 0x0401DC55 RID: 121941
		[Nullable(2)]
		protected PhantomArenaBattleDetailsViewProxy Proxy;
	}
}
