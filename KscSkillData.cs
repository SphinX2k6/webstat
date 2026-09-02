using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000F40 RID: 3904
[UClass("/Game/Aki/TypeScript/Game/KuroSimpleCombat/KSCDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/KuroSimpleCombat/KSCDataClass/KscSkillData.KscSkillData_C")]
public class KscSkillData : KscBpDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000748 RID: 1864
	// (get) Token: 0x060061BF RID: 25023 RVA: 0x00186E08 File Offset: 0x00185008
	// (set) Token: 0x060061C0 RID: 25024 RVA: 0x00186E18 File Offset: 0x00185018
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SkillIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)KscSkillData.__PropertyOffset_SkillIndex);
		}
		set
		{
			*(base.NativePtr + (IntPtr)KscSkillData.__PropertyOffset_SkillIndex) = value;
		}
	}

	// Token: 0x060061C1 RID: 25025 RVA: 0x00186E29 File Offset: 0x00185029
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (KscSkillData._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/KuroSimpleCombat/KSCDataClass/KscSkillData.KscSkillData_C");
		}
		return KscSkillData._ClassPtr;
	}

	// Token: 0x060061C2 RID: 25026 RVA: 0x00186E50 File Offset: 0x00185050
	public KscSkillData() : this(BuiltinUtils.AllocNativeUObject(KscSkillData.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060061C3 RID: 25027 RVA: 0x00186E78 File Offset: 0x00185078
	[NullableContext(1)]
	public KscSkillData(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(KscSkillData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060061C4 RID: 25028 RVA: 0x00186EAB File Offset: 0x001850AB
	protected KscSkillData(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x04002EDD RID: 11997
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/KuroSimpleCombat/KSCDataClass/KscSkillData.KscSkillData_C";

	// Token: 0x04002EDE RID: 11998
	private static IntPtr _ClassPtr;

	// Token: 0x04002EDF RID: 11999
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04002EE0 RID: 12000
	private static int __PropertyOffset_SkillIndex;
}
