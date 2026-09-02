using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBird;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA007
{
	// Token: 0x02004183 RID: 16771
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA007/BP_NA007.BP_NA007_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA007_C : BP_BaseBird_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C753 RID: 182099 RVA: 0x00AA2180 File Offset: 0x00AA0380
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA007_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA007/BP_NA007.BP_NA007_C");
			}
			return BP_NA007_C._ClassPtr;
		}

		// Token: 0x0602C754 RID: 182100 RVA: 0x00AA21A4 File Offset: 0x00AA03A4
		public BP_NA007_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA007_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C755 RID: 182101 RVA: 0x00AA21CC File Offset: 0x00AA03CC
		[NullableContext(1)]
		public BP_NA007_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA007_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C756 RID: 182102 RVA: 0x00AA21FF File Offset: 0x00AA03FF
		protected BP_NA007_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B17 RID: 101143
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA007/BP_NA007.BP_NA007_C";

		// Token: 0x04018B18 RID: 101144
		private static IntPtr _ClassPtr;

		// Token: 0x04018B19 RID: 101145
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
