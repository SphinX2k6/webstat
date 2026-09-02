using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CF7 RID: 19703
	public class FormationCancelChoseRoleComponent : HotKeyComponent
	{
		// Token: 0x06033400 RID: 209920 RVA: 0x00CD4B1E File Offset: 0x00CD2D1E
		public FormationCancelChoseRoleComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
			ControllerBase<FormationDragController>.Instance.AddCustomShieldHotKeyComponentSetData(this.HotKeyMapIndex);
		}

		// Token: 0x06033401 RID: 209921 RVA: 0x00CD4B37 File Offset: 0x00CD2D37
		protected override void OnPress(HotKeyMap config)
		{
			if (ControllerBase<FormationDragController>.Instance.GamePadSelectModel)
			{
				ControllerBase<FormationDragController>.Instance.CancelDrag();
			}
		}

		// Token: 0x06033402 RID: 209922 RVA: 0x00CD4B50 File Offset: 0x00CD2D50
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (bindButtonTag == null || StringUtils.IsEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (!base.IsLinkListener(focusListener.GetOwner()))
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (!ControllerBase<FormationDragController>.Instance.GetDragItemUiActive())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			HotKeyViewDefine.ELogicMode logicMode = HotKeyViewDefine.ELogicMode.ListenerActive;
			TArray<string> tagArray = focusListener.TagArray;
			base.SetVisibleMode(logicMode, ((tagArray != null) ? tagArray.FindIndex(bindButtonTag) : -1) >= 0, false);
		}
	}
}
