using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA006
{
	// Token: 0x0200418A RID: 16778
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA006/BP_NA006_Path.BP_NA006_Path_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_NA006_Path_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C771 RID: 182129 RVA: 0x00AA2561 File Offset: 0x00AA0761
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA006_Path_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA006/BP_NA006_Path.BP_NA006_Path_C");
			}
			return BP_NA006_Path_C._ClassPtr;
		}

		// Token: 0x0602C772 RID: 182130 RVA: 0x00AA2588 File Offset: 0x00AA0788
		public BP_NA006_Path_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA006_Path_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C773 RID: 182131 RVA: 0x00AA25B0 File Offset: 0x00AA07B0
		[NullableContext(1)]
		public BP_NA006_Path_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA006_Path_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700777D RID: 30589
		// (get) Token: 0x0602C774 RID: 182132 RVA: 0x00AA25E3 File Offset: 0x00AA07E3
		// (set) Token: 0x0602C775 RID: 182133 RVA: 0x00AA25F7 File Offset: 0x00AA07F7
		[Nullable(2)]
		public unsafe UCapsuleComponent Root
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA006_Path_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA006_Path_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602C776 RID: 182134 RVA: 0x00AA260C File Offset: 0x00AA080C
		protected BP_NA006_Path_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B2D RID: 101165
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA006/BP_NA006_Path.BP_NA006_Path_C";

		// Token: 0x04018B2E RID: 101166
		private static IntPtr _ClassPtr;

		// Token: 0x04018B2F RID: 101167
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018B30 RID: 101168
		internal new static int __PropertyOffset_0;
	}
}
