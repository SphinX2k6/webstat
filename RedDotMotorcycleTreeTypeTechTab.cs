using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003372 RID: 13170
public class RedDotMotorcycleTreeTypeTechTab : RedDotBase
{
	// Token: 0x0601B77A RID: 112506 RVA: 0x008388FA File Offset: 0x00836AFA
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B77B RID: 112507 RVA: 0x00838900 File Offset: 0x00836B00
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.MotorDevelopTechTreeUpdate, new Action<bool>(this.OnMotorDevelopTechTreeUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopTaskUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B77C RID: 112508 RVA: 0x00838964 File Offset: 0x00836B64
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.MotorDevelopTechTreeUpdate, new Action<bool>(this.OnMotorDevelopTechTreeUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopTaskUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B77D RID: 112509 RVA: 0x008389C5 File Offset: 0x00836BC5
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MotorcycleDevelopModel>.Instance.RedDotHasUpgradableTechNode(new int?(uId));
	}

	// Token: 0x0601B77E RID: 112510 RVA: 0x008389D7 File Offset: 0x00836BD7
	private void OnMotorDevelopTechTreeUpdate(bool isUpdateNode)
	{
		base.EventCheck();
	}
}
