using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.UI.Module.Common.View.Widget;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Statistics
{
	// Token: 0x02003D2C RID: 15660
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Statistics/WBP_StatisticsEntry.WBP_StatisticsEntry_C")]
	[UnrealStructLayout(1320, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1320)]
	public class WBP_StatisticsEntry_C : UUserWidget, IUnrealUObject, IUnrealObject, IUserObjectListEntry, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x06025E74 RID: 155252 RVA: 0x009C80DB File Offset: 0x009C62DB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_StatisticsEntry_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Statistics/WBP_StatisticsEntry.WBP_StatisticsEntry_C");
			}
			return WBP_StatisticsEntry_C._ClassPtr;
		}

		// Token: 0x06025E75 RID: 155253 RVA: 0x009C80FF File Offset: 0x009C62FF
		int IUserObjectListEntry.InterfaceOffset()
		{
			return WBP_StatisticsEntry_C.__InterfaceOffset_IUserObjectListEntry;
		}

		// Token: 0x06025E76 RID: 155254 RVA: 0x009C8108 File Offset: 0x009C6308
		public WBP_StatisticsEntry_C() : this(BuiltinUtils.AllocNativeUObject(WBP_StatisticsEntry_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025E77 RID: 155255 RVA: 0x009C8130 File Offset: 0x009C6330
		[NullableContext(1)]
		public WBP_StatisticsEntry_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_StatisticsEntry_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005467 RID: 21607
		// (get) Token: 0x06025E78 RID: 155256 RVA: 0x009C8164 File Offset: 0x009C6364
		// (set) Token: 0x06025E79 RID: 155257 RVA: 0x009C819D File Offset: 0x009C639D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005468 RID: 21608
		// (get) Token: 0x06025E7A RID: 155258 RVA: 0x009C81BE File Offset: 0x009C63BE
		// (set) Token: 0x06025E7B RID: 155259 RVA: 0x009C81D2 File Offset: 0x009C63D2
		public unsafe UButton Button_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005469 RID: 21609
		// (get) Token: 0x06025E7C RID: 155260 RVA: 0x009C81E7 File Offset: 0x009C63E7
		// (set) Token: 0x06025E7D RID: 155261 RVA: 0x009C81FB File Offset: 0x009C63FB
		public unsafe KuroImage_C KuroImage_C_236
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KuroImage_C>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700546A RID: 21610
		// (get) Token: 0x06025E7E RID: 155262 RVA: 0x009C8210 File Offset: 0x009C6410
		// (set) Token: 0x06025E7F RID: 155263 RVA: 0x009C8224 File Offset: 0x009C6424
		public unsafe UTextBlock TextBlock
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700546B RID: 21611
		// (get) Token: 0x06025E80 RID: 155264 RVA: 0x009C8239 File Offset: 0x009C6439
		// (set) Token: 0x06025E81 RID: 155265 RVA: 0x009C824D File Offset: 0x009C644D
		public unsafe UTextBlock TextBlock_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700546C RID: 21612
		// (get) Token: 0x06025E82 RID: 155266 RVA: 0x009C8262 File Offset: 0x009C6462
		// (set) Token: 0x06025E83 RID: 155267 RVA: 0x009C8276 File Offset: 0x009C6476
		public unsafe UTextBlock TextBlock_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700546D RID: 21613
		// (get) Token: 0x06025E84 RID: 155268 RVA: 0x009C828B File Offset: 0x009C648B
		// (set) Token: 0x06025E85 RID: 155269 RVA: 0x009C829F File Offset: 0x009C649F
		public unsafe UTextBlock TextBlock_20
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700546E RID: 21614
		// (get) Token: 0x06025E86 RID: 155270 RVA: 0x009C82B4 File Offset: 0x009C64B4
		// (set) Token: 0x06025E87 RID: 155271 RVA: 0x009C82C8 File Offset: 0x009C64C8
		public unsafe UTextBlock TextBlock_139
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700546F RID: 21615
		// (get) Token: 0x06025E88 RID: 155272 RVA: 0x009C82DD File Offset: 0x009C64DD
		// (set) Token: 0x06025E89 RID: 155273 RVA: 0x009C82F1 File Offset: 0x009C64F1
		[Nullable(1)]
		public unsafe string Name
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_8)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_8)), value);
			}
		}

		// Token: 0x17005470 RID: 21616
		// (get) Token: 0x06025E8A RID: 155274 RVA: 0x009C8306 File Offset: 0x009C6506
		// (set) Token: 0x06025E8B RID: 155275 RVA: 0x009C8316 File Offset: 0x009C6516
		public unsafe float ExistingTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005471 RID: 21617
		// (get) Token: 0x06025E8C RID: 155276 RVA: 0x009C8327 File Offset: 0x009C6527
		// (set) Token: 0x06025E8D RID: 155277 RVA: 0x009C8337 File Offset: 0x009C6537
		public unsafe float Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005472 RID: 21618
		// (get) Token: 0x06025E8E RID: 155278 RVA: 0x009C8348 File Offset: 0x009C6548
		// (set) Token: 0x06025E8F RID: 155279 RVA: 0x009C835C File Offset: 0x009C655C
		[Nullable(1)]
		public unsafe string Author
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_11)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_11)), value);
			}
		}

		// Token: 0x17005473 RID: 21619
		// (get) Token: 0x06025E90 RID: 155280 RVA: 0x009C8371 File Offset: 0x009C6571
		// (set) Token: 0x06025E91 RID: 155281 RVA: 0x009C8385 File Offset: 0x009C6585
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005474 RID: 21620
		// (get) Token: 0x06025E92 RID: 155282 RVA: 0x009C839A File Offset: 0x009C659A
		// (set) Token: 0x06025E93 RID: 155283 RVA: 0x009C83AA File Offset: 0x009C65AA
		public unsafe int TickCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005475 RID: 21621
		// (get) Token: 0x06025E94 RID: 155284 RVA: 0x009C83BB File Offset: 0x009C65BB
		// (set) Token: 0x06025E95 RID: 155285 RVA: 0x009C83CF File Offset: 0x009C65CF
		public unsafe UEffectStatisticsEntryData_C Data
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UEffectStatisticsEntryData_C>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_StatisticsEntry_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17005476 RID: 21622
		// (get) Token: 0x06025E96 RID: 155286 RVA: 0x009C83E4 File Offset: 0x009C65E4
		// (set) Token: 0x06025E97 RID: 155287 RVA: 0x009C83F8 File Offset: 0x009C65F8
		public unsafe FLinearColor TextColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_StatisticsEntry_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x06025E98 RID: 155288 RVA: 0x009C840D File Offset: 0x009C660D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BP_OnEntryReleased()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_StatisticsEntry_C.__BP_OnEntryReleased_NativeFunctionPtr, null);
		}

		// Token: 0x06025E99 RID: 155289 RVA: 0x009C8421 File Offset: 0x009C6621
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BP_OnEntryReleased_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_StatisticsEntry_C.__BP_OnEntryReleased_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025E9A RID: 155290 RVA: 0x009C8438 File Offset: 0x009C6638
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BP_OnItemExpansionChanged(bool bIsExpanded)
		{
			WBP_StatisticsEntry_C.__BP_OnItemExpansionChanged_FunctionParams* ptr = stackalloc WBP_StatisticsEntry_C.__BP_OnItemExpansionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_StatisticsEntry_C.__BP_OnItemExpansionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_StatisticsEntry_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsExpanded = bIsExpanded;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_StatisticsEntry_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025E9B RID: 155291 RVA: 0x009C8480 File Offset: 0x009C6680
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BP_OnItemExpansionChanged_Implementation(bool bIsExpanded)
		{
			WBP_StatisticsEntry_C.__BP_OnItemExpansionChanged_FunctionParams* ptr = stackalloc WBP_StatisticsEntry_C.__BP_OnItemExpansionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_StatisticsEntry_C.__BP_OnItemExpansionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_StatisticsEntry_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsExpanded = bIsExpanded;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_StatisticsEntry_C.__BP_OnItemExpansionChanged_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025E9C RID: 155292 RVA: 0x009C84C8 File Offset: 0x009C66C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BP_OnItemSelectionChanged(bool bIsSelected)
		{
			WBP_StatisticsEntry_C.__BP_OnItemSelectionChanged_FunctionParams* ptr = stackalloc WBP_StatisticsEntry_C.__BP_OnItemSelectionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_StatisticsEntry_C.__BP_OnItemSelectionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_StatisticsEntry_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsSelected = bIsSelected;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_StatisticsEntry_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025E9D RID: 155293 RVA: 0x009C8510 File Offset: 0x009C6710
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BP_OnItemSelectionChanged_Implementation(bool bIsSelected)
		{
			WBP_StatisticsEntry_C.__BP_OnItemSelectionChanged_FunctionParams* ptr = stackalloc WBP_StatisticsEntry_C.__BP_OnItemSelectionChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(WBP_StatisticsEntry_C.__BP_OnItemSelectionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_StatisticsEntry_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsSelected = bIsSelected;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_StatisticsEntry_C.__BP_OnItemSelectionChanged_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025E9E RID: 155294 RVA: 0x009C8558 File Offset: 0x009C6758
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnListItemObjectSet(UObject ListItemObject)
		{
			WBP_StatisticsEntry_C.__OnListItemObjectSet_FunctionParams* ptr = stackalloc WBP_StatisticsEntry_C.__OnListItemObjectSet_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(WBP_StatisticsEntry_C.__OnListItemObjectSet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_StatisticsEntry_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ListItemObject = ((ListItemObject != null) ? ListItemObject.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_StatisticsEntry_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025E9F RID: 155295 RVA: 0x009C85B0 File Offset: 0x009C67B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnListItemObjectSet_Implementation(UObject ListItemObject)
		{
			WBP_StatisticsEntry_C.__OnListItemObjectSet_FunctionParams* ptr = stackalloc WBP_StatisticsEntry_C.__OnListItemObjectSet_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(WBP_StatisticsEntry_C.__OnListItemObjectSet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_StatisticsEntry_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ListItemObject = ((ListItemObject != null) ? ListItemObject.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_StatisticsEntry_C.__OnListItemObjectSet_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025EA0 RID: 155296 RVA: 0x009C8606 File Offset: 0x009C6806
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__WBP_StatisticsEntry_Button_0_K2Node_ComponentBoundEvent_0_OnButtonReleasedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_StatisticsEntry_C.__BndEvt__WBP_StatisticsEntry_Button_0_K2Node_ComponentBoundEvent_0_OnButtonReleasedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06025EA1 RID: 155297 RVA: 0x009C861C File Offset: 0x009C681C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_WBP_StatisticsEntry(int EntryPoint)
		{
			WBP_StatisticsEntry_C.__ExecuteUbergraph_WBP_StatisticsEntry_FunctionParams* ptr = stackalloc WBP_StatisticsEntry_C.__ExecuteUbergraph_WBP_StatisticsEntry_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(WBP_StatisticsEntry_C.__ExecuteUbergraph_WBP_StatisticsEntry_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_StatisticsEntry_C.__ExecuteUbergraph_WBP_StatisticsEntry_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_StatisticsEntry_C.__ExecuteUbergraph_WBP_StatisticsEntry_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025EA2 RID: 155298 RVA: 0x009C8663 File Offset: 0x009C6863
		protected WBP_StatisticsEntry_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013980 RID: 80256
		internal static int __InterfaceOffset_IUserObjectListEntry;

		// Token: 0x04013981 RID: 80257
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Statistics/WBP_StatisticsEntry.WBP_StatisticsEntry_C";

		// Token: 0x04013982 RID: 80258
		private static IntPtr _ClassPtr;

		// Token: 0x04013983 RID: 80259
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013984 RID: 80260
		internal static int __PropertyOffset_0;

		// Token: 0x04013985 RID: 80261
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013986 RID: 80262
		internal static int __PropertyOffset_1;

		// Token: 0x04013987 RID: 80263
		internal static int __PropertyOffset_2;

		// Token: 0x04013988 RID: 80264
		internal static int __PropertyOffset_3;

		// Token: 0x04013989 RID: 80265
		internal static int __PropertyOffset_4;

		// Token: 0x0401398A RID: 80266
		internal static int __PropertyOffset_5;

		// Token: 0x0401398B RID: 80267
		internal static int __PropertyOffset_6;

		// Token: 0x0401398C RID: 80268
		internal static int __PropertyOffset_7;

		// Token: 0x0401398D RID: 80269
		internal static int __PropertyOffset_8;

		// Token: 0x0401398E RID: 80270
		internal static int __PropertyOffset_9;

		// Token: 0x0401398F RID: 80271
		internal static int __PropertyOffset_10;

		// Token: 0x04013990 RID: 80272
		internal static int __PropertyOffset_11;

		// Token: 0x04013991 RID: 80273
		internal static int __PropertyOffset_12;

		// Token: 0x04013992 RID: 80274
		internal static int __PropertyOffset_13;

		// Token: 0x04013993 RID: 80275
		internal static int __PropertyOffset_14;

		// Token: 0x04013994 RID: 80276
		internal static int __PropertyOffset_15;

		// Token: 0x04013995 RID: 80277
		private static IntPtr __BP_OnEntryReleased_NativeFunctionPtr;

		// Token: 0x04013996 RID: 80278
		private static IntPtr __BP_OnItemExpansionChanged_NativeFunctionPtr;

		// Token: 0x04013997 RID: 80279
		private static IntPtr __BP_OnItemSelectionChanged_NativeFunctionPtr;

		// Token: 0x04013998 RID: 80280
		private static IntPtr __OnListItemObjectSet_NativeFunctionPtr;

		// Token: 0x04013999 RID: 80281
		private static IntPtr __BndEvt__WBP_StatisticsEntry_Button_0_K2Node_ComponentBoundEvent_0_OnButtonReleasedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401399A RID: 80282
		private static IntPtr __ExecuteUbergraph_WBP_StatisticsEntry_NativeFunctionPtr;

		// Token: 0x02009FC5 RID: 40901
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __BP_OnItemExpansionChanged_FunctionParams
		{
			// Token: 0x04032B7D RID: 207741
			[FieldOffset(0)]
			public bool bIsExpanded;
		}

		// Token: 0x02009FC6 RID: 40902
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __BP_OnItemSelectionChanged_FunctionParams
		{
			// Token: 0x04032B7E RID: 207742
			[FieldOffset(0)]
			public bool bIsSelected;
		}

		// Token: 0x02009FC7 RID: 40903
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnListItemObjectSet_FunctionParams
		{
			// Token: 0x04032B7F RID: 207743
			[FieldOffset(0)]
			public IntPtr ListItemObject;
		}

		// Token: 0x02009FC8 RID: 40904
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __ExecuteUbergraph_WBP_StatisticsEntry_FunctionParams
		{
			// Token: 0x04032B80 RID: 207744
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
