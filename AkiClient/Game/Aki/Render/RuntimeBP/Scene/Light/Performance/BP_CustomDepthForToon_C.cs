using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light.Performance
{
	// Token: 0x02003AAE RID: 15022
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/Performance/BP_CustomDepthForToon.BP_CustomDepthForToon_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_CustomDepthForToon_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602001B RID: 131099 RVA: 0x0091F9FC File Offset: 0x0091DBFC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CustomDepthForToon_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/Performance/BP_CustomDepthForToon.BP_CustomDepthForToon_C");
			}
			return BP_CustomDepthForToon_C._ClassPtr;
		}

		// Token: 0x0602001C RID: 131100 RVA: 0x0091FA20 File Offset: 0x0091DC20
		public BP_CustomDepthForToon_C() : this(BuiltinUtils.AllocNativeUObject(BP_CustomDepthForToon_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602001D RID: 131101 RVA: 0x0091FA48 File Offset: 0x0091DC48
		public BP_CustomDepthForToon_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CustomDepthForToon_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003374 RID: 13172
		// (get) Token: 0x0602001E RID: 131102 RVA: 0x0091FA7C File Offset: 0x0091DC7C
		// (set) Token: 0x0602001F RID: 131103 RVA: 0x0091FAB5 File Offset: 0x0091DCB5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CustomDepthForToon_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CustomDepthForToon_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003375 RID: 13173
		// (get) Token: 0x06020020 RID: 131104 RVA: 0x0091FAD6 File Offset: 0x0091DCD6
		// (set) Token: 0x06020021 RID: 131105 RVA: 0x0091FAEA File Offset: 0x0091DCEA
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomDepthForToon_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomDepthForToon_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06020022 RID: 131106 RVA: 0x0091FAFF File Offset: 0x0091DCFF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableCustomDepthForToon()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CustomDepthForToon_C.__DisableCustomDepthForToon_NativeFunctionPtr, null);
		}

		// Token: 0x06020023 RID: 131107 RVA: 0x0091FB13 File Offset: 0x0091DD13
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EnableCustomDepthForToon()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CustomDepthForToon_C.__EnableCustomDepthForToon_NativeFunctionPtr, null);
		}

		// Token: 0x06020024 RID: 131108 RVA: 0x0091FB27 File Offset: 0x0091DD27
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CustomDepthForToon_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x06020025 RID: 131109 RVA: 0x0091FB3B File Offset: 0x0091DD3B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CustomDepthForToon_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020026 RID: 131110 RVA: 0x0091FB50 File Offset: 0x0091DD50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CustomDepthForToon_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020027 RID: 131111 RVA: 0x0091FB64 File Offset: 0x0091DD64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CustomDepthForToon_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020028 RID: 131112 RVA: 0x0091FB7C File Offset: 0x0091DD7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CustomDepthForToon(int EntryPoint)
		{
			BP_CustomDepthForToon_C.__ExecuteUbergraph_BP_CustomDepthForToon_FunctionParams* ptr = stackalloc BP_CustomDepthForToon_C.__ExecuteUbergraph_BP_CustomDepthForToon_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CustomDepthForToon_C.__ExecuteUbergraph_BP_CustomDepthForToon_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CustomDepthForToon_C.__ExecuteUbergraph_BP_CustomDepthForToon_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CustomDepthForToon_C.__ExecuteUbergraph_BP_CustomDepthForToon_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020029 RID: 131113 RVA: 0x0091FBC3 File Offset: 0x0091DDC3
		protected BP_CustomDepthForToon_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FF03 RID: 65283
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/Performance/BP_CustomDepthForToon.BP_CustomDepthForToon_C";

		// Token: 0x0400FF04 RID: 65284
		private static IntPtr _ClassPtr;

		// Token: 0x0400FF05 RID: 65285
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FF06 RID: 65286
		internal static int __PropertyOffset_0;

		// Token: 0x0400FF07 RID: 65287
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FF08 RID: 65288
		internal static int __PropertyOffset_1;

		// Token: 0x0400FF09 RID: 65289
		private static IntPtr __DisableCustomDepthForToon_NativeFunctionPtr;

		// Token: 0x0400FF0A RID: 65290
		private static IntPtr __EnableCustomDepthForToon_NativeFunctionPtr;

		// Token: 0x0400FF0B RID: 65291
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400FF0C RID: 65292
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FF0D RID: 65293
		private static IntPtr __ExecuteUbergraph_BP_CustomDepthForToon_NativeFunctionPtr;

		// Token: 0x02009945 RID: 39237
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_CustomDepthForToon_FunctionParams
		{
			// Token: 0x04031FA4 RID: 204708
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
