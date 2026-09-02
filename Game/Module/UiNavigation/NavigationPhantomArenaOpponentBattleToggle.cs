using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CBA RID: 19642
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationPhantomArenaOpponentBattleToggle : NavigationButton
	{
		// Token: 0x06033278 RID: 209528 RVA: 0x00CCEC44 File Offset: 0x00CCCE44
		public NavigationPhantomArenaOpponentBattleToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x170087C3 RID: 34755
		// (get) Token: 0x06033279 RID: 209529 RVA: 0x00CCEC50 File Offset: 0x00CCCE50
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

		// Token: 0x0603327A RID: 209530 RVA: 0x00CCEC92 File Offset: 0x00CCCE92
		protected override void OnButtonClick()
		{
		}

		// Token: 0x0603327B RID: 209531 RVA: 0x00CCEC94 File Offset: 0x00CCCE94
		protected override void OnNotifyFocusListener(bool isSameListener)
		{
			if (this.Proxy != null && !isSameListener)
			{
				this.Proxy.GamepadLogic.HideCardTips();
			}
		}

		// Token: 0x0603327C RID: 209532 RVA: 0x00CCECB1 File Offset: 0x00CCCEB1
		protected override bool OnCheckFindOpposite()
		{
			return this.Proxy == null || (!this.Proxy.GamepadLogic.IsInCardSelectState && (!this.Proxy.SkillTriggerMask.IsInSkillInteract || this.IsInSkillInteract));
		}

		// Token: 0x0603327D RID: 209533 RVA: 0x00CCECEC File Offset: 0x00CCCEEC
		public void SwitchBattleCardTips()
		{
			if (this.Proxy != null)
			{
				int index = int.Parse(this.ParamList[0]);
				this.Proxy.GamepadLogic.SwitchOpponentBattleCardTips(index);
			}
		}

		// Token: 0x170087C4 RID: 34756
		// (get) Token: 0x0603327E RID: 209534 RVA: 0x00CCED24 File Offset: 0x00CCCF24
		public bool IsInSkillInteract
		{
			get
			{
				if (this.Proxy != null)
				{
					int index = int.Parse(this.ParamList[0]);
					return this.Proxy.GamepadLogic.IsInSkillInteractByOpponentIndex(index);
				}
				return false;
			}
		}

		// Token: 0x0401DB8A RID: 121738
		protected PhantomArenaBattleProxy ProxyInternal;
	}
}
