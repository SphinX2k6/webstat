using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CFF RID: 19711
	public class GamepadClickComponent : GamepadInteractComponentBase
	{
		// Token: 0x06033417 RID: 209943 RVA: 0x00CD4F32 File Offset: 0x00CD3132
		public GamepadClickComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033418 RID: 209944 RVA: 0x00CD4F3C File Offset: 0x00CD313C
		protected override void OnPress(HotKeyMap config)
		{
			UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = currentViewHandle.GetGuideUiListener();
			if (tsUiNavigationBehaviorListener == null)
			{
				tsUiNavigationBehaviorListener = currentViewHandle.GetHitComponentListener();
			}
			if (tsUiNavigationBehaviorListener != null)
			{
				TArray<string> tagArray = tsUiNavigationBehaviorListener.TagArray;
				if (tagArray != null && tagArray.Contains(config.BindButtonTag))
				{
					ControllerBase<UiNavigationNewController>.Instance.InteractClickByListener(tsUiNavigationBehaviorListener);
				}
			}
		}

		// Token: 0x06033419 RID: 209945 RVA: 0x00CD4F90 File Offset: 0x00CD3190
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (string.IsNullOrEmpty(bindButtonTag))
			{
				return;
			}
			if (!viewHandle.HasGamepadControlMouse())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (viewHandle.IsNavigationMousePositionDragging())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = viewHandle.GetGuideUiListener();
			if (tsUiNavigationBehaviorListener == null)
			{
				tsUiNavigationBehaviorListener = viewHandle.GetHitComponentListener();
			}
			if (tsUiNavigationBehaviorListener == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			TArray<string> tagArray = tsUiNavigationBehaviorListener.TagArray;
			bool isActive = tagArray != null && tagArray.Contains(bindButtonTag);
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, isActive, false);
		}
	}
}
