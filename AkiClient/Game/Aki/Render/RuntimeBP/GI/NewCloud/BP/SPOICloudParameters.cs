using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CD1 RID: 15569
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SPOICloudParameters.SPOICloudParameters")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 65)]
	public class SPOICloudParameters : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060251DE RID: 152030 RVA: 0x009B1482 File Offset: 0x009AF682
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPOICloudParameters._ScriptStructPtr != 0) ? SPOICloudParameters._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SPOICloudParameters.SPOICloudParameters", ref SPOICloudParameters._ScriptStructPtr);
		}

		// Token: 0x17004FBE RID: 20414
		// (get) Token: 0x060251DF RID: 152031 RVA: 0x009B14A6 File Offset: 0x009AF6A6
		// (set) Token: 0x060251E0 RID: 152032 RVA: 0x009B14BA File Offset: 0x009AF6BA
		public unsafe UTexture Mask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + SPOICloudParameters.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SPOICloudParameters.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17004FBF RID: 20415
		// (get) Token: 0x060251E1 RID: 152033 RVA: 0x009B14CF File Offset: 0x009AF6CF
		// (set) Token: 0x060251E2 RID: 152034 RVA: 0x009B14DF File Offset: 0x009AF6DF
		public unsafe bool YesUV1NoUV2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004FC0 RID: 20416
		// (get) Token: 0x060251E3 RID: 152035 RVA: 0x009B14F0 File Offset: 0x009AF6F0
		// (set) Token: 0x060251E4 RID: 152036 RVA: 0x009B1500 File Offset: 0x009AF700
		public unsafe int UVTiling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004FC1 RID: 20417
		// (get) Token: 0x060251E5 RID: 152037 RVA: 0x009B1511 File Offset: 0x009AF711
		// (set) Token: 0x060251E6 RID: 152038 RVA: 0x009B1521 File Offset: 0x009AF721
		public unsafe float CloudAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004FC2 RID: 20418
		// (get) Token: 0x060251E7 RID: 152039 RVA: 0x009B1532 File Offset: 0x009AF732
		// (set) Token: 0x060251E8 RID: 152040 RVA: 0x009B1542 File Offset: 0x009AF742
		public unsafe float CloudSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004FC3 RID: 20419
		// (get) Token: 0x060251E9 RID: 152041 RVA: 0x009B1553 File Offset: 0x009AF753
		// (set) Token: 0x060251EA RID: 152042 RVA: 0x009B1563 File Offset: 0x009AF763
		public unsafe bool CloudRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004FC4 RID: 20420
		// (get) Token: 0x060251EB RID: 152043 RVA: 0x009B1574 File Offset: 0x009AF774
		// (set) Token: 0x060251EC RID: 152044 RVA: 0x009B1588 File Offset: 0x009AF788
		public unsafe UTexture NoiseMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + SPOICloudParameters.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SPOICloudParameters.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004FC5 RID: 20421
		// (get) Token: 0x060251ED RID: 152045 RVA: 0x009B159D File Offset: 0x009AF79D
		// (set) Token: 0x060251EE RID: 152046 RVA: 0x009B15AD File Offset: 0x009AF7AD
		public unsafe float NoiseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004FC6 RID: 20422
		// (get) Token: 0x060251EF RID: 152047 RVA: 0x009B15BE File Offset: 0x009AF7BE
		// (set) Token: 0x060251F0 RID: 152048 RVA: 0x009B15CE File Offset: 0x009AF7CE
		public unsafe float NoiseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004FC7 RID: 20423
		// (get) Token: 0x060251F1 RID: 152049 RVA: 0x009B15DF File Offset: 0x009AF7DF
		// (set) Token: 0x060251F2 RID: 152050 RVA: 0x009B15EF File Offset: 0x009AF7EF
		public unsafe float NoiseTilling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004FC8 RID: 20424
		// (get) Token: 0x060251F3 RID: 152051 RVA: 0x009B1600 File Offset: 0x009AF800
		// (set) Token: 0x060251F4 RID: 152052 RVA: 0x009B1614 File Offset: 0x009AF814
		public unsafe UStaticMesh Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + SPOICloudParameters.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SPOICloudParameters.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004FC9 RID: 20425
		// (get) Token: 0x060251F5 RID: 152053 RVA: 0x009B1629 File Offset: 0x009AF829
		// (set) Token: 0x060251F6 RID: 152054 RVA: 0x009B1639 File Offset: 0x009AF839
		public unsafe bool SDF_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPOICloudParameters.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x060251F7 RID: 152055 RVA: 0x009B164A File Offset: 0x009AF84A
		public SPOICloudParameters()
		{
		}

		// Token: 0x060251F8 RID: 152056 RVA: 0x009B1654 File Offset: 0x009AF854
		[NullableContext(1)]
		public SPOICloudParameters(UTexture Mask, bool YesUV1NoUV2, int UVTiling, float CloudAngle, float CloudSpeed, bool CloudRotation, UTexture NoiseMap, float NoiseSpeed, float NoiseStrength, float NoiseTilling, UStaticMesh Mesh, bool SDF_)
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
			this.Mesh = Mesh;
			this.SDF_ = SDF_;
		}

		// Token: 0x060251F9 RID: 152057 RVA: 0x009B16C4 File Offset: 0x009AF8C4
		protected override IntPtr GetUStructPtr()
		{
			return SPOICloudParameters.StaticStruct();
		}

		// Token: 0x060251FA RID: 152058 RVA: 0x009B16D0 File Offset: 0x009AF8D0
		public SPOICloudParameters(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060251FB RID: 152059 RVA: 0x009B16DA File Offset: 0x009AF8DA
		public SPOICloudParameters(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060251FC RID: 152060 RVA: 0x009B16E5 File Offset: 0x009AF8E5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPOICloudParameters(Pointer, false, true);
		}

		// Token: 0x060251FD RID: 152061 RVA: 0x009B16EF File Offset: 0x009AF8EF
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPOICloudParameters(Pointer, MemoryOwner);
		}

		// Token: 0x040131B4 RID: 78260
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SPOICloudParameters.SPOICloudParameters";

		// Token: 0x040131B5 RID: 78261
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040131B6 RID: 78262
		internal static int __PropertyOffset_0;

		// Token: 0x040131B7 RID: 78263
		internal static int __PropertyOffset_1;

		// Token: 0x040131B8 RID: 78264
		internal static int __PropertyOffset_2;

		// Token: 0x040131B9 RID: 78265
		internal static int __PropertyOffset_3;

		// Token: 0x040131BA RID: 78266
		internal static int __PropertyOffset_4;

		// Token: 0x040131BB RID: 78267
		internal static int __PropertyOffset_5;

		// Token: 0x040131BC RID: 78268
		internal static int __PropertyOffset_6;

		// Token: 0x040131BD RID: 78269
		internal static int __PropertyOffset_7;

		// Token: 0x040131BE RID: 78270
		internal static int __PropertyOffset_8;

		// Token: 0x040131BF RID: 78271
		internal static int __PropertyOffset_9;

		// Token: 0x040131C0 RID: 78272
		internal static int __PropertyOffset_10;

		// Token: 0x040131C1 RID: 78273
		internal static int __PropertyOffset_11;
	}
}
