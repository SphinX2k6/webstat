using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Ice
{
	// Token: 0x02003C0D RID: 15373
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Ice/BP_Ice_Floeberg.BP_Ice_Floeberg_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1384)]
	public class BP_Ice_Floeberg_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022EF8 RID: 143096 RVA: 0x009738A3 File Offset: 0x00971AA3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Ice_Floeberg_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Ice/BP_Ice_Floeberg.BP_Ice_Floeberg_C");
			}
			return BP_Ice_Floeberg_C._ClassPtr;
		}

		// Token: 0x06022EF9 RID: 143097 RVA: 0x009738C8 File Offset: 0x00971AC8
		public BP_Ice_Floeberg_C() : this(BuiltinUtils.AllocNativeUObject(BP_Ice_Floeberg_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022EFA RID: 143098 RVA: 0x009738F0 File Offset: 0x00971AF0
		[NullableContext(1)]
		public BP_Ice_Floeberg_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Ice_Floeberg_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700438B RID: 17291
		// (get) Token: 0x06022EFB RID: 143099 RVA: 0x00973924 File Offset: 0x00971B24
		// (set) Token: 0x06022EFC RID: 143100 RVA: 0x0097395D File Offset: 0x00971B5D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700438C RID: 17292
		// (get) Token: 0x06022EFD RID: 143101 RVA: 0x0097397E File Offset: 0x00971B7E
		// (set) Token: 0x06022EFE RID: 143102 RVA: 0x00973992 File Offset: 0x00971B92
		public unsafe UStaticMeshComponent IceMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Ice_Floeberg_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Ice_Floeberg_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700438D RID: 17293
		// (get) Token: 0x06022EFF RID: 143103 RVA: 0x009739A7 File Offset: 0x00971BA7
		// (set) Token: 0x06022F00 RID: 143104 RVA: 0x009739BB File Offset: 0x00971BBB
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Ice_Floeberg_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Ice_Floeberg_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700438E RID: 17294
		// (get) Token: 0x06022F01 RID: 143105 RVA: 0x009739D0 File Offset: 0x00971BD0
		// (set) Token: 0x06022F02 RID: 143106 RVA: 0x009739E0 File Offset: 0x00971BE0
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700438F RID: 17295
		// (get) Token: 0x06022F03 RID: 143107 RVA: 0x009739F1 File Offset: 0x00971BF1
		// (set) Token: 0x06022F04 RID: 143108 RVA: 0x00973A05 File Offset: 0x00971C05
		public unsafe FVectorDouble ActorPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004390 RID: 17296
		// (get) Token: 0x06022F05 RID: 143109 RVA: 0x00973A1A File Offset: 0x00971C1A
		// (set) Token: 0x06022F06 RID: 143110 RVA: 0x00973A2A File Offset: 0x00971C2A
		public unsafe double ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004391 RID: 17297
		// (get) Token: 0x06022F07 RID: 143111 RVA: 0x00973A3B File Offset: 0x00971C3B
		// (set) Token: 0x06022F08 RID: 143112 RVA: 0x00973A4B File Offset: 0x00971C4B
		public unsafe float Height
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004392 RID: 17298
		// (get) Token: 0x06022F09 RID: 143113 RVA: 0x00973A5C File Offset: 0x00971C5C
		// (set) Token: 0x06022F0A RID: 143114 RVA: 0x00973A6C File Offset: 0x00971C6C
		public unsafe float X_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004393 RID: 17299
		// (get) Token: 0x06022F0B RID: 143115 RVA: 0x00973A7D File Offset: 0x00971C7D
		// (set) Token: 0x06022F0C RID: 143116 RVA: 0x00973A8D File Offset: 0x00971C8D
		public unsafe float Y_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004394 RID: 17300
		// (get) Token: 0x06022F0D RID: 143117 RVA: 0x00973A9E File Offset: 0x00971C9E
		// (set) Token: 0x06022F0E RID: 143118 RVA: 0x00973AAE File Offset: 0x00971CAE
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ice_Floeberg_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x06022F0F RID: 143119 RVA: 0x00973AC0 File Offset: 0x00971CC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void WaterWave(float ID, float T, ref float H)
		{
			BP_Ice_Floeberg_C.__WaterWave_FunctionParams* ptr = stackalloc BP_Ice_Floeberg_C.__WaterWave_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_Ice_Floeberg_C.__WaterWave_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Ice_Floeberg_C.__WaterWave_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ID = ID;
			ptr->T = T;
			ptr->H = H;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Ice_Floeberg_C.__WaterWave_NativeFunctionPtr, (void*)ptr);
			H = ptr->H;
		}

		// Token: 0x06022F10 RID: 143120 RVA: 0x00973B1D File Offset: 0x00971D1D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Ice_Floeberg_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022F11 RID: 143121 RVA: 0x00973B31 File Offset: 0x00971D31
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Ice_Floeberg_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022F12 RID: 143122 RVA: 0x00973B48 File Offset: 0x00971D48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Ice_Floeberg_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Ice_Floeberg_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Ice_Floeberg_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Ice_Floeberg_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Ice_Floeberg_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022F13 RID: 143123 RVA: 0x00973B90 File Offset: 0x00971D90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Ice_Floeberg_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Ice_Floeberg_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Ice_Floeberg_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Ice_Floeberg_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Ice_Floeberg_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022F14 RID: 143124 RVA: 0x00973BD8 File Offset: 0x00971DD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Ice_Floeberg(int EntryPoint)
		{
			BP_Ice_Floeberg_C.__ExecuteUbergraph_BP_Ice_Floeberg_FunctionParams* ptr = stackalloc BP_Ice_Floeberg_C.__ExecuteUbergraph_BP_Ice_Floeberg_FunctionParams[(UIntPtr)295] + 15L / (long)sizeof(BP_Ice_Floeberg_C.__ExecuteUbergraph_BP_Ice_Floeberg_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Ice_Floeberg_C.__ExecuteUbergraph_BP_Ice_Floeberg_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Ice_Floeberg_C.__ExecuteUbergraph_BP_Ice_Floeberg_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022F15 RID: 143125 RVA: 0x00973C22 File Offset: 0x00971E22
		protected BP_Ice_Floeberg_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011BE4 RID: 72676
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Ice/BP_Ice_Floeberg.BP_Ice_Floeberg_C";

		// Token: 0x04011BE5 RID: 72677
		private static IntPtr _ClassPtr;

		// Token: 0x04011BE6 RID: 72678
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011BE7 RID: 72679
		internal static int __PropertyOffset_0;

		// Token: 0x04011BE8 RID: 72680
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011BE9 RID: 72681
		internal static int __PropertyOffset_1;

		// Token: 0x04011BEA RID: 72682
		internal static int __PropertyOffset_2;

		// Token: 0x04011BEB RID: 72683
		internal static int __PropertyOffset_3;

		// Token: 0x04011BEC RID: 72684
		internal static int __PropertyOffset_4;

		// Token: 0x04011BED RID: 72685
		internal static int __PropertyOffset_5;

		// Token: 0x04011BEE RID: 72686
		internal static int __PropertyOffset_6;

		// Token: 0x04011BEF RID: 72687
		internal static int __PropertyOffset_7;

		// Token: 0x04011BF0 RID: 72688
		internal static int __PropertyOffset_8;

		// Token: 0x04011BF1 RID: 72689
		internal static int __PropertyOffset_9;

		// Token: 0x04011BF2 RID: 72690
		private static IntPtr __WaterWave_NativeFunctionPtr;

		// Token: 0x04011BF3 RID: 72691
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011BF4 RID: 72692
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011BF5 RID: 72693
		private static IntPtr __ExecuteUbergraph_BP_Ice_Floeberg_NativeFunctionPtr;

		// Token: 0x02009C55 RID: 40021
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __WaterWave_FunctionParams
		{
			// Token: 0x04032514 RID: 206100
			[FieldOffset(0)]
			public float ID;

			// Token: 0x04032515 RID: 206101
			[FieldOffset(4)]
			public float T;

			// Token: 0x04032516 RID: 206102
			[FieldOffset(8)]
			public float H;
		}

		// Token: 0x02009C56 RID: 40022
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032517 RID: 206103
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C57 RID: 40023
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 280)]
		protected ref struct __ExecuteUbergraph_BP_Ice_Floeberg_FunctionParams
		{
			// Token: 0x04032518 RID: 206104
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
