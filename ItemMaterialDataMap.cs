using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003429 RID: 13353
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialDataMap.ItemMaterialDataMap_C")]
public class ItemMaterialDataMap : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x170025FC RID: 9724
	// (get) Token: 0x0601BE70 RID: 114288 RVA: 0x008503B8 File Offset: 0x0084E5B8
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<float, ItemMaterialControllerActorData> Map
	{
		get
		{
			base.FastCheckIsValid();
			TMap<float, ItemMaterialControllerActorData> result;
			if ((result = this._Map) == null)
			{
				result = (this._Map = new TMap<float, ItemMaterialControllerActorData>(base.NativePtr + (IntPtr)ItemMaterialDataMap.__PropertyOffset_Map, this));
			}
			return result;
		}
	}

	// Token: 0x0601BE71 RID: 114289 RVA: 0x008503F1 File Offset: 0x0084E5F1
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (ItemMaterialDataMap._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialDataMap.ItemMaterialDataMap_C");
		}
		return ItemMaterialDataMap._ClassPtr;
	}

	// Token: 0x0601BE72 RID: 114290 RVA: 0x00850418 File Offset: 0x0084E618
	public ItemMaterialDataMap() : this(BuiltinUtils.AllocNativeUObject(ItemMaterialDataMap.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BE73 RID: 114291 RVA: 0x00850440 File Offset: 0x0084E640
	public ItemMaterialDataMap(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ItemMaterialDataMap.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BE74 RID: 114292 RVA: 0x00850473 File Offset: 0x0084E673
	protected ItemMaterialDataMap(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x170025FD RID: 9725
	// (get) Token: 0x0601BE75 RID: 114293 RVA: 0x0085047C File Offset: 0x0084E67C
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialDataMap.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x170025FE RID: 9726
	// (get) Token: 0x0601BE76 RID: 114294 RVA: 0x0085048C File Offset: 0x0084E68C
	[Nullable(2)]
	public unsafe USceneComponent DefaultSceneRoot
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ItemMaterialDataMap.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x0400E1AD RID: 57773
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialDataMap.ItemMaterialDataMap_C";

	// Token: 0x0400E1AE RID: 57774
	private static IntPtr _ClassPtr;

	// Token: 0x0400E1AF RID: 57775
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E1B0 RID: 57776
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x0400E1B1 RID: 57777
	private static int __PropertyOffset_DefaultSceneRoot;

	// Token: 0x0400E1B2 RID: 57778
	private static int __PropertyOffset_Map;

	// Token: 0x0400E1B3 RID: 57779
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<float, ItemMaterialControllerActorData> _Map;
}
