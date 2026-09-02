using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Input.Blueprints
{
	// Token: 0x020041B5 RID: 16821
	[UnrealObjectPath("/Game/Aki/Character/Input/Blueprints/ML_InputComponent.ML_InputComponent_C")]
	[UnrealStructLayout(424, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 424)]
	public abstract class ML_InputComponent_C : BP_InputBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CAED RID: 183021 RVA: 0x00AAB495 File Offset: 0x00AA9695
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ML_InputComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Input/Blueprints/ML_InputComponent.ML_InputComponent_C");
			}
			return ML_InputComponent_C._ClassPtr;
		}

		// Token: 0x0602CAEE RID: 183022 RVA: 0x00AAB4BC File Offset: 0x00AA96BC
		protected ML_InputComponent_C() : this(BuiltinUtils.AllocNativeUObject(ML_InputComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CAEF RID: 183023 RVA: 0x00AAB4E4 File Offset: 0x00AA96E4
		protected ML_InputComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018E3A RID: 101946
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Input/Blueprints/ML_InputComponent.ML_InputComponent_C";

		// Token: 0x04018E3B RID: 101947
		private static IntPtr _ClassPtr;

		// Token: 0x04018E3C RID: 101948
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
