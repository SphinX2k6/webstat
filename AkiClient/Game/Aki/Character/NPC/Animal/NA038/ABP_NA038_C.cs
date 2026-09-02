using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA038
{
	// Token: 0x02004153 RID: 16723
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA038/ABP_NA038.ABP_NA038_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA038_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C66D RID: 181869 RVA: 0x00AA0310 File Offset: 0x00A9E510
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA038_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA038/ABP_NA038.ABP_NA038_C");
			}
			return ABP_NA038_C._ClassPtr;
		}

		// Token: 0x0602C66E RID: 181870 RVA: 0x00AA0334 File Offset: 0x00A9E534
		public ABP_NA038_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA038_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C66F RID: 181871 RVA: 0x00AA035C File Offset: 0x00A9E55C
		[NullableContext(1)]
		public ABP_NA038_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA038_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C670 RID: 181872 RVA: 0x00AA038F File Offset: 0x00A9E58F
		protected ABP_NA038_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A6F RID: 100975
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA038/ABP_NA038.ABP_NA038_C";

		// Token: 0x04018A70 RID: 100976
		private static IntPtr _ClassPtr;

		// Token: 0x04018A71 RID: 100977
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
