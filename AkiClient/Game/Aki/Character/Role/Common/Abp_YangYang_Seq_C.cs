using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common
{
	// Token: 0x02003FFC RID: 16380
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abp_YangYang_Seq.Abp_YangYang_Seq_C")]
	[UnrealStructLayout(4432, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 4421)]
	public class Abp_YangYang_Seq_C : ABP_BaseSequenceRole_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A862 RID: 174178 RVA: 0x00A5BE78 File Offset: 0x00A5A078
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (Abp_YangYang_Seq_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abp_YangYang_Seq.Abp_YangYang_Seq_C");
			}
			return Abp_YangYang_Seq_C._ClassPtr;
		}

		// Token: 0x0602A863 RID: 174179 RVA: 0x00A5BE9C File Offset: 0x00A5A09C
		public Abp_YangYang_Seq_C() : this(BuiltinUtils.AllocNativeUObject(Abp_YangYang_Seq_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A864 RID: 174180 RVA: 0x00A5BEC4 File Offset: 0x00A5A0C4
		[NullableContext(1)]
		public Abp_YangYang_Seq_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(Abp_YangYang_Seq_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A865 RID: 174181 RVA: 0x00A5BEF7 File Offset: 0x00A5A0F7
		protected Abp_YangYang_Seq_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017203 RID: 94723
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abp_YangYang_Seq.Abp_YangYang_Seq_C";

		// Token: 0x04017204 RID: 94724
		private static IntPtr _ClassPtr;

		// Token: 0x04017205 RID: 94725
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
