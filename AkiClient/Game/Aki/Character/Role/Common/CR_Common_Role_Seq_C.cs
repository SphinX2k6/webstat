using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common
{
	// Token: 0x02003FFD RID: 16381
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/CR_Common_Role_Seq.CR_Common_Role_Seq_C")]
	[UnrealStructLayout(2080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2076)]
	public class CR_Common_Role_Seq_C : UControlRig, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A866 RID: 174182 RVA: 0x00A5BF00 File Offset: 0x00A5A100
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CR_Common_Role_Seq_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/CR_Common_Role_Seq.CR_Common_Role_Seq_C");
			}
			return CR_Common_Role_Seq_C._ClassPtr;
		}

		// Token: 0x0602A867 RID: 174183 RVA: 0x00A5BF24 File Offset: 0x00A5A124
		public CR_Common_Role_Seq_C() : this(BuiltinUtils.AllocNativeUObject(CR_Common_Role_Seq_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A868 RID: 174184 RVA: 0x00A5BF4C File Offset: 0x00A5A14C
		[NullableContext(1)]
		public CR_Common_Role_Seq_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CR_Common_Role_Seq_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006E82 RID: 28290
		// (get) Token: 0x0602A869 RID: 174185 RVA: 0x00A5BF7F File Offset: 0x00A5A17F
		// (set) Token: 0x0602A86A RID: 174186 RVA: 0x00A5BF8F File Offset: 0x00A5A18F
		public unsafe float eye_alpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)CR_Common_Role_Seq_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)CR_Common_Role_Seq_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006E83 RID: 28291
		// (get) Token: 0x0602A86B RID: 174187 RVA: 0x00A5BFA0 File Offset: 0x00A5A1A0
		// (set) Token: 0x0602A86C RID: 174188 RVA: 0x00A5BFB0 File Offset: 0x00A5A1B0
		public unsafe float eyebrow_alpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)CR_Common_Role_Seq_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)CR_Common_Role_Seq_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006E84 RID: 28292
		// (get) Token: 0x0602A86D RID: 174189 RVA: 0x00A5BFC1 File Offset: 0x00A5A1C1
		// (set) Token: 0x0602A86E RID: 174190 RVA: 0x00A5BFD1 File Offset: 0x00A5A1D1
		public unsafe float mouth_alpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)CR_Common_Role_Seq_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)CR_Common_Role_Seq_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602A86F RID: 174191 RVA: 0x00A5BFE2 File Offset: 0x00A5A1E2
		protected CR_Common_Role_Seq_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017206 RID: 94726
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/CR_Common_Role_Seq.CR_Common_Role_Seq_C";

		// Token: 0x04017207 RID: 94727
		private static IntPtr _ClassPtr;

		// Token: 0x04017208 RID: 94728
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017209 RID: 94729
		internal static int __PropertyOffset_0;

		// Token: 0x0401720A RID: 94730
		internal static int __PropertyOffset_1;

		// Token: 0x0401720B RID: 94731
		internal static int __PropertyOffset_2;
	}
}
