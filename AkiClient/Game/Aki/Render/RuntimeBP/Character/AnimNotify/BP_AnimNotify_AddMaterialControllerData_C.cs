using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.AnimNotify
{
	// Token: 0x02003D99 RID: 15769
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/AnimNotify/BP_AnimNotify_AddMaterialControllerData.BP_AnimNotify_AddMaterialControllerData_C")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 89)]
	public class BP_AnimNotify_AddMaterialControllerData_C : __AnimNotifyAddMaterialControllerData_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060268B1 RID: 157873 RVA: 0x009DB475 File Offset: 0x009D9675
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AnimNotify_AddMaterialControllerData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/AnimNotify/BP_AnimNotify_AddMaterialControllerData.BP_AnimNotify_AddMaterialControllerData_C");
			}
			return BP_AnimNotify_AddMaterialControllerData_C._ClassPtr;
		}

		// Token: 0x060268B2 RID: 157874 RVA: 0x009DB49C File Offset: 0x009D969C
		public BP_AnimNotify_AddMaterialControllerData_C() : this(BuiltinUtils.AllocNativeUObject(BP_AnimNotify_AddMaterialControllerData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060268B3 RID: 157875 RVA: 0x009DB4C4 File Offset: 0x009D96C4
		[NullableContext(1)]
		public BP_AnimNotify_AddMaterialControllerData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AnimNotify_AddMaterialControllerData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060268B4 RID: 157876 RVA: 0x009DB4F7 File Offset: 0x009D96F7
		protected BP_AnimNotify_AddMaterialControllerData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040140AD RID: 82093
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/AnimNotify/BP_AnimNotify_AddMaterialControllerData.BP_AnimNotify_AddMaterialControllerData_C";

		// Token: 0x040140AE RID: 82094
		private static IntPtr _ClassPtr;

		// Token: 0x040140AF RID: 82095
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
