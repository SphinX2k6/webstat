using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA010
{
	// Token: 0x0200417F RID: 16767
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA010/ABP_NA010.ABP_NA010_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA010_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C741 RID: 182081 RVA: 0x00AA1F34 File Offset: 0x00AA0134
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA010_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA010/ABP_NA010.ABP_NA010_C");
			}
			return ABP_NA010_C._ClassPtr;
		}

		// Token: 0x0602C742 RID: 182082 RVA: 0x00AA1F58 File Offset: 0x00AA0158
		public ABP_NA010_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA010_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C743 RID: 182083 RVA: 0x00AA1F80 File Offset: 0x00AA0180
		[NullableContext(1)]
		public ABP_NA010_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA010_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C744 RID: 182084 RVA: 0x00AA1FB3 File Offset: 0x00AA01B3
		protected ABP_NA010_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B0A RID: 101130
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA010/ABP_NA010.ABP_NA010_C";

		// Token: 0x04018B0B RID: 101131
		private static IntPtr _ClassPtr;

		// Token: 0x04018B0C RID: 101132
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
