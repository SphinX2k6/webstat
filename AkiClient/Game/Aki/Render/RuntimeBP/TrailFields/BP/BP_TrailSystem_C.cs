using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.BP
{
	// Token: 0x02003A38 RID: 14904
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/BP/BP_TrailSystem.BP_TrailSystem_C")]
	[UnrealStructLayout(1456, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1444)]
	public class BP_TrailSystem_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EBA3 RID: 125859 RVA: 0x008FCE58 File Offset: 0x008FB058
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailSystem_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/BP/BP_TrailSystem.BP_TrailSystem_C");
			}
			return BP_TrailSystem_C._ClassPtr;
		}

		// Token: 0x0601EBA4 RID: 125860 RVA: 0x008FCE7C File Offset: 0x008FB07C
		public BP_TrailSystem_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailSystem_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EBA5 RID: 125861 RVA: 0x008FCEA4 File Offset: 0x008FB0A4
		[NullableContext(1)]
		public BP_TrailSystem_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailSystem_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002C18 RID: 11288
		// (get) Token: 0x0601EBA6 RID: 125862 RVA: 0x008FCED8 File Offset: 0x008FB0D8
		// (set) Token: 0x0601EBA7 RID: 125863 RVA: 0x008FCF11 File Offset: 0x008FB111
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TrailSystem_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TrailSystem_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002C19 RID: 11289
		// (get) Token: 0x0601EBA8 RID: 125864 RVA: 0x008FCF32 File Offset: 0x008FB132
		// (set) Token: 0x0601EBA9 RID: 125865 RVA: 0x008FCF46 File Offset: 0x008FB146
		public unsafe UNiagaraComponent NS_SnowTrail
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSystem_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSystem_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002C1A RID: 11290
		// (get) Token: 0x0601EBAA RID: 125866 RVA: 0x008FCF5B File Offset: 0x008FB15B
		// (set) Token: 0x0601EBAB RID: 125867 RVA: 0x008FCF6F File Offset: 0x008FB16F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSystem_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSystem_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002C1B RID: 11291
		// (get) Token: 0x0601EBAC RID: 125868 RVA: 0x008FCF84 File Offset: 0x008FB184
		// (set) Token: 0x0601EBAD RID: 125869 RVA: 0x008FCF98 File Offset: 0x008FB198
		public unsafe FVector Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSystem_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSystem_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002C1C RID: 11292
		// (get) Token: 0x0601EBAE RID: 125870 RVA: 0x008FCFAD File Offset: 0x008FB1AD
		// (set) Token: 0x0601EBAF RID: 125871 RVA: 0x008FCFBD File Offset: 0x008FB1BD
		public unsafe float Threshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSystem_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSystem_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002C1D RID: 11293
		// (get) Token: 0x0601EBB0 RID: 125872 RVA: 0x008FCFCE File Offset: 0x008FB1CE
		// (set) Token: 0x0601EBB1 RID: 125873 RVA: 0x008FCFE2 File Offset: 0x008FB1E2
		public unsafe FVectorDouble PrezCharacterPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSystem_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSystem_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002C1E RID: 11294
		// (get) Token: 0x0601EBB2 RID: 125874 RVA: 0x008FCFF7 File Offset: 0x008FB1F7
		// (set) Token: 0x0601EBB3 RID: 125875 RVA: 0x008FD00B File Offset: 0x008FB20B
		public unsafe FTransformDouble CharacterTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSystem_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSystem_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002C1F RID: 11295
		// (get) Token: 0x0601EBB4 RID: 125876 RVA: 0x008FD020 File Offset: 0x008FB220
		// (set) Token: 0x0601EBB5 RID: 125877 RVA: 0x008FD030 File Offset: 0x008FB230
		public unsafe float Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSystem_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSystem_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0601EBB6 RID: 125878 RVA: 0x008FD041 File Offset: 0x008FB241
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSystem_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EBB7 RID: 125879 RVA: 0x008FD055 File Offset: 0x008FB255
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSystem_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EBB8 RID: 125880 RVA: 0x008FD06C File Offset: 0x008FB26C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_TrailSystem_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TrailSystem_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailSystem_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSystem_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSystem_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EBB9 RID: 125881 RVA: 0x008FD0B4 File Offset: 0x008FB2B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_TrailSystem_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TrailSystem_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailSystem_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSystem_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSystem_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EBBA RID: 125882 RVA: 0x008FD0FC File Offset: 0x008FB2FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_TrailSystem_C.__EditorTick_FunctionParams* ptr = stackalloc BP_TrailSystem_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailSystem_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSystem_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSystem_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EBBB RID: 125883 RVA: 0x008FD144 File Offset: 0x008FB344
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_TrailSystem_C.__EditorTick_FunctionParams* ptr = stackalloc BP_TrailSystem_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailSystem_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSystem_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSystem_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EBBC RID: 125884 RVA: 0x008FD18C File Offset: 0x008FB38C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TrailSystem(int EntryPoint)
		{
			BP_TrailSystem_C.__ExecuteUbergraph_BP_TrailSystem_FunctionParams* ptr = stackalloc BP_TrailSystem_C.__ExecuteUbergraph_BP_TrailSystem_FunctionParams[(UIntPtr)431] + 15L / (long)sizeof(BP_TrailSystem_C.__ExecuteUbergraph_BP_TrailSystem_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSystem_C.__ExecuteUbergraph_BP_TrailSystem_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSystem_C.__ExecuteUbergraph_BP_TrailSystem_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EBBD RID: 125885 RVA: 0x008FD1D6 File Offset: 0x008FB3D6
		protected BP_TrailSystem_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F2A4 RID: 62116
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/BP/BP_TrailSystem.BP_TrailSystem_C";

		// Token: 0x0400F2A5 RID: 62117
		private static IntPtr _ClassPtr;

		// Token: 0x0400F2A6 RID: 62118
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F2A7 RID: 62119
		internal static int __PropertyOffset_0;

		// Token: 0x0400F2A8 RID: 62120
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F2A9 RID: 62121
		internal static int __PropertyOffset_1;

		// Token: 0x0400F2AA RID: 62122
		internal static int __PropertyOffset_2;

		// Token: 0x0400F2AB RID: 62123
		internal static int __PropertyOffset_3;

		// Token: 0x0400F2AC RID: 62124
		internal static int __PropertyOffset_4;

		// Token: 0x0400F2AD RID: 62125
		internal static int __PropertyOffset_5;

		// Token: 0x0400F2AE RID: 62126
		internal static int __PropertyOffset_6;

		// Token: 0x0400F2AF RID: 62127
		internal static int __PropertyOffset_7;

		// Token: 0x0400F2B0 RID: 62128
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F2B1 RID: 62129
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F2B2 RID: 62130
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F2B3 RID: 62131
		private static IntPtr __ExecuteUbergraph_BP_TrailSystem_NativeFunctionPtr;

		// Token: 0x020097F6 RID: 38902
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031DEB RID: 204267
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097F7 RID: 38903
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031DEC RID: 204268
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097F8 RID: 38904
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 416)]
		protected ref struct __ExecuteUbergraph_BP_TrailSystem_FunctionParams
		{
			// Token: 0x04031DED RID: 204269
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
