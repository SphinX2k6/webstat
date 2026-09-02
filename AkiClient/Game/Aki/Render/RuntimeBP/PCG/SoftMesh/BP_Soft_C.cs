using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SoftMesh
{
	// Token: 0x02003B6B RID: 15211
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/BP_Soft.BP_Soft_C")]
	[UnrealStructLayout(1432, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1428)]
	public class BP_Soft_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021732 RID: 137010 RVA: 0x009497F0 File Offset: 0x009479F0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Soft_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/BP_Soft.BP_Soft_C");
			}
			return BP_Soft_C._ClassPtr;
		}

		// Token: 0x06021733 RID: 137011 RVA: 0x00949814 File Offset: 0x00947A14
		public BP_Soft_C() : this(BuiltinUtils.AllocNativeUObject(BP_Soft_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021734 RID: 137012 RVA: 0x0094983C File Offset: 0x00947A3C
		[NullableContext(1)]
		public BP_Soft_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Soft_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003B39 RID: 15161
		// (get) Token: 0x06021735 RID: 137013 RVA: 0x00949870 File Offset: 0x00947A70
		// (set) Token: 0x06021736 RID: 137014 RVA: 0x009498A9 File Offset: 0x00947AA9
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003B3A RID: 15162
		// (get) Token: 0x06021737 RID: 137015 RVA: 0x009498CA File Offset: 0x00947ACA
		// (set) Token: 0x06021738 RID: 137016 RVA: 0x009498DE File Offset: 0x00947ADE
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003B3B RID: 15163
		// (get) Token: 0x06021739 RID: 137017 RVA: 0x009498F3 File Offset: 0x00947AF3
		// (set) Token: 0x0602173A RID: 137018 RVA: 0x00949907 File Offset: 0x00947B07
		public unsafe UStaticMeshComponent xpbd_test
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003B3C RID: 15164
		// (get) Token: 0x0602173B RID: 137019 RVA: 0x0094991C File Offset: 0x00947B1C
		// (set) Token: 0x0602173C RID: 137020 RVA: 0x00949930 File Offset: 0x00947B30
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003B3D RID: 15165
		// (get) Token: 0x0602173D RID: 137021 RVA: 0x00949945 File Offset: 0x00947B45
		// (set) Token: 0x0602173E RID: 137022 RVA: 0x00949959 File Offset: 0x00947B59
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003B3E RID: 15166
		// (get) Token: 0x0602173F RID: 137023 RVA: 0x0094996E File Offset: 0x00947B6E
		// (set) Token: 0x06021740 RID: 137024 RVA: 0x00949982 File Offset: 0x00947B82
		public unsafe FVector BoxExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003B3F RID: 15167
		// (get) Token: 0x06021741 RID: 137025 RVA: 0x00949997 File Offset: 0x00947B97
		// (set) Token: 0x06021742 RID: 137026 RVA: 0x009499A7 File Offset: 0x00947BA7
		public unsafe float Mass
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003B40 RID: 15168
		// (get) Token: 0x06021743 RID: 137027 RVA: 0x009499B8 File Offset: 0x00947BB8
		// (set) Token: 0x06021744 RID: 137028 RVA: 0x009499CC File Offset: 0x00947BCC
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003B41 RID: 15169
		// (get) Token: 0x06021745 RID: 137029 RVA: 0x009499E1 File Offset: 0x00947BE1
		// (set) Token: 0x06021746 RID: 137030 RVA: 0x009499F1 File Offset: 0x00947BF1
		public unsafe float Tightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003B42 RID: 15170
		// (get) Token: 0x06021747 RID: 137031 RVA: 0x00949A02 File Offset: 0x00947C02
		// (set) Token: 0x06021748 RID: 137032 RVA: 0x00949A16 File Offset: 0x00947C16
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003B43 RID: 15171
		// (get) Token: 0x06021749 RID: 137033 RVA: 0x00949A2B File Offset: 0x00947C2B
		// (set) Token: 0x0602174A RID: 137034 RVA: 0x00949A3F File Offset: 0x00947C3F
		public unsafe UHoudiniPointCache HoudiniPointCache
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHoudiniPointCache>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003B44 RID: 15172
		// (get) Token: 0x0602174B RID: 137035 RVA: 0x00949A54 File Offset: 0x00947C54
		// (set) Token: 0x0602174C RID: 137036 RVA: 0x00949A68 File Offset: 0x00947C68
		public unsafe UMaterialInstanceDynamic Dmaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003B45 RID: 15173
		// (get) Token: 0x0602174D RID: 137037 RVA: 0x00949A7D File Offset: 0x00947C7D
		// (set) Token: 0x0602174E RID: 137038 RVA: 0x00949A91 File Offset: 0x00947C91
		public unsafe UMaterialInstance InputMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003B46 RID: 15174
		// (get) Token: 0x0602174F RID: 137039 RVA: 0x00949AA6 File Offset: 0x00947CA6
		// (set) Token: 0x06021750 RID: 137040 RVA: 0x00949AB6 File Offset: 0x00947CB6
		public unsafe bool AlreadyBegin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B47 RID: 15175
		// (get) Token: 0x06021751 RID: 137041 RVA: 0x00949AC7 File Offset: 0x00947CC7
		// (set) Token: 0x06021752 RID: 137042 RVA: 0x00949AD7 File Offset: 0x00947CD7
		public unsafe bool initOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B48 RID: 15176
		// (get) Token: 0x06021753 RID: 137043 RVA: 0x00949AE8 File Offset: 0x00947CE8
		// (set) Token: 0x06021754 RID: 137044 RVA: 0x00949AF8 File Offset: 0x00947CF8
		public unsafe float dt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003B49 RID: 15177
		// (get) Token: 0x06021755 RID: 137045 RVA: 0x00949B09 File Offset: 0x00947D09
		// (set) Token: 0x06021756 RID: 137046 RVA: 0x00949B19 File Offset: 0x00947D19
		public unsafe float fade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x06021757 RID: 137047 RVA: 0x00949B2A File Offset: 0x00947D2A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021758 RID: 137048 RVA: 0x00949B3E File Offset: 0x00947D3E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021759 RID: 137049 RVA: 0x00949B54 File Offset: 0x00947D54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_Soft_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_Soft_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_Soft_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602175A RID: 137050 RVA: 0x00949C10 File Offset: 0x00947E10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_Soft_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_Soft_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Soft_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602175B RID: 137051 RVA: 0x00949C99 File Offset: 0x00947E99
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_C.__CustomEvent1_NativeFunctionPtr, null);
		}

		// Token: 0x0602175C RID: 137052 RVA: 0x00949CAD File Offset: 0x00947EAD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_C.__CustomEvent_0_NativeFunctionPtr, null);
		}

		// Token: 0x0602175D RID: 137053 RVA: 0x00949CC4 File Offset: 0x00947EC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Soft_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Soft_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Soft_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602175E RID: 137054 RVA: 0x00949D0C File Offset: 0x00947F0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Soft_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Soft_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Soft_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602175F RID: 137055 RVA: 0x00949D53 File Offset: 0x00947F53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021760 RID: 137056 RVA: 0x00949D67 File Offset: 0x00947F67
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021761 RID: 137057 RVA: 0x00949D7C File Offset: 0x00947F7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x06021762 RID: 137058 RVA: 0x00949D90 File Offset: 0x00947F90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021763 RID: 137059 RVA: 0x00949DA5 File Offset: 0x00947FA5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x06021764 RID: 137060 RVA: 0x00949DB9 File Offset: 0x00947FB9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021765 RID: 137061 RVA: 0x00949DD0 File Offset: 0x00947FD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Soft(int EntryPoint)
		{
			BP_Soft_C.__ExecuteUbergraph_BP_Soft_FunctionParams* ptr = stackalloc BP_Soft_C.__ExecuteUbergraph_BP_Soft_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(BP_Soft_C.__ExecuteUbergraph_BP_Soft_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_C.__ExecuteUbergraph_BP_Soft_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_C.__ExecuteUbergraph_BP_Soft_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021766 RID: 137062 RVA: 0x00949E1A File Offset: 0x0094801A
		protected BP_Soft_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010D78 RID: 68984
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/BP_Soft.BP_Soft_C";

		// Token: 0x04010D79 RID: 68985
		private static IntPtr _ClassPtr;

		// Token: 0x04010D7A RID: 68986
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010D7B RID: 68987
		internal static int __PropertyOffset_0;

		// Token: 0x04010D7C RID: 68988
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010D7D RID: 68989
		internal static int __PropertyOffset_1;

		// Token: 0x04010D7E RID: 68990
		internal static int __PropertyOffset_2;

		// Token: 0x04010D7F RID: 68991
		internal static int __PropertyOffset_3;

		// Token: 0x04010D80 RID: 68992
		internal static int __PropertyOffset_4;

		// Token: 0x04010D81 RID: 68993
		internal static int __PropertyOffset_5;

		// Token: 0x04010D82 RID: 68994
		internal static int __PropertyOffset_6;

		// Token: 0x04010D83 RID: 68995
		internal static int __PropertyOffset_7;

		// Token: 0x04010D84 RID: 68996
		internal static int __PropertyOffset_8;

		// Token: 0x04010D85 RID: 68997
		internal static int __PropertyOffset_9;

		// Token: 0x04010D86 RID: 68998
		internal static int __PropertyOffset_10;

		// Token: 0x04010D87 RID: 68999
		internal static int __PropertyOffset_11;

		// Token: 0x04010D88 RID: 69000
		internal static int __PropertyOffset_12;

		// Token: 0x04010D89 RID: 69001
		internal static int __PropertyOffset_13;

		// Token: 0x04010D8A RID: 69002
		internal static int __PropertyOffset_14;

		// Token: 0x04010D8B RID: 69003
		internal static int __PropertyOffset_15;

		// Token: 0x04010D8C RID: 69004
		internal static int __PropertyOffset_16;

		// Token: 0x04010D8D RID: 69005
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010D8E RID: 69006
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010D8F RID: 69007
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010D90 RID: 69008
		private static IntPtr __CustomEvent1_NativeFunctionPtr;

		// Token: 0x04010D91 RID: 69009
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x04010D92 RID: 69010
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010D93 RID: 69011
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010D94 RID: 69012
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x04010D95 RID: 69013
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x04010D96 RID: 69014
		private static IntPtr __ExecuteUbergraph_BP_Soft_NativeFunctionPtr;

		// Token: 0x02009ADD RID: 39645
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032261 RID: 205409
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032262 RID: 205410
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032263 RID: 205411
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032264 RID: 205412
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032265 RID: 205413
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032266 RID: 205414
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009ADE RID: 39646
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032267 RID: 205415
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032268 RID: 205416
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032269 RID: 205417
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403226A RID: 205418
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009ADF RID: 39647
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403226B RID: 205419
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AE0 RID: 39648
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected ref struct __ExecuteUbergraph_BP_Soft_FunctionParams
		{
			// Token: 0x0403226C RID: 205420
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
