using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vision
{
	// Token: 0x02003F89 RID: 16265
	[UnrealObjectPath("/Game/Aki/Character/Vision/BP_BaseVision.BP_BaseVision_C")]
	[UnrealStructLayout(2272, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2266)]
	public class BP_BaseVision_C : __TsBaseCharacter_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028B1D RID: 166685 RVA: 0x00A13028 File Offset: 0x00A11228
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BaseVision_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vision/BP_BaseVision.BP_BaseVision_C");
			}
			return BP_BaseVision_C._ClassPtr;
		}

		// Token: 0x06028B1E RID: 166686 RVA: 0x00A1304C File Offset: 0x00A1124C
		public BP_BaseVision_C() : this(BuiltinUtils.AllocNativeUObject(BP_BaseVision_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028B1F RID: 166687 RVA: 0x00A13074 File Offset: 0x00A11274
		[NullableContext(1)]
		public BP_BaseVision_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BaseVision_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006383 RID: 25475
		// (get) Token: 0x06028B20 RID: 166688 RVA: 0x00A130A8 File Offset: 0x00A112A8
		// (set) Token: 0x06028B21 RID: 166689 RVA: 0x00A130E1 File Offset: 0x00A112E1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BaseVision_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BaseVision_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006384 RID: 25476
		// (get) Token: 0x06028B22 RID: 166690 RVA: 0x00A13102 File Offset: 0x00A11302
		// (set) Token: 0x06028B23 RID: 166691 RVA: 0x00A13116 File Offset: 0x00A11316
		public unsafe FVector 显像放大比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseVision_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseVision_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006385 RID: 25477
		// (get) Token: 0x06028B24 RID: 166692 RVA: 0x00A1312B File Offset: 0x00A1132B
		// (set) Token: 0x06028B25 RID: 166693 RVA: 0x00A1313F File Offset: 0x00A1133F
		public unsafe FVector 显像缩小比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseVision_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseVision_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006386 RID: 25478
		// (get) Token: 0x06028B26 RID: 166694 RVA: 0x00A13154 File Offset: 0x00A11354
		// (set) Token: 0x06028B27 RID: 166695 RVA: 0x00A13164 File Offset: 0x00A11364
		public unsafe bool 显像时是否需要打开可视化
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseVision_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseVision_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006387 RID: 25479
		// (get) Token: 0x06028B28 RID: 166696 RVA: 0x00A13175 File Offset: 0x00A11375
		// (set) Token: 0x06028B29 RID: 166697 RVA: 0x00A13185 File Offset: 0x00A11385
		public unsafe bool 显像时是否需要特殊pose
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseVision_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseVision_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x06028B2A RID: 166698 RVA: 0x00A13198 File Offset: 0x00A11398
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取召唤角色(ref TsBaseCharacter 召唤角色)
		{
			BP_BaseVision_C.__获取召唤角色_FunctionParams* ptr = stackalloc BP_BaseVision_C.__获取召唤角色_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_BaseVision_C.__获取召唤角色_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseVision_C.__获取召唤角色_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_BaseVision_C.__获取召唤角色_FunctionParams ptr2 = ref *ptr;
			TsBaseCharacter tsBaseCharacter = 召唤角色;
			ptr2.召唤角色 = ((tsBaseCharacter != null) ? tsBaseCharacter.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseVision_C.__获取召唤角色_NativeFunctionPtr, (void*)ptr);
			召唤角色 = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(ptr->召唤角色);
		}

		// Token: 0x06028B2B RID: 166699 RVA: 0x00A131FC File Offset: 0x00A113FC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取幻象数据(ref SVisionData 幻象数据)
		{
			BP_BaseVision_C.__获取幻象数据_FunctionParams* ptr = stackalloc BP_BaseVision_C.__获取幻象数据_FunctionParams[(UIntPtr)367] + 15L / (long)sizeof(BP_BaseVision_C.__获取幻象数据_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseVision_C.__获取幻象数据_NativeFunctionPtr, (void*)ptr, 1);
			if (幻象数据 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SVisionData.StaticStruct(), &ptr->幻象数据, 幻象数据.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseVision_C.__获取幻象数据_NativeFunctionPtr, (void*)ptr);
			if (幻象数据 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SVisionData.StaticStruct(), 幻象数据.NativePtr, &ptr->幻象数据, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(BP_BaseVision_C.__获取幻象数据_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028B2C RID: 166700 RVA: 0x00A13297 File Offset: 0x00A11497
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseVision_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06028B2D RID: 166701 RVA: 0x00A132AB File Offset: 0x00A114AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseVision_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028B2E RID: 166702 RVA: 0x00A132C0 File Offset: 0x00A114C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BaseVision_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BaseVision_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BaseVision_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseVision_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseVision_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028B2F RID: 166703 RVA: 0x00A13308 File Offset: 0x00A11508
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BaseVision_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BaseVision_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BaseVision_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseVision_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseVision_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028B30 RID: 166704 RVA: 0x00A1334F File Offset: 0x00A1154F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 显像初始化()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseVision_C.__显像初始化_NativeFunctionPtr, null);
		}

		// Token: 0x06028B31 RID: 166705 RVA: 0x00A13363 File Offset: 0x00A11563
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 显像结束()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseVision_C.__显像结束_NativeFunctionPtr, null);
		}

		// Token: 0x06028B32 RID: 166706 RVA: 0x00A13378 File Offset: 0x00A11578
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BaseVision(int EntryPoint)
		{
			BP_BaseVision_C.__ExecuteUbergraph_BP_BaseVision_FunctionParams* ptr = stackalloc BP_BaseVision_C.__ExecuteUbergraph_BP_BaseVision_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_BaseVision_C.__ExecuteUbergraph_BP_BaseVision_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseVision_C.__ExecuteUbergraph_BP_BaseVision_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseVision_C.__ExecuteUbergraph_BP_BaseVision_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028B33 RID: 166707 RVA: 0x00A133BF File Offset: 0x00A115BF
		protected BP_BaseVision_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401578E RID: 87950
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vision/BP_BaseVision.BP_BaseVision_C";

		// Token: 0x0401578F RID: 87951
		private static IntPtr _ClassPtr;

		// Token: 0x04015790 RID: 87952
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015791 RID: 87953
		internal static int __PropertyOffset_0;

		// Token: 0x04015792 RID: 87954
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015793 RID: 87955
		internal static int __PropertyOffset_1;

		// Token: 0x04015794 RID: 87956
		internal static int __PropertyOffset_2;

		// Token: 0x04015795 RID: 87957
		internal static int __PropertyOffset_3;

		// Token: 0x04015796 RID: 87958
		internal static int __PropertyOffset_4;

		// Token: 0x04015797 RID: 87959
		private static IntPtr __获取召唤角色_NativeFunctionPtr;

		// Token: 0x04015798 RID: 87960
		private static IntPtr __获取幻象数据_NativeFunctionPtr;

		// Token: 0x04015799 RID: 87961
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401579A RID: 87962
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401579B RID: 87963
		private static IntPtr __显像初始化_NativeFunctionPtr;

		// Token: 0x0401579C RID: 87964
		private static IntPtr __显像结束_NativeFunctionPtr;

		// Token: 0x0401579D RID: 87965
		private static IntPtr __ExecuteUbergraph_BP_BaseVision_NativeFunctionPtr;

		// Token: 0x0200A138 RID: 41272
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __获取召唤角色_FunctionParams
		{
			// Token: 0x04032E6C RID: 208492
			[FieldOffset(0)]
			public IntPtr 召唤角色;
		}

		// Token: 0x0200A139 RID: 41273
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 352)]
		protected ref struct __获取幻象数据_FunctionParams
		{
			// Token: 0x04032E6D RID: 208493
			[FieldOffset(0)]
			public byte 幻象数据;
		}

		// Token: 0x0200A13A RID: 41274
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032E6E RID: 208494
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A13B RID: 41275
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_BaseVision_FunctionParams
		{
			// Token: 0x04032E6F RID: 208495
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
