using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D6F RID: 15727
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/SRoleHookPart.SRoleHookPart")]
	[UnrealStructLayout(96, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 96)]
	public class SRoleHookPart : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060264F4 RID: 156916 RVA: 0x009D4AA0 File Offset: 0x009D2CA0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRoleHookPart._ScriptStructPtr != 0) ? SRoleHookPart._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/Npc/SRoleHookPart.SRoleHookPart", ref SRoleHookPart._ScriptStructPtr);
		}

		// Token: 0x1700568F RID: 22159
		// (get) Token: 0x060264F5 RID: 156917 RVA: 0x009D4AC4 File Offset: 0x009D2CC4
		// (set) Token: 0x060264F6 RID: 156918 RVA: 0x009D4AD8 File Offset: 0x009D2CD8
		[Nullable(2)]
		public unsafe USkeletalMesh Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + SRoleHookPart.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SRoleHookPart.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005690 RID: 22160
		// (get) Token: 0x060264F7 RID: 156919 RVA: 0x009D4AED File Offset: 0x009D2CED
		// (set) Token: 0x060264F8 RID: 156920 RVA: 0x009D4B01 File Offset: 0x009D2D01
		public unsafe FTransform Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleHookPart.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleHookPart.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005691 RID: 22161
		// (get) Token: 0x060264F9 RID: 156921 RVA: 0x009D4B18 File Offset: 0x009D2D18
		// (set) Token: 0x060264FA RID: 156922 RVA: 0x009D4B5B File Offset: 0x009D2D5B
		public TArray<FMorphTargetPreviewItem> MorphTargets
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FMorphTargetPreviewItem> result;
				if ((result = this._MorphTargets) == null)
				{
					result = (this._MorphTargets = new TArray<FMorphTargetPreviewItem>(base.NativePtr + (IntPtr)SRoleHookPart.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MorphTargets.CopyAssign(value);
			}
		}

		// Token: 0x17005692 RID: 22162
		// (get) Token: 0x060264FB RID: 156923 RVA: 0x009D4B6C File Offset: 0x009D2D6C
		// (set) Token: 0x060264FC RID: 156924 RVA: 0x009D4BAF File Offset: 0x009D2DAF
		public TArray<SNpcHookPartMaterial> MaterialInfos
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SNpcHookPartMaterial> result;
				if ((result = this._MaterialInfos) == null)
				{
					result = (this._MaterialInfos = new TArray<SNpcHookPartMaterial>(base.NativePtr + (IntPtr)SRoleHookPart.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MaterialInfos.CopyAssign(value);
			}
		}

		// Token: 0x060264FD RID: 156925 RVA: 0x009D4BBD File Offset: 0x009D2DBD
		public SRoleHookPart()
		{
		}

		// Token: 0x060264FE RID: 156926 RVA: 0x009D4BC5 File Offset: 0x009D2DC5
		public SRoleHookPart(USkeletalMesh Mesh, FTransform Transform, TArray<FMorphTargetPreviewItem> MorphTargets, TArray<SNpcHookPartMaterial> MaterialInfos)
		{
			this.Mesh = Mesh;
			this.Transform = Transform;
			this.MorphTargets = MorphTargets;
			this.MaterialInfos = MaterialInfos;
		}

		// Token: 0x060264FF RID: 156927 RVA: 0x009D4BEA File Offset: 0x009D2DEA
		protected override IntPtr GetUStructPtr()
		{
			return SRoleHookPart.StaticStruct();
		}

		// Token: 0x06026500 RID: 156928 RVA: 0x009D4BF6 File Offset: 0x009D2DF6
		[NullableContext(2)]
		public SRoleHookPart(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026501 RID: 156929 RVA: 0x009D4C00 File Offset: 0x009D2E00
		public SRoleHookPart(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026502 RID: 156930 RVA: 0x009D4C0B File Offset: 0x009D2E0B
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SRoleHookPart(Pointer, false, true);
		}

		// Token: 0x06026503 RID: 156931 RVA: 0x009D4C15 File Offset: 0x009D2E15
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SRoleHookPart(Pointer, MemoryOwner);
		}

		// Token: 0x04013DF6 RID: 81398
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/SRoleHookPart.SRoleHookPart";

		// Token: 0x04013DF7 RID: 81399
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013DF8 RID: 81400
		internal static int __PropertyOffset_0;

		// Token: 0x04013DF9 RID: 81401
		internal static int __PropertyOffset_1;

		// Token: 0x04013DFA RID: 81402
		internal static int __PropertyOffset_2;

		// Token: 0x04013DFB RID: 81403
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FMorphTargetPreviewItem> _MorphTargets;

		// Token: 0x04013DFC RID: 81404
		internal static int __PropertyOffset_3;

		// Token: 0x04013DFD RID: 81405
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SNpcHookPartMaterial> _MaterialInfos;
	}
}
