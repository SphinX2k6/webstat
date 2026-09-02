using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D2C RID: 19756
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class NavigationGroupNextComponentBase : HotKeyComponent
	{
		// Token: 0x060334FA RID: 210170 RVA: 0x00CD7216 File Offset: 0x00CD5416
		protected NavigationGroupNextComponentBase(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334FB RID: 210171 RVA: 0x00CD721F File Offset: 0x00CD541F
		private void JumpNextNavigation(ENavigationDirectionType direction)
		{
			if (direction == this.GetDirection())
			{
				this.JumpToNextGroupListener();
			}
		}

		// Token: 0x060334FC RID: 210172 RVA: 0x00CD7230 File Offset: 0x00CD5430
		protected virtual void JumpToNextGroupListener()
		{
			HotKeyMap? hotKeyMap;
			string text = (base.GetHotKeyConfig() != null) ? hotKeyMap.GetValueOrDefault().BindButtonTag : null;
			if (text != null)
			{
				ControllerBase<UiNavigationNewController>.Instance.JumpNavigationGroupByTag(text);
			}
		}

		// Token: 0x060334FD RID: 210173
		protected abstract ENavigationDirectionType GetDirection();

		// Token: 0x060334FE RID: 210174 RVA: 0x00CD726F File Offset: 0x00CD546F
		protected override void OnRelease(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.JumpNavigationGroupByTag(config.BindButtonTag);
		}

		// Token: 0x060334FF RID: 210175 RVA: 0x00CD7283 File Offset: 0x00CD5483
		protected override void OnStartInputAxis(string axisName)
		{
			UiNavigationJoystickInput.RegisterLeftJoystickFunction(new Action<ENavigationDirectionType>(this.JumpNextNavigation));
		}

		// Token: 0x06033500 RID: 210176 RVA: 0x00CD7296 File Offset: 0x00CD5496
		protected override void OnFinishInputAxis(string axisName)
		{
			UiNavigationJoystickInput.UnRegisterLeftJoystickFunction(new Action<ENavigationDirectionType>(this.JumpNextNavigation));
		}

		// Token: 0x06033501 RID: 210177 RVA: 0x00CD72A9 File Offset: 0x00CD54A9
		protected override void OnClear()
		{
			UiNavigationJoystickInput.UnRegisterLeftJoystickFunction(new Action<ENavigationDirectionType>(this.JumpNextNavigation));
		}

		// Token: 0x06033502 RID: 210178 RVA: 0x00CD72BC File Offset: 0x00CD54BC
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			NavigationGroup navigationGroup = focusListener.GetNavigationGroup();
			string bindButtonTag = base.GetBindButtonTag();
			string text;
			if (!string.IsNullOrEmpty(bindButtonTag))
			{
				text = navigationGroup.GroupNameMap.GetValueOrDefault(bindButtonTag);
			}
			else
			{
				text = navigationGroup.NextGroupName;
			}
			if (string.IsNullOrEmpty(text))
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			NavigationGroup activeNavigationGroupByNameCheckAll = viewHandle.GetActiveNavigationGroupByNameCheckAll(text);
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
