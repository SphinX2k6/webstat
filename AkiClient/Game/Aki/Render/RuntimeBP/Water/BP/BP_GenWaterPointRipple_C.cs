using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Water.BP
{
	// Token: 0x02003A07 RID: 14855
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Water/BP/BP_GenWaterPointRipple.BP_GenWaterPointRipple_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1048)]
	public class BP_GenWaterPointRipple_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E49A RID: 124058 RVA: 0x008F1C98 File Offset: 0x008EFE98
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GenWaterPointRipple_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Water/BP/BP_GenWaterPointRipple.BP_GenWaterPointRipple_C");
			}
			return BP_GenWaterPointRipple_C._ClassPtr;
		}

		// Token: 0x0601E49B RID: 124059 RVA: 0x008F1CBC File Offset: 0x008EFEBC
		public BP_GenWaterPointRipple_C() : this(BuiltinUtils.AllocNativeUObject(BP_GenWaterPointRipple_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E49C RID: 124060 RVA: 0x008F1CE4 File Offset: 0x008EFEE4
		public BP_GenWaterPointRipple_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GenWaterPointRipple_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002967 RID: 10599
		// (get) Token: 0x0601E49D RID: 124061 RVA: 0x008F1D18 File Offset: 0x008EFF18
		// (set) Token: 0x0601E49E RID: 124062 RVA: 0x008F1D51 File Offset: 0x008EFF51
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GenWaterPointRipple_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GenWaterPointRipple_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002968 RID: 10600
		// (get) Token: 0x0601E49F RID: 124063 RVA: 0x008F1D72 File Offset: 0x008EFF72
		// (set) Token: 0x0601E4A0 RID: 124064 RVA: 0x008F1D86 File Offset: 0x008EFF86
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GenWaterPointRipple_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GenWaterPointRipple_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0601E4A1 RID: 124065 RVA: 0x008F1D9B File Offset: 0x008EFF9B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GenWaterPointRipple_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E4A2 RID: 124066 RVA: 0x008F1DAF File Offset: 0x008EFFAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GenWaterPointRipple_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E4A3 RID: 124067 RVA: 0x008F1DC4 File Offset: 0x008EFFC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GenWaterPointRipple_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601E4A4 RID: 124068 RVA: 0x008F1DD8 File Offset: 0x008EFFD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GenWaterPointRipple_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E4A5 RID: 124069 RVA: 0x008F1DF0 File Offset: 0x008EFFF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GenWaterPointRipple(int EntryPoint)
		{
			BP_GenWaterPointRipple_C.__ExecuteUbergraph_BP_GenWaterPointRipple_FunctionParams* ptr = stackalloc BP_GenWaterPointRipple_C.__ExecuteUbergraph_BP_GenWaterPointRipple_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_GenWaterPointRipple_C.__ExecuteUbergraph_BP_GenWaterPointRipple_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GenWaterPointRipple_C.__ExecuteUbergraph_BP_GenWaterPointRipple_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GenWaterPointRipple_C.__ExecuteUbergraph_BP_GenWaterPointRipple_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E4A6 RID: 124070 RVA: 0x008F1E37 File Offset: 0x008F0037
		protected BP_GenWaterPointRipple_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EE51 RID: 61009
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Water/BP/BP_GenWaterPointRipple.BP_GenWaterPointRipple_C";

		// Token: 0x0400EE52 RID: 61010
		private static IntPtr _ClassPtr;

		// Token: 0x0400EE53 RID: 61011
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EE54 RID: 61012
		internal static int __PropertyOffset_0;

		// Token: 0x0400EE55 RID: 61013
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EE56 RID: 61014
		internal static int __PropertyOffset_1;

		// Token: 0x0400EE57 RID: 61015
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EE58 RID: 61016
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400EE59 RID: 61017
		private static IntPtr __ExecuteUbergraph_BP_GenWaterPointRipple_NativeFunctionPtr;

		// Token: 0x0200979B RID: 38811
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_GenWaterPointRipple_FunctionParams
		{
			// Token: 0x04031D61 RID: 204129
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
