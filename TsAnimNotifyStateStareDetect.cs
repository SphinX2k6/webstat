using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D8D RID: 3469
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateStareDetect.TsAnimNotifyStateStareDetect_C")]
public class TsAnimNotifyStateStareDetect : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000490 RID: 1168
	// (get) Token: 0x06004CA4 RID: 19620 RVA: 0x000AB707 File Offset: 0x000A9907
	// (set) Token: 0x06004CA5 RID: 19621 RVA: 0x000AB71B File Offset: 0x000A991B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag 发送GameplayEvent
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateStareDetect.__PropertyOffset_发送GameplayEvent);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateStareDetect.__PropertyOffset_发送GameplayEvent) = value;
		}
	}

	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x06004CA6 RID: 19622 RVA: 0x000AB730 File Offset: 0x000A9930
	// (set) Token: 0x06004CA7 RID: 19623 RVA: 0x000AB740 File Offset: 0x000A9940
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 持续时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateStareDetect.__PropertyOffset_持续时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateStareDetect.__PropertyOffset_持续时间) = value;
		}
	}

	// Token: 0x17000492 RID: 1170
	// (get) Token: 0x06004CA8 RID: 19624 RVA: 0x000AB751 File Offset: 0x000A9951
	// (set) Token: 0x06004CA9 RID: 19625 RVA: 0x000AB765 File Offset: 0x000A9965
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector2D 距离区间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateStareDetect.__PropertyOffset_距离区间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateStareDetect.__PropertyOffset_距离区间) = value;
		}
	}

	// Token: 0x17000493 RID: 1171
	// (get) Token: 0x06004CAA RID: 19626 RVA: 0x000AB77A File Offset: 0x000A997A
	// (set) Token: 0x06004CAB RID: 19627 RVA: 0x000AB78E File Offset: 0x000A998E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector2D 水平区间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateStareDetect.__PropertyOffset_水平区间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateStareDetect.__PropertyOffset_水平区间) = value;
		}
	}

	// Token: 0x17000494 RID: 1172
	// (get) Token: 0x06004CAC RID: 19628 RVA: 0x000AB7A3 File Offset: 0x000A99A3
	// (set) Token: 0x06004CAD RID: 19629 RVA: 0x000AB7B7 File Offset: 0x000A99B7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector2D 垂直区间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateStareDetect.__PropertyOffset_垂直区间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateStareDetect.__PropertyOffset_垂直区间) = value;
		}
	}

	// Token: 0x06004CAE RID: 19630 RVA: 0x000AB7CC File Offset: 0x000A99CC
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004CAF RID: 19631 RVA: 0x000AB874 File Offset: 0x000A9A74
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (!(meshComp.GetOwner() is TsBaseCharacter))
		{
			return false;
		}
		StareDetectParams value = new StareDetectParams();
		this.ParamsMap[meshComp] = value;
		return true;
	}

	// Token: 0x06004CB0 RID: 19632 RVA: 0x000AB8A4 File Offset: 0x000A9AA4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004CB1 RID: 19633 RVA: 0x000AB94C File Offset: 0x000A9B4C
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		StareDetectParams stareDetectParams;
		if (!this.ParamsMap.TryGetValue(meshComp, out stareDetectParams))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		if (this.StareDetect(characterActorComponent))
		{
			stareDetectParams.NowTime += frameDeltaTime;
		}
		if (stareDetectParams.NowTime > this.持续时间)
		{
			this.ParamsMap.Remove(meshComp);
			this.SendGameplayEvent(tsBaseCharacter.EntityId);
		}
		return true;
	}

	// Token: 0x06004CB2 RID: 19634 RVA: 0x000AB9C4 File Offset: 0x000A9BC4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004CB3 RID: 19635 RVA: 0x000ABA63 File Offset: 0x000A9C63
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (!(meshComp.GetOwner() is TsBaseCharacter))
		{
			return false;
		}
		this.ParamsMap.Remove(meshComp);
		return true;
	}

	// Token: 0x06004CB4 RID: 19636 RVA: 0x000ABA84 File Offset: 0x000A9C84
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x06004CB5 RID: 19637 RVA: 0x000ABAFF File Offset: 0x000A9CFF
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "发送动画广播通知（基于相机位置）";
	}

	// Token: 0x06004CB6 RID: 19638 RVA: 0x000ABB08 File Offset: 0x000A9D08
	[NullableContext(1)]
	private bool StareDetect(CharacterActorComponent myActorComp)
	{
		FVectorDouble actorForward = myActorComp.ActorForward;
		FVectorDouble actorLocation = myActorComp.ActorLocation;
		FVectorDouble fvectorDouble = Global.CharacterCameraManager.D_GetCameraLocation();
		FVectorDouble fvectorDouble2 = fvectorDouble - actorLocation;
		FVectorDouble fvectorDouble3 = FVectorDouble.CrossProduct(actorForward, Vector.UpVectorDouble);
		float xDeg = (float)Singleton<MathUtils>.Instance.SignedAngleOnPlaneDeg(actorForward, fvectorDouble2, Vector.UpVectorDouble);
		float xDeg2 = (float)Singleton<MathUtils>.Instance.SignedAngleOnPlaneDeg(actorForward, fvectorDouble2, fvectorDouble3);
		float distance = (float)fvectorDouble2.Size();
		bool flag = this.AngleInRangeDeg(xDeg, this.水平区间);
		bool flag2 = this.AngleInRangeDeg(xDeg2, this.垂直区间);
		bool flag3 = this.DistanceInRange(distance, this.距离区间);
		return flag && flag2 && flag3;
	}

	// Token: 0x06004CB7 RID: 19639 RVA: 0x000ABBCC File Offset: 0x000A9DCC
	private void SendGameplayEvent(int entityId)
	{
		BaseAbilityComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseAbilityComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SendGameplayEventToActor(this.发送GameplayEvent, null);
	}

	// Token: 0x06004CB8 RID: 19640 RVA: 0x000ABBEC File Offset: 0x000A9DEC
	private bool AngleInRangeDeg(float xDeg, FVector2D rangeDeg)
	{
		float num = (float)Singleton<MathUtils>.Instance.NormalizeDeg180((double)xDeg);
		float num2 = (float)Singleton<MathUtils>.Instance.NormalizeDeg180((double)rangeDeg.X);
		float num3 = (float)Singleton<MathUtils>.Instance.NormalizeDeg180((double)rangeDeg.Y);
		return Singleton<MathUtils>.Instance.IsAngleInRange((double)num, (double)num2, (double)num3);
	}

	// Token: 0x06004CB9 RID: 19641 RVA: 0x000ABC40 File Offset: 0x000A9E40
	private bool DistanceInRange(float distance, FVector2D range)
	{
		float x = range.X;
		float y = range.Y;
		return (x == -1f || distance >= x) && (y == -1f || distance <= y);
	}

	// Token: 0x06004CBA RID: 19642 RVA: 0x000ABC7A File Offset: 0x000A9E7A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateStareDetect._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateStareDetect.TsAnimNotifyStateStareDetect_C");
		}
		return TsAnimNotifyStateStareDetect._ClassPtr;
	}

	// Token: 0x06004CBB RID: 19643 RVA: 0x000ABCA0 File Offset: 0x000A9EA0
	public TsAnimNotifyStateStareDetect() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateStareDetect.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004CBC RID: 19644 RVA: 0x000ABCC8 File Offset: 0x000A9EC8
	[NullableContext(1)]
	public TsAnimNotifyStateStareDetect(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateStareDetect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004CBD RID: 19645 RVA: 0x000ABCFB File Offset: 0x000A9EFB
	protected TsAnimNotifyStateStareDetect(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004CBE RID: 19646 RVA: 0x000ABD10 File Offset: 0x000A9F10
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004CBF RID: 19647 RVA: 0x000ABD4C File Offset: 0x000A9F4C
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004CC0 RID: 19648 RVA: 0x000ABD88 File Offset: 0x000A9F88
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004CC1 RID: 19649 RVA: 0x000ABDBB File Offset: 0x000A9FBB
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040015F4 RID: 5620
	[Nullable(1)]
	private readonly Dictionary<USkeletalMeshComponent, StareDetectParams> ParamsMap = new Dictionary<USkeletalMeshComponent, StareDetectParams>();

	// Token: 0x040015F5 RID: 5621
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateStareDetect.TsAnimNotifyStateStareDetect_C";

	// Token: 0x040015F6 RID: 5622
	private static IntPtr _ClassPtr;

	// Token: 0x040015F7 RID: 5623
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040015F8 RID: 5624
	private static int __PropertyOffset_发送GameplayEvent;

	// Token: 0x040015F9 RID: 5625
	private static int __PropertyOffset_持续时间;

	// Token: 0x040015FA RID: 5626
	private static int __PropertyOffset_距离区间;

	// Token: 0x040015FB RID: 5627
	private static int __PropertyOffset_水平区间;

	// Token: 0x040015FC RID: 5628
	private static int __PropertyOffset_垂直区间;
}
