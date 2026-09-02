using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.AreaLightManager
{
	// Token: 0x02003B24 RID: 15140
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/AreaLightManager/BP_AreaTrigger.BP_AreaTrigger_C")]
	[UnrealStructLayout(1136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1129)]
	public class BP_AreaTrigger_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602093A RID: 133434 RVA: 0x00930B10 File Offset: 0x0092ED10
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AreaTrigger_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/AreaLightManager/BP_AreaTrigger.BP_AreaTrigger_C");
			}
			return BP_AreaTrigger_C._ClassPtr;
		}

		// Token: 0x0602093B RID: 133435 RVA: 0x00930B34 File Offset: 0x0092ED34
		public BP_AreaTrigger_C() : this(BuiltinUtils.AllocNativeUObject(BP_AreaTrigger_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602093C RID: 133436 RVA: 0x00930B5C File Offset: 0x0092ED5C
		[NullableContext(1)]
		public BP_AreaTrigger_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AreaTrigger_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003635 RID: 13877
		// (get) Token: 0x0602093D RID: 133437 RVA: 0x00930B90 File Offset: 0x0092ED90
		// (set) Token: 0x0602093E RID: 133438 RVA: 0x00930BC9 File Offset: 0x0092EDC9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_AreaTrigger_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_AreaTrigger_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003636 RID: 13878
		// (get) Token: 0x0602093F RID: 133439 RVA: 0x00930BEA File Offset: 0x0092EDEA
		// (set) Token: 0x06020940 RID: 133440 RVA: 0x00930BFE File Offset: 0x0092EDFE
		public unsafe UBoxComponent RightTrigger
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003637 RID: 13879
		// (get) Token: 0x06020941 RID: 133441 RVA: 0x00930C13 File Offset: 0x0092EE13
		// (set) Token: 0x06020942 RID: 133442 RVA: 0x00930C27 File Offset: 0x0092EE27
		public unsafe UBoxComponent LeftTrigger
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003638 RID: 13880
		// (get) Token: 0x06020943 RID: 133443 RVA: 0x00930C3C File Offset: 0x0092EE3C
		// (set) Token: 0x06020944 RID: 133444 RVA: 0x00930C50 File Offset: 0x0092EE50
		public unsafe UStaticMeshComponent AreaTriggerArrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003639 RID: 13881
		// (get) Token: 0x06020945 RID: 133445 RVA: 0x00930C65 File Offset: 0x0092EE65
		// (set) Token: 0x06020946 RID: 133446 RVA: 0x00930C79 File Offset: 0x0092EE79
		public unsafe UBoxComponent Root
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700363A RID: 13882
		// (get) Token: 0x06020947 RID: 133447 RVA: 0x00930C8E File Offset: 0x0092EE8E
		// (set) Token: 0x06020948 RID: 133448 RVA: 0x00930CA2 File Offset: 0x0092EEA2
		public unsafe UTextRenderComponent RightTextRender
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700363B RID: 13883
		// (get) Token: 0x06020949 RID: 133449 RVA: 0x00930CB7 File Offset: 0x0092EEB7
		// (set) Token: 0x0602094A RID: 133450 RVA: 0x00930CCB File Offset: 0x0092EECB
		public unsafe UTextRenderComponent LeftTextRender
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700363C RID: 13884
		// (get) Token: 0x0602094B RID: 133451 RVA: 0x00930CE0 File Offset: 0x0092EEE0
		// (set) Token: 0x0602094C RID: 133452 RVA: 0x00930CF4 File Offset: 0x0092EEF4
		public unsafe BP_AreaLightManager_C LightManager
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_AreaLightManager_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaTrigger_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700363D RID: 13885
		// (get) Token: 0x0602094D RID: 133453 RVA: 0x00930D09 File Offset: 0x0092EF09
		// (set) Token: 0x0602094E RID: 133454 RVA: 0x00930D19 File Offset: 0x0092EF19
		public unsafe int LeftAreaIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AreaTrigger_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AreaTrigger_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700363E RID: 13886
		// (get) Token: 0x0602094F RID: 133455 RVA: 0x00930D2A File Offset: 0x0092EF2A
		// (set) Token: 0x06020950 RID: 133456 RVA: 0x00930D3A File Offset: 0x0092EF3A
		public unsafe int RightAreaIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AreaTrigger_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AreaTrigger_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700363F RID: 13887
		// (get) Token: 0x06020951 RID: 133457 RVA: 0x00930D4B File Offset: 0x0092EF4B
		// (set) Token: 0x06020952 RID: 133458 RVA: 0x00930D5B File Offset: 0x0092EF5B
		public unsafe int PlayerInAreaIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AreaTrigger_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AreaTrigger_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003640 RID: 13888
		// (get) Token: 0x06020953 RID: 133459 RVA: 0x00930D6C File Offset: 0x0092EF6C
		// (set) Token: 0x06020954 RID: 133460 RVA: 0x00930D80 File Offset: 0x0092EF80
		[Nullable(1)]
		public unsafe string AreaText
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_AreaTrigger_C.__PropertyOffset_11)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_AreaTrigger_C.__PropertyOffset_11)), value);
			}
		}

		// Token: 0x17003641 RID: 13889
		// (get) Token: 0x06020955 RID: 133461 RVA: 0x00930D95 File Offset: 0x0092EF95
		// (set) Token: 0x06020956 RID: 133462 RVA: 0x00930DA5 File Offset: 0x0092EFA5
		public unsafe bool EnableOverlapTrigger
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AreaTrigger_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AreaTrigger_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020957 RID: 133463 RVA: 0x00930DB6 File Offset: 0x0092EFB6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AreaTrigger_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020958 RID: 133464 RVA: 0x00930DCA File Offset: 0x0092EFCA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AreaTrigger_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020959 RID: 133465 RVA: 0x00930DDF File Offset: 0x0092EFDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AreaTrigger_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602095A RID: 133466 RVA: 0x00930DF3 File Offset: 0x0092EFF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AreaTrigger_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602095B RID: 133467 RVA: 0x00930E08 File Offset: 0x0092F008
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_Test_FrontBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_AreaTrigger_C.__BndEvt__BP_Test_FrontBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_AreaTrigger_C.__BndEvt__BP_Test_FrontBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_AreaTrigger_C.__BndEvt__BP_Test_FrontBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AreaTrigger_C.__BndEvt__BP_Test_FrontBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AreaTrigger_C.__BndEvt__BP_Test_FrontBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602095C RID: 133468 RVA: 0x00930E94 File Offset: 0x0092F094
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_Test_BackBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_AreaTrigger_C.__BndEvt__BP_Test_BackBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_AreaTrigger_C.__BndEvt__BP_Test_BackBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_AreaTrigger_C.__BndEvt__BP_Test_BackBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AreaTrigger_C.__BndEvt__BP_Test_BackBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AreaTrigger_C.__BndEvt__BP_Test_BackBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602095D RID: 133469 RVA: 0x00930F20 File Offset: 0x0092F120
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_AreaTrigger_LeftTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_AreaTrigger_C.__BndEvt__BP_AreaTrigger_LeftTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_AreaTrigger_C.__BndEvt__BP_AreaTrigger_LeftTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_AreaTrigger_C.__BndEvt__BP_AreaTrigger_LeftTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AreaTrigger_C.__BndEvt__BP_AreaTrigger_LeftTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AreaTrigger_C.__BndEvt__BP_AreaTrigger_LeftTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602095E RID: 133470 RVA: 0x00930FDC File Offset: 0x0092F1DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_AreaTrigger_RightTrigger_K2Node_ComponentBoundEvent_4_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_AreaTrigger_C.__BndEvt__BP_AreaTrigger_RightTrigger_K2Node_ComponentBoundEvent_4_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_AreaTrigger_C.__BndEvt__BP_AreaTrigger_RightTrigger_K2Node_ComponentBoundEvent_4_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_AreaTrigger_C.__BndEvt__BP_AreaTrigger_RightTrigger_K2Node_ComponentBoundEvent_4_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AreaTrigger_C.__BndEvt__BP_AreaTrigger_RightTrigger_K2Node_ComponentBoundEvent_4_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AreaTrigger_C.__BndEvt__BP_AreaTrigger_RightTrigger_K2Node_ComponentBoundEvent_4_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602095F RID: 133471 RVA: 0x00931098 File Offset: 0x0092F298
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_AreaTrigger(int EntryPoint)
		{
			BP_AreaTrigger_C.__ExecuteUbergraph_BP_AreaTrigger_FunctionParams* ptr = stackalloc BP_AreaTrigger_C.__ExecuteUbergraph_BP_AreaTrigger_FunctionParams[(UIntPtr)479] + 15L / (long)sizeof(BP_AreaTrigger_C.__ExecuteUbergraph_BP_AreaTrigger_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AreaTrigger_C.__ExecuteUbergraph_BP_AreaTrigger_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AreaTrigger_C.__ExecuteUbergraph_BP_AreaTrigger_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020960 RID: 133472 RVA: 0x009310E2 File Offset: 0x0092F2E2
		protected BP_AreaTrigger_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040104D9 RID: 66777
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/AreaLightManager/BP_AreaTrigger.BP_AreaTrigger_C";

		// Token: 0x040104DA RID: 66778
		private static IntPtr _ClassPtr;

		// Token: 0x040104DB RID: 66779
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040104DC RID: 66780
		internal static int __PropertyOffset_0;

		// Token: 0x040104DD RID: 66781
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040104DE RID: 66782
		internal static int __PropertyOffset_1;

		// Token: 0x040104DF RID: 66783
		internal static int __PropertyOffset_2;

		// Token: 0x040104E0 RID: 66784
		internal static int __PropertyOffset_3;

		// Token: 0x040104E1 RID: 66785
		internal static int __PropertyOffset_4;

		// Token: 0x040104E2 RID: 66786
		internal static int __PropertyOffset_5;

		// Token: 0x040104E3 RID: 66787
		internal static int __PropertyOffset_6;

		// Token: 0x040104E4 RID: 66788
		internal static int __PropertyOffset_7;

		// Token: 0x040104E5 RID: 66789
		internal static int __PropertyOffset_8;

		// Token: 0x040104E6 RID: 66790
		internal static int __PropertyOffset_9;

		// Token: 0x040104E7 RID: 66791
		internal static int __PropertyOffset_10;

		// Token: 0x040104E8 RID: 66792
		internal static int __PropertyOffset_11;

		// Token: 0x040104E9 RID: 66793
		internal static int __PropertyOffset_12;

		// Token: 0x040104EA RID: 66794
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040104EB RID: 66795
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040104EC RID: 66796
		private static IntPtr __BndEvt__BP_Test_FrontBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040104ED RID: 66797
		private static IntPtr __BndEvt__BP_Test_BackBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040104EE RID: 66798
		private static IntPtr __BndEvt__BP_AreaTrigger_LeftTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040104EF RID: 66799
		private static IntPtr __BndEvt__BP_AreaTrigger_RightTrigger_K2Node_ComponentBoundEvent_4_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040104F0 RID: 66800
		private static IntPtr __ExecuteUbergraph_BP_AreaTrigger_NativeFunctionPtr;

		// Token: 0x020099EA RID: 39402
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_Test_FrontBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040320B5 RID: 204981
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040320B6 RID: 204982
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040320B7 RID: 204983
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040320B8 RID: 204984
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x020099EB RID: 39403
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_Test_BackBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040320B9 RID: 204985
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040320BA RID: 204986
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040320BB RID: 204987
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040320BC RID: 204988
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x020099EC RID: 39404
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_AreaTrigger_LeftTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040320BD RID: 204989
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040320BE RID: 204990
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040320BF RID: 204991
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040320C0 RID: 204992
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040320C1 RID: 204993
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040320C2 RID: 204994
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x020099ED RID: 39405
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_AreaTrigger_RightTrigger_K2Node_ComponentBoundEvent_4_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040320C3 RID: 204995
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040320C4 RID: 204996
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040320C5 RID: 204997
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040320C6 RID: 204998
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040320C7 RID: 204999
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040320C8 RID: 205000
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x020099EE RID: 39406
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 464)]
		protected ref struct __ExecuteUbergraph_BP_AreaTrigger_FunctionParams
		{
			// Token: 0x040320C9 RID: 205001
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
