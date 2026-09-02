using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.ActiveDebug
{
	// Token: 0x02003986 RID: 14726
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/Module/ActiveDebug/ActiveBvb.ActiveBvb_C")]
	[UnrealStructLayout(1200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1200)]
	public class ActiveBvb_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DABC RID: 121532 RVA: 0x008DCE28 File Offset: 0x008DB028
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ActiveBvb_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Module/ActiveDebug/ActiveBvb.ActiveBvb_C");
			}
			return ActiveBvb_C._ClassPtr;
		}

		// Token: 0x0601DABD RID: 121533 RVA: 0x008DCE4C File Offset: 0x008DB04C
		public ActiveBvb_C() : this(BuiltinUtils.AllocNativeUObject(ActiveBvb_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DABE RID: 121534 RVA: 0x008DCE74 File Offset: 0x008DB074
		[NullableContext(1)]
		public ActiveBvb_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ActiveBvb_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700271C RID: 10012
		// (get) Token: 0x0601DABF RID: 121535 RVA: 0x008DCEA8 File Offset: 0x008DB0A8
		// (set) Token: 0x0601DAC0 RID: 121536 RVA: 0x008DCEE1 File Offset: 0x008DB0E1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ActiveBvb_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ActiveBvb_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700271D RID: 10013
		// (get) Token: 0x0601DAC1 RID: 121537 RVA: 0x008DCF02 File Offset: 0x008DB102
		// (set) Token: 0x0601DAC2 RID: 121538 RVA: 0x008DCF16 File Offset: 0x008DB116
		public unsafe BvbPlayerItem_C BvbNpcItem
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BvbPlayerItem_C>(base.NativePtr / (IntPtr)sizeof(void*) + ActiveBvb_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ActiveBvb_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700271E RID: 10014
		// (get) Token: 0x0601DAC3 RID: 121539 RVA: 0x008DCF2B File Offset: 0x008DB12B
		// (set) Token: 0x0601DAC4 RID: 121540 RVA: 0x008DCF3F File Offset: 0x008DB13F
		public unsafe BvbPlayerItem_C BvbPlayerItem
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BvbPlayerItem_C>(base.NativePtr / (IntPtr)sizeof(void*) + ActiveBvb_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ActiveBvb_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700271F RID: 10015
		// (get) Token: 0x0601DAC5 RID: 121541 RVA: 0x008DCF54 File Offset: 0x008DB154
		// (set) Token: 0x0601DAC6 RID: 121542 RVA: 0x008DCF68 File Offset: 0x008DB168
		public unsafe UImage TexMainBg
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + ActiveBvb_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ActiveBvb_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x0601DAC7 RID: 121543 RVA: 0x008DCF80 File Offset: 0x008DB180
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Refresh(BvbPlayerItemData PlayerItemData, BvbPlayerItemData NpcItemData)
		{
			ActiveBvb_C.__Refresh_FunctionParams* ptr = stackalloc ActiveBvb_C.__Refresh_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(ActiveBvb_C.__Refresh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ActiveBvb_C.__Refresh_NativeFunctionPtr, (void*)ptr, 1);
			if (PlayerItemData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(BvbPlayerItemData.StaticStruct(), &ptr->PlayerItemData, PlayerItemData.NativePtr, 1, false);
			}
			if (NpcItemData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(BvbPlayerItemData.StaticStruct(), &ptr->NpcItemData, NpcItemData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ActiveBvb_C.__Refresh_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(ActiveBvb_C.__Refresh_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DAC8 RID: 121544 RVA: 0x008DD014 File Offset: 0x008DB214
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void Construct()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ActiveBvb_C.__Construct_NativeFunctionPtr, null);
		}

		// Token: 0x0601DAC9 RID: 121545 RVA: 0x008DD028 File Offset: 0x008DB228
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void Construct_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ActiveBvb_C.__Construct_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601DACA RID: 121546 RVA: 0x008DD040 File Offset: 0x008DB240
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ActiveBvb(int EntryPoint)
		{
			ActiveBvb_C.__ExecuteUbergraph_ActiveBvb_FunctionParams* ptr = stackalloc ActiveBvb_C.__ExecuteUbergraph_ActiveBvb_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ActiveBvb_C.__ExecuteUbergraph_ActiveBvb_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ActiveBvb_C.__ExecuteUbergraph_ActiveBvb_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ActiveBvb_C.__ExecuteUbergraph_ActiveBvb_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DACB RID: 121547 RVA: 0x008DD087 File Offset: 0x008DB287
		protected ActiveBvb_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E875 RID: 59509
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Module/ActiveDebug/ActiveBvb.ActiveBvb_C";

		// Token: 0x0400E876 RID: 59510
		private static IntPtr _ClassPtr;

		// Token: 0x0400E877 RID: 59511
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E878 RID: 59512
		internal static int __PropertyOffset_0;

		// Token: 0x0400E879 RID: 59513
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400E87A RID: 59514
		internal static int __PropertyOffset_1;

		// Token: 0x0400E87B RID: 59515
		internal static int __PropertyOffset_2;

		// Token: 0x0400E87C RID: 59516
		internal static int __PropertyOffset_3;

		// Token: 0x0400E87D RID: 59517
		private static IntPtr __Refresh_NativeFunctionPtr;

		// Token: 0x0400E87E RID: 59518
		private static IntPtr __Construct_NativeFunctionPtr;

		// Token: 0x0400E87F RID: 59519
		private static IntPtr __ExecuteUbergraph_ActiveBvb_NativeFunctionPtr;

		// Token: 0x020096B1 RID: 38577
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __Refresh_FunctionParams
		{
			// Token: 0x04031B86 RID: 203654
			[FieldOffset(0)]
			public byte PlayerItemData;

			// Token: 0x04031B87 RID: 203655
			[FieldOffset(48)]
			public byte NpcItemData;
		}

		// Token: 0x020096B2 RID: 38578
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_ActiveBvb_FunctionParams
		{
			// Token: 0x04031B88 RID: 203656
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
