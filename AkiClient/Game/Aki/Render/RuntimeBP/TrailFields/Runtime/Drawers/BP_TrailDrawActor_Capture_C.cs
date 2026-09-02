using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Drawers
{
	// Token: 0x02003A34 RID: 14900
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailDrawActor_Capture.BP_TrailDrawActor_Capture_C")]
	[UnrealStructLayout(1192, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1192)]
	public class BP_TrailDrawActor_Capture_C : BP_TrailDrawActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EB38 RID: 125752 RVA: 0x008FC1D0 File Offset: 0x008FA3D0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailDrawActor_Capture_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailDrawActor_Capture.BP_TrailDrawActor_Capture_C");
			}
			return BP_TrailDrawActor_Capture_C._ClassPtr;
		}

		// Token: 0x0601EB39 RID: 125753 RVA: 0x008FC1F4 File Offset: 0x008FA3F4
		public BP_TrailDrawActor_Capture_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailDrawActor_Capture_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EB3A RID: 125754 RVA: 0x008FC21C File Offset: 0x008FA41C
		[NullableContext(1)]
		public BP_TrailDrawActor_Capture_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailDrawActor_Capture_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002BF7 RID: 11255
		// (get) Token: 0x0601EB3B RID: 125755 RVA: 0x008FC250 File Offset: 0x008FA450
		// (set) Token: 0x0601EB3C RID: 125756 RVA: 0x008FC289 File Offset: 0x008FA489
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002BF8 RID: 11256
		// (get) Token: 0x0601EB3D RID: 125757 RVA: 0x008FC2AA File Offset: 0x008FA4AA
		// (set) Token: 0x0601EB3E RID: 125758 RVA: 0x008FC2BE File Offset: 0x008FA4BE
		public unsafe USceneCaptureComponent2D SceneCaptureComponent2D
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_Capture_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_Capture_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002BF9 RID: 11257
		// (get) Token: 0x0601EB3F RID: 125759 RVA: 0x008FC2D3 File Offset: 0x008FA4D3
		// (set) Token: 0x0601EB40 RID: 125760 RVA: 0x008FC2E3 File Offset: 0x008FA4E3
		public unsafe float OrthoWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17002BFA RID: 11258
		// (get) Token: 0x0601EB41 RID: 125761 RVA: 0x008FC2F4 File Offset: 0x008FA4F4
		// (set) Token: 0x0601EB42 RID: 125762 RVA: 0x008FC308 File Offset: 0x008FA508
		public unsafe UTextureRenderTarget2D CaptureTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_Capture_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_Capture_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002BFB RID: 11259
		// (get) Token: 0x0601EB43 RID: 125763 RVA: 0x008FC31D File Offset: 0x008FA51D
		// (set) Token: 0x0601EB44 RID: 125764 RVA: 0x008FC331 File Offset: 0x008FA531
		public unsafe UMaterialInstanceDynamic MirrorMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_Capture_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_Capture_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002BFC RID: 11260
		// (get) Token: 0x0601EB45 RID: 125765 RVA: 0x008FC348 File Offset: 0x008FA548
		// (set) Token: 0x0601EB46 RID: 125766 RVA: 0x008FC381 File Offset: 0x008FA581
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> Object_Types
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._Object_Types) == null)
				{
					result = (this._Object_Types = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.Object_Types.CopyAssign(value);
			}
		}

		// Token: 0x17002BFD RID: 11261
		// (get) Token: 0x0601EB47 RID: 125767 RVA: 0x008FC38F File Offset: 0x008FA58F
		// (set) Token: 0x0601EB48 RID: 125768 RVA: 0x008FC39F File Offset: 0x008FA59F
		public unsafe float PixelWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002BFE RID: 11262
		// (get) Token: 0x0601EB49 RID: 125769 RVA: 0x008FC3B0 File Offset: 0x008FA5B0
		// (set) Token: 0x0601EB4A RID: 125770 RVA: 0x008FC3C4 File Offset: 0x008FA5C4
		public unsafe AActor Father
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_Capture_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_Capture_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002BFF RID: 11263
		// (get) Token: 0x0601EB4B RID: 125771 RVA: 0x008FC3D9 File Offset: 0x008FA5D9
		// (set) Token: 0x0601EB4C RID: 125772 RVA: 0x008FC3ED File Offset: 0x008FA5ED
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002C00 RID: 11264
		// (get) Token: 0x0601EB4D RID: 125773 RVA: 0x008FC402 File Offset: 0x008FA602
		// (set) Token: 0x0601EB4E RID: 125774 RVA: 0x008FC412 File Offset: 0x008FA612
		public unsafe bool UseBoundOrigin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C01 RID: 11265
		// (get) Token: 0x0601EB4F RID: 125775 RVA: 0x008FC423 File Offset: 0x008FA623
		// (set) Token: 0x0601EB50 RID: 125776 RVA: 0x008FC437 File Offset: 0x008FA637
		public unsafe UTextureRenderTarget2D RT1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_Capture_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_Capture_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17002C02 RID: 11266
		// (get) Token: 0x0601EB51 RID: 125777 RVA: 0x008FC44C File Offset: 0x008FA64C
		// (set) Token: 0x0601EB52 RID: 125778 RVA: 0x008FC460 File Offset: 0x008FA660
		public unsafe UTextureRenderTarget2D RT2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_Capture_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_Capture_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17002C03 RID: 11267
		// (get) Token: 0x0601EB53 RID: 125779 RVA: 0x008FC475 File Offset: 0x008FA675
		// (set) Token: 0x0601EB54 RID: 125780 RVA: 0x008FC485 File Offset: 0x008FA685
		public unsafe float ZOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002C04 RID: 11268
		// (get) Token: 0x0601EB55 RID: 125781 RVA: 0x008FC496 File Offset: 0x008FA696
		// (set) Token: 0x0601EB56 RID: 125782 RVA: 0x008FC4A6 File Offset: 0x008FA6A6
		public unsafe bool UpdateEveryTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C05 RID: 11269
		// (get) Token: 0x0601EB57 RID: 125783 RVA: 0x008FC4B7 File Offset: 0x008FA6B7
		// (set) Token: 0x0601EB58 RID: 125784 RVA: 0x008FC4C7 File Offset: 0x008FA6C7
		public unsafe float RayUp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002C06 RID: 11270
		// (get) Token: 0x0601EB59 RID: 125785 RVA: 0x008FC4D8 File Offset: 0x008FA6D8
		// (set) Token: 0x0601EB5A RID: 125786 RVA: 0x008FC4E8 File Offset: 0x008FA6E8
		public unsafe float RayDown
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawActor_Capture_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x0601EB5B RID: 125787 RVA: 0x008FC4F9 File Offset: 0x008FA6F9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDrawActor_Capture_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601EB5C RID: 125788 RVA: 0x008FC50D File Offset: 0x008FA70D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailDrawActor_Capture_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EB5D RID: 125789 RVA: 0x008FC522 File Offset: 0x008FA722
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDrawActor_Capture_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EB5E RID: 125790 RVA: 0x008FC536 File Offset: 0x008FA736
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailDrawActor_Capture_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EB5F RID: 125791 RVA: 0x008FC54C File Offset: 0x008FA74C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_TrailDrawActor_Capture_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TrailDrawActor_Capture_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailDrawActor_Capture_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDrawActor_Capture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDrawActor_Capture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EB60 RID: 125792 RVA: 0x008FC594 File Offset: 0x008FA794
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_TrailDrawActor_Capture_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TrailDrawActor_Capture_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailDrawActor_Capture_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDrawActor_Capture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailDrawActor_Capture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EB61 RID: 125793 RVA: 0x008FC5DC File Offset: 0x008FA7DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TrailDrawActor_Capture(int EntryPoint)
		{
			BP_TrailDrawActor_Capture_C.__ExecuteUbergraph_BP_TrailDrawActor_Capture_FunctionParams* ptr = stackalloc BP_TrailDrawActor_Capture_C.__ExecuteUbergraph_BP_TrailDrawActor_Capture_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_TrailDrawActor_Capture_C.__ExecuteUbergraph_BP_TrailDrawActor_Capture_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDrawActor_Capture_C.__ExecuteUbergraph_BP_TrailDrawActor_Capture_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailDrawActor_Capture_C.__ExecuteUbergraph_BP_TrailDrawActor_Capture_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EB62 RID: 125794 RVA: 0x008FC626 File Offset: 0x008FA826
		protected BP_TrailDrawActor_Capture_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F260 RID: 62048
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailDrawActor_Capture.BP_TrailDrawActor_Capture_C";

		// Token: 0x0400F261 RID: 62049
		private static IntPtr _ClassPtr;

		// Token: 0x0400F262 RID: 62050
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F263 RID: 62051
		internal new static int __PropertyOffset_0;

		// Token: 0x0400F264 RID: 62052
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F265 RID: 62053
		internal new static int __PropertyOffset_1;

		// Token: 0x0400F266 RID: 62054
		internal new static int __PropertyOffset_2;

		// Token: 0x0400F267 RID: 62055
		internal static int __PropertyOffset_3;

		// Token: 0x0400F268 RID: 62056
		internal static int __PropertyOffset_4;

		// Token: 0x0400F269 RID: 62057
		internal static int __PropertyOffset_5;

		// Token: 0x0400F26A RID: 62058
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _Object_Types;

		// Token: 0x0400F26B RID: 62059
		internal static int __PropertyOffset_6;

		// Token: 0x0400F26C RID: 62060
		internal static int __PropertyOffset_7;

		// Token: 0x0400F26D RID: 62061
		internal static int __PropertyOffset_8;

		// Token: 0x0400F26E RID: 62062
		internal static int __PropertyOffset_9;

		// Token: 0x0400F26F RID: 62063
		internal static int __PropertyOffset_10;

		// Token: 0x0400F270 RID: 62064
		internal static int __PropertyOffset_11;

		// Token: 0x0400F271 RID: 62065
		internal static int __PropertyOffset_12;

		// Token: 0x0400F272 RID: 62066
		internal static int __PropertyOffset_13;

		// Token: 0x0400F273 RID: 62067
		internal static int __PropertyOffset_14;

		// Token: 0x0400F274 RID: 62068
		internal static int __PropertyOffset_15;

		// Token: 0x0400F275 RID: 62069
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F276 RID: 62070
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F277 RID: 62071
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F278 RID: 62072
		private static IntPtr __ExecuteUbergraph_BP_TrailDrawActor_Capture_NativeFunctionPtr;

		// Token: 0x020097EE RID: 38894
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031DE2 RID: 204258
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097EF RID: 38895
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __ExecuteUbergraph_BP_TrailDrawActor_Capture_FunctionParams
		{
			// Token: 0x04031DE3 RID: 204259
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
