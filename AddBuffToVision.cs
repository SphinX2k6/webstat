using System;
using System.Runtime.CompilerServices;
using Aki.Protocol.Summon;

// Token: 0x02002F38 RID: 12088
[NullableContext(1)]
[Nullable(0)]
public class AddBuffToVision : BuffEffect
{
	// Token: 0x06018BE5 RID: 101349 RVA: 0x006FDCE8 File Offset: 0x006FBEE8
	public AddBuffToVision(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018BE6 RID: 101350 RVA: 0x006FDD04 File Offset: 0x006FBF04
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ != null)
		{
			this.SummonType = ((extraEffectParameters_.Length != 0) ? int.Parse(extraEffectParameters_[0]) : 0);
			this.SummonIndex = ((extraEffectParameters_.Length > 1) ? int.Parse(extraEffectParameters_[1]) : 0);
			string text = (extraEffectParameters_.Length > 2) ? extraEffectParameters_[2] : string.Empty;
			if (!string.IsNullOrEmpty(text))
			{
				string[] array = text.Split('#', StringSplitOptions.None);
				this.BuffIds = new long[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					this.BuffIds[i] = long.Parse(array[i]);
				}
				return;
			}
			this.BuffIds = Array.Empty<long>();
		}
	}

	// Token: 0x06018BE7 RID: 101351 RVA: 0x006FDDA8 File Offset: 0x006FBFA8
	public override void OnCreated()
	{
		EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(base.OwnerEntity, (ESummonType)this.SummonType, this.SummonIndex);
		object obj = (summonedEntity != null) ? summonedEntity.Entity : null;
		IActiveBuff buff = base.Buff;
		long? preMessageId = (buff != null) ? buff.MessageId : null;
		if (preMessageId == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.BuffItem, ELogAuthor.ZFJ, "没有父Buff的上下文信息", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		object obj2 = obj;
		CharacterBuffComponent characterBuffComponent = (obj2 != null) ? obj2.GetComponent<CharacterBuffComponent>() : null;
		if (characterBuffComponent != null)
		{
			foreach (long num in this.BuffIds)
			{
				BaseBuffComponent baseBuffComponent = characterBuffComponent;
				long buffId = num;
				AddBuffParam addBuffParam = new AddBuffParam();
				CharacterBuffComponent instigatorBuffComponent = base.InstigatorBuffComponent;
				addBuffParam.InstigatorId = ((instigatorBuffComponent != null) ? instigatorBuffComponent.CreatureDataId : 0L);
				addBuffParam.PreMessageId = preMessageId;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
				defaultInterpolatedStringHandler.AppendLiteral("buff");
				defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
				defaultInterpolatedStringHandler.AppendLiteral("向召唤物共享buff");
				addBuffParam.Reason = defaultInterpolatedStringHandler.ToStringAndClear();
				baseBuffComponent.AddBuff(buffId, addBuffParam);
			}
		}
	}

	// Token: 0x06018BE8 RID: 101352 RVA: 0x006FDEB6 File Offset: 0x006FC0B6
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018BE9 RID: 101353 RVA: 0x006FDEBC File Offset: 0x006FC0BC
	public override void OnRemoved(bool bPremature)
	{
		EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(base.OwnerEntity, (ESummonType)this.SummonType, 1);
		WorldEntity worldEntity = (summonedEntity != null) ? summonedEntity.Entity : null;
		CharacterBuffComponent characterBuffComponent = (worldEntity != null) ? worldEntity.GetComponent<CharacterBuffComponent>() : null;
		if (characterBuffComponent != null)
		{
			foreach (long num in this.BuffIds)
			{
				BaseBuffComponent baseBuffComponent = characterBuffComponent;
				long buffId = num;
				int stackCount = -1;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
				defaultInterpolatedStringHandler.AppendLiteral("召唤者的buff");
				defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
				defaultInterpolatedStringHandler.AppendLiteral("移除");
				baseBuffComponent.RemoveBuff(buffId, stackCount, defaultInterpolatedStringHandler.ToStringAndClear(), null, null, null);
			}
		}
	}

	// Token: 0x0400C0B4 RID: 49332
	protected int SummonType;

	// Token: 0x0400C0B5 RID: 49333
	protected int SummonIndex;

	// Token: 0x0400C0B6 RID: 49334
	protected long[] BuffIds = Array.Empty<long>();
}
