using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Structures;

// Token: 0x02003288 RID: 12936
[NullableContext(1)]
[Nullable(0)]
public class FishingBoatInputComponent : GongduolaInputComponent
{
	// Token: 0x0601B13D RID: 110909 RVA: 0x0081D398 File Offset: 0x0081B598
	protected override void ExecuteSprint(SInputCommand command)
	{
	}

	// Token: 0x0601B13E RID: 110910 RVA: 0x0081D39A File Offset: 0x0081B59A
	protected override void ExecuteSkill(SInputCommand command)
	{
		this.BeginSkill(command.IntValue);
	}

	// Token: 0x0601B13F RID: 110911 RVA: 0x0081D3A8 File Offset: 0x0081B5A8
	private void BeginSkill(int skillId)
	{
		if (skillId == 210012)
		{
			ControllerBase<PhotographController>.Instance.PhotographFastScreenShot(ECameraCaptureType.NormalCamera);
			return;
		}
		base.Entity.GetComponent<BaseSkillComponent>().BeginSkill(skillId, new SkillParam
		{
			Reason = "FishingBoatInputComponent.ExecuteSkill"
		});
	}

	// Token: 0x0601B140 RID: 110912 RVA: 0x0081D3E0 File Offset: 0x0081B5E0
	public void ExecuteSkillWithConfirmBox(int skillId, EConfirmBoxConfigId configId, int itemId)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(configId);
		if (itemId > 0)
		{
			confirmBoxDataNew.ItemIdMap[itemId] = 1;
		}
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			this.BeginSkill(skillId);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0601B141 RID: 110913 RVA: 0x0081D43D File Offset: 0x0081B63D
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		FishingBoatInputComponent fishingBoatInputComponent = (FishingBoatInputComponent)componentTemplate;
		return true;
	}
}
