using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.UI.DebugDataLayer
{
	// Token: 0x02003CA6 RID: 15526
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/UI/DebugDataLayer/WBP_DebugDataLayerListEntry.WBP_DebugDataLayerListEntry_C")]
	[UnrealStructLayout(1232, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1232)]
	public class WBP_DebugDataLayerListEntry_C : UUserWidget, IUnrealUObject, IUnrealObject, IUserObjectListEntry, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x060249A3 RID: 149923 RVA: 0x009A256A File Offset: 0x009A076A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_DebugDataLayerListEntry_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/UI/DebugDataLayer/WBP_DebugDataLayerListEntry.WBP_DebugDataLayerListEntry_C");
			}
			return WBP_DebugDataLayerListEntry_C._ClassPtr;
		}

		// Token: 0x060249A4 RID: 149924 RVA: 0x009A258E File Offset: 0x009A078E
		int IUserObjectListEntry.InterfaceOffset()
		{
			return WBP_DebugDataLayerListEntry_C.__InterfaceOffset_IUserObjectListEntry;
		}

		// Token: 0x060249A5 RID: 149925 RVA: 0x009A2598 File Offset: 0x009A0798
		public WBP_DebugDataLayerListEntry_C() : this(BuiltinUtils.AllocNativeUObject(WBP_DebugDataLayerListEntry_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060249A6 RID: 149926 RVA: 0x009A25C0 File Offset: 0x009A07C0
		[NullableContext(1)]
		public WBP_DebugDataLayerListEntry_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_DebugDataLayerListEntry_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004CED RID: 19693
		// (get) Token: 0x060249A7 RID: 149927 RVA: 0x009A25F4 File Offset: 0x009A07F4
		// (set) Token: 0x060249A8 RID: 149928 RVA: 0x009A262D File Offset: 0x009A082D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)WBP_DebugDataLayerListEntry_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)WBP_DebugDataLayerListEntry_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004CEE RID: 19694
		// (get) Token: 0x060249A9 RID: 149929 RVA: 0x009A264E File Offset: 0x009A084E
		// (set) Token: 0x060249AA RID: 149930 RVA: 0x009A2662 File Offset: 0x009A0862
		public unsafe UButton BtnClose
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerListEntry_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerListEntry_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004CEF RID: 19695
		// (get) Token: 0x060249AB RID: 149931 RVA: 0x009A2677 File Offset: 0x009A0877
		// (set) Token: 0x060249AC RID: 149932 RVA: 0x009A268B File Offset: 0x009A088B
		public unsafe UButton BtnShow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerListEntry_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerListEntry_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004CF0 RID: 19696
		// (get) Token: 0x060249AD RID: 149933 RVA: 0x009A26A0 File Offset: 0x009A08A0
		// (set) Token: 0x060249AE RID: 149934 RVA: 0x009A26B4 File Offset: 0x009A08B4
		public unsafe UTextBlock DataLayerName
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerListEntry_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerListEntry_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004CF1 RID: 19697
		// (get) Token: 0x060249AF RID: 149935 RVA: 0x009A26C9 File Offset: 0x009A08C9
		// (set) Token: 0x060249B0 RID: 149936 RVA: 0x009A26DD File Offset: 0x009A08DD
		public unsafe UTextBlock DataLayerState
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerListEntry_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerListEntry_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004CF2 RID: 19698
		// (get) Token: 0x060249B1 RID: 149937 RVA: 0x009A26F2 File Offset: 0x009A08F2
		// (set) Token: 0x060249B2 RID: 149938 RVA: 0x009A2706 File Offset: 0x009A0906
		public unsafe UImage Image_86
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerListEntry_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerListEntry_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004CF3 RID: 19699
		// (get) Token: 0x060249B3 RID: 149939 RVA: 0x009A271B File Offset: 0x009A091B
		// (set) Token: 0x060249B4 RID: 149940 RVA: 0x009A272B File Offset: 0x009A092B
		public unsafe bool HasOverrideProperties
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_DebugDataLayerListEntry_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_DebugDataLayerListEntry_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004CF4 RID: 19700
		// (get) Token: 0x060249B5 RID: 149941 RVA: 0x009A273C File Offset: 0x009A093C
		// (set) Token: 0x060249B6 RID: 149942 RVA: 0x009A2750 File Offset: 0x009A0950
		public unsafe DebugDataLayerObject_C DebugDataLayerObject
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<DebugDataLayerObject_C>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerListEntry_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerListEntry_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x060249B7 RID: 149943 RVA: 0x009A2765 File Offset: 0x009A0965
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePanel()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugDataLayerListEntry_C.__UpdatePanel_NativeFunctionPtr, null);
		}

		// Token: 0x060249B8 RID: 149944 RVA: 0x009A277C File Offset: 0x009A097C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetItemInfo(bool IsOverrideType, FPostprocessGIDebugInfo InputPostInfo)
		{
			WBP_DebugDataLayerListEntry_C.__SetItemInfo_FunctionParams* ptr = stackalloc WBP_DebugDataLayerListEntry_C.__SetItemInfo_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(WBP_DebugDataLayerListEntry_C.__SetItemInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugDataLayerListEntry_C.__SetItemInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsOverrideType = IsOverrideType;
			if (InputPostInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPostprocessGIDebugInfo.StaticStruct(), &ptr->InputPostInfo, InputPostInfo.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugDataLayerListEntry_C.__SetItemInfo_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(WBP_DebugDataLayerListEntry_C.__SetItemInfo_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060249B9 RID: 149945 RVA: 0x009A27F8 File Offset: 0x009A09F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BP_OnEntryReleased()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugDataLayerListEntry_C.__BP_OnEntryReleased_NativeFunctionPtr, null);
		}

		// Token: 0x060249BA RID: 149946 RVA: 0x009A280C File Offset: 0x009A0A0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BP_OnEntryReleased_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugDataLayerListEntry_C.__BP_OnEntryReleased_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060249BB RID: 149947 RVA: 0x009A2824 File Offset: 0x009A0A24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BP_OnItemExpansionChanged(bool bIsExpanded)
		{
			WBP_DebugDataLayerListEntry_C.__BP_OnItemExpansionChanged_FunctionParams* ptr = stackalloc WBP_DebugDataLayerListEntry_C.__BP_OnItemExpansionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_DebugDataLayerListEntry_C.__BP_OnItemExpansionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugDataLayerListEntry_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsExpanded = bIsExpanded;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugDataLayerListEntry_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060249BC RID: 149948 RVA: 0x009A286C File Offset: 0x009A0A6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BP_OnItemExpansionChanged_Implementation(bool bIsExpanded)
		{
			WBP_DebugDataLayerListEntry_C.__BP_OnItemExpansionChanged_FunctionParams* ptr = stackalloc WBP_DebugDataLayerListEntry_C.__BP_OnItemExpansionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_DebugDataLayerListEntry_C.__BP_OnItemExpansionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugDataLayerListEntry_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsExpanded = bIsExpanded;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugDataLayerListEntry_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060249BD RID: 149949 RVA: 0x009A28B4 File Offset: 0x009A0AB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BP_OnItemSelectionChanged(bool bIsSelected)
		{
			WBP_DebugDataLayerListEntry_C.__BP_OnItemSelectionChanged_FunctionParams* ptr = stackalloc WBP_DebugDataLayerListEntry_C.__BP_OnItemSelectionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_DebugDataLayerListEntry_C.__BP_OnItemSelectionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugDataLayerListEntry_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsSelected = bIsSelected;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugDataLayerListEntry_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060249BE RID: 149950 RVA: 0x009A28FC File Offset: 0x009A0AFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BP_OnItemSelectionChanged_Implementation(bool bIsSelected)
		{
			WBP_DebugDataLayerListEntry_C.__BP_OnItemSelectionChanged_FunctionParams* ptr = stackalloc WBP_DebugDataLayerListEntry_C.__BP_OnItemSelectionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_DebugDataLayerListEntry_C.__BP_OnItemSelectionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugDataLayerListEntry_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsSelected = bIsSelected;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugDataLayerListEntry_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060249BF RID: 149951 RVA: 0x009A2944 File Offset: 0x009A0B44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnListItemObjectSet(UObject ListItemObject)
		{
			WBP_DebugDataLayerListEntry_C.__OnListItemObjectSet_FunctionParams* ptr = stackalloc WBP_DebugDataLayerListEntry_C.__OnListItemObjectSet_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(WBP_DebugDataLayerListEntry_C.__OnListItemObjectSet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugDataLayerListEntry_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ListItemObject = ((ListItemObject != null) ? ListItemObject.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugDataLayerListEntry_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060249C0 RID: 149952 RVA: 0x009A299C File Offset: 0x009A0B9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnListItemObjectSet_Implementation(UObject ListItemObject)
		{
			WBP_DebugDataLayerListEntry_C.__OnListItemObjectSet_FunctionParams* ptr = stackalloc WBP_DebugDataLayerListEntry_C.__OnListItemObjectSet_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(WBP_DebugDataLayerListEntry_C.__OnListItemObjectSet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugDataLayerListEntry_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ListItemObject = ((ListItemObject != null) ? ListItemObject.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugDataLayerListEntry_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060249C1 RID: 149953 RVA: 0x009A29F2 File Offset: 0x009A0BF2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__WBP_DebugDataLayerListEntry_BtnShow_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugDataLayerListEntry_C.__BndEvt__WBP_DebugDataLayerListEntry_BtnShow_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060249C2 RID: 149954 RVA: 0x009A2A06 File Offset: 0x009A0C06
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__WBP_DebugDataLayerListEntry_BtnClose_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugDataLayerListEntry_C.__BndEvt__WBP_DebugDataLayerListEntry_BtnClose_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060249C3 RID: 149955 RVA: 0x009A2A1C File Offset: 0x009A0C1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_WBP_DebugDataLayerListEntry(int EntryPoint)
		{
			WBP_DebugDataLayerListEntry_C.__ExecuteUbergraph_WBP_DebugDataLayerListEntry_FunctionParams* ptr = stackalloc WBP_DebugDataLayerListEntry_C.__ExecuteUbergraph_WBP_DebugDataLayerListEntry_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(WBP_DebugDataLayerListEntry_C.__ExecuteUbergraph_WBP_DebugDataLayerListEntry_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugDataLayerListEntry_C.__ExecuteUbergraph_WBP_DebugDataLayerListEntry_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugDataLayerListEntry_C.__ExecuteUbergraph_WBP_DebugDataLayerListEntry_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060249C4 RID: 149956 RVA: 0x009A2A63 File Offset: 0x009A0C63
		protected WBP_DebugDataLayerListEntry_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012C3A RID: 76858
		internal static int __InterfaceOffset_IUserObjectListEntry;

		// Token: 0x04012C3B RID: 76859
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/UI/DebugDataLayer/WBP_DebugDataLayerListEntry.WBP_DebugDataLayerListEntry_C";

		// Token: 0x04012C3C RID: 76860
		private static IntPtr _ClassPtr;

		// Token: 0x04012C3D RID: 76861
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012C3E RID: 76862
		internal static int __PropertyOffset_0;

		// Token: 0x04012C3F RID: 76863
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012C40 RID: 76864
		internal static int __PropertyOffset_1;

		// Token: 0x04012C41 RID: 76865
		internal static int __PropertyOffset_2;

		// Token: 0x04012C42 RID: 76866
		internal static int __PropertyOffset_3;

		// Token: 0x04012C43 RID: 76867
		internal static int __PropertyOffset_4;

		// Token: 0x04012C44 RID: 76868
		internal static int __PropertyOffset_5;

		// Token: 0x04012C45 RID: 76869
		internal static int __PropertyOffset_6;

		// Token: 0x04012C46 RID: 76870
		internal static int __PropertyOffset_7;

		// Token: 0x04012C47 RID: 76871
		private static IntPtr __UpdatePanel_NativeFunctionPtr;

		// Token: 0x04012C48 RID: 76872
		private static IntPtr __SetItemInfo_NativeFunctionPtr;

		// Token: 0x04012C49 RID: 76873
		private static IntPtr __BP_OnEntryReleased_NativeFunctionPtr;

		// Token: 0x04012C4A RID: 76874
		private static IntPtr __BP_OnItemExpansionChanged_NativeFunctionPtr;

		// Token: 0x04012C4B RID: 76875
		private static IntPtr __BP_OnItemSelectionChanged_NativeFunctionPtr;

		// Token: 0x04012C4C RID: 76876
		private static IntPtr __OnListItemObjectSet_NativeFunctionPtr;

		// Token: 0x04012C4D RID: 76877
		private static IntPtr __BndEvt__WBP_DebugDataLayerListEntry_BtnShow_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012C4E RID: 76878
		private static IntPtr __BndEvt__WBP_DebugDataLayerListEntry_BtnClose_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012C4F RID: 76879
		private static IntPtr __ExecuteUbergraph_WBP_DebugDataLayerListEntry_NativeFunctionPtr;

		// Token: 0x02009E1B RID: 40475
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __SetItemInfo_FunctionParams
		{
			// Token: 0x04032865 RID: 206949
			[FieldOffset(0)]
			public bool IsOverrideType;

			// Token: 0x04032866 RID: 206950
			[FieldOffset(8)]
			public byte InputPostInfo;
		}

		// Token: 0x02009E1C RID: 40476
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __BP_OnItemExpansionChanged_FunctionParams
		{
			// Token: 0x04032867 RID: 206951
			[FieldOffset(0)]
			public bool bIsExpanded;
		}

		// Token: 0x02009E1D RID: 40477
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __BP_OnItemSelectionChanged_FunctionParams
		{
			// Token: 0x04032868 RID: 206952
			[FieldOffset(0)]
			public bool bIsSelected;
		}

		// Token: 0x02009E1E RID: 40478
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnListItemObjectSet_FunctionParams
		{
			// Token: 0x04032869 RID: 206953
			[FieldOffset(0)]
			public IntPtr ListItemObject;
		}

		// Token: 0x02009E1F RID: 40479
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_WBP_DebugDataLayerListEntry_FunctionParams
		{
			// Token: 0x0403286A RID: 206954
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
