using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Temp
{
	// Token: 0x02003A3D RID: 14909
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Temp/BP_TestNiagara.BP_TestNiagara_C")]
	[UnrealStructLayout(1080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1080)]
	public class BP_TestNiagara_C : AKuroEffectActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EC19 RID: 125977 RVA: 0x008FDB53 File Offset: 0x008FBD53
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TestNiagara_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Temp/BP_TestNiagara.BP_TestNiagara_C");
			}
			return BP_TestNiagara_C._ClassPtr;
		}

		// Token: 0x0601EC1A RID: 125978 RVA: 0x008FDB78 File Offset: 0x008FBD78
		public BP_TestNiagara_C() : this(BuiltinUtils.AllocNativeUObject(BP_TestNiagara_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EC1B RID: 125979 RVA: 0x008FDBA0 File Offset: 0x008FBDA0
		[NullableContext(1)]
		public BP_TestNiagara_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TestNiagara_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002C3C RID: 11324
		// (get) Token: 0x0601EC1C RID: 125980 RVA: 0x008FDBD4 File Offset: 0x008FBDD4
		// (set) Token: 0x0601EC1D RID: 125981 RVA: 0x008FDC0D File Offset: 0x008FBE0D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TestNiagara_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TestNiagara_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002C3D RID: 11325
		// (get) Token: 0x0601EC1E RID: 125982 RVA: 0x008FDC2E File Offset: 0x008FBE2E
		// (set) Token: 0x0601EC1F RID: 125983 RVA: 0x008FDC42 File Offset: 0x008FBE42
		public unsafe UStaticMeshComponent Cube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestNiagara_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestNiagara_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002C3E RID: 11326
		// (get) Token: 0x0601EC20 RID: 125984 RVA: 0x008FDC57 File Offset: 0x008FBE57
		// (set) Token: 0x0601EC21 RID: 125985 RVA: 0x008FDC6B File Offset: 0x008FBE6B
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestNiagara_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestNiagara_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002C3F RID: 11327
		// (get) Token: 0x0601EC22 RID: 125986 RVA: 0x008FDC80 File Offset: 0x008FBE80
		// (set) Token: 0x0601EC23 RID: 125987 RVA: 0x008FDC94 File Offset: 0x008FBE94
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestNiagara_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TestNiagara_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002C40 RID: 11328
		// (get) Token: 0x0601EC24 RID: 125988 RVA: 0x008FDCA9 File Offset: 0x008FBEA9
		// (set) Token: 0x0601EC25 RID: 125989 RVA: 0x008FDCB9 File Offset: 0x008FBEB9
		public unsafe float TriggerInterval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TestNiagara_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TestNiagara_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002C41 RID: 11329
		// (get) Token: 0x0601EC26 RID: 125990 RVA: 0x008FDCCA File Offset: 0x008FBECA
		// (set) Token: 0x0601EC27 RID: 125991 RVA: 0x008FDCDA File Offset: 0x008FBEDA
		public unsafe float Counter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TestNiagara_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TestNiagara_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x0601EC28 RID: 125992 RVA: 0x008FDCEB File Offset: 0x008FBEEB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TestNiagara_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601EC29 RID: 125993 RVA: 0x008FDCFF File Offset: 0x008FBEFF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TestNiagara_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EC2A RID: 125994 RVA: 0x008FDD14 File Offset: 0x008FBF14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_TestNiagara_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TestNiagara_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TestNiagara_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TestNiagara_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TestNiagara_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EC2B RID: 125995 RVA: 0x008FDD5C File Offset: 0x008FBF5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_TestNiagara_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TestNiagara_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TestNiagara_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TestNiagara_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TestNiagara_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EC2C RID: 125996 RVA: 0x008FDDA4 File Offset: 0x008FBFA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_TestNiagara_C.__EditorTick_FunctionParams* ptr = stackalloc BP_TestNiagara_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TestNiagara_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TestNiagara_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TestNiagara_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EC2D RID: 125997 RVA: 0x008FDDEC File Offset: 0x008FBFEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_TestNiagara_C.__EditorTick_FunctionParams* ptr = stackalloc BP_TestNiagara_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TestNiagara_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TestNiagara_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TestNiagara_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EC2E RID: 125998 RVA: 0x008FDE34 File Offset: 0x008FC034
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TestNiagara(int EntryPoint)
		{
			BP_TestNiagara_C.__ExecuteUbergraph_BP_TestNiagara_FunctionParams* ptr = stackalloc BP_TestNiagara_C.__ExecuteUbergraph_BP_TestNiagara_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_TestNiagara_C.__ExecuteUbergraph_BP_TestNiagara_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TestNiagara_C.__ExecuteUbergraph_BP_TestNiagara_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TestNiagara_C.__ExecuteUbergraph_BP_TestNiagara_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EC2F RID: 125999 RVA: 0x008FDE7B File Offset: 0x008FC07B
		protected BP_TestNiagara_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F2EC RID: 62188
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Temp/BP_TestNiagara.BP_TestNiagara_C";

		// Token: 0x0400F2ED RID: 62189
		private static IntPtr _ClassPtr;

		// Token: 0x0400F2EE RID: 62190
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F2EF RID: 62191
		internal static int __PropertyOffset_0;

		// Token: 0x0400F2F0 RID: 62192
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F2F1 RID: 62193
		internal static int __PropertyOffset_1;

		// Token: 0x0400F2F2 RID: 62194
		internal static int __PropertyOffset_2;

		// Token: 0x0400F2F3 RID: 62195
		internal static int __PropertyOffset_3;

		// Token: 0x0400F2F4 RID: 62196
		internal static int __PropertyOffset_4;

		// Token: 0x0400F2F5 RID: 62197
		internal static int __PropertyOffset_5;

		// Token: 0x0400F2F6 RID: 62198
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F2F7 RID: 62199
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F2F8 RID: 62200
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F2F9 RID: 62201
		private static IntPtr __ExecuteUbergraph_BP_TestNiagara_NativeFunctionPtr;

		// Token: 0x020097FC RID: 38908
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031DF1 RID: 204273
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097FD RID: 38909
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031DF2 RID: 204274
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097FE RID: 38910
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_TestNiagara_FunctionParams
		{
			// Token: 0x04031DF3 RID: 204275
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
