using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Sensors;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime
{
	// Token: 0x02003A29 RID: 14889
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_TrailDebugger.BP_TrailDebugger_C")]
	[UnrealStructLayout(1144, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1144)]
	public class BP_TrailDebugger_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EA13 RID: 125459 RVA: 0x008FA013 File Offset: 0x008F8213
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailDebugger_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_TrailDebugger.BP_TrailDebugger_C");
			}
			return BP_TrailDebugger_C._ClassPtr;
		}

		// Token: 0x0601EA14 RID: 125460 RVA: 0x008FA038 File Offset: 0x008F8238
		public BP_TrailDebugger_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailDebugger_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EA15 RID: 125461 RVA: 0x008FA060 File Offset: 0x008F8260
		[NullableContext(1)]
		public BP_TrailDebugger_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailDebugger_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002B96 RID: 11158
		// (get) Token: 0x0601EA16 RID: 125462 RVA: 0x008FA094 File Offset: 0x008F8294
		// (set) Token: 0x0601EA17 RID: 125463 RVA: 0x008FA0CD File Offset: 0x008F82CD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TrailDebugger_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TrailDebugger_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002B97 RID: 11159
		// (get) Token: 0x0601EA18 RID: 125464 RVA: 0x008FA0EE File Offset: 0x008F82EE
		// (set) Token: 0x0601EA19 RID: 125465 RVA: 0x008FA102 File Offset: 0x008F8302
		public unsafe UStaticMeshComponent Cube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002B98 RID: 11160
		// (get) Token: 0x0601EA1A RID: 125466 RVA: 0x008FA117 File Offset: 0x008F8317
		// (set) Token: 0x0601EA1B RID: 125467 RVA: 0x008FA12B File Offset: 0x008F832B
		public unsafe UTextRenderComponent TextRender4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002B99 RID: 11161
		// (get) Token: 0x0601EA1C RID: 125468 RVA: 0x008FA140 File Offset: 0x008F8340
		// (set) Token: 0x0601EA1D RID: 125469 RVA: 0x008FA154 File Offset: 0x008F8354
		public unsafe UTextRenderComponent TextRender3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002B9A RID: 11162
		// (get) Token: 0x0601EA1E RID: 125470 RVA: 0x008FA169 File Offset: 0x008F8369
		// (set) Token: 0x0601EA1F RID: 125471 RVA: 0x008FA17D File Offset: 0x008F837D
		public unsafe UTextRenderComponent TextRender2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002B9B RID: 11163
		// (get) Token: 0x0601EA20 RID: 125472 RVA: 0x008FA192 File Offset: 0x008F8392
		// (set) Token: 0x0601EA21 RID: 125473 RVA: 0x008FA1A6 File Offset: 0x008F83A6
		public unsafe UTextRenderComponent TextRender1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002B9C RID: 11164
		// (get) Token: 0x0601EA22 RID: 125474 RVA: 0x008FA1BB File Offset: 0x008F83BB
		// (set) Token: 0x0601EA23 RID: 125475 RVA: 0x008FA1CF File Offset: 0x008F83CF
		public unsafe UTextRenderComponent TextRender
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002B9D RID: 11165
		// (get) Token: 0x0601EA24 RID: 125476 RVA: 0x008FA1E4 File Offset: 0x008F83E4
		// (set) Token: 0x0601EA25 RID: 125477 RVA: 0x008FA1F8 File Offset: 0x008F83F8
		public unsafe UStaticMeshComponent Plane4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002B9E RID: 11166
		// (get) Token: 0x0601EA26 RID: 125478 RVA: 0x008FA20D File Offset: 0x008F840D
		// (set) Token: 0x0601EA27 RID: 125479 RVA: 0x008FA221 File Offset: 0x008F8421
		public unsafe UStaticMeshComponent Plane3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17002B9F RID: 11167
		// (get) Token: 0x0601EA28 RID: 125480 RVA: 0x008FA236 File Offset: 0x008F8436
		// (set) Token: 0x0601EA29 RID: 125481 RVA: 0x008FA24A File Offset: 0x008F844A
		public unsafe UStaticMeshComponent Plane2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17002BA0 RID: 11168
		// (get) Token: 0x0601EA2A RID: 125482 RVA: 0x008FA25F File Offset: 0x008F845F
		// (set) Token: 0x0601EA2B RID: 125483 RVA: 0x008FA273 File Offset: 0x008F8473
		public unsafe UStaticMeshComponent Plane1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17002BA1 RID: 11169
		// (get) Token: 0x0601EA2C RID: 125484 RVA: 0x008FA288 File Offset: 0x008F8488
		// (set) Token: 0x0601EA2D RID: 125485 RVA: 0x008FA29C File Offset: 0x008F849C
		public unsafe UStaticMeshComponent Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17002BA2 RID: 11170
		// (get) Token: 0x0601EA2E RID: 125486 RVA: 0x008FA2B1 File Offset: 0x008F84B1
		// (set) Token: 0x0601EA2F RID: 125487 RVA: 0x008FA2C5 File Offset: 0x008F84C5
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17002BA3 RID: 11171
		// (get) Token: 0x0601EA30 RID: 125488 RVA: 0x008FA2DA File Offset: 0x008F84DA
		// (set) Token: 0x0601EA31 RID: 125489 RVA: 0x008FA2EE File Offset: 0x008F84EE
		public unsafe BP_TrailSensorActor_C Target
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_TrailSensorActor_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugger_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x0601EA32 RID: 125490 RVA: 0x008FA304 File Offset: 0x008F8504
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetMat(UTexture Texture, UPrimitiveComponent Plane)
		{
			BP_TrailDebugger_C.__SetMat_FunctionParams* ptr = stackalloc BP_TrailDebugger_C.__SetMat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_TrailDebugger_C.__SetMat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDebugger_C.__SetMat_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Texture = ((Texture != null) ? Texture.NativePtr : IntPtr.Zero);
			ptr->Plane = ((Plane != null) ? Plane.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDebugger_C.__SetMat_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EA33 RID: 125491 RVA: 0x008FA36F File Offset: 0x008F856F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDebugger_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EA34 RID: 125492 RVA: 0x008FA383 File Offset: 0x008F8583
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailDebugger_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EA35 RID: 125493 RVA: 0x008FA398 File Offset: 0x008F8598
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TrailDebugger(int EntryPoint)
		{
			BP_TrailDebugger_C.__ExecuteUbergraph_BP_TrailDebugger_FunctionParams* ptr = stackalloc BP_TrailDebugger_C.__ExecuteUbergraph_BP_TrailDebugger_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_TrailDebugger_C.__ExecuteUbergraph_BP_TrailDebugger_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDebugger_C.__ExecuteUbergraph_BP_TrailDebugger_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailDebugger_C.__ExecuteUbergraph_BP_TrailDebugger_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EA36 RID: 125494 RVA: 0x008FA3DF File Offset: 0x008F85DF
		protected BP_TrailDebugger_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F1A4 RID: 61860
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_TrailDebugger.BP_TrailDebugger_C";

		// Token: 0x0400F1A5 RID: 61861
		private static IntPtr _ClassPtr;

		// Token: 0x0400F1A6 RID: 61862
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F1A7 RID: 61863
		internal static int __PropertyOffset_0;

		// Token: 0x0400F1A8 RID: 61864
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F1A9 RID: 61865
		internal static int __PropertyOffset_1;

		// Token: 0x0400F1AA RID: 61866
		internal static int __PropertyOffset_2;

		// Token: 0x0400F1AB RID: 61867
		internal static int __PropertyOffset_3;

		// Token: 0x0400F1AC RID: 61868
		internal static int __PropertyOffset_4;

		// Token: 0x0400F1AD RID: 61869
		internal static int __PropertyOffset_5;

		// Token: 0x0400F1AE RID: 61870
		internal static int __PropertyOffset_6;

		// Token: 0x0400F1AF RID: 61871
		internal static int __PropertyOffset_7;

		// Token: 0x0400F1B0 RID: 61872
		internal static int __PropertyOffset_8;

		// Token: 0x0400F1B1 RID: 61873
		internal static int __PropertyOffset_9;

		// Token: 0x0400F1B2 RID: 61874
		internal static int __PropertyOffset_10;

		// Token: 0x0400F1B3 RID: 61875
		internal static int __PropertyOffset_11;

		// Token: 0x0400F1B4 RID: 61876
		internal static int __PropertyOffset_12;

		// Token: 0x0400F1B5 RID: 61877
		internal static int __PropertyOffset_13;

		// Token: 0x0400F1B6 RID: 61878
		private static IntPtr __SetMat_NativeFunctionPtr;

		// Token: 0x0400F1B7 RID: 61879
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F1B8 RID: 61880
		private static IntPtr __ExecuteUbergraph_BP_TrailDebugger_NativeFunctionPtr;

		// Token: 0x020097D6 RID: 38870
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __SetMat_FunctionParams
		{
			// Token: 0x04031DC2 RID: 204226
			[FieldOffset(0)]
			public IntPtr Texture;

			// Token: 0x04031DC3 RID: 204227
			[FieldOffset(8)]
			public IntPtr Plane;
		}

		// Token: 0x020097D7 RID: 38871
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_TrailDebugger_FunctionParams
		{
			// Token: 0x04031DC4 RID: 204228
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
