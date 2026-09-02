using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200336E RID: 13166
public class RedDotMotorcycleSceneButtonRedDot : RedDotBase
{
	// Token: 0x0601B765 RID: 112485 RVA: 0x00838644 File Offset: 0x00836844
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FunctionMotorDevelop);
	}

	// Token: 0x0601B766 RID: 112486 RVA: 0x0083864D File Offset: 0x0083684D
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiySceneItemUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B767 RID: 112487 RVA: 0x0083866B File Offset: 0x0083686B
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiySceneItemUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B768 RID: 112488 RVA: 0x00838689 File Offset: 0x00836889
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MotorcycleDiyModel>.Instance.RedDotHasAnyNewScene();
	}
}
