using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D6C RID: 15724
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/SNpcHookPart.SNpcHookPart")]
	[UnrealStructLayout(96, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 96)]
	public class SNpcHookPart : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060264CE RID: 156878 RVA: 0x009D479F File Offset: 0x009D299F
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SNpcHookPart._ScriptStructPtr != 0) ? SNpcHookPart._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/Npc/SNpcHookPart.SNpcHookPart", ref SNpcHookPart._ScriptStructPtr);
		}

		// Token: 0x17005688 RID: 22152
		// (get) Token: 0x060264CF RID: 156879 RVA: 0x009D47C3 File Offset: 0x009D29C3
		// (set) Token: 0x060264D0 RID: 156880 RVA: 0x009D47D7 File Offset: 0x009D29D7
		[Nullable(2)]
		public unsafe USkeletalMesh Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + SNpcHookPart.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SNpcHookPart.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005689 RID: 22153
		// (get) Token: 0x060264D1 RID: 156881 RVA: 0x009D47EC File Offset: 0x009D29EC
		// (set) Token: 0x060264D2 RID: 156882 RVA: 0x009D4800 File Offset: 0x009D2A00
		public unsafe FTransform Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNpcHookPart.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNpcHookPart.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700568A RID: 22154
		// (get) Token: 0x060264D3 RID: 156883 RVA: 0x009D4818 File Offset: 0x009D2A18
		// (set) Token: 0x060264D4 RID: 156884 RVA: 0x009D485B File Offset: 0x009D2A5B
		public TArray<FMorphTargetPreviewItem> MorphTargets
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FMorphTargetPreviewItem> result;
				if ((result = this._MorphTargets) == null)
				{
					result = (this._MorphTargets = new TArray<FMorphTargetPreviewItem>(base.NativePtr + (IntPtr)SNpcHookPart.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MorphTargets.CopyAssign(value);
			}
		}

		// Token: 0x1700568B RID: 22155
		// (get) Token: 0x060264D5 RID: 156885 RVA: 0x009D486C File Offset: 0x009D2A6C
		// (set) Token: 0x060264D6 RID: 156886 RVA: 0x009D48AF File Offset: 0x009D2AAF
		public TArray<SNpcHookPartMaterial> MaterialInfos
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SNpcHookPartMaterial> result;
				if ((result = this._MaterialInfos) == null)
				{
					result = (this._MaterialInfos = new TArray<SNpcHookPartMaterial>(base.NativePtr + (IntPtr)SNpcHookPart.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MaterialInfos.CopyAssign(value);
			}
		}

		// Token: 0x060264D7 RID: 156887 RVA: 0x009D48BD File Offset: 0x009D2ABD
		public SNpcHookPart()
		{
		}

		// Token: 0x060264D8 RID: 156888 RVA: 0x009D48C5 File Offset: 0x009D2AC5
		public SNpcHookPart(USkeletalMesh Mesh, FTransform Transform, TArray<FMorphTargetPreviewItem> MorphTargets, TArray<SNpcHookPartMaterial> MaterialInfos)
		{
			this.Mesh = Mesh;
			this.Transform = Transform;
			this.MorphTargets = MorphTargets;
			this.MaterialInfos = MaterialInfos;
		}

		// Token: 0x060264D9 RID: 156889 RVA: 0x009D48EA File Offset: 0x009D2AEA
		protected override IntPtr GetUStructPtr()
		{
			return SNpcHookPart.StaticStruct();
		}

		// Token: 0x060264DA RID: 156890 RVA: 0x009D48F6 File Offset: 0x009D2AF6
		[NullableContext(2)]
		public SNpcHookPart(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060264DB RID: 156891 RVA: 0x009D4900 File Offset: 0x009D2B00
		public SNpcHookPart(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060264DC RID: 156892 RVA: 0x009D490B File Offset: 0x009D2B0B
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SNpcHookPart(Pointer, false, true);
		}

		// Token: 0x060264DD RID: 156893 RVA: 0x009D4915 File Offset: 0x009D2B15
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SNpcHookPart(Pointer, MemoryOwner);
		}

		// Token: 0x04013DE6 RID: 81382
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/SNpcHookPart.SNpcHookPart";

		// Token: 0x04013DE7 RID: 81383
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013DE8 RID: 81384
		internal static int __PropertyOffset_0;

		// Token: 0x04013DE9 RID: 81385
		internal static int __PropertyOffset_1;

		// Token: 0x04013DEA RID: 81386
		internal static int __PropertyOffset_2;

		// Token: 0x04013DEB RID: 81387
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FMorphTargetPreviewItem> _MorphTargets;

		// Token: 0x04013DEC RID: 81388
		internal static int __PropertyOffset_3;

		// Token: 0x04013DED RID: 81389
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SNpcHookPartMaterial> _MaterialInfos;
	}
}
