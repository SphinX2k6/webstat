using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.UI.DebugWuYinQu
{
	// Token: 0x02003CA0 RID: 15520
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/UI/DebugWuYinQu/WBP_DebugWuYinQuItem.WBP_DebugWuYinQuItem_C")]
	[UnrealStructLayout(1192, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1192)]
	public class WBP_DebugWuYinQuItem_C : UUserWidget, IUnrealUObject, IUnrealObject, IUserObjectListEntry, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0602491B RID: 149787 RVA: 0x009A12C0 File Offset: 0x0099F4C0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_DebugWuYinQuItem_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/UI/DebugWuYinQu/WBP_DebugWuYinQuItem.WBP_DebugWuYinQuItem_C");
			}
			return WBP_DebugWuYinQuItem_C._ClassPtr;
		}

		// Token: 0x0602491C RID: 149788 RVA: 0x009A12E4 File Offset: 0x0099F4E4
		int IUserObjectListEntry.InterfaceOffset()
		{
			return WBP_DebugWuYinQuItem_C.__InterfaceOffset_IUserObjectListEntry;
		}

		// Token: 0x0602491D RID: 149789 RVA: 0x009A12EC File Offset: 0x0099F4EC
		public WBP_DebugWuYinQuItem_C() : this(BuiltinUtils.AllocNativeUObject(WBP_DebugWuYinQuItem_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602491E RID: 149790 RVA: 0x009A1314 File Offset: 0x0099F514
		[NullableContext(1)]
		public WBP_DebugWuYinQuItem_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_DebugWuYinQuItem_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004CC6 RID: 19654
		// (get) Token: 0x0602491F RID: 149791 RVA: 0x009A1348 File Offset: 0x0099F548
		// (set) Token: 0x06024920 RID: 149792 RVA: 0x009A1381 File Offset: 0x0099F581
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)WBP_DebugWuYinQuItem_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)WBP_DebugWuYinQuItem_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004CC7 RID: 19655
		// (get) Token: 0x06024921 RID: 149793 RVA: 0x009A13A2 File Offset: 0x0099F5A2
		// (set) Token: 0x06024922 RID: 149794 RVA: 0x009A13B6 File Offset: 0x0099F5B6
		[Nullable(2)]
		public unsafe UButton Button_100
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugWuYinQuItem_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugWuYinQuItem_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004CC8 RID: 19656
		// (get) Token: 0x06024923 RID: 149795 RVA: 0x009A13CB File Offset: 0x0099F5CB
		// (set) Token: 0x06024924 RID: 149796 RVA: 0x009A13DF File Offset: 0x0099F5DF
		[Nullable(2)]
		public unsafe UImage Image_76
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugWuYinQuItem_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugWuYinQuItem_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x06024925 RID: 149797 RVA: 0x009A13F4 File Offset: 0x0099F5F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BP_OnEntryReleased()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugWuYinQuItem_C.__BP_OnEntryReleased_NativeFunctionPtr, null);
		}

		// Token: 0x06024926 RID: 149798 RVA: 0x009A1408 File Offset: 0x0099F608
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BP_OnEntryReleased_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugWuYinQuItem_C.__BP_OnEntryReleased_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024927 RID: 149799 RVA: 0x009A1420 File Offset: 0x0099F620
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BP_OnItemExpansionChanged(bool bIsExpanded)
		{
			WBP_DebugWuYinQuItem_C.__BP_OnItemExpansionChanged_FunctionParams* ptr = stackalloc WBP_DebugWuYinQuItem_C.__BP_OnItemExpansionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_DebugWuYinQuItem_C.__BP_OnItemExpansionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugWuYinQuItem_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsExpanded = bIsExpanded;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugWuYinQuItem_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024928 RID: 149800 RVA: 0x009A1468 File Offset: 0x0099F668
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BP_OnItemExpansionChanged_Implementation(bool bIsExpanded)
		{
			WBP_DebugWuYinQuItem_C.__BP_OnItemExpansionChanged_FunctionParams* ptr = stackalloc WBP_DebugWuYinQuItem_C.__BP_OnItemExpansionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_DebugWuYinQuItem_C.__BP_OnItemExpansionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugWuYinQuItem_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsExpanded = bIsExpanded;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugWuYinQuItem_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024929 RID: 149801 RVA: 0x009A14B0 File Offset: 0x0099F6B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BP_OnItemSelectionChanged(bool bIsSelected)
		{
			WBP_DebugWuYinQuItem_C.__BP_OnItemSelectionChanged_FunctionParams* ptr = stackalloc WBP_DebugWuYinQuItem_C.__BP_OnItemSelectionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_DebugWuYinQuItem_C.__BP_OnItemSelectionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugWuYinQuItem_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsSelected = bIsSelected;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugWuYinQuItem_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602492A RID: 149802 RVA: 0x009A14F8 File Offset: 0x0099F6F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BP_OnItemSelectionChanged_Implementation(bool bIsSelected)
		{
			WBP_DebugWuYinQuItem_C.__BP_OnItemSelectionChanged_FunctionParams* ptr = stackalloc WBP_DebugWuYinQuItem_C.__BP_OnItemSelectionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_DebugWuYinQuItem_C.__BP_OnItemSelectionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugWuYinQuItem_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsSelected = bIsSelected;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugWuYinQuItem_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602492B RID: 149803 RVA: 0x009A1540 File Offset: 0x0099F740
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnListItemObjectSet(UObject ListItemObject)
		{
			WBP_DebugWuYinQuItem_C.__OnListItemObjectSet_FunctionParams* ptr = stackalloc WBP_DebugWuYinQuItem_C.__OnListItemObjectSet_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(WBP_DebugWuYinQuItem_C.__OnListItemObjectSet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugWuYinQuItem_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ListItemObject = ((ListItemObject != null) ? ListItemObject.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugWuYinQuItem_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602492C RID: 149804 RVA: 0x009A1598 File Offset: 0x0099F798
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnListItemObjectSet_Implementation(UObject ListItemObject)
		{
			WBP_DebugWuYinQuItem_C.__OnListItemObjectSet_FunctionParams* ptr = stackalloc WBP_DebugWuYinQuItem_C.__OnListItemObjectSet_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(WBP_DebugWuYinQuItem_C.__OnListItemObjectSet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugWuYinQuItem_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ListItemObject = ((ListItemObject != null) ? ListItemObject.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugWuYinQuItem_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602492D RID: 149805 RVA: 0x009A15F0 File Offset: 0x0099F7F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_WBP_DebugWuYinQuItem(int EntryPoint)
		{
			WBP_DebugWuYinQuItem_C.__ExecuteUbergraph_WBP_DebugWuYinQuItem_FunctionParams* ptr = stackalloc WBP_DebugWuYinQuItem_C.__ExecuteUbergraph_WBP_DebugWuYinQuItem_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(WBP_DebugWuYinQuItem_C.__ExecuteUbergraph_WBP_DebugWuYinQuItem_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugWuYinQuItem_C.__ExecuteUbergraph_WBP_DebugWuYinQuItem_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugWuYinQuItem_C.__ExecuteUbergraph_WBP_DebugWuYinQuItem_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602492E RID: 149806 RVA: 0x009A1637 File Offset: 0x0099F837
		protected WBP_DebugWuYinQuItem_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012BE3 RID: 76771
		internal static int __InterfaceOffset_IUserObjectListEntry;

		// Token: 0x04012BE4 RID: 76772
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/UI/DebugWuYinQu/WBP_DebugWuYinQuItem.WBP_DebugWuYinQuItem_C";

		// Token: 0x04012BE5 RID: 76773
		private static IntPtr _ClassPtr;

		// Token: 0x04012BE6 RID: 76774
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012BE7 RID: 76775
		internal static int __PropertyOffset_0;

		// Token: 0x04012BE8 RID: 76776
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012BE9 RID: 76777
		internal static int __PropertyOffset_1;

		// Token: 0x04012BEA RID: 76778
		internal static int __PropertyOffset_2;

		// Token: 0x04012BEB RID: 76779
		private static IntPtr __BP_OnEntryReleased_NativeFunctionPtr;

		// Token: 0x04012BEC RID: 76780
		private static IntPtr __BP_OnItemExpansionChanged_NativeFunctionPtr;

		// Token: 0x04012BED RID: 76781
		private static IntPtr __BP_OnItemSelectionChanged_NativeFunctionPtr;

		// Token: 0x04012BEE RID: 76782
		private static IntPtr __OnListItemObjectSet_NativeFunctionPtr;

		// Token: 0x04012BEF RID: 76783
		private static IntPtr __ExecuteUbergraph_WBP_DebugWuYinQuItem_NativeFunctionPtr;

		// Token: 0x02009E0D RID: 40461
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __BP_OnItemExpansionChanged_FunctionParams
		{
			// Token: 0x04032854 RID: 206932
			[FieldOffset(0)]
			public bool bIsExpanded;
		}

		// Token: 0x02009E0E RID: 40462
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __BP_OnItemSelectionChanged_FunctionParams
		{
			// Token: 0x04032855 RID: 206933
			[FieldOffset(0)]
			public bool bIsSelected;
		}

		// Token: 0x02009E0F RID: 40463
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnListItemObjectSet_FunctionParams
		{
			// Token: 0x04032856 RID: 206934
			[FieldOffset(0)]
			public IntPtr ListItemObject;
		}

		// Token: 0x02009E10 RID: 40464
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_WBP_DebugWuYinQuItem_FunctionParams
		{
			// Token: 0x04032857 RID: 206935
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
