using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA071
{
	// Token: 0x020040FB RID: 16635
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA071/BP_NA071.BP_NA071_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA071_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C46D RID: 181357 RVA: 0x00A9BFA8 File Offset: 0x00A9A1A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA071_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA071/BP_NA071.BP_NA071_C");
			}
			return BP_NA071_C._ClassPtr;
		}

		// Token: 0x0602C46E RID: 181358 RVA: 0x00A9BFCC File Offset: 0x00A9A1CC
		public BP_NA071_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA071_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C46F RID: 181359 RVA: 0x00A9BFF4 File Offset: 0x00A9A1F4
		[NullableContext(1)]
		public BP_NA071_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA071_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C470 RID: 181360 RVA: 0x00A9C027 File Offset: 0x00A9A227
		protected BP_NA071_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040188F8 RID: 100600
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA071/BP_NA071.BP_NA071_C";

		// Token: 0x040188F9 RID: 100601
		private static IntPtr _ClassPtr;

		// Token: 0x040188FA RID: 100602
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
