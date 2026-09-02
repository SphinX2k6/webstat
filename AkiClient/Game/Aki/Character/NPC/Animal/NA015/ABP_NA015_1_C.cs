using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA015
{
	// Token: 0x02004170 RID: 16752
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA015/ABP_NA015_1.ABP_NA015_1_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA015_1_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6F7 RID: 182007 RVA: 0x00AA1484 File Offset: 0x00A9F684
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA015_1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA015/ABP_NA015_1.ABP_NA015_1_C");
			}
			return ABP_NA015_1_C._ClassPtr;
		}

		// Token: 0x0602C6F8 RID: 182008 RVA: 0x00AA14A8 File Offset: 0x00A9F6A8
		public ABP_NA015_1_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA015_1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6F9 RID: 182009 RVA: 0x00AA14D0 File Offset: 0x00A9F6D0
		[NullableContext(1)]
		public ABP_NA015_1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA015_1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6FA RID: 182010 RVA: 0x00AA1503 File Offset: 0x00A9F703
		protected ABP_NA015_1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AD3 RID: 101075
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA015/ABP_NA015_1.ABP_NA015_1_C";

		// Token: 0x04018AD4 RID: 101076
		private static IntPtr _ClassPtr;

		// Token: 0x04018AD5 RID: 101077
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
