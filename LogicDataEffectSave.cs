using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DEB RID: 11755
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataEffectSave.LogicDataEffectSave_C")]
public class LogicDataEffectSave : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FC4 RID: 8132
	// (get) Token: 0x06017B5C RID: 97116 RVA: 0x0069E9CC File Offset: 0x0069CBCC
	// (set) Token: 0x06017B5D RID: 97117 RVA: 0x0069EA05 File Offset: 0x0069CC05
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> Effect
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._Effect) == null)
			{
				result = (this._Effect = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)LogicDataEffectSave.__PropertyOffset_Effect, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)LogicDataEffectSave.__PropertyOffset_Effect, 1);
		}
	}

	// Token: 0x06017B5E RID: 97118 RVA: 0x0069EA2A File Offset: 0x0069CC2A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataEffectSave._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataEffectSave.LogicDataEffectSave_C");
		}
		return LogicDataEffectSave._ClassPtr;
	}

	// Token: 0x06017B5F RID: 97119 RVA: 0x0069EA50 File Offset: 0x0069CC50
	public LogicDataEffectSave() : this(BuiltinUtils.AllocNativeUObject(LogicDataEffectSave.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017B60 RID: 97120 RVA: 0x0069EA78 File Offset: 0x0069CC78
	public LogicDataEffectSave(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataEffectSave.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017B61 RID: 97121 RVA: 0x0069EAAB File Offset: 0x0069CCAB
	protected LogicDataEffectSave(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B6F3 RID: 46835
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataEffectSave.LogicDataEffectSave_C";

	// Token: 0x0400B6F4 RID: 46836
	private static IntPtr _ClassPtr;

	// Token: 0x0400B6F5 RID: 46837
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B6F6 RID: 46838
	private static int __PropertyOffset_Effect;

	// Token: 0x0400B6F7 RID: 46839
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _Effect;
}
