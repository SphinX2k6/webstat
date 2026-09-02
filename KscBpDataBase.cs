using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000F3E RID: 3902
[UClass("/Game/Aki/TypeScript/Game/KuroSimpleCombat/KSCDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/KuroSimpleCombat/KSCDataClass/KscBpDataBase.KscBpDataBase_C")]
public class KscBpDataBase : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
{
	// Token: 0x060061B1 RID: 25009 RVA: 0x00186C84 File Offset: 0x00184E84
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (KscBpDataBase._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/KuroSimpleCombat/KSCDataClass/KscBpDataBase.KscBpDataBase_C");
		}
		return KscBpDataBase._ClassPtr;
	}

	// Token: 0x060061B2 RID: 25010 RVA: 0x00186CA8 File Offset: 0x00184EA8
	public KscBpDataBase() : this(BuiltinUtils.AllocNativeUObject(KscBpDataBase.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060061B3 RID: 25011 RVA: 0x00186CD0 File Offset: 0x00184ED0
	[NullableContext(1)]
	public KscBpDataBase(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(KscBpDataBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060061B4 RID: 25012 RVA: 0x00186D03 File Offset: 0x00184F03
	protected KscBpDataBase(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x04002ED4 RID: 11988
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/KuroSimpleCombat/KSCDataClass/KscBpDataBase.KscBpDataBase_C";

	// Token: 0x04002ED5 RID: 11989
	private static IntPtr _ClassPtr;

	// Token: 0x04002ED6 RID: 11990
	private static IntPtr _ClassDefaultObjectPtr;
}
