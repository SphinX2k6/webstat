using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.WaterSim.BP
{
	// Token: 0x02003B4D RID: 15181
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_HeightmapReadback.BP_HeightmapReadback_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1088)]
	public class BP_HeightmapReadback_C : AKuroCSReadback, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020F11 RID: 134929 RVA: 0x0093B77C File Offset: 0x0093997C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_HeightmapReadback_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_HeightmapReadback.BP_HeightmapReadback_C");
			}
			return BP_HeightmapReadback_C._ClassPtr;
		}

		// Token: 0x06020F12 RID: 134930 RVA: 0x0093B7A0 File Offset: 0x009399A0
		public BP_HeightmapReadback_C() : this(BuiltinUtils.AllocNativeUObject(BP_HeightmapReadback_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020F13 RID: 134931 RVA: 0x0093B7C8 File Offset: 0x009399C8
		[NullableContext(1)]
		public BP_HeightmapReadback_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_HeightmapReadback_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700381B RID: 14363
		// (get) Token: 0x06020F14 RID: 134932 RVA: 0x0093B7FC File Offset: 0x009399FC
		// (set) Token: 0x06020F15 RID: 134933 RVA: 0x0093B835 File Offset: 0x00939A35
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_HeightmapReadback_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_HeightmapReadback_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06020F16 RID: 134934 RVA: 0x0093B856 File Offset: 0x00939A56
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HeightmapReadback_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020F17 RID: 134935 RVA: 0x0093B86A File Offset: 0x00939A6A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HeightmapReadback_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020F18 RID: 134936 RVA: 0x0093B880 File Offset: 0x00939A80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_HeightmapReadback_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_HeightmapReadback_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_HeightmapReadback_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HeightmapReadback_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HeightmapReadback_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020F19 RID: 134937 RVA: 0x0093B8CC File Offset: 0x00939ACC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_HeightmapReadback_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_HeightmapReadback_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_HeightmapReadback_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HeightmapReadback_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HeightmapReadback_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020F1A RID: 134938 RVA: 0x0093B918 File Offset: 0x00939B18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_HeightmapReadback(int EntryPoint)
		{
			BP_HeightmapReadback_C.__ExecuteUbergraph_BP_HeightmapReadback_FunctionParams* ptr = stackalloc BP_HeightmapReadback_C.__ExecuteUbergraph_BP_HeightmapReadback_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_HeightmapReadback_C.__ExecuteUbergraph_BP_HeightmapReadback_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HeightmapReadback_C.__ExecuteUbergraph_BP_HeightmapReadback_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HeightmapReadback_C.__ExecuteUbergraph_BP_HeightmapReadback_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020F1B RID: 134939 RVA: 0x0093B95F File Offset: 0x00939B5F
		protected BP_HeightmapReadback_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010894 RID: 67732
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_HeightmapReadback.BP_HeightmapReadback_C";

		// Token: 0x04010895 RID: 67733
		private static IntPtr _ClassPtr;

		// Token: 0x04010896 RID: 67734
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010897 RID: 67735
		internal static int __PropertyOffset_0;

		// Token: 0x04010898 RID: 67736
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010899 RID: 67737
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401089A RID: 67738
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0401089B RID: 67739
		private static IntPtr __ExecuteUbergraph_BP_HeightmapReadback_NativeFunctionPtr;

		// Token: 0x02009A53 RID: 39507
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032154 RID: 205140
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009A54 RID: 39508
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_HeightmapReadback_FunctionParams
		{
			// Token: 0x04032155 RID: 205141
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
