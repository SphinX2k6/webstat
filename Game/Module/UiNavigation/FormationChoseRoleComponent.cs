using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CF8 RID: 19704
	public class FormationChoseRoleComponent : HotKeyComponent
	{
		// Token: 0x06033403 RID: 209923 RVA: 0x00CD4BD4 File Offset: 0x00CD2DD4
		public FormationChoseRoleComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
			ControllerBase<FormationDragController>.Instance.AddCustomShieldHotKeyComponentSetData(this.HotKeyMapIndex);
		}

		// Token: 0x06033404 RID: 209924 RVA: 0x00CD4BED File Offset: 0x00CD2DED
		protected override void OnPress(HotKeyMap config)
		{
			if (ControllerBase<FormationDragController>.Instance.GamePadSelectModel)
			{
				return;
			}
			ControllerBase<FormationDragController>.Instance.OnGamePadPress();
		}

		// Token: 0x06033405 RID: 209925 RVA: 0x00CD4C06 File Offset: 0x00CD2E06
		protected override void OnRelease(HotKeyMap config)
		{
			if (ControllerBase<FormationDragController>.Instance.DragStartMoveFirstRelease)
			{
				ControllerBase<FormationDragController>.Instance.DragStartMoveFirstRelease = false;
				return;
			}
			if (ControllerBase<FormationDragController>.Instance.GamePadSelectModel)
			{
				ControllerBase<FormationDragController>.Instance.DragConfirm();
				return;
			}
			ControllerBase<FormationDragController>.Instance.OnGamePadRelease();
		}

		// Token: 0x06033406 RID: 209926 RVA: 0x00CD4C44 File Offset: 0x00CD2E44
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
			HotKeyViewDefine.ELogicMode logicMode = HotKeyViewDefine.ELogicMode.ListenerActive;
			TArray<string> tagArray = focusListener.TagArray;
			base.SetVisibleMode(logicMode, ((tagArray != null) ? tagArray.FindIndex(bindButtonTag) : -1) >= 0, false);
		}
	}
}
