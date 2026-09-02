using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.ActiveDebug
{
	// Token: 0x02003988 RID: 14728
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/Module/ActiveDebug/BvbCardItem.BvbCardItem_C")]
	[UnrealStructLayout(1272, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1272)]
	public class BvbCardItem_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DAE0 RID: 121568 RVA: 0x008DD246 File Offset: 0x008DB446
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BvbCardItem_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Module/ActiveDebug/BvbCardItem.BvbCardItem_C");
			}
			return BvbCardItem_C._ClassPtr;
		}

		// Token: 0x0601DAE1 RID: 121569 RVA: 0x008DD26C File Offset: 0x008DB46C
		public BvbCardItem_C() : this(BuiltinUtils.AllocNativeUObject(BvbCardItem_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DAE2 RID: 121570 RVA: 0x008DD294 File Offset: 0x008DB494
		[NullableContext(1)]
		public BvbCardItem_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BvbCardItem_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002726 RID: 10022
		// (get) Token: 0x0601DAE3 RID: 121571 RVA: 0x008DD2C8 File Offset: 0x008DB4C8
		// (set) Token: 0x0601DAE4 RID: 121572 RVA: 0x008DD301 File Offset: 0x008DB501
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BvbCardItem_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BvbCardItem_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002727 RID: 10023
		// (get) Token: 0x0601DAE5 RID: 121573 RVA: 0x008DD322 File Offset: 0x008DB522
		// (set) Token: 0x0601DAE6 RID: 121574 RVA: 0x008DD336 File Offset: 0x008DB536
		public unsafe UButton BtnArrow_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002728 RID: 10024
		// (get) Token: 0x0601DAE7 RID: 121575 RVA: 0x008DD34B File Offset: 0x008DB54B
		// (set) Token: 0x0601DAE8 RID: 121576 RVA: 0x008DD35F File Offset: 0x008DB55F
		public unsafe UBorder ContentBorder
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBorder>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002729 RID: 10025
		// (get) Token: 0x0601DAE9 RID: 121577 RVA: 0x008DD374 File Offset: 0x008DB574
		// (set) Token: 0x0601DAEA RID: 121578 RVA: 0x008DD388 File Offset: 0x008DB588
		public unsafe UVerticalBox PnlLayout
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UVerticalBox>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700272A RID: 10026
		// (get) Token: 0x0601DAEB RID: 121579 RVA: 0x008DD39D File Offset: 0x008DB59D
		// (set) Token: 0x0601DAEC RID: 121580 RVA: 0x008DD3B1 File Offset: 0x008DB5B1
		public unsafe UImage TexTitleBg_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700272B RID: 10027
		// (get) Token: 0x0601DAED RID: 121581 RVA: 0x008DD3C6 File Offset: 0x008DB5C6
		// (set) Token: 0x0601DAEE RID: 121582 RVA: 0x008DD3DA File Offset: 0x008DB5DA
		public unsafe UTextBlock TxtCostAll
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700272C RID: 10028
		// (get) Token: 0x0601DAEF RID: 121583 RVA: 0x008DD3EF File Offset: 0x008DB5EF
		// (set) Token: 0x0601DAF0 RID: 121584 RVA: 0x008DD403 File Offset: 0x008DB603
		public unsafe UTextBlock TxtDesc
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700272D RID: 10029
		// (get) Token: 0x0601DAF1 RID: 121585 RVA: 0x008DD418 File Offset: 0x008DB618
		// (set) Token: 0x0601DAF2 RID: 121586 RVA: 0x008DD42C File Offset: 0x008DB62C
		public unsafe UTextBlock TxtElementAll
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700272E RID: 10030
		// (get) Token: 0x0601DAF3 RID: 121587 RVA: 0x008DD441 File Offset: 0x008DB641
		// (set) Token: 0x0601DAF4 RID: 121588 RVA: 0x008DD455 File Offset: 0x008DB655
		public unsafe UTextBlock TxtPowerAll
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x1700272F RID: 10031
		// (get) Token: 0x0601DAF5 RID: 121589 RVA: 0x008DD46A File Offset: 0x008DB66A
		// (set) Token: 0x0601DAF6 RID: 121590 RVA: 0x008DD47E File Offset: 0x008DB67E
		public unsafe UTextBlock TxtTitle_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17002730 RID: 10032
		// (get) Token: 0x0601DAF7 RID: 121591 RVA: 0x008DD493 File Offset: 0x008DB693
		// (set) Token: 0x0601DAF8 RID: 121592 RVA: 0x008DD4A7 File Offset: 0x008DB6A7
		public unsafe UVerticalBox VerticalBox_434
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UVerticalBox>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardItem_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17002731 RID: 10033
		// (get) Token: 0x0601DAF9 RID: 121593 RVA: 0x008DD4BC File Offset: 0x008DB6BC
		// (set) Token: 0x0601DAFA RID: 121594 RVA: 0x008DD4F5 File Offset: 0x008DB6F5
		[Nullable(1)]
		public TArray<BvbEffectItem_C> EffectItemList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<BvbEffectItem_C> result;
				if ((result = this._EffectItemList) == null)
				{
					result = (this._EffectItemList = new TArray<BvbEffectItem_C>(base.NativePtr + (IntPtr)BvbCardItem_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.EffectItemList.CopyAssign(value);
			}
		}

		// Token: 0x0601DAFB RID: 121595 RVA: 0x008DD503 File Offset: 0x008DB703
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFlodBtnClick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbCardItem_C.__OnFlodBtnClick_NativeFunctionPtr, null);
		}

		// Token: 0x0601DAFC RID: 121596 RVA: 0x008DD518 File Offset: 0x008DB718
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RefreshEffectItemList([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<BvbEffectItemData> EffectItemDataList)
		{
			BvbCardItem_C.__RefreshEffectItemList_FunctionParams* ptr = stackalloc BvbCardItem_C.__RefreshEffectItemList_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BvbCardItem_C.__RefreshEffectItemList_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbCardItem_C.__RefreshEffectItemList_NativeFunctionPtr, (void*)ptr, 1);
			TArray<BvbEffectItemData> tarray = EffectItemDataList;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->EffectItemDataList);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbCardItem_C.__RefreshEffectItemList_NativeFunctionPtr, (void*)ptr);
			TArray<BvbEffectItemData> tarray2 = EffectItemDataList;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->EffectItemDataList);
			}
			UnrealReflectionUtils.DestroyStruct(BvbCardItem_C.__RefreshEffectItemList_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DAFD RID: 121597 RVA: 0x008DD590 File Offset: 0x008DB790
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CreateEffectItem()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbCardItem_C.__CreateEffectItem_NativeFunctionPtr, null);
		}

		// Token: 0x0601DAFE RID: 121598 RVA: 0x008DD5A4 File Offset: 0x008DB7A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Refresh(BvbCardItemData CardItemData)
		{
			BvbCardItem_C.__Refresh_FunctionParams* ptr = stackalloc BvbCardItem_C.__Refresh_FunctionParams[(UIntPtr)231] + 15L / (long)sizeof(BvbCardItem_C.__Refresh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbCardItem_C.__Refresh_NativeFunctionPtr, (void*)ptr, 1);
			if (CardItemData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(BvbCardItemData.StaticStruct(), &ptr->CardItemData, CardItemData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbCardItem_C.__Refresh_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BvbCardItem_C.__Refresh_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DAFF RID: 121599 RVA: 0x008DD619 File Offset: 0x008DB819
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BvbCardItem_BtnArrow_1_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbCardItem_C.__BndEvt__BvbCardItem_BtnArrow_1_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x0601DB00 RID: 121600 RVA: 0x008DD630 File Offset: 0x008DB830
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BvbCardItem(int EntryPoint)
		{
			BvbCardItem_C.__ExecuteUbergraph_BvbCardItem_FunctionParams* ptr = stackalloc BvbCardItem_C.__ExecuteUbergraph_BvbCardItem_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BvbCardItem_C.__ExecuteUbergraph_BvbCardItem_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbCardItem_C.__ExecuteUbergraph_BvbCardItem_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BvbCardItem_C.__ExecuteUbergraph_BvbCardItem_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DB01 RID: 121601 RVA: 0x008DD677 File Offset: 0x008DB877
		protected BvbCardItem_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E889 RID: 59529
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Module/ActiveDebug/BvbCardItem.BvbCardItem_C";

		// Token: 0x0400E88A RID: 59530
		private static IntPtr _ClassPtr;

		// Token: 0x0400E88B RID: 59531
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E88C RID: 59532
		internal static int __PropertyOffset_0;

		// Token: 0x0400E88D RID: 59533
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400E88E RID: 59534
		internal static int __PropertyOffset_1;

		// Token: 0x0400E88F RID: 59535
		internal static int __PropertyOffset_2;

		// Token: 0x0400E890 RID: 59536
		internal static int __PropertyOffset_3;

		// Token: 0x0400E891 RID: 59537
		internal static int __PropertyOffset_4;

		// Token: 0x0400E892 RID: 59538
		internal static int __PropertyOffset_5;

		// Token: 0x0400E893 RID: 59539
		internal static int __PropertyOffset_6;

		// Token: 0x0400E894 RID: 59540
		internal static int __PropertyOffset_7;

		// Token: 0x0400E895 RID: 59541
		internal static int __PropertyOffset_8;

		// Token: 0x0400E896 RID: 59542
		internal static int __PropertyOffset_9;

		// Token: 0x0400E897 RID: 59543
		internal static int __PropertyOffset_10;

		// Token: 0x0400E898 RID: 59544
		internal static int __PropertyOffset_11;

		// Token: 0x0400E899 RID: 59545
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BvbEffectItem_C> _EffectItemList;

		// Token: 0x0400E89A RID: 59546
		private static IntPtr __OnFlodBtnClick_NativeFunctionPtr;

		// Token: 0x0400E89B RID: 59547
		private static IntPtr __RefreshEffectItemList_NativeFunctionPtr;

		// Token: 0x0400E89C RID: 59548
		private static IntPtr __CreateEffectItem_NativeFunctionPtr;

		// Token: 0x0400E89D RID: 59549
		private static IntPtr __Refresh_NativeFunctionPtr;

		// Token: 0x0400E89E RID: 59550
		private static IntPtr __BndEvt__BvbCardItem_BtnArrow_1_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E89F RID: 59551
		private static IntPtr __ExecuteUbergraph_BvbCardItem_NativeFunctionPtr;

		// Token: 0x020096B3 RID: 38579
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __RefreshEffectItemList_FunctionParams
		{
			// Token: 0x04031B89 RID: 203657
			[FieldOffset(0)]
			public byte EffectItemDataList;
		}

		// Token: 0x020096B4 RID: 38580
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 216)]
		protected ref struct __Refresh_FunctionParams
		{
			// Token: 0x04031B8A RID: 203658
			[FieldOffset(0)]
			public byte CardItemData;
		}

		// Token: 0x020096B5 RID: 38581
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BvbCardItem_FunctionParams
		{
			// Token: 0x04031B8B RID: 203659
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
