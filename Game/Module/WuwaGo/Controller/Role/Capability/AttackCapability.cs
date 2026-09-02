using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.WuWaGo;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.Role.Capability
{
	// Token: 0x02004AFE RID: 19198
	[NullableContext(1)]
	[Nullable(0)]
	public class AttackCapability : CapabilityBase
	{
		// Token: 0x06032113 RID: 205075 RVA: 0x00C87075 File Offset: 0x00C85275
		public AttackCapability(WuWaGoRole role) : base(role)
		{
		}

		// Token: 0x06032114 RID: 205076 RVA: 0x00C87080 File Offset: 0x00C85280
		public IAttackSession Attack()
		{
			AttackCapability.<>c__DisplayClass4_0 CS$<>8__locals1 = new AttackCapability.<>c__DisplayClass4_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.hitPromise = new CustomPromise<UniTaskVoid>();
			CS$<>8__locals1.hitResolved = false;
			this.Role.RegisterAttackHitListener(new Action(CS$<>8__locals1.<Attack>g__ResolveHit|0));
			UniTask finished = CS$<>8__locals1.<Attack>g__FinishedAsync|1();
			return new AttackSession
			{
				HitOrFinished = CS$<>8__locals1.hitPromise.Promise,
				Finished = finished
			};
		}

		// Token: 0x06032115 RID: 205077 RVA: 0x00C870EC File Offset: 0x00C852EC
		private UniTask PerformAttackAnim()
		{
			AttackCapability.<PerformAttackAnim>d__5 <PerformAttackAnim>d__;
			<PerformAttackAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PerformAttackAnim>d__.<>4__this = this;
			<PerformAttackAnim>d__.<>1__state = -1;
			<PerformAttackAnim>d__.<>t__builder.Start<AttackCapability.<PerformAttackAnim>d__5>(ref <PerformAttackAnim>d__);
			return <PerformAttackAnim>d__.<>t__builder.Task;
		}

		// Token: 0x06032116 RID: 205078 RVA: 0x00C87130 File Offset: 0x00C85330
		private unsafe float ComputeRootMotionScale(UAnimMontage montage)
		{
			BP_WuWaGo_C setting = WuWaGoGlobal.Setting;
			if (setting == null || !setting.IsValid())
			{
				return 1f;
			}
			float num = (float)setting.SingleGridSize / 2f;
			int num2 = 700;
			float num3 = num / (float)num2;
			if (num3 < 0.1f || num3 > 5f)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.WuWaGo;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "攻击 RM scale 超出安全区间，已 clamp";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("montage", montage);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("raw", num3);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return Math.Min(5f, Math.Max(0.1f, num3));
		}

		// Token: 0x0401D44F RID: 119887
		private const int DEFAULT_ATTACK_MONTAGE_ORIGINAL_FORWARD_CM = 700;

		// Token: 0x0401D450 RID: 119888
		private const float ATTACK_RM_SCALE_MIN = 0.1f;

		// Token: 0x0401D451 RID: 119889
		private const int ATTACK_RM_SCALE_MAX = 5;
	}
}
