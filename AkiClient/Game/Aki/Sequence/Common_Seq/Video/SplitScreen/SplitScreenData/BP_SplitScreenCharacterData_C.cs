using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Common_Seq.Video.SplitScreen.SplitScreenData
{
	// Token: 0x020043A4 RID: 17316
	[UnrealObjectPath("/Game/Aki/Sequence/Common_Seq/Video/SplitScreen/SplitScreenData/BP_SplitScreenCharacterData.BP_SplitScreenCharacterData_C")]
	[UnrealStructLayout(152, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 148)]
	public class BP_SplitScreenCharacterData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602E07F RID: 188543 RVA: 0x00AD4953 File Offset: 0x00AD2B53
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SplitScreenCharacterData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Common_Seq/Video/SplitScreen/SplitScreenData/BP_SplitScreenCharacterData.BP_SplitScreenCharacterData_C");
			}
			return BP_SplitScreenCharacterData_C._ClassPtr;
		}

		// Token: 0x0602E080 RID: 188544 RVA: 0x00AD4978 File Offset: 0x00AD2B78
		public BP_SplitScreenCharacterData_C() : this(BuiltinUtils.AllocNativeUObject(BP_SplitScreenCharacterData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602E081 RID: 188545 RVA: 0x00AD49A0 File Offset: 0x00AD2BA0
		[NullableContext(1)]
		public BP_SplitScreenCharacterData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SplitScreenCharacterData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007EA9 RID: 32425
		// (get) Token: 0x0602E082 RID: 188546 RVA: 0x00AD49D3 File Offset: 0x00AD2BD3
		// (set) Token: 0x0602E083 RID: 188547 RVA: 0x00AD49E7 File Offset: 0x00AD2BE7
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<AActor> CharacterActorClass
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreenCharacterData_C.__PropertyOffset_0);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreenCharacterData_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007EAA RID: 32426
		// (get) Token: 0x0602E084 RID: 188548 RVA: 0x00AD49FC File Offset: 0x00AD2BFC
		// (set) Token: 0x0602E085 RID: 188549 RVA: 0x00AD4A10 File Offset: 0x00AD2C10
		[Nullable(2)]
		public unsafe UAnimSequence Cos_Pose_AnimSequence
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimSequence>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreenCharacterData_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitScreenCharacterData_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007EAB RID: 32427
		// (get) Token: 0x0602E086 RID: 188550 RVA: 0x00AD4A25 File Offset: 0x00AD2C25
		// (set) Token: 0x0602E087 RID: 188551 RVA: 0x00AD4A39 File Offset: 0x00AD2C39
		public unsafe FVector PointLight_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreenCharacterData_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreenCharacterData_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007EAC RID: 32428
		// (get) Token: 0x0602E088 RID: 188552 RVA: 0x00AD4A4E File Offset: 0x00AD2C4E
		// (set) Token: 0x0602E089 RID: 188553 RVA: 0x00AD4A62 File Offset: 0x00AD2C62
		public unsafe FLinearColor PointLight_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreenCharacterData_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreenCharacterData_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007EAD RID: 32429
		// (get) Token: 0x0602E08A RID: 188554 RVA: 0x00AD4A77 File Offset: 0x00AD2C77
		// (set) Token: 0x0602E08B RID: 188555 RVA: 0x00AD4A8B File Offset: 0x00AD2C8B
		public unsafe FLinearColor EyeLightSimulation_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreenCharacterData_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreenCharacterData_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007EAE RID: 32430
		// (get) Token: 0x0602E08C RID: 188556 RVA: 0x00AD4AA0 File Offset: 0x00AD2CA0
		// (set) Token: 0x0602E08D RID: 188557 RVA: 0x00AD4AB0 File Offset: 0x00AD2CB0
		public unsafe float LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreenCharacterData_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreenCharacterData_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007EAF RID: 32431
		// (get) Token: 0x0602E08E RID: 188558 RVA: 0x00AD4AC1 File Offset: 0x00AD2CC1
		// (set) Token: 0x0602E08F RID: 188559 RVA: 0x00AD4AD1 File Offset: 0x00AD2CD1
		public unsafe float FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitScreenCharacterData_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitScreenCharacterData_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x0602E090 RID: 188560 RVA: 0x00AD4AE2 File Offset: 0x00AD2CE2
		protected BP_SplitScreenCharacterData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401A034 RID: 106548
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Sequence/Common_Seq/Video/SplitScreen/SplitScreenData/BP_SplitScreenCharacterData.BP_SplitScreenCharacterData_C";

		// Token: 0x0401A035 RID: 106549
		private static IntPtr _ClassPtr;

		// Token: 0x0401A036 RID: 106550
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401A037 RID: 106551
		internal static int __PropertyOffset_0;

		// Token: 0x0401A038 RID: 106552
		internal static int __PropertyOffset_1;

		// Token: 0x0401A039 RID: 106553
		internal static int __PropertyOffset_2;

		// Token: 0x0401A03A RID: 106554
		internal static int __PropertyOffset_3;

		// Token: 0x0401A03B RID: 106555
		internal static int __PropertyOffset_4;

		// Token: 0x0401A03C RID: 106556
		internal static int __PropertyOffset_5;

		// Token: 0x0401A03D RID: 106557
		internal static int __PropertyOffset_6;
	}
}
