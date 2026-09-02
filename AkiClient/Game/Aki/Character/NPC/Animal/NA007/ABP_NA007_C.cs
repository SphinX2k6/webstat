using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA007
{
	// Token: 0x02004181 RID: 16769
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA007/ABP_NA007.ABP_NA007_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA007_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C74B RID: 182091 RVA: 0x00AA206D File Offset: 0x00AA026D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA007_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA007/ABP_NA007.ABP_NA007_C");
			}
			return ABP_NA007_C._ClassPtr;
		}

		// Token: 0x0602C74C RID: 182092 RVA: 0x00AA2094 File Offset: 0x00AA0294
		public ABP_NA007_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA007_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C74D RID: 182093 RVA: 0x00AA20BC File Offset: 0x00AA02BC
		[NullableContext(1)]
		public ABP_NA007_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA007_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C74E RID: 182094 RVA: 0x00AA20EF File Offset: 0x00AA02EF
		protected ABP_NA007_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B11 RID: 101137
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA007/ABP_NA007.ABP_NA007_C";

		// Token: 0x04018B12 RID: 101138
		private static IntPtr _ClassPtr;

		// Token: 0x04018B13 RID: 101139
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
