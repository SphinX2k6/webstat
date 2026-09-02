using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.ExtraEffect
{
	// Token: 0x02004986 RID: 18822
	[NullableContext(1)]
	[Nullable(0)]
	public class AbnormalThunder : PeriodExecution
	{
		// Token: 0x060312F1 RID: 201457 RVA: 0x00C3EEE7 File Offset: 0x00C3D0E7
		public AbnormalThunder(RequireAndLimits requireAndLimits) : base(requireAndLimits)
		{
		}

		// Token: 0x060312F2 RID: 201458 RVA: 0x00C3EEF0 File Offset: 0x00C3D0F0
		protected override void InitParameters(ExtraEffectParameters parameters)
		{
			if (parameters.ExtraEffectParameters_ == null)
			{
				return;
			}
			this.ReductionRateThunder = float.Parse(parameters.ExtraEffectParameters_.ElementAtOrDefault(0) ?? "0") * 0.0001f;
			this.ReductionRateExplode = float.Parse(parameters.ExtraEffectParameters_.ElementAtOrDefault(1) ?? "0") * 0.0001f;
			this.ExplodeBuffId = long.Parse(parameters.ExtraEffectParameters_.ElementAtOrDefault(2) ?? "0");
			this.ExecuteAddBuffId = long.Parse(parameters.ExtraEffectParameters_.ElementAtOrDefault(5) ?? "0");
		}

		// Token: 0x060312F3 RID: 201459 RVA: 0x00C3EF94 File Offset: 0x00C3D194
		[return: Nullable(2)]
		public override object OnExecute(params object[] args)
		{
			base.BuffEffectExecutePush();
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			int num = (int)Math.Ceiling((double)((float)this.Buff.StackCount * this.ReductionRateThunder));
			if (num > 0)
			{
				ownerBuffComponent.RemoveBuff(this.BuffId, num, "电磁效应触发时移除buff", null, null, null);
			}
			ActiveBuffInternal buffById = ownerBuffComponent.GetBuffById(this.ExplodeBuffId);
			if (buffById != null)
			{
				num = (int)Math.Ceiling((double)((float)buffById.StackCount * this.ReductionRateExplode));
				ownerBuffComponent.RemoveBuff(this.ExplodeBuffId, num, "电磁效应触发时移除buff", null, null, null);
			}
			if (this.ExecuteAddBuffId > 0L)
			{
				IBuffComponent ownerBuffComponent2 = this.OwnerBuffComponent;
				if (ownerBuffComponent2 != null)
				{
					ownerBuffComponent2.AddIterativeBuff(this.ExecuteAddBuffId, this.Buff, null, true, "电磁效应触发时buff添加", null, null);
				}
			}
			return null;
		}

		// Token: 0x060312F4 RID: 201460 RVA: 0x00C3F094 File Offset: 0x00C3D294
		protected override void DoBuffStackOverflow(int oldStack, int newStack, int stackLimitMax)
		{
			int num = newStack - stackLimitMax;
			if (num > 0 && this.ExplodeBuffId > 0L)
			{
				IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
				if (ownerBuffComponent == null)
				{
					return;
				}
				ownerBuffComponent.AddIterativeBuff(this.ExplodeBuffId, this.Buff, new int?(num), true, "电磁效应叠层溢出添加", null, null);
			}
		}

		// Token: 0x0401C4E1 RID: 115937
		protected float ReductionRateThunder;

		// Token: 0x0401C4E2 RID: 115938
		protected float ReductionRateExplode;

		// Token: 0x0401C4E3 RID: 115939
		protected long ExplodeBuffId;

		// Token: 0x0401C4E4 RID: 115940
		protected long ExecuteAddBuffId;
	}
}
