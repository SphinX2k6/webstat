using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.BubbleInteraction
{
	// Token: 0x02003D9B RID: 15771
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/BubbleInteraction/BP_LSFix_InteractBubbleSM.BP_LSFix_InteractBubbleSM_C")]
	[UnrealStructLayout(1112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1112)]
	public class BP_LSFix_InteractBubbleSM_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060268DA RID: 157914 RVA: 0x009DBA57 File Offset: 0x009D9C57
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LSFix_InteractBubbleSM_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/BubbleInteraction/BP_LSFix_InteractBubbleSM.BP_LSFix_InteractBubbleSM_C");
			}
			return BP_LSFix_InteractBubbleSM_C._ClassPtr;
		}

		// Token: 0x060268DB RID: 157915 RVA: 0x009DBA7C File Offset: 0x009D9C7C
		public BP_LSFix_InteractBubbleSM_C() : this(BuiltinUtils.AllocNativeUObject(BP_LSFix_InteractBubbleSM_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060268DC RID: 157916 RVA: 0x009DBAA4 File Offset: 0x009D9CA4
		[NullableContext(1)]
		public BP_LSFix_InteractBubbleSM_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LSFix_InteractBubbleSM_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170057F1 RID: 22513
		// (get) Token: 0x060268DD RID: 157917 RVA: 0x009DBAD8 File Offset: 0x009D9CD8
		// (set) Token: 0x060268DE RID: 157918 RVA: 0x009DBB11 File Offset: 0x009D9D11
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170057F2 RID: 22514
		// (get) Token: 0x060268DF RID: 157919 RVA: 0x009DBB32 File Offset: 0x009D9D32
		// (set) Token: 0x060268E0 RID: 157920 RVA: 0x009DBB46 File Offset: 0x009D9D46
		public unsafe UStaticMeshComponent SM_Old_Lig_09AM_Collision
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LSFix_InteractBubbleSM_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LSFix_InteractBubbleSM_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170057F3 RID: 22515
		// (get) Token: 0x060268E1 RID: 157921 RVA: 0x009DBB5B File Offset: 0x009D9D5B
		// (set) Token: 0x060268E2 RID: 157922 RVA: 0x009DBB6F File Offset: 0x009D9D6F
		public unsafe UNiagaraComponent NS_BubbleExplosion
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LSFix_InteractBubbleSM_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LSFix_InteractBubbleSM_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170057F4 RID: 22516
		// (get) Token: 0x060268E3 RID: 157923 RVA: 0x009DBB84 File Offset: 0x009D9D84
		// (set) Token: 0x060268E4 RID: 157924 RVA: 0x009DBB98 File Offset: 0x009D9D98
		public unsafe UStaticMeshComponent SM_Old_Lig_09AM_T
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LSFix_InteractBubbleSM_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LSFix_InteractBubbleSM_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170057F5 RID: 22517
		// (get) Token: 0x060268E5 RID: 157925 RVA: 0x009DBBAD File Offset: 0x009D9DAD
		// (set) Token: 0x060268E6 RID: 157926 RVA: 0x009DBBC1 File Offset: 0x009D9DC1
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LSFix_InteractBubbleSM_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LSFix_InteractBubbleSM_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170057F6 RID: 22518
		// (get) Token: 0x060268E7 RID: 157927 RVA: 0x009DBBD6 File Offset: 0x009D9DD6
		// (set) Token: 0x060268E8 RID: 157928 RVA: 0x009DBBE6 File Offset: 0x009D9DE6
		public unsafe float TestRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170057F7 RID: 22519
		// (get) Token: 0x060268E9 RID: 157929 RVA: 0x009DBBF7 File Offset: 0x009D9DF7
		// (set) Token: 0x060268EA RID: 157930 RVA: 0x009DBC07 File Offset: 0x009D9E07
		public unsafe bool bShouldUpdateRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170057F8 RID: 22520
		// (get) Token: 0x060268EB RID: 157931 RVA: 0x009DBC18 File Offset: 0x009D9E18
		// (set) Token: 0x060268EC RID: 157932 RVA: 0x009DBC28 File Offset: 0x009D9E28
		public unsafe float InterpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170057F9 RID: 22521
		// (get) Token: 0x060268ED RID: 157933 RVA: 0x009DBC39 File Offset: 0x009D9E39
		// (set) Token: 0x060268EE RID: 157934 RVA: 0x009DBC4D File Offset: 0x009D9E4D
		public unsafe FVector SphereCenterVector
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170057FA RID: 22522
		// (get) Token: 0x060268EF RID: 157935 RVA: 0x009DBC62 File Offset: 0x009D9E62
		// (set) Token: 0x060268F0 RID: 157936 RVA: 0x009DBC72 File Offset: 0x009D9E72
		public unsafe float InterpRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170057FB RID: 22523
		// (get) Token: 0x060268F1 RID: 157937 RVA: 0x009DBC83 File Offset: 0x009D9E83
		// (set) Token: 0x060268F2 RID: 157938 RVA: 0x009DBC93 File Offset: 0x009D9E93
		public unsafe bool DebugMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LSFix_InteractBubbleSM_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170057FC RID: 22524
		// (get) Token: 0x060268F3 RID: 157939 RVA: 0x009DBCA4 File Offset: 0x009D9EA4
		// (set) Token: 0x060268F4 RID: 157940 RVA: 0x009DBCB8 File Offset: 0x009D9EB8
		public unsafe UMaterialInstanceDynamic Bubble_DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LSFix_InteractBubbleSM_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LSFix_InteractBubbleSM_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x060268F5 RID: 157941 RVA: 0x009DBCCD File Offset: 0x009D9ECD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdataSDF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LSFix_InteractBubbleSM_C.__UpdataSDF_NativeFunctionPtr, null);
		}

		// Token: 0x060268F6 RID: 157942 RVA: 0x009DBCE4 File Offset: 0x009D9EE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_6B91D0B14409837F432BB3A8D9146B00(int PlayingID)
		{
			BP_LSFix_InteractBubbleSM_C.__Completed_6B91D0B14409837F432BB3A8D9146B00_FunctionParams* ptr = stackalloc BP_LSFix_InteractBubbleSM_C.__Completed_6B91D0B14409837F432BB3A8D9146B00_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LSFix_InteractBubbleSM_C.__Completed_6B91D0B14409837F432BB3A8D9146B00_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LSFix_InteractBubbleSM_C.__Completed_6B91D0B14409837F432BB3A8D9146B00_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LSFix_InteractBubbleSM_C.__Completed_6B91D0B14409837F432BB3A8D9146B00_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060268F7 RID: 157943 RVA: 0x009DBD2A File Offset: 0x009D9F2A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LSFix_InteractBubbleSM_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060268F8 RID: 157944 RVA: 0x009DBD3E File Offset: 0x009D9F3E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LSFix_InteractBubbleSM_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060268F9 RID: 157945 RVA: 0x009DBD54 File Offset: 0x009D9F54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LSFix_InteractBubbleSM_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LSFix_InteractBubbleSM_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LSFix_InteractBubbleSM_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LSFix_InteractBubbleSM_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LSFix_InteractBubbleSM_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060268FA RID: 157946 RVA: 0x009DBD9C File Offset: 0x009D9F9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LSFix_InteractBubbleSM_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LSFix_InteractBubbleSM_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LSFix_InteractBubbleSM_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LSFix_InteractBubbleSM_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LSFix_InteractBubbleSM_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060268FB RID: 157947 RVA: 0x009DBDE4 File Offset: 0x009D9FE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_LSFix_InteractBubbleSM_C.__BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_LSFix_InteractBubbleSM_C.__BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_LSFix_InteractBubbleSM_C.__BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LSFix_InteractBubbleSM_C.__BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LSFix_InteractBubbleSM_C.__BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060268FC RID: 157948 RVA: 0x009DBEA0 File Offset: 0x009DA0A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LSFix_InteractBubbleSM(int EntryPoint)
		{
			BP_LSFix_InteractBubbleSM_C.__ExecuteUbergraph_BP_LSFix_InteractBubbleSM_FunctionParams* ptr = stackalloc BP_LSFix_InteractBubbleSM_C.__ExecuteUbergraph_BP_LSFix_InteractBubbleSM_FunctionParams[(UIntPtr)503] + 15L / (long)sizeof(BP_LSFix_InteractBubbleSM_C.__ExecuteUbergraph_BP_LSFix_InteractBubbleSM_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LSFix_InteractBubbleSM_C.__ExecuteUbergraph_BP_LSFix_InteractBubbleSM_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LSFix_InteractBubbleSM_C.__ExecuteUbergraph_BP_LSFix_InteractBubbleSM_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060268FD RID: 157949 RVA: 0x009DBEEA File Offset: 0x009DA0EA
		protected BP_LSFix_InteractBubbleSM_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040140C7 RID: 82119
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/BubbleInteraction/BP_LSFix_InteractBubbleSM.BP_LSFix_InteractBubbleSM_C";

		// Token: 0x040140C8 RID: 82120
		private static IntPtr _ClassPtr;

		// Token: 0x040140C9 RID: 82121
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040140CA RID: 82122
		internal static int __PropertyOffset_0;

		// Token: 0x040140CB RID: 82123
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040140CC RID: 82124
		internal static int __PropertyOffset_1;

		// Token: 0x040140CD RID: 82125
		internal static int __PropertyOffset_2;

		// Token: 0x040140CE RID: 82126
		internal static int __PropertyOffset_3;

		// Token: 0x040140CF RID: 82127
		internal static int __PropertyOffset_4;

		// Token: 0x040140D0 RID: 82128
		internal static int __PropertyOffset_5;

		// Token: 0x040140D1 RID: 82129
		internal static int __PropertyOffset_6;

		// Token: 0x040140D2 RID: 82130
		internal static int __PropertyOffset_7;

		// Token: 0x040140D3 RID: 82131
		internal static int __PropertyOffset_8;

		// Token: 0x040140D4 RID: 82132
		internal static int __PropertyOffset_9;

		// Token: 0x040140D5 RID: 82133
		internal static int __PropertyOffset_10;

		// Token: 0x040140D6 RID: 82134
		internal static int __PropertyOffset_11;

		// Token: 0x040140D7 RID: 82135
		private static IntPtr __UpdataSDF_NativeFunctionPtr;

		// Token: 0x040140D8 RID: 82136
		private static IntPtr __Completed_6B91D0B14409837F432BB3A8D9146B00_NativeFunctionPtr;

		// Token: 0x040140D9 RID: 82137
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040140DA RID: 82138
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040140DB RID: 82139
		private static IntPtr __BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040140DC RID: 82140
		private static IntPtr __ExecuteUbergraph_BP_LSFix_InteractBubbleSM_NativeFunctionPtr;

		// Token: 0x0200A08A RID: 41098
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_6B91D0B14409837F432BB3A8D9146B00_FunctionParams
		{
			// Token: 0x04032D20 RID: 208160
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x0200A08B RID: 41099
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D21 RID: 208161
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A08C RID: 41100
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_InteractBubbleSM_SM_Old_Lig_09AM_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032D22 RID: 208162
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032D23 RID: 208163
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032D24 RID: 208164
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032D25 RID: 208165
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032D26 RID: 208166
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032D27 RID: 208167
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x0200A08D RID: 41101
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 488)]
		protected ref struct __ExecuteUbergraph_BP_LSFix_InteractBubbleSM_FunctionParams
		{
			// Token: 0x04032D28 RID: 208168
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
