using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA006
{
	// Token: 0x02004187 RID: 16775
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA006/ABP_NA006V2_6.ABP_NA006V2_6_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA006V2_6_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C763 RID: 182115 RVA: 0x00AA23A0 File Offset: 0x00AA05A0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA006V2_6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA006/ABP_NA006V2_6.ABP_NA006V2_6_C");
			}
			return ABP_NA006V2_6_C._ClassPtr;
		}

		// Token: 0x0602C764 RID: 182116 RVA: 0x00AA23C4 File Offset: 0x00AA05C4
		public ABP_NA006V2_6_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA006V2_6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C765 RID: 182117 RVA: 0x00AA23EC File Offset: 0x00AA05EC
		[NullableContext(1)]
		public ABP_NA006V2_6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA006V2_6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C766 RID: 182118 RVA: 0x00AA241F File Offset: 0x00AA061F
		protected ABP_NA006V2_6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B23 RID: 101155
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA006/ABP_NA006V2_6.ABP_NA006V2_6_C";

		// Token: 0x04018B24 RID: 101156
		private static IntPtr _ClassPtr;

		// Token: 0x04018B25 RID: 101157
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
