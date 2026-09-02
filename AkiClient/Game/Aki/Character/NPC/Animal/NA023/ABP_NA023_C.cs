using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA023
{
	// Token: 0x02004166 RID: 16742
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA023/ABP_NA023.ABP_NA023_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA023_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6C5 RID: 181957 RVA: 0x00AA0E21 File Offset: 0x00A9F021
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA023_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA023/ABP_NA023.ABP_NA023_C");
			}
			return ABP_NA023_C._ClassPtr;
		}

		// Token: 0x0602C6C6 RID: 181958 RVA: 0x00AA0E48 File Offset: 0x00A9F048
		public ABP_NA023_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA023_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6C7 RID: 181959 RVA: 0x00AA0E70 File Offset: 0x00A9F070
		[NullableContext(1)]
		public ABP_NA023_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA023_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6C8 RID: 181960 RVA: 0x00AA0EA3 File Offset: 0x00A9F0A3
		protected ABP_NA023_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AAE RID: 101038
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA023/ABP_NA023.ABP_NA023_C";

		// Token: 0x04018AAF RID: 101039
		private static IntPtr _ClassPtr;

		// Token: 0x04018AB0 RID: 101040
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
