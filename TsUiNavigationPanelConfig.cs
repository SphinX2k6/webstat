using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiNavigation.Struct;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiNavigation;
using CSharpScript.Game.Module.UiNavigation.UIComponent;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002CC2 RID: 11458
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Module/UiNavigation/New/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationPanelConfig.TsUiNavigationPanelConfig_C")]
public class TsUiNavigationPanelConfig : ULGUIBehaviour, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001E56 RID: 7766
	// (get) Token: 0x06017076 RID: 94326 RVA: 0x00661608 File Offset: 0x0065F808
	// (set) Token: 0x06017077 RID: 94327 RVA: 0x0066161C File Offset: 0x0065F81C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ViewName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_ViewName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_ViewName)), value);
		}
	}

	// Token: 0x17001E57 RID: 7767
	// (get) Token: 0x06017078 RID: 94328 RVA: 0x00661631 File Offset: 0x0065F831
	// (set) Token: 0x06017079 RID: 94329 RVA: 0x00661641 File Offset: 0x0065F841
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Independent
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_Independent) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_Independent) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001E58 RID: 7768
	// (get) Token: 0x0601707A RID: 94330 RVA: 0x00661652 File Offset: 0x0065F852
	// (set) Token: 0x0601707B RID: 94331 RVA: 0x00661662 File Offset: 0x0065F862
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsChildPanel
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_IsChildPanel) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_IsChildPanel) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001E59 RID: 7769
	// (get) Token: 0x0601707C RID: 94332 RVA: 0x00661673 File Offset: 0x0065F873
	// (set) Token: 0x0601707D RID: 94333 RVA: 0x00661683 File Offset: 0x0065F883
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NeedCacheListener
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_NeedCacheListener) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_NeedCacheListener) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001E5A RID: 7770
	// (get) Token: 0x0601707E RID: 94334 RVA: 0x00661694 File Offset: 0x0065F894
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<AActor> DefaultNavigationActor
	{
		get
		{
			base.FastCheckIsValid();
			TArray<AActor> result;
			if ((result = this._DefaultNavigationActor) == null)
			{
				result = (this._DefaultNavigationActor = new TArray<AActor>(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_DefaultNavigationActor, this));
			}
			return result;
		}
	}

	// Token: 0x17001E5B RID: 7771
	// (get) Token: 0x0601707F RID: 94335 RVA: 0x006616D0 File Offset: 0x0065F8D0
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, SNavigationDynamicListenerConfig> DynamicListenerConfigMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, SNavigationDynamicListenerConfig> result;
			if ((result = this._DynamicListenerConfigMap) == null)
			{
				result = (this._DynamicListenerConfigMap = new TMap<string, SNavigationDynamicListenerConfig>(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_DynamicListenerConfigMap, this));
			}
			return result;
		}
	}

	// Token: 0x17001E5C RID: 7772
	// (get) Token: 0x06017080 RID: 94336 RVA: 0x0066170C File Offset: 0x0065F90C
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SNavigationGroup> NormalGroup
	{
		get
		{
			base.FastCheckIsValid();
			TArray<SNavigationGroup> result;
			if ((result = this._NormalGroup) == null)
			{
				result = (this._NormalGroup = new TArray<SNavigationGroup>(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_NormalGroup, this));
			}
			return result;
		}
	}

	// Token: 0x17001E5D RID: 7773
	// (get) Token: 0x06017081 RID: 94337 RVA: 0x00661748 File Offset: 0x0065F948
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SNavigationGroup> BookmarkGroup
	{
		get
		{
			base.FastCheckIsValid();
			TArray<SNavigationGroup> result;
			if ((result = this._BookmarkGroup) == null)
			{
				result = (this._BookmarkGroup = new TArray<SNavigationGroup>(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_BookmarkGroup, this));
			}
			return result;
		}
	}

	// Token: 0x17001E5E RID: 7774
	// (get) Token: 0x06017082 RID: 94338 RVA: 0x00661784 File Offset: 0x0065F984
	// (set) Token: 0x06017083 RID: 94339 RVA: 0x006617BD File Offset: 0x0065F9BD
	[UProperty(EPropertyFlags.CPF_None)]
	public SNavigationGroup ScrollBarGroup
	{
		get
		{
			base.FastCheckIsValid();
			SNavigationGroup result;
			if ((result = this._ScrollBarGroup) == null)
			{
				result = (this._ScrollBarGroup = new SNavigationGroup(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_ScrollBarGroup, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SNavigationGroup.StaticStruct(), base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_ScrollBarGroup, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17001E5F RID: 7775
	// (get) Token: 0x06017084 RID: 94340 RVA: 0x006617E5 File Offset: 0x0065F9E5
	// (set) Token: 0x06017085 RID: 94341 RVA: 0x006617F5 File Offset: 0x0065F9F5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool AllowNavigateInKeyBoard
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_AllowNavigateInKeyBoard) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_AllowNavigateInKeyBoard) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001E60 RID: 7776
	// (get) Token: 0x06017086 RID: 94342 RVA: 0x00661806 File Offset: 0x0065FA06
	// (set) Token: 0x06017087 RID: 94343 RVA: 0x00661816 File Offset: 0x0065FA16
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool FirstFindFromSubPanelWhenFindNone
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_FirstFindFromSubPanelWhenFindNone) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_FirstFindFromSubPanelWhenFindNone) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001E61 RID: 7777
	// (get) Token: 0x06017088 RID: 94344 RVA: 0x00661827 File Offset: 0x0065FA27
	// (set) Token: 0x06017089 RID: 94345 RVA: 0x0066183B File Offset: 0x0065FA3B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string InteractiveTag
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_InteractiveTag)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsUiNavigationPanelConfig.__PropertyOffset_InteractiveTag)), value);
		}
	}

	// Token: 0x0601708A RID: 94346 RVA: 0x00661850 File Offset: 0x0065FA50
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

	// Token: 0x0601708B RID: 94347 RVA: 0x006618C0 File Offset: 0x0065FAC0
	protected virtual void AwakeBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		this.InitDefaultParam();
		this.InitDynamicListenerIndexMap();
		this.InitPanelHandle();
	}

	// Token: 0x0601708C RID: 94348 RVA: 0x006618DC File Offset: 0x0065FADC
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

	// Token: 0x0601708D RID: 94349 RVA: 0x0066194C File Offset: 0x0065FB4C
	protected virtual void StartBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		this.NavigationViewCreate();
	}

	// Token: 0x0601708E RID: 94350 RVA: 0x0066195C File Offset: 0x0065FB5C
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

	// Token: 0x0601708F RID: 94351 RVA: 0x006619CC File Offset: 0x0065FBCC
	protected virtual void OnEnableBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		this.IsInActive = true;
		this.HandleAddPanel();
		this.HandleUIActivePanel();
		this.HandleChildUIActivePanel();
	}

	// Token: 0x06017090 RID: 94352 RVA: 0x006619F0 File Offset: 0x0065FBF0
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

	// Token: 0x06017091 RID: 94353 RVA: 0x00661A60 File Offset: 0x0065FC60
	protected virtual void OnDisableBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		this.IsInActive = false;
		this.HandleAddPanel();
		this.HandleUIActivePanel();
		this.HandleChildUIActivePanel();
		if (this.LastFindResultWasWaitingScrollAnimation)
		{
			UiNavigationViewHandle viewHandle = this.ViewHandle;
			if (viewHandle == null)
			{
				return;
			}
			viewHandle.NotifyWaitingScrollPanelHidden();
		}
	}

	// Token: 0x06017092 RID: 94354 RVA: 0x00661A9B File Offset: 0x0065FC9B
	private void HandleUIActivePanel()
	{
		if (this.Independent)
		{
			this.HandleViewHandleFunction(delegate
			{
				UiNavigationViewHandle viewHandle = this.ViewHandle;
				if (viewHandle == null)
				{
					return;
				}
				viewHandle.SetIsActive(this.IsInActive);
			});
		}
	}

	// Token: 0x06017093 RID: 94355 RVA: 0x00661AB7 File Offset: 0x0065FCB7
	private void HandleAddPanel()
	{
		if (this.IsInActive)
		{
			UiNavigationViewHandle viewHandle = this.ViewHandle;
			if (viewHandle == null)
			{
				return;
			}
			viewHandle.SetCurrentAddPanel(this);
		}
	}

	// Token: 0x06017094 RID: 94356 RVA: 0x00661AD2 File Offset: 0x0065FCD2
	private void HandleChildUIActivePanel()
	{
		if (this.IsChildPanel && this.Independent)
		{
			UiNavigationViewHandle viewHandle = this.ViewHandle;
			if (viewHandle == null)
			{
				return;
			}
			viewHandle.SetIsUsable(this.IsInActive);
		}
	}

	// Token: 0x06017095 RID: 94357 RVA: 0x00661AFC File Offset: 0x0065FCFC
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

	// Token: 0x06017096 RID: 94358 RVA: 0x00661B6C File Offset: 0x0065FD6C
	protected virtual void OnPreDestroyBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		SpecialPanelHandleBase panelHandle = this.PanelHandle;
		if (panelHandle != null)
		{
			panelHandle.Clear();
		}
		this.NavigationViewDestroy();
		this.ViewHandle = null;
	}

	// Token: 0x06017097 RID: 94359 RVA: 0x00661B94 File Offset: 0x0065FD94
	private void InitDefaultParam()
	{
		this.HotKeyItemSet = new HashSet<HotKeyItem>();
	}

	// Token: 0x06017098 RID: 94360 RVA: 0x00661BA4 File Offset: 0x0065FDA4
	private void InitDynamicListenerIndexMap()
	{
		this.DynamicListenerIndexMap = new Dictionary<int, bool>();
		foreach (SNavigationDynamicListenerConfig snavigationDynamicListenerConfig in this.DynamicListenerConfigMap.Values)
		{
			if (snavigationDynamicListenerConfig != null)
			{
				this.DynamicListenerIndexMap[snavigationDynamicListenerConfig.Index] = snavigationDynamicListenerConfig.NeedWaitRegister;
			}
		}
	}

	// Token: 0x06017099 RID: 94361 RVA: 0x00661C24 File Offset: 0x0065FE24
	private void NavigationViewCreate()
	{
		this.IncId = ++UiNavigationUtil.IncId;
		Singleton<EventSystem>.Instance.Emit<int, AActor>(EEventName.NavigationViewCreate, this.IncId, base.GetOwner());
	}

	// Token: 0x0601709A RID: 94362 RVA: 0x00661C55 File Offset: 0x0065FE55
	private void NavigationViewDestroy()
	{
		Singleton<EventSystem>.Instance.Emit<int, AActor>(EEventName.NavigationViewDestroy, this.IncId, base.GetOwner());
	}

	// Token: 0x0601709B RID: 94363 RVA: 0x00661C74 File Offset: 0x0065FE74
	private Dictionary<string, NavigationGroup> GetGroupMap()
	{
		Dictionary<string, NavigationGroup> dictionary = new Dictionary<string, NavigationGroup>();
		int i = 0;
		int num = this.NormalGroup.Num();
		while (i < num)
		{
			SNavigationGroup snavigationGroup = this.NormalGroup.Get(i);
			snavigationGroup.GroupType = 0;
			NavigationGroup value = new NavigationGroup(snavigationGroup);
			dictionary[snavigationGroup.GroupName] = value;
			i++;
		}
		int j = 0;
		int num2 = this.BookmarkGroup.Num();
		while (j < num2)
		{
			SNavigationGroup snavigationGroup2 = this.BookmarkGroup.Get(j);
			snavigationGroup2.GroupType = 1;
			NavigationGroup value2 = new NavigationGroup(snavigationGroup2);
			dictionary[snavigationGroup2.GroupName] = value2;
			j++;
		}
		if (this.ScrollBarGroup != null)
		{
			this.ScrollBarGroup.GroupType = 2;
			this.TsScrollBarGroup = new NavigationGroup(this.ScrollBarGroup);
			dictionary[this.ScrollBarGroup.GroupName] = this.TsScrollBarGroup;
		}
		return dictionary;
	}

	// Token: 0x0601709C RID: 94364 RVA: 0x00661D5C File Offset: 0x0065FF5C
	private void InitPanelHandle()
	{
		this.PanelHandle = NavigationPanelHandleCreator.GetPanelHandle(this.InteractiveTag);
		if (this.PanelHandle != null)
		{
			this.PanelHandle.Init();
			this.PanelHandle.SetGroupMap(this.GetGroupMap());
			this.PanelHandle.SetDefaultNavigationListenerList(this.DefaultNavigationActor);
		}
	}

	// Token: 0x0601709D RID: 94365 RVA: 0x00661DAF File Offset: 0x0065FFAF
	private void HandleViewHandleFunction(Action handleFunction)
	{
		if (this.ViewHandle != null)
		{
			handleFunction();
			return;
		}
		if (this.ViewHandleCacheFunctionList == null)
		{
			this.ViewHandleCacheFunctionList = new List<Action>();
		}
		this.ViewHandleCacheFunctionList.Add(handleFunction);
	}

	// Token: 0x0601709E RID: 94366 RVA: 0x00661DE0 File Offset: 0x0065FFE0
	private void ExecuteViewHandleFunction()
	{
		if (this.ViewHandleCacheFunctionList != null)
		{
			foreach (Action action in this.ViewHandleCacheFunctionList)
			{
				action();
			}
			this.ViewHandleCacheFunctionList = new List<Action>();
		}
	}

	// Token: 0x0601709F RID: 94367 RVA: 0x00661E44 File Offset: 0x00660044
	public void RegisterNavigationListener(TsUiNavigationBehaviorListener listener)
	{
		if (this.PanelHandle == null)
		{
			return;
		}
		this.PanelHandle.AddListener(listener);
		listener.GetNavigationComponent().SetPanelHandle(this.PanelHandle);
		listener.GetNavigationComponent().Start();
		if (StringUtils.IsEmpty(listener.GroupName))
		{
			return;
		}
		NavigationGroup navigationGroup = this.PanelHandle.GetNavigationGroup(listener.GroupName);
		if (navigationGroup == null)
		{
			return;
		}
		navigationGroup.AddListener(listener);
		if (navigationGroup.GroupType == 2)
		{
			this.HandleViewHandleFunction(delegate
			{
				UiNavigationViewHandle viewHandle = this.ViewHandle;
				if (viewHandle == null)
				{
					return;
				}
				viewHandle.MarkRefreshScrollDataDirty();
			});
		}
	}

	// Token: 0x060170A0 RID: 94368 RVA: 0x00661EC8 File Offset: 0x006600C8
	public unsafe void DynamicListenerConfigHandle(TsUiNavigationBehaviorListener listener)
	{
		if (this.PanelHandle == null)
		{
			return;
		}
		string dynamicTag = listener.DynamicTag;
		if (StringUtils.IsBlank(dynamicTag))
		{
			return;
		}
		SNavigationDynamicListenerConfig valueOrDefault = this.DynamicListenerConfigMap.GetValueOrDefault(dynamicTag);
		if (valueOrDefault == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "导航监听组件找不到对应的动态配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("导航组名字", listener.GroupName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ViewName", this.ViewName);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (valueOrDefault.LayoutActor != null)
		{
			listener.LayoutActor = valueOrDefault.LayoutActor;
		}
		if (valueOrDefault.ScrollActor != null)
		{
			listener.ScrollViewActor = valueOrDefault.ScrollActor;
		}
		if (StringUtils.IsBlank(listener.GroupName))
		{
			return;
		}
		if (this.PanelHandle.GetNavigationGroup(listener.GroupName) == null)
		{
			return;
		}
		this.PanelHandle.ReplaceDefaultNavigationListener(listener, valueOrDefault.Index);
	}

	// Token: 0x060170A1 RID: 94369 RVA: 0x00661FC1 File Offset: 0x006601C1
	public void UnRegisterNavigationListener(TsUiNavigationBehaviorListener listener)
	{
		if (this.PanelHandle == null)
		{
			return;
		}
		this.PanelHandle.TryRemoveListener(listener);
	}

	// Token: 0x060170A2 RID: 94370 RVA: 0x00661FD8 File Offset: 0x006601D8
	[NullableContext(2)]
	public void SetViewHandle(UiNavigationViewHandle viewHandle)
	{
		this.ViewHandle = viewHandle;
		this.ExecuteViewHandleFunction();
	}

	// Token: 0x060170A3 RID: 94371 RVA: 0x00661FE7 File Offset: 0x006601E7
	[return: Nullable(2)]
	public NavigationGroup GetNavigationGroup(string groupName)
	{
		SpecialPanelHandleBase panelHandle = this.PanelHandle;
		if (panelHandle == null)
		{
			return null;
		}
		return panelHandle.GetNavigationGroup(groupName);
	}

	// Token: 0x060170A4 RID: 94372 RVA: 0x00661FFB File Offset: 0x006601FB
	[NullableContext(2)]
	public TsUiNavigationBehaviorListener GetFocusListener()
	{
		UiNavigationViewHandle viewHandle = this.ViewHandle;
		if (viewHandle == null)
		{
			return null;
		}
		return viewHandle.GetFocusListener();
	}

	// Token: 0x060170A5 RID: 94373 RVA: 0x0066200E File Offset: 0x0066020E
	public SpecialPanelHandleBase GetPanelHandle()
	{
		return this.PanelHandle;
	}

	// Token: 0x060170A6 RID: 94374 RVA: 0x00662018 File Offset: 0x00660218
	private void CommonFindNavigationLogic(FindNavigationResult result)
	{
		if (!this.IsAllowNavigate())
		{
			result.Result = EFindNavigationResult.CantFocus;
			return;
		}
		UUIItem uuiitem = base.RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		if (!uuiitem.IsUIActiveInHierarchy())
		{
			result.Result = EFindNavigationResult.CantFocus;
			return;
		}
		if (this.FindAction != null)
		{
			this.FindAction.FindNavigation(result);
			if (result.IsFinishFind())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "结束导航行为";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("动作", this.FindAction.GetType().Name);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.FindAction = null;
			}
			return;
		}
		UiNavigationViewHandle viewHandle = this.ViewHandle;
		if (viewHandle != null && viewHandle.IsWaitToFindDynamicGrid)
		{
			NavigationDynamicScrollViewFindContext dynamicScrollViewNavigationContext = this.ViewHandle.GetDynamicScrollViewNavigationContext();
			UUIDynScrollViewComponent uuidynScrollViewComponent = dynamicScrollViewNavigationContext.ScrollView as UUIDynScrollViewComponent;
			if (!uuidynScrollViewComponent.IsAllDisplayItemUpdateCompleted())
			{
				result.Result = EFindNavigationResult.DynamicScrollViewNotReady;
				return;
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = UiNavigationModeModule.FindDynamicScrollViewNavigationComponent(dynamicScrollViewNavigationContext);
			if (tsUiNavigationBehaviorListener != null && tsUiNavigationBehaviorListener.IsCanFocus())
			{
				result.Result = EFindNavigationResult.CanFocus;
				result.Listener = tsUiNavigationBehaviorListener;
				uuidynScrollViewComponent.NavigateScrollToUIItem(tsUiNavigationBehaviorListener.RootUIComp, dynamicScrollViewNavigationContext.Reversed, dynamicScrollViewNavigationContext.WrapMode);
				this.ViewHandle.ClearDynamicScrollViewNavigationContext();
				return;
			}
			TsUiNavigationBehaviorListener lastListener = dynamicScrollViewNavigationContext.LastListener;
			if (lastListener != null && lastListener.IsCanFocus())
			{
				result.Result = EFindNavigationResult.CanFocus;
				result.Listener = dynamicScrollViewNavigationContext.LastListener;
				this.ViewHandle.ClearDynamicScrollViewNavigationContext();
				return;
			}
		}
		result.Result = EFindNavigationResult.None;
	}

	// Token: 0x060170A7 RID: 94375 RVA: 0x00662180 File Offset: 0x00660380
	public void CommonFindNavigationByListener(FindNavigationResult result, [Nullable(2)] TsUiNavigationBehaviorListener listener, bool needWaitRegister)
	{
		if (listener == null)
		{
			if (needWaitRegister)
			{
				result.Result = EFindNavigationResult.WaitDynamicListener;
				return;
			}
			result.Result = EFindNavigationResult.None;
			return;
		}
		else
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = listener;
			if (listener.IsScrollOrLayoutActor())
			{
				if (!listener.IsScrollOrLayoutActive())
				{
					result.Result = EFindNavigationResult.None;
					return;
				}
				NavigationGroup navigationGroup = listener.GetNavigationGroup();
				if ((navigationGroup == null || navigationGroup.WaitScrollAnimation) && listener.IsInScrollOrLayoutAnimation())
				{
					result.Result = EFindNavigationResult.LoopOrLayoutAnimation;
					return;
				}
				if (listener.HasDynamicScrollView())
				{
					UiNavigationScrollProxy scrollProxy = listener.ScrollProxy;
					UUIDynScrollViewComponent uuidynScrollViewComponent = ((scrollProxy != null) ? scrollProxy.ScrollView : null) as UUIDynScrollViewComponent;
					if (uuidynScrollViewComponent == null || !uuidynScrollViewComponent.IsAllDisplayItemUpdateCompleted())
					{
						result.Result = EFindNavigationResult.DynamicScrollViewNotReady;
						return;
					}
				}
				SpecialPanelHandleBase panelHandle = this.PanelHandle;
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = (panelHandle != null) ? panelHandle.GetLoopOrLayoutListener(listener) : null;
				if (tsUiNavigationBehaviorListener2 == null)
				{
					result.Result = EFindNavigationResult.None;
					return;
				}
				tsUiNavigationBehaviorListener = tsUiNavigationBehaviorListener2;
			}
			else
			{
				NavigationGroup navigationGroup2 = listener.GetNavigationGroup();
				if (navigationGroup2 != null && navigationGroup2.SuitableListenerByNoDynamic)
				{
					SpecialPanelHandleBase panelHandle2 = this.PanelHandle;
					TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener3 = (panelHandle2 != null) ? panelHandle2.GetSuitableListenerWithoutLayout(listener) : null;
					if (tsUiNavigationBehaviorListener3 != null)
					{
						tsUiNavigationBehaviorListener = tsUiNavigationBehaviorListener3;
					}
				}
			}
			if (!tsUiNavigationBehaviorListener.IsCanFocus())
			{
				result.Result = EFindNavigationResult.None;
				return;
			}
			if (!tsUiNavigationBehaviorListener.IsRegisterToPanelConfig())
			{
				result.Result = EFindNavigationResult.WaitRegisterToPanelConfig;
				return;
			}
			result.Result = EFindNavigationResult.CanFocus;
			result.Listener = tsUiNavigationBehaviorListener;
			return;
		}
	}

	// Token: 0x060170A8 RID: 94376 RVA: 0x00662298 File Offset: 0x00660498
	public void FindSuitableNavigation(bool isDefault)
	{
		FindNavigationResult findNavigationResult = new FindNavigationResult();
		this.CommonFindNavigationLogic(findNavigationResult);
		if (findNavigationResult.Result == EFindNavigationResult.None)
		{
			SpecialPanelHandleBase panelHandle = this.PanelHandle;
			List<TsUiNavigationBehaviorListener> list = (panelHandle != null) ? panelHandle.GetSuitableNavigationListenerList(isDefault) : null;
			if (list != null)
			{
				int i = 0;
				int count = list.Count;
				while (i < count)
				{
					TsUiNavigationBehaviorListener listener = list[i];
					Dictionary<int, bool> dynamicListenerIndexMap = this.DynamicListenerIndexMap;
					bool needWaitRegister = dynamicListenerIndexMap == null || dynamicListenerIndexMap.GetValueOrDefault(i, true);
					this.CommonFindNavigationByListener(findNavigationResult, listener, needWaitRegister);
					if (findNavigationResult.Result != EFindNavigationResult.None)
					{
						break;
					}
					i++;
				}
			}
			if (findNavigationResult.Result == EFindNavigationResult.None)
			{
				findNavigationResult.Result = EFindNavigationResult.CantFocus;
			}
		}
		this.LastFindResultWasWaitingScrollAnimation = TsUiNavigationPanelConfig.IsWaitingScrollAnimationResult(findNavigationResult.Result);
		SpecialPanelHandleBase panelHandle2 = this.PanelHandle;
		if (panelHandle2 != null)
		{
			panelHandle2.NotifyFindResult(findNavigationResult);
		}
		UiNavigationViewHandle viewHandle = this.ViewHandle;
		if (viewHandle == null)
		{
			return;
		}
		viewHandle.NotifySuitableNavigation(findNavigationResult);
	}

	// Token: 0x060170A9 RID: 94377 RVA: 0x00662359 File Offset: 0x00660559
	private static bool IsWaitingScrollAnimationResult(EFindNavigationResult value)
	{
		return value == EFindNavigationResult.WaitDynamicListener || value == EFindNavigationResult.LoopOrLayoutAnimation || value == EFindNavigationResult.DynamicScrollViewNotReady || value == EFindNavigationResult.WaitRegisterToPanelConfig;
	}

	// Token: 0x060170AA RID: 94378 RVA: 0x00662370 File Offset: 0x00660570
	public void SetFindNavigationAction(FindActionBase findAction)
	{
		this.FindAction = findAction;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiNavigation;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "新增导航行为";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("动作", findAction.GetType().Name);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x060170AB RID: 94379 RVA: 0x006623B8 File Offset: 0x006605B8
	private bool CheckReFindCondition()
	{
		if (this.ViewHandle == null)
		{
			return false;
		}
		if (!this.IsInActive && this.Independent)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "[ReFindNavigation]独立界面刚刚隐藏,触发导航对象取消不做通知处理", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (this.ViewHandle.HasNavigationButDisActive())
		{
			Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "[ReFindNavigation]界面已经处于HasNavigationButDisActive状态,触发导航对象取消不做通知处理", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return this.Independent || this.ViewHandle.GetIsActive();
	}

	// Token: 0x060170AC RID: 94380 RVA: 0x00662446 File Offset: 0x00660646
	public void ReFindNavigation()
	{
		if (!this.CheckReFindCondition())
		{
			return;
		}
		UiNavigationViewHandle viewHandle = this.ViewHandle;
		if (viewHandle == null)
		{
			return;
		}
		viewHandle.MarkRefreshNavigationDirty(0);
	}

	// Token: 0x060170AD RID: 94381 RVA: 0x00662462 File Offset: 0x00660662
	public void ReFindScrollbar()
	{
		if (this.ViewHandle == null)
		{
			return;
		}
		this.ViewHandle.FindNextScrollData();
	}

	// Token: 0x060170AE RID: 94382 RVA: 0x00662478 File Offset: 0x00660678
	public void TryFindScrollbar()
	{
		if (this.ViewHandle == null)
		{
			return;
		}
		this.ViewHandle.TryFindScrollData();
	}

	// Token: 0x060170AF RID: 94383 RVA: 0x0066248E File Offset: 0x0066068E
	public void FindNavigationInNoneState()
	{
		if (this.ViewHandle == null)
		{
			return;
		}
		if (!this.ViewHandle.IsNonNavigation())
		{
			return;
		}
		this.ViewHandle.MarkResetCurrentPanelDirty();
		this.ViewHandle.MarkRefreshNavigationDirty(0);
	}

	// Token: 0x060170B0 RID: 94384 RVA: 0x006624C0 File Offset: 0x006606C0
	public bool IsAllowNavigate()
	{
		bool flag = Singleton<Info>.Instance.IsInGamepad();
		return this.AllowNavigateInKeyBoard || flag;
	}

	// Token: 0x060170B1 RID: 94385 RVA: 0x006624E0 File Offset: 0x006606E0
	public bool CanOverrideFindNavigation(ELGUINavigationDirection direction, TsUiNavigationBehaviorListener lastListener, [Nullable(2)] TsUiNavigationBehaviorListener targetListener)
	{
		return this.PanelHandle != null && this.PanelHandle.CanOverrideFindNavigation(direction, lastListener, targetListener);
	}

	// Token: 0x060170B2 RID: 94386 RVA: 0x006624FA File Offset: 0x006606FA
	[NullableContext(2)]
	public TsUiNavigationBehaviorListener HandleOverrideFindNavigation(ELGUINavigationDirection direction, [Nullable(1)] TsUiNavigationBehaviorListener lastListener, TsUiNavigationBehaviorListener targetListener)
	{
		if (this.PanelHandle == null)
		{
			return null;
		}
		return this.PanelHandle.HandleOverrideFindNavigation(direction, lastListener, targetListener);
	}

	// Token: 0x060170B3 RID: 94387 RVA: 0x00662514 File Offset: 0x00660714
	[NullableContext(2)]
	public TsUiNavigationBehaviorListener HandleAfterFindOpposite(ELGUINavigationDirection direction, [Nullable(1)] TsUiNavigationBehaviorListener lastListener, TsUiNavigationBehaviorListener targetListener, bool isPositive)
	{
		if (this.PanelHandle == null)
		{
			return null;
		}
		return this.PanelHandle.HandleAfterFindOpposite(direction, lastListener, targetListener, isPositive);
	}

	// Token: 0x060170B4 RID: 94388 RVA: 0x00662530 File Offset: 0x00660730
	public void AddHotKeyItem(HotKeyItem hotKeyItem)
	{
		HashSet<HotKeyItem> hotKeyItemSet = this.HotKeyItemSet;
		if (hotKeyItemSet != null)
		{
			hotKeyItemSet.Add(hotKeyItem);
		}
		this.HandleAsyncHotKeyState(hotKeyItem);
	}

	// Token: 0x060170B5 RID: 94389 RVA: 0x0066254C File Offset: 0x0066074C
	private void HandleAsyncHotKeyState(HotKeyItem hotKeyItem)
	{
		foreach (KeyValuePair<HotKeyViewDefine.ELogicMode, bool> keyValuePair in this.GetOrCreateCacheHotKeyStateMap())
		{
			HotKeyViewDefine.ELogicMode key = keyValuePair.Key;
			bool value = keyValuePair.Value;
			foreach (HotKeyComponent hotKeyComponent in hotKeyItem.GetHotKeyComponentArray())
			{
				if (hotKeyComponent != null)
				{
					hotKeyComponent.SetVisibleMode(key, value, false);
				}
				if (this.ViewHandle != null)
				{
					if (hotKeyComponent != null)
					{
						hotKeyComponent.RefreshSelfHotKeyState(this.ViewHandle);
					}
					if (hotKeyComponent != null)
					{
						hotKeyComponent.RefreshSelfHotKeyText(this.ViewHandle);
					}
				}
			}
		}
		if (this.CacheHotKeyComponentCallbackMap != null)
		{
			foreach (Action<HotKeyItem> action in this.CacheHotKeyComponentCallbackMap.Values)
			{
				action(hotKeyItem);
			}
		}
	}

	// Token: 0x060170B6 RID: 94390 RVA: 0x00662674 File Offset: 0x00660874
	private Dictionary<HotKeyViewDefine.ELogicMode, bool> GetOrCreateCacheHotKeyStateMap()
	{
		if (this.CacheHotKeyStateMap == null)
		{
			this.CacheHotKeyStateMap = new Dictionary<HotKeyViewDefine.ELogicMode, bool>();
		}
		return this.CacheHotKeyStateMap;
	}

	// Token: 0x060170B7 RID: 94391 RVA: 0x0066268F File Offset: 0x0066088F
	public void DeleteKeyItem(HotKeyItem hotKeyItem)
	{
		HashSet<HotKeyItem> hotKeyItemSet = this.HotKeyItemSet;
		if (hotKeyItemSet == null)
		{
			return;
		}
		hotKeyItemSet.Remove(hotKeyItem);
	}

	// Token: 0x060170B8 RID: 94392 RVA: 0x006626A4 File Offset: 0x006608A4
	public void SetHotKeyVisibleMode(HotKeyViewDefine.ELogicMode mode, bool active)
	{
		this.GetOrCreateCacheHotKeyStateMap()[mode] = active;
		if (this.HotKeyItemSet == null)
		{
			return;
		}
		if (this.HotKeyItemSet != null)
		{
			foreach (HotKeyItem hotKeyItem in this.HotKeyItemSet)
			{
				foreach (HotKeyComponent hotKeyComponent in hotKeyItem.GetHotKeyComponentArray())
				{
					if (hotKeyComponent != null)
					{
						hotKeyComponent.SetVisibleMode(mode, active, false);
					}
				}
			}
		}
	}

	// Token: 0x060170B9 RID: 94393 RVA: 0x00662754 File Offset: 0x00660954
	public void NotifyListenerFocus(TsUiNavigationBehaviorListener listener)
	{
		if (this.ViewHandle == null)
		{
			this.HandleViewHandleFunction(delegate
			{
				this.NotifyListenerFocus(listener);
			});
			return;
		}
		if (!this.ViewHandle.IsListenerCanFocusByPanelConfig)
		{
			return;
		}
		if (!this.IsAllowNavigate())
		{
			return;
		}
		this.ViewHandle.UpdateFocus(listener);
	}

	// Token: 0x060170BA RID: 94394 RVA: 0x006627B8 File Offset: 0x006609B8
	public void UpdateHotKeyTextForce(TArray<string> tagArray, string text)
	{
		foreach (HotKeyItem hotKeyItem in this.HotKeyItemSet)
		{
			foreach (HotKeyComponent hotKeyComponent in hotKeyItem.GetHotKeyComponentArray())
			{
				string value = (hotKeyComponent != null) ? hotKeyComponent.GetBindButtonTag() : null;
				if (tagArray.Contains(value) && hotKeyComponent != null)
				{
					hotKeyComponent.SetHotKeyDescTextForce(text);
				}
			}
		}
	}

	// Token: 0x060170BB RID: 94395 RVA: 0x00662860 File Offset: 0x00660A60
	public List<TsUiNavigationBehaviorListener> GetListenerListByTag(string tag)
	{
		SpecialPanelHandleBase panelHandle = this.PanelHandle;
		return ((panelHandle != null) ? panelHandle.GetListenerListByTag(tag) : null) ?? new List<TsUiNavigationBehaviorListener>();
	}

	// Token: 0x060170BC RID: 94396 RVA: 0x00662880 File Offset: 0x00660A80
	public void RefreshHotKeyComponents()
	{
		if (this.HotKeyItemSet == null)
		{
			return;
		}
		foreach (HotKeyItem hotKeyItem in this.HotKeyItemSet)
		{
			foreach (HotKeyComponent hotKeyComponent in hotKeyItem.GetHotKeyComponentArray())
			{
				if (hotKeyComponent != null)
				{
					hotKeyComponent.RefreshSelfHotKeyState(this.ViewHandle);
				}
				if (hotKeyComponent != null)
				{
					hotKeyComponent.RefreshSelfHotKeyText(this.ViewHandle);
				}
			}
		}
	}

	// Token: 0x060170BD RID: 94397 RVA: 0x00662930 File Offset: 0x00660B30
	public void RefreshHotKeyTextId()
	{
		if (this.HotKeyItemSet == null)
		{
			return;
		}
		foreach (HotKeyItem hotKeyItem in this.HotKeyItemSet)
		{
			foreach (HotKeyComponent hotKeyComponent in hotKeyItem.GetHotKeyComponentArray())
			{
				if (hotKeyComponent != null)
				{
					hotKeyComponent.RefreshSelfHotKeyText(this.ViewHandle);
				}
			}
		}
	}

	// Token: 0x17001E62 RID: 7778
	// (get) Token: 0x060170BE RID: 94398 RVA: 0x006629D0 File Offset: 0x00660BD0
	// (set) Token: 0x060170BF RID: 94399 RVA: 0x006629E4 File Offset: 0x00660BE4
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor GamepadMouseActor
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + TsUiNavigationPanelConfig.__PropertyOffset_GamepadMouseActor);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsUiNavigationPanelConfig.__PropertyOffset_GamepadMouseActor, value);
		}
	}

	// Token: 0x17001E63 RID: 7779
	// (get) Token: 0x060170C0 RID: 94400 RVA: 0x006629F9 File Offset: 0x00660BF9
	public bool IsGamepadControlMouse
	{
		get
		{
			return this.Independent && this.GamepadMouseActor != null && this.GamepadMouseActor.IsValid();
		}
	}

	// Token: 0x17001E64 RID: 7780
	// (get) Token: 0x060170C1 RID: 94401 RVA: 0x00662A1A File Offset: 0x00660C1A
	[Nullable(2)]
	public UUIItem GamepadMouseItem
	{
		[NullableContext(2)]
		get
		{
			if (this.GamepadMouseItemInternal == null)
			{
				AActor gamepadMouseActor = this.GamepadMouseActor;
				this.GamepadMouseItemInternal = (((gamepadMouseActor != null) ? gamepadMouseActor.GetComponentByClass(UUIItem.StaticClass()) : null) as UUIItem);
			}
			return this.GamepadMouseItemInternal;
		}
	}

	// Token: 0x060170C2 RID: 94402 RVA: 0x00662A51 File Offset: 0x00660C51
	public void MarkToFindDynamicGrid(NavigationDynamicScrollViewFindContext navigationDynamicScrollViewFindInfo)
	{
		UiNavigationViewHandle viewHandle = this.ViewHandle;
		if (viewHandle != null)
		{
			viewHandle.SetDynamicScrollViewNavigationContext(navigationDynamicScrollViewFindInfo);
		}
		UiNavigationViewHandle viewHandle2 = this.ViewHandle;
		if (viewHandle2 == null)
		{
			return;
		}
		viewHandle2.MarkRefreshNavigationDirty(0);
	}

	// Token: 0x060170C3 RID: 94403 RVA: 0x00662A76 File Offset: 0x00660C76
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsUiNavigationPanelConfig._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationPanelConfig.TsUiNavigationPanelConfig_C");
		}
		return TsUiNavigationPanelConfig._ClassPtr;
	}

	// Token: 0x060170C4 RID: 94404 RVA: 0x00662A9C File Offset: 0x00660C9C
	public TsUiNavigationPanelConfig() : this(BuiltinUtils.AllocNativeUObject(TsUiNavigationPanelConfig.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060170C5 RID: 94405 RVA: 0x00662AC4 File Offset: 0x00660CC4
	public TsUiNavigationPanelConfig(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiNavigationPanelConfig.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060170C6 RID: 94406 RVA: 0x00662AF7 File Offset: 0x00660CF7
	protected TsUiNavigationPanelConfig(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060170C7 RID: 94407 RVA: 0x00662B0B File Offset: 0x00660D0B
	protected virtual void __CPPCALL_AwakeBP_Implementation()
	{
		this.AwakeBP_Implementation();
	}

	// Token: 0x060170C8 RID: 94408 RVA: 0x00662B13 File Offset: 0x00660D13
	protected virtual void __CPPCALL_StartBP_Implementation()
	{
		this.StartBP_Implementation();
	}

	// Token: 0x060170C9 RID: 94409 RVA: 0x00662B1B File Offset: 0x00660D1B
	protected virtual void __CPPCALL_OnEnableBP_Implementation()
	{
		this.OnEnableBP_Implementation();
	}

	// Token: 0x060170CA RID: 94410 RVA: 0x00662B23 File Offset: 0x00660D23
	protected virtual void __CPPCALL_OnDisableBP_Implementation()
	{
		this.OnDisableBP_Implementation();
	}

	// Token: 0x060170CB RID: 94411 RVA: 0x00662B2B File Offset: 0x00660D2B
	protected virtual void __CPPCALL_OnPreDestroyBP_Implementation()
	{
		this.OnPreDestroyBP_Implementation();
	}

	// Token: 0x0400B176 RID: 45430
	[Nullable(2)]
	public NavigationGroup TsScrollBarGroup;

	// Token: 0x0400B177 RID: 45431
	[Nullable(2)]
	public UiNavigationViewHandle ViewHandle;

	// Token: 0x0400B178 RID: 45432
	public bool IsInActive;

	// Token: 0x0400B179 RID: 45433
	public bool LastFindResultWasWaitingScrollAnimation;

	// Token: 0x0400B17A RID: 45434
	[Nullable(2)]
	private SpecialPanelHandleBase PanelHandle;

	// Token: 0x0400B17B RID: 45435
	private List<Action> ViewHandleCacheFunctionList = new List<Action>();

	// Token: 0x0400B17C RID: 45436
	private int IncId;

	// Token: 0x0400B17D RID: 45437
	[Nullable(2)]
	private FindActionBase FindAction;

	// Token: 0x0400B17E RID: 45438
	[Nullable(2)]
	private Dictionary<int, bool> DynamicListenerIndexMap;

	// Token: 0x0400B17F RID: 45439
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public HashSet<HotKeyItem> HotKeyItemSet;

	// Token: 0x0400B180 RID: 45440
	[Nullable(2)]
	private Dictionary<HotKeyViewDefine.ELogicMode, bool> CacheHotKeyStateMap;

	// Token: 0x0400B181 RID: 45441
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Dictionary<EHotKeyCacheKey, Action<HotKeyItem>> CacheHotKeyComponentCallbackMap;

	// Token: 0x0400B182 RID: 45442
	[Nullable(2)]
	private UUIItem GamepadMouseItemInternal;

	// Token: 0x0400B183 RID: 45443
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationPanelConfig.TsUiNavigationPanelConfig_C";

	// Token: 0x0400B184 RID: 45444
	private static IntPtr _ClassPtr;

	// Token: 0x0400B185 RID: 45445
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B186 RID: 45446
	private static int __PropertyOffset_ViewName;

	// Token: 0x0400B187 RID: 45447
	private static int __PropertyOffset_Independent;

	// Token: 0x0400B188 RID: 45448
	private static int __PropertyOffset_IsChildPanel;

	// Token: 0x0400B189 RID: 45449
	private static int __PropertyOffset_NeedCacheListener;

	// Token: 0x0400B18A RID: 45450
	private static int __PropertyOffset_DefaultNavigationActor;

	// Token: 0x0400B18B RID: 45451
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<AActor> _DefaultNavigationActor;

	// Token: 0x0400B18C RID: 45452
	private static int __PropertyOffset_DynamicListenerConfigMap;

	// Token: 0x0400B18D RID: 45453
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private TMap<string, SNavigationDynamicListenerConfig> _DynamicListenerConfigMap;

	// Token: 0x0400B18E RID: 45454
	private static int __PropertyOffset_NormalGroup;

	// Token: 0x0400B18F RID: 45455
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SNavigationGroup> _NormalGroup;

	// Token: 0x0400B190 RID: 45456
	private static int __PropertyOffset_BookmarkGroup;

	// Token: 0x0400B191 RID: 45457
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SNavigationGroup> _BookmarkGroup;

	// Token: 0x0400B192 RID: 45458
	private static int __PropertyOffset_ScrollBarGroup;

	// Token: 0x0400B193 RID: 45459
	[Nullable(2)]
	private SNavigationGroup _ScrollBarGroup;

	// Token: 0x0400B194 RID: 45460
	private static int __PropertyOffset_AllowNavigateInKeyBoard;

	// Token: 0x0400B195 RID: 45461
	private static int __PropertyOffset_FirstFindFromSubPanelWhenFindNone;

	// Token: 0x0400B196 RID: 45462
	private static int __PropertyOffset_InteractiveTag;

	// Token: 0x0400B197 RID: 45463
	private static int __PropertyOffset_GamepadMouseActor;
}
