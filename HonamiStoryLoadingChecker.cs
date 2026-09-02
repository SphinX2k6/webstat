using System;
using CSharpScript.Game.Ui;

// Token: 0x020020CA RID: 8394
public class HonamiStoryLoadingChecker : ISpecialCustomLoadingTypeChecker
{
	// Token: 0x060100A3 RID: 65699 RVA: 0x00467AFD File Offset: 0x00465CFD
	public bool CanHandle(int instanceId)
	{
		return HonamiStoryUtil.CheckEnterOrExitHonamiStoryDungeon(instanceId);
	}

	// Token: 0x060100A4 RID: 65700 RVA: 0x00467B05 File Offset: 0x00465D05
	public EUiViewName? GetLoadingViewName(int instanceId)
	{
		return ModelBase<HonamiStoryModel>.Instance.GetCurLoadViewName();
	}
}
