using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F4B RID: 12107
[NullableContext(1)]
[Nullable(0)]
public class SyncMaxStackFromAnotherBuffEffect : BuffEffect
{
	// Token: 0x06018C61 RID: 101473 RVA: 0x00700E84 File Offset: 0x006FF084
	public SyncMaxStackFromAnotherBuffEffect(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C62 RID: 101474 RVA: 0x00700E94 File Offset: 0x006FF094
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ != null && extraEffectParameters_.Length != 0)
		{
			this.SourceBuffId = long.Parse(extraEffectParameters_[0]);
		}
	}

	// Token: 0x06018C63 RID: 101475 RVA: 0x00700EBD File Offset: 0x006FF0BD
	public override void OnCreated()
	{
		if (base.OwnerEntity != null)
		{
			AbilityEvent.Instance.Add(base.OwnerEntity, EAbilityEventName.OnBuffMaxStackModifier, this.SourceBuffId, new Action<long>(this.OnBuffMaxStackModifier));
		}
		this.SyncMaxStack();
	}

	// Token: 0x06018C64 RID: 101476 RVA: 0x00700EF0 File Offset: 0x006FF0F0
	public override void OnRemoved(bool bPremature)
	{
		if (base.OwnerEntity != null)
		{
			AbilityEvent.Instance.Remove(base.OwnerEntity, EAbilityEventName.OnBuffMaxStackModifier, this.SourceBuffId, new Action<long>(this.OnBuffMaxStackModifier));
		}
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		if (ownerBuffComponent == null)
		{
			return;
		}
		ownerBuffComponent.RemoveBuffStackModifier(this.BuffId, this.ActiveHandleId);
	}

	// Token: 0x06018C65 RID: 101477 RVA: 0x00700F44 File Offset: 0x006FF144
	protected void OnBuffMaxStackModifier(long buffId)
	{
		this.SyncMaxStack();
	}

	// Token: 0x06018C66 RID: 101478 RVA: 0x00700F4C File Offset: 0x006FF14C
	private void SyncMaxStack()
	{
		if (this.OwnerBuffComponent == null)
		{
			return;
		}
		int? num = this.OwnerBuffComponent.CalculateBuffStackMax(this.SourceBuffId);
		if (num == null)
		{
			return;
		}
		this.OwnerBuffComponent.AddBuffStackModifier(this.BuffId, this.ActiveHandleId, num.Value, EBuffStackModifierType.Override);
	}

	// Token: 0x06018C67 RID: 101479 RVA: 0x00700F9D File Offset: 0x006FF19D
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C68 RID: 101480 RVA: 0x00700FA0 File Offset: 0x006FF1A0
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
		defaultInterpolatedStringHandler.AppendLiteral("同步buff[");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.SourceBuffId);
		defaultInterpolatedStringHandler.AppendLiteral("]的最大层数");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C0EA RID: 49386
	private long SourceBuffId;
}
