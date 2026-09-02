using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D71 RID: 15729
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/SRoleOtherCasePart.SRoleOtherCasePart")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SRoleOtherCasePart : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026510 RID: 156944 RVA: 0x009D4CDE File Offset: 0x009D2EDE
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRoleOtherCasePart._ScriptStructPtr != 0) ? SRoleOtherCasePart._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/Npc/SRoleOtherCasePart.SRoleOtherCasePart", ref SRoleOtherCasePart._ScriptStructPtr);
		}

		// Token: 0x17005695 RID: 22165
		// (get) Token: 0x06026511 RID: 156945 RVA: 0x009D4D02 File Offset: 0x009D2F02
		// (set) Token: 0x06026512 RID: 156946 RVA: 0x009D4D16 File Offset: 0x009D2F16
		[Nullable(2)]
		public unsafe USkeletalMesh OtherCaseSkeletalMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + SRoleOtherCasePart.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SRoleOtherCasePart.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005696 RID: 22166
		// (get) Token: 0x06026513 RID: 156947 RVA: 0x009D4D2B File Offset: 0x009D2F2B
		// (set) Token: 0x06026514 RID: 156948 RVA: 0x009D4D3B File Offset: 0x009D2F3B
		public unsafe bool Vis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleOtherCasePart.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleOtherCasePart.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005697 RID: 22167
		// (get) Token: 0x06026515 RID: 156949 RVA: 0x009D4D4C File Offset: 0x009D2F4C
		// (set) Token: 0x06026516 RID: 156950 RVA: 0x009D4D60 File Offset: 0x009D2F60
		public unsafe FName ParentTransformName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleOtherCasePart.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleOtherCasePart.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x06026517 RID: 156951 RVA: 0x009D4D75 File Offset: 0x009D2F75
		public SRoleOtherCasePart()
		{
		}

		// Token: 0x06026518 RID: 156952 RVA: 0x009D4D7D File Offset: 0x009D2F7D
		[NullableContext(1)]
		public SRoleOtherCasePart(USkeletalMesh OtherCaseSkeletalMesh, bool Vis, FName ParentTransformName)
		{
			this.OtherCaseSkeletalMesh = OtherCaseSkeletalMesh;
			this.Vis = Vis;
			this.ParentTransformName = ParentTransformName;
		}

		// Token: 0x06026519 RID: 156953 RVA: 0x009D4D9A File Offset: 0x009D2F9A
		protected override IntPtr GetUStructPtr()
		{
			return SRoleOtherCasePart.StaticStruct();
		}

		// Token: 0x0602651A RID: 156954 RVA: 0x009D4DA6 File Offset: 0x009D2FA6
		[NullableContext(2)]
		public SRoleOtherCasePart(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602651B RID: 156955 RVA: 0x009D4DB0 File Offset: 0x009D2FB0
		public SRoleOtherCasePart(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602651C RID: 156956 RVA: 0x009D4DBB File Offset: 0x009D2FBB
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SRoleOtherCasePart(Pointer, false, true);
		}

		// Token: 0x0602651D RID: 156957 RVA: 0x009D4DC5 File Offset: 0x009D2FC5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SRoleOtherCasePart(Pointer, MemoryOwner);
		}

		// Token: 0x04013E02 RID: 81410
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/SRoleOtherCasePart.SRoleOtherCasePart";

		// Token: 0x04013E03 RID: 81411
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013E04 RID: 81412
		internal static int __PropertyOffset_0;

		// Token: 0x04013E05 RID: 81413
		internal static int __PropertyOffset_1;

		// Token: 0x04013E06 RID: 81414
		internal static int __PropertyOffset_2;
	}
}
