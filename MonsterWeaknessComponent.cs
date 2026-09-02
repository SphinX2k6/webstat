using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.Pawn.Controllers;

// Token: 0x0200317F RID: 12671
[NullableContext(1)]
[Nullable(0)]
public class MonsterWeaknessComponent : EntityComponent
{
	// Token: 0x170023B5 RID: 9141
	// (get) Token: 0x0601A423 RID: 107555 RVA: 0x007B9747 File Offset: 0x007B7947
	public string TargetSocket
	{
		get
		{
			return this.TargetSocketInternal;
		}
	}

	// Token: 0x0601A424 RID: 107556 RVA: 0x007B974F File Offset: 0x007B794F
	protected override bool OnStart()
	{
		PawnInteractNewComponent component = base.Entity.GetComponent<PawnInteractNewComponent>();
		this.InteractController = ((component != null) ? component.GetInteractController() : null);
		return true;
	}

	// Token: 0x0601A425 RID: 107557 RVA: 0x007B976F File Offset: 0x007B796F
	protected override bool OnEnd()
	{
		return true;
	}

	// Token: 0x0601A426 RID: 107558 RVA: 0x007B9774 File Offset: 0x007B7974
	public void ShowWeaknessButton(string targetSocket)
	{
		if (this.InteractHandle != 0)
		{
			this.HideWeaknessButton();
		}
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
		Entity entity = base.Entity;
		string message = "激活破弱按钮";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("socket", targetSocket);
		instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.TargetSocketInternal = targetSocket;
		PawnInteractController interactController = this.InteractController;
		this.InteractHandle = ((interactController != null) ? interactController.AddClientInteractOption(new BreakWeakness(), null, new EDoInteract?(EDoInteract.Direct), new float?(float.MaxValue), null, new ECustomOptionType?(ECustomOptionType.BreakWeakness), null, null) : 0);
	}

	// Token: 0x0601A427 RID: 107559 RVA: 0x007B9800 File Offset: 0x007B7A00
	public void UpdateTargetSocket(string targetSocket)
	{
		if (this.InteractHandle != 0 && this.TargetSocketInternal != targetSocket)
		{
			this.TargetSocketInternal = targetSocket;
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			Entity entity = base.Entity;
			string message = "更新破弱按钮Socket";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("socket", targetSocket);
			instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x0601A428 RID: 107560 RVA: 0x007B9854 File Offset: 0x007B7A54
	public void HideWeaknessButton()
	{
		if (this.InteractHandle != 0)
		{
			Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Skill, base.Entity, "移除破弱按钮", default(ReadOnlySpan<ValueTuple<string, object>>));
			PawnInteractController interactController = this.InteractController;
			if (interactController != null)
			{
				interactController.RemoveClientInteractOption(this.InteractHandle);
			}
			this.InteractHandle = 0;
			this.TargetSocketInternal = "";
		}
	}

	// Token: 0x0601A429 RID: 107561 RVA: 0x007B98B4 File Offset: 0x007B7AB4
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		MonsterWeaknessComponent monsterWeaknessComponent = (MonsterWeaknessComponent)componentTemplate;
		if (base.CanResetComponentProperty("InteractController"))
		{
			if (monsterWeaknessComponent.InteractController == null)
			{
				this.InteractController = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnInteractController>(this.InteractController), "InteractController"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InteractHandle"))
		{
			this.InteractHandle = monsterWeaknessComponent.InteractHandle;
		}
		if (base.CanResetComponentProperty("TargetSocketInternal"))
		{
			this.TargetSocketInternal = monsterWeaknessComponent.TargetSocketInternal;
		}
		return true;
	}

	// Token: 0x0400D373 RID: 54131
	[Nullable(2)]
	private PawnInteractController InteractController;

	// Token: 0x0400D374 RID: 54132
	private int InteractHandle;

	// Token: 0x0400D375 RID: 54133
	private string TargetSocketInternal = "";
}
