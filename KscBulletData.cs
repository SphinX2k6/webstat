using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000F3F RID: 3903
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/KuroSimpleCombat/KSCDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/KuroSimpleCombat/KSCDataClass/KscBulletData.KscBulletData_C")]
public class KscBulletData : KscBpDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000745 RID: 1861
	// (get) Token: 0x060061B5 RID: 25013 RVA: 0x00186D0C File Offset: 0x00184F0C
	// (set) Token: 0x060061B6 RID: 25014 RVA: 0x00186D1C File Offset: 0x00184F1C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int BulletConfigId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)KscBulletData.__PropertyOffset_BulletConfigId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)KscBulletData.__PropertyOffset_BulletConfigId) = value;
		}
	}

	// Token: 0x17000746 RID: 1862
	// (get) Token: 0x060061B7 RID: 25015 RVA: 0x00186D2D File Offset: 0x00184F2D
	// (set) Token: 0x060061B8 RID: 25016 RVA: 0x00186D41 File Offset: 0x00184F41
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string LaunchMeshComponentName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)KscBulletData.__PropertyOffset_LaunchMeshComponentName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)KscBulletData.__PropertyOffset_LaunchMeshComponentName)), value);
		}
	}

	// Token: 0x17000747 RID: 1863
	// (get) Token: 0x060061B9 RID: 25017 RVA: 0x00186D56 File Offset: 0x00184F56
	// (set) Token: 0x060061BA RID: 25018 RVA: 0x00186D6A File Offset: 0x00184F6A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string LaunchBoneOrSocketName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)KscBulletData.__PropertyOffset_LaunchBoneOrSocketName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)KscBulletData.__PropertyOffset_LaunchBoneOrSocketName)), value);
		}
	}

	// Token: 0x060061BB RID: 25019 RVA: 0x00186D7F File Offset: 0x00184F7F
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (KscBulletData._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/KuroSimpleCombat/KSCDataClass/KscBulletData.KscBulletData_C");
		}
		return KscBulletData._ClassPtr;
	}

	// Token: 0x060061BC RID: 25020 RVA: 0x00186DA4 File Offset: 0x00184FA4
	public KscBulletData() : this(BuiltinUtils.AllocNativeUObject(KscBulletData.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060061BD RID: 25021 RVA: 0x00186DCC File Offset: 0x00184FCC
	public KscBulletData(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(KscBulletData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060061BE RID: 25022 RVA: 0x00186DFF File Offset: 0x00184FFF
	protected KscBulletData(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x04002ED7 RID: 11991
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/KuroSimpleCombat/KSCDataClass/KscBulletData.KscBulletData_C";

	// Token: 0x04002ED8 RID: 11992
	private static IntPtr _ClassPtr;

	// Token: 0x04002ED9 RID: 11993
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04002EDA RID: 11994
	private static int __PropertyOffset_BulletConfigId;

	// Token: 0x04002EDB RID: 11995
	private static int __PropertyOffset_LaunchMeshComponentName;

	// Token: 0x04002EDC RID: 11996
	private static int __PropertyOffset_LaunchBoneOrSocketName;
}
