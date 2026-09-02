using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA004
{
	// Token: 0x0200418D RID: 16781
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA004/BP_NA004.BP_NA004_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA004_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C781 RID: 182145 RVA: 0x00AA2754 File Offset: 0x00AA0954
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA004_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA004/BP_NA004.BP_NA004_C");
			}
			return BP_NA004_C._ClassPtr;
		}

		// Token: 0x0602C782 RID: 182146 RVA: 0x00AA2778 File Offset: 0x00AA0978
		public BP_NA004_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA004_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C783 RID: 182147 RVA: 0x00AA27A0 File Offset: 0x00AA09A0
		[NullableContext(1)]
		public BP_NA004_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA004_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C784 RID: 182148 RVA: 0x00AA27D3 File Offset: 0x00AA09D3
		protected BP_NA004_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B38 RID: 101176
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA004/BP_NA004.BP_NA004_C";

		// Token: 0x04018B39 RID: 101177
		private static IntPtr _ClassPtr;

		// Token: 0x04018B3A RID: 101178
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
