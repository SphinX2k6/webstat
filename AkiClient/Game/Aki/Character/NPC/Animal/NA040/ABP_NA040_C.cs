using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA040
{
	// Token: 0x0200414E RID: 16718
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA040/ABP_na040.ABP_NA040_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA040_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C659 RID: 181849 RVA: 0x00AA0068 File Offset: 0x00A9E268
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA040_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA040/ABP_na040.ABP_NA040_C");
			}
			return ABP_NA040_C._ClassPtr;
		}

		// Token: 0x0602C65A RID: 181850 RVA: 0x00AA008C File Offset: 0x00A9E28C
		public ABP_NA040_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA040_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C65B RID: 181851 RVA: 0x00AA00B4 File Offset: 0x00A9E2B4
		[NullableContext(1)]
		public ABP_NA040_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA040_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C65C RID: 181852 RVA: 0x00AA00E7 File Offset: 0x00A9E2E7
		protected ABP_NA040_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A60 RID: 100960
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA040/ABP_na040.ABP_NA040_C";

		// Token: 0x04018A61 RID: 100961
		private static IntPtr _ClassPtr;

		// Token: 0x04018A62 RID: 100962
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
