using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Render;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200342A RID: 13354
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialDebugActor.ItemMaterialDebugActor_C")]
public class ItemMaterialDebugActor : AKuroEffectActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BE77 RID: 114295 RVA: 0x008504A0 File Offset: 0x0084E6A0
	public override void EditorTick(float deltaSecond)
	{
		Singleton<ItemMaterialManager>.Instance.Tick(deltaSecond * 1000f);
		this.SimpleMaterialControllerUpdate();
	}

	// Token: 0x170025FF RID: 9727
	// (get) Token: 0x0601BE78 RID: 114296 RVA: 0x008504B9 File Offset: 0x0084E6B9
	// (set) Token: 0x0601BE79 RID: 114297 RVA: 0x008504CD File Offset: 0x0084E6CD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor Actor
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + ItemMaterialDebugActor.__PropertyOffset_Actor);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ItemMaterialDebugActor.__PropertyOffset_Actor, value);
		}
	}

	// Token: 0x17002600 RID: 9728
	// (get) Token: 0x0601BE7A RID: 114298 RVA: 0x008504E2 File Offset: 0x0084E6E2
	// (set) Token: 0x0601BE7B RID: 114299 RVA: 0x008504F6 File Offset: 0x0084E6F6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName SimpleScalarNameTest
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialDebugActor.__PropertyOffset_SimpleScalarNameTest);
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialDebugActor.__PropertyOffset_SimpleScalarNameTest) = value;
		}
	}

	// Token: 0x17002601 RID: 9729
	// (get) Token: 0x0601BE7C RID: 114300 RVA: 0x0085050B File Offset: 0x0084E70B
	// (set) Token: 0x0601BE7D RID: 114301 RVA: 0x0085051B File Offset: 0x0084E71B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float SimpleScalarValueTest
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialDebugActor.__PropertyOffset_SimpleScalarValueTest);
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialDebugActor.__PropertyOffset_SimpleScalarValueTest) = value;
		}
	}

	// Token: 0x17002602 RID: 9730
	// (get) Token: 0x0601BE7E RID: 114302 RVA: 0x0085052C File Offset: 0x0084E72C
	// (set) Token: 0x0601BE7F RID: 114303 RVA: 0x00850540 File Offset: 0x0084E740
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName SimpleVectorNameTest
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialDebugActor.__PropertyOffset_SimpleVectorNameTest);
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialDebugActor.__PropertyOffset_SimpleVectorNameTest) = value;
		}
	}

	// Token: 0x17002603 RID: 9731
	// (get) Token: 0x0601BE80 RID: 114304 RVA: 0x00850555 File Offset: 0x0084E755
	// (set) Token: 0x0601BE81 RID: 114305 RVA: 0x00850569 File Offset: 0x0084E769
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FLinearColor SimpleVectorValueTest
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialDebugActor.__PropertyOffset_SimpleVectorValueTest);
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialDebugActor.__PropertyOffset_SimpleVectorValueTest) = value;
		}
	}

	// Token: 0x17002604 RID: 9732
	// (get) Token: 0x0601BE82 RID: 114306 RVA: 0x0085057E File Offset: 0x0084E77E
	// (set) Token: 0x0601BE83 RID: 114307 RVA: 0x00850592 File Offset: 0x0084E792
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ItemMaterialControllerGlobalData GlobalMaterialData
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<ItemMaterialControllerGlobalData>(base.NativePtr / (IntPtr)sizeof(void*) + ItemMaterialDebugActor.__PropertyOffset_GlobalMaterialData);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ItemMaterialDebugActor.__PropertyOffset_GlobalMaterialData, value);
		}
	}

	// Token: 0x17002605 RID: 9733
	// (get) Token: 0x0601BE84 RID: 114308 RVA: 0x008505A7 File Offset: 0x0084E7A7
	// (set) Token: 0x0601BE85 RID: 114309 RVA: 0x008505BB File Offset: 0x0084E7BB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ItemMaterialControllerActorData MaterialData
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<ItemMaterialControllerActorData>(base.NativePtr / (IntPtr)sizeof(void*) + ItemMaterialDebugActor.__PropertyOffset_MaterialData);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ItemMaterialDebugActor.__PropertyOffset_MaterialData, value);
		}
	}

	// Token: 0x17002606 RID: 9734
	// (get) Token: 0x0601BE86 RID: 114310 RVA: 0x008505D0 File Offset: 0x0084E7D0
	// (set) Token: 0x0601BE87 RID: 114311 RVA: 0x008505E0 File Offset: 0x0084E7E0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ActorMaterialControllerNum
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialDebugActor.__PropertyOffset_ActorMaterialControllerNum);
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialDebugActor.__PropertyOffset_ActorMaterialControllerNum) = value;
		}
	}

	// Token: 0x0601BE88 RID: 114312 RVA: 0x008505F4 File Offset: 0x0084E7F4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void DisableAllActorData()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("DisableAllActorData"), out num);
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

	// Token: 0x0601BE89 RID: 114313 RVA: 0x00850664 File Offset: 0x0084E864
	protected void DisableAllActorData_Implementation()
	{
		Singleton<ItemMaterialManager>.Instance.DisableAllActorData();
	}

	// Token: 0x0601BE8A RID: 114314 RVA: 0x00850674 File Offset: 0x0084E874
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void DisableActorData()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("DisableActorData"), out num);
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

	// Token: 0x0601BE8B RID: 114315 RVA: 0x008506E4 File Offset: 0x0084E8E4
	protected void DisableActorData_Implementation()
	{
		Singleton<ItemMaterialManager>.Instance.DisableActorData((int)this.ActorMaterialControllerNum);
	}

	// Token: 0x0601BE8C RID: 114316 RVA: 0x008506F8 File Offset: 0x0084E8F8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void EnableActorData()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EnableActorData"), out num);
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

	// Token: 0x0601BE8D RID: 114317 RVA: 0x00850768 File Offset: 0x0084E968
	protected void EnableActorData_Implementation()
	{
		if (this.Controllers == null)
		{
			this.Controllers = new List<ItemMaterialActorController>();
		}
		if (this.Actor != null && this.MaterialData != null)
		{
			Singleton<ItemMaterialManager>.Instance.AddMaterialData(this.Actor, this.MaterialData);
		}
	}

	// Token: 0x0601BE8E RID: 114318 RVA: 0x008507A4 File Offset: 0x0084E9A4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SimpleMaterialControllerDisable()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SimpleMaterialControllerDisable"), out num);
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

	// Token: 0x0601BE8F RID: 114319 RVA: 0x00850814 File Offset: 0x0084EA14
	protected void SimpleMaterialControllerDisable_Implementation()
	{
		Singleton<ItemMaterialManager>.Instance.DisableSimpleMaterialController((int)this.ActorMaterialControllerNum);
	}

	// Token: 0x0601BE90 RID: 114320 RVA: 0x00850828 File Offset: 0x0084EA28
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SimpleMaterialControllerUpdate()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SimpleMaterialControllerUpdate"), out num);
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

	// Token: 0x0601BE91 RID: 114321 RVA: 0x00850898 File Offset: 0x0084EA98
	protected void SimpleMaterialControllerUpdate_Implementation()
	{
		if (this.Actor != null && this.SimpleScalarNameTest != null && this.SimpleScalarValueTest != 0f && this.SimpleVectorNameTest != null)
		{
			FLinearColor simpleVectorValueTest = this.SimpleVectorValueTest;
			Dictionary<FName, float> dictionary = new Dictionary<FName, float>();
			Dictionary<FName, FLinearColor> dictionary2 = new Dictionary<FName, FLinearColor>();
			dictionary[this.SimpleScalarNameTest] = this.SimpleScalarValueTest;
			dictionary2[this.SimpleVectorNameTest] = this.SimpleVectorValueTest;
			Singleton<ItemMaterialManager>.Instance.AddSimpleMaterialController(this.Actor, dictionary, dictionary2);
		}
	}

	// Token: 0x0601BE92 RID: 114322 RVA: 0x0085092A File Offset: 0x0084EB2A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (ItemMaterialDebugActor._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialDebugActor.ItemMaterialDebugActor_C");
		}
		return ItemMaterialDebugActor._ClassPtr;
	}

	// Token: 0x0601BE93 RID: 114323 RVA: 0x00850950 File Offset: 0x0084EB50
	public ItemMaterialDebugActor() : this(BuiltinUtils.AllocNativeUObject(ItemMaterialDebugActor.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BE94 RID: 114324 RVA: 0x00850978 File Offset: 0x0084EB78
	[NullableContext(1)]
	public ItemMaterialDebugActor(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ItemMaterialDebugActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BE95 RID: 114325 RVA: 0x008509AB File Offset: 0x0084EBAB
	protected ItemMaterialDebugActor(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BE96 RID: 114326 RVA: 0x008509BF File Offset: 0x0084EBBF
	protected virtual void __CPPCALL_DisableAllActorData_Implementation()
	{
		this.DisableAllActorData_Implementation();
	}

	// Token: 0x0601BE97 RID: 114327 RVA: 0x008509C7 File Offset: 0x0084EBC7
	protected virtual void __CPPCALL_DisableActorData_Implementation()
	{
		this.DisableActorData_Implementation();
	}

	// Token: 0x0601BE98 RID: 114328 RVA: 0x008509CF File Offset: 0x0084EBCF
	protected virtual void __CPPCALL_EnableActorData_Implementation()
	{
		this.EnableActorData_Implementation();
	}

	// Token: 0x0601BE99 RID: 114329 RVA: 0x008509D7 File Offset: 0x0084EBD7
	protected virtual void __CPPCALL_SimpleMaterialControllerDisable_Implementation()
	{
		this.SimpleMaterialControllerDisable_Implementation();
	}

	// Token: 0x0601BE9A RID: 114330 RVA: 0x008509DF File Offset: 0x0084EBDF
	protected virtual void __CPPCALL_SimpleMaterialControllerUpdate_Implementation()
	{
		this.SimpleMaterialControllerUpdate_Implementation();
	}

	// Token: 0x0400E1B4 RID: 57780
	public int GlobalNum;

	// Token: 0x0400E1B5 RID: 57781
	public ItemMaterialGlobalController GlobalItemMaterialController;

	// Token: 0x0400E1B6 RID: 57782
	[Nullable(1)]
	public List<ItemMaterialActorController> Controllers = new List<ItemMaterialActorController>();

	// Token: 0x0400E1B7 RID: 57783
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialDebugActor.ItemMaterialDebugActor_C";

	// Token: 0x0400E1B8 RID: 57784
	private static IntPtr _ClassPtr;

	// Token: 0x0400E1B9 RID: 57785
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E1BA RID: 57786
	private static int __PropertyOffset_Actor;

	// Token: 0x0400E1BB RID: 57787
	private static int __PropertyOffset_SimpleScalarNameTest;

	// Token: 0x0400E1BC RID: 57788
	private static int __PropertyOffset_SimpleScalarValueTest;

	// Token: 0x0400E1BD RID: 57789
	private static int __PropertyOffset_SimpleVectorNameTest;

	// Token: 0x0400E1BE RID: 57790
	private static int __PropertyOffset_SimpleVectorValueTest;

	// Token: 0x0400E1BF RID: 57791
	private static int __PropertyOffset_GlobalMaterialData;

	// Token: 0x0400E1C0 RID: 57792
	private static int __PropertyOffset_MaterialData;

	// Token: 0x0400E1C1 RID: 57793
	private static int __PropertyOffset_ActorMaterialControllerNum;
}
