using System;
using CSharpScript.Game.Ui;

// Token: 0x02000FB3 RID: 4019
public static class UiPopFrameViewRegisterCenter
{
	// Token: 0x060066FE RID: 26366 RVA: 0x0019F7F0 File Offset: 0x0019D9F0
	public static void Init()
	{
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(1, new UiPopFrameViewInfo("UiView_PopupB", () => new PopupTypeBigItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(4, new UiPopFrameViewInfo("UiView_PopupL", () => new PopupTypeLargeItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(3, new UiPopFrameViewInfo("UiView_PopupM", () => new PopupTypeMiddleItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(2, new UiPopFrameViewInfo("UiView_PopupS", () => new PopupTypeSmallItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(5, new UiPopFrameViewInfo("UiView_PopupL1", () => new NpcSystemViewItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(6, new UiPopFrameViewInfo("UiView_PopupL2", () => new InteractSystemViewItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(7, new UiPopFrameViewInfo("UiView_PopupFullScreen", () => new FullScreenViewItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(8, new UiPopFrameViewInfo("UiView_SoundRemnantArenaPopupB", () => new PopupTypeBigItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(9, new UiPopFrameViewInfo("UiView_SoundRemnantArenaPopupM", () => new PopupTypeMiddleItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(10, new UiPopFrameViewInfo("UiView_SoundRemnantArenaPopupS", () => new PopupTypeSmallItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(11, new UiPopFrameViewInfo("UiView_PasturePopupHelp", () => new PopupTypeMiddleItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(12, new UiPopFrameViewInfo("UiView_PopupR", () => new PopupTypeRightItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(13, new UiPopFrameViewInfo("UiView_CatapultStoryPopupB", () => new PopupTypeBigItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(14, new UiPopFrameViewInfo("UiView_CatapultStoryPopupM", () => new PopupTypeMiddleItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(15, new UiPopFrameViewInfo("UiView_CatapultStoryPopupS", () => new PopupTypeSmallItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(16, new UiPopFrameViewInfo("UiView_PopupB", () => new PopupTypeBigItem()));
		Singleton<UiPopFrameViewStorage>.Instance.RegisterUiBehaviourPop(17, new UiPopFrameViewInfo("UiView_PopupS", () => new PopupTypeSmallItem()));
	}
}
