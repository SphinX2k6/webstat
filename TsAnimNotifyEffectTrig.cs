using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.AnimNotifyInteraction.BP;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DC8 RID: 3528
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyEffectTrig.TsAnimNotifyEffectTrig_C")]
public class TsAnimNotifyEffectTrig : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000521 RID: 1313
	// (get) Token: 0x0600504A RID: 20554 RVA: 0x000B937F File Offset: 0x000B757F
	// (set) Token: 0x0600504B RID: 20555 RVA: 0x000B938F File Offset: 0x000B758F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int AteIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_AteIndex);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_AteIndex) = value;
		}
	}

	// Token: 0x17000522 RID: 1314
	// (get) Token: 0x0600504C RID: 20556 RVA: 0x000B93A0 File Offset: 0x000B75A0
	// (set) Token: 0x0600504D RID: 20557 RVA: 0x000B93B0 File Offset: 0x000B75B0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EEffectAction 攻击类型
	{
		get
		{
			return (EEffectAction)(*(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_攻击类型));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_攻击类型) = (byte)value;
		}
	}

	// Token: 0x17000523 RID: 1315
	// (get) Token: 0x0600504E RID: 20558 RVA: 0x000B93C1 File Offset: 0x000B75C1
	// (set) Token: 0x0600504F RID: 20559 RVA: 0x000B93D1 File Offset: 0x000B75D1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 攻击半径
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_攻击半径);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_攻击半径) = value;
		}
	}

	// Token: 0x17000524 RID: 1316
	// (get) Token: 0x06005050 RID: 20560 RVA: 0x000B93E2 File Offset: 0x000B75E2
	// (set) Token: 0x06005051 RID: 20561 RVA: 0x000B93F2 File Offset: 0x000B75F2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 攻击强度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_攻击强度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_攻击强度) = value;
		}
	}

	// Token: 0x17000525 RID: 1317
	// (get) Token: 0x06005052 RID: 20562 RVA: 0x000B9403 File Offset: 0x000B7603
	// (set) Token: 0x06005053 RID: 20563 RVA: 0x000B9413 File Offset: 0x000B7613
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 持续时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_持续时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_持续时间) = value;
		}
	}

	// Token: 0x17000526 RID: 1318
	// (get) Token: 0x06005054 RID: 20564 RVA: 0x000B9424 File Offset: 0x000B7624
	// (set) Token: 0x06005055 RID: 20565 RVA: 0x000B9434 File Offset: 0x000B7634
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 纹理高度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_纹理高度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_纹理高度) = value;
		}
	}

	// Token: 0x17000527 RID: 1319
	// (get) Token: 0x06005056 RID: 20566 RVA: 0x000B9445 File Offset: 0x000B7645
	// (set) Token: 0x06005057 RID: 20567 RVA: 0x000B9459 File Offset: 0x000B7659
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector 特效节点Location
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_特效节点Location);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyEffectTrig.__PropertyOffset_特效节点Location) = value;
		}
	}

	// Token: 0x17000528 RID: 1320
	// (get) Token: 0x06005058 RID: 20568 RVA: 0x000B946E File Offset: 0x000B766E
	// (set) Token: 0x06005059 RID: 20569 RVA: 0x000B9482 File Offset: 0x000B7682
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UMaterialParameterCollection AteMPC
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyEffectTrig.__PropertyOffset_AteMPC);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyEffectTrig.__PropertyOffset_AteMPC, value);
		}
	}

	// Token: 0x0600505A RID: 20570 RVA: 0x000B9498 File Offset: 0x000B7698
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (!(meshComp.GetOwner() is ACharacter))
		{
			Singleton<Log>.Instance.Warn(ELogModule.RenderEffect, ELogAuthor.ZJL, "TsAnimNotifyEffectTrig Owner非Character", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (this.AteMPC == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.RenderEffect, ELogAuthor.ZJL, "TsAnimNotifyEffectTrig 未配置 MPC", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (!EffectTriggerMaterialParameterRegistry.IsValidActionAndIndex(this.攻击类型, this.AteIndex))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.ZJL;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(54, 2);
			defaultInterpolatedStringHandler.AppendLiteral("TsAnimNotifyEffectTrig 攻击类型或AteIndex无效 攻击类型=");
			defaultInterpolatedStringHandler.AppendFormatted<EEffectAction>(this.攻击类型);
			defaultInterpolatedStringHandler.AppendLiteral(" AteIndex=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.AteIndex);
			instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.AteMPC, EffectTriggerMaterialParameterRegistry.GetTriggerParameterName(this.攻击类型, this.AteIndex), UGameplayStatics.GetRealTimeSeconds(GlobalData.World));
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.AteMPC, EffectTriggerMaterialParameterRegistry.GetDurationParameterName(this.攻击类型, this.AteIndex), this.持续时间);
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.AteMPC, EffectTriggerMaterialParameterRegistry.GetAttackRadiusParameterName(this.攻击类型, this.AteIndex), this.攻击半径);
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.AteMPC, EffectTriggerMaterialParameterRegistry.GetAttackMagnitudeParameterName(this.攻击类型, this.AteIndex), this.攻击强度);
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.AteMPC, EffectTriggerMaterialParameterRegistry.GetTextureHeightParameterName(this.攻击类型, this.AteIndex), this.纹理高度);
		Vector tempVectorDouble = this.TempVectorDouble;
		FVector 特效节点Location = this.特效节点Location;
		tempVectorDouble.FromUeVector(特效节点Location);
		FTransformDouble ftransformDouble = meshComp.D_K2_GetComponentToWorld();
		Vector tempVector = this.TempVector;
		FVectorDouble fvectorDouble = this.TempVectorDouble.ToUeVector(false);
		FVectorDouble fvectorDouble2 = ftransformDouble.TransformPosition(fvectorDouble);
		tempVector.FromUeVector(fvectorDouble2);
		UObject world = GlobalData.World;
		UMaterialParameterCollection ateMPC = this.AteMPC;
		FName actorLocationParameterName = EffectTriggerMaterialParameterRegistry.GetActorLocationParameterName(this.攻击类型, this.AteIndex);
		FLinearColor flinearColor = UKismetMathLibrary.Conv_VectorDoubleToLinearColor(this.TempVector.ToUeVector(false));
		UKismetMaterialLibrary.SetVectorParameterValue(world, ateMPC, actorLocationParameterName, flinearColor);
		return true;
	}

	// Token: 0x0600505B RID: 20571 RVA: 0x000B96A4 File Offset: 0x000B78A4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override string GetNotifyName()
	{
		return "触发特效";
	}

	// Token: 0x0600505C RID: 20572 RVA: 0x000B96AB File Offset: 0x000B78AB
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyEffectTrig._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyEffectTrig.TsAnimNotifyEffectTrig_C");
		}
		return TsAnimNotifyEffectTrig._ClassPtr;
	}

	// Token: 0x0600505D RID: 20573 RVA: 0x000B96D0 File Offset: 0x000B78D0
	public TsAnimNotifyEffectTrig() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyEffectTrig.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600505E RID: 20574 RVA: 0x000B96F8 File Offset: 0x000B78F8
	[NullableContext(1)]
	public TsAnimNotifyEffectTrig(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyEffectTrig.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600505F RID: 20575 RVA: 0x000B972B File Offset: 0x000B792B
	protected TsAnimNotifyEffectTrig(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005060 RID: 20576 RVA: 0x000B974C File Offset: 0x000B794C
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005061 RID: 20577 RVA: 0x000B977F File Offset: 0x000B797F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName());
	}

	// Token: 0x04001775 RID: 6005
	[Nullable(1)]
	private readonly Vector TempVector = Vector.Create();

	// Token: 0x04001776 RID: 6006
	[Nullable(1)]
	private readonly Vector TempVectorDouble = Vector.Create();

	// Token: 0x04001777 RID: 6007
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyEffectTrig.TsAnimNotifyEffectTrig_C";

	// Token: 0x04001778 RID: 6008
	private static IntPtr _ClassPtr;

	// Token: 0x04001779 RID: 6009
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400177A RID: 6010
	private static int __PropertyOffset_AteIndex;

	// Token: 0x0400177B RID: 6011
	private static int __PropertyOffset_攻击类型;

	// Token: 0x0400177C RID: 6012
	private static int __PropertyOffset_攻击半径;

	// Token: 0x0400177D RID: 6013
	private static int __PropertyOffset_攻击强度;

	// Token: 0x0400177E RID: 6014
	private static int __PropertyOffset_持续时间;

	// Token: 0x0400177F RID: 6015
	private static int __PropertyOffset_纹理高度;

	// Token: 0x04001780 RID: 6016
	private static int __PropertyOffset_特效节点Location;

	// Token: 0x04001781 RID: 6017
	private static int __PropertyOffset_AteMPC;
}
