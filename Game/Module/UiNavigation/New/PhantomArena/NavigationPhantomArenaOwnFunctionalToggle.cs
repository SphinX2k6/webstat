using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation.New.PhantomArena
{
	// Token: 0x02004D86 RID: 19846
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationPhantomArenaOwnFunctionalToggle : NavigationButton
	{
		// Token: 0x0603363A RID: 210490 RVA: 0x00CDA90A File Offset: 0x00CD8B0A
		public NavigationPhantomArenaOwnFunctionalToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x170087D7 RID: 34775
		// (get) Token: 0x0603363B RID: 210491 RVA: 0x00CDA918 File Offset: 0x00CD8B18
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

		// Token: 0x0603363C RID: 210492 RVA: 0x00CDA95A File Offset: 0x00CD8B5A
		protected override void OnButtonClick()
		{
		}

		// Token: 0x0603363D RID: 210493 RVA: 0x00CDA95C File Offset: 0x00CD8B5C
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

		// Token: 0x0401DC8B RID: 121995
		protected PhantomArenaBattleProxy ProxyInternal;
	}
}
