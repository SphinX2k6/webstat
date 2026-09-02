using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002F3D RID: 12093
[NullableContext(1)]
[Nullable(0)]
public class ExtraEffectModifyBuffMaxStack : BuffEffect
{
	// Token: 0x06018C04 RID: 101380 RVA: 0x006FEC13 File Offset: 0x006FCE13
	public ExtraEffectModifyBuffMaxStack(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C05 RID: 101381 RVA: 0x006FEC38 File Offset: 0x006FCE38
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ != null)
		{
			List<long> list = new List<long>();
			List<int> list2 = new List<int>();
			for (int i = 0; i < extraEffectParameters_.Length; i++)
			{
				string[] array = extraEffectParameters_[i].Split('#', StringSplitOptions.None);
				if (array.Length >= 2)
				{
					list.Add(long.Parse(array[0]));
					list2.Add(int.Parse(array[1]));
				}
			}
			this.InvolvedBuffIds = list.ToArray();
			this.StackValues = list2.ToArray();
		}
	}

	// Token: 0x06018C06 RID: 101382 RVA: 0x006FECB4 File Offset: 0x006FCEB4
	public override void OnCreated()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		if (ownerBuffComponent != null)
		{
			for (int i = 0; i < this.InvolvedBuffIds.Length; i++)
			{
				ownerBuffComponent.AddBuffStackModifier(this.InvolvedBuffIds[i], this.ActiveHandleId, this.StackValues[i], EBuffStackModifierType.Incremental);
			}
		}
	}

	// Token: 0x06018C07 RID: 101383 RVA: 0x006FECFB File Offset: 0x006FCEFB
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C08 RID: 101384 RVA: 0x006FED00 File Offset: 0x006FCF00
	public override void OnRemoved(bool bPremature)
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		if (ownerBuffComponent != null && this.InvolvedBuffIds.Length != 0)
		{
			foreach (long targetBuffId in this.InvolvedBuffIds)
			{
				ownerBuffComponent.RemoveBuffStackModifier(targetBuffId, this.ActiveHandleId);
			}
		}
	}

	// Token: 0x06018C09 RID: 101385 RVA: 0x006FED46 File Offset: 0x006FCF46
	public override string GetDebugEffectString()
	{
		return "修改buff" + string.Join<long>(",", this.InvolvedBuffIds) + " 修改层数" + string.Join<int>(",", this.StackValues);
	}

	// Token: 0x0400C0C1 RID: 49345
	protected long[] InvolvedBuffIds = Array.Empty<long>();

	// Token: 0x0400C0C2 RID: 49346
	protected int[] StackValues = Array.Empty<int>();
}
