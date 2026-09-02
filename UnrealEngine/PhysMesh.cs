using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace UnrealEngine
{
	// Token: 0x020043E1 RID: 17377
	[UnrealObjectPath("/Engine/ArtTools/RenderToTexture/Blueprints/PhysMesh.PhysMesh")]
	[UnrealStructLayout(64, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class PhysMesh : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E289 RID: 189065 RVA: 0x00ADAED6 File Offset: 0x00AD90D6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (PhysMesh._ScriptStructPtr != 0) ? PhysMesh._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Engine/ArtTools/RenderToTexture/Blueprints/PhysMesh.PhysMesh", ref PhysMesh._ScriptStructPtr);
		}

		// Token: 0x17007F11 RID: 32529
		// (get) Token: 0x0602E28A RID: 189066 RVA: 0x00ADAEFA File Offset: 0x00AD90FA
		// (set) Token: 0x0602E28B RID: 189067 RVA: 0x00ADAF0E File Offset: 0x00AD910E
		[Nullable(2)]
		public unsafe UStaticMesh SMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PhysMesh.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PhysMesh.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007F12 RID: 32530
		// (get) Token: 0x0602E28C RID: 189068 RVA: 0x00ADAF23 File Offset: 0x00AD9123
		// (set) Token: 0x0602E28D RID: 189069 RVA: 0x00ADAF37 File Offset: 0x00AD9137
		public unsafe FTransform Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PhysMesh.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PhysMesh.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602E28E RID: 189070 RVA: 0x00ADAF4C File Offset: 0x00AD914C
		public PhysMesh()
		{
		}

		// Token: 0x0602E28F RID: 189071 RVA: 0x00ADAF54 File Offset: 0x00AD9154
		[NullableContext(1)]
		public PhysMesh(UStaticMesh SMesh, FTransform Transform)
		{
			this.SMesh = SMesh;
			this.Transform = Transform;
		}

		// Token: 0x0602E290 RID: 189072 RVA: 0x00ADAF6A File Offset: 0x00AD916A
		protected override IntPtr GetUStructPtr()
		{
			return PhysMesh.StaticStruct();
		}

		// Token: 0x0602E291 RID: 189073 RVA: 0x00ADAF76 File Offset: 0x00AD9176
		[NullableContext(2)]
		public PhysMesh(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E292 RID: 189074 RVA: 0x00ADAF80 File Offset: 0x00AD9180
		public PhysMesh(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E293 RID: 189075 RVA: 0x00ADAF8B File Offset: 0x00AD918B
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new PhysMesh(Pointer, false, true);
		}

		// Token: 0x0602E294 RID: 189076 RVA: 0x00ADAF95 File Offset: 0x00AD9195
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new PhysMesh(Pointer, MemoryOwner);
		}

		// Token: 0x0401A1BE RID: 106942
		[Nullable(1)]
		public const string __ObjectPath = "/Engine/ArtTools/RenderToTexture/Blueprints/PhysMesh.PhysMesh";

		// Token: 0x0401A1BF RID: 106943
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A1C0 RID: 106944
		internal static int __PropertyOffset_0;

		// Token: 0x0401A1C1 RID: 106945
		internal static int __PropertyOffset_1;
	}
}
