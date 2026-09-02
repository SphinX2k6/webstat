using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA006
{
	// Token: 0x02004189 RID: 16777
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA006/BP_NA006.BP_NA006_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_NA006_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C76B RID: 182123 RVA: 0x00AA24B0 File Offset: 0x00AA06B0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA006_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA006/BP_NA006.BP_NA006_C");
			}
			return BP_NA006_C._ClassPtr;
		}

		// Token: 0x0602C76C RID: 182124 RVA: 0x00AA24D4 File Offset: 0x00AA06D4
		public BP_NA006_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA006_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C76D RID: 182125 RVA: 0x00AA24FC File Offset: 0x00AA06FC
		[NullableContext(1)]
		public BP_NA006_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA006_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700777C RID: 30588
		// (get) Token: 0x0602C76E RID: 182126 RVA: 0x00AA252F File Offset: 0x00AA072F
		// (set) Token: 0x0602C76F RID: 182127 RVA: 0x00AA2543 File Offset: 0x00AA0743
		[Nullable(2)]
		public unsafe UCapsuleComponent Root
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA006_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA006_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602C770 RID: 182128 RVA: 0x00AA2558 File Offset: 0x00AA0758
		protected BP_NA006_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B29 RID: 101161
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA006/BP_NA006.BP_NA006_C";

		// Token: 0x04018B2A RID: 101162
		private static IntPtr _ClassPtr;

		// Token: 0x04018B2B RID: 101163
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018B2C RID: 101164
		internal new static int __PropertyOffset_0;
	}
}
