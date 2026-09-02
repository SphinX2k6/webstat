using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003370 RID: 13168
public class RedDotMotorcycleTechTreeTab : RedDotBase
{
	// Token: 0x0601B76F RID: 112495 RVA: 0x00838728 File Offset: 0x00836928
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B770 RID: 112496 RVA: 0x0083872C File Offset: 0x0083692C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.MotorDevelopTechTreeUpdate, new Action<bool>(this.OnMotorDevelopTechTreeUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopTaskUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopTreeTypeRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B771 RID: 112497 RVA: 0x008387AC File Offset: 0x008369AC
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.MotorDevelopTechTreeUpdate, new Action<bool>(this.OnMotorDevelopTechTreeUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopTaskUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopTreeTypeRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B772 RID: 112498 RVA: 0x0083882C File Offset: 0x00836A2C
	protected override bool OnCheck(int uId = 0)
	{
		bool flag = ModelBase<MotorcycleDevelopModel>.Instance.RedDotHasAnyNewTechTree();
		bool flag2 = ModelBase<MotorcycleDevelopModel>.Instance.RedDotHasUpgradableTechNode(null);
		return flag || flag2;
	}

	// Token: 0x0601B773 RID: 112499 RVA: 0x00838859 File Offset: 0x00836A59
	private void OnMotorDevelopTechTreeUpdate(bool isUpdateNode)
	{
		base.EventCheck();
	}
}
