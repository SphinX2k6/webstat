using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CE7 RID: 19687
	[NullableContext(1)]
	[Nullable(0)]
	public class ClickBtnInScrollComponent : HotKeyComponent
	{
		// Token: 0x060333BC RID: 209852 RVA: 0x00CD4261 File Offset: 0x00CD2461
		public ClickBtnInScrollComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333BD RID: 209853 RVA: 0x00CD426A File Offset: 0x00CD246A
		protected override void OnPress(HotKeyMap config)
		{
			this.ClickButton(config.BindButtonTag);
		}

		// Token: 0x060333BE RID: 209854 RVA: 0x00CD4279 File Offset: 0x00CD2479
		private void ClickButton(string tag)
		{
			if (tag == "tag1")
			{
				ControllerBase<UiNavigationNewController>.Instance.HotKeyCloseView();
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.ClickButton(tag);
			Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
		}

		// Token: 0x060333BF RID: 209855 RVA: 0x00CD42A8 File Offset: 0x00CD24A8
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (string.IsNullOrEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener activeListenerByTag = viewHandle.GetActiveListenerByTag(bindButtonTag);
			if (activeListenerByTag == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (!activeListenerByTag.IsInNormalScrollDisplayByGridActor())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, activeListenerByTag.IsListenerActive(), false);
		}
	}
}
