using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.TypeScript.Game.Character
{
	// Token: 0x020039C5 RID: 14789
	[UnrealObjectPath("/Game/Aki/TypeScript/Game/Character/BaseRoleDataTemplate.BaseRoleDataTemplate_C")]
	[UnrealStructLayout(2224, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2224)]
	public class BaseRoleDataTemplate_C : __TsBaseCharacter_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DE6D RID: 122477 RVA: 0x008E6737 File Offset: 0x008E4937
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BaseRoleDataTemplate_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Character/BaseRoleDataTemplate.BaseRoleDataTemplate_C");
			}
			return BaseRoleDataTemplate_C._ClassPtr;
		}

		// Token: 0x0601DE6E RID: 122478 RVA: 0x008E675C File Offset: 0x008E495C
		public BaseRoleDataTemplate_C() : this(BuiltinUtils.AllocNativeUObject(BaseRoleDataTemplate_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DE6F RID: 122479 RVA: 0x008E6784 File Offset: 0x008E4984
		[NullableContext(1)]
		public BaseRoleDataTemplate_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BaseRoleDataTemplate_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0601DE70 RID: 122480 RVA: 0x008E67B7 File Offset: 0x008E49B7
		protected BaseRoleDataTemplate_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EA77 RID: 60023
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Character/BaseRoleDataTemplate.BaseRoleDataTemplate_C";

		// Token: 0x0400EA78 RID: 60024
		private static IntPtr _ClassPtr;

		// Token: 0x0400EA79 RID: 60025
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
