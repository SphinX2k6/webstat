using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002CC3 RID: 11459
[UClass("/Game/Aki/TypeScript/Game/Module/UiNavigation/New/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationPlatformChangeListener.TsUiNavigationPlatformChangeListener_C")]
public class TsUiNavigationPlatformChangeListener : ULGUIBehaviour, IUnrealUObject, IUnrealObject
{
	// Token: 0x060170CE RID: 94414 RVA: 0x00662B60 File Offset: 0x00660D60
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

	// Token: 0x060170CF RID: 94415 RVA: 0x00662BD0 File Offset: 0x00660DD0
	protected virtual void AwakeBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		this.ChangeAlpha();
		UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.AddPlatformListener(this);
	}

	// Token: 0x060170D0 RID: 94416 RVA: 0x00662BF0 File Offset: 0x00660DF0
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

	// Token: 0x060170D1 RID: 94417 RVA: 0x00662C60 File Offset: 0x00660E60
	protected virtual void OnPreDestroyBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		ModelBase<UiNavigationModel>.Instance.RemovePlatformListener(this);
	}

	// Token: 0x060170D2 RID: 94418 RVA: 0x00662C78 File Offset: 0x00660E78
	public void ChangeAlpha()
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			this.IsChangeAlpha = true;
			UUIItem rootComponent = base.GetRootComponent();
			if (rootComponent == null)
			{
				return;
			}
			rootComponent.SetAlpha(0f);
			return;
		}
		else
		{
			if (!this.IsChangeAlpha)
			{
				return;
			}
			this.IsChangeAlpha = false;
			UUIItem rootComponent2 = base.GetRootComponent();
			if (rootComponent2 == null)
			{
				return;
			}
			rootComponent2.SetAlpha(1f);
			return;
		}
	}

	// Token: 0x060170D3 RID: 94419 RVA: 0x00662CD3 File Offset: 0x00660ED3
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsUiNavigationPlatformChangeListener._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationPlatformChangeListener.TsUiNavigationPlatformChangeListener_C");
		}
		return TsUiNavigationPlatformChangeListener._ClassPtr;
	}

	// Token: 0x060170D4 RID: 94420 RVA: 0x00662CF8 File Offset: 0x00660EF8
	public TsUiNavigationPlatformChangeListener() : this(BuiltinUtils.AllocNativeUObject(TsUiNavigationPlatformChangeListener.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060170D5 RID: 94421 RVA: 0x00662D20 File Offset: 0x00660F20
	[NullableContext(1)]
	public TsUiNavigationPlatformChangeListener(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiNavigationPlatformChangeListener.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060170D6 RID: 94422 RVA: 0x00662D53 File Offset: 0x00660F53
	protected TsUiNavigationPlatformChangeListener(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060170D7 RID: 94423 RVA: 0x00662D5C File Offset: 0x00660F5C
	protected virtual void __CPPCALL_AwakeBP_Implementation()
	{
		this.AwakeBP_Implementation();
	}

	// Token: 0x060170D8 RID: 94424 RVA: 0x00662D64 File Offset: 0x00660F64
	protected virtual void __CPPCALL_OnPreDestroyBP_Implementation()
	{
		this.OnPreDestroyBP_Implementation();
	}

	// Token: 0x0400B198 RID: 45464
	private bool IsChangeAlpha;

	// Token: 0x0400B199 RID: 45465
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationPlatformChangeListener.TsUiNavigationPlatformChangeListener_C";

	// Token: 0x0400B19A RID: 45466
	private static IntPtr _ClassPtr;

	// Token: 0x0400B19B RID: 45467
	private static IntPtr _ClassDefaultObjectPtr;
}
