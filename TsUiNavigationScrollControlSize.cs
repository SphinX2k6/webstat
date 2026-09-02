using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002CCA RID: 11466
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Module/UiNavigation/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/UiNavigation/TsUiNavigationScrollControlSize.TsUiNavigationScrollControlSize_C")]
public class TsUiNavigationScrollControlSize : ULGUIBehaviour, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001E6A RID: 7786
	// (get) Token: 0x06017180 RID: 94592 RVA: 0x006663D4 File Offset: 0x006645D4
	// (set) Token: 0x06017181 RID: 94593 RVA: 0x006663E8 File Offset: 0x006645E8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor ScrollViewActor
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + TsUiNavigationScrollControlSize.__PropertyOffset_ScrollViewActor);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsUiNavigationScrollControlSize.__PropertyOffset_ScrollViewActor, value);
		}
	}

	// Token: 0x06017182 RID: 94594 RVA: 0x00666400 File Offset: 0x00664600
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

	// Token: 0x06017183 RID: 94595 RVA: 0x00666470 File Offset: 0x00664670
	protected virtual void AwakeBP_Implementation()
	{
		AActor owner = base.GetOwner();
		this.SizeController = (((owner != null) ? owner.GetComponentByClass(UUISizeControlByOther.StaticClass()) : null) as UUISizeControlByOther);
		if (this.SizeController == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.UiNavigation, ELogAuthor.XXJ, "该组件需要放在有SizeControlByOther的Actor上", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		AActor scrollViewActor = this.ScrollViewActor;
		this.ScrollView = (((scrollViewActor != null) ? scrollViewActor.GetComponentByClass(UUIScrollViewWithScrollbarComponent.StaticClass()) : null) as UUIScrollViewWithScrollbarComponent);
		UUIScrollViewWithScrollbarComponent scrollView = this.ScrollView;
		UUIItem contentItem;
		if (scrollView == null)
		{
			contentItem = null;
		}
		else
		{
			AUIBaseActor content = scrollView.GetContent();
			contentItem = ((content != null) ? content.GetUIItem() : null);
		}
		this.ContentItem = contentItem;
		if (this.ScrollView == null || this.ContentItem == null)
		{
			return;
		}
		this.SizeController.SetTargetActor(this.ScrollViewActor as AUIBaseActor);
		this.UseScroll = true;
	}

	// Token: 0x06017184 RID: 94596 RVA: 0x00666548 File Offset: 0x00664748
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void LateUpdateBP(float deltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("LateUpdateBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		ULGUIBehaviour.__LateUpdateBP_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((ULGUIBehaviour.__LateUpdateBP_FunctionParams*)ptr + 15L / (long)sizeof(ULGUIBehaviour.__LateUpdateBP_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaTime = deltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06017185 RID: 94597 RVA: 0x006665C0 File Offset: 0x006647C0
	protected virtual void LateUpdateBP_Implementation(float deltaTime)
	{
		if (this.ScrollView == null || this.SizeController == null)
		{
			return;
		}
		if (this.ScrollValue == 0f)
		{
			this.ScrollValue = (this.ScrollView.Vertical ? this.ScrollView.RootUIComp.Get().GetHeight() : this.ScrollView.RootUIComp.Get().GetWidth());
		}
		float num;
		if (!this.ScrollView.Vertical)
		{
			UUIItem contentItem = this.ContentItem;
			num = ((contentItem != null) ? contentItem.GetWidth() : 0f);
		}
		else
		{
			UUIItem contentItem2 = this.ContentItem;
			num = ((contentItem2 != null) ? contentItem2.GetHeight() : 0f);
		}
		float num2 = num;
		if (num2 <= this.ScrollValue && this.UseScroll)
		{
			this.UseScroll = false;
			this.SizeController.SetTargetActor(this.ScrollView.Content);
			return;
		}
		if (num2 > this.ScrollValue && !this.UseScroll)
		{
			this.UseScroll = true;
			this.SizeController.SetTargetActor(this.ScrollViewActor as AUIBaseActor);
		}
	}

	// Token: 0x06017186 RID: 94598 RVA: 0x006666D0 File Offset: 0x006648D0
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

	// Token: 0x06017187 RID: 94599 RVA: 0x00666740 File Offset: 0x00664940
	protected virtual void OnDisableBP_Implementation()
	{
		this.ScrollValue = 0f;
	}

	// Token: 0x06017188 RID: 94600 RVA: 0x0066674D File Offset: 0x0066494D
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsUiNavigationScrollControlSize._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/UiNavigation/TsUiNavigationScrollControlSize.TsUiNavigationScrollControlSize_C");
		}
		return TsUiNavigationScrollControlSize._ClassPtr;
	}

	// Token: 0x06017189 RID: 94601 RVA: 0x00666774 File Offset: 0x00664974
	public TsUiNavigationScrollControlSize() : this(BuiltinUtils.AllocNativeUObject(TsUiNavigationScrollControlSize.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601718A RID: 94602 RVA: 0x0066679C File Offset: 0x0066499C
	[NullableContext(1)]
	public TsUiNavigationScrollControlSize(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiNavigationScrollControlSize.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601718B RID: 94603 RVA: 0x006667CF File Offset: 0x006649CF
	protected TsUiNavigationScrollControlSize(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601718C RID: 94604 RVA: 0x006667D8 File Offset: 0x006649D8
	protected virtual void __CPPCALL_AwakeBP_Implementation()
	{
		this.AwakeBP_Implementation();
	}

	// Token: 0x0601718D RID: 94605 RVA: 0x006667E0 File Offset: 0x006649E0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_LateUpdateBP_Implementation(ULGUIBehaviour.__LateUpdateBP_FunctionParams* __Params)
	{
		this.LateUpdateBP_Implementation(__Params->DeltaTime);
	}

	// Token: 0x0601718E RID: 94606 RVA: 0x006667EE File Offset: 0x006649EE
	protected virtual void __CPPCALL_OnDisableBP_Implementation()
	{
		this.OnDisableBP_Implementation();
	}

	// Token: 0x0400B1BB RID: 45499
	private UUIScrollViewWithScrollbarComponent ScrollView;

	// Token: 0x0400B1BC RID: 45500
	private UUISizeControlByOther SizeController;

	// Token: 0x0400B1BD RID: 45501
	private float ScrollValue;

	// Token: 0x0400B1BE RID: 45502
	private UUIItem ContentItem;

	// Token: 0x0400B1BF RID: 45503
	private bool UseScroll;

	// Token: 0x0400B1C0 RID: 45504
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/UiNavigation/TsUiNavigationScrollControlSize.TsUiNavigationScrollControlSize_C";

	// Token: 0x0400B1C1 RID: 45505
	private static IntPtr _ClassPtr;

	// Token: 0x0400B1C2 RID: 45506
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B1C3 RID: 45507
	private static int __PropertyOffset_ScrollViewActor;
}
