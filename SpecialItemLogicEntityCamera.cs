using System;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Ui;

// Token: 0x02002080 RID: 8320
public class SpecialItemLogicEntityCamera : SpecialItemLogicBase
{
	// Token: 0x0600FD81 RID: 64897 RVA: 0x0045887F File Offset: 0x00456A7F
	public SpecialItemLogicEntityCamera(int configId) : base(configId)
	{
	}

	// Token: 0x0600FD82 RID: 64898 RVA: 0x00458888 File Offset: 0x00456A88
	public override bool CheckUseCondition()
	{
		return true;
	}

	// Token: 0x0600FD83 RID: 64899 RVA: 0x0045888B File Offset: 0x00456A8B
	public override void OnUse()
	{
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhotographView) && ControllerBase<PhotographController>.Instance.TryOpenPhotograph(ECameraCaptureType.EntityCamera))
		{
			TsInteractionUtils.RegisterOpenViewName(EUiViewName.PhotographView);
		}
	}
}
