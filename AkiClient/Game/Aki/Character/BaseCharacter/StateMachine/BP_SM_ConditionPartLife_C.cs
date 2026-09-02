using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042D3 RID: 17107
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionPartLife.BP_SM_ConditionPartLife_C")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 84)]
	public class BP_SM_ConditionPartLife_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D623 RID: 185891 RVA: 0x00ABEAF5 File Offset: 0x00ABCCF5
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionPartLife_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionPartLife.BP_SM_ConditionPartLife_C");
			}
			return BP_SM_ConditionPartLife_C._ClassPtr;
		}

		// Token: 0x0602D624 RID: 185892 RVA: 0x00ABEB1C File Offset: 0x00ABCD1C
		public BP_SM_ConditionPartLife_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionPartLife_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D625 RID: 185893 RVA: 0x00ABEB44 File Offset: 0x00ABCD44
		public BP_SM_ConditionPartLife_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionPartLife_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BCA RID: 31690
		// (get) Token: 0x0602D626 RID: 185894 RVA: 0x00ABEB77 File Offset: 0x00ABCD77
		// (set) Token: 0x0602D627 RID: 185895 RVA: 0x00ABEB8B File Offset: 0x00ABCD8B
		public unsafe string 部位名
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ConditionPartLife_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ConditionPartLife_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007BCB RID: 31691
		// (get) Token: 0x0602D628 RID: 185896 RVA: 0x00ABEBA0 File Offset: 0x00ABCDA0
		// (set) Token: 0x0602D629 RID: 185897 RVA: 0x00ABEBB0 File Offset: 0x00ABCDB0
		public unsafe bool 是否万分比
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionPartLife_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionPartLife_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BCC RID: 31692
		// (get) Token: 0x0602D62A RID: 185898 RVA: 0x00ABEBC1 File Offset: 0x00ABCDC1
		// (set) Token: 0x0602D62B RID: 185899 RVA: 0x00ABEBD1 File Offset: 0x00ABCDD1
		public unsafe int Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionPartLife_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionPartLife_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007BCD RID: 31693
		// (get) Token: 0x0602D62C RID: 185900 RVA: 0x00ABEBE2 File Offset: 0x00ABCDE2
		// (set) Token: 0x0602D62D RID: 185901 RVA: 0x00ABEBF2 File Offset: 0x00ABCDF2
		public unsafe int Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionPartLife_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionPartLife_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602D62E RID: 185902 RVA: 0x00ABEC03 File Offset: 0x00ABCE03
		protected BP_SM_ConditionPartLife_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401973D RID: 104253
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionPartLife.BP_SM_ConditionPartLife_C";

		// Token: 0x0401973E RID: 104254
		private static IntPtr _ClassPtr;

		// Token: 0x0401973F RID: 104255
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019740 RID: 104256
		internal static int __PropertyOffset_0;

		// Token: 0x04019741 RID: 104257
		internal static int __PropertyOffset_1;

		// Token: 0x04019742 RID: 104258
		internal static int __PropertyOffset_2;

		// Token: 0x04019743 RID: 104259
		internal static int __PropertyOffset_3;
	}
}
