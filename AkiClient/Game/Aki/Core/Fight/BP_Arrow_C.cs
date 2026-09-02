using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F4C RID: 16204
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/BP_Arrow.BP_Arrow_C")]
	[UnrealStructLayout(1064, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1064)]
	public class BP_Arrow_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060287DC RID: 165852 RVA: 0x00A0D2BC File Offset: 0x00A0B4BC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Arrow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/Fight/BP_Arrow.BP_Arrow_C");
			}
			return BP_Arrow_C._ClassPtr;
		}

		// Token: 0x060287DD RID: 165853 RVA: 0x00A0D2E0 File Offset: 0x00A0B4E0
		public BP_Arrow_C() : this(BuiltinUtils.AllocNativeUObject(BP_Arrow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060287DE RID: 165854 RVA: 0x00A0D308 File Offset: 0x00A0B508
		[NullableContext(1)]
		public BP_Arrow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Arrow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700627B RID: 25211
		// (get) Token: 0x060287DF RID: 165855 RVA: 0x00A0D33C File Offset: 0x00A0B53C
		// (set) Token: 0x060287E0 RID: 165856 RVA: 0x00A0D375 File Offset: 0x00A0B575
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Arrow_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Arrow_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700627C RID: 25212
		// (get) Token: 0x060287E1 RID: 165857 RVA: 0x00A0D396 File Offset: 0x00A0B596
		// (set) Token: 0x060287E2 RID: 165858 RVA: 0x00A0D3AA File Offset: 0x00A0B5AA
		public unsafe UArrowComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Arrow_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Arrow_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700627D RID: 25213
		// (get) Token: 0x060287E3 RID: 165859 RVA: 0x00A0D3BF File Offset: 0x00A0B5BF
		// (set) Token: 0x060287E4 RID: 165860 RVA: 0x00A0D3D3 File Offset: 0x00A0B5D3
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Arrow_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Arrow_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700627E RID: 25214
		// (get) Token: 0x060287E5 RID: 165861 RVA: 0x00A0D3E8 File Offset: 0x00A0B5E8
		// (set) Token: 0x060287E6 RID: 165862 RVA: 0x00A0D3F8 File Offset: 0x00A0B5F8
		public unsafe float 开始时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Arrow_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Arrow_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700627F RID: 25215
		// (get) Token: 0x060287E7 RID: 165863 RVA: 0x00A0D409 File Offset: 0x00A0B609
		// (set) Token: 0x060287E8 RID: 165864 RVA: 0x00A0D419 File Offset: 0x00A0B619
		public unsafe float 持续时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Arrow_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Arrow_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x060287E9 RID: 165865 RVA: 0x00A0D42A File Offset: 0x00A0B62A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Arrow_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060287EA RID: 165866 RVA: 0x00A0D43E File Offset: 0x00A0B63E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Arrow_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060287EB RID: 165867 RVA: 0x00A0D454 File Offset: 0x00A0B654
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Arrow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Arrow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Arrow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Arrow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Arrow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060287EC RID: 165868 RVA: 0x00A0D49C File Offset: 0x00A0B69C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Arrow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Arrow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Arrow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Arrow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Arrow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060287ED RID: 165869 RVA: 0x00A0D4E4 File Offset: 0x00A0B6E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Arrow(int EntryPoint)
		{
			BP_Arrow_C.__ExecuteUbergraph_BP_Arrow_FunctionParams* ptr = stackalloc BP_Arrow_C.__ExecuteUbergraph_BP_Arrow_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Arrow_C.__ExecuteUbergraph_BP_Arrow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Arrow_C.__ExecuteUbergraph_BP_Arrow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Arrow_C.__ExecuteUbergraph_BP_Arrow_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060287EE RID: 165870 RVA: 0x00A0D52B File Offset: 0x00A0B72B
		protected BP_Arrow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040154F0 RID: 87280
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/Fight/BP_Arrow.BP_Arrow_C";

		// Token: 0x040154F1 RID: 87281
		private static IntPtr _ClassPtr;

		// Token: 0x040154F2 RID: 87282
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040154F3 RID: 87283
		internal static int __PropertyOffset_0;

		// Token: 0x040154F4 RID: 87284
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040154F5 RID: 87285
		internal static int __PropertyOffset_1;

		// Token: 0x040154F6 RID: 87286
		internal static int __PropertyOffset_2;

		// Token: 0x040154F7 RID: 87287
		internal static int __PropertyOffset_3;

		// Token: 0x040154F8 RID: 87288
		internal static int __PropertyOffset_4;

		// Token: 0x040154F9 RID: 87289
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040154FA RID: 87290
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040154FB RID: 87291
		private static IntPtr __ExecuteUbergraph_BP_Arrow_NativeFunctionPtr;

		// Token: 0x0200A11B RID: 41243
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032E3F RID: 208447
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A11C RID: 41244
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_Arrow_FunctionParams
		{
			// Token: 0x04032E40 RID: 208448
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
