using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA002
{
	// Token: 0x0200418F RID: 16783
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA002/BP_NA002.BP_NA002_C")]
	[UnrealStructLayout(2224, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2224)]
	public class BP_NA002_C : __TsBaseCharacter_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C789 RID: 182153 RVA: 0x00AA2864 File Offset: 0x00AA0A64
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA002_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA002/BP_NA002.BP_NA002_C");
			}
			return BP_NA002_C._ClassPtr;
		}

		// Token: 0x0602C78A RID: 182154 RVA: 0x00AA2888 File Offset: 0x00AA0A88
		public BP_NA002_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA002_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C78B RID: 182155 RVA: 0x00AA28B0 File Offset: 0x00AA0AB0
		[NullableContext(1)]
		public BP_NA002_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA002_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C78C RID: 182156 RVA: 0x00AA28E3 File Offset: 0x00AA0AE3
		protected BP_NA002_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B3E RID: 101182
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA002/BP_NA002.BP_NA002_C";

		// Token: 0x04018B3F RID: 101183
		private static IntPtr _ClassPtr;

		// Token: 0x04018B40 RID: 101184
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
