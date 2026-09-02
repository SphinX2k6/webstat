using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F47 RID: 12103
[NullableContext(1)]
[Nullable(0)]
public class DynamicModifyBuffStackEffect : BuffEffect
{
	// Token: 0x06018C44 RID: 101444 RVA: 0x007003D8 File Offset: 0x006FE5D8
	public DynamicModifyBuffStackEffect(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C45 RID: 101445 RVA: 0x007003F4 File Offset: 0x006FE5F4
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length == 0)
		{
			this.BuffIds = Array.Empty<long>();
			return;
		}
		string[] array = extraEffectParameters_[0].Split('|', StringSplitOptions.None);
		this.BuffIds = new long[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split('#', StringSplitOptions.None);
			this.BuffIds[i] = ((array2.Length != 0) ? long.Parse(array2[0]) : 0L);
		}
	}

	// Token: 0x06018C46 RID: 101446 RVA: 0x00700467 File Offset: 0x006FE667
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C47 RID: 101447 RVA: 0x0070046A File Offset: 0x006FE66A
	public override void OnCreated()
	{
	}

	// Token: 0x06018C48 RID: 101448 RVA: 0x0070046C File Offset: 0x006FE66C
	public override void OnRemoved(bool bPremature)
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		if (ownerBuffComponent != null)
		{
			foreach (long targetBuffId in this.BuffIds)
			{
				ownerBuffComponent.RemoveBuffStackModifier(targetBuffId, this.ActiveHandleId);
			}
		}
	}

	// Token: 0x0400C0E6 RID: 49382
	public long[] BuffIds = Array.Empty<long>();
}
