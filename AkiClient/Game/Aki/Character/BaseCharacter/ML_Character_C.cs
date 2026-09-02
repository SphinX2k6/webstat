using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004234 RID: 16948
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ML_Character.ML_Character_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public abstract class ML_Character_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CD36 RID: 183606 RVA: 0x00AB0BE5 File Offset: 0x00AAEDE5
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ML_Character_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/ML_Character.ML_Character_C");
			}
			return ML_Character_C._ClassPtr;
		}

		// Token: 0x0602CD37 RID: 183607 RVA: 0x00AB0C0C File Offset: 0x00AAEE0C
		protected ML_Character_C() : this(BuiltinUtils.AllocNativeUObject(ML_Character_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CD38 RID: 183608 RVA: 0x00AB0C34 File Offset: 0x00AAEE34
		protected ML_Character_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401925E RID: 103006
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/ML_Character.ML_Character_C";

		// Token: 0x0401925F RID: 103007
		private static IntPtr _ClassPtr;

		// Token: 0x04019260 RID: 103008
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
