using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200336B RID: 13163
public class RedDotMotorcycleDevelop : RedDotBase
{
	// Token: 0x0601B755 RID: 112469 RVA: 0x008382EE File Offset: 0x008364EE
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattleViewMenu);
	}

	// Token: 0x0601B756 RID: 112470 RVA: 0x008382F8 File Offset: 0x008364F8
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.MotorDevelopTechTreeUpdate, new Action<bool>(this.OnMotorDevelopTechTreeUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopTaskUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopTreeTypeRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiySceneItemUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B757 RID: 112471 RVA: 0x008383CC File Offset: 0x008365CC
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.MotorDevelopTechTreeUpdate, new Action<bool>(this.OnMotorDevelopTechTreeUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopTaskUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopTreeTypeRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiySceneItemUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B758 RID: 112472 RVA: 0x008384A0 File Offset: 0x008366A0
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.MotorDevelop) && (ModelBase<MotorcycleDevelopModel>.Instance.RedDotHasLevelUpReward() || ModelBase<MotorcycleDevelopModel>.Instance.RedDotHasAnyNewTechTree() || ModelBase<MotorcycleDevelopModel>.Instance.RedDotHasUpgradableTechNode(null) || ModelBase<MotorcycleDevelopModel>.Instance.RedDotCanGetAnyTaskReward() || ModelBase<MotorcycleDiyModel>.Instance.RedDotForDiyTab());
	}

	// Token: 0x0601B759 RID: 112473 RVA: 0x00838505 File Offset: 0x00836705
	private void OnMotorDevelopTechTreeUpdate(bool isUpdateNode)
	{
		base.EventCheck();
	}
}
