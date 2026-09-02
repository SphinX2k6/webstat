using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA026
{
	// Token: 0x02004165 RID: 16741
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA026/BP_NA026.BP_NA026_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_NA026_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6BF RID: 181951 RVA: 0x00AA0D70 File Offset: 0x00A9EF70
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA026_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA026/BP_NA026.BP_NA026_C");
			}
			return BP_NA026_C._ClassPtr;
		}

		// Token: 0x0602C6C0 RID: 181952 RVA: 0x00AA0D94 File Offset: 0x00A9EF94
		public BP_NA026_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA026_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6C1 RID: 181953 RVA: 0x00AA0DBC File Offset: 0x00A9EFBC
		[NullableContext(1)]
		public BP_NA026_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA026_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007771 RID: 30577
		// (get) Token: 0x0602C6C2 RID: 181954 RVA: 0x00AA0DEF File Offset: 0x00A9EFEF
		// (set) Token: 0x0602C6C3 RID: 181955 RVA: 0x00AA0E03 File Offset: 0x00A9F003
		[Nullable(2)]
		public unsafe UCapsuleComponent Root
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA026_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA026_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602C6C4 RID: 181956 RVA: 0x00AA0E18 File Offset: 0x00A9F018
		protected BP_NA026_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AAA RID: 101034
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA026/BP_NA026.BP_NA026_C";

		// Token: 0x04018AAB RID: 101035
		private static IntPtr _ClassPtr;

		// Token: 0x04018AAC RID: 101036
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018AAD RID: 101037
		internal new static int __PropertyOffset_0;
	}
}
