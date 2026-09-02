using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D6B RID: 15723
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/SNpcChildPart.SNpcChildPart")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SNpcChildPart : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060264C2 RID: 156866 RVA: 0x009D46AC File Offset: 0x009D28AC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SNpcChildPart._ScriptStructPtr != 0) ? SNpcChildPart._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/Npc/SNpcChildPart.SNpcChildPart", ref SNpcChildPart._ScriptStructPtr);
		}

		// Token: 0x17005686 RID: 22150
		// (get) Token: 0x060264C3 RID: 156867 RVA: 0x009D46D0 File Offset: 0x009D28D0
		// (set) Token: 0x060264C4 RID: 156868 RVA: 0x009D46E4 File Offset: 0x009D28E4
		[Nullable(2)]
		public unsafe USkeletalMesh Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + SNpcChildPart.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SNpcChildPart.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005687 RID: 22151
		// (get) Token: 0x060264C5 RID: 156869 RVA: 0x009D46FC File Offset: 0x009D28FC
		// (set) Token: 0x060264C6 RID: 156870 RVA: 0x009D473F File Offset: 0x009D293F
		public TArray<SNpcHookPartMaterial> MaterialInfos
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SNpcHookPartMaterial> result;
				if ((result = this._MaterialInfos) == null)
				{
					result = (this._MaterialInfos = new TArray<SNpcHookPartMaterial>(base.NativePtr + (IntPtr)SNpcChildPart.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MaterialInfos.CopyAssign(value);
			}
		}

		// Token: 0x060264C7 RID: 156871 RVA: 0x009D474D File Offset: 0x009D294D
		public SNpcChildPart()
		{
		}

		// Token: 0x060264C8 RID: 156872 RVA: 0x009D4755 File Offset: 0x009D2955
		public SNpcChildPart(USkeletalMesh Mesh, TArray<SNpcHookPartMaterial> MaterialInfos)
		{
			this.Mesh = Mesh;
			this.MaterialInfos = MaterialInfos;
		}

		// Token: 0x060264C9 RID: 156873 RVA: 0x009D476B File Offset: 0x009D296B
		protected override IntPtr GetUStructPtr()
		{
			return SNpcChildPart.StaticStruct();
		}

		// Token: 0x060264CA RID: 156874 RVA: 0x009D4777 File Offset: 0x009D2977
		[NullableContext(2)]
		public SNpcChildPart(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060264CB RID: 156875 RVA: 0x009D4781 File Offset: 0x009D2981
		public SNpcChildPart(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060264CC RID: 156876 RVA: 0x009D478C File Offset: 0x009D298C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SNpcChildPart(Pointer, false, true);
		}

		// Token: 0x060264CD RID: 156877 RVA: 0x009D4796 File Offset: 0x009D2996
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SNpcChildPart(Pointer, MemoryOwner);
		}

		// Token: 0x04013DE1 RID: 81377
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/SNpcChildPart.SNpcChildPart";

		// Token: 0x04013DE2 RID: 81378
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013DE3 RID: 81379
		internal static int __PropertyOffset_0;

		// Token: 0x04013DE4 RID: 81380
		internal static int __PropertyOffset_1;

		// Token: 0x04013DE5 RID: 81381
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SNpcHookPartMaterial> _MaterialInfos;
	}
}
