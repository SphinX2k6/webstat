using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA015
{
	// Token: 0x02004171 RID: 16753
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA015/ABP_NA015_2.ABP_NA015_2_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA015_2_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6FB RID: 182011 RVA: 0x00AA150C File Offset: 0x00A9F70C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA015_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA015/ABP_NA015_2.ABP_NA015_2_C");
			}
			return ABP_NA015_2_C._ClassPtr;
		}

		// Token: 0x0602C6FC RID: 182012 RVA: 0x00AA1530 File Offset: 0x00A9F730
		public ABP_NA015_2_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA015_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6FD RID: 182013 RVA: 0x00AA1558 File Offset: 0x00A9F758
		[NullableContext(1)]
		public ABP_NA015_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA015_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6FE RID: 182014 RVA: 0x00AA158B File Offset: 0x00A9F78B
		protected ABP_NA015_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AD6 RID: 101078
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA015/ABP_NA015_2.ABP_NA015_2_C";

		// Token: 0x04018AD7 RID: 101079
		private static IntPtr _ClassPtr;

		// Token: 0x04018AD8 RID: 101080
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
