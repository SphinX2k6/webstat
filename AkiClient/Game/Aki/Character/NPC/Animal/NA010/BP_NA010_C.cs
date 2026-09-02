using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBird;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA010
{
	// Token: 0x02004180 RID: 16768
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA010/BP_NA010.BP_NA010_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_NA010_C : BP_BaseBird_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C745 RID: 182085 RVA: 0x00AA1FBC File Offset: 0x00AA01BC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA010_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA010/BP_NA010.BP_NA010_C");
			}
			return BP_NA010_C._ClassPtr;
		}

		// Token: 0x0602C746 RID: 182086 RVA: 0x00AA1FE0 File Offset: 0x00AA01E0
		public BP_NA010_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA010_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C747 RID: 182087 RVA: 0x00AA2008 File Offset: 0x00AA0208
		[NullableContext(1)]
		public BP_NA010_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA010_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700777B RID: 30587
		// (get) Token: 0x0602C748 RID: 182088 RVA: 0x00AA203B File Offset: 0x00AA023B
		// (set) Token: 0x0602C749 RID: 182089 RVA: 0x00AA204F File Offset: 0x00AA024F
		[Nullable(2)]
		public unsafe UCapsuleComponent Root
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA010_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA010_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602C74A RID: 182090 RVA: 0x00AA2064 File Offset: 0x00AA0264
		protected BP_NA010_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B0D RID: 101133
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA010/BP_NA010.BP_NA010_C";

		// Token: 0x04018B0E RID: 101134
		private static IntPtr _ClassPtr;

		// Token: 0x04018B0F RID: 101135
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018B10 RID: 101136
		internal new static int __PropertyOffset_0;
	}
}
