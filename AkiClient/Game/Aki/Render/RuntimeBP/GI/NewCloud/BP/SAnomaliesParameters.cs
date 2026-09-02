using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CCC RID: 15564
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SAnomaliesParameters.SAnomaliesParameters")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class SAnomaliesParameters : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06025189 RID: 151945 RVA: 0x009B0E24 File Offset: 0x009AF024
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAnomaliesParameters._ScriptStructPtr != 0) ? SAnomaliesParameters._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SAnomaliesParameters.SAnomaliesParameters", ref SAnomaliesParameters._ScriptStructPtr);
		}

		// Token: 0x17004FA7 RID: 20391
		// (get) Token: 0x0602518A RID: 151946 RVA: 0x009B0E48 File Offset: 0x009AF048
		// (set) Token: 0x0602518B RID: 151947 RVA: 0x009B0E5C File Offset: 0x009AF05C
		public unsafe UTexture Color
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + SAnomaliesParameters.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SAnomaliesParameters.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17004FA8 RID: 20392
		// (get) Token: 0x0602518C RID: 151948 RVA: 0x009B0E71 File Offset: 0x009AF071
		// (set) Token: 0x0602518D RID: 151949 RVA: 0x009B0E81 File Offset: 0x009AF081
		public unsafe float CloudAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAnomaliesParameters.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAnomaliesParameters.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17004FA9 RID: 20393
		// (get) Token: 0x0602518E RID: 151950 RVA: 0x009B0E92 File Offset: 0x009AF092
		// (set) Token: 0x0602518F RID: 151951 RVA: 0x009B0EA6 File Offset: 0x009AF0A6
		public unsafe UTexture NoiseMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + SAnomaliesParameters.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SAnomaliesParameters.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004FAA RID: 20394
		// (get) Token: 0x06025190 RID: 151952 RVA: 0x009B0EBB File Offset: 0x009AF0BB
		// (set) Token: 0x06025191 RID: 151953 RVA: 0x009B0ECB File Offset: 0x009AF0CB
		public unsafe float NoiseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAnomaliesParameters.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAnomaliesParameters.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004FAB RID: 20395
		// (get) Token: 0x06025192 RID: 151954 RVA: 0x009B0EDC File Offset: 0x009AF0DC
		// (set) Token: 0x06025193 RID: 151955 RVA: 0x009B0EEC File Offset: 0x009AF0EC
		public unsafe float NoiseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAnomaliesParameters.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAnomaliesParameters.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004FAC RID: 20396
		// (get) Token: 0x06025194 RID: 151956 RVA: 0x009B0EFD File Offset: 0x009AF0FD
		// (set) Token: 0x06025195 RID: 151957 RVA: 0x009B0F0D File Offset: 0x009AF10D
		public unsafe float NoiseTilling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAnomaliesParameters.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAnomaliesParameters.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004FAD RID: 20397
		// (get) Token: 0x06025196 RID: 151958 RVA: 0x009B0F1E File Offset: 0x009AF11E
		// (set) Token: 0x06025197 RID: 151959 RVA: 0x009B0F2E File Offset: 0x009AF12E
		public unsafe float luminance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAnomaliesParameters.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAnomaliesParameters.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004FAE RID: 20398
		// (get) Token: 0x06025198 RID: 151960 RVA: 0x009B0F3F File Offset: 0x009AF13F
		// (set) Token: 0x06025199 RID: 151961 RVA: 0x009B0F4F File Offset: 0x009AF14F
		public unsafe bool Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAnomaliesParameters.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAnomaliesParameters.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004FAF RID: 20399
		// (get) Token: 0x0602519A RID: 151962 RVA: 0x009B0F60 File Offset: 0x009AF160
		// (set) Token: 0x0602519B RID: 151963 RVA: 0x009B0F74 File Offset: 0x009AF174
		public unsafe UStaticMesh Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + SAnomaliesParameters.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SAnomaliesParameters.__PropertyOffset_8, value);
			}
		}

		// Token: 0x0602519C RID: 151964 RVA: 0x009B0F89 File Offset: 0x009AF189
		public SAnomaliesParameters()
		{
		}

		// Token: 0x0602519D RID: 151965 RVA: 0x009B0F94 File Offset: 0x009AF194
		[NullableContext(1)]
		public SAnomaliesParameters(UTexture Color, float CloudAngle, UTexture NoiseMap, float NoiseSpeed, float NoiseStrength, float NoiseTilling, float luminance, bool Rotation, UStaticMesh Mesh)
		{
			this.Color = Color;
			this.CloudAngle = CloudAngle;
			this.NoiseMap = NoiseMap;
			this.NoiseSpeed = NoiseSpeed;
			this.NoiseStrength = NoiseStrength;
			this.NoiseTilling = NoiseTilling;
			this.luminance = luminance;
			this.Rotation = Rotation;
			this.Mesh = Mesh;
		}

		// Token: 0x0602519E RID: 151966 RVA: 0x009B0FEC File Offset: 0x009AF1EC
		protected override IntPtr GetUStructPtr()
		{
			return SAnomaliesParameters.StaticStruct();
		}

		// Token: 0x0602519F RID: 151967 RVA: 0x009B0FF8 File Offset: 0x009AF1F8
		public SAnomaliesParameters(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060251A0 RID: 151968 RVA: 0x009B1002 File Offset: 0x009AF202
		public SAnomaliesParameters(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060251A1 RID: 151969 RVA: 0x009B100D File Offset: 0x009AF20D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAnomaliesParameters(Pointer, false, true);
		}

		// Token: 0x060251A2 RID: 151970 RVA: 0x009B1017 File Offset: 0x009AF217
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAnomaliesParameters(Pointer, MemoryOwner);
		}

		// Token: 0x04013191 RID: 78225
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SAnomaliesParameters.SAnomaliesParameters";

		// Token: 0x04013192 RID: 78226
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013193 RID: 78227
		internal static int __PropertyOffset_0;

		// Token: 0x04013194 RID: 78228
		internal static int __PropertyOffset_1;

		// Token: 0x04013195 RID: 78229
		internal static int __PropertyOffset_2;

		// Token: 0x04013196 RID: 78230
		internal static int __PropertyOffset_3;

		// Token: 0x04013197 RID: 78231
		internal static int __PropertyOffset_4;

		// Token: 0x04013198 RID: 78232
		internal static int __PropertyOffset_5;

		// Token: 0x04013199 RID: 78233
		internal static int __PropertyOffset_6;

		// Token: 0x0401319A RID: 78234
		internal static int __PropertyOffset_7;

		// Token: 0x0401319B RID: 78235
		internal static int __PropertyOffset_8;
	}
}
