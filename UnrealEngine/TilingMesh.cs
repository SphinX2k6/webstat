using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace UnrealEngine
{
	// Token: 0x020043E2 RID: 17378
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Engine/ArtTools/RenderToTexture/Blueprints/TilingMesh.TilingMesh")]
	[UnrealStructLayout(96, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 88)]
	public class TilingMesh : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E295 RID: 189077 RVA: 0x00ADAF9E File Offset: 0x00AD919E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (TilingMesh._ScriptStructPtr != 0) ? TilingMesh._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Engine/ArtTools/RenderToTexture/Blueprints/TilingMesh.TilingMesh", ref TilingMesh._ScriptStructPtr);
		}

		// Token: 0x17007F13 RID: 32531
		// (get) Token: 0x0602E296 RID: 189078 RVA: 0x00ADAFC2 File Offset: 0x00AD91C2
		// (set) Token: 0x0602E297 RID: 189079 RVA: 0x00ADAFD6 File Offset: 0x00AD91D6
		public unsafe UStaticMesh StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + TilingMesh.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TilingMesh.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007F14 RID: 32532
		// (get) Token: 0x0602E298 RID: 189080 RVA: 0x00ADAFEB File Offset: 0x00AD91EB
		// (set) Token: 0x0602E299 RID: 189081 RVA: 0x00ADAFFF File Offset: 0x00AD91FF
		public unsafe FTransform Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TilingMesh.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TilingMesh.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007F15 RID: 32533
		// (get) Token: 0x0602E29A RID: 189082 RVA: 0x00ADB014 File Offset: 0x00AD9214
		// (set) Token: 0x0602E29B RID: 189083 RVA: 0x00ADB028 File Offset: 0x00AD9228
		public unsafe UMaterialInstanceConstant Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + TilingMesh.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TilingMesh.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007F16 RID: 32534
		// (get) Token: 0x0602E29C RID: 189084 RVA: 0x00ADB03D File Offset: 0x00AD923D
		// (set) Token: 0x0602E29D RID: 189085 RVA: 0x00ADB04D File Offset: 0x00AD924D
		public unsafe bool Visible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TilingMesh.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)TilingMesh.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007F17 RID: 32535
		// (get) Token: 0x0602E29E RID: 189086 RVA: 0x00ADB05E File Offset: 0x00AD925E
		// (set) Token: 0x0602E29F RID: 189087 RVA: 0x00ADB072 File Offset: 0x00AD9272
		public unsafe UTexture DisplacementTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + TilingMesh.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TilingMesh.__PropertyOffset_4, value);
			}
		}

		// Token: 0x0602E2A0 RID: 189088 RVA: 0x00ADB087 File Offset: 0x00AD9287
		public TilingMesh()
		{
		}

		// Token: 0x0602E2A1 RID: 189089 RVA: 0x00ADB08F File Offset: 0x00AD928F
		[NullableContext(1)]
		public TilingMesh(UStaticMesh StaticMesh, FTransform Transform, UMaterialInstanceConstant Material, bool Visible, UTexture DisplacementTexture)
		{
			this.StaticMesh = StaticMesh;
			this.Transform = Transform;
			this.Material = Material;
			this.Visible = Visible;
			this.DisplacementTexture = DisplacementTexture;
		}

		// Token: 0x0602E2A2 RID: 189090 RVA: 0x00ADB0BC File Offset: 0x00AD92BC
		protected override IntPtr GetUStructPtr()
		{
			return TilingMesh.StaticStruct();
		}

		// Token: 0x0602E2A3 RID: 189091 RVA: 0x00ADB0C8 File Offset: 0x00AD92C8
		public TilingMesh(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E2A4 RID: 189092 RVA: 0x00ADB0D2 File Offset: 0x00AD92D2
		public TilingMesh(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E2A5 RID: 189093 RVA: 0x00ADB0DD File Offset: 0x00AD92DD
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new TilingMesh(Pointer, false, true);
		}

		// Token: 0x0602E2A6 RID: 189094 RVA: 0x00ADB0E7 File Offset: 0x00AD92E7
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new TilingMesh(Pointer, MemoryOwner);
		}

		// Token: 0x0401A1C2 RID: 106946
		[Nullable(1)]
		public const string __ObjectPath = "/Engine/ArtTools/RenderToTexture/Blueprints/TilingMesh.TilingMesh";

		// Token: 0x0401A1C3 RID: 106947
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A1C4 RID: 106948
		internal static int __PropertyOffset_0;

		// Token: 0x0401A1C5 RID: 106949
		internal static int __PropertyOffset_1;

		// Token: 0x0401A1C6 RID: 106950
		internal static int __PropertyOffset_2;

		// Token: 0x0401A1C7 RID: 106951
		internal static int __PropertyOffset_3;

		// Token: 0x0401A1C8 RID: 106952
		internal static int __PropertyOffset_4;
	}
}
