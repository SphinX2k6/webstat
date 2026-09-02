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
	// Token: 0x02004CBD RID: 19645
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationPhantomArenaOwnHandToggle : NavigationButton
	{
		// Token: 0x0603328C RID: 209548 RVA: 0x00CCEFA2 File Offset: 0x00CCD1A2
		public NavigationPhantomArenaOwnHandToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x170087C8 RID: 34760
		// (get) Token: 0x0603328D RID: 209549 RVA: 0x00CCEFB0 File Offset: 0x00CCD1B0
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

		// Token: 0x0603328E RID: 209550 RVA: 0x00CCEFF2 File Offset: 0x00CCD1F2
		protected override void OnButtonClick()
		{
		}

		// Token: 0x0603328F RID: 209551 RVA: 0x00CCEFF4 File Offset: 0x00CCD1F4
		protected override bool OnCheckFindOpposite()
		{
			return this.Proxy == null || !this.Proxy.GamepadLogic.IsInCardSelectState;
		}

		// Token: 0x06033290 RID: 209552 RVA: 0x00CCF015 File Offset: 0x00CCD215
		protected override void OnNotifyFocusListener(bool isSameListener)
		{
			if (this.Proxy != null && !isSameListener)
			{
				this.Proxy.GamepadLogic.HideCardTips();
			}
		}

		// Token: 0x06033291 RID: 209553 RVA: 0x00CCF032 File Offset: 0x00CCD232
		private int GetHandListenerIndex()
		{
			return (this.PanelHandle as PhantomArenaBattlePanelHandle).GetNavigationListenerListByType(ENavigationSelectableDefine.PhantomArenaOwnHandToggle, "GroupNor").IndexOf(this.Listener);
		}

		// Token: 0x06033292 RID: 209554 RVA: 0x00CCF058 File Offset: 0x00CCD258
		[NullableContext(0)]
		public UniTask<bool> TriggerSelectCard()
		{
			NavigationPhantomArenaOwnHandToggle.<TriggerSelectCard>d__8 <TriggerSelectCard>d__;
			<TriggerSelectCard>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TriggerSelectCard>d__.<>4__this = this;
			<TriggerSelectCard>d__.<>1__state = -1;
			<TriggerSelectCard>d__.<>t__builder.Start<NavigationPhantomArenaOwnHandToggle.<TriggerSelectCard>d__8>(ref <TriggerSelectCard>d__);
			return <TriggerSelectCard>d__.<>t__builder.Task;
		}

		// Token: 0x06033293 RID: 209555 RVA: 0x00CCF09C File Offset: 0x00CCD29C
		public void SwitchHandCardTips()
		{
			if (this.Proxy != null)
			{
				int handListenerIndex = this.GetHandListenerIndex();
				this.Proxy.GamepadLogic.SwitchHandCardTips(handListenerIndex);
			}
		}

		// Token: 0x0401DB8D RID: 121741
		protected PhantomArenaBattleProxy ProxyInternal;
	}
}
