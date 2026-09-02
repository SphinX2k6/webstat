using System;
using CSharpScript.Game.Module.BattleUi.Views;
using UnrealEngine;

// Token: 0x02002671 RID: 9841
public class QuestViewChildStep : StepWithStatusItem
{
	// Token: 0x06013651 RID: 79441 RVA: 0x0056854A File Offset: 0x0056674A
	public QuestViewChildStep(EMissionItemView viewId, int stepId) : base(viewId, stepId)
	{
	}

	// Token: 0x06013652 RID: 79442 RVA: 0x00568554 File Offset: 0x00566754
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUISprite)));
	}

	// Token: 0x06013653 RID: 79443 RVA: 0x00568577 File Offset: 0x00566777
	protected override void OnStart()
	{
		base.OnStart();
	}

	// Token: 0x06013654 RID: 79444 RVA: 0x0056857F File Offset: 0x0056677F
	protected override void UpdateStepInfo()
	{
		base.UpdateStepInfo();
		UUISprite sprite = base.GetSprite(5);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(!this.IsDescribeTextVisible || !this.StatusNodeVisible);
	}

	// Token: 0x06013655 RID: 79445 RVA: 0x005685AC File Offset: 0x005667AC
	protected override bool CheckCanShowStatusRoot()
	{
		return true;
	}

	// Token: 0x02008A0C RID: 35340
	private class EChildComponent
	{
		// Token: 0x0402E901 RID: 190721
		public const int StepProcess = 5;
	}
}
