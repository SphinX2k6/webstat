using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_Cymbal1
{
	// Token: 0x02003BB8 RID: 15288
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PBD_Cymbal1/BP_PBD_Cymbal1.BP_PBD_Cymbal1_C")]
	[UnrealStructLayout(1360, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1356)]
	public class BP_PBD_Cymbal1_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060223EF RID: 140271 RVA: 0x0095FCBF File Offset: 0x0095DEBF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PBD_Cymbal1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PBD_Cymbal1/BP_PBD_Cymbal1.BP_PBD_Cymbal1_C");
			}
			return BP_PBD_Cymbal1_C._ClassPtr;
		}

		// Token: 0x060223F0 RID: 140272 RVA: 0x0095FCE4 File Offset: 0x0095DEE4
		public BP_PBD_Cymbal1_C() : this(BuiltinUtils.AllocNativeUObject(BP_PBD_Cymbal1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060223F1 RID: 140273 RVA: 0x0095FD0C File Offset: 0x0095DF0C
		[NullableContext(1)]
		public BP_PBD_Cymbal1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PBD_Cymbal1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003FD8 RID: 16344
		// (get) Token: 0x060223F2 RID: 140274 RVA: 0x0095FD40 File Offset: 0x0095DF40
		// (set) Token: 0x060223F3 RID: 140275 RVA: 0x0095FD79 File Offset: 0x0095DF79
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PBD_Cymbal1_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PBD_Cymbal1_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003FD9 RID: 16345
		// (get) Token: 0x060223F4 RID: 140276 RVA: 0x0095FD9A File Offset: 0x0095DF9A
		// (set) Token: 0x060223F5 RID: 140277 RVA: 0x0095FDAE File Offset: 0x0095DFAE
		public unsafe UStaticMeshComponent Base
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PBD_Cymbal1_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PBD_Cymbal1_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003FDA RID: 16346
		// (get) Token: 0x060223F6 RID: 140278 RVA: 0x0095FDC3 File Offset: 0x0095DFC3
		// (set) Token: 0x060223F7 RID: 140279 RVA: 0x0095FDD7 File Offset: 0x0095DFD7
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PBD_Cymbal1_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PBD_Cymbal1_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003FDB RID: 16347
		// (get) Token: 0x060223F8 RID: 140280 RVA: 0x0095FDEC File Offset: 0x0095DFEC
		// (set) Token: 0x060223F9 RID: 140281 RVA: 0x0095FDFC File Offset: 0x0095DFFC
		public unsafe float PlayerImpulse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PBD_Cymbal1_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PBD_Cymbal1_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003FDC RID: 16348
		// (get) Token: 0x060223FA RID: 140282 RVA: 0x0095FE0D File Offset: 0x0095E00D
		// (set) Token: 0x060223FB RID: 140283 RVA: 0x0095FE21 File Offset: 0x0095E021
		public unsafe FRotator Delta_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PBD_Cymbal1_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PBD_Cymbal1_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003FDD RID: 16349
		// (get) Token: 0x060223FC RID: 140284 RVA: 0x0095FE36 File Offset: 0x0095E036
		// (set) Token: 0x060223FD RID: 140285 RVA: 0x0095FE46 File Offset: 0x0095E046
		public unsafe float X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PBD_Cymbal1_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PBD_Cymbal1_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003FDE RID: 16350
		// (get) Token: 0x060223FE RID: 140286 RVA: 0x0095FE57 File Offset: 0x0095E057
		// (set) Token: 0x060223FF RID: 140287 RVA: 0x0095FE67 File Offset: 0x0095E067
		public unsafe float Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PBD_Cymbal1_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PBD_Cymbal1_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003FDF RID: 16351
		// (get) Token: 0x06022400 RID: 140288 RVA: 0x0095FE78 File Offset: 0x0095E078
		// (set) Token: 0x06022401 RID: 140289 RVA: 0x0095FE88 File Offset: 0x0095E088
		public unsafe float LerpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PBD_Cymbal1_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PBD_Cymbal1_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x06022402 RID: 140290 RVA: 0x0095FE9C File Offset: 0x0095E09C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PBD_Cymbal1_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PBD_Cymbal1_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PBD_Cymbal1_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PBD_Cymbal1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PBD_Cymbal1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022403 RID: 140291 RVA: 0x0095FEE4 File Offset: 0x0095E0E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PBD_Cymbal1_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PBD_Cymbal1_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PBD_Cymbal1_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PBD_Cymbal1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PBD_Cymbal1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022404 RID: 140292 RVA: 0x0095FF2C File Offset: 0x0095E12C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PBD_Cymbal1(int EntryPoint)
		{
			BP_PBD_Cymbal1_C.__ExecuteUbergraph_BP_PBD_Cymbal1_FunctionParams* ptr = stackalloc BP_PBD_Cymbal1_C.__ExecuteUbergraph_BP_PBD_Cymbal1_FunctionParams[(UIntPtr)687] + 15L / (long)sizeof(BP_PBD_Cymbal1_C.__ExecuteUbergraph_BP_PBD_Cymbal1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PBD_Cymbal1_C.__ExecuteUbergraph_BP_PBD_Cymbal1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PBD_Cymbal1_C.__ExecuteUbergraph_BP_PBD_Cymbal1_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022405 RID: 140293 RVA: 0x0095FF76 File Offset: 0x0095E176
		protected BP_PBD_Cymbal1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011507 RID: 70919
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PBD_Cymbal1/BP_PBD_Cymbal1.BP_PBD_Cymbal1_C";

		// Token: 0x04011508 RID: 70920
		private static IntPtr _ClassPtr;

		// Token: 0x04011509 RID: 70921
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401150A RID: 70922
		internal static int __PropertyOffset_0;

		// Token: 0x0401150B RID: 70923
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401150C RID: 70924
		internal static int __PropertyOffset_1;

		// Token: 0x0401150D RID: 70925
		internal static int __PropertyOffset_2;

		// Token: 0x0401150E RID: 70926
		internal static int __PropertyOffset_3;

		// Token: 0x0401150F RID: 70927
		internal static int __PropertyOffset_4;

		// Token: 0x04011510 RID: 70928
		internal static int __PropertyOffset_5;

		// Token: 0x04011511 RID: 70929
		internal static int __PropertyOffset_6;

		// Token: 0x04011512 RID: 70930
		internal static int __PropertyOffset_7;

		// Token: 0x04011513 RID: 70931
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011514 RID: 70932
		private static IntPtr __ExecuteUbergraph_BP_PBD_Cymbal1_NativeFunctionPtr;

		// Token: 0x02009BAB RID: 39851
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040323DE RID: 205790
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BAC RID: 39852
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 672)]
		protected ref struct __ExecuteUbergraph_BP_PBD_Cymbal1_FunctionParams
		{
			// Token: 0x040323DF RID: 205791
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
