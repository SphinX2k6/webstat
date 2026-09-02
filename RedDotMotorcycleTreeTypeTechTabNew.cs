using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003373 RID: 13171
public class RedDotMotorcycleTreeTypeTechTabNew : RedDotBase
{
	// Token: 0x0601B780 RID: 112512 RVA: 0x008389E7 File Offset: 0x00836BE7
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B781 RID: 112513 RVA: 0x008389EC File Offset: 0x00836BEC
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.MotorDevelopTechTreeUpdate, new Action<bool>(this.OnMotorDevelopTechTreeUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopTreeTypeRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B782 RID: 112514 RVA: 0x00838A50 File Offset: 0x00836C50
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.MotorDevelopTechTreeUpdate, new Action<bool>(this.OnMotorDevelopTechTreeUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopTreeTypeRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B783 RID: 112515 RVA: 0x00838AB1 File Offset: 0x00836CB1
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MotorcycleDevelopModel>.Instance.RedDotHasNewTechTree(uId);
	}

	// Token: 0x0601B784 RID: 112516 RVA: 0x00838ABE File Offset: 0x00836CBE
	private void OnMotorDevelopTechTreeUpdate(bool isUpdateNode)
	{
		base.EventCheck();
	}
}
