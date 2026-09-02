using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020037EF RID: 14319
public class __TsAnimNotifyReSkillByTagCount_InheritProxy : TsAnimNotifyReSkillByTagCount
{
	// Token: 0x0601D3E9 RID: 119785 RVA: 0x008C50F4 File Offset: 0x008C32F4
	[NullableContext(1)]
	public __TsAnimNotifyReSkillByTagCount_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyReSkillByTagCount.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D3EA RID: 119786 RVA: 0x008C5127 File Offset: 0x008C3327
	protected __TsAnimNotifyReSkillByTagCount_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D3EB RID: 119787 RVA: 0x008C5130 File Offset: 0x008C3330
	protected unsafe override void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), base.GetNotifyName_Implementation());
	}
}
