using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Vehicle.Motorcycle;
using UnrealEngine;

// Token: 0x02000F9C RID: 3996
public class LevelEventMotorSoarInWindField : LevelEventBase
{
	// Token: 0x060065F1 RID: 26097 RVA: 0x0019AFE8 File Offset: 0x001991E8
	public LevelEventMotorSoarInWindField(int id) : base(id)
	{
	}

	// Token: 0x060065F2 RID: 26098 RVA: 0x0019AFF4 File Offset: 0x001991F4
	[NullableContext(1)]
	public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
	{
		Singleton<global::Log>.Instance.Info(ELogModule.Vehicle, ELogAuthor.LCZ, "[MotorSoarInWindField]触发", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (context.Type.GetValueOrDefault() != EGeneralContextType.Trigger)
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Vehicle, ELogAuthor.LCZ, "[MotorSoarInWindField]必须使用Trigger触发", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		TriggerContext triggerContext = context as TriggerContext;
		if (triggerContext == null || triggerContext.OtherEntityId == null)
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Vehicle, ELogAuthor.LCZ, "[MotorSoarInWindField]缺失OtherEntityId", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int value = triggerContext.OtherEntityId.Value;
		MotorcycleWindFieldComponent component = Singleton<EntitySystem>.Instance.GetComponent<MotorcycleWindFieldComponent>(value);
		if (component == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "[MotorSoarInWindField]的触发者必须带有WindFieldComp";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", value);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		int value2 = triggerContext.TriggerEntityId.Value;
		BaseActorComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(value2);
		FTransformDouble? ftransformDouble = null;
		if (component2 != null && component2.Valid)
		{
			AActor owner = component2.Owner;
			ftransformDouble = ((owner != null) ? new FTransformDouble?(owner.D_GetTransform()) : null);
		}
		else
		{
			CreatureDataComponent component3 = Singleton<EntitySystem>.Instance.GetComponent<CreatureDataComponent>(value2);
			ftransformDouble = ((component3 != null) ? new FTransformDouble?(component3.D_GetTransform()) : null);
		}
		IMotorSoarInWindFieldControlType controlType = (inParams as MotorSoarInWindField).ControlType;
		EMotorSoarInWindFieldControlType type = controlType.Type;
		if (type == EMotorSoarInWindFieldControlType.EnterWindField)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Vehicle, ELogAuthor.LCZ, "[MotorSoarInWindField]触发 进入", default(ReadOnlySpan<ValueTuple<string, object>>));
			component.StartWindField(value2, ftransformDouble.Value, (IMotorSoarInWindFieldEnterWindField)controlType);
			return;
		}
		if (type != EMotorSoarInWindFieldControlType.ExitWindField)
		{
			return;
		}
		Singleton<global::Log>.Instance.Info(ELogModule.Vehicle, ELogAuthor.LCZ, "[MotorSoarInWindField]触发 退出", default(ReadOnlySpan<ValueTuple<string, object>>));
		component.EndWindField(value2);
	}
}
