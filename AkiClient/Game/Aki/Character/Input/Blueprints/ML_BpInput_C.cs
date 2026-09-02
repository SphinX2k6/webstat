using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Input.Blueprints
{
	// Token: 0x020041B4 RID: 16820
	[UnrealObjectPath("/Game/Aki/Character/Input/Blueprints/ML_BpInput.ML_BpInput_C")]
	[UnrealStructLayout(592, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 591)]
	public abstract class ML_BpInput_C : BP_InputComponent_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CAEA RID: 183018 RVA: 0x00AAB440 File Offset: 0x00AA9640
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ML_BpInput_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Input/Blueprints/ML_BpInput.ML_BpInput_C");
			}
			return ML_BpInput_C._ClassPtr;
		}

		// Token: 0x0602CAEB RID: 183019 RVA: 0x00AAB464 File Offset: 0x00AA9664
		protected ML_BpInput_C() : this(BuiltinUtils.AllocNativeUObject(ML_BpInput_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CAEC RID: 183020 RVA: 0x00AAB48C File Offset: 0x00AA968C
		protected ML_BpInput_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018E37 RID: 101943
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Input/Blueprints/ML_BpInput.ML_BpInput_C";

		// Token: 0x04018E38 RID: 101944
		private static IntPtr _ClassPtr;

		// Token: 0x04018E39 RID: 101945
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
