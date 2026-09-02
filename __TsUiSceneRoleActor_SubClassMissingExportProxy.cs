using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003876 RID: 14454
public class __TsUiSceneRoleActor_SubClassMissingExportProxy : __TsUiSceneRoleActor_InheritProxy
{
	// Token: 0x0601D5D0 RID: 120272 RVA: 0x008C9F4C File Offset: 0x008C814C
	[NullableContext(1)]
	protected __TsUiSceneRoleActor_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiSceneRoleActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5D1 RID: 120273 RVA: 0x008C9F7F File Offset: 0x008C817F
	protected __TsUiSceneRoleActor_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D5D2 RID: 120274 RVA: 0x008C9F88 File Offset: 0x008C8188
	public unsafe override bool IsShowUiWepaonEffect()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("IsShowUiWepaonEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsUiSceneRoleActor.__IsShowUiWepaonEffect_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsUiSceneRoleActor.__IsShowUiWepaonEffect_FunctionParams*)ptr + 15L / (long)sizeof(TsUiSceneRoleActor.__IsShowUiWepaonEffect_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}
}
