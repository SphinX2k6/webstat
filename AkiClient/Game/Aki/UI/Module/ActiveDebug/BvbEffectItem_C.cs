using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.ActiveDebug
{
	// Token: 0x0200398C RID: 14732
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/Module/ActiveDebug/BvbEffectItem.BvbEffectItem_C")]
	[UnrealStructLayout(1232, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1232)]
	public class BvbEffectItem_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DB3E RID: 121662 RVA: 0x008DDDE2 File Offset: 0x008DBFE2
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BvbEffectItem_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Module/ActiveDebug/BvbEffectItem.BvbEffectItem_C");
			}
			return BvbEffectItem_C._ClassPtr;
		}

		// Token: 0x0601DB3F RID: 121663 RVA: 0x008DDE08 File Offset: 0x008DC008
		public BvbEffectItem_C() : this(BuiltinUtils.AllocNativeUObject(BvbEffectItem_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DB40 RID: 121664 RVA: 0x008DDE30 File Offset: 0x008DC030
		[NullableContext(1)]
		public BvbEffectItem_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BvbEffectItem_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002743 RID: 10051
		// (get) Token: 0x0601DB41 RID: 121665 RVA: 0x008DDE64 File Offset: 0x008DC064
		// (set) Token: 0x0601DB42 RID: 121666 RVA: 0x008DDE9D File Offset: 0x008DC09D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BvbEffectItem_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BvbEffectItem_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002744 RID: 10052
		// (get) Token: 0x0601DB43 RID: 121667 RVA: 0x008DDEBE File Offset: 0x008DC0BE
		// (set) Token: 0x0601DB44 RID: 121668 RVA: 0x008DDED2 File Offset: 0x008DC0D2
		public unsafe UButton BtnArrow_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BvbEffectItem_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbEffectItem_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002745 RID: 10053
		// (get) Token: 0x0601DB45 RID: 121669 RVA: 0x008DDEE7 File Offset: 0x008DC0E7
		// (set) Token: 0x0601DB46 RID: 121670 RVA: 0x008DDEFB File Offset: 0x008DC0FB
		public unsafe UVerticalBox PnlHideInfo
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UVerticalBox>(base.NativePtr / (IntPtr)sizeof(void*) + BvbEffectItem_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbEffectItem_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002746 RID: 10054
		// (get) Token: 0x0601DB47 RID: 121671 RVA: 0x008DDF10 File Offset: 0x008DC110
		// (set) Token: 0x0601DB48 RID: 121672 RVA: 0x008DDF24 File Offset: 0x008DC124
		public unsafe UImage TexTitleBg_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + BvbEffectItem_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbEffectItem_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002747 RID: 10055
		// (get) Token: 0x0601DB49 RID: 121673 RVA: 0x008DDF39 File Offset: 0x008DC139
		// (set) Token: 0x0601DB4A RID: 121674 RVA: 0x008DDF4D File Offset: 0x008DC14D
		public unsafe UTextBlock TxtDesc
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + BvbEffectItem_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbEffectItem_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002748 RID: 10056
		// (get) Token: 0x0601DB4B RID: 121675 RVA: 0x008DDF62 File Offset: 0x008DC162
		// (set) Token: 0x0601DB4C RID: 121676 RVA: 0x008DDF76 File Offset: 0x008DC176
		public unsafe UTextBlock TxtTitle_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + BvbEffectItem_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbEffectItem_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002749 RID: 10057
		// (get) Token: 0x0601DB4D RID: 121677 RVA: 0x008DDF8C File Offset: 0x008DC18C
		// (set) Token: 0x0601DB4E RID: 121678 RVA: 0x008DDFC5 File Offset: 0x008DC1C5
		[Nullable(1)]
		public TArray<BvbChildEffectItem_C> ChildEffectItemList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<BvbChildEffectItem_C> result;
				if ((result = this._ChildEffectItemList) == null)
				{
					result = (this._ChildEffectItemList = new TArray<BvbChildEffectItem_C>(base.NativePtr + (IntPtr)BvbEffectItem_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ChildEffectItemList.CopyAssign(value);
			}
		}

		// Token: 0x0601DB4F RID: 121679 RVA: 0x008DDFD3 File Offset: 0x008DC1D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CreateChildEffectItem()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbEffectItem_C.__CreateChildEffectItem_NativeFunctionPtr, null);
		}

		// Token: 0x0601DB50 RID: 121680 RVA: 0x008DDFE8 File Offset: 0x008DC1E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RefreshChildEffectList([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<string> TitleList, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<string> DescList)
		{
			BvbEffectItem_C.__RefreshChildEffectList_FunctionParams* ptr = stackalloc BvbEffectItem_C.__RefreshChildEffectList_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BvbEffectItem_C.__RefreshChildEffectList_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbEffectItem_C.__RefreshChildEffectList_NativeFunctionPtr, (void*)ptr, 1);
			TArray<string> tarray = TitleList;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->TitleList);
			}
			TArray<string> tarray2 = DescList;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->DescList);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbEffectItem_C.__RefreshChildEffectList_NativeFunctionPtr, (void*)ptr);
			TArray<string> tarray3 = TitleList;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->TitleList);
			}
			TArray<string> tarray4 = DescList;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->DescList);
			}
			UnrealReflectionUtils.DestroyStruct(BvbEffectItem_C.__RefreshChildEffectList_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DB51 RID: 121681 RVA: 0x008DE088 File Offset: 0x008DC288
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Refresh(BvbEffectItemData EffectItemData)
		{
			BvbEffectItem_C.__Refresh_FunctionParams* ptr = stackalloc BvbEffectItem_C.__Refresh_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BvbEffectItem_C.__Refresh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbEffectItem_C.__Refresh_NativeFunctionPtr, (void*)ptr, 1);
			if (EffectItemData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(BvbEffectItemData.StaticStruct(), &ptr->EffectItemData, EffectItemData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbEffectItem_C.__Refresh_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BvbEffectItem_C.__Refresh_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DB52 RID: 121682 RVA: 0x008DE0FD File Offset: 0x008DC2FD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFlodBtnClick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbEffectItem_C.__OnFlodBtnClick_NativeFunctionPtr, null);
		}

		// Token: 0x0601DB53 RID: 121683 RVA: 0x008DE111 File Offset: 0x008DC311
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BvbEffectItem_BtnArrow_2_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbEffectItem_C.__BndEvt__BvbEffectItem_BtnArrow_2_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x0601DB54 RID: 121684 RVA: 0x008DE128 File Offset: 0x008DC328
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BvbEffectItem(int EntryPoint)
		{
			BvbEffectItem_C.__ExecuteUbergraph_BvbEffectItem_FunctionParams* ptr = stackalloc BvbEffectItem_C.__ExecuteUbergraph_BvbEffectItem_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BvbEffectItem_C.__ExecuteUbergraph_BvbEffectItem_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbEffectItem_C.__ExecuteUbergraph_BvbEffectItem_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BvbEffectItem_C.__ExecuteUbergraph_BvbEffectItem_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DB55 RID: 121685 RVA: 0x008DE16F File Offset: 0x008DC36F
		protected BvbEffectItem_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E8C8 RID: 59592
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Module/ActiveDebug/BvbEffectItem.BvbEffectItem_C";

		// Token: 0x0400E8C9 RID: 59593
		private static IntPtr _ClassPtr;

		// Token: 0x0400E8CA RID: 59594
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E8CB RID: 59595
		internal static int __PropertyOffset_0;

		// Token: 0x0400E8CC RID: 59596
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400E8CD RID: 59597
		internal static int __PropertyOffset_1;

		// Token: 0x0400E8CE RID: 59598
		internal static int __PropertyOffset_2;

		// Token: 0x0400E8CF RID: 59599
		internal static int __PropertyOffset_3;

		// Token: 0x0400E8D0 RID: 59600
		internal static int __PropertyOffset_4;

		// Token: 0x0400E8D1 RID: 59601
		internal static int __PropertyOffset_5;

		// Token: 0x0400E8D2 RID: 59602
		internal static int __PropertyOffset_6;

		// Token: 0x0400E8D3 RID: 59603
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BvbChildEffectItem_C> _ChildEffectItemList;

		// Token: 0x0400E8D4 RID: 59604
		private static IntPtr __CreateChildEffectItem_NativeFunctionPtr;

		// Token: 0x0400E8D5 RID: 59605
		private static IntPtr __RefreshChildEffectList_NativeFunctionPtr;

		// Token: 0x0400E8D6 RID: 59606
		private static IntPtr __Refresh_NativeFunctionPtr;

		// Token: 0x0400E8D7 RID: 59607
		private static IntPtr __OnFlodBtnClick_NativeFunctionPtr;

		// Token: 0x0400E8D8 RID: 59608
		private static IntPtr __BndEvt__BvbEffectItem_BtnArrow_2_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E8D9 RID: 59609
		private static IntPtr __ExecuteUbergraph_BvbEffectItem_NativeFunctionPtr;

		// Token: 0x020096BB RID: 38587
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __RefreshChildEffectList_FunctionParams
		{
			// Token: 0x04031B92 RID: 203666
			[FieldOffset(0)]
			public byte TitleList;

			// Token: 0x04031B93 RID: 203667
			[FieldOffset(16)]
			public byte DescList;
		}

		// Token: 0x020096BC RID: 38588
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __Refresh_FunctionParams
		{
			// Token: 0x04031B94 RID: 203668
			[FieldOffset(0)]
			public byte EffectItemData;
		}

		// Token: 0x020096BD RID: 38589
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BvbEffectItem_FunctionParams
		{
			// Token: 0x04031B95 RID: 203669
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
