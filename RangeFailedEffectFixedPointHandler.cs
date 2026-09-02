using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using UnrealEngine;

// Token: 0x02001DD0 RID: 7632
[NullableContext(1)]
[Nullable(0)]
internal class RangeFailedEffectFixedPointHandler : RangeFailedEffectHandler
{
	// Token: 0x0600E1DF RID: 57823 RVA: 0x003CD994 File Offset: 0x003CBB94
	private static bool FixedPointValid(RangeFailedParameterContext context)
	{
		return context.IsValid() && context.RangeFailedEffectCenterPos != null && context.RangeFailedEffectRadius > 0f;
	}

	// Token: 0x0600E1E0 RID: 57824 RVA: 0x003CD9B5 File Offset: 0x003CBBB5
	protected override bool CanHandle(RangeFailedParameterContext context)
	{
		return RangeFailedEffectFixedPointHandler.FixedPointValid(context);
	}

	// Token: 0x0600E1E1 RID: 57825 RVA: 0x003CD9BD File Offset: 0x003CBBBD
	protected override bool ShouldStop(RangeFailedParameterContext context)
	{
		return RangeFailedEffectFixedPointHandler.FixedPointValid(context);
	}

	// Token: 0x0600E1E2 RID: 57826 RVA: 0x003CD9C8 File Offset: 0x003CBBC8
	protected override void ExecuteProcessing(RangeFailedParameterContext context)
	{
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FVectorDouble fvectorDouble = context.RangeFailedEffectCenterPos.ToUeVector(false);
		FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble(ref Rotator.ZeroRotator, ref fvectorDouble, ref Vector.OneVector));
		Func<int, bool> <>9__1;
		instance.SpawnEffect(world, ftransformDouble, context.RangeFailedEffectPath, "[QuestFailedBehaviorNode.RangeFailedEffectFixedPointHandler]", null, EEffectType.Scene, null, delegate(ELoadEffectResult result, int handle)
		{
			if (result != ELoadEffectResult.Success)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GeneralLogicTree;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "GeneralLogicTree:CheckPointEffectController.SpawnEffect 错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", result);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (handle == 0)
			{
				return;
			}
			context.RangeEffectHandleId = handle;
			EffectSystem instance3 = Singleton<EffectSystem>.Instance;
			FName value = FNameUtil.GetDynamicFName("CircleRadius").Value;
			instance3.SetEffectDataFloatConstParam(handle, value, context.RangeFailedEffectRadius);
			EffectSystem instance4 = Singleton<EffectSystem>.Instance;
			Func<int, bool> func;
			if ((func = <>9__1) == null)
			{
				func = (<>9__1 = ((int _) => context.RangeEffectHandleId != 0));
			}
			instance4.RegisterCustomCheckOwnerFunc(handle, func);
		}, null, false, false);
	}
}
