using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.HeightMap
{
	// Token: 0x02003C8E RID: 15502
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/HeightMap/PDA_HeightMapBakeConfig.PDA_HeightMapBakeConfig_C")]
	[UnrealStructLayout(120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 120)]
	public class PDA_HeightMapBakeConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060242A0 RID: 148128 RVA: 0x0099661F File Offset: 0x0099481F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_HeightMapBakeConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/HeightMap/PDA_HeightMapBakeConfig.PDA_HeightMapBakeConfig_C");
			}
			return PDA_HeightMapBakeConfig_C._ClassPtr;
		}

		// Token: 0x060242A1 RID: 148129 RVA: 0x00996644 File Offset: 0x00994844
		public PDA_HeightMapBakeConfig_C() : this(BuiltinUtils.AllocNativeUObject(PDA_HeightMapBakeConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060242A2 RID: 148130 RVA: 0x0099666C File Offset: 0x0099486C
		public PDA_HeightMapBakeConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_HeightMapBakeConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004A6B RID: 19051
		// (get) Token: 0x060242A3 RID: 148131 RVA: 0x0099669F File Offset: 0x0099489F
		// (set) Token: 0x060242A4 RID: 148132 RVA: 0x009966B3 File Offset: 0x009948B3
		public unsafe string Path
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)PDA_HeightMapBakeConfig_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)PDA_HeightMapBakeConfig_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17004A6C RID: 19052
		// (get) Token: 0x060242A5 RID: 148133 RVA: 0x009966C8 File Offset: 0x009948C8
		// (set) Token: 0x060242A6 RID: 148134 RVA: 0x009966D8 File Offset: 0x009948D8
		public unsafe float CellLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_HeightMapBakeConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_HeightMapBakeConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17004A6D RID: 19053
		// (get) Token: 0x060242A7 RID: 148135 RVA: 0x009966E9 File Offset: 0x009948E9
		// (set) Token: 0x060242A8 RID: 148136 RVA: 0x009966F9 File Offset: 0x009948F9
		public unsafe float ShotHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_HeightMapBakeConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_HeightMapBakeConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004A6E RID: 19054
		// (get) Token: 0x060242A9 RID: 148137 RVA: 0x0099670A File Offset: 0x0099490A
		// (set) Token: 0x060242AA RID: 148138 RVA: 0x0099671A File Offset: 0x0099491A
		public unsafe int HalfSideCellNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_HeightMapBakeConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_HeightMapBakeConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004A6F RID: 19055
		// (get) Token: 0x060242AB RID: 148139 RVA: 0x0099672B File Offset: 0x0099492B
		// (set) Token: 0x060242AC RID: 148140 RVA: 0x0099673B File Offset: 0x0099493B
		public unsafe float TextureSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_HeightMapBakeConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_HeightMapBakeConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004A70 RID: 19056
		// (get) Token: 0x060242AD RID: 148141 RVA: 0x0099674C File Offset: 0x0099494C
		// (set) Token: 0x060242AE RID: 148142 RVA: 0x00996760 File Offset: 0x00994960
		[Nullable(2)]
		public unsafe UKuroHeightMapSettings HeightMapSettings
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroHeightMapSettings>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_HeightMapBakeConfig_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_HeightMapBakeConfig_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x060242AF RID: 148143 RVA: 0x00996775 File Offset: 0x00994975
		protected PDA_HeightMapBakeConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040127F1 RID: 75761
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/HeightMap/PDA_HeightMapBakeConfig.PDA_HeightMapBakeConfig_C";

		// Token: 0x040127F2 RID: 75762
		private static IntPtr _ClassPtr;

		// Token: 0x040127F3 RID: 75763
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040127F4 RID: 75764
		internal static int __PropertyOffset_0;

		// Token: 0x040127F5 RID: 75765
		internal static int __PropertyOffset_1;

		// Token: 0x040127F6 RID: 75766
		internal static int __PropertyOffset_2;

		// Token: 0x040127F7 RID: 75767
		internal static int __PropertyOffset_3;

		// Token: 0x040127F8 RID: 75768
		internal static int __PropertyOffset_4;

		// Token: 0x040127F9 RID: 75769
		internal static int __PropertyOffset_5;
	}
}
