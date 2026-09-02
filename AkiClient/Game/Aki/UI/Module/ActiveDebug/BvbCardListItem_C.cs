using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.ActiveDebug
{
	// Token: 0x02003989 RID: 14729
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/Module/ActiveDebug/BvbCardListItem.BvbCardListItem_C")]
	[UnrealStructLayout(1232, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1232)]
	public class BvbCardListItem_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DB02 RID: 121602 RVA: 0x008DD680 File Offset: 0x008DB880
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BvbCardListItem_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Module/ActiveDebug/BvbCardListItem.BvbCardListItem_C");
			}
			return BvbCardListItem_C._ClassPtr;
		}

		// Token: 0x0601DB03 RID: 121603 RVA: 0x008DD6A4 File Offset: 0x008DB8A4
		public BvbCardListItem_C() : this(BuiltinUtils.AllocNativeUObject(BvbCardListItem_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DB04 RID: 121604 RVA: 0x008DD6CC File Offset: 0x008DB8CC
		[NullableContext(1)]
		public BvbCardListItem_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BvbCardListItem_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002732 RID: 10034
		// (get) Token: 0x0601DB05 RID: 121605 RVA: 0x008DD700 File Offset: 0x008DB900
		// (set) Token: 0x0601DB06 RID: 121606 RVA: 0x008DD739 File Offset: 0x008DB939
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BvbCardListItem_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BvbCardListItem_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002733 RID: 10035
		// (get) Token: 0x0601DB07 RID: 121607 RVA: 0x008DD75A File Offset: 0x008DB95A
		// (set) Token: 0x0601DB08 RID: 121608 RVA: 0x008DD76E File Offset: 0x008DB96E
		public unsafe UButton BtnArrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardListItem_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardListItem_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002734 RID: 10036
		// (get) Token: 0x0601DB09 RID: 121609 RVA: 0x008DD783 File Offset: 0x008DB983
		// (set) Token: 0x0601DB0A RID: 121610 RVA: 0x008DD797 File Offset: 0x008DB997
		public unsafe UVerticalBox Content
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UVerticalBox>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardListItem_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardListItem_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002735 RID: 10037
		// (get) Token: 0x0601DB0B RID: 121611 RVA: 0x008DD7AC File Offset: 0x008DB9AC
		// (set) Token: 0x0601DB0C RID: 121612 RVA: 0x008DD7C0 File Offset: 0x008DB9C0
		public unsafe UVerticalBox PnlLayout
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UVerticalBox>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardListItem_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardListItem_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002736 RID: 10038
		// (get) Token: 0x0601DB0D RID: 121613 RVA: 0x008DD7D5 File Offset: 0x008DB9D5
		// (set) Token: 0x0601DB0E RID: 121614 RVA: 0x008DD7E9 File Offset: 0x008DB9E9
		public unsafe UImage TexTitleBg_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardListItem_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardListItem_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002737 RID: 10039
		// (get) Token: 0x0601DB0F RID: 121615 RVA: 0x008DD7FE File Offset: 0x008DB9FE
		// (set) Token: 0x0601DB10 RID: 121616 RVA: 0x008DD812 File Offset: 0x008DBA12
		public unsafe UTextBlock TxtTitle_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardListItem_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbCardListItem_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002738 RID: 10040
		// (get) Token: 0x0601DB11 RID: 121617 RVA: 0x008DD828 File Offset: 0x008DBA28
		// (set) Token: 0x0601DB12 RID: 121618 RVA: 0x008DD861 File Offset: 0x008DBA61
		[Nullable(1)]
		public TArray<BvbCardItem_C> CardItemList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<BvbCardItem_C> result;
				if ((result = this._CardItemList) == null)
				{
					result = (this._CardItemList = new TArray<BvbCardItem_C>(base.NativePtr + (IntPtr)BvbCardListItem_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CardItemList.CopyAssign(value);
			}
		}

		// Token: 0x0601DB13 RID: 121619 RVA: 0x008DD870 File Offset: 0x008DBA70
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetTitle(string Title)
		{
			BvbCardListItem_C.__SetTitle_FunctionParams* ptr = stackalloc BvbCardListItem_C.__SetTitle_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BvbCardListItem_C.__SetTitle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbCardListItem_C.__SetTitle_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Title), Title);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbCardListItem_C.__SetTitle_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BvbCardListItem_C.__SetTitle_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DB14 RID: 121620 RVA: 0x008DD8CD File Offset: 0x008DBACD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFlodBtnClick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbCardListItem_C.__OnFlodBtnClick_NativeFunctionPtr, null);
		}

		// Token: 0x0601DB15 RID: 121621 RVA: 0x008DD8E4 File Offset: 0x008DBAE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RefreshCardItemList([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<BvbCardItemData> CardItemDataList)
		{
			BvbCardListItem_C.__RefreshCardItemList_FunctionParams* ptr = stackalloc BvbCardListItem_C.__RefreshCardItemList_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BvbCardListItem_C.__RefreshCardItemList_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbCardListItem_C.__RefreshCardItemList_NativeFunctionPtr, (void*)ptr, 1);
			TArray<BvbCardItemData> tarray = CardItemDataList;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->CardItemDataList);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbCardListItem_C.__RefreshCardItemList_NativeFunctionPtr, (void*)ptr);
			TArray<BvbCardItemData> tarray2 = CardItemDataList;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->CardItemDataList);
			}
			UnrealReflectionUtils.DestroyStruct(BvbCardListItem_C.__RefreshCardItemList_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DB16 RID: 121622 RVA: 0x008DD95C File Offset: 0x008DBB5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CreateCardItem()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbCardListItem_C.__CreateCardItem_NativeFunctionPtr, null);
		}

		// Token: 0x0601DB17 RID: 121623 RVA: 0x008DD970 File Offset: 0x008DBB70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BvbCardListItem_BtnArrow_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbCardListItem_C.__BndEvt__BvbCardListItem_BtnArrow_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x0601DB18 RID: 121624 RVA: 0x008DD984 File Offset: 0x008DBB84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BvbCardListItem(int EntryPoint)
		{
			BvbCardListItem_C.__ExecuteUbergraph_BvbCardListItem_FunctionParams* ptr = stackalloc BvbCardListItem_C.__ExecuteUbergraph_BvbCardListItem_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BvbCardListItem_C.__ExecuteUbergraph_BvbCardListItem_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbCardListItem_C.__ExecuteUbergraph_BvbCardListItem_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BvbCardListItem_C.__ExecuteUbergraph_BvbCardListItem_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DB19 RID: 121625 RVA: 0x008DD9CB File Offset: 0x008DBBCB
		protected BvbCardListItem_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E8A0 RID: 59552
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Module/ActiveDebug/BvbCardListItem.BvbCardListItem_C";

		// Token: 0x0400E8A1 RID: 59553
		private static IntPtr _ClassPtr;

		// Token: 0x0400E8A2 RID: 59554
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E8A3 RID: 59555
		internal static int __PropertyOffset_0;

		// Token: 0x0400E8A4 RID: 59556
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400E8A5 RID: 59557
		internal static int __PropertyOffset_1;

		// Token: 0x0400E8A6 RID: 59558
		internal static int __PropertyOffset_2;

		// Token: 0x0400E8A7 RID: 59559
		internal static int __PropertyOffset_3;

		// Token: 0x0400E8A8 RID: 59560
		internal static int __PropertyOffset_4;

		// Token: 0x0400E8A9 RID: 59561
		internal static int __PropertyOffset_5;

		// Token: 0x0400E8AA RID: 59562
		internal static int __PropertyOffset_6;

		// Token: 0x0400E8AB RID: 59563
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BvbCardItem_C> _CardItemList;

		// Token: 0x0400E8AC RID: 59564
		private static IntPtr __SetTitle_NativeFunctionPtr;

		// Token: 0x0400E8AD RID: 59565
		private static IntPtr __OnFlodBtnClick_NativeFunctionPtr;

		// Token: 0x0400E8AE RID: 59566
		private static IntPtr __RefreshCardItemList_NativeFunctionPtr;

		// Token: 0x0400E8AF RID: 59567
		private static IntPtr __CreateCardItem_NativeFunctionPtr;

		// Token: 0x0400E8B0 RID: 59568
		private static IntPtr __BndEvt__BvbCardListItem_BtnArrow_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E8B1 RID: 59569
		private static IntPtr __ExecuteUbergraph_BvbCardListItem_NativeFunctionPtr;

		// Token: 0x020096B6 RID: 38582
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __SetTitle_FunctionParams
		{
			// Token: 0x04031B8C RID: 203660
			[FieldOffset(0)]
			public FString Title;
		}

		// Token: 0x020096B7 RID: 38583
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __RefreshCardItemList_FunctionParams
		{
			// Token: 0x04031B8D RID: 203661
			[FieldOffset(0)]
			public byte CardItemDataList;
		}

		// Token: 0x020096B8 RID: 38584
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BvbCardListItem_FunctionParams
		{
			// Token: 0x04031B8E RID: 203662
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
