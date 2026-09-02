using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020031BE RID: 12734
[NullableContext(2)]
[Nullable(0)]
public class InterestEvent : IStaticVariableResetter
{
	// Token: 0x0601A672 RID: 108146 RVA: 0x007C8FF7 File Offset: 0x007C71F7
	static InterestEvent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(InterestEvent.CreateStaticDefaultValue), new Action(InterestEvent.ResetStaticDefaultValue));
	}

	// Token: 0x0601A673 RID: 108147 RVA: 0x007C9018 File Offset: 0x007C7218
	[NullableContext(1)]
	public InterestEvent(Entity ownerEntity)
	{
		this.Id = ++InterestEvent.IdGenerator;
		this.OwnerEntity = ownerEntity;
		CommonNpcPerformComponent component = this.OwnerEntity.GetComponent<CommonNpcPerformComponent>();
		this.OwnerController = component.InterestEventController;
	}

	// Token: 0x0601A674 RID: 108148 RVA: 0x007C9068 File Offset: 0x007C7268
	public int GetPriority()
	{
		return this.Action.GetPriority(this.OwnerEntity, this.Target);
	}

	// Token: 0x0601A675 RID: 108149 RVA: 0x007C9084 File Offset: 0x007C7284
	public bool CheckCondition()
	{
		using (List<InterestConditionBase>.Enumerator enumerator = this.Conditions.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.CheckCondition(this.OwnerEntity, this.Target))
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0601A676 RID: 108150 RVA: 0x007C90EC File Offset: 0x007C72EC
	public void TryEnterRange()
	{
		if (this.IsEntered)
		{
			return;
		}
		this.IsEntered = true;
		this.OwnerController.RegisterActiveEvent(this);
		InterestActionBase action = this.Action;
		if (action == null)
		{
			return;
		}
		action.OnEnter(this.OwnerEntity, this.Target);
	}

	// Token: 0x0601A677 RID: 108151 RVA: 0x007C9126 File Offset: 0x007C7326
	public void TryLeaveRange()
	{
		if (!this.IsEntered)
		{
			return;
		}
		InterestActionBase action = this.Action;
		if (action != null)
		{
			action.OnLeave(this.OwnerEntity, this.Target);
		}
		this.OwnerController.UnRegisterActiveEvent(this);
		this.IsEntered = false;
	}

	// Token: 0x0601A678 RID: 108152 RVA: 0x007C9161 File Offset: 0x007C7361
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x0601A679 RID: 108153 RVA: 0x007C9163 File Offset: 0x007C7363
	public static void ResetStaticDefaultValue()
	{
		InterestEvent.IdGenerator = 0;
	}

	// Token: 0x0400D50C RID: 54540
	public Entity OwnerEntity;

	// Token: 0x0400D50D RID: 54541
	public NpcInterestEventController OwnerController;

	// Token: 0x0400D50E RID: 54542
	public int Id;

	// Token: 0x0400D50F RID: 54543
	public float Radius;

	// Token: 0x0400D510 RID: 54544
	public InterestItemBase Target;

	// Token: 0x0400D511 RID: 54545
	[Nullable(1)]
	public List<InterestConditionBase> Conditions = new List<InterestConditionBase>();

	// Token: 0x0400D512 RID: 54546
	public InterestActionBase Action;

	// Token: 0x0400D513 RID: 54547
	public bool IsEntered;

	// Token: 0x0400D514 RID: 54548
	private static int IdGenerator;
}
