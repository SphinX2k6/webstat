using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA002
{
	// Token: 0x0200418E RID: 16782
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA002/ABP_NA002.ABP_NA002_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA002_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C785 RID: 182149 RVA: 0x00AA27DC File Offset: 0x00AA09DC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA002_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA002/ABP_NA002.ABP_NA002_C");
			}
			return ABP_NA002_C._ClassPtr;
		}

		// Token: 0x0602C786 RID: 182150 RVA: 0x00AA2800 File Offset: 0x00AA0A00
		public ABP_NA002_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA002_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C787 RID: 182151 RVA: 0x00AA2828 File Offset: 0x00AA0A28
		[NullableContext(1)]
		public ABP_NA002_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA002_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C788 RID: 182152 RVA: 0x00AA285B File Offset: 0x00AA0A5B
		protected ABP_NA002_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B3B RID: 101179
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA002/ABP_NA002.ABP_NA002_C";

		// Token: 0x04018B3C RID: 101180
		private static IntPtr _ClassPtr;

		// Token: 0x04018B3D RID: 101181
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
