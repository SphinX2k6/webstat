using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DF3 RID: 11763
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataShowMesh.LogicDataShowMesh_C")]
public class LogicDataShowMesh : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FFF RID: 8191
	// (get) Token: 0x06017BF2 RID: 97266 RVA: 0x0069FA7C File Offset: 0x0069DC7C
	// (set) Token: 0x06017BF3 RID: 97267 RVA: 0x0069FAB5 File Offset: 0x0069DCB5
	[UProperty(EPropertyFlags.CPF_None)]
	public FSoftObjectPath MaterialEffect
	{
		get
		{
			base.FastCheckIsValid();
			FSoftObjectPath result;
			if ((result = this._MaterialEffect) == null)
			{
				result = (this._MaterialEffect = new FSoftObjectPath(base.NativePtr + (IntPtr)LogicDataShowMesh.__PropertyOffset_MaterialEffect, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)LogicDataShowMesh.__PropertyOffset_MaterialEffect, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x06017BF4 RID: 97268 RVA: 0x0069FADD File Offset: 0x0069DCDD
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataShowMesh._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataShowMesh.LogicDataShowMesh_C");
		}
		return LogicDataShowMesh._ClassPtr;
	}

	// Token: 0x06017BF5 RID: 97269 RVA: 0x0069FB04 File Offset: 0x0069DD04
	public LogicDataShowMesh() : this(BuiltinUtils.AllocNativeUObject(LogicDataShowMesh.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017BF6 RID: 97270 RVA: 0x0069FB2C File Offset: 0x0069DD2C
	public LogicDataShowMesh(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataShowMesh.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017BF7 RID: 97271 RVA: 0x0069FB5F File Offset: 0x0069DD5F
	protected LogicDataShowMesh(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B75C RID: 46940
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataShowMesh.LogicDataShowMesh_C";

	// Token: 0x0400B75D RID: 46941
	private static IntPtr _ClassPtr;

	// Token: 0x0400B75E RID: 46942
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B75F RID: 46943
	private static int __PropertyOffset_MaterialEffect;

	// Token: 0x0400B760 RID: 46944
	[Nullable(2)]
	private FSoftObjectPath _MaterialEffect;
}
