using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA066
{
	// Token: 0x0200410C RID: 16652
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA066/ABP_NA066.ABP_NA066_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA066_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4CB RID: 181451 RVA: 0x00A9CB98 File Offset: 0x00A9AD98
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA066_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA066/ABP_NA066.ABP_NA066_C");
			}
			return ABP_NA066_C._ClassPtr;
		}

		// Token: 0x0602C4CC RID: 181452 RVA: 0x00A9CBBC File Offset: 0x00A9ADBC
		public ABP_NA066_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA066_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4CD RID: 181453 RVA: 0x00A9CBE4 File Offset: 0x00A9ADE4
		[NullableContext(1)]
		public ABP_NA066_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA066_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C4CE RID: 181454 RVA: 0x00A9CC17 File Offset: 0x00A9AE17
		protected ABP_NA066_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401893B RID: 100667
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA066/ABP_NA066.ABP_NA066_C";

		// Token: 0x0401893C RID: 100668
		private static IntPtr _ClassPtr;

		// Token: 0x0401893D RID: 100669
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
