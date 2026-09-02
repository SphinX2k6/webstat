using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Rain2
{
	// Token: 0x02003B3C RID: 15164
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/BP_Spline_Water.BP_Spline_Water_C")]
	[UnrealStructLayout(1104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1104)]
	public class BP_Spline_Water_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020D11 RID: 134417 RVA: 0x00937A17 File Offset: 0x00935C17
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Spline_Water_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Rain2/BP_Spline_Water.BP_Spline_Water_C");
			}
			return BP_Spline_Water_C._ClassPtr;
		}

		// Token: 0x06020D12 RID: 134418 RVA: 0x00937A3C File Offset: 0x00935C3C
		public BP_Spline_Water_C() : this(BuiltinUtils.AllocNativeUObject(BP_Spline_Water_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020D13 RID: 134419 RVA: 0x00937A64 File Offset: 0x00935C64
		[NullableContext(1)]
		public BP_Spline_Water_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Spline_Water_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003770 RID: 14192
		// (get) Token: 0x06020D14 RID: 134420 RVA: 0x00937A98 File Offset: 0x00935C98
		// (set) Token: 0x06020D15 RID: 134421 RVA: 0x00937AD1 File Offset: 0x00935CD1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003771 RID: 14193
		// (get) Token: 0x06020D16 RID: 134422 RVA: 0x00937AF2 File Offset: 0x00935CF2
		// (set) Token: 0x06020D17 RID: 134423 RVA: 0x00937B06 File Offset: 0x00935D06
		public unsafe UNiagaraComponent Spline_Particle
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Spline_Water_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Spline_Water_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003772 RID: 14194
		// (get) Token: 0x06020D18 RID: 134424 RVA: 0x00937B1B File Offset: 0x00935D1B
		// (set) Token: 0x06020D19 RID: 134425 RVA: 0x00937B2F File Offset: 0x00935D2F
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Spline_Water_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Spline_Water_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003773 RID: 14195
		// (get) Token: 0x06020D1A RID: 134426 RVA: 0x00937B44 File Offset: 0x00935D44
		// (set) Token: 0x06020D1B RID: 134427 RVA: 0x00937B58 File Offset: 0x00935D58
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Spline_Water_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Spline_Water_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003774 RID: 14196
		// (get) Token: 0x06020D1C RID: 134428 RVA: 0x00937B6D File Offset: 0x00935D6D
		// (set) Token: 0x06020D1D RID: 134429 RVA: 0x00937B81 File Offset: 0x00935D81
		public unsafe UMaterialInterface RainSplineMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Spline_Water_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Spline_Water_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003775 RID: 14197
		// (get) Token: 0x06020D1E RID: 134430 RVA: 0x00937B96 File Offset: 0x00935D96
		// (set) Token: 0x06020D1F RID: 134431 RVA: 0x00937BA6 File Offset: 0x00935DA6
		public unsafe int Spawn_Count
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003776 RID: 14198
		// (get) Token: 0x06020D20 RID: 134432 RVA: 0x00937BB7 File Offset: 0x00935DB7
		// (set) Token: 0x06020D21 RID: 134433 RVA: 0x00937BC7 File Offset: 0x00935DC7
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003777 RID: 14199
		// (get) Token: 0x06020D22 RID: 134434 RVA: 0x00937BD8 File Offset: 0x00935DD8
		// (set) Token: 0x06020D23 RID: 134435 RVA: 0x00937BEC File Offset: 0x00935DEC
		public unsafe FVector2D Min_Max_Scale_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003778 RID: 14200
		// (get) Token: 0x06020D24 RID: 134436 RVA: 0x00937C01 File Offset: 0x00935E01
		// (set) Token: 0x06020D25 RID: 134437 RVA: 0x00937C11 File Offset: 0x00935E11
		public unsafe int ScaleRandomSeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003779 RID: 14201
		// (get) Token: 0x06020D26 RID: 134438 RVA: 0x00937C22 File Offset: 0x00935E22
		// (set) Token: 0x06020D27 RID: 134439 RVA: 0x00937C36 File Offset: 0x00935E36
		public unsafe FVector2D Min_Max_Distance_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700377A RID: 14202
		// (get) Token: 0x06020D28 RID: 134440 RVA: 0x00937C4B File Offset: 0x00935E4B
		// (set) Token: 0x06020D29 RID: 134441 RVA: 0x00937C5B File Offset: 0x00935E5B
		public unsafe int DistanceRandomSeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Spline_Water_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x06020D2A RID: 134442 RVA: 0x00937C6C File Offset: 0x00935E6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Spline_Water_C.__SetParam_NativeFunctionPtr, null);
		}

		// Token: 0x06020D2B RID: 134443 RVA: 0x00937C80 File Offset: 0x00935E80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Spline_Water_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020D2C RID: 134444 RVA: 0x00937C94 File Offset: 0x00935E94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Spline_Water_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020D2D RID: 134445 RVA: 0x00937CA9 File Offset: 0x00935EA9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Spline_Water_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020D2E RID: 134446 RVA: 0x00937CBD File Offset: 0x00935EBD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Spline_Water_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020D2F RID: 134447 RVA: 0x00937CD4 File Offset: 0x00935ED4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Spline_Water(int EntryPoint)
		{
			BP_Spline_Water_C.__ExecuteUbergraph_BP_Spline_Water_FunctionParams* ptr = stackalloc BP_Spline_Water_C.__ExecuteUbergraph_BP_Spline_Water_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Spline_Water_C.__ExecuteUbergraph_BP_Spline_Water_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Spline_Water_C.__ExecuteUbergraph_BP_Spline_Water_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Spline_Water_C.__ExecuteUbergraph_BP_Spline_Water_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020D30 RID: 134448 RVA: 0x00937D1B File Offset: 0x00935F1B
		protected BP_Spline_Water_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010740 RID: 67392
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/BP_Spline_Water.BP_Spline_Water_C";

		// Token: 0x04010741 RID: 67393
		private static IntPtr _ClassPtr;

		// Token: 0x04010742 RID: 67394
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010743 RID: 67395
		internal static int __PropertyOffset_0;

		// Token: 0x04010744 RID: 67396
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010745 RID: 67397
		internal static int __PropertyOffset_1;

		// Token: 0x04010746 RID: 67398
		internal static int __PropertyOffset_2;

		// Token: 0x04010747 RID: 67399
		internal static int __PropertyOffset_3;

		// Token: 0x04010748 RID: 67400
		internal static int __PropertyOffset_4;

		// Token: 0x04010749 RID: 67401
		internal static int __PropertyOffset_5;

		// Token: 0x0401074A RID: 67402
		internal static int __PropertyOffset_6;

		// Token: 0x0401074B RID: 67403
		internal static int __PropertyOffset_7;

		// Token: 0x0401074C RID: 67404
		internal static int __PropertyOffset_8;

		// Token: 0x0401074D RID: 67405
		internal static int __PropertyOffset_9;

		// Token: 0x0401074E RID: 67406
		internal static int __PropertyOffset_10;

		// Token: 0x0401074F RID: 67407
		private static IntPtr __SetParam_NativeFunctionPtr;

		// Token: 0x04010750 RID: 67408
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010751 RID: 67409
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010752 RID: 67410
		private static IntPtr __ExecuteUbergraph_BP_Spline_Water_NativeFunctionPtr;

		// Token: 0x02009A34 RID: 39476
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_Spline_Water_FunctionParams
		{
			// Token: 0x0403212E RID: 205102
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
