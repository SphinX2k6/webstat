using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA004
{
	// Token: 0x0200418C RID: 16780
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA004/ABP_NA004.ABP_NA004_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA004_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C77D RID: 182141 RVA: 0x00AA26C9 File Offset: 0x00AA08C9
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA004_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA004/ABP_NA004.ABP_NA004_C");
			}
			return ABP_NA004_C._ClassPtr;
		}

		// Token: 0x0602C77E RID: 182142 RVA: 0x00AA26F0 File Offset: 0x00AA08F0
		public ABP_NA004_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA004_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C77F RID: 182143 RVA: 0x00AA2718 File Offset: 0x00AA0918
		[NullableContext(1)]
		public ABP_NA004_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA004_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C780 RID: 182144 RVA: 0x00AA274B File Offset: 0x00AA094B
		protected ABP_NA004_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B35 RID: 101173
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA004/ABP_NA004.ABP_NA004_C";

		// Token: 0x04018B36 RID: 101174
		private static IntPtr _ClassPtr;

		// Token: 0x04018B37 RID: 101175
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
