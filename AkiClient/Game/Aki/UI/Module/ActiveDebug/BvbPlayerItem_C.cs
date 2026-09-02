using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.ActiveDebug
{
	// Token: 0x0200398E RID: 14734
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/Module/ActiveDebug/BvbPlayerItem.BvbPlayerItem_C")]
	[UnrealStructLayout(1232, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1232)]
	public class BvbPlayerItem_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DB64 RID: 121700 RVA: 0x008DE2EE File Offset: 0x008DC4EE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BvbPlayerItem_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Module/ActiveDebug/BvbPlayerItem.BvbPlayerItem_C");
			}
			return BvbPlayerItem_C._ClassPtr;
		}

		// Token: 0x0601DB65 RID: 121701 RVA: 0x008DE314 File Offset: 0x008DC514
		public BvbPlayerItem_C() : this(BuiltinUtils.AllocNativeUObject(BvbPlayerItem_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DB66 RID: 121702 RVA: 0x008DE33C File Offset: 0x008DC53C
		[NullableContext(1)]
		public BvbPlayerItem_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BvbPlayerItem_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700274D RID: 10061
		// (get) Token: 0x0601DB67 RID: 121703 RVA: 0x008DE370 File Offset: 0x008DC570
		// (set) Token: 0x0601DB68 RID: 121704 RVA: 0x008DE3A9 File Offset: 0x008DC5A9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BvbPlayerItem_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BvbPlayerItem_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700274E RID: 10062
		// (get) Token: 0x0601DB69 RID: 121705 RVA: 0x008DE3CA File Offset: 0x008DC5CA
		// (set) Token: 0x0601DB6A RID: 121706 RVA: 0x008DE3DE File Offset: 0x008DC5DE
		public unsafe BvbCardListItem_C BvbCardListItem
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BvbCardListItem_C>(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700274F RID: 10063
		// (get) Token: 0x0601DB6B RID: 121707 RVA: 0x008DE3F3 File Offset: 0x008DC5F3
		// (set) Token: 0x0601DB6C RID: 121708 RVA: 0x008DE407 File Offset: 0x008DC607
		public unsafe BvbCardListItem_C BvbCardListItem_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BvbCardListItem_C>(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002750 RID: 10064
		// (get) Token: 0x0601DB6D RID: 121709 RVA: 0x008DE41C File Offset: 0x008DC61C
		// (set) Token: 0x0601DB6E RID: 121710 RVA: 0x008DE430 File Offset: 0x008DC630
		public unsafe BvbCardListItem_C BvbCardListItem_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BvbCardListItem_C>(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002751 RID: 10065
		// (get) Token: 0x0601DB6F RID: 121711 RVA: 0x008DE445 File Offset: 0x008DC645
		// (set) Token: 0x0601DB70 RID: 121712 RVA: 0x008DE459 File Offset: 0x008DC659
		public unsafe UScrollBox ScrollBox_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UScrollBox>(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002752 RID: 10066
		// (get) Token: 0x0601DB71 RID: 121713 RVA: 0x008DE46E File Offset: 0x008DC66E
		// (set) Token: 0x0601DB72 RID: 121714 RVA: 0x008DE482 File Offset: 0x008DC682
		public unsafe UImage TexBg
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002753 RID: 10067
		// (get) Token: 0x0601DB73 RID: 121715 RVA: 0x008DE497 File Offset: 0x008DC697
		// (set) Token: 0x0601DB74 RID: 121716 RVA: 0x008DE4AB File Offset: 0x008DC6AB
		public unsafe UImage TexTitleBg
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002754 RID: 10068
		// (get) Token: 0x0601DB75 RID: 121717 RVA: 0x008DE4C0 File Offset: 0x008DC6C0
		// (set) Token: 0x0601DB76 RID: 121718 RVA: 0x008DE4D4 File Offset: 0x008DC6D4
		public unsafe UTextBlock TxtTitle
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbPlayerItem_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x0601DB77 RID: 121719 RVA: 0x008DE4EC File Offset: 0x008DC6EC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetTiltle(string Title)
		{
			BvbPlayerItem_C.__SetTiltle_FunctionParams* ptr = stackalloc BvbPlayerItem_C.__SetTiltle_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BvbPlayerItem_C.__SetTiltle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbPlayerItem_C.__SetTiltle_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Title), Title);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbPlayerItem_C.__SetTiltle_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BvbPlayerItem_C.__SetTiltle_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DB78 RID: 121720 RVA: 0x008DE54C File Offset: 0x008DC74C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Refresh(BvbPlayerItemData PlayerItemData)
		{
			BvbPlayerItem_C.__Refresh_FunctionParams* ptr = stackalloc BvbPlayerItem_C.__Refresh_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BvbPlayerItem_C.__Refresh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbPlayerItem_C.__Refresh_NativeFunctionPtr, (void*)ptr, 1);
			if (PlayerItemData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(BvbPlayerItemData.StaticStruct(), &ptr->PlayerItemData, PlayerItemData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbPlayerItem_C.__Refresh_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BvbPlayerItem_C.__Refresh_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DB79 RID: 121721 RVA: 0x008DE5BE File Offset: 0x008DC7BE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void Construct()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbPlayerItem_C.__Construct_NativeFunctionPtr, null);
		}

		// Token: 0x0601DB7A RID: 121722 RVA: 0x008DE5D2 File Offset: 0x008DC7D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void Construct_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BvbPlayerItem_C.__Construct_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601DB7B RID: 121723 RVA: 0x008DE5E8 File Offset: 0x008DC7E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BvbPlayerItem(int EntryPoint)
		{
			BvbPlayerItem_C.__ExecuteUbergraph_BvbPlayerItem_FunctionParams* ptr = stackalloc BvbPlayerItem_C.__ExecuteUbergraph_BvbPlayerItem_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BvbPlayerItem_C.__ExecuteUbergraph_BvbPlayerItem_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbPlayerItem_C.__ExecuteUbergraph_BvbPlayerItem_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BvbPlayerItem_C.__ExecuteUbergraph_BvbPlayerItem_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DB7C RID: 121724 RVA: 0x008DE62F File Offset: 0x008DC82F
		protected BvbPlayerItem_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E8E2 RID: 59618
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Module/ActiveDebug/BvbPlayerItem.BvbPlayerItem_C";

		// Token: 0x0400E8E3 RID: 59619
		private static IntPtr _ClassPtr;

		// Token: 0x0400E8E4 RID: 59620
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E8E5 RID: 59621
		internal static int __PropertyOffset_0;

		// Token: 0x0400E8E6 RID: 59622
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400E8E7 RID: 59623
		internal static int __PropertyOffset_1;

		// Token: 0x0400E8E8 RID: 59624
		internal static int __PropertyOffset_2;

		// Token: 0x0400E8E9 RID: 59625
		internal static int __PropertyOffset_3;

		// Token: 0x0400E8EA RID: 59626
		internal static int __PropertyOffset_4;

		// Token: 0x0400E8EB RID: 59627
		internal static int __PropertyOffset_5;

		// Token: 0x0400E8EC RID: 59628
		internal static int __PropertyOffset_6;

		// Token: 0x0400E8ED RID: 59629
		internal static int __PropertyOffset_7;

		// Token: 0x0400E8EE RID: 59630
		private static IntPtr __SetTiltle_NativeFunctionPtr;

		// Token: 0x0400E8EF RID: 59631
		private static IntPtr __Refresh_NativeFunctionPtr;

		// Token: 0x0400E8F0 RID: 59632
		private static IntPtr __Construct_NativeFunctionPtr;

		// Token: 0x0400E8F1 RID: 59633
		private static IntPtr __ExecuteUbergraph_BvbPlayerItem_NativeFunctionPtr;

		// Token: 0x020096BE RID: 38590
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __SetTiltle_FunctionParams
		{
			// Token: 0x04031B96 RID: 203670
			[FieldOffset(0)]
			public FString Title;
		}

		// Token: 0x020096BF RID: 38591
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __Refresh_FunctionParams
		{
			// Token: 0x04031B97 RID: 203671
			[FieldOffset(0)]
			public byte PlayerItemData;
		}

		// Token: 0x020096C0 RID: 38592
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BvbPlayerItem_FunctionParams
		{
			// Token: 0x04031B98 RID: 203672
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
