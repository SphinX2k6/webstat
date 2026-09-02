using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.UI.DebugPostProcess
{
	// Token: 0x02003CA3 RID: 15523
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/UI/DebugPostProcess/WBP_DebugPostProcessListEntry.WBP_DebugPostProcessListEntry_C")]
	[UnrealStructLayout(1480, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1480)]
	public class WBP_DebugPostProcessListEntry_C : UUserWidget, IUnrealUObject, IUnrealObject, IUserObjectListEntry, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0602494B RID: 149835 RVA: 0x009A1A28 File Offset: 0x0099FC28
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_DebugPostProcessListEntry_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/UI/DebugPostProcess/WBP_DebugPostProcessListEntry.WBP_DebugPostProcessListEntry_C");
			}
			return WBP_DebugPostProcessListEntry_C._ClassPtr;
		}

		// Token: 0x0602494C RID: 149836 RVA: 0x009A1A4C File Offset: 0x0099FC4C
		int IUserObjectListEntry.InterfaceOffset()
		{
			return WBP_DebugPostProcessListEntry_C.__InterfaceOffset_IUserObjectListEntry;
		}

		// Token: 0x0602494D RID: 149837 RVA: 0x009A1A54 File Offset: 0x0099FC54
		public WBP_DebugPostProcessListEntry_C() : this(BuiltinUtils.AllocNativeUObject(WBP_DebugPostProcessListEntry_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602494E RID: 149838 RVA: 0x009A1A7C File Offset: 0x0099FC7C
		[NullableContext(1)]
		public WBP_DebugPostProcessListEntry_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_DebugPostProcessListEntry_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004CD0 RID: 19664
		// (get) Token: 0x0602494F RID: 149839 RVA: 0x009A1AB0 File Offset: 0x0099FCB0
		// (set) Token: 0x06024950 RID: 149840 RVA: 0x009A1AE9 File Offset: 0x0099FCE9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)WBP_DebugPostProcessListEntry_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)WBP_DebugPostProcessListEntry_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004CD1 RID: 19665
		// (get) Token: 0x06024951 RID: 149841 RVA: 0x009A1B0A File Offset: 0x0099FD0A
		// (set) Token: 0x06024952 RID: 149842 RVA: 0x009A1B1E File Offset: 0x0099FD1E
		public unsafe UTextBlock ActorName
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004CD2 RID: 19666
		// (get) Token: 0x06024953 RID: 149843 RVA: 0x009A1B33 File Offset: 0x0099FD33
		// (set) Token: 0x06024954 RID: 149844 RVA: 0x009A1B47 File Offset: 0x0099FD47
		public unsafe UImage BG
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004CD3 RID: 19667
		// (get) Token: 0x06024955 RID: 149845 RVA: 0x009A1B5C File Offset: 0x0099FD5C
		// (set) Token: 0x06024956 RID: 149846 RVA: 0x009A1B70 File Offset: 0x0099FD70
		public unsafe UTextBlock BlendWeight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004CD4 RID: 19668
		// (get) Token: 0x06024957 RID: 149847 RVA: 0x009A1B85 File Offset: 0x0099FD85
		// (set) Token: 0x06024958 RID: 149848 RVA: 0x009A1B99 File Offset: 0x0099FD99
		public unsafe UButton BtnDetail
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004CD5 RID: 19669
		// (get) Token: 0x06024959 RID: 149849 RVA: 0x009A1BAE File Offset: 0x0099FDAE
		// (set) Token: 0x0602495A RID: 149850 RVA: 0x009A1BC2 File Offset: 0x0099FDC2
		public unsafe UButton BtnJump
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004CD6 RID: 19670
		// (get) Token: 0x0602495B RID: 149851 RVA: 0x009A1BD7 File Offset: 0x0099FDD7
		// (set) Token: 0x0602495C RID: 149852 RVA: 0x009A1BEB File Offset: 0x0099FDEB
		public unsafe UTextBlock Component
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004CD7 RID: 19671
		// (get) Token: 0x0602495D RID: 149853 RVA: 0x009A1C00 File Offset: 0x0099FE00
		// (set) Token: 0x0602495E RID: 149854 RVA: 0x009A1C14 File Offset: 0x0099FE14
		public unsafe UTextBlock IsUnbound
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004CD8 RID: 19672
		// (get) Token: 0x0602495F RID: 149855 RVA: 0x009A1C29 File Offset: 0x0099FE29
		// (set) Token: 0x06024960 RID: 149856 RVA: 0x009A1C3D File Offset: 0x0099FE3D
		public unsafe UTextBlock IsVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004CD9 RID: 19673
		// (get) Token: 0x06024961 RID: 149857 RVA: 0x009A1C52 File Offset: 0x0099FE52
		// (set) Token: 0x06024962 RID: 149858 RVA: 0x009A1C66 File Offset: 0x0099FE66
		public unsafe UTextBlock LBlendWeight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004CDA RID: 19674
		// (get) Token: 0x06024963 RID: 149859 RVA: 0x009A1C7B File Offset: 0x0099FE7B
		// (set) Token: 0x06024964 RID: 149860 RVA: 0x009A1C8F File Offset: 0x0099FE8F
		public unsafe UTextBlock OverrideProperties
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004CDB RID: 19675
		// (get) Token: 0x06024965 RID: 149861 RVA: 0x009A1CA4 File Offset: 0x0099FEA4
		// (set) Token: 0x06024966 RID: 149862 RVA: 0x009A1CB8 File Offset: 0x0099FEB8
		public unsafe UTextBlock Pri
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004CDC RID: 19676
		// (get) Token: 0x06024967 RID: 149863 RVA: 0x009A1CCD File Offset: 0x0099FECD
		// (set) Token: 0x06024968 RID: 149864 RVA: 0x009A1CE1 File Offset: 0x0099FEE1
		public unsafe UTextBlock TxtPropertiesBlock
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17004CDD RID: 19677
		// (get) Token: 0x06024969 RID: 149865 RVA: 0x009A1CF6 File Offset: 0x0099FEF6
		// (set) Token: 0x0602496A RID: 149866 RVA: 0x009A1D0A File Offset: 0x0099FF0A
		public unsafe UTextBlock WeatherDa
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004CDE RID: 19678
		// (get) Token: 0x0602496B RID: 149867 RVA: 0x009A1D1F File Offset: 0x0099FF1F
		// (set) Token: 0x0602496C RID: 149868 RVA: 0x009A1D33 File Offset: 0x0099FF33
		public unsafe UTextBlock WPri
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcessListEntry_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17004CDF RID: 19679
		// (get) Token: 0x0602496D RID: 149869 RVA: 0x009A1D48 File Offset: 0x0099FF48
		// (set) Token: 0x0602496E RID: 149870 RVA: 0x009A1D58 File Offset: 0x0099FF58
		public unsafe bool HasOverrideProperties
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_DebugPostProcessListEntry_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_DebugPostProcessListEntry_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004CE0 RID: 19680
		// (get) Token: 0x0602496F RID: 149871 RVA: 0x009A1D6C File Offset: 0x0099FF6C
		// (set) Token: 0x06024970 RID: 149872 RVA: 0x009A1DA5 File Offset: 0x0099FFA5
		[Nullable(1)]
		public FPostprocessGIDebugInfo PostInfo
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPostprocessGIDebugInfo result;
				if ((result = this._PostInfo) == null)
				{
					result = (this._PostInfo = new FPostprocessGIDebugInfo(base.NativePtr + (IntPtr)WBP_DebugPostProcessListEntry_C.__PropertyOffset_16, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPostprocessGIDebugInfo.StaticStruct(), base.NativePtr + (IntPtr)WBP_DebugPostProcessListEntry_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06024971 RID: 149873 RVA: 0x009A1DC8 File Offset: 0x0099FFC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetItemInfo(bool IsOverrideType, FPostprocessGIDebugInfo InputPostInfo)
		{
			WBP_DebugPostProcessListEntry_C.__SetItemInfo_FunctionParams* ptr = stackalloc WBP_DebugPostProcessListEntry_C.__SetItemInfo_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(WBP_DebugPostProcessListEntry_C.__SetItemInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugPostProcessListEntry_C.__SetItemInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsOverrideType = IsOverrideType;
			if (InputPostInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPostprocessGIDebugInfo.StaticStruct(), &ptr->InputPostInfo, InputPostInfo.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugPostProcessListEntry_C.__SetItemInfo_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(WBP_DebugPostProcessListEntry_C.__SetItemInfo_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06024972 RID: 149874 RVA: 0x009A1E44 File Offset: 0x009A0044
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BP_OnItemExpansionChanged(bool bIsExpanded)
		{
			WBP_DebugPostProcessListEntry_C.__BP_OnItemExpansionChanged_FunctionParams* ptr = stackalloc WBP_DebugPostProcessListEntry_C.__BP_OnItemExpansionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_DebugPostProcessListEntry_C.__BP_OnItemExpansionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugPostProcessListEntry_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsExpanded = bIsExpanded;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugPostProcessListEntry_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024973 RID: 149875 RVA: 0x009A1E8C File Offset: 0x009A008C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BP_OnItemExpansionChanged_Implementation(bool bIsExpanded)
		{
			WBP_DebugPostProcessListEntry_C.__BP_OnItemExpansionChanged_FunctionParams* ptr = stackalloc WBP_DebugPostProcessListEntry_C.__BP_OnItemExpansionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_DebugPostProcessListEntry_C.__BP_OnItemExpansionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugPostProcessListEntry_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsExpanded = bIsExpanded;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugPostProcessListEntry_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024974 RID: 149876 RVA: 0x009A1ED4 File Offset: 0x009A00D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BP_OnItemSelectionChanged(bool bIsSelected)
		{
			WBP_DebugPostProcessListEntry_C.__BP_OnItemSelectionChanged_FunctionParams* ptr = stackalloc WBP_DebugPostProcessListEntry_C.__BP_OnItemSelectionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_DebugPostProcessListEntry_C.__BP_OnItemSelectionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugPostProcessListEntry_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsSelected = bIsSelected;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugPostProcessListEntry_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024975 RID: 149877 RVA: 0x009A1F1C File Offset: 0x009A011C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BP_OnItemSelectionChanged_Implementation(bool bIsSelected)
		{
			WBP_DebugPostProcessListEntry_C.__BP_OnItemSelectionChanged_FunctionParams* ptr = stackalloc WBP_DebugPostProcessListEntry_C.__BP_OnItemSelectionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_DebugPostProcessListEntry_C.__BP_OnItemSelectionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugPostProcessListEntry_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsSelected = bIsSelected;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugPostProcessListEntry_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024976 RID: 149878 RVA: 0x009A1F64 File Offset: 0x009A0164
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnListItemObjectSet(UObject ListItemObject)
		{
			WBP_DebugPostProcessListEntry_C.__OnListItemObjectSet_FunctionParams* ptr = stackalloc WBP_DebugPostProcessListEntry_C.__OnListItemObjectSet_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(WBP_DebugPostProcessListEntry_C.__OnListItemObjectSet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugPostProcessListEntry_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ListItemObject = ((ListItemObject != null) ? ListItemObject.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugPostProcessListEntry_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024977 RID: 149879 RVA: 0x009A1FBC File Offset: 0x009A01BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnListItemObjectSet_Implementation(UObject ListItemObject)
		{
			WBP_DebugPostProcessListEntry_C.__OnListItemObjectSet_FunctionParams* ptr = stackalloc WBP_DebugPostProcessListEntry_C.__OnListItemObjectSet_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(WBP_DebugPostProcessListEntry_C.__OnListItemObjectSet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugPostProcessListEntry_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ListItemObject = ((ListItemObject != null) ? ListItemObject.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugPostProcessListEntry_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024978 RID: 149880 RVA: 0x009A2012 File Offset: 0x009A0212
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BP_OnEntryReleased()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugPostProcessListEntry_C.__BP_OnEntryReleased_NativeFunctionPtr, null);
		}

		// Token: 0x06024979 RID: 149881 RVA: 0x009A2026 File Offset: 0x009A0226
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BP_OnEntryReleased_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugPostProcessListEntry_C.__BP_OnEntryReleased_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602497A RID: 149882 RVA: 0x009A203C File Offset: 0x009A023C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_WBP_DebugPostProcessListEntry(int EntryPoint)
		{
			WBP_DebugPostProcessListEntry_C.__ExecuteUbergraph_WBP_DebugPostProcessListEntry_FunctionParams* ptr = stackalloc WBP_DebugPostProcessListEntry_C.__ExecuteUbergraph_WBP_DebugPostProcessListEntry_FunctionParams[(UIntPtr)863] + 15L / (long)sizeof(WBP_DebugPostProcessListEntry_C.__ExecuteUbergraph_WBP_DebugPostProcessListEntry_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugPostProcessListEntry_C.__ExecuteUbergraph_WBP_DebugPostProcessListEntry_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugPostProcessListEntry_C.__ExecuteUbergraph_WBP_DebugPostProcessListEntry_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602497B RID: 149883 RVA: 0x009A2086 File Offset: 0x009A0286
		protected WBP_DebugPostProcessListEntry_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012C04 RID: 76804
		internal static int __InterfaceOffset_IUserObjectListEntry;

		// Token: 0x04012C05 RID: 76805
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/UI/DebugPostProcess/WBP_DebugPostProcessListEntry.WBP_DebugPostProcessListEntry_C";

		// Token: 0x04012C06 RID: 76806
		private static IntPtr _ClassPtr;

		// Token: 0x04012C07 RID: 76807
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012C08 RID: 76808
		internal static int __PropertyOffset_0;

		// Token: 0x04012C09 RID: 76809
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012C0A RID: 76810
		internal static int __PropertyOffset_1;

		// Token: 0x04012C0B RID: 76811
		internal static int __PropertyOffset_2;

		// Token: 0x04012C0C RID: 76812
		internal static int __PropertyOffset_3;

		// Token: 0x04012C0D RID: 76813
		internal static int __PropertyOffset_4;

		// Token: 0x04012C0E RID: 76814
		internal static int __PropertyOffset_5;

		// Token: 0x04012C0F RID: 76815
		internal static int __PropertyOffset_6;

		// Token: 0x04012C10 RID: 76816
		internal static int __PropertyOffset_7;

		// Token: 0x04012C11 RID: 76817
		internal static int __PropertyOffset_8;

		// Token: 0x04012C12 RID: 76818
		internal static int __PropertyOffset_9;

		// Token: 0x04012C13 RID: 76819
		internal static int __PropertyOffset_10;

		// Token: 0x04012C14 RID: 76820
		internal static int __PropertyOffset_11;

		// Token: 0x04012C15 RID: 76821
		internal static int __PropertyOffset_12;

		// Token: 0x04012C16 RID: 76822
		internal static int __PropertyOffset_13;

		// Token: 0x04012C17 RID: 76823
		internal static int __PropertyOffset_14;

		// Token: 0x04012C18 RID: 76824
		internal static int __PropertyOffset_15;

		// Token: 0x04012C19 RID: 76825
		internal static int __PropertyOffset_16;

		// Token: 0x04012C1A RID: 76826
		private FPostprocessGIDebugInfo _PostInfo;

		// Token: 0x04012C1B RID: 76827
		private static IntPtr __SetItemInfo_NativeFunctionPtr;

		// Token: 0x04012C1C RID: 76828
		private static IntPtr __BP_OnItemExpansionChanged_NativeFunctionPtr;

		// Token: 0x04012C1D RID: 76829
		private static IntPtr __BP_OnItemSelectionChanged_NativeFunctionPtr;

		// Token: 0x04012C1E RID: 76830
		private static IntPtr __OnListItemObjectSet_NativeFunctionPtr;

		// Token: 0x04012C1F RID: 76831
		private static IntPtr __BP_OnEntryReleased_NativeFunctionPtr;

		// Token: 0x04012C20 RID: 76832
		private static IntPtr __ExecuteUbergraph_WBP_DebugPostProcessListEntry_NativeFunctionPtr;

		// Token: 0x02009E13 RID: 40467
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __SetItemInfo_FunctionParams
		{
			// Token: 0x0403285B RID: 206939
			[FieldOffset(0)]
			public bool IsOverrideType;

			// Token: 0x0403285C RID: 206940
			[FieldOffset(8)]
			public byte InputPostInfo;
		}

		// Token: 0x02009E14 RID: 40468
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __BP_OnItemExpansionChanged_FunctionParams
		{
			// Token: 0x0403285D RID: 206941
			[FieldOffset(0)]
			public bool bIsExpanded;
		}

		// Token: 0x02009E15 RID: 40469
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __BP_OnItemSelectionChanged_FunctionParams
		{
			// Token: 0x0403285E RID: 206942
			[FieldOffset(0)]
			public bool bIsSelected;
		}

		// Token: 0x02009E16 RID: 40470
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnListItemObjectSet_FunctionParams
		{
			// Token: 0x0403285F RID: 206943
			[FieldOffset(0)]
			public IntPtr ListItemObject;
		}

		// Token: 0x02009E17 RID: 40471
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 848)]
		protected ref struct __ExecuteUbergraph_WBP_DebugPostProcessListEntry_FunctionParams
		{
			// Token: 0x04032860 RID: 206944
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
