using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200390F RID: 14607
public class __AnimNotifyAddMotionVertexOffset_InheritProxy : AnimNotifyAddMotionVertexOffset
{
	// Token: 0x0601D7FC RID: 120828 RVA: 0x008CF7E0 File Offset: 0x008CD9E0
	[NullableContext(1)]
	public __AnimNotifyAddMotionVertexOffset_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyAddMotionVertexOffset.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D7FD RID: 120829 RVA: 0x008CF813 File Offset: 0x008CDA13
	protected __AnimNotifyAddMotionVertexOffset_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D7FE RID: 120830 RVA: 0x008CF81C File Offset: 0x008CDA1C
	protected unsafe override void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), base.GetNotifyName_Implementation());
	}
}
