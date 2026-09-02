using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.BubbleInteraction
{
	// Token: 0x02003D9A RID: 15770
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/BubbleInteraction/BP_InteractBubbleSM.BP_InteractBubbleSM_C")]
	[UnrealStructLayout(1112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1112)]
	public class BP_InteractBubbleSM_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060268B5 RID: 157877 RVA: 0x009DB500 File Offset: 0x009D9700
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InteractBubbleSM_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/BubbleInteraction/BP_InteractBubbleSM.BP_InteractBubbleSM_C");
			}
			return BP_InteractBubbleSM_C._ClassPtr;
		}

		// Token: 0x060268B6 RID: 157878 RVA: 0x009DB524 File Offset: 0x009D9724
		public BP_InteractBubbleSM_C() : this(BuiltinUtils.AllocNativeUObject(BP_InteractBubbleSM_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060268B7 RID: 157879 RVA: 0x009DB54C File Offset: 0x009D974C
		[NullableContext(1)]
		public BP_InteractBubbleSM_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InteractBubbleSM_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170057E5 RID: 22501
		// (get) Token: 0x060268B8 RID: 157880 RVA: 0x009DB580 File Offset: 0x009D9780
		// (set) Token: 0x060268B9 RID: 157881 RVA: 0x009DB5B9 File Offset: 0x009D97B9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170057E6 RID: 22502
		// (get) Token: 0x060268BA RID: 157882 RVA: 0x009DB5DA File Offset: 0x009D97DA
		// (set) Token: 0x060268BB RID: 157883 RVA: 0x009DB5EE File Offset: 0x009D97EE
		public unsafe UStaticMeshComponent SM_Old_Lig_09AM_Collision
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBubbleSM_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBubbleSM_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170057E7 RID: 22503
		// (get) Token: 0x060268BC RID: 157884 RVA: 0x009DB603 File Offset: 0x009D9803
		// (set) Token: 0x060268BD RID: 157885 RVA: 0x009DB617 File Offset: 0x009D9817
		public unsafe UNiagaraComponent NS_BubbleExplosion
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBubbleSM_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBubbleSM_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170057E8 RID: 22504
		// (get) Token: 0x060268BE RID: 157886 RVA: 0x009DB62C File Offset: 0x009D982C
		// (set) Token: 0x060268BF RID: 157887 RVA: 0x009DB640 File Offset: 0x009D9840
		public unsafe UStaticMeshComponent SM_Old_Lig_09AM_T
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBubbleSM_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBubbleSM_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170057E9 RID: 22505
		// (get) Token: 0x060268C0 RID: 157888 RVA: 0x009DB655 File Offset: 0x009D9855
		// (set) Token: 0x060268C1 RID: 157889 RVA: 0x009DB669 File Offset: 0x009D9869
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBubbleSM_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBubbleSM_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170057EA RID: 22506
		// (get) Token: 0x060268C2 RID: 157890 RVA: 0x009DB67E File Offset: 0x009D987E
		// (set) Token: 0x060268C3 RID: 157891 RVA: 0x009DB68E File Offset: 0x009D988E
		public unsafe float TestRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170057EB RID: 22507
		// (get) Token: 0x060268C4 RID: 157892 RVA: 0x009DB69F File Offset: 0x009D989F
		// (set) Token: 0x060268C5 RID: 157893 RVA: 0x009DB6AF File Offset: 0x009D98AF
		public unsafe bool bShouldUpdateRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170057EC RID: 22508
		// (get) Token: 0x060268C6 RID: 157894 RVA: 0x009DB6C0 File Offset: 0x009D98C0
		// (set) Token: 0x060268C7 RID: 157895 RVA: 0x009DB6D0 File Offset: 0x009D98D0
		public unsafe float InterpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170057ED RID: 22509
		// (get) Token: 0x060268C8 RID: 157896 RVA: 0x009DB6E1 File Offset: 0x009D98E1
		// (set) Token: 0x060268C9 RID: 157897 RVA: 0x009DB6F5 File Offset: 0x009D98F5
		public unsafe FVector SphereCenterVector
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170057EE RID: 22510
		// (get) Token: 0x060268CA RID: 157898 RVA: 0x009DB70A File Offset: 0x009D990A
		// (set) Token: 0x060268CB RID: 157899 RVA: 0x009DB71A File Offset: 0x009D991A
		public unsafe float InterpRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170057EF RID: 22511
		// (get) Token: 0x060268CC RID: 157900 RVA: 0x009DB72B File Offset: 0x009D992B
		// (set) Token: 0x060268CD RID: 157901 RVA: 0x009DB73B File Offset: 0x009D993B
		public unsafe bool DebugMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBubbleSM_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170057F0 RID: 22512
		// (get) Token: 0x060268CE RID: 157902 RVA: 0x009DB74C File Offset: 0x009D994C
		// (set) Token: 0x060268CF RID: 157903 RVA: 0x009DB760 File Offset: 0x009D9960
		public unsafe UMaterialInstanceDynamic Bubble_DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBubbleSM_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBubbleSM_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x060268D0 RID: 157904 RVA: 0x009DB775 File Offset: 0x009D9975
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdataSDF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBubbleSM_C.__UpdataSDF_NativeFunctionPtr, null);
		}

		// Token: 0x060268D1 RID: 157905 RVA: 0x009DB78C File Offset: 0x009D998C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_7248FFF24C6ED5791FB19C83C313381A(int PlayingID)
		{
			BP_InteractBubbleSM_C.__Completed_7248FFF24C6ED5791FB19C83C313381A_FunctionParams* ptr = stackalloc BP_InteractBubbleSM_C.__Completed_7248FFF24C6ED5791FB19C83C313381A_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractBubbleSM_C.__Completed_7248FFF24C6ED5791FB19C83C313381A_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBubbleSM_C.__Completed_7248FFF24C6ED5791FB19C83C313381A_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBubbleSM_C.__Completed_7248FFF24C6ED5791FB19C83C313381A_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060268D2 RID: 157906 RVA: 0x009DB7D2 File Offset: 0x009D99D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBubbleSM_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060268D3 RID: 157907 RVA: 0x009DB7E6 File Offset: 0x009D99E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractBubbleSM_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060268D4 RID: 157908 RVA: 0x009DB7FC File Offset: 0x009D99FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_InteractBubbleSM_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteractBubbleSM_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractBubbleSM_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBubbleSM_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBubbleSM_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060268D5 RID: 157909 RVA: 0x009DB844 File Offset: 0x009D9A44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_InteractBubbleSM_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteractBubbleSM_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractBubbleSM_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBubbleSM_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractBubbleSM_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060268D6 RID: 157910 RVA: 0x009DB88C File Offset: 0x009D9A8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_BubbleHit_SM_Old_Lig_09AM_T_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_InteractBubbleSM_C.__BndEvt__BP_BubbleHit_SM_Old_Lig_09AM_T_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_InteractBubbleSM_C.__BndEvt__BP_BubbleHit_SM_Old_Lig_09AM_T_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_InteractBubbleSM_C.__BndEvt__BP_BubbleHit_SM_Old_Lig_09AM_T_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBubbleSM_C.__BndEvt__BP_BubbleHit_SM_Old_Lig_09AM_T_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBubbleSM_C.__BndEvt__BP_BubbleHit_SM_Old_Lig_09AM_T_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060268D7 RID: 157911 RVA: 0x009DB948 File Offset: 0x009D9B48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_InteractBubbleSM_C.__BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_InteractBubbleSM_C.__BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_InteractBubbleSM_C.__BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBubbleSM_C.__BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBubbleSM_C.__BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060268D8 RID: 157912 RVA: 0x009DBA04 File Offset: 0x009D9C04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_InteractBubbleSM(int EntryPoint)
		{
			BP_InteractBubbleSM_C.__ExecuteUbergraph_BP_InteractBubbleSM_FunctionParams* ptr = stackalloc BP_InteractBubbleSM_C.__ExecuteUbergraph_BP_InteractBubbleSM_FunctionParams[(UIntPtr)687] + 15L / (long)sizeof(BP_InteractBubbleSM_C.__ExecuteUbergraph_BP_InteractBubbleSM_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBubbleSM_C.__ExecuteUbergraph_BP_InteractBubbleSM_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractBubbleSM_C.__ExecuteUbergraph_BP_InteractBubbleSM_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060268D9 RID: 157913 RVA: 0x009DBA4E File Offset: 0x009D9C4E
		protected BP_InteractBubbleSM_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040140B0 RID: 82096
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/BubbleInteraction/BP_InteractBubbleSM.BP_InteractBubbleSM_C";

		// Token: 0x040140B1 RID: 82097
		private static IntPtr _ClassPtr;

		// Token: 0x040140B2 RID: 82098
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040140B3 RID: 82099
		internal static int __PropertyOffset_0;

		// Token: 0x040140B4 RID: 82100
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040140B5 RID: 82101
		internal static int __PropertyOffset_1;

		// Token: 0x040140B6 RID: 82102
		internal static int __PropertyOffset_2;

		// Token: 0x040140B7 RID: 82103
		internal static int __PropertyOffset_3;

		// Token: 0x040140B8 RID: 82104
		internal static int __PropertyOffset_4;

		// Token: 0x040140B9 RID: 82105
		internal static int __PropertyOffset_5;

		// Token: 0x040140BA RID: 82106
		internal static int __PropertyOffset_6;

		// Token: 0x040140BB RID: 82107
		internal static int __PropertyOffset_7;

		// Token: 0x040140BC RID: 82108
		internal static int __PropertyOffset_8;

		// Token: 0x040140BD RID: 82109
		internal static int __PropertyOffset_9;

		// Token: 0x040140BE RID: 82110
		internal static int __PropertyOffset_10;

		// Token: 0x040140BF RID: 82111
		internal static int __PropertyOffset_11;

		// Token: 0x040140C0 RID: 82112
		private static IntPtr __UpdataSDF_NativeFunctionPtr;

		// Token: 0x040140C1 RID: 82113
		private static IntPtr __Completed_7248FFF24C6ED5791FB19C83C313381A_NativeFunctionPtr;

		// Token: 0x040140C2 RID: 82114
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040140C3 RID: 82115
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040140C4 RID: 82116
		private static IntPtr __BndEvt__BP_BubbleHit_SM_Old_Lig_09AM_T_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040140C5 RID: 82117
		private static IntPtr __BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040140C6 RID: 82118
		private static IntPtr __ExecuteUbergraph_BP_InteractBubbleSM_NativeFunctionPtr;

		// Token: 0x0200A085 RID: 41093
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_7248FFF24C6ED5791FB19C83C313381A_FunctionParams
		{
			// Token: 0x04032D11 RID: 208145
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x0200A086 RID: 41094
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D12 RID: 208146
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A087 RID: 41095
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_BubbleHit_SM_Old_Lig_09AM_T_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032D13 RID: 208147
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032D14 RID: 208148
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032D15 RID: 208149
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032D16 RID: 208150
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032D17 RID: 208151
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032D18 RID: 208152
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x0200A088 RID: 41096
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032D19 RID: 208153
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032D1A RID: 208154
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032D1B RID: 208155
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032D1C RID: 208156
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032D1D RID: 208157
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032D1E RID: 208158
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x0200A089 RID: 41097
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 672)]
		protected ref struct __ExecuteUbergraph_BP_InteractBubbleSM_FunctionParams
		{
			// Token: 0x04032D1F RID: 208159
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
