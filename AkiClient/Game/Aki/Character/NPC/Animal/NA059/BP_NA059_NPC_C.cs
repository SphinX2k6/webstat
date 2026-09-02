using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA059
{
	// Token: 0x02004127 RID: 16679
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA059/BP_NA059_NPC.BP_NA059_NPC_C")]
	[UnrealStructLayout(2352, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2344)]
	public class BP_NA059_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C58A RID: 181642 RVA: 0x00A9E434 File Offset: 0x00A9C634
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA059_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA059/BP_NA059_NPC.BP_NA059_NPC_C");
			}
			return BP_NA059_NPC_C._ClassPtr;
		}

		// Token: 0x0602C58B RID: 181643 RVA: 0x00A9E458 File Offset: 0x00A9C658
		public BP_NA059_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA059_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C58C RID: 181644 RVA: 0x00A9E480 File Offset: 0x00A9C680
		[NullableContext(1)]
		public BP_NA059_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA059_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700775E RID: 30558
		// (get) Token: 0x0602C58D RID: 181645 RVA: 0x00A9E4B3 File Offset: 0x00A9C6B3
		// (set) Token: 0x0602C58E RID: 181646 RVA: 0x00A9E4C7 File Offset: 0x00A9C6C7
		public unsafe UKuroAdjustableCapsuleComponent Bip001_Bone_Forearm_R
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_NPC_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_NPC_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700775F RID: 30559
		// (get) Token: 0x0602C58F RID: 181647 RVA: 0x00A9E4DC File Offset: 0x00A9C6DC
		// (set) Token: 0x0602C590 RID: 181648 RVA: 0x00A9E4F0 File Offset: 0x00A9C6F0
		public unsafe UKuroAdjustableCapsuleComponent Bip001_Bone_Forearm_L
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_NPC_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_NPC_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007760 RID: 30560
		// (get) Token: 0x0602C591 RID: 181649 RVA: 0x00A9E505 File Offset: 0x00A9C705
		// (set) Token: 0x0602C592 RID: 181650 RVA: 0x00A9E519 File Offset: 0x00A9C719
		public unsafe UKuroAdjustableCapsuleComponent Bip001
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_NPC_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_NPC_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0602C593 RID: 181651 RVA: 0x00A9E52E File Offset: 0x00A9C72E
		protected BP_NA059_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189C3 RID: 100803
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA059/BP_NA059_NPC.BP_NA059_NPC_C";

		// Token: 0x040189C4 RID: 100804
		private static IntPtr _ClassPtr;

		// Token: 0x040189C5 RID: 100805
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040189C6 RID: 100806
		internal new static int __PropertyOffset_0;

		// Token: 0x040189C7 RID: 100807
		internal new static int __PropertyOffset_1;

		// Token: 0x040189C8 RID: 100808
		internal new static int __PropertyOffset_2;
	}
}
