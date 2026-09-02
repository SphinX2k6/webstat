using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D39 RID: 19769
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleCardSelectComponent : PhantomArenaBattleComponentBase
	{
		// Token: 0x06033528 RID: 210216 RVA: 0x00CD7850 File Offset: 0x00CD5A50
		public PhantomArenaBattleCardSelectComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033529 RID: 210217 RVA: 0x00CD785C File Offset: 0x00CD5A5C
		protected override void OnPress(HotKeyMap _)
		{
			if (base.Proxy == null)
			{
				return;
			}
			if (base.Proxy.GamepadLogic.IsInCardSelectState)
			{
				this.PutDownCardToFunctional().Forget();
				return;
			}
			TsUiNavigationBehaviorListener currentNavigationFocusListener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
			NavigationSelectableBase navigationSelectableBase = (currentNavigationFocusListener != null) ? currentNavigationFocusListener.GetNavigationComponent() : null;
			if (navigationSelectableBase == null)
			{
				return;
			}
			if (navigationSelectableBase.GetType() == ENavigationSelectableDefine.PhantomArenaOwnHandToggle)
			{
				this.SelectHandCard(navigationSelectableBase).Forget();
				return;
			}
			if (navigationSelectableBase.GetType() == ENavigationSelectableDefine.PhantomArenaOwnBattleToggle)
			{
				this.SelectBattleCard(navigationSelectableBase).Forget();
			}
		}

		// Token: 0x0603352A RID: 210218 RVA: 0x00CD78D8 File Offset: 0x00CD5AD8
		private UniTask PutDownCardToFunctional()
		{
			PhantomArenaBattleCardSelectComponent.<PutDownCardToFunctional>d__2 <PutDownCardToFunctional>d__;
			<PutDownCardToFunctional>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PutDownCardToFunctional>d__.<>4__this = this;
			<PutDownCardToFunctional>d__.<>1__state = -1;
			<PutDownCardToFunctional>d__.<>t__builder.Start<PhantomArenaBattleCardSelectComponent.<PutDownCardToFunctional>d__2>(ref <PutDownCardToFunctional>d__);
			return <PutDownCardToFunctional>d__.<>t__builder.Task;
		}

		// Token: 0x0603352B RID: 210219 RVA: 0x00CD791C File Offset: 0x00CD5B1C
		private UniTask SelectHandCard(NavigationSelectableBase navigationComponent)
		{
			PhantomArenaBattleCardSelectComponent.<SelectHandCard>d__3 <SelectHandCard>d__;
			<SelectHandCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SelectHandCard>d__.<>4__this = this;
			<SelectHandCard>d__.navigationComponent = navigationComponent;
			<SelectHandCard>d__.<>1__state = -1;
			<SelectHandCard>d__.<>t__builder.Start<PhantomArenaBattleCardSelectComponent.<SelectHandCard>d__3>(ref <SelectHandCard>d__);
			return <SelectHandCard>d__.<>t__builder.Task;
		}

		// Token: 0x0603352C RID: 210220 RVA: 0x00CD7968 File Offset: 0x00CD5B68
		private UniTask SelectBattleCard(NavigationSelectableBase navigationComponent)
		{
			PhantomArenaBattleCardSelectComponent.<SelectBattleCard>d__4 <SelectBattleCard>d__;
			<SelectBattleCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SelectBattleCard>d__.navigationComponent = navigationComponent;
			<SelectBattleCard>d__.<>1__state = -1;
			<SelectBattleCard>d__.<>t__builder.Start<PhantomArenaBattleCardSelectComponent.<SelectBattleCard>d__4>(ref <SelectBattleCard>d__);
			return <SelectBattleCard>d__.<>t__builder.Task;
		}

		// Token: 0x0603352D RID: 210221 RVA: 0x00CD79AC File Offset: 0x00CD5BAC
		[NullableContext(2)]
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
			if (index >= list.Count)
			{
				return null;
			}
			return list[index];
		}

		// Token: 0x0603352E RID: 210222 RVA: 0x00CD7A44 File Offset: 0x00CD5C44
		[NullableContext(2)]
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
			if (index >= list.Count)
			{
				return null;
			}
			return list[index];
		}
	}
}
