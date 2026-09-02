using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033E9 RID: 13289
public class RedDotTutorialType : RedDotBase
{
	// Token: 0x0601B9AC RID: 113068 RVA: 0x0083D1FD File Offset: 0x0083B3FD
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FunctionTutorial);
	}

	// Token: 0x0601B9AD RID: 113069 RVA: 0x0083D206 File Offset: 0x0083B406
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<ETutorialType>(EEventName.RedDotNewTutorialType, new Action<ETutorialType>(this.OnRedDotNewTutorialType));
	}

	// Token: 0x0601B9AE RID: 113070 RVA: 0x0083D224 File Offset: 0x0083B424
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<ETutorialType>(EEventName.RedDotNewTutorialType, new Action<ETutorialType>(this.OnRedDotNewTutorialType));
	}

	// Token: 0x0601B9AF RID: 113071 RVA: 0x0083D242 File Offset: 0x0083B442
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<TutorialModel>.Instance.RedDotCheckIsNewTutorialType((ETutorialType)uId);
	}

	// Token: 0x0601B9B0 RID: 113072 RVA: 0x0083D24F File Offset: 0x0083B44F
	private void OnRedDotNewTutorialType(ETutorialType tutorialType)
	{
		base.EventCheckWithUid((int)tutorialType);
	}
}
