using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x02004376 RID: 17270
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Audio/BP_AudioEventTrigger.BP_AudioEventTrigger_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1081)]
	public class BP_AudioEventTrigger_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DBB8 RID: 187320 RVA: 0x00ACA68C File Offset: 0x00AC888C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AudioEventTrigger_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Audio/BP_AudioEventTrigger.BP_AudioEventTrigger_C");
			}
			return BP_AudioEventTrigger_C._ClassPtr;
		}

		// Token: 0x0602DBB9 RID: 187321 RVA: 0x00ACA6B0 File Offset: 0x00AC88B0
		public BP_AudioEventTrigger_C() : this(BuiltinUtils.AllocNativeUObject(BP_AudioEventTrigger_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DBBA RID: 187322 RVA: 0x00ACA6D8 File Offset: 0x00AC88D8
		[NullableContext(1)]
		public BP_AudioEventTrigger_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AudioEventTrigger_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D29 RID: 32041
		// (get) Token: 0x0602DBBB RID: 187323 RVA: 0x00ACA70C File Offset: 0x00AC890C
		// (set) Token: 0x0602DBBC RID: 187324 RVA: 0x00ACA745 File Offset: 0x00AC8945
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_AudioEventTrigger_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_AudioEventTrigger_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007D2A RID: 32042
		// (get) Token: 0x0602DBBD RID: 187325 RVA: 0x00ACA766 File Offset: 0x00AC8966
		// (set) Token: 0x0602DBBE RID: 187326 RVA: 0x00ACA77A File Offset: 0x00AC897A
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioEventTrigger_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioEventTrigger_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007D2B RID: 32043
		// (get) Token: 0x0602DBBF RID: 187327 RVA: 0x00ACA78F File Offset: 0x00AC898F
		// (set) Token: 0x0602DBC0 RID: 187328 RVA: 0x00ACA7A3 File Offset: 0x00AC89A3
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioEventTrigger_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioEventTrigger_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007D2C RID: 32044
		// (get) Token: 0x0602DBC1 RID: 187329 RVA: 0x00ACA7B8 File Offset: 0x00AC89B8
		// (set) Token: 0x0602DBC2 RID: 187330 RVA: 0x00ACA7CC File Offset: 0x00AC89CC
		public unsafe ATriggerVolume TriggerVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ATriggerVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioEventTrigger_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioEventTrigger_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007D2D RID: 32045
		// (get) Token: 0x0602DBC3 RID: 187331 RVA: 0x00ACA7E1 File Offset: 0x00AC89E1
		// (set) Token: 0x0602DBC4 RID: 187332 RVA: 0x00ACA7F5 File Offset: 0x00AC89F5
		public unsafe UAkAudioEvent AudioEvent_In
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioEventTrigger_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioEventTrigger_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17007D2E RID: 32046
		// (get) Token: 0x0602DBC5 RID: 187333 RVA: 0x00ACA80A File Offset: 0x00AC8A0A
		// (set) Token: 0x0602DBC6 RID: 187334 RVA: 0x00ACA81E File Offset: 0x00AC8A1E
		public unsafe UAkAudioEvent AudioEvent_Out
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioEventTrigger_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioEventTrigger_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17007D2F RID: 32047
		// (get) Token: 0x0602DBC7 RID: 187335 RVA: 0x00ACA833 File Offset: 0x00AC8A33
		// (set) Token: 0x0602DBC8 RID: 187336 RVA: 0x00ACA843 File Offset: 0x00AC8A43
		public unsafe bool IsOverlapping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioEventTrigger_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioEventTrigger_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602DBC9 RID: 187337 RVA: 0x00ACA854 File Offset: 0x00AC8A54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioEventTrigger_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602DBCA RID: 187338 RVA: 0x00ACA868 File Offset: 0x00AC8A68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AudioEventTrigger_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DBCB RID: 187339 RVA: 0x00ACA880 File Offset: 0x00AC8A80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_AudioEventTrigger_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AudioEventTrigger_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AudioEventTrigger_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioEventTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioEventTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DBCC RID: 187340 RVA: 0x00ACA8C8 File Offset: 0x00AC8AC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_AudioEventTrigger_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AudioEventTrigger_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AudioEventTrigger_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioEventTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AudioEventTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DBCD RID: 187341 RVA: 0x00ACA910 File Offset: 0x00AC8B10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_AudioEventTrigger(int EntryPoint)
		{
			BP_AudioEventTrigger_C.__ExecuteUbergraph_BP_AudioEventTrigger_FunctionParams* ptr = stackalloc BP_AudioEventTrigger_C.__ExecuteUbergraph_BP_AudioEventTrigger_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_AudioEventTrigger_C.__ExecuteUbergraph_BP_AudioEventTrigger_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioEventTrigger_C.__ExecuteUbergraph_BP_AudioEventTrigger_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AudioEventTrigger_C.__ExecuteUbergraph_BP_AudioEventTrigger_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DBCE RID: 187342 RVA: 0x00ACA95A File Offset: 0x00AC8B5A
		protected BP_AudioEventTrigger_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019CE9 RID: 105705
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Audio/BP_AudioEventTrigger.BP_AudioEventTrigger_C";

		// Token: 0x04019CEA RID: 105706
		private static IntPtr _ClassPtr;

		// Token: 0x04019CEB RID: 105707
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019CEC RID: 105708
		internal static int __PropertyOffset_0;

		// Token: 0x04019CED RID: 105709
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019CEE RID: 105710
		internal static int __PropertyOffset_1;

		// Token: 0x04019CEF RID: 105711
		internal static int __PropertyOffset_2;

		// Token: 0x04019CF0 RID: 105712
		internal static int __PropertyOffset_3;

		// Token: 0x04019CF1 RID: 105713
		internal static int __PropertyOffset_4;

		// Token: 0x04019CF2 RID: 105714
		internal static int __PropertyOffset_5;

		// Token: 0x04019CF3 RID: 105715
		internal static int __PropertyOffset_6;

		// Token: 0x04019CF4 RID: 105716
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04019CF5 RID: 105717
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04019CF6 RID: 105718
		private static IntPtr __ExecuteUbergraph_BP_AudioEventTrigger_NativeFunctionPtr;

		// Token: 0x0200A592 RID: 42386
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040334E5 RID: 210149
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A593 RID: 42387
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __ExecuteUbergraph_BP_AudioEventTrigger_FunctionParams
		{
			// Token: 0x040334E6 RID: 210150
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
