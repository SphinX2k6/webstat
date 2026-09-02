using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F3A RID: 12090
[NullableContext(1)]
[Nullable(0)]
public class PreventReduceStack : BuffEffect
{
	// Token: 0x06018BF1 RID: 101361 RVA: 0x006FE38B File Offset: 0x006FC58B
	public PreventReduceStack(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018BF2 RID: 101362 RVA: 0x006FE3A8 File Offset: 0x006FC5A8
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ != null && extraEffectParameters_.Length != 0)
		{
			string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
			this.InvolvedBuffIds = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.InvolvedBuffIds[i] = long.Parse(array[i]);
			}
		}
	}

	// Token: 0x06018BF3 RID: 101363 RVA: 0x006FE3FC File Offset: 0x006FC5FC
	public override void OnCreated()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		if (ownerBuffComponent == null)
		{
			return;
		}
		foreach (long buffId in this.InvolvedBuffIds)
		{
			ownerBuffComponent.AddBuffRoutineExpirationLock(buffId);
		}
	}

	// Token: 0x06018BF4 RID: 101364 RVA: 0x006FE434 File Offset: 0x006FC634
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018BF5 RID: 101365 RVA: 0x006FE438 File Offset: 0x006FC638
	public override void OnRemoved(bool bPremature)
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		if (ownerBuffComponent == null)
		{
			return;
		}
		foreach (long buffId in this.InvolvedBuffIds)
		{
			ownerBuffComponent.RemoveBuffRoutineExpirationLock(buffId);
		}
	}

	// Token: 0x06018BF6 RID: 101366 RVA: 0x006FE470 File Offset: 0x006FC670
	public override string GetDebugEffectString()
	{
		return "阻止buff" + string.Join<long>(",", this.InvolvedBuffIds) + "随时间自然衰减";
	}

	// Token: 0x0400C0B9 RID: 49337
	protected long[] InvolvedBuffIds = Array.Empty<long>();
}
