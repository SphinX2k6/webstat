using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiNavigation.Enum;
using AkiClient.Game.Aki.Data.UiNavigation.Struct;
using CSharpScript.Game.Module.UiNavigation;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002CC1 RID: 11457
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Module/UiNavigation/New/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationBehaviorListener.TsUiNavigationBehaviorListener_C")]
public class TsUiNavigationBehaviorListener : UUINavigationBehaviour, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001E3E RID: 7742
	// (get) Token: 0x06016FEC RID: 94188 RVA: 0x0065FEA5 File Offset: 0x0065E0A5
	// (set) Token: 0x06016FED RID: 94189 RVA: 0x0065FEB9 File Offset: 0x0065E0B9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string GroupName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_GroupName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_GroupName)), value);
		}
	}

	// Token: 0x17001E3F RID: 7743
	// (get) Token: 0x06016FEE RID: 94190 RVA: 0x0065FED0 File Offset: 0x0065E0D0
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> TagArray
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._TagArray) == null)
			{
				result = (this._TagArray = new TArray<string>(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_TagArray, this));
			}
			return result;
		}
	}

	// Token: 0x17001E40 RID: 7744
	// (get) Token: 0x06016FEF RID: 94191 RVA: 0x0065FF09 File Offset: 0x0065E109
	// (set) Token: 0x06016FF0 RID: 94192 RVA: 0x0065FF19 File Offset: 0x0065E119
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int ExitTagPriority
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_ExitTagPriority);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_ExitTagPriority) = value;
		}
	}

	// Token: 0x17001E41 RID: 7745
	// (get) Token: 0x06016FF1 RID: 94193 RVA: 0x0065FF2C File Offset: 0x0065E12C
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> ShieldHotKeyIndexArray
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._ShieldHotKeyIndexArray) == null)
			{
				result = (this._ShieldHotKeyIndexArray = new TArray<int>(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_ShieldHotKeyIndexArray, this));
			}
			return result;
		}
	}

	// Token: 0x17001E42 RID: 7746
	// (get) Token: 0x06016FF2 RID: 94194 RVA: 0x0065FF65 File Offset: 0x0065E165
	// (set) Token: 0x06016FF3 RID: 94195 RVA: 0x0065FF79 File Offset: 0x0065E179
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor ScrollViewActor
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + TsUiNavigationBehaviorListener.__PropertyOffset_ScrollViewActor);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsUiNavigationBehaviorListener.__PropertyOffset_ScrollViewActor, value);
		}
	}

	// Token: 0x17001E43 RID: 7747
	// (get) Token: 0x06016FF4 RID: 94196 RVA: 0x0065FF8E File Offset: 0x0065E18E
	// (set) Token: 0x06016FF5 RID: 94197 RVA: 0x0065FFA2 File Offset: 0x0065E1A2
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AUIBaseActor GridBaseActor
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AUIBaseActor>(base.NativePtr / (IntPtr)sizeof(void*) + TsUiNavigationBehaviorListener.__PropertyOffset_GridBaseActor);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsUiNavigationBehaviorListener.__PropertyOffset_GridBaseActor, value);
		}
	}

	// Token: 0x17001E44 RID: 7748
	// (get) Token: 0x06016FF6 RID: 94198 RVA: 0x0065FFB7 File Offset: 0x0065E1B7
	// (set) Token: 0x06016FF7 RID: 94199 RVA: 0x0065FFCB File Offset: 0x0065E1CB
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor LayoutActor
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + TsUiNavigationBehaviorListener.__PropertyOffset_LayoutActor);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsUiNavigationBehaviorListener.__PropertyOffset_LayoutActor, value);
		}
	}

	// Token: 0x17001E45 RID: 7749
	// (get) Token: 0x06016FF8 RID: 94200 RVA: 0x0065FFE0 File Offset: 0x0065E1E0
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<EHotKeyNameStateType, string> HotKeyTipsTextIdMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<EHotKeyNameStateType, string> result;
			if ((result = this._HotKeyTipsTextIdMap) == null)
			{
				result = (this._HotKeyTipsTextIdMap = new TMap<EHotKeyNameStateType, string>(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_HotKeyTipsTextIdMap, this));
			}
			return result;
		}
	}

	// Token: 0x17001E46 RID: 7750
	// (get) Token: 0x06016FF9 RID: 94201 RVA: 0x00660019 File Offset: 0x0065E219
	// (set) Token: 0x06016FFA RID: 94202 RVA: 0x0066002D File Offset: 0x0065E22D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector2D ClickPivot
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_ClickPivot);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_ClickPivot) = value;
		}
	}

	// Token: 0x17001E47 RID: 7751
	// (get) Token: 0x06016FFB RID: 94203 RVA: 0x00660042 File Offset: 0x0065E242
	// (set) Token: 0x06016FFC RID: 94204 RVA: 0x00660056 File Offset: 0x0065E256
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor InsideGroupActor
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + TsUiNavigationBehaviorListener.__PropertyOffset_InsideGroupActor);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsUiNavigationBehaviorListener.__PropertyOffset_InsideGroupActor, value);
		}
	}

	// Token: 0x17001E48 RID: 7752
	// (get) Token: 0x06016FFD RID: 94205 RVA: 0x0066006C File Offset: 0x0065E26C
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, AActor> InsideActorMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, AActor> result;
			if ((result = this._InsideActorMap) == null)
			{
				result = (this._InsideActorMap = new TMap<string, AActor>(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_InsideActorMap, this));
			}
			return result;
		}
	}

	// Token: 0x17001E49 RID: 7753
	// (get) Token: 0x06016FFE RID: 94206 RVA: 0x006600A5 File Offset: 0x0065E2A5
	// (set) Token: 0x06016FFF RID: 94207 RVA: 0x006600B5 File Offset: 0x0065E2B5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ScrollbarIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_ScrollbarIndex);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_ScrollbarIndex) = value;
		}
	}

	// Token: 0x17001E4A RID: 7754
	// (get) Token: 0x06017000 RID: 94208 RVA: 0x006600C6 File Offset: 0x0065E2C6
	// (set) Token: 0x06017001 RID: 94209 RVA: 0x006600DA File Offset: 0x0065E2DA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string InteractiveTag
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_InteractiveTag)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_InteractiveTag)), value);
		}
	}

	// Token: 0x17001E4B RID: 7755
	// (get) Token: 0x06017002 RID: 94210 RVA: 0x006600F0 File Offset: 0x0065E2F0
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> InteractiveParam
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._InteractiveParam) == null)
			{
				result = (this._InteractiveParam = new TArray<string>(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_InteractiveParam, this));
			}
			return result;
		}
	}

	// Token: 0x17001E4C RID: 7756
	// (get) Token: 0x06017003 RID: 94211 RVA: 0x00660129 File Offset: 0x0065E329
	// (set) Token: 0x06017004 RID: 94212 RVA: 0x0066013D File Offset: 0x0065E33D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string DynamicTag
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_DynamicTag)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_DynamicTag)), value);
		}
	}

	// Token: 0x17001E4D RID: 7757
	// (get) Token: 0x06017005 RID: 94213 RVA: 0x00660152 File Offset: 0x0065E352
	// (set) Token: 0x06017006 RID: 94214 RVA: 0x00660162 File Offset: 0x0065E362
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OpenAdsorbed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_OpenAdsorbed) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_OpenAdsorbed) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001E4E RID: 7758
	// (get) Token: 0x06017007 RID: 94215 RVA: 0x00660173 File Offset: 0x0065E373
	// (set) Token: 0x06017008 RID: 94216 RVA: 0x00660183 File Offset: 0x0065E383
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float AdsorbedDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_AdsorbedDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_AdsorbedDistance) = value;
		}
	}

	// Token: 0x17001E4F RID: 7759
	// (get) Token: 0x06017009 RID: 94217 RVA: 0x00660194 File Offset: 0x0065E394
	// (set) Token: 0x0601700A RID: 94218 RVA: 0x006601A8 File Offset: 0x0065E3A8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector2D AdsorbedPivot
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_AdsorbedPivot);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_AdsorbedPivot) = value;
		}
	}

	// Token: 0x17001E50 RID: 7760
	// (get) Token: 0x0601700B RID: 94219 RVA: 0x006601BD File Offset: 0x0065E3BD
	// (set) Token: 0x0601700C RID: 94220 RVA: 0x006601CD File Offset: 0x0065E3CD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsUseDrag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_IsUseDrag) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_IsUseDrag) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001E51 RID: 7761
	// (get) Token: 0x0601700D RID: 94221 RVA: 0x006601DE File Offset: 0x0065E3DE
	// (set) Token: 0x0601700E RID: 94222 RVA: 0x006601EE File Offset: 0x0065E3EE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsUsePool
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_IsUsePool) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_IsUsePool) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001E52 RID: 7762
	// (get) Token: 0x0601700F RID: 94223 RVA: 0x006601FF File Offset: 0x0065E3FF
	// (set) Token: 0x06017010 RID: 94224 RVA: 0x0066020F File Offset: 0x0065E40F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float NavigateTolerance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_NavigateTolerance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_NavigateTolerance) = value;
		}
	}

	// Token: 0x17001E53 RID: 7763
	// (get) Token: 0x06017011 RID: 94225 RVA: 0x00660220 File Offset: 0x0065E420
	// (set) Token: 0x06017012 RID: 94226 RVA: 0x00660230 File Offset: 0x0065E430
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float NavigateToleranceReverse
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_NavigateToleranceReverse);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_NavigateToleranceReverse) = value;
		}
	}

	// Token: 0x06017013 RID: 94227 RVA: 0x00660244 File Offset: 0x0065E444
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void AwakeBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AwakeBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06017014 RID: 94228 RVA: 0x006602B4 File Offset: 0x0065E4B4
	protected virtual void AwakeBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		this.InstanceId = UiNavigationGlobalData.GetListenerInstanceId();
		this.AwakeInit();
	}

	// Token: 0x06017015 RID: 94229 RVA: 0x006602D0 File Offset: 0x0065E4D0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void StartBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("StartBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06017016 RID: 94230 RVA: 0x00660340 File Offset: 0x0065E540
	protected virtual void StartBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		this.StartInit();
	}

	// Token: 0x06017017 RID: 94231 RVA: 0x00660350 File Offset: 0x0065E550
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnNotifyNavigationEnterBP(ULGUIPointerEventData eventData)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnNotifyNavigationEnterBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UUINavigationBehaviour.__OnNotifyNavigationEnterBP_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UUINavigationBehaviour.__OnNotifyNavigationEnterBP_FunctionParams*)ptr + 15L / (long)sizeof(UUINavigationBehaviour.__OnNotifyNavigationEnterBP_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->eventData) = ((eventData != null) ? eventData.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06017018 RID: 94232 RVA: 0x006603D4 File Offset: 0x0065E5D4
	[NullableContext(2)]
	protected virtual void OnNotifyNavigationEnterBP_Implementation(ULGUIPointerEventData eventData)
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		if (StringUtils.IsBlank(this.GroupName))
		{
			return;
		}
		TsUiNavigationPanelConfig panelConfig = this.PanelConfig;
		if (panelConfig == null || !panelConfig.IsAllowNavigate())
		{
			return;
		}
		if (eventData == null)
		{
			return;
		}
		if (!this.GetNavigationComponent().HandlePointerEnter(eventData))
		{
			return;
		}
		this.SetListenerInNavigation();
	}

	// Token: 0x06017019 RID: 94233 RVA: 0x00660428 File Offset: 0x0065E628
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnNotifyNavigationSelectBP(ULGUIPointerEventData eventData)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnNotifyNavigationSelectBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UUINavigationBehaviour.__OnNotifyNavigationSelectBP_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UUINavigationBehaviour.__OnNotifyNavigationSelectBP_FunctionParams*)ptr + 15L / (long)sizeof(UUINavigationBehaviour.__OnNotifyNavigationSelectBP_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->eventData) = ((eventData != null) ? eventData.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601701A RID: 94234 RVA: 0x006604AC File Offset: 0x0065E6AC
	[NullableContext(2)]
	protected virtual void OnNotifyNavigationSelectBP_Implementation(ULGUIPointerEventData eventData)
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		if (StringUtils.IsBlank(this.GroupName))
		{
			return;
		}
		TsUiNavigationPanelConfig panelConfig = this.PanelConfig;
		if (panelConfig == null || !panelConfig.IsAllowNavigate())
		{
			return;
		}
		if (eventData == null)
		{
			return;
		}
		if (!this.GetNavigationComponent().HandlePointerSelect(eventData))
		{
			UiNavigationLogic.UpdateSameNavigationListener(this);
			return;
		}
		this.SetListenerInNavigation();
	}

	// Token: 0x0601701B RID: 94235 RVA: 0x00660508 File Offset: 0x0065E708
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool OnCheckCanSetNavigationBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnCheckCanSetNavigationBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UUINavigationBehaviour.__OnCheckCanSetNavigationBP_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UUINavigationBehaviour.__OnCheckCanSetNavigationBP_FunctionParams*)ptr + 15L / (long)sizeof(UUINavigationBehaviour.__OnCheckCanSetNavigationBP_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601701C RID: 94236 RVA: 0x00660580 File Offset: 0x0065E780
	protected virtual bool OnCheckCanSetNavigationBP_Implementation()
	{
		if (this.ScrollProxy == null)
		{
			return this.InNavigation;
		}
		if (!this.ScrollProxy.HasLoopScrollView())
		{
			return this.InNavigation;
		}
		int loopScrollViewNavigationIndex = this.ScrollProxy.GetLoopScrollViewNavigationIndex();
		if (loopScrollViewNavigationIndex == -1)
		{
			return this.InNavigation;
		}
		if (UiNavigationGlobalData.IsAllowLoopScrollInteractHighlight)
		{
			return loopScrollViewNavigationIndex == base.LoopScrollViewGridIndex && this.InNavigation;
		}
		return loopScrollViewNavigationIndex != base.LoopScrollViewGridIndex && this.InNavigation;
	}

	// Token: 0x0601701D RID: 94237 RVA: 0x006605F4 File Offset: 0x0065E7F4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool OnCheckLoopScrollChangeNavigationBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnCheckLoopScrollChangeNavigationBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UUINavigationBehaviour.__OnCheckLoopScrollChangeNavigationBP_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UUINavigationBehaviour.__OnCheckLoopScrollChangeNavigationBP_FunctionParams*)ptr + 15L / (long)sizeof(UUINavigationBehaviour.__OnCheckLoopScrollChangeNavigationBP_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601701E RID: 94238 RVA: 0x00660669 File Offset: 0x0065E869
	protected virtual bool OnCheckLoopScrollChangeNavigationBP_Implementation()
	{
		return this.ScrollProxy != null && this.ScrollProxy.CheckLoopScrollChangeNavigation();
	}

	// Token: 0x0601701F RID: 94239 RVA: 0x00660680 File Offset: 0x0065E880
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnEnableBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnEnableBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06017020 RID: 94240 RVA: 0x006606F0 File Offset: 0x0065E8F0
	protected virtual void OnEnableBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		this.TryReStartInit();
		Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
		this.RefreshPanelConfig();
		this.TryFindScrollbar();
	}

	// Token: 0x06017021 RID: 94241 RVA: 0x00660718 File Offset: 0x0065E918
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnDisableBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnDisableBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06017022 RID: 94242 RVA: 0x00660788 File Offset: 0x0065E988
	protected virtual void OnDisableBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
		this.DisActiveHandle();
	}

	// Token: 0x06017023 RID: 94243 RVA: 0x006607A4 File Offset: 0x0065E9A4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnNotifyInteractiveBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnNotifyInteractiveBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06017024 RID: 94244 RVA: 0x00660814 File Offset: 0x0065EA14
	protected virtual void OnNotifyInteractiveBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		this.GetNavigationComponent().SetIsInteractive(true);
		Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
	}

	// Token: 0x06017025 RID: 94245 RVA: 0x00660834 File Offset: 0x0065EA34
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnNotifyNotInteractiveBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnNotifyNotInteractiveBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06017026 RID: 94246 RVA: 0x006608A4 File Offset: 0x0065EAA4
	protected virtual void OnNotifyNotInteractiveBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		this.GetNavigationComponent().SetIsInteractive(false);
		Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
		this.DisActiveHandle();
	}

	// Token: 0x06017027 RID: 94247 RVA: 0x006608CC File Offset: 0x0065EACC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnPreDestroyBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnPreDestroyBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06017028 RID: 94248 RVA: 0x0066093C File Offset: 0x0065EB3C
	protected virtual void OnPreDestroyBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		this.DisActiveHandle();
		this.UnBindLoopScrollView();
		this.UnRegisterListenerToPanel();
		NavigationSelectableBase navigationComponent = this.NavigationComponent;
		if (navigationComponent != null)
		{
			navigationComponent.Clear();
		}
		this.PanelConfig = null;
		this.LayoutBase = null;
		this.ScrollProxy = null;
	}

	// Token: 0x06017029 RID: 94249 RVA: 0x0066098C File Offset: 0x0065EB8C
	private void AwakeInit()
	{
		if (this.IsAwakeCalled)
		{
			return;
		}
		this.InNavigation = false;
		this.ModeModule = new UiNavigationModeModule(this);
		this.CursorModule = new UiNavigationCursorModule(this.Cursor);
		this.ChildTagMap = new Dictionary<string, TsUiNavigationBehaviorListener>();
		this.CreateNavigationComponent();
		this.RegisterListenerToPanel();
		this.IsAwakeCalled = true;
	}

	// Token: 0x0601702A RID: 94250 RVA: 0x006609E4 File Offset: 0x0065EBE4
	private void StartInit()
	{
		if (this.IsStartCalled)
		{
			return;
		}
		this.SetTextChangeComponent();
		this.InitInsideGroupActor();
		this.NotifyParentListener(this);
		this.RegisterListenerToPanel();
		this.InitScrollViewAndLayout();
		Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
		this.RefreshPanelConfig();
		this.IsStartCalled = true;
	}

	// Token: 0x0601702B RID: 94251 RVA: 0x00660A30 File Offset: 0x0065EC30
	private unsafe void TryReStartInit()
	{
		if (!this.IsUsePool)
		{
			return;
		}
		if (!this.IsStartCalled)
		{
			return;
		}
		if (this.PanelConfig == null)
		{
			return;
		}
		UUIItem uuiitem = this.PanelConfig.RootUIComp.Get();
		if (this.PanelConfig.IsValid() && uuiitem != null && uuiitem.IsValid())
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiNavigation;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "可能存在从对象池获取的情况[TsUiNavigationBehaviorListener]";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GroupName", this.GroupName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Name", base.RootUIComp.Get().displayName);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.IsStartCalled = false;
		this.ScrollProxy = null;
		this.IsInitLayout = false;
		this.PanelConfig = null;
		this.StartInit();
	}

	// Token: 0x0601702C RID: 94252 RVA: 0x00660B14 File Offset: 0x0065ED14
	private void InitScrollViewAndLayout()
	{
		this.InitScrollView();
		this.InitLayout();
	}

	// Token: 0x0601702D RID: 94253 RVA: 0x00660B24 File Offset: 0x0065ED24
	private void InitAnimController()
	{
		if (this.IsInitAnimController)
		{
			return;
		}
		this.IsInitAnimController = true;
		if (this.ScrollProxy != null)
		{
			this.AnimController = this.ScrollProxy.GetInturnAnimController();
		}
		if (this.LayoutBase != null)
		{
			UUILayoutBase layoutBase = this.LayoutBase;
			this.AnimController = (((layoutBase != null) ? layoutBase.GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) : null) as UUIInturnAnimController);
		}
	}

	// Token: 0x0601702E RID: 94254 RVA: 0x00660B90 File Offset: 0x0065ED90
	private void InitScrollView()
	{
		if (this.ScrollViewActor == null)
		{
			return;
		}
		if (this.ScrollProxy != null)
		{
			return;
		}
		this.ScrollProxy = new UiNavigationScrollProxy();
		this.ScrollProxy.InitScrollView(this.ScrollViewActor, this);
		this.DynamicGridActor = this.ScrollProxy.GetDynamicGridActor();
		this.BindLoopScrollView();
		if (this.ScrollProxy.ScrollView != null)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiNavigation;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "找不到滚动列表组件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("节点", base.RootUIComp.Get().displayName);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601702F RID: 94255 RVA: 0x00660C30 File Offset: 0x0065EE30
	private void InitLayout()
	{
		if (this.LayoutActor == null)
		{
			return;
		}
		if (this.IsInitLayout)
		{
			return;
		}
		this.LayoutBase = (this.LayoutActor.GetComponentByClass(UUILayoutBase.StaticClass()) as UUILayoutBase);
		this.IsInitLayout = true;
		if (this.LayoutBase != null)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiNavigation;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "找不到循环滚动列表组件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("节点", base.RootUIComp.Get().displayName);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06017030 RID: 94256 RVA: 0x00660CBB File Offset: 0x0065EEBB
	private void TryFindScrollbar()
	{
		if (this.PanelConfig == null)
		{
			return;
		}
		this.PanelConfig.TryFindScrollbar();
	}

	// Token: 0x06017031 RID: 94257 RVA: 0x00660CD1 File Offset: 0x0065EED1
	private void DisActiveHandle()
	{
		if (this.PanelConfig == null)
		{
			return;
		}
		if (this.InNavigation)
		{
			this.InNavigation = false;
			this.PanelConfig.ReFindNavigation();
		}
		if (this.IsFocusScrollbar)
		{
			this.PanelConfig.ReFindScrollbar();
		}
	}

	// Token: 0x06017032 RID: 94258 RVA: 0x00660D09 File Offset: 0x0065EF09
	private void SetTextChangeComponent()
	{
		AActor owner = base.GetOwner();
		this.TextChangeComponent = (((owner != null) ? owner.GetComponentByClass(TsUiNavigationTextChangeListener.StaticClass()) : null) as TsUiNavigationTextChangeListener);
	}

	// Token: 0x06017033 RID: 94259 RVA: 0x00660D34 File Offset: 0x0065EF34
	private void NotifyParentListener(TsUiNavigationBehaviorListener listener)
	{
		TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = UiNavigationLogic.FindUpNavigationListener(base.GetOwner());
		if (tsUiNavigationBehaviorListener == null)
		{
			return;
		}
		tsUiNavigationBehaviorListener.RegisterChildListener(listener);
	}

	// Token: 0x06017034 RID: 94260 RVA: 0x00660D58 File Offset: 0x0065EF58
	public void RegisterChildListener(TsUiNavigationBehaviorListener listener)
	{
		TArray<string> tagArray = listener.TagArray;
		if (tagArray != null)
		{
			int i = 0;
			int num = tagArray.Num();
			while (i < num)
			{
				string text = tagArray.Get(i);
				if (text != null)
				{
					this.ChildTagMap[text] = listener;
				}
				i++;
			}
		}
		this.NotifyParentListener(listener);
	}

	// Token: 0x06017035 RID: 94261 RVA: 0x00660DA1 File Offset: 0x0065EFA1
	private void InitInsideGroupActor()
	{
		if (this.InsideGroupActor != null)
		{
			return;
		}
		this.InsideGroupActor = base.GetOwner();
	}

	// Token: 0x06017036 RID: 94262 RVA: 0x00660DB8 File Offset: 0x0065EFB8
	private void BindLoopScrollView()
	{
		if (this.ScrollProxy == null)
		{
			return;
		}
		UUISelectableComponent selectableComponent = this.GetSelectableComponent();
		this.ScrollProxy.BindScrollView(selectableComponent);
	}

	// Token: 0x06017037 RID: 94263 RVA: 0x00660DE4 File Offset: 0x0065EFE4
	private void UnBindLoopScrollView()
	{
		if (this.ScrollProxy == null)
		{
			return;
		}
		UUISelectableComponent selectableComponent = this.GetSelectableComponent();
		this.ScrollProxy.UnBindScrollView(selectableComponent);
	}

	// Token: 0x06017038 RID: 94264 RVA: 0x00660E0D File Offset: 0x0065F00D
	public bool HasNormalScrollView()
	{
		return this.ScrollProxy != null && this.ScrollProxy.HasNormalScrollView();
	}

	// Token: 0x06017039 RID: 94265 RVA: 0x00660E24 File Offset: 0x0065F024
	public bool HasLoopScrollView()
	{
		return this.ScrollProxy != null && this.ScrollProxy.HasLoopScrollView();
	}

	// Token: 0x0601703A RID: 94266 RVA: 0x00660E3B File Offset: 0x0065F03B
	public bool HasDynamicScrollView()
	{
		return this.ScrollProxy != null && this.ScrollProxy.HasDynamicScrollView();
	}

	// Token: 0x0601703B RID: 94267 RVA: 0x00660E52 File Offset: 0x0065F052
	public bool HasMultiTemplateScrollView()
	{
		return this.ScrollProxy != null && this.ScrollProxy.HasMultiTemplateScrollView();
	}

	// Token: 0x0601703C RID: 94268 RVA: 0x00660E69 File Offset: 0x0065F069
	private void RegisterListenerToPanel()
	{
		if (this.PanelConfig != null)
		{
			return;
		}
		this.PanelConfig = UiNavigationLogic.FindUiNavigationPanelConfig(base.GetOwner());
		if (this.PanelConfig == null)
		{
			return;
		}
		this.PanelConfig.RegisterNavigationListener(this);
		this.PanelConfig.DynamicListenerConfigHandle(this);
	}

	// Token: 0x0601703D RID: 94269 RVA: 0x00660EA6 File Offset: 0x0065F0A6
	private void UnRegisterListenerToPanel()
	{
		if (this.PanelConfig == null)
		{
			return;
		}
		this.PanelConfig.UnRegisterNavigationListener(this);
	}

	// Token: 0x0601703E RID: 94270 RVA: 0x00660EBD File Offset: 0x0065F0BD
	private void RefreshPanelConfig()
	{
		if (StringUtils.IsBlank(this.GroupName))
		{
			return;
		}
		if (this.PanelConfig == null)
		{
			return;
		}
		this.PanelConfig.FindNavigationInNoneState();
	}

	// Token: 0x0601703F RID: 94271 RVA: 0x00660EE4 File Offset: 0x0065F0E4
	private void CreateNavigationComponent()
	{
		if (this.NavigationComponent != null)
		{
			return;
		}
		List<string> list = new List<string>();
		if (this.InteractiveParam != null)
		{
			int i = 0;
			int num = this.InteractiveParam.Num();
			while (i < num)
			{
				string text = this.InteractiveParam.Get(i);
				if (!string.IsNullOrEmpty(text))
				{
					list.Add(text);
				}
				i++;
			}
		}
		this.NavigationComponent = NavigationSelectableCreator.CreateNavigationBehavior(base.GetOwner(), this.InteractiveTag, list);
		NavigationSelectableBase navigationComponent = this.NavigationComponent;
		if (navigationComponent != null)
		{
			navigationComponent.SetListener(this);
		}
		NavigationSelectableBase navigationComponent2 = this.NavigationComponent;
		if (navigationComponent2 == null)
		{
			return;
		}
		navigationComponent2.Init();
	}

	// Token: 0x06017040 RID: 94272 RVA: 0x00660F76 File Offset: 0x0065F176
	public NavigationSelectableBase GetNavigationComponent()
	{
		if (this.NavigationComponent == null)
		{
			this.CreateNavigationComponent();
		}
		return this.NavigationComponent;
	}

	// Token: 0x06017041 RID: 94273 RVA: 0x00660F8C File Offset: 0x0065F18C
	[NullableContext(2)]
	public UUISelectableComponent GetSelectableComponent()
	{
		return this.GetBehaviorComponent() as UUISelectableComponent;
	}

	// Token: 0x06017042 RID: 94274 RVA: 0x00660F99 File Offset: 0x0065F199
	public ULGUIBehaviour GetBehaviorComponent()
	{
		return this.GetNavigationComponent().GetSelectable();
	}

	// Token: 0x06017043 RID: 94275 RVA: 0x00660FA6 File Offset: 0x0065F1A6
	[NullableContext(2)]
	public USceneComponent GetSceneComponent()
	{
		return this.GetBehaviorComponent().GetRootComponent();
	}

	// Token: 0x06017044 RID: 94276 RVA: 0x00660FB4 File Offset: 0x0065F1B4
	[return: Nullable(2)]
	public TsUiNavigationBehaviorListener GetChildListenerByTag(string tag)
	{
		TsUiNavigationBehaviorListener result;
		if (this.ChildTagMap == null || !this.ChildTagMap.TryGetValue(tag, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06017045 RID: 94277 RVA: 0x00660FDC File Offset: 0x0065F1DC
	public bool IsScrollOrLayoutActor()
	{
		this.InitScrollViewAndLayout();
		UiNavigationScrollProxy scrollProxy = this.ScrollProxy;
		return ((scrollProxy != null) ? scrollProxy.ScrollView : null) != null || this.LayoutBase != null;
	}

	// Token: 0x06017046 RID: 94278 RVA: 0x00661003 File Offset: 0x0065F203
	[NullableContext(2)]
	public AActor GetScrollOrLayoutActor()
	{
		if (this.ScrollViewActor != null)
		{
			return this.ScrollViewActor;
		}
		if (this.LayoutActor != null)
		{
			return this.LayoutActor;
		}
		return null;
	}

	// Token: 0x06017047 RID: 94279 RVA: 0x00661024 File Offset: 0x0065F224
	public bool IsScrollOrLayoutActive()
	{
		this.InitScrollViewAndLayout();
		if (this.ScrollProxy != null)
		{
			return this.ScrollProxy.IsScrollViewActive();
		}
		return this.LayoutBase != null && this.LayoutBase.RootUIComp.Get().IsUIActiveInHierarchy();
	}

	// Token: 0x06017048 RID: 94280 RVA: 0x0066106D File Offset: 0x0065F26D
	public bool IsInScrollOrLayoutAnimation()
	{
		this.InitAnimController();
		UUIInturnAnimController animController = this.AnimController;
		return animController != null && animController.IsPlaying();
	}

	// Token: 0x06017049 RID: 94281 RVA: 0x00661086 File Offset: 0x0065F286
	public bool IsInNormalScrollDisplayByGridActor()
	{
		return !this.HasNormalScrollView() || this.GridBaseActor == null || this.ScrollProxy.IsInNormalScrollDisplayByGridActor(this.GridBaseActor);
	}

	// Token: 0x0601704A RID: 94282 RVA: 0x006610AD File Offset: 0x0065F2AD
	public bool IsInLoopScrollDisplay()
	{
		return this.ScrollProxy == null || this.ScrollProxy.IsInLoopScrollDisplay(base.LoopScrollViewGridIndex);
	}

	// Token: 0x0601704B RID: 94283 RVA: 0x006610CA File Offset: 0x0065F2CA
	public bool IsInLoopScrollDisplayByGridActor()
	{
		return this.ScrollProxy == null || this.ScrollProxy.IsInLoopScrollDisplayByGridActor(this.GridBaseActor);
	}

	// Token: 0x0601704C RID: 94284 RVA: 0x006610E7 File Offset: 0x0065F2E7
	public bool IsInDynScrollDisplay()
	{
		return this.ScrollProxy == null || this.ScrollProxy.IsInDynScrollDisplay(this.GridBaseActor);
	}

	// Token: 0x0601704D RID: 94285 RVA: 0x00661104 File Offset: 0x0065F304
	public bool IsInScrollDisplayByGridActor()
	{
		return this.ScrollProxy == null || this.ScrollProxy.IsScrollDisplayByGridActor(this.GridBaseActor);
	}

	// Token: 0x0601704E RID: 94286 RVA: 0x00661124 File Offset: 0x0065F324
	public bool IsInScrollOrLayoutCanFocus()
	{
		NavigationSelectableBase navigationComponent = this.GetNavigationComponent();
		return navigationComponent != null && navigationComponent.CanFocusInScrollOrLayout();
	}

	// Token: 0x0601704F RID: 94287 RVA: 0x00661144 File Offset: 0x0065F344
	public bool IsCanFocus()
	{
		NavigationSelectableBase navigationComponent = this.GetNavigationComponent();
		return navigationComponent != null && navigationComponent.CanFocus();
	}

	// Token: 0x06017050 RID: 94288 RVA: 0x00661163 File Offset: 0x0065F363
	public bool IsRegisterToPanelConfig()
	{
		return this.IsStartCalled;
	}

	// Token: 0x06017051 RID: 94289 RVA: 0x0066116C File Offset: 0x0065F36C
	public bool IsListenerActive()
	{
		NavigationSelectableBase navigationComponent = this.GetNavigationComponent();
		return navigationComponent != null && navigationComponent.IsActive();
	}

	// Token: 0x06017052 RID: 94290 RVA: 0x0066118C File Offset: 0x0065F38C
	public bool IsIgnoreScrollOrLayoutCheckInSwitchGroup()
	{
		NavigationSelectableBase navigationComponent = this.GetNavigationComponent();
		return navigationComponent != null && navigationComponent.IsIgnoreScrollOrLayoutCheckInSwitchGroup();
	}

	// Token: 0x06017053 RID: 94291 RVA: 0x006611AB File Offset: 0x0065F3AB
	public void ResetNavigationState()
	{
		this.InNavigation = false;
		TsUiNavigationPanelConfig panelConfig = this.PanelConfig;
		if (panelConfig != null)
		{
			UiNavigationViewHandle viewHandle = panelConfig.ViewHandle;
			if (viewHandle != null)
			{
				viewHandle.ResetNavigationDirty(this.InstanceId);
			}
		}
		this.UpdateNavigationState();
		this.UpdateLoopNavigationIndex(-1);
		this.NotifyUnFocusListener();
	}

	// Token: 0x06017054 RID: 94292 RVA: 0x006611E9 File Offset: 0x0065F3E9
	public void ActiveNavigationState(bool isSameListener)
	{
		this.InNavigation = true;
		this.UpdateNavigationState();
		this.UpdateLoopNavigationIndex(base.LoopScrollViewGridIndex);
		this.NotifyFocusListener(isSameListener);
	}

	// Token: 0x06017055 RID: 94293 RVA: 0x0066120C File Offset: 0x0065F40C
	private void UpdateNavigationState()
	{
		ULGUIBehaviour behaviorComponent = this.GetBehaviorComponent();
		if (behaviorComponent != null && behaviorComponent.IsValid())
		{
			UUISelectableComponent uuiselectableComponent = behaviorComponent as UUISelectableComponent;
			if (uuiselectableComponent != null)
			{
				uuiselectableComponent.SetSelectionState(uuiselectableComponent.GetSelectionState());
				uuiselectableComponent.ApplySelectionState(true);
			}
		}
	}

	// Token: 0x06017056 RID: 94294 RVA: 0x00661248 File Offset: 0x0065F448
	private void UpdateLoopNavigationIndex(int gridIndex)
	{
		if (this.ScrollViewActor == null)
		{
			return;
		}
		if (this.ScrollProxy == null)
		{
			return;
		}
		this.ScrollProxy.SetLoopScrollViewNavigationIndex(gridIndex);
	}

	// Token: 0x06017057 RID: 94295 RVA: 0x00661268 File Offset: 0x0065F468
	private void NotifyUnFocusListener()
	{
		UUISelectableComponent uuiselectableComponent = this.GetBehaviorComponent() as UUISelectableComponent;
		if (uuiselectableComponent != null)
		{
			uuiselectableComponent.NotifyUnFocusListener();
		}
	}

	// Token: 0x06017058 RID: 94296 RVA: 0x0066128C File Offset: 0x0065F48C
	private void NotifyFocusListener(bool isSameListener)
	{
		NavigationSelectableBase navigationComponent = this.GetNavigationComponent();
		navigationComponent.NotifyFocusListener(isSameListener);
		UUISelectableComponent uuiselectableComponent = navigationComponent.GetSelectable() as UUISelectableComponent;
		if (uuiselectableComponent != null)
		{
			uuiselectableComponent.NotifyFocusListener();
		}
	}

	// Token: 0x06017059 RID: 94297 RVA: 0x006612BC File Offset: 0x0065F4BC
	private void SetListenerInNavigation()
	{
		if (UiNavigationGlobalData.IsAllowCrossNavigationGroup)
		{
			UiNavigationGlobalData.IsAllowCrossNavigationGroup = false;
			TsUiNavigationPanelConfig panelConfig = this.PanelConfig;
			if (panelConfig == null)
			{
				return;
			}
			panelConfig.NotifyListenerFocus(this);
			return;
		}
		else
		{
			if (this.InNavigation && this.IsInLoopScrollDisplay())
			{
				return;
			}
			TsUiNavigationPanelConfig panelConfig2 = this.PanelConfig;
			if (panelConfig2 == null)
			{
				return;
			}
			panelConfig2.NotifyListenerFocus(this);
			return;
		}
	}

	// Token: 0x0601705A RID: 94298 RVA: 0x0066130A File Offset: 0x0065F50A
	[NullableContext(2)]
	public NavigationGroup GetNavigationGroup()
	{
		TsUiNavigationPanelConfig panelConfig = this.PanelConfig;
		if (panelConfig == null)
		{
			return null;
		}
		return panelConfig.GetNavigationGroup(this.GroupName);
	}

	// Token: 0x0601705B RID: 94299 RVA: 0x00661324 File Offset: 0x0065F524
	public bool IsSelectedToggle()
	{
		UUIExtendToggle uuiextendToggle = this.GetSelectableComponent() as UUIExtendToggle;
		return uuiextendToggle != null && uuiextendToggle.ToggleState == EToggleState.ETT_Checked;
	}

	// Token: 0x0601705C RID: 94300 RVA: 0x0066134B File Offset: 0x0065F54B
	public void NotifyTextChangeByComponent(string notifyText)
	{
		if (this.PanelConfig == null)
		{
			return;
		}
		this.PanelConfig.UpdateHotKeyTextForce(this.TagArray, notifyText);
	}

	// Token: 0x0601705D RID: 94301 RVA: 0x00661368 File Offset: 0x0065F568
	public string GetTipsTextIdByState()
	{
		return this.GetNavigationComponent().GetTipsTextId();
	}

	// Token: 0x0601705E RID: 94302 RVA: 0x00661375 File Offset: 0x0065F575
	public TsUiNavigationTextChangeListener GetTextChangeComponent()
	{
		return this.TextChangeComponent;
	}

	// Token: 0x17001E54 RID: 7764
	// (get) Token: 0x0601705F RID: 94303 RVA: 0x00661380 File Offset: 0x0065F580
	// (set) Token: 0x06017060 RID: 94304 RVA: 0x006613B9 File Offset: 0x0065F5B9
	[UProperty(EPropertyFlags.CPF_None)]
	public SNavigationMode NavigationMode
	{
		get
		{
			base.FastCheckIsValid();
			SNavigationMode result;
			if ((result = this._NavigationMode) == null)
			{
				result = (this._NavigationMode = new SNavigationMode(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_NavigationMode, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SNavigationMode.StaticStruct(), base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_NavigationMode, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x06017061 RID: 94305 RVA: 0x006613E4 File Offset: 0x0065F5E4
	[NullableContext(2)]
	public USceneComponent FindNavigation(ELGUINavigationDirection direction)
	{
		if (direction == ELGUINavigationDirection.None)
		{
			return this.GetSceneComponent();
		}
		if (direction == ELGUINavigationDirection.Prev)
		{
			USceneComponent usceneComponent = this.ModeModule.FindActorByDirection(ELGUINavigationDirection.Left, true);
			if (usceneComponent != null && usceneComponent != this.GetSceneComponent())
			{
				return usceneComponent;
			}
			return this.ModeModule.FindActorByDirection(ELGUINavigationDirection.Up, true);
		}
		else
		{
			if (direction != ELGUINavigationDirection.Next)
			{
				return this.ModeModule.FindActorByDirection(direction, true);
			}
			USceneComponent usceneComponent2 = this.ModeModule.FindActorByDirection(ELGUINavigationDirection.Right, true);
			if (usceneComponent2 != null && usceneComponent2 != this.GetSceneComponent())
			{
				return usceneComponent2;
			}
			return this.ModeModule.FindActorByDirection(ELGUINavigationDirection.Down, true);
		}
	}

	// Token: 0x17001E55 RID: 7765
	// (get) Token: 0x06017062 RID: 94306 RVA: 0x00661464 File Offset: 0x0065F664
	// (set) Token: 0x06017063 RID: 94307 RVA: 0x0066149D File Offset: 0x0065F69D
	[UProperty(EPropertyFlags.CPF_None)]
	public SNavigationCursor Cursor
	{
		get
		{
			base.FastCheckIsValid();
			SNavigationCursor result;
			if ((result = this._Cursor) == null)
			{
				result = (this._Cursor = new SNavigationCursor(base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_Cursor, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SNavigationCursor.StaticStruct(), base.NativePtr + (IntPtr)TsUiNavigationBehaviorListener.__PropertyOffset_Cursor, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x06017064 RID: 94308 RVA: 0x006614C5 File Offset: 0x0065F6C5
	public FVector2D GetCursorOffset()
	{
		return this.CursorModule.GetCursorOffset();
	}

	// Token: 0x06017065 RID: 94309 RVA: 0x006614D2 File Offset: 0x0065F6D2
	public int GetCursorRotation()
	{
		return this.CursorModule.GetCursorRotation();
	}

	// Token: 0x06017066 RID: 94310 RVA: 0x006614DF File Offset: 0x0065F6DF
	public FVector2D GetBoundOffset()
	{
		return this.CursorModule.GetBoundOffset();
	}

	// Token: 0x06017067 RID: 94311 RVA: 0x006614EC File Offset: 0x0065F6EC
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsUiNavigationBehaviorListener._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationBehaviorListener.TsUiNavigationBehaviorListener_C");
		}
		return TsUiNavigationBehaviorListener._ClassPtr;
	}

	// Token: 0x06017068 RID: 94312 RVA: 0x00661510 File Offset: 0x0065F710
	public TsUiNavigationBehaviorListener() : this(BuiltinUtils.AllocNativeUObject(TsUiNavigationBehaviorListener.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017069 RID: 94313 RVA: 0x00661538 File Offset: 0x0065F738
	public TsUiNavigationBehaviorListener(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiNavigationBehaviorListener.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601706A RID: 94314 RVA: 0x0066156B File Offset: 0x0065F76B
	protected TsUiNavigationBehaviorListener(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601706B RID: 94315 RVA: 0x00661574 File Offset: 0x0065F774
	protected virtual void __CPPCALL_AwakeBP_Implementation()
	{
		this.AwakeBP_Implementation();
	}

	// Token: 0x0601706C RID: 94316 RVA: 0x0066157C File Offset: 0x0065F77C
	protected virtual void __CPPCALL_StartBP_Implementation()
	{
		this.StartBP_Implementation();
	}

	// Token: 0x0601706D RID: 94317 RVA: 0x00661584 File Offset: 0x0065F784
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OnNotifyNavigationEnterBP_Implementation(UUINavigationBehaviour.__OnNotifyNavigationEnterBP_FunctionParams* __Params)
	{
		ULGUIPointerEventData orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULGUIPointerEventData>(__Params->eventData);
		this.OnNotifyNavigationEnterBP_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601706E RID: 94318 RVA: 0x006615A4 File Offset: 0x0065F7A4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OnNotifyNavigationSelectBP_Implementation(UUINavigationBehaviour.__OnNotifyNavigationSelectBP_FunctionParams* __Params)
	{
		ULGUIPointerEventData orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULGUIPointerEventData>(__Params->eventData);
		this.OnNotifyNavigationSelectBP_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601706F RID: 94319 RVA: 0x006615C4 File Offset: 0x0065F7C4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OnCheckCanSetNavigationBP_Implementation(UUINavigationBehaviour.__OnCheckCanSetNavigationBP_FunctionParams* __Params)
	{
		__Params->__Result = this.OnCheckCanSetNavigationBP_Implementation();
	}

	// Token: 0x06017070 RID: 94320 RVA: 0x006615D2 File Offset: 0x0065F7D2
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OnCheckLoopScrollChangeNavigationBP_Implementation(UUINavigationBehaviour.__OnCheckLoopScrollChangeNavigationBP_FunctionParams* __Params)
	{
		__Params->__Result = this.OnCheckLoopScrollChangeNavigationBP_Implementation();
	}

	// Token: 0x06017071 RID: 94321 RVA: 0x006615E0 File Offset: 0x0065F7E0
	protected virtual void __CPPCALL_OnEnableBP_Implementation()
	{
		this.OnEnableBP_Implementation();
	}

	// Token: 0x06017072 RID: 94322 RVA: 0x006615E8 File Offset: 0x0065F7E8
	protected virtual void __CPPCALL_OnDisableBP_Implementation()
	{
		this.OnDisableBP_Implementation();
	}

	// Token: 0x06017073 RID: 94323 RVA: 0x006615F0 File Offset: 0x0065F7F0
	protected virtual void __CPPCALL_OnNotifyInteractiveBP_Implementation()
	{
		this.OnNotifyInteractiveBP_Implementation();
	}

	// Token: 0x06017074 RID: 94324 RVA: 0x006615F8 File Offset: 0x0065F7F8
	protected virtual void __CPPCALL_OnNotifyNotInteractiveBP_Implementation()
	{
		this.OnNotifyNotInteractiveBP_Implementation();
	}

	// Token: 0x06017075 RID: 94325 RVA: 0x00661600 File Offset: 0x0065F800
	protected virtual void __CPPCALL_OnPreDestroyBP_Implementation()
	{
		this.OnPreDestroyBP_Implementation();
	}

	// Token: 0x0400B143 RID: 45379
	[Nullable(2)]
	public UiNavigationScrollProxy ScrollProxy;

	// Token: 0x0400B144 RID: 45380
	[Nullable(2)]
	private UUILayoutBase LayoutBase;

	// Token: 0x0400B145 RID: 45381
	[Nullable(2)]
	private TsUiNavigationTextChangeListener TextChangeComponent;

	// Token: 0x0400B146 RID: 45382
	[Nullable(2)]
	public TsUiNavigationPanelConfig PanelConfig;

	// Token: 0x0400B147 RID: 45383
	private bool InNavigation;

	// Token: 0x0400B148 RID: 45384
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<string, TsUiNavigationBehaviorListener> ChildTagMap;

	// Token: 0x0400B149 RID: 45385
	[Nullable(2)]
	private NavigationSelectableBase NavigationComponent;

	// Token: 0x0400B14A RID: 45386
	private bool IsAwakeCalled;

	// Token: 0x0400B14B RID: 45387
	private bool IsStartCalled;

	// Token: 0x0400B14C RID: 45388
	private bool IsInitLayout;

	// Token: 0x0400B14D RID: 45389
	public bool IsFocusScrollbar;

	// Token: 0x0400B14E RID: 45390
	[Nullable(2)]
	private UUIInturnAnimController AnimController;

	// Token: 0x0400B14F RID: 45391
	private bool IsInitAnimController;

	// Token: 0x0400B150 RID: 45392
	[Nullable(2)]
	public AActor DynamicGridActor;

	// Token: 0x0400B151 RID: 45393
	public int InstanceId;

	// Token: 0x0400B152 RID: 45394
	[Nullable(2)]
	public UiNavigationModeModule ModeModule;

	// Token: 0x0400B153 RID: 45395
	[Nullable(2)]
	private UiNavigationCursorModule CursorModule;

	// Token: 0x0400B154 RID: 45396
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationBehaviorListener.TsUiNavigationBehaviorListener_C";

	// Token: 0x0400B155 RID: 45397
	private static IntPtr _ClassPtr;

	// Token: 0x0400B156 RID: 45398
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B157 RID: 45399
	private static int __PropertyOffset_GroupName;

	// Token: 0x0400B158 RID: 45400
	private static int __PropertyOffset_TagArray;

	// Token: 0x0400B159 RID: 45401
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _TagArray;

	// Token: 0x0400B15A RID: 45402
	private static int __PropertyOffset_ExitTagPriority;

	// Token: 0x0400B15B RID: 45403
	private static int __PropertyOffset_ShieldHotKeyIndexArray;

	// Token: 0x0400B15C RID: 45404
	[Nullable(2)]
	private TArray<int> _ShieldHotKeyIndexArray;

	// Token: 0x0400B15D RID: 45405
	private static int __PropertyOffset_ScrollViewActor;

	// Token: 0x0400B15E RID: 45406
	private static int __PropertyOffset_GridBaseActor;

	// Token: 0x0400B15F RID: 45407
	private static int __PropertyOffset_LayoutActor;

	// Token: 0x0400B160 RID: 45408
	private static int __PropertyOffset_HotKeyTipsTextIdMap;

	// Token: 0x0400B161 RID: 45409
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<EHotKeyNameStateType, string> _HotKeyTipsTextIdMap;

	// Token: 0x0400B162 RID: 45410
	private static int __PropertyOffset_ClickPivot;

	// Token: 0x0400B163 RID: 45411
	private static int __PropertyOffset_InsideGroupActor;

	// Token: 0x0400B164 RID: 45412
	private static int __PropertyOffset_InsideActorMap;

	// Token: 0x0400B165 RID: 45413
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private TMap<string, AActor> _InsideActorMap;

	// Token: 0x0400B166 RID: 45414
	private static int __PropertyOffset_ScrollbarIndex;

	// Token: 0x0400B167 RID: 45415
	private static int __PropertyOffset_InteractiveTag;

	// Token: 0x0400B168 RID: 45416
	private static int __PropertyOffset_InteractiveParam;

	// Token: 0x0400B169 RID: 45417
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _InteractiveParam;

	// Token: 0x0400B16A RID: 45418
	private static int __PropertyOffset_DynamicTag;

	// Token: 0x0400B16B RID: 45419
	private static int __PropertyOffset_OpenAdsorbed;

	// Token: 0x0400B16C RID: 45420
	private static int __PropertyOffset_AdsorbedDistance;

	// Token: 0x0400B16D RID: 45421
	private static int __PropertyOffset_AdsorbedPivot;

	// Token: 0x0400B16E RID: 45422
	private static int __PropertyOffset_IsUseDrag;

	// Token: 0x0400B16F RID: 45423
	private static int __PropertyOffset_IsUsePool;

	// Token: 0x0400B170 RID: 45424
	private static int __PropertyOffset_NavigateTolerance;

	// Token: 0x0400B171 RID: 45425
	private static int __PropertyOffset_NavigateToleranceReverse;

	// Token: 0x0400B172 RID: 45426
	private static int __PropertyOffset_NavigationMode;

	// Token: 0x0400B173 RID: 45427
	[Nullable(2)]
	private SNavigationMode _NavigationMode;

	// Token: 0x0400B174 RID: 45428
	private static int __PropertyOffset_Cursor;

	// Token: 0x0400B175 RID: 45429
	[Nullable(2)]
	private SNavigationCursor _Cursor;
}
