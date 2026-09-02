using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CCE RID: 15566
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SCloudParameters.SCloudParameters")]
	[UnrealStructLayout(200, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 200)]
	public class SCloudParameters : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060251AD RID: 151981 RVA: 0x009B10B8 File Offset: 0x009AF2B8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCloudParameters._ScriptStructPtr != 0) ? SCloudParameters._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SCloudParameters.SCloudParameters", ref SCloudParameters._ScriptStructPtr);
		}

		// Token: 0x17004FB1 RID: 20401
		// (get) Token: 0x060251AE RID: 151982 RVA: 0x009B10DC File Offset: 0x009AF2DC
		// (set) Token: 0x060251AF RID: 151983 RVA: 0x009B10F0 File Offset: 0x009AF2F0
		public unsafe UTexture Mask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + SCloudParameters.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SCloudParameters.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17004FB2 RID: 20402
		// (get) Token: 0x060251B0 RID: 151984 RVA: 0x009B1105 File Offset: 0x009AF305
		// (set) Token: 0x060251B1 RID: 151985 RVA: 0x009B1115 File Offset: 0x009AF315
		public unsafe bool YesUV1NoUV2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004FB3 RID: 20403
		// (get) Token: 0x060251B2 RID: 151986 RVA: 0x009B1126 File Offset: 0x009AF326
		// (set) Token: 0x060251B3 RID: 151987 RVA: 0x009B1136 File Offset: 0x009AF336
		public unsafe int UVTiling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004FB4 RID: 20404
		// (get) Token: 0x060251B4 RID: 151988 RVA: 0x009B1147 File Offset: 0x009AF347
		// (set) Token: 0x060251B5 RID: 151989 RVA: 0x009B1157 File Offset: 0x009AF357
		public unsafe float CloudAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004FB5 RID: 20405
		// (get) Token: 0x060251B6 RID: 151990 RVA: 0x009B1168 File Offset: 0x009AF368
		// (set) Token: 0x060251B7 RID: 151991 RVA: 0x009B1178 File Offset: 0x009AF378
		public unsafe float CloudSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004FB6 RID: 20406
		// (get) Token: 0x060251B8 RID: 151992 RVA: 0x009B1189 File Offset: 0x009AF389
		// (set) Token: 0x060251B9 RID: 151993 RVA: 0x009B1199 File Offset: 0x009AF399
		public unsafe bool CloudRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004FB7 RID: 20407
		// (get) Token: 0x060251BA RID: 151994 RVA: 0x009B11AA File Offset: 0x009AF3AA
		// (set) Token: 0x060251BB RID: 151995 RVA: 0x009B11BE File Offset: 0x009AF3BE
		public unsafe UTexture NoiseMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + SCloudParameters.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SCloudParameters.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004FB8 RID: 20408
		// (get) Token: 0x060251BC RID: 151996 RVA: 0x009B11D3 File Offset: 0x009AF3D3
		// (set) Token: 0x060251BD RID: 151997 RVA: 0x009B11E3 File Offset: 0x009AF3E3
		public unsafe float NoiseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004FB9 RID: 20409
		// (get) Token: 0x060251BE RID: 151998 RVA: 0x009B11F4 File Offset: 0x009AF3F4
		// (set) Token: 0x060251BF RID: 151999 RVA: 0x009B1204 File Offset: 0x009AF404
		public unsafe float NoiseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004FBA RID: 20410
		// (get) Token: 0x060251C0 RID: 152000 RVA: 0x009B1215 File Offset: 0x009AF415
		// (set) Token: 0x060251C1 RID: 152001 RVA: 0x009B1225 File Offset: 0x009AF425
		public unsafe float NoiseTilling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004FBB RID: 20411
		// (get) Token: 0x060251C2 RID: 152002 RVA: 0x009B1236 File Offset: 0x009AF436
		// (set) Token: 0x060251C3 RID: 152003 RVA: 0x009B1246 File Offset: 0x009AF446
		public unsafe bool SDF_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004FBC RID: 20412
		// (get) Token: 0x060251C4 RID: 152004 RVA: 0x009B1258 File Offset: 0x009AF458
		// (set) Token: 0x060251C5 RID: 152005 RVA: 0x009B129B File Offset: 0x009AF49B
		[Nullable(1)]
		public FKuroCurveFloat SDFTime
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._SDFTime) == null)
				{
					result = (this._SDFTime = new FKuroCurveFloat(base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_11, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)SCloudParameters.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060251C6 RID: 152006 RVA: 0x009B12BC File Offset: 0x009AF4BC
		public SCloudParameters()
		{
		}

		// Token: 0x060251C7 RID: 152007 RVA: 0x009B12C4 File Offset: 0x009AF4C4
		[NullableContext(1)]
		public SCloudParameters(UTexture Mask, bool YesUV1NoUV2, int UVTiling, float CloudAngle, float CloudSpeed, bool CloudRotation, UTexture NoiseMap, float NoiseSpeed, float NoiseStrength, float NoiseTilling, bool SDF_, FKuroCurveFloat SDFTime)
		{
			this.Mask = Mask;
			this.YesUV1NoUV2 = YesUV1NoUV2;
			this.UVTiling = UVTiling;
			this.CloudAngle = CloudAngle;
			this.CloudSpeed = CloudSpeed;
			this.CloudRotation = CloudRotation;
			this.NoiseMap = NoiseMap;
			this.NoiseSpeed = NoiseSpeed;
			this.NoiseStrength = NoiseStrength;
			this.NoiseTilling = NoiseTilling;
			this.SDF_ = SDF_;
			this.SDFTime = SDFTime;
		}

		// Token: 0x060251C8 RID: 152008 RVA: 0x009B1334 File Offset: 0x009AF534
		protected override IntPtr GetUStructPtr()
		{
			return SCloudParameters.StaticStruct();
		}

		// Token: 0x060251C9 RID: 152009 RVA: 0x009B1340 File Offset: 0x009AF540
		public SCloudParameters(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060251CA RID: 152010 RVA: 0x009B134A File Offset: 0x009AF54A
		public SCloudParameters(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060251CB RID: 152011 RVA: 0x009B1355 File Offset: 0x009AF555
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCloudParameters(Pointer, false, true);
		}

		// Token: 0x060251CC RID: 152012 RVA: 0x009B135F File Offset: 0x009AF55F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCloudParameters(Pointer, MemoryOwner);
		}

		// Token: 0x0401319F RID: 78239
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SCloudParameters.SCloudParameters";

		// Token: 0x040131A0 RID: 78240
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040131A1 RID: 78241
		internal static int __PropertyOffset_0;

		// Token: 0x040131A2 RID: 78242
		internal static int __PropertyOffset_1;

		// Token: 0x040131A3 RID: 78243
		internal static int __PropertyOffset_2;

		// Token: 0x040131A4 RID: 78244
		internal static int __PropertyOffset_3;

		// Token: 0x040131A5 RID: 78245
		internal static int __PropertyOffset_4;

		// Token: 0x040131A6 RID: 78246
		internal static int __PropertyOffset_5;

		// Token: 0x040131A7 RID: 78247
		internal static int __PropertyOffset_6;

		// Token: 0x040131A8 RID: 78248
		internal static int __PropertyOffset_7;

		// Token: 0x040131A9 RID: 78249
		internal static int __PropertyOffset_8;

		// Token: 0x040131AA RID: 78250
		internal static int __PropertyOffset_9;

		// Token: 0x040131AB RID: 78251
		internal static int __PropertyOffset_10;

		// Token: 0x040131AC RID: 78252
		internal static int __PropertyOffset_11;

		// Token: 0x040131AD RID: 78253
		private FKuroCurveFloat _SDFTime;
	}
}
