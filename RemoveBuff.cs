using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02002F56 RID: 12118
[NullableContext(1)]
[Nullable(0)]
public class RemoveBuff : BuffEffect
{
	// Token: 0x06018C83 RID: 101507 RVA: 0x007015ED File Offset: 0x006FF7ED
	public RemoveBuff(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C84 RID: 101508 RVA: 0x007015FC File Offset: 0x006FF7FC
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		string text = (extraEffectParameters_ != null && extraEffectParameters_.Length != 0) ? extraEffectParameters_[0] : "0";
		if (string.IsNullOrEmpty(text))
		{
			text = "0";
		}
		string[] array = text.Split('#', StringSplitOptions.None);
		this.TriggerTypes = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			this.TriggerTypes[i] = int.Parse(array[i]);
		}
	}

	// Token: 0x06018C85 RID: 101509 RVA: 0x00701668 File Offset: 0x006FF868
	public override void OnCreated()
	{
		EntityHandle instigatorEntity = base.InstigatorEntity;
		if (instigatorEntity == null || !instigatorEntity.Valid)
		{
			return;
		}
		if (this.TriggerTypes == null)
		{
			return;
		}
		foreach (int num in this.TriggerTypes)
		{
			if (num != 0)
			{
				if (num == 1)
				{
					Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(base.InstigatorEntity, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnInstigatorRemoved));
				}
			}
			else
			{
				Singleton<EventSystem>.Instance.AddWithTarget(base.InstigatorEntity.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnInstigatorDead));
			}
		}
	}

	// Token: 0x06018C86 RID: 101510 RVA: 0x00701704 File Offset: 0x006FF904
	public override void OnRemoved(bool bPremature)
	{
		EntityHandle instigatorEntity = base.InstigatorEntity;
		if (instigatorEntity == null || !instigatorEntity.Valid)
		{
			return;
		}
		if (this.TriggerTypes == null)
		{
			return;
		}
		foreach (int num in this.TriggerTypes)
		{
			if (num != 0)
			{
				if (num == 1)
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(base.InstigatorEntity, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnInstigatorRemoved));
				}
			}
			else
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.InstigatorEntity.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnInstigatorDead));
			}
		}
	}

	// Token: 0x06018C87 RID: 101511 RVA: 0x0070179F File Offset: 0x006FF99F
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C88 RID: 101512 RVA: 0x007017A4 File Offset: 0x006FF9A4
	private void OnInstigatorDead()
	{
		if (this.OwnerBuffComponent.HasBuffAuthority())
		{
			this.OwnerBuffComponent.RemoveBuffByHandle(this.ActiveHandleId, -1, "buff施加者死亡导致移除", null, null, null);
		}
	}

	// Token: 0x06018C89 RID: 101513 RVA: 0x007017F4 File Offset: 0x006FF9F4
	private void OnInstigatorRemoved(ERemoveEntityType removeType, EntityHandle handle)
	{
		if (handle == base.InstigatorEntity && this.OwnerBuffComponent.HasBuffAuthority())
		{
			this.OwnerBuffComponent.RemoveBuffByHandle(this.ActiveHandleId, -1, "buff施加者被移除导致移除", null, null, null);
		}
	}

	// Token: 0x0400C121 RID: 49441
	[Nullable(2)]
	private int[] TriggerTypes;
}
