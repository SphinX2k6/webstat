using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.ActiveDebug
{
	// Token: 0x0200398A RID: 14730
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/Module/ActiveDebug/BvbChildEffectItem.BvbChildEffectItem_C")]
	[UnrealStructLayout(1216, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1216)]
	public class BvbChildEffectItem_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DB1A RID: 121626 RVA: 0x008DD9D4 File Offset: 0x008DBBD4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BvbChildEffectItem_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Module/ActiveDebug/BvbChildEffectItem.BvbChildEffectItem_C");
			}
			return BvbChildEffectItem_C._ClassPtr;
		}

		// Token: 0x0601DB1B RID: 121627 RVA: 0x008DD9F8 File Offset: 0x008DBBF8
		public BvbChildEffectItem_C() : this(BuiltinUtils.AllocNativeUObject(BvbChildEffectItem_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DB1C RID: 121628 RVA: 0x008DDA20 File Offset: 0x008DBC20
		[NullableContext(1)]
		public BvbChildEffectItem_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BvbChildEffectItem_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002739 RID: 10041
		// (get) Token: 0x0601DB1D RID: 121629 RVA: 0x008DDA54 File Offset: 0x008DBC54
		// (set) Token: 0x0601DB1E RID: 121630 RVA: 0x008DDA8D File Offset: 0x008DBC8D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BvbChildEffectItem_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BvbChildEffectItem_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700273A RID: 10042
		// (get) Token: 0x0601DB1F RID: 121631 RVA: 0x008DDAAE File Offset: 0x008DBCAE
		// (set) Token: 0x0601DB20 RID: 121632 RVA: 0x008DDAC2 File Offset: 0x008DBCC2
		public unsafe UButton BtnArrow_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BvbChildEffectItem_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbChildEffectItem_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700273B RID: 10043
		// (get) Token: 0x0601DB21 RID: 121633 RVA: 0x008DDAD7 File Offset: 0x008DBCD7
		// (set) Token: 0x0601DB22 RID: 121634 RVA: 0x008DDAEB File Offset: 0x008DBCEB
		public unsafe UVerticalBox PnlHideInfo
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UVerticalBox>(base.NativePtr / (IntPtr)sizeof(void*) + BvbChildEffectItem_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbChildEffectItem_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700273C RID: 10044
		// (get) Token: 0x0601DB23 RID: 121635 RVA: 0x008DDB00 File Offset: 0x008DBD00
		// (set) Token: 0x0601DB24 RID: 121636 RVA: 0x008DDB14 File Offset: 0x008DBD14
		public unsafe UImage TexTitleBg_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + BvbChildEffectItem_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbChildEffectItem_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700273D RID: 10045
		// (get) Token: 0x0601DB25 RID: 121637 RVA: 0x008DDB29 File Offset: 0x008DBD29
		// (set) Token: 0x0601DB26 RID: 121638 RVA: 0x008DDB3D File Offset: 0x008DBD3D
		public unsafe UTextBlock TxtDesc
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + BvbChildEffectItem_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbChildEffectItem_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700273E RID: 10046
		// (get) Token: 0x0601DB27 RID: 121639 RVA: 0x008DDB52 File Offset: 0x008DBD52
		// (set) Token: 0x0601DB28 RID: 121640 RVA: 0x008DDB66 File Offset: 0x008DBD66
		public unsafe UTextBlock TxtTitle_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + BvbChildEffectItem_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BvbChildEffectItem_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x0601DB29 RID: 121641 RVA: 0x008DDB7C File Offset: 0x008DBD7C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Refresh(string Title, string Desc)
		{
			BvbChildEffectItem_C.__Refresh_FunctionParams* ptr = stackalloc BvbChildEffectItem_C.__Refresh_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BvbChildEffectItem_C.__Refresh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbChildEffectItem_C.__Refresh_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Title), Title);
			FString.CopyFrom((void*)(&ptr->Desc), Desc);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbChildEffectItem_C.__Refresh_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BvbChildEffectItem_C.__Refresh_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DB2A RID: 121642 RVA: 0x008DDBE9 File Offset: 0x008DBDE9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFlodBtnClick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbChildEffectItem_C.__OnFlodBtnClick_NativeFunctionPtr, null);
		}

		// Token: 0x0601DB2B RID: 121643 RVA: 0x008DDBFD File Offset: 0x008DBDFD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BvbEffectItem_BtnArrow_2_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BvbChildEffectItem_C.__BndEvt__BvbEffectItem_BtnArrow_2_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x0601DB2C RID: 121644 RVA: 0x008DDC14 File Offset: 0x008DBE14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BvbChildEffectItem(int EntryPoint)
		{
			BvbChildEffectItem_C.__ExecuteUbergraph_BvbChildEffectItem_FunctionParams* ptr = stackalloc BvbChildEffectItem_C.__ExecuteUbergraph_BvbChildEffectItem_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BvbChildEffectItem_C.__ExecuteUbergraph_BvbChildEffectItem_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BvbChildEffectItem_C.__ExecuteUbergraph_BvbChildEffectItem_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BvbChildEffectItem_C.__ExecuteUbergraph_BvbChildEffectItem_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DB2D RID: 121645 RVA: 0x008DDC5B File Offset: 0x008DBE5B
		protected BvbChildEffectItem_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E8B2 RID: 59570
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Module/ActiveDebug/BvbChildEffectItem.BvbChildEffectItem_C";

		// Token: 0x0400E8B3 RID: 59571
		private static IntPtr _ClassPtr;

		// Token: 0x0400E8B4 RID: 59572
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E8B5 RID: 59573
		internal static int __PropertyOffset_0;

		// Token: 0x0400E8B6 RID: 59574
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400E8B7 RID: 59575
		internal static int __PropertyOffset_1;

		// Token: 0x0400E8B8 RID: 59576
		internal static int __PropertyOffset_2;

		// Token: 0x0400E8B9 RID: 59577
		internal static int __PropertyOffset_3;

		// Token: 0x0400E8BA RID: 59578
		internal static int __PropertyOffset_4;

		// Token: 0x0400E8BB RID: 59579
		internal static int __PropertyOffset_5;

		// Token: 0x0400E8BC RID: 59580
		private static IntPtr __Refresh_NativeFunctionPtr;

		// Token: 0x0400E8BD RID: 59581
		private static IntPtr __OnFlodBtnClick_NativeFunctionPtr;

		// Token: 0x0400E8BE RID: 59582
		private static IntPtr __BndEvt__BvbEffectItem_BtnArrow_2_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E8BF RID: 59583
		private static IntPtr __ExecuteUbergraph_BvbChildEffectItem_NativeFunctionPtr;

		// Token: 0x020096B9 RID: 38585
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __Refresh_FunctionParams
		{
			// Token: 0x04031B8F RID: 203663
			[FieldOffset(0)]
			public FString Title;

			// Token: 0x04031B90 RID: 203664
			[FieldOffset(16)]
			public FString Desc;
		}

		// Token: 0x020096BA RID: 38586
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BvbChildEffectItem_FunctionParams
		{
			// Token: 0x04031B91 RID: 203665
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
