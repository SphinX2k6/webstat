using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D66 RID: 3430
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStatePositionTarget.TsAnimNotifyStatePositionTarget_C")]
public class TsAnimNotifyStatePositionTarget : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000420 RID: 1056
	// (get) Token: 0x060049DE RID: 18910 RVA: 0x000A00A3 File Offset: 0x0009E2A3
	// (set) Token: 0x060049DF RID: 18911 RVA: 0x000A00B3 File Offset: 0x0009E2B3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 最大速度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionTarget.__PropertyOffset_最大速度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionTarget.__PropertyOffset_最大速度) = value;
		}
	}

	// Token: 0x17000421 RID: 1057
	// (get) Token: 0x060049E0 RID: 18912 RVA: 0x000A00C4 File Offset: 0x0009E2C4
	// (set) Token: 0x060049E1 RID: 18913 RVA: 0x000A00D8 File Offset: 0x0009E2D8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat 速度变化曲线
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStatePositionTarget.__PropertyOffset_速度变化曲线);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStatePositionTarget.__PropertyOffset_速度变化曲线, value);
		}
	}

	// Token: 0x17000422 RID: 1058
	// (get) Token: 0x060049E2 RID: 18914 RVA: 0x000A00ED File Offset: 0x0009E2ED
	// (set) Token: 0x060049E3 RID: 18915 RVA: 0x000A00FD File Offset: 0x0009E2FD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 最小距离
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionTarget.__PropertyOffset_最小距离);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionTarget.__PropertyOffset_最小距离) = value;
		}
	}

	// Token: 0x17000423 RID: 1059
	// (get) Token: 0x060049E4 RID: 18916 RVA: 0x000A010E File Offset: 0x0009E30E
	// (set) Token: 0x060049E5 RID: 18917 RVA: 0x000A011E File Offset: 0x0009E31E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 达成条件后终止逻辑
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionTarget.__PropertyOffset_达成条件后终止逻辑) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePositionTarget.__PropertyOffset_达成条件后终止逻辑) = (value ? 1 : 0);
		}
	}

	// Token: 0x060049E6 RID: 18918 RVA: 0x000A0130 File Offset: 0x0009E330
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

	// Token: 0x060049E7 RID: 18919 RVA: 0x000A01D8 File Offset: 0x0009E3D8
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		this.Init();
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		Entity entity = tsBaseCharacter.CharacterActorComponent.Entity;
		if (entity == null || !entity.Valid)
		{
			return false;
		}
		CharacterSkillComponent component = entity.GetComponent<CharacterSkillComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		EntityHandle skillTargetForAns = component.GetSkillTargetForAns();
		AActor aactor;
		if (skillTargetForAns == null)
		{
			aactor = null;
		}
		else
		{
			WorldEntity entity2 = skillTargetForAns.Entity;
			if (entity2 == null)
			{
				aactor = null;
			}
			else
			{
				BaseActorComponent component2 = entity2.GetComponent<BaseActorComponent>();
				aactor = ((component2 != null) ? component2.Owner : null);
			}
		}
		AActor aactor2 = aactor;
		if (aactor2 == null || !aactor2.IsValid())
		{
			return false;
		}
		Vector inB = Vector.Create(owner.D_K2_GetActorLocation());
		Vector.Create(aactor2.D_K2_GetActorLocation()).Subtraction(inB, this.速度);
		this.速度.DivisionEqual((double)totalDuration);
		return true;
	}

	// Token: 0x060049E8 RID: 18920 RVA: 0x000A02B8 File Offset: 0x0009E4B8
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

	// Token: 0x060049E9 RID: 18921 RVA: 0x000A0360 File Offset: 0x0009E560
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		if (this.终止逻辑)
		{
			return false;
		}
		this.经过时间 += frameDeltaTime;
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		Entity entity = tsBaseCharacter.CharacterActorComponent.Entity;
		if (entity == null || !entity.Valid)
		{
			return false;
		}
		CharacterSkillComponent component = entity.GetComponent<CharacterSkillComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		EntityHandle skillTargetForAns = component.GetSkillTargetForAns();
		AActor aactor;
		if (skillTargetForAns == null)
		{
			aactor = null;
		}
		else
		{
			WorldEntity entity2 = skillTargetForAns.Entity;
			if (entity2 == null)
			{
				aactor = null;
			}
			else
			{
				BaseActorComponent component2 = entity2.GetComponent<BaseActorComponent>();
				aactor = ((component2 != null) ? component2.Owner : null);
			}
		}
		AActor aactor2 = aactor;
		if (aactor2 == null || !aactor2.IsValid())
		{
			return false;
		}
		if (this.最小距离 > 0f)
		{
			Vector v = Vector.Create(owner.D_K2_GetActorLocation());
			Vector v2 = Vector.Create(aactor2.D_K2_GetActorLocation());
			if (Vector.DistSquared(v, v2) <= (double)(this.最小距离 * this.最小距离) && this.达成条件后终止逻辑)
			{
				this.终止逻辑 = true;
				return true;
			}
		}
		UCurveFloat 速度变化曲线 = this.速度变化曲线;
		float num = (速度变化曲线 != null && 速度变化曲线.IsValid()) ? this.速度变化曲线.GetFloatValue(this.经过时间) : 1f;
		this.速度.Multiply((double)num, this.TmpVector);
		this.TmpVector.GetClampedToMaxSize((double)this.最大速度, this.TmpVector);
		this.TmpVector.MultiplyEqual((double)frameDeltaTime);
		BaseMoveComponent component3 = entity.GetComponent<BaseMoveComponent>();
		if (component3 != null)
		{
			component3.SetAddMoveOffset(new FVectorDouble?(this.TmpVector.ToUeVector(false)));
		}
		return true;
	}

	// Token: 0x060049EA RID: 18922 RVA: 0x000A04F8 File Offset: 0x0009E6F8
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

	// Token: 0x060049EB RID: 18923 RVA: 0x000A0597 File Offset: 0x0009E797
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		this.经过时间 = 0f;
		return true;
	}

	// Token: 0x060049EC RID: 18924 RVA: 0x000A05A5 File Offset: 0x0009E7A5
	private void Init()
	{
		this.经过时间 = 0f;
		this.速度 = Vector.Create();
		this.TmpVector = Vector.Create();
		this.终止逻辑 = false;
	}

	// Token: 0x060049ED RID: 18925 RVA: 0x000A05D0 File Offset: 0x0009E7D0
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

	// Token: 0x060049EE RID: 18926 RVA: 0x000A064B File Offset: 0x0009E84B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "位移到目标身前";
	}

	// Token: 0x060049EF RID: 18927 RVA: 0x000A0652 File Offset: 0x0009E852
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStatePositionTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStatePositionTarget.TsAnimNotifyStatePositionTarget_C");
		}
		return TsAnimNotifyStatePositionTarget._ClassPtr;
	}

	// Token: 0x060049F0 RID: 18928 RVA: 0x000A0678 File Offset: 0x0009E878
	public TsAnimNotifyStatePositionTarget() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStatePositionTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060049F1 RID: 18929 RVA: 0x000A06A0 File Offset: 0x0009E8A0
	[NullableContext(1)]
	public TsAnimNotifyStatePositionTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStatePositionTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060049F2 RID: 18930 RVA: 0x000A06D3 File Offset: 0x0009E8D3
	protected TsAnimNotifyStatePositionTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060049F3 RID: 18931 RVA: 0x000A06DC File Offset: 0x0009E8DC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060049F4 RID: 18932 RVA: 0x000A0718 File Offset: 0x0009E918
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x060049F5 RID: 18933 RVA: 0x000A0754 File Offset: 0x0009E954
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060049F6 RID: 18934 RVA: 0x000A0787 File Offset: 0x0009E987
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040014DC RID: 5340
	private float 经过时间;

	// Token: 0x040014DD RID: 5341
	private Vector 速度;

	// Token: 0x040014DE RID: 5342
	private Vector TmpVector;

	// Token: 0x040014DF RID: 5343
	private bool 终止逻辑;

	// Token: 0x040014E0 RID: 5344
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStatePositionTarget.TsAnimNotifyStatePositionTarget_C";

	// Token: 0x040014E1 RID: 5345
	private static IntPtr _ClassPtr;

	// Token: 0x040014E2 RID: 5346
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040014E3 RID: 5347
	private static int __PropertyOffset_最大速度;

	// Token: 0x040014E4 RID: 5348
	private static int __PropertyOffset_速度变化曲线;

	// Token: 0x040014E5 RID: 5349
	private static int __PropertyOffset_最小距离;

	// Token: 0x040014E6 RID: 5350
	private static int __PropertyOffset_达成条件后终止逻辑;
}
