using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CBC RID: 19644
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationPhantomArenaOwnBattleToggle : NavigationButton
	{
		// Token: 0x06033284 RID: 209540 RVA: 0x00CCEDEE File Offset: 0x00CCCFEE
		public NavigationPhantomArenaOwnBattleToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x170087C6 RID: 34758
		// (get) Token: 0x06033285 RID: 209541 RVA: 0x00CCEDFC File Offset: 0x00CCCFFC
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

		// Token: 0x06033286 RID: 209542 RVA: 0x00CCEE3E File Offset: 0x00CCD03E
		protected override void OnButtonClick()
		{
		}

		// Token: 0x06033287 RID: 209543 RVA: 0x00CCEE40 File Offset: 0x00CCD040
		protected override bool OnCheckFindOpposite()
		{
			return this.Proxy == null || !this.Proxy.SkillTriggerMask.IsInSkillInteract || this.IsInSkillInteract;
		}

		// Token: 0x06033288 RID: 209544 RVA: 0x00CCEE68 File Offset: 0x00CCD068
		protected override void OnNotifyFocusListener(bool isSameListener)
		{
			int index = int.Parse(this.ParamList[0]);
			if (this.Proxy != null && !isSameListener)
			{
				this.Proxy.GamepadLogic.HideCardTips();
				if (this.Proxy.GamepadLogic.IsInHandCardSelectState)
				{
					this.Proxy.GamepadLogic.MoveHandCardToFunctional(index);
					return;
				}
				if (this.Proxy.GamepadLogic.IsInBattleCardSelectState)
				{
					this.Proxy.GamepadLogic.MoveBattleCardToFunctional(index);
				}
			}
		}

		// Token: 0x06033289 RID: 209545 RVA: 0x00CCEEEC File Offset: 0x00CCD0EC
		[NullableContext(0)]
		public UniTask<bool> TriggerSelectCard()
		{
			NavigationPhantomArenaOwnBattleToggle.<TriggerSelectCard>d__7 <TriggerSelectCard>d__;
			<TriggerSelectCard>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TriggerSelectCard>d__.<>4__this = this;
			<TriggerSelectCard>d__.<>1__state = -1;
			<TriggerSelectCard>d__.<>t__builder.Start<NavigationPhantomArenaOwnBattleToggle.<TriggerSelectCard>d__7>(ref <TriggerSelectCard>d__);
			return <TriggerSelectCard>d__.<>t__builder.Task;
		}

		// Token: 0x0603328A RID: 209546 RVA: 0x00CCEF30 File Offset: 0x00CCD130
		public void SwitchBattleCardTips()
		{
			if (this.Proxy != null)
			{
				int index = int.Parse(this.ParamList[0]);
				this.Proxy.GamepadLogic.SwitchOwnBattleCardTips(index);
			}
		}

		// Token: 0x170087C7 RID: 34759
		// (get) Token: 0x0603328B RID: 209547 RVA: 0x00CCEF68 File Offset: 0x00CCD168
		public bool IsInSkillInteract
		{
			get
			{
				if (this.Proxy != null)
				{
					int index = int.Parse(this.ParamList[0]);
					return this.Proxy.GamepadLogic.IsInSkillInteractByOwnIndex(index);
				}
				return false;
			}
		}

		// Token: 0x0401DB8C RID: 121740
		protected PhantomArenaBattleProxy ProxyInternal;
	}
}
