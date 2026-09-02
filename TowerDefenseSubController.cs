using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.TowerDefenseEvent;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x02000F91 RID: 3985
public class TowerDefenseSubController : KscSubControllerBase
{
	// Token: 0x06006599 RID: 26009 RVA: 0x00198A85 File Offset: 0x00196C85
	protected override void OnInit()
	{
		TowerDefensePlayerController.OnInit();
	}

	// Token: 0x0600659A RID: 26010 RVA: 0x00198A8D File Offset: 0x00196C8D
	protected override void OnClear()
	{
		TowerDefensePlayerController.OnClear();
	}

	// Token: 0x0600659B RID: 26011 RVA: 0x00198A95 File Offset: 0x00196C95
	protected override void OnTick(float delta)
	{
		ControllerBase<TowerDefenseEventController>.Instance.ControllerTick(delta);
	}

	// Token: 0x0600659C RID: 26012 RVA: 0x00198AA2 File Offset: 0x00196CA2
	protected override void CreateModel()
	{
		this.SubModel = new TowerDefenseSubModel();
	}

	// Token: 0x0600659D RID: 26013 RVA: 0x00198AAF File Offset: 0x00196CAF
	public override bool IsTargetMap(int instSubType)
	{
		return instSubType == 37;
	}

	// Token: 0x0600659E RID: 26014 RVA: 0x00198AB6 File Offset: 0x00196CB6
	protected override void OnInitMap()
	{
		ControllerBase<TowerDefenseEventController>.Instance.InitMap();
	}

	// Token: 0x0600659F RID: 26015 RVA: 0x00198AC2 File Offset: 0x00196CC2
	protected override void OnWorldDone()
	{
		TowerDefensePlayerController.OnStart();
		TowerDefenseInputController.OnStart();
		TrapDefensePsFeedbackManager.Initialize();
		TrapDefenseBattleGuideManager.Initialize();
		ControllerBase<TowerDefenseEventController>.Instance.OnWorldDone();
	}

	// Token: 0x060065A0 RID: 26016 RVA: 0x00198AE4 File Offset: 0x00196CE4
	protected override void OnWorldReset()
	{
		ControllerBase<TowerDefenseEventController>.Instance.OnWorldReset();
		TowerDefensePlayerController.OnStop();
		TowerDefenseInputController.OnStop();
		TrapDefensePsFeedbackManager.Clear();
		TrapDefenseBattleGuideManager.Clear();
	}

	// Token: 0x060065A1 RID: 26017 RVA: 0x00198B06 File Offset: 0x00196D06
	[NullableContext(1)]
	public override void OnEntityRemoved(KscRemoveContext context, Dictionary<long, SimpleCombatEntityDieContext> protoContexts)
	{
		ControllerBase<TowerDefenseEventController>.Instance.OnEntityRemoved(context, protoContexts);
	}

	// Token: 0x060065A2 RID: 26018 RVA: 0x00198B14 File Offset: 0x00196D14
	protected override void CreateEntityFilter()
	{
		this.RedirectFilter = ControllerBase<TowerDefenseEventController>.Instance.EntityRedirectFilter;
	}

	// Token: 0x060065A3 RID: 26019 RVA: 0x00198B26 File Offset: 0x00196D26
	protected override void AddKscPlayerEntity()
	{
	}
}
