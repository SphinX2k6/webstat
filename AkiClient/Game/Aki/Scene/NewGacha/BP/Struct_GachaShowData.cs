using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039E6 RID: 14822
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Scene/NewGacha/BP/Struct_GachaShowData.Struct_GachaShowData")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class Struct_GachaShowData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601E086 RID: 123014 RVA: 0x008EA106 File Offset: 0x008E8306
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (Struct_GachaShowData._ScriptStructPtr != 0) ? Struct_GachaShowData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Scene/NewGacha/BP/Struct_GachaShowData.Struct_GachaShowData", ref Struct_GachaShowData._ScriptStructPtr);
		}

		// Token: 0x17002812 RID: 10258
		// (get) Token: 0x0601E087 RID: 123015 RVA: 0x008EA12A File Offset: 0x008E832A
		// (set) Token: 0x0601E088 RID: 123016 RVA: 0x008EA13A File Offset: 0x008E833A
		public unsafe int ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_GachaShowData.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_GachaShowData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17002813 RID: 10259
		// (get) Token: 0x0601E089 RID: 123017 RVA: 0x008EA14B File Offset: 0x008E834B
		// (set) Token: 0x0601E08A RID: 123018 RVA: 0x008EA15F File Offset: 0x008E835F
		public unsafe UMaterialInterface SkyMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_GachaShowData.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_GachaShowData.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002814 RID: 10260
		// (get) Token: 0x0601E08B RID: 123019 RVA: 0x008EA174 File Offset: 0x008E8374
		// (set) Token: 0x0601E08C RID: 123020 RVA: 0x008EA188 File Offset: 0x008E8388
		public unsafe UMaterialInterface FloorMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_GachaShowData.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_GachaShowData.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002815 RID: 10261
		// (get) Token: 0x0601E08D RID: 123021 RVA: 0x008EA19D File Offset: 0x008E839D
		// (set) Token: 0x0601E08E RID: 123022 RVA: 0x008EA1B1 File Offset: 0x008E83B1
		public unsafe FLinearColor ParticleColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_GachaShowData.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_GachaShowData.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002816 RID: 10262
		// (get) Token: 0x0601E08F RID: 123023 RVA: 0x008EA1C6 File Offset: 0x008E83C6
		// (set) Token: 0x0601E090 RID: 123024 RVA: 0x008EA1DA File Offset: 0x008E83DA
		public unsafe UKuroWeatherDataAsset GachaDataAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_GachaShowData.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_GachaShowData.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002817 RID: 10263
		// (get) Token: 0x0601E091 RID: 123025 RVA: 0x008EA1EF File Offset: 0x008E83EF
		// (set) Token: 0x0601E092 RID: 123026 RVA: 0x008EA203 File Offset: 0x008E8403
		public unsafe FVector FloorScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_GachaShowData.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_GachaShowData.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002818 RID: 10264
		// (get) Token: 0x0601E093 RID: 123027 RVA: 0x008EA218 File Offset: 0x008E8418
		// (set) Token: 0x0601E094 RID: 123028 RVA: 0x008EA22C File Offset: 0x008E842C
		public unsafe FVector SkyScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_GachaShowData.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_GachaShowData.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002819 RID: 10265
		// (get) Token: 0x0601E095 RID: 123029 RVA: 0x008EA241 File Offset: 0x008E8441
		// (set) Token: 0x0601E096 RID: 123030 RVA: 0x008EA251 File Offset: 0x008E8451
		public unsafe bool MeshHidden
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_GachaShowData.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_GachaShowData.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700281A RID: 10266
		// (get) Token: 0x0601E097 RID: 123031 RVA: 0x008EA262 File Offset: 0x008E8462
		// (set) Token: 0x0601E098 RID: 123032 RVA: 0x008EA272 File Offset: 0x008E8472
		public unsafe float MotionBlur
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_GachaShowData.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_GachaShowData.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x0601E099 RID: 123033 RVA: 0x008EA283 File Offset: 0x008E8483
		public Struct_GachaShowData()
		{
		}

		// Token: 0x0601E09A RID: 123034 RVA: 0x008EA28C File Offset: 0x008E848C
		[NullableContext(1)]
		public Struct_GachaShowData(int ID, UMaterialInterface SkyMaterial, UMaterialInterface FloorMaterial, FLinearColor ParticleColor, UKuroWeatherDataAsset GachaDataAsset, FVector FloorScale, FVector SkyScale, bool MeshHidden, float MotionBlur)
		{
			this.ID = ID;
			this.SkyMaterial = SkyMaterial;
			this.FloorMaterial = FloorMaterial;
			this.ParticleColor = ParticleColor;
			this.GachaDataAsset = GachaDataAsset;
			this.FloorScale = FloorScale;
			this.SkyScale = SkyScale;
			this.MeshHidden = MeshHidden;
			this.MotionBlur = MotionBlur;
		}

		// Token: 0x0601E09B RID: 123035 RVA: 0x008EA2E4 File Offset: 0x008E84E4
		protected override IntPtr GetUStructPtr()
		{
			return Struct_GachaShowData.StaticStruct();
		}

		// Token: 0x0601E09C RID: 123036 RVA: 0x008EA2F0 File Offset: 0x008E84F0
		public Struct_GachaShowData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E09D RID: 123037 RVA: 0x008EA2FA File Offset: 0x008E84FA
		public Struct_GachaShowData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E09E RID: 123038 RVA: 0x008EA305 File Offset: 0x008E8505
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new Struct_GachaShowData(Pointer, false, true);
		}

		// Token: 0x0601E09F RID: 123039 RVA: 0x008EA30F File Offset: 0x008E850F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new Struct_GachaShowData(Pointer, MemoryOwner);
		}

		// Token: 0x0400EB9A RID: 60314
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/Struct_GachaShowData.Struct_GachaShowData";

		// Token: 0x0400EB9B RID: 60315
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400EB9C RID: 60316
		internal static int __PropertyOffset_0;

		// Token: 0x0400EB9D RID: 60317
		internal static int __PropertyOffset_1;

		// Token: 0x0400EB9E RID: 60318
		internal static int __PropertyOffset_2;

		// Token: 0x0400EB9F RID: 60319
		internal static int __PropertyOffset_3;

		// Token: 0x0400EBA0 RID: 60320
		internal static int __PropertyOffset_4;

		// Token: 0x0400EBA1 RID: 60321
		internal static int __PropertyOffset_5;

		// Token: 0x0400EBA2 RID: 60322
		internal static int __PropertyOffset_6;

		// Token: 0x0400EBA3 RID: 60323
		internal static int __PropertyOffset_7;

		// Token: 0x0400EBA4 RID: 60324
		internal static int __PropertyOffset_8;
	}
}
