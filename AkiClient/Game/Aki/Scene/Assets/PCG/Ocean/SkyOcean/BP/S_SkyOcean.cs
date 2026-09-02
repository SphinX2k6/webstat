using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.Assets.PCG.Ocean.SkyOcean.BP
{
	// Token: 0x020039EC RID: 14828
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Scene/Assets/PCG/Ocean/SkyOcean/BP/S_SkyOcean.S_SkyOcean")]
	[UnrealStructLayout(120, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 120)]
	public class S_SkyOcean : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601E107 RID: 123143 RVA: 0x008EADC0 File Offset: 0x008E8FC0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_SkyOcean._ScriptStructPtr != 0) ? S_SkyOcean._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Scene/Assets/PCG/Ocean/SkyOcean/BP/S_SkyOcean.S_SkyOcean", ref S_SkyOcean._ScriptStructPtr);
		}

		// Token: 0x1700283E RID: 10302
		// (get) Token: 0x0601E108 RID: 123144 RVA: 0x008EADE4 File Offset: 0x008E8FE4
		// (set) Token: 0x0601E109 RID: 123145 RVA: 0x008EADF4 File Offset: 0x008E8FF4
		public unsafe float Angle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700283F RID: 10303
		// (get) Token: 0x0601E10A RID: 123146 RVA: 0x008EAE05 File Offset: 0x008E9005
		// (set) Token: 0x0601E10B RID: 123147 RVA: 0x008EAE19 File Offset: 0x008E9019
		public unsafe FLinearColor WaveUV_Scale_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17002840 RID: 10304
		// (get) Token: 0x0601E10C RID: 123148 RVA: 0x008EAE2E File Offset: 0x008E902E
		// (set) Token: 0x0601E10D RID: 123149 RVA: 0x008EAE3E File Offset: 0x008E903E
		public unsafe float UVScaleFoam
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17002841 RID: 10305
		// (get) Token: 0x0601E10E RID: 123150 RVA: 0x008EAE4F File Offset: 0x008E904F
		// (set) Token: 0x0601E10F RID: 123151 RVA: 0x008EAE63 File Offset: 0x008E9063
		public unsafe FLinearColor FomaTexColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002842 RID: 10306
		// (get) Token: 0x0601E110 RID: 123152 RVA: 0x008EAE78 File Offset: 0x008E9078
		// (set) Token: 0x0601E111 RID: 123153 RVA: 0x008EAE8C File Offset: 0x008E908C
		public unsafe FLinearColor WaterColorTintMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002843 RID: 10307
		// (get) Token: 0x0601E112 RID: 123154 RVA: 0x008EAEA1 File Offset: 0x008E90A1
		// (set) Token: 0x0601E113 RID: 123155 RVA: 0x008EAEB5 File Offset: 0x008E90B5
		public unsafe FLinearColor WaterColorTintMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002844 RID: 10308
		// (get) Token: 0x0601E114 RID: 123156 RVA: 0x008EAECA File Offset: 0x008E90CA
		// (set) Token: 0x0601E115 RID: 123157 RVA: 0x008EAEDE File Offset: 0x008E90DE
		public unsafe FLinearColor WaterColorTintScatter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002845 RID: 10309
		// (get) Token: 0x0601E116 RID: 123158 RVA: 0x008EAEF3 File Offset: 0x008E90F3
		// (set) Token: 0x0601E117 RID: 123159 RVA: 0x008EAF07 File Offset: 0x008E9107
		public unsafe FLinearColor WaterColorWave
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002846 RID: 10310
		// (get) Token: 0x0601E118 RID: 123160 RVA: 0x008EAF1C File Offset: 0x008E911C
		// (set) Token: 0x0601E119 RID: 123161 RVA: 0x008EAF30 File Offset: 0x008E9130
		public unsafe FLinearColor Dis_Vector
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_SkyOcean.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x0601E11A RID: 123162 RVA: 0x008EAF45 File Offset: 0x008E9145
		public S_SkyOcean()
		{
		}

		// Token: 0x0601E11B RID: 123163 RVA: 0x008EAF50 File Offset: 0x008E9150
		public S_SkyOcean(float Angle, FLinearColor WaveUV_Scale_Offset, float UVScaleFoam, FLinearColor FomaTexColor, FLinearColor WaterColorTintMax, FLinearColor WaterColorTintMin, FLinearColor WaterColorTintScatter, FLinearColor WaterColorWave, FLinearColor Dis_Vector)
		{
			this.Angle = Angle;
			this.WaveUV_Scale_Offset = WaveUV_Scale_Offset;
			this.UVScaleFoam = UVScaleFoam;
			this.FomaTexColor = FomaTexColor;
			this.WaterColorTintMax = WaterColorTintMax;
			this.WaterColorTintMin = WaterColorTintMin;
			this.WaterColorTintScatter = WaterColorTintScatter;
			this.WaterColorWave = WaterColorWave;
			this.Dis_Vector = Dis_Vector;
		}

		// Token: 0x0601E11C RID: 123164 RVA: 0x008EAFA8 File Offset: 0x008E91A8
		protected override IntPtr GetUStructPtr()
		{
			return S_SkyOcean.StaticStruct();
		}

		// Token: 0x0601E11D RID: 123165 RVA: 0x008EAFB4 File Offset: 0x008E91B4
		[NullableContext(2)]
		public S_SkyOcean(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E11E RID: 123166 RVA: 0x008EAFBE File Offset: 0x008E91BE
		public S_SkyOcean(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E11F RID: 123167 RVA: 0x008EAFC9 File Offset: 0x008E91C9
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_SkyOcean(Pointer, false, true);
		}

		// Token: 0x0601E120 RID: 123168 RVA: 0x008EAFD3 File Offset: 0x008E91D3
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_SkyOcean(Pointer, MemoryOwner);
		}

		// Token: 0x0400EC15 RID: 60437
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/Assets/PCG/Ocean/SkyOcean/BP/S_SkyOcean.S_SkyOcean";

		// Token: 0x0400EC16 RID: 60438
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400EC17 RID: 60439
		internal static int __PropertyOffset_0;

		// Token: 0x0400EC18 RID: 60440
		internal static int __PropertyOffset_1;

		// Token: 0x0400EC19 RID: 60441
		internal static int __PropertyOffset_2;

		// Token: 0x0400EC1A RID: 60442
		internal static int __PropertyOffset_3;

		// Token: 0x0400EC1B RID: 60443
		internal static int __PropertyOffset_4;

		// Token: 0x0400EC1C RID: 60444
		internal static int __PropertyOffset_5;

		// Token: 0x0400EC1D RID: 60445
		internal static int __PropertyOffset_6;

		// Token: 0x0400EC1E RID: 60446
		internal static int __PropertyOffset_7;

		// Token: 0x0400EC1F RID: 60447
		internal static int __PropertyOffset_8;
	}
}
