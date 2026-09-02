using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041D0 RID: 16848
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/CharacterData.CharacterData_C")]
	[UnrealStructLayout(120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 116)]
	public class CharacterData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CD09 RID: 183561 RVA: 0x00AB0680 File Offset: 0x00AAE880
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CharacterData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/CharacterData.CharacterData_C");
			}
			return CharacterData_C._ClassPtr;
		}

		// Token: 0x0602CD0A RID: 183562 RVA: 0x00AB06A4 File Offset: 0x00AAE8A4
		public CharacterData_C() : this(BuiltinUtils.AllocNativeUObject(CharacterData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CD0B RID: 183563 RVA: 0x00AB06CC File Offset: 0x00AAE8CC
		public CharacterData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CharacterData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007931 RID: 31025
		// (get) Token: 0x0602CD0C RID: 183564 RVA: 0x00AB06FF File Offset: 0x00AAE8FF
		// (set) Token: 0x0602CD0D RID: 183565 RVA: 0x00AB0713 File Offset: 0x00AAE913
		public unsafe string 名字
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)CharacterData_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)CharacterData_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007932 RID: 31026
		// (get) Token: 0x0602CD0E RID: 183566 RVA: 0x00AB0728 File Offset: 0x00AAE928
		// (set) Token: 0x0602CD0F RID: 183567 RVA: 0x00AB0738 File Offset: 0x00AAE938
		public unsafe int 生命
		{
			get
			{
				return *(base.NativePtr + (IntPtr)CharacterData_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)CharacterData_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007933 RID: 31027
		// (get) Token: 0x0602CD10 RID: 183568 RVA: 0x00AB0749 File Offset: 0x00AAE949
		// (set) Token: 0x0602CD11 RID: 183569 RVA: 0x00AB0759 File Offset: 0x00AAE959
		public unsafe float 攻击力
		{
			get
			{
				return *(base.NativePtr + (IntPtr)CharacterData_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)CharacterData_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007934 RID: 31028
		// (get) Token: 0x0602CD12 RID: 183570 RVA: 0x00AB076A File Offset: 0x00AAE96A
		// (set) Token: 0x0602CD13 RID: 183571 RVA: 0x00AB077A File Offset: 0x00AAE97A
		public unsafe float 防御力
		{
			get
			{
				return *(base.NativePtr + (IntPtr)CharacterData_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)CharacterData_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007935 RID: 31029
		// (get) Token: 0x0602CD14 RID: 183572 RVA: 0x00AB078B File Offset: 0x00AAE98B
		// (set) Token: 0x0602CD15 RID: 183573 RVA: 0x00AB079B File Offset: 0x00AAE99B
		public unsafe float 体力
		{
			get
			{
				return *(base.NativePtr + (IntPtr)CharacterData_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)CharacterData_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007936 RID: 31030
		// (get) Token: 0x0602CD16 RID: 183574 RVA: 0x00AB07AC File Offset: 0x00AAE9AC
		// (set) Token: 0x0602CD17 RID: 183575 RVA: 0x00AB07BC File Offset: 0x00AAE9BC
		public unsafe int npc类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)CharacterData_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)CharacterData_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x0602CD18 RID: 183576 RVA: 0x00AB07CD File Offset: 0x00AAE9CD
		protected CharacterData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018FA9 RID: 102313
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/CharacterData.CharacterData_C";

		// Token: 0x04018FAA RID: 102314
		private static IntPtr _ClassPtr;

		// Token: 0x04018FAB RID: 102315
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018FAC RID: 102316
		internal static int __PropertyOffset_0;

		// Token: 0x04018FAD RID: 102317
		internal static int __PropertyOffset_1;

		// Token: 0x04018FAE RID: 102318
		internal static int __PropertyOffset_2;

		// Token: 0x04018FAF RID: 102319
		internal static int __PropertyOffset_3;

		// Token: 0x04018FB0 RID: 102320
		internal static int __PropertyOffset_4;

		// Token: 0x04018FB1 RID: 102321
		internal static int __PropertyOffset_5;
	}
}
