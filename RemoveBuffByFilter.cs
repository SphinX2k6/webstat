using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002F89 RID: 12169
[NullableContext(1)]
[Nullable(0)]
public class RemoveBuffByFilter : PeriodExecution
{
	// Token: 0x06018D4A RID: 101706 RVA: 0x0070738E File Offset: 0x0070558E
	public RemoveBuffByFilter(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D4B RID: 101707 RVA: 0x00707398 File Offset: 0x00705598
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length == 0)
		{
			this.FilterType = ERemoveBuffFilterType.OutsideList;
			this.KeepBuffIds = null;
			return;
		}
		this.FilterType = (ERemoveBuffFilterType)int.Parse(extraEffectParameters_[0]);
		if (this.FilterType == ERemoveBuffFilterType.OutsideList)
		{
			if (extraEffectParameters_.Length > 1 && !string.IsNullOrEmpty(extraEffectParameters_[1]))
			{
				string[] array = extraEffectParameters_[1].Split('#', StringSplitOptions.None);
				this.KeepBuffIds = new HashSet<long>();
				for (int i = 0; i < array.Length; i++)
				{
					this.KeepBuffIds.Add(long.Parse(array[i]));
				}
				return;
			}
			this.KeepBuffIds = new HashSet<long>();
		}
	}

	// Token: 0x06018D4C RID: 101708 RVA: 0x00707430 File Offset: 0x00705630
	[return: Nullable(2)]
	public override object OnExecute(params object[] args)
	{
		if (this.OwnerBuffComponent == null)
		{
			Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.Buff, base.OwnerEntity, "buff:RemoveBuffsOutsideList失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		if (this.FilterType == ERemoveBuffFilterType.OutsideList)
		{
			foreach (IActiveBuff activeBuff in this.OwnerBuffComponent.GetAllBuffs())
			{
				HashSet<long> keepBuffIds = this.KeepBuffIds;
				if (keepBuffIds == null || !keepBuffIds.Contains(activeBuff.Id))
				{
					this.OwnerBuffComponent.RemoveBuff(activeBuff.Id, -1, "RemoveBuffsOutsideList", null, null, null);
				}
			}
		}
		return null;
	}

	// Token: 0x06018D4D RID: 101709 RVA: 0x007074E0 File Offset: 0x007056E0
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 2);
		defaultInterpolatedStringHandler.AppendLiteral("buff");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
		defaultInterpolatedStringHandler.AppendLiteral(" 移除列表外的其他buff");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join<long>(",", this.KeepBuffIds ?? new HashSet<long>()));
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C1C8 RID: 49608
	private ERemoveBuffFilterType FilterType;

	// Token: 0x0400C1C9 RID: 49609
	[Nullable(2)]
	private HashSet<long> KeepBuffIds;
}
