using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.NA004;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA037
{
	// Token: 0x02004156 RID: 16726
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA037/BP_NA037.BP_NA037_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA037_C : BP_NA004_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C679 RID: 181881 RVA: 0x00AA04A8 File Offset: 0x00A9E6A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA037_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA037/BP_NA037.BP_NA037_C");
			}
			return BP_NA037_C._ClassPtr;
		}

		// Token: 0x0602C67A RID: 181882 RVA: 0x00AA04CC File Offset: 0x00A9E6CC
		public BP_NA037_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA037_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C67B RID: 181883 RVA: 0x00AA04F4 File Offset: 0x00A9E6F4
		[NullableContext(1)]
		public BP_NA037_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA037_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C67C RID: 181884 RVA: 0x00AA0527 File Offset: 0x00A9E727
		protected BP_NA037_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A78 RID: 100984
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA037/BP_NA037.BP_NA037_C";

		// Token: 0x04018A79 RID: 100985
		private static IntPtr _ClassPtr;

		// Token: 0x04018A7A RID: 100986
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
