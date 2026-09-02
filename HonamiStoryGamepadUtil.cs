using System;
using CSharpScript.Game.Ui;

// Token: 0x02001EEE RID: 7918
public static class HonamiStoryGamepadUtil
{
	// Token: 0x0600EAB3 RID: 60083 RVA: 0x003FA5A0 File Offset: 0x003F87A0
	public static void HideAllTips()
	{
		HonamiStoryBackpackView honamiStoryBackpackView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryBackpackView) as HonamiStoryBackpackView;
		if (honamiStoryBackpackView != null)
		{
			honamiStoryBackpackView.HideAllTips();
		}
		HonamiStoryPickUpBackpackView honamiStoryPickUpBackpackView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryPickUpBackpackView) as HonamiStoryPickUpBackpackView;
		if (honamiStoryPickUpBackpackView != null)
		{
			honamiStoryPickUpBackpackView.HideAllTips();
		}
	}

	// Token: 0x0600EAB4 RID: 60084 RVA: 0x003FA5EC File Offset: 0x003F87EC
	public static void EnterMask()
	{
		HonamiStoryBackpackView honamiStoryBackpackView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryBackpackView) as HonamiStoryBackpackView;
		if (honamiStoryBackpackView != null)
		{
			honamiStoryBackpackView.OnEnterGamepadMask();
		}
		HonamiStoryPickUpBackpackView honamiStoryPickUpBackpackView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryPickUpBackpackView) as HonamiStoryPickUpBackpackView;
		if (honamiStoryPickUpBackpackView != null)
		{
			honamiStoryPickUpBackpackView.OnEnterGamepadMask();
		}
	}

	// Token: 0x0600EAB5 RID: 60085 RVA: 0x003FA638 File Offset: 0x003F8838
	public static void ExitMask()
	{
		HonamiStoryBackpackView honamiStoryBackpackView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryBackpackView) as HonamiStoryBackpackView;
		if (honamiStoryBackpackView != null)
		{
			honamiStoryBackpackView.OnExitGamepadMask();
		}
		HonamiStoryPickUpBackpackView honamiStoryPickUpBackpackView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryPickUpBackpackView) as HonamiStoryPickUpBackpackView;
		if (honamiStoryPickUpBackpackView != null)
		{
			honamiStoryPickUpBackpackView.OnExitGamepadMask();
		}
	}
}
