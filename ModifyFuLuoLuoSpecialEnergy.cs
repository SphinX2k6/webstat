using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F85 RID: 12165
[NullableContext(1)]
[Nullable(0)]
public class ModifyFuLuoLuoSpecialEnergy : PeriodExecution
{
	// Token: 0x06018D42 RID: 101698 RVA: 0x007070BC File Offset: 0x007052BC
	public ModifyFuLuoLuoSpecialEnergy(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D43 RID: 101699 RVA: 0x007070D0 File Offset: 0x007052D0
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null)
		{
			this.NumberParams = Array.Empty<int>();
			return;
		}
		this.NumberParams = new int[extraEffectParameters_.Length];
		for (int i = 0; i < extraEffectParameters_.Length; i++)
		{
			this.NumberParams[i] = int.Parse(extraEffectParameters_[i]);
		}
	}

	// Token: 0x06018D44 RID: 101700 RVA: 0x00707120 File Offset: 0x00705320
	[return: Nullable(2)]
	public unsafe override object OnExecute(params object[] args)
	{
		if (base.OwnerEntity != null)
		{
			int energyType = (this.NumberParams.Length != 0) ? this.NumberParams[0] : 0;
			if (!AbilityUtils.ModifyFuLuoLuoSpecialEnergy(base.OwnerEntity, energyType))
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
				Entity ownerEntity = base.OwnerEntity;
				string message = "buff额外效果修改弗洛洛特殊能量失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "handle";
				IActiveBuff buff = this.Buff;
				ptr = new ValueTuple<string, object>(item, (buff != null) ? new int?(buff.Handle) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffId", this.BuffId);
				instance.Error(flag, ownerEntity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		return null;
	}

	// Token: 0x06018D45 RID: 101701 RVA: 0x007071E4 File Offset: 0x007053E4
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
		defaultInterpolatedStringHandler.AppendLiteral("buff");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
		defaultInterpolatedStringHandler.AppendLiteral(" 修改弗洛洛特殊能量 ");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join<int>(",", this.NumberParams));
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C1C0 RID: 49600
	private int[] NumberParams = Array.Empty<int>();
}
