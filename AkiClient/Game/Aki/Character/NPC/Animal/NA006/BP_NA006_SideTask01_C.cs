using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA006
{
	// Token: 0x0200418B RID: 16779
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA006/BP_NA006_SideTask01.BP_NA006_SideTask01_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_NA006_SideTask01_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C777 RID: 182135 RVA: 0x00AA2615 File Offset: 0x00AA0815
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA006_SideTask01_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA006/BP_NA006_SideTask01.BP_NA006_SideTask01_C");
			}
			return BP_NA006_SideTask01_C._ClassPtr;
		}

		// Token: 0x0602C778 RID: 182136 RVA: 0x00AA263C File Offset: 0x00AA083C
		public BP_NA006_SideTask01_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA006_SideTask01_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C779 RID: 182137 RVA: 0x00AA2664 File Offset: 0x00AA0864
		[NullableContext(1)]
		public BP_NA006_SideTask01_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA006_SideTask01_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700777E RID: 30590
		// (get) Token: 0x0602C77A RID: 182138 RVA: 0x00AA2697 File Offset: 0x00AA0897
		// (set) Token: 0x0602C77B RID: 182139 RVA: 0x00AA26AB File Offset: 0x00AA08AB
		[Nullable(2)]
		public unsafe UCapsuleComponent Root
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA006_SideTask01_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA006_SideTask01_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602C77C RID: 182140 RVA: 0x00AA26C0 File Offset: 0x00AA08C0
		protected BP_NA006_SideTask01_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B31 RID: 101169
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA006/BP_NA006_SideTask01.BP_NA006_SideTask01_C";

		// Token: 0x04018B32 RID: 101170
		private static IntPtr _ClassPtr;

		// Token: 0x04018B33 RID: 101171
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018B34 RID: 101172
		internal new static int __PropertyOffset_0;
	}
}
