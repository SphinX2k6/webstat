using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA023
{
	// Token: 0x02004167 RID: 16743
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA023/BP_NA023.BP_NA023_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_NA023_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6C9 RID: 181961 RVA: 0x00AA0EAC File Offset: 0x00A9F0AC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA023_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA023/BP_NA023.BP_NA023_C");
			}
			return BP_NA023_C._ClassPtr;
		}

		// Token: 0x0602C6CA RID: 181962 RVA: 0x00AA0ED0 File Offset: 0x00A9F0D0
		public BP_NA023_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA023_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6CB RID: 181963 RVA: 0x00AA0EF8 File Offset: 0x00A9F0F8
		[NullableContext(1)]
		public BP_NA023_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA023_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007772 RID: 30578
		// (get) Token: 0x0602C6CC RID: 181964 RVA: 0x00AA0F2B File Offset: 0x00A9F12B
		// (set) Token: 0x0602C6CD RID: 181965 RVA: 0x00AA0F3F File Offset: 0x00A9F13F
		[Nullable(2)]
		public unsafe UCapsuleComponent Root
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA023_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA023_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602C6CE RID: 181966 RVA: 0x00AA0F54 File Offset: 0x00A9F154
		protected BP_NA023_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AB1 RID: 101041
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA023/BP_NA023.BP_NA023_C";

		// Token: 0x04018AB2 RID: 101042
		private static IntPtr _ClassPtr;

		// Token: 0x04018AB3 RID: 101043
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018AB4 RID: 101044
		internal new static int __PropertyOffset_0;
	}
}
