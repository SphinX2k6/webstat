using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D31 RID: 19761
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class NavigationGroupPrevComponentBase : HotKeyComponent
	{
		// Token: 0x0603350B RID: 210187 RVA: 0x00CD7377 File Offset: 0x00CD5577
		protected NavigationGroupPrevComponentBase(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603350C RID: 210188 RVA: 0x00CD7380 File Offset: 0x00CD5580
		private void JumpPrevNavigation(ENavigationDirectionType direction)
		{
			if (direction == this.GetDirection())
			{
				ControllerBase<UiNavigationNewController>.Instance.JumpNavigationGroup(ELGUINavigationDirection.Prev);
			}
		}

		// Token: 0x0603350D RID: 210189
		protected abstract ENavigationDirectionType GetDirection();

		// Token: 0x0603350E RID: 210190 RVA: 0x00CD7397 File Offset: 0x00CD5597
		protected override void OnRelease(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.JumpNavigationGroup(ELGUINavigationDirection.Prev);
		}

		// Token: 0x0603350F RID: 210191 RVA: 0x00CD73A5 File Offset: 0x00CD55A5
		protected override void OnStartInputAxis(string axisName)
		{
			UiNavigationJoystickInput.RegisterLeftJoystickFunction(new Action<ENavigationDirectionType>(this.JumpPrevNavigation));
		}

		// Token: 0x06033510 RID: 210192 RVA: 0x00CD73B8 File Offset: 0x00CD55B8
		protected override void OnFinishInputAxis(string axisName)
		{
			UiNavigationJoystickInput.UnRegisterLeftJoystickFunction(new Action<ENavigationDirectionType>(this.JumpPrevNavigation));
		}

		// Token: 0x06033511 RID: 210193 RVA: 0x00CD73CB File Offset: 0x00CD55CB
		protected override void OnClear()
		{
			UiNavigationJoystickInput.UnRegisterLeftJoystickFunction(new Action<ENavigationDirectionType>(this.JumpPrevNavigation));
		}

		// Token: 0x06033512 RID: 210194 RVA: 0x00CD73E0 File Offset: 0x00CD55E0
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			NavigationGroup navigationGroup = focusListener.GetNavigationGroup();
			if (string.IsNullOrEmpty(navigationGroup.PrevGroupName))
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			NavigationGroup activeNavigationGroupByNameCheckAll = viewHandle.GetActiveNavigationGroupByNameCheckAll(navigationGroup.PrevGroupName);
			if (activeNavigationGroupByNameCheckAll == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			bool isActive = UiNavigationLogic.HasActiveListenerInGroup(activeNavigationGroupByNameCheckAll);
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, isActive, false);
		}
	}
}
