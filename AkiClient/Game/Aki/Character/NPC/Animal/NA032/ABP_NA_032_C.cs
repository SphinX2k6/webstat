using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA032
{
	// Token: 0x0200415F RID: 16735
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA032/ABP_NA_032.ABP_NA_032_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA_032_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6A7 RID: 181927 RVA: 0x00AA0A3D File Offset: 0x00A9EC3D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA_032_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA032/ABP_NA_032.ABP_NA_032_C");
			}
			return ABP_NA_032_C._ClassPtr;
		}

		// Token: 0x0602C6A8 RID: 181928 RVA: 0x00AA0A64 File Offset: 0x00A9EC64
		public ABP_NA_032_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA_032_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6A9 RID: 181929 RVA: 0x00AA0A8C File Offset: 0x00A9EC8C
		[NullableContext(1)]
		public ABP_NA_032_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA_032_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6AA RID: 181930 RVA: 0x00AA0ABF File Offset: 0x00A9ECBF
		protected ABP_NA_032_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A98 RID: 101016
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA032/ABP_NA_032.ABP_NA_032_C";

		// Token: 0x04018A99 RID: 101017
		private static IntPtr _ClassPtr;

		// Token: 0x04018A9A RID: 101018
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
