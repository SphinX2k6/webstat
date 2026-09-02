using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002CC4 RID: 11460
[UClass("/Game/Aki/TypeScript/Game/Module/UiNavigation/New/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationTextChangeListener.TsUiNavigationTextChangeListener_C")]
public class TsUiNavigationTextChangeListener : UUINavigationTextChangeListener, IUnrealUObject, IUnrealObject
{
	// Token: 0x060170D9 RID: 94425 RVA: 0x00662D6C File Offset: 0x00660F6C
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

	// Token: 0x060170DA RID: 94426 RVA: 0x00662DDC File Offset: 0x00660FDC
	protected virtual void AwakeBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		this.Listener = (base.GetOwner().GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) as TsUiNavigationBehaviorListener);
	}

	// Token: 0x060170DB RID: 94427 RVA: 0x00662E08 File Offset: 0x00661008
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

	// Token: 0x060170DC RID: 94428 RVA: 0x00662E78 File Offset: 0x00661078
	protected virtual void StartBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		this.NotifyDefaultText();
	}

	// Token: 0x060170DD RID: 94429 RVA: 0x00662E88 File Offset: 0x00661088
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnNotifyTextChangeBP(string NotifyText)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnNotifyTextChangeBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UUINavigationTextChangeListener.__OnNotifyTextChangeBP_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UUINavigationTextChangeListener.__OnNotifyTextChangeBP_FunctionParams*)ptr + 15L / (long)sizeof(UUINavigationTextChangeListener.__OnNotifyTextChangeBP_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->NotifyText), NotifyText);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060170DE RID: 94430 RVA: 0x00662F04 File Offset: 0x00661104
	[NullableContext(1)]
	protected virtual void OnNotifyTextChangeBP_Implementation(string NotifyText)
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		if (this.Listener == null)
		{
			return;
		}
		this.Listener.NotifyTextChangeByComponent(NotifyText);
	}

	// Token: 0x060170DF RID: 94431 RVA: 0x00662F24 File Offset: 0x00661124
	private void NotifyDefaultText()
	{
		if (this.Listener == null)
		{
			return;
		}
		if (base.TextActor == null)
		{
			return;
		}
		this.Text = (base.TextActor.GetComponentByClass(UUIText.StaticClass()) as UUIText);
		if (this.Text == null)
		{
			return;
		}
		this.Listener.NotifyTextChangeByComponent(this.Text.GetText());
	}

	// Token: 0x060170E0 RID: 94432 RVA: 0x00662F82 File Offset: 0x00661182
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsUiNavigationTextChangeListener._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationTextChangeListener.TsUiNavigationTextChangeListener_C");
		}
		return TsUiNavigationTextChangeListener._ClassPtr;
	}

	// Token: 0x060170E1 RID: 94433 RVA: 0x00662FA8 File Offset: 0x006611A8
	public TsUiNavigationTextChangeListener() : this(BuiltinUtils.AllocNativeUObject(TsUiNavigationTextChangeListener.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060170E2 RID: 94434 RVA: 0x00662FD0 File Offset: 0x006611D0
	[NullableContext(1)]
	public TsUiNavigationTextChangeListener(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiNavigationTextChangeListener.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060170E3 RID: 94435 RVA: 0x00663003 File Offset: 0x00661203
	protected TsUiNavigationTextChangeListener(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060170E4 RID: 94436 RVA: 0x0066300C File Offset: 0x0066120C
	protected virtual void __CPPCALL_AwakeBP_Implementation()
	{
		this.AwakeBP_Implementation();
	}

	// Token: 0x060170E5 RID: 94437 RVA: 0x00663014 File Offset: 0x00661214
	protected virtual void __CPPCALL_StartBP_Implementation()
	{
		this.StartBP_Implementation();
	}

	// Token: 0x060170E6 RID: 94438 RVA: 0x0066301C File Offset: 0x0066121C
	protected unsafe virtual void __CPPCALL_OnNotifyTextChangeBP_Implementation(UUINavigationTextChangeListener.__OnNotifyTextChangeBP_FunctionParams* __Params)
	{
		string notifyText = FString.ToString((void*)(&__Params->NotifyText));
		this.OnNotifyTextChangeBP_Implementation(notifyText);
	}

	// Token: 0x0400B19C RID: 45468
	[Nullable(2)]
	private TsUiNavigationBehaviorListener Listener;

	// Token: 0x0400B19D RID: 45469
	[Nullable(2)]
	public UUIText Text;

	// Token: 0x0400B19E RID: 45470
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationTextChangeListener.TsUiNavigationTextChangeListener_C";

	// Token: 0x0400B19F RID: 45471
	private static IntPtr _ClassPtr;

	// Token: 0x0400B1A0 RID: 45472
	private static IntPtr _ClassDefaultObjectPtr;
}
