using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA036
{
	// Token: 0x02004157 RID: 16727
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA036/ABP_NA036.ABP_NA036_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA036_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C67D RID: 181885 RVA: 0x00AA0530 File Offset: 0x00A9E730
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA036_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA036/ABP_NA036.ABP_NA036_C");
			}
			return ABP_NA036_C._ClassPtr;
		}

		// Token: 0x0602C67E RID: 181886 RVA: 0x00AA0554 File Offset: 0x00A9E754
		public ABP_NA036_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA036_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C67F RID: 181887 RVA: 0x00AA057C File Offset: 0x00A9E77C
		[NullableContext(1)]
		public ABP_NA036_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA036_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C680 RID: 181888 RVA: 0x00AA05AF File Offset: 0x00A9E7AF
		protected ABP_NA036_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A7B RID: 100987
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA036/ABP_NA036.ABP_NA036_C";

		// Token: 0x04018A7C RID: 100988
		private static IntPtr _ClassPtr;

		// Token: 0x04018A7D RID: 100989
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
