using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C98 RID: 19608
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattlePanelHandle : SpecialPanelHandleBase
	{
		// Token: 0x0603319A RID: 209306 RVA: 0x00CCC378 File Offset: 0x00CCA578
		public PhantomArenaBattlePanelHandle(string type) : base(type)
		{
		}

		// Token: 0x170087BB RID: 34747
		// (get) Token: 0x0603319B RID: 209307 RVA: 0x00CCC384 File Offset: 0x00CCA584
		private PhantomArenaBattleProxy Proxy
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

		// Token: 0x0603319C RID: 209308 RVA: 0x00CCC3C8 File Offset: 0x00CCA5C8
		protected override List<TsUiNavigationBehaviorListener> OnGetSuitableNavigationListenerList(bool isDefault)
		{
			if (this.Proxy == null)
			{
				return new List<TsUiNavigationBehaviorListener>();
			}
			if (this.Proxy.SkillTriggerMask.IsInSkillInteract)
			{
				return this.GetListenerListBySkillInteract();
			}
			if (this.Proxy.IsInPanelInteract)
			{
				return this.GetListenerListByPanelInteract();
			}
			if (ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetHandCardIdList().Count == 0)
			{
				return this.GetListenerListByBattle();
			}
			return this.GetListenerListByHand();
		}

		// Token: 0x0603319D RID: 209309 RVA: 0x00CCC434 File Offset: 0x00CCA634
		private List<TsUiNavigationBehaviorListener> GetListenerListBySkillInteract()
		{
			List<TsUiNavigationBehaviorListener> navigationListenerListByTypeList = this.GetNavigationListenerListByTypeList(new ENavigationSelectableDefine[]
			{
				ENavigationSelectableDefine.PhantomArenaOpponentBattleToggle,
				ENavigationSelectableDefine.PhantomArenaOwnBattleToggle
			}, "GroupTarget");
			if (navigationListenerListByTypeList == null)
			{
				return new List<TsUiNavigationBehaviorListener>();
			}
			List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in navigationListenerListByTypeList)
			{
				NavigationSelectableBase navigationComponent = tsUiNavigationBehaviorListener.GetNavigationComponent();
				ENavigationSelectableDefine type = navigationComponent.GetType();
				if (type == ENavigationSelectableDefine.PhantomArenaOpponentBattleToggle)
				{
					NavigationPhantomArenaOpponentBattleToggle navigationPhantomArenaOpponentBattleToggle = navigationComponent as NavigationPhantomArenaOpponentBattleToggle;
					if (navigationPhantomArenaOpponentBattleToggle != null && navigationPhantomArenaOpponentBattleToggle.IsInSkillInteract)
					{
						list.Add(tsUiNavigationBehaviorListener);
					}
				}
				else if (type == ENavigationSelectableDefine.PhantomArenaOwnBattleToggle)
				{
					NavigationPhantomArenaOwnBattleToggle navigationPhantomArenaOwnBattleToggle = navigationComponent as NavigationPhantomArenaOwnBattleToggle;
					if (navigationPhantomArenaOwnBattleToggle != null && navigationPhantomArenaOwnBattleToggle.IsInSkillInteract)
					{
						list.Add(tsUiNavigationBehaviorListener);
					}
				}
			}
			return list;
		}

		// Token: 0x0603319E RID: 209310 RVA: 0x00CCC500 File Offset: 0x00CCA700
		private List<TsUiNavigationBehaviorListener> GetListenerListByPanelInteract()
		{
			if (this.Proxy == null)
			{
				return new List<TsUiNavigationBehaviorListener>();
			}
			if (!this.Proxy.IsMainInVisible)
			{
				return new List<TsUiNavigationBehaviorListener>();
			}
			return this.GetNavigationListenerListByType(ENavigationSelectableDefine.PhantomArenaOwnBattleToggle, "GroupNor");
		}

		// Token: 0x0603319F RID: 209311 RVA: 0x00CCC530 File Offset: 0x00CCA730
		private List<TsUiNavigationBehaviorListener> GetListenerListByBattle()
		{
			return this.GetNavigationListenerListByType(ENavigationSelectableDefine.PhantomArenaOwnBattleToggle, "GroupNor");
		}

		// Token: 0x060331A0 RID: 209312 RVA: 0x00CCC53F File Offset: 0x00CCA73F
		private List<TsUiNavigationBehaviorListener> GetListenerListByHand()
		{
			return this.GetNavigationListenerListByType(ENavigationSelectableDefine.PhantomArenaOwnHandToggle, "GroupNor");
		}

		// Token: 0x060331A1 RID: 209313 RVA: 0x00CCC550 File Offset: 0x00CCA750
		public List<TsUiNavigationBehaviorListener> GetNavigationListenerListByType(ENavigationSelectableDefine type, string groupName = "GroupNor")
		{
			NavigationGroup navigationGroup = base.GetNavigationGroup(groupName);
			if (navigationGroup == null)
			{
				return new List<TsUiNavigationBehaviorListener>();
			}
			List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in navigationGroup.ListenerList)
			{
				if (tsUiNavigationBehaviorListener.GetNavigationComponent().GetType() == type)
				{
					list.Add(tsUiNavigationBehaviorListener);
				}
			}
			return list;
		}

		// Token: 0x060331A2 RID: 209314 RVA: 0x00CCC5CC File Offset: 0x00CCA7CC
		public List<TsUiNavigationBehaviorListener> GetNavigationListenerListByTypeList(ENavigationSelectableDefine[] typeList, string groupName)
		{
			NavigationGroup navigationGroup = base.GetNavigationGroup(groupName);
			if (navigationGroup == null)
			{
				return new List<TsUiNavigationBehaviorListener>();
			}
			List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in navigationGroup.ListenerList)
			{
				ENavigationSelectableDefine type = tsUiNavigationBehaviorListener.GetNavigationComponent().GetType();
				if (Array.IndexOf<ENavigationSelectableDefine>(typeList, type) >= 0)
				{
					list.Add(tsUiNavigationBehaviorListener);
				}
			}
			return list;
		}

		// Token: 0x0401DB68 RID: 121704
		private PhantomArenaBattleProxy ProxyInternal;
	}
}
