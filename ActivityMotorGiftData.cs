using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001423 RID: 5155
public class ActivityMotorGiftData : ActivityBaseData
{
	// Token: 0x06008EF7 RID: 36599 RVA: 0x0025866A File Offset: 0x0025686A
	[NullableContext(1)]
	protected override void PhraseEx(ActivityData data)
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, base.Id);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06008EF8 RID: 36600 RVA: 0x00258698 File Offset: 0x00256898
	public int GetMotorPreviewId()
	{
		return 1007;
	}

	// Token: 0x06008EF9 RID: 36601 RVA: 0x0025869F File Offset: 0x0025689F
	public MotorGeneralPreview? GetMotorPreviewConfig()
	{
		return ConfigBase<MotorDiyConfig>.Instance.GetMotorGeneralPreviewConfig(1007);
	}

	// Token: 0x06008EFA RID: 36602 RVA: 0x002586B0 File Offset: 0x002568B0
	public void OpenMotorPreviewView()
	{
		if (this.GetMotorPreviewConfig() == null)
		{
			return;
		}
		ControllerBase<MotorcycleDiyController>.Instance.OpenMotorGeneralPreviewView(1007);
	}

	// Token: 0x06008EFB RID: 36603 RVA: 0x002586E0 File Offset: 0x002568E0
	public bool IsRewardObtained()
	{
		MotorGeneralPreview? motorPreviewConfig = this.GetMotorPreviewConfig();
		return motorPreviewConfig != null && motorPreviewConfig.Value.Frame > 0 && ModelBase<MotorcycleDiyModel>.Instance.HasFrame(motorPreviewConfig.Value.Frame);
	}

	// Token: 0x06008EFC RID: 36604 RVA: 0x0025872A File Offset: 0x0025692A
	protected override bool GetExDataFinishShowState()
	{
		return this.IsRewardObtained();
	}

	// Token: 0x06008EFD RID: 36605 RVA: 0x00258732 File Offset: 0x00256932
	public override bool GetExDataRedPointShowState()
	{
		return false;
	}

	// Token: 0x04004282 RID: 17026
	private const int MotorGiftMotorPreviewId = 1007;
}
