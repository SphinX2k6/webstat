using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002CC9 RID: 11465
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Module/UiNavigation/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/UiNavigation/TsUiHotKeyLinkListener.TsUiHotKeyLinkListener_C")]
public class TsUiHotKeyLinkListener : ULGUIBehaviour, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001E69 RID: 7785
	// (get) Token: 0x0601717B RID: 94587 RVA: 0x00666310 File Offset: 0x00664510
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<AActor> ActorList
	{
		get
		{
			base.FastCheckIsValid();
			TArray<AActor> result;
			if ((result = this._ActorList) == null)
			{
				result = (this._ActorList = new TArray<AActor>(base.NativePtr + (IntPtr)TsUiHotKeyLinkListener.__PropertyOffset_ActorList, this));
			}
			return result;
		}
	}

	// Token: 0x0601717C RID: 94588 RVA: 0x00666349 File Offset: 0x00664549
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsUiHotKeyLinkListener._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/UiNavigation/TsUiHotKeyLinkListener.TsUiHotKeyLinkListener_C");
		}
		return TsUiHotKeyLinkListener._ClassPtr;
	}

	// Token: 0x0601717D RID: 94589 RVA: 0x00666370 File Offset: 0x00664570
	public TsUiHotKeyLinkListener() : this(BuiltinUtils.AllocNativeUObject(TsUiHotKeyLinkListener.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601717E RID: 94590 RVA: 0x00666398 File Offset: 0x00664598
	public TsUiHotKeyLinkListener(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiHotKeyLinkListener.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601717F RID: 94591 RVA: 0x006663CB File Offset: 0x006645CB
	protected TsUiHotKeyLinkListener(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B1B6 RID: 45494
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/UiNavigation/TsUiHotKeyLinkListener.TsUiHotKeyLinkListener_C";

	// Token: 0x0400B1B7 RID: 45495
	private static IntPtr _ClassPtr;

	// Token: 0x0400B1B8 RID: 45496
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B1B9 RID: 45497
	private static int __PropertyOffset_ActorList;

	// Token: 0x0400B1BA RID: 45498
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<AActor> _ActorList;
}
