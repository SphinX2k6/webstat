using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Components
{
	// Token: 0x02003D96 RID: 15766
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Components/WBP_MaterialControllerDebug.WBP_MaterialControllerDebug_C")]
	[UnrealStructLayout(1288, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1282)]
	public class WBP_MaterialControllerDebug_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602682A RID: 157738 RVA: 0x009DA504 File Offset: 0x009D8704
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_MaterialControllerDebug_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/Components/WBP_MaterialControllerDebug.WBP_MaterialControllerDebug_C");
			}
			return WBP_MaterialControllerDebug_C._ClassPtr;
		}

		// Token: 0x0602682B RID: 157739 RVA: 0x009DA528 File Offset: 0x009D8728
		public WBP_MaterialControllerDebug_C() : this(BuiltinUtils.AllocNativeUObject(WBP_MaterialControllerDebug_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602682C RID: 157740 RVA: 0x009DA550 File Offset: 0x009D8750
		[NullableContext(1)]
		public WBP_MaterialControllerDebug_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_MaterialControllerDebug_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170057AF RID: 22447
		// (get) Token: 0x0602682D RID: 157741 RVA: 0x009DA584 File Offset: 0x009D8784
		// (set) Token: 0x0602682E RID: 157742 RVA: 0x009DA5BD File Offset: 0x009D87BD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)WBP_MaterialControllerDebug_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)WBP_MaterialControllerDebug_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170057B0 RID: 22448
		// (get) Token: 0x0602682F RID: 157743 RVA: 0x009DA5DE File Offset: 0x009D87DE
		// (set) Token: 0x06026830 RID: 157744 RVA: 0x009DA5F2 File Offset: 0x009D87F2
		public unsafe UButton Button_122
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170057B1 RID: 22449
		// (get) Token: 0x06026831 RID: 157745 RVA: 0x009DA607 File Offset: 0x009D8807
		// (set) Token: 0x06026832 RID: 157746 RVA: 0x009DA61B File Offset: 0x009D881B
		public unsafe UButton Button_368
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170057B2 RID: 22450
		// (get) Token: 0x06026833 RID: 157747 RVA: 0x009DA630 File Offset: 0x009D8830
		// (set) Token: 0x06026834 RID: 157748 RVA: 0x009DA644 File Offset: 0x009D8844
		public unsafe UButton Button_453
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170057B3 RID: 22451
		// (get) Token: 0x06026835 RID: 157749 RVA: 0x009DA659 File Offset: 0x009D8859
		// (set) Token: 0x06026836 RID: 157750 RVA: 0x009DA66D File Offset: 0x009D886D
		public unsafe UButton Button_575
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170057B4 RID: 22452
		// (get) Token: 0x06026837 RID: 157751 RVA: 0x009DA682 File Offset: 0x009D8882
		// (set) Token: 0x06026838 RID: 157752 RVA: 0x009DA696 File Offset: 0x009D8896
		public unsafe UComboBoxString CharacterSelector
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UComboBoxString>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170057B5 RID: 22453
		// (get) Token: 0x06026839 RID: 157753 RVA: 0x009DA6AB File Offset: 0x009D88AB
		// (set) Token: 0x0602683A RID: 157754 RVA: 0x009DA6BF File Offset: 0x009D88BF
		public unsafe UButton CloseButton
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170057B6 RID: 22454
		// (get) Token: 0x0602683B RID: 157755 RVA: 0x009DA6D4 File Offset: 0x009D88D4
		// (set) Token: 0x0602683C RID: 157756 RVA: 0x009DA6E8 File Offset: 0x009D88E8
		public unsafe UImage Image_105
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170057B7 RID: 22455
		// (get) Token: 0x0602683D RID: 157757 RVA: 0x009DA6FD File Offset: 0x009D88FD
		// (set) Token: 0x0602683E RID: 157758 RVA: 0x009DA711 File Offset: 0x009D8911
		public unsafe UImage Image_Mask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170057B8 RID: 22456
		// (get) Token: 0x0602683F RID: 157759 RVA: 0x009DA726 File Offset: 0x009D8926
		// (set) Token: 0x06026840 RID: 157760 RVA: 0x009DA73A File Offset: 0x009D893A
		public unsafe UMultiLineEditableTextBox MaterialEffects
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMultiLineEditableTextBox>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170057B9 RID: 22457
		// (get) Token: 0x06026841 RID: 157761 RVA: 0x009DA74F File Offset: 0x009D894F
		// (set) Token: 0x06026842 RID: 157762 RVA: 0x009DA763 File Offset: 0x009D8963
		public unsafe UMultiLineEditableTextBox SectionEffect
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMultiLineEditableTextBox>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170057BA RID: 22458
		// (get) Token: 0x06026843 RID: 157763 RVA: 0x009DA778 File Offset: 0x009D8978
		// (set) Token: 0x06026844 RID: 157764 RVA: 0x009DA78C File Offset: 0x009D898C
		public unsafe UMultiLineEditableTextBox SectionList
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMultiLineEditableTextBox>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170057BB RID: 22459
		// (get) Token: 0x06026845 RID: 157765 RVA: 0x009DA7A1 File Offset: 0x009D89A1
		// (set) Token: 0x06026846 RID: 157766 RVA: 0x009DA7B5 File Offset: 0x009D89B5
		public unsafe UWidgetSwitcher WidgetSwitcher_248
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UWidgetSwitcher>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170057BC RID: 22460
		// (get) Token: 0x06026847 RID: 157767 RVA: 0x009DA7CA File Offset: 0x009D89CA
		// (set) Token: 0x06026848 RID: 157768 RVA: 0x009DA7DE File Offset: 0x009D89DE
		public unsafe UComboBoxString 选取方式Combox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UComboBoxString>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_MaterialControllerDebug_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170057BD RID: 22461
		// (get) Token: 0x06026849 RID: 157769 RVA: 0x009DA7F3 File Offset: 0x009D89F3
		// (set) Token: 0x0602684A RID: 157770 RVA: 0x009DA803 File Offset: 0x009D8A03
		public unsafe bool 跟踪换人
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_MaterialControllerDebug_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_MaterialControllerDebug_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170057BE RID: 22462
		// (get) Token: 0x0602684B RID: 157771 RVA: 0x009DA814 File Offset: 0x009D8A14
		// (set) Token: 0x0602684C RID: 157772 RVA: 0x009DA824 File Offset: 0x009D8A24
		public unsafe bool 鼠标选择
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_MaterialControllerDebug_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_MaterialControllerDebug_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602684D RID: 157773 RVA: 0x009DA838 File Offset: 0x009D8A38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetSectionInfo([Nullable(new byte[]
		{
			2,
			1
		})] TMap<string, SMaterialDebugInfo> SectionInfo)
		{
			WBP_MaterialControllerDebug_C.__SetSectionInfo_FunctionParams* ptr = stackalloc WBP_MaterialControllerDebug_C.__SetSectionInfo_FunctionParams[(UIntPtr)351] + 15L / (long)sizeof(WBP_MaterialControllerDebug_C.__SetSectionInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_MaterialControllerDebug_C.__SetSectionInfo_NativeFunctionPtr, (void*)ptr, 1);
			if (SectionInfo != null)
			{
				SectionInfo.CopyTo(&ptr->SectionInfo, default(UScriptStructStackOnlyPtr));
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__SetSectionInfo_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(WBP_MaterialControllerDebug_C.__SetSectionInfo_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602684E RID: 157774 RVA: 0x009DA8A4 File Offset: 0x009D8AA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCurrentCharacter(ref TsBaseCharacter Character)
		{
			WBP_MaterialControllerDebug_C.__GetCurrentCharacter_FunctionParams* ptr = stackalloc WBP_MaterialControllerDebug_C.__GetCurrentCharacter_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(WBP_MaterialControllerDebug_C.__GetCurrentCharacter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_MaterialControllerDebug_C.__GetCurrentCharacter_NativeFunctionPtr, (void*)ptr, 1);
			ref WBP_MaterialControllerDebug_C.__GetCurrentCharacter_FunctionParams ptr2 = ref *ptr;
			TsBaseCharacter tsBaseCharacter = Character;
			ptr2.Character = ((tsBaseCharacter != null) ? tsBaseCharacter.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__GetCurrentCharacter_NativeFunctionPtr, (void*)ptr);
			Character = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(ptr->Character);
		}

		// Token: 0x0602684F RID: 157775 RVA: 0x009DA908 File Offset: 0x009D8B08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		[return: Nullable(1)]
		public unsafe virtual FEventReply On_Image_Mask_MouseButtonDown_0(FGeometry MyGeometry, in FPointerEvent MouseEvent)
		{
			WBP_MaterialControllerDebug_C.__On_Image_Mask_MouseButtonDown_0_FunctionParams* ptr = stackalloc WBP_MaterialControllerDebug_C.__On_Image_Mask_MouseButtonDown_0_FunctionParams[(UIntPtr)575] + 15L / (long)sizeof(WBP_MaterialControllerDebug_C.__On_Image_Mask_MouseButtonDown_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_MaterialControllerDebug_C.__On_Image_Mask_MouseButtonDown_0_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			if (MouseEvent != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerEvent.StaticStruct(), &ptr->MouseEvent, MouseEvent.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__On_Image_Mask_MouseButtonDown_0_NativeFunctionPtr, (void*)ptr);
			FEventReply result = new FEventReply(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(WBP_MaterialControllerDebug_C.__On_Image_Mask_MouseButtonDown_0_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x06026850 RID: 157776 RVA: 0x009DA9B0 File Offset: 0x009D8BB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateDebugInfo(TsBaseCharacter Character)
		{
			WBP_MaterialControllerDebug_C.__UpdateDebugInfo_FunctionParams* ptr = stackalloc WBP_MaterialControllerDebug_C.__UpdateDebugInfo_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(WBP_MaterialControllerDebug_C.__UpdateDebugInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_MaterialControllerDebug_C.__UpdateDebugInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__UpdateDebugInfo_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026851 RID: 157777 RVA: 0x009DAA08 File Offset: 0x009D8C08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void WhenRoleChange()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__WhenRoleChange_NativeFunctionPtr, null);
		}

		// Token: 0x06026852 RID: 157778 RVA: 0x009DAA1C File Offset: 0x009D8C1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CharacterSelectorInit([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<string> Options)
		{
			WBP_MaterialControllerDebug_C.__CharacterSelectorInit_FunctionParams* ptr = stackalloc WBP_MaterialControllerDebug_C.__CharacterSelectorInit_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(WBP_MaterialControllerDebug_C.__CharacterSelectorInit_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_MaterialControllerDebug_C.__CharacterSelectorInit_NativeFunctionPtr, (void*)ptr, 1);
			TArray<string> tarray = Options;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Options);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__CharacterSelectorInit_NativeFunctionPtr, (void*)ptr);
			TArray<string> tarray2 = Options;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Options);
			}
			UnrealReflectionUtils.DestroyStruct(WBP_MaterialControllerDebug_C.__CharacterSelectorInit_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026853 RID: 157779 RVA: 0x009DAA94 File Offset: 0x009D8C94
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CharacterSelectorDelete(string Option)
		{
			WBP_MaterialControllerDebug_C.__CharacterSelectorDelete_FunctionParams* ptr = stackalloc WBP_MaterialControllerDebug_C.__CharacterSelectorDelete_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(WBP_MaterialControllerDebug_C.__CharacterSelectorDelete_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_MaterialControllerDebug_C.__CharacterSelectorDelete_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Option), Option);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__CharacterSelectorDelete_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(WBP_MaterialControllerDebug_C.__CharacterSelectorDelete_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026854 RID: 157780 RVA: 0x009DAAF4 File Offset: 0x009D8CF4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CharacterSelectorAdd(string Option)
		{
			WBP_MaterialControllerDebug_C.__CharacterSelectorAdd_FunctionParams* ptr = stackalloc WBP_MaterialControllerDebug_C.__CharacterSelectorAdd_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(WBP_MaterialControllerDebug_C.__CharacterSelectorAdd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_MaterialControllerDebug_C.__CharacterSelectorAdd_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Option), Option);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__CharacterSelectorAdd_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(WBP_MaterialControllerDebug_C.__CharacterSelectorAdd_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026855 RID: 157781 RVA: 0x009DAB54 File Offset: 0x009D8D54
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_MaterialControllerDebug_选取方式Combox_K2Node_ComponentBoundEvent_1_OnSelectionChangedEvent__DelegateSignature(string SelectedItem, ESelectInfo SelectionType)
		{
			WBP_MaterialControllerDebug_C.__BndEvt__BP_MaterialControllerDebug_选取方式Combox_K2Node_ComponentBoundEvent_1_OnSelectionChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc WBP_MaterialControllerDebug_C.__BndEvt__BP_MaterialControllerDebug_选取方式Combox_K2Node_ComponentBoundEvent_1_OnSelectionChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(WBP_MaterialControllerDebug_C.__BndEvt__BP_MaterialControllerDebug_选取方式Combox_K2Node_ComponentBoundEvent_1_OnSelectionChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_MaterialControllerDebug_C.__BndEvt__BP_MaterialControllerDebug_选取方式Combox_K2Node_ComponentBoundEvent_1_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SelectedItem), SelectedItem);
			ptr->SelectionType = SelectionType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__BndEvt__BP_MaterialControllerDebug_选取方式Combox_K2Node_ComponentBoundEvent_1_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(WBP_MaterialControllerDebug_C.__BndEvt__BP_MaterialControllerDebug_选取方式Combox_K2Node_ComponentBoundEvent_1_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026856 RID: 157782 RVA: 0x009DABBD File Offset: 0x009D8DBD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__OnBegin_NativeFunctionPtr, null);
		}

		// Token: 0x06026857 RID: 157783 RVA: 0x009DABD1 File Offset: 0x009D8DD1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnEnd_1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__OnEnd_1_NativeFunctionPtr, null);
		}

		// Token: 0x06026858 RID: 157784 RVA: 0x009DABE5 File Offset: 0x009D8DE5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_MaterialControllerDebug_CloseButton_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__BndEvt__BP_MaterialControllerDebug_CloseButton_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06026859 RID: 157785 RVA: 0x009DABFC File Offset: 0x009D8DFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Tick(FGeometry MyGeometry, float InDeltaTime)
		{
			WBP_MaterialControllerDebug_C.__Tick_FunctionParams* ptr = stackalloc WBP_MaterialControllerDebug_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(WBP_MaterialControllerDebug_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_MaterialControllerDebug_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__Tick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602685A RID: 157786 RVA: 0x009DAC64 File Offset: 0x009D8E64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void Tick_Implementation(FGeometry MyGeometry, float InDeltaTime)
		{
			WBP_MaterialControllerDebug_C.__Tick_FunctionParams* ptr = stackalloc WBP_MaterialControllerDebug_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(WBP_MaterialControllerDebug_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_MaterialControllerDebug_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__Tick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602685B RID: 157787 RVA: 0x009DACD0 File Offset: 0x009D8ED0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_WBP_MaterialControllerDebug(int EntryPoint)
		{
			WBP_MaterialControllerDebug_C.__ExecuteUbergraph_WBP_MaterialControllerDebug_FunctionParams* ptr = stackalloc WBP_MaterialControllerDebug_C.__ExecuteUbergraph_WBP_MaterialControllerDebug_FunctionParams[(UIntPtr)943] + 15L / (long)sizeof(WBP_MaterialControllerDebug_C.__ExecuteUbergraph_WBP_MaterialControllerDebug_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_MaterialControllerDebug_C.__ExecuteUbergraph_WBP_MaterialControllerDebug_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_MaterialControllerDebug_C.__ExecuteUbergraph_WBP_MaterialControllerDebug_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602685C RID: 157788 RVA: 0x009DAD1A File Offset: 0x009D8F1A
		protected WBP_MaterialControllerDebug_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014059 RID: 82009
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Components/WBP_MaterialControllerDebug.WBP_MaterialControllerDebug_C";

		// Token: 0x0401405A RID: 82010
		private static IntPtr _ClassPtr;

		// Token: 0x0401405B RID: 82011
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401405C RID: 82012
		internal static int __PropertyOffset_0;

		// Token: 0x0401405D RID: 82013
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401405E RID: 82014
		internal static int __PropertyOffset_1;

		// Token: 0x0401405F RID: 82015
		internal static int __PropertyOffset_2;

		// Token: 0x04014060 RID: 82016
		internal static int __PropertyOffset_3;

		// Token: 0x04014061 RID: 82017
		internal static int __PropertyOffset_4;

		// Token: 0x04014062 RID: 82018
		internal static int __PropertyOffset_5;

		// Token: 0x04014063 RID: 82019
		internal static int __PropertyOffset_6;

		// Token: 0x04014064 RID: 82020
		internal static int __PropertyOffset_7;

		// Token: 0x04014065 RID: 82021
		internal static int __PropertyOffset_8;

		// Token: 0x04014066 RID: 82022
		internal static int __PropertyOffset_9;

		// Token: 0x04014067 RID: 82023
		internal static int __PropertyOffset_10;

		// Token: 0x04014068 RID: 82024
		internal static int __PropertyOffset_11;

		// Token: 0x04014069 RID: 82025
		internal static int __PropertyOffset_12;

		// Token: 0x0401406A RID: 82026
		internal static int __PropertyOffset_13;

		// Token: 0x0401406B RID: 82027
		internal static int __PropertyOffset_14;

		// Token: 0x0401406C RID: 82028
		internal static int __PropertyOffset_15;

		// Token: 0x0401406D RID: 82029
		private static IntPtr __SetSectionInfo_NativeFunctionPtr;

		// Token: 0x0401406E RID: 82030
		private static IntPtr __GetCurrentCharacter_NativeFunctionPtr;

		// Token: 0x0401406F RID: 82031
		private static IntPtr __On_Image_Mask_MouseButtonDown_0_NativeFunctionPtr;

		// Token: 0x04014070 RID: 82032
		private static IntPtr __UpdateDebugInfo_NativeFunctionPtr;

		// Token: 0x04014071 RID: 82033
		private static IntPtr __WhenRoleChange_NativeFunctionPtr;

		// Token: 0x04014072 RID: 82034
		private static IntPtr __CharacterSelectorInit_NativeFunctionPtr;

		// Token: 0x04014073 RID: 82035
		private static IntPtr __CharacterSelectorDelete_NativeFunctionPtr;

		// Token: 0x04014074 RID: 82036
		private static IntPtr __CharacterSelectorAdd_NativeFunctionPtr;

		// Token: 0x04014075 RID: 82037
		private static IntPtr __BndEvt__BP_MaterialControllerDebug_选取方式Combox_K2Node_ComponentBoundEvent_1_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04014076 RID: 82038
		private static IntPtr __OnBegin_NativeFunctionPtr;

		// Token: 0x04014077 RID: 82039
		private static IntPtr __OnEnd_1_NativeFunctionPtr;

		// Token: 0x04014078 RID: 82040
		private static IntPtr __BndEvt__BP_MaterialControllerDebug_CloseButton_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04014079 RID: 82041
		private static IntPtr __Tick_NativeFunctionPtr;

		// Token: 0x0401407A RID: 82042
		private static IntPtr __ExecuteUbergraph_WBP_MaterialControllerDebug_NativeFunctionPtr;

		// Token: 0x0200A07B RID: 41083
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 336)]
		protected ref struct __SetSectionInfo_FunctionParams
		{
			// Token: 0x04032D03 RID: 208131
			[FieldOffset(0)]
			public byte SectionInfo;
		}

		// Token: 0x0200A07C RID: 41084
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __GetCurrentCharacter_FunctionParams
		{
			// Token: 0x04032D04 RID: 208132
			[FieldOffset(0)]
			public IntPtr Character;
		}

		// Token: 0x0200A07D RID: 41085
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 560)]
		protected ref struct __On_Image_Mask_MouseButtonDown_0_FunctionParams
		{
			// Token: 0x04032D05 RID: 208133
			[FieldOffset(0)]
			public byte MyGeometry;

			// Token: 0x04032D06 RID: 208134
			[FieldOffset(56)]
			public byte MouseEvent;

			// Token: 0x04032D07 RID: 208135
			[FieldOffset(176)]
			public byte __Result;
		}

		// Token: 0x0200A07E RID: 41086
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __UpdateDebugInfo_FunctionParams
		{
			// Token: 0x04032D08 RID: 208136
			[FieldOffset(0)]
			public IntPtr Character;
		}

		// Token: 0x0200A07F RID: 41087
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __CharacterSelectorInit_FunctionParams
		{
			// Token: 0x04032D09 RID: 208137
			[FieldOffset(0)]
			public byte Options;
		}

		// Token: 0x0200A080 RID: 41088
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __CharacterSelectorDelete_FunctionParams
		{
			// Token: 0x04032D0A RID: 208138
			[FieldOffset(0)]
			public FString Option;
		}

		// Token: 0x0200A081 RID: 41089
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __CharacterSelectorAdd_FunctionParams
		{
			// Token: 0x04032D0B RID: 208139
			[FieldOffset(0)]
			public FString Option;
		}

		// Token: 0x0200A082 RID: 41090
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __BndEvt__BP_MaterialControllerDebug_选取方式Combox_K2Node_ComponentBoundEvent_1_OnSelectionChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032D0C RID: 208140
			[FieldOffset(0)]
			public FString SelectedItem;

			// Token: 0x04032D0D RID: 208141
			[FieldOffset(16)]
			public TEnumAsByte<ESelectInfo> SelectionType;
		}

		// Token: 0x0200A083 RID: 41091
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected new ref struct __Tick_FunctionParams
		{
			// Token: 0x04032D0E RID: 208142
			[FieldOffset(0)]
			public byte MyGeometry;

			// Token: 0x04032D0F RID: 208143
			[FieldOffset(56)]
			public float InDeltaTime;
		}

		// Token: 0x0200A084 RID: 41092
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 928)]
		protected ref struct __ExecuteUbergraph_WBP_MaterialControllerDebug_FunctionParams
		{
			// Token: 0x04032D10 RID: 208144
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
