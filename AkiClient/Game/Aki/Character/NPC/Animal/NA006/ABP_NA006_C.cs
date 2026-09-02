using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA006
{
	// Token: 0x02004188 RID: 16776
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA006/ABP_NA006.ABP_NA006_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA006_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C767 RID: 182119 RVA: 0x00AA2428 File Offset: 0x00AA0628
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA006_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA006/ABP_NA006.ABP_NA006_C");
			}
			return ABP_NA006_C._ClassPtr;
		}

		// Token: 0x0602C768 RID: 182120 RVA: 0x00AA244C File Offset: 0x00AA064C
		public ABP_NA006_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA006_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C769 RID: 182121 RVA: 0x00AA2474 File Offset: 0x00AA0674
		[NullableContext(1)]
		public ABP_NA006_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA006_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C76A RID: 182122 RVA: 0x00AA24A7 File Offset: 0x00AA06A7
		protected ABP_NA006_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B26 RID: 101158
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA006/ABP_NA006.ABP_NA006_C";

		// Token: 0x04018B27 RID: 101159
		private static IntPtr _ClassPtr;

		// Token: 0x04018B28 RID: 101160
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
