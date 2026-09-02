using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004233 RID: 16947
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ML_BaseRole.ML_BaseRole_C")]
	[UnrealStructLayout(2224, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2224)]
	public abstract class ML_BaseRole_C : __TsBaseCharacter_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CD33 RID: 183603 RVA: 0x00AB0B90 File Offset: 0x00AAED90
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ML_BaseRole_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/ML_BaseRole.ML_BaseRole_C");
			}
			return ML_BaseRole_C._ClassPtr;
		}

		// Token: 0x0602CD34 RID: 183604 RVA: 0x00AB0BB4 File Offset: 0x00AAEDB4
		protected ML_BaseRole_C() : this(BuiltinUtils.AllocNativeUObject(ML_BaseRole_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CD35 RID: 183605 RVA: 0x00AB0BDC File Offset: 0x00AAEDDC
		protected ML_BaseRole_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401925B RID: 103003
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/ML_BaseRole.ML_BaseRole_C";

		// Token: 0x0401925C RID: 103004
		private static IntPtr _ClassPtr;

		// Token: 0x0401925D RID: 103005
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
