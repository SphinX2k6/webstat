using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D72 RID: 15730
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/SRoleSetupPartInfo.SRoleSetupPartInfo")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SRoleSetupPartInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602651E RID: 156958 RVA: 0x009D4DCE File Offset: 0x009D2FCE
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRoleSetupPartInfo._ScriptStructPtr != 0) ? SRoleSetupPartInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/Npc/SRoleSetupPartInfo.SRoleSetupPartInfo", ref SRoleSetupPartInfo._ScriptStructPtr);
		}

		// Token: 0x17005698 RID: 22168
		// (get) Token: 0x0602651F RID: 156959 RVA: 0x009D4DF4 File Offset: 0x009D2FF4
		// (set) Token: 0x06026520 RID: 156960 RVA: 0x009D4E37 File Offset: 0x009D3037
		public TArray<USkeletalMeshComponent> SkeletalMeshComponents
		{
			get
			{
				base.FastCheckIsValid();
				TArray<USkeletalMeshComponent> result;
				if ((result = this._SkeletalMeshComponents) == null)
				{
					result = (this._SkeletalMeshComponents = new TArray<USkeletalMeshComponent>(base.NativePtr + (IntPtr)SRoleSetupPartInfo.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SkeletalMeshComponents.CopyAssign(value);
			}
		}

		// Token: 0x06026521 RID: 156961 RVA: 0x009D4E45 File Offset: 0x009D3045
		public SRoleSetupPartInfo()
		{
		}

		// Token: 0x06026522 RID: 156962 RVA: 0x009D4E4D File Offset: 0x009D304D
		public SRoleSetupPartInfo(TArray<USkeletalMeshComponent> SkeletalMeshComponents)
		{
			this.SkeletalMeshComponents = SkeletalMeshComponents;
		}

		// Token: 0x06026523 RID: 156963 RVA: 0x009D4E5C File Offset: 0x009D305C
		protected override IntPtr GetUStructPtr()
		{
			return SRoleSetupPartInfo.StaticStruct();
		}

		// Token: 0x06026524 RID: 156964 RVA: 0x009D4E68 File Offset: 0x009D3068
		[NullableContext(2)]
		public SRoleSetupPartInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026525 RID: 156965 RVA: 0x009D4E72 File Offset: 0x009D3072
		public SRoleSetupPartInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026526 RID: 156966 RVA: 0x009D4E7D File Offset: 0x009D307D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SRoleSetupPartInfo(Pointer, false, true);
		}

		// Token: 0x06026527 RID: 156967 RVA: 0x009D4E87 File Offset: 0x009D3087
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SRoleSetupPartInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04013E07 RID: 81415
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/SRoleSetupPartInfo.SRoleSetupPartInfo";

		// Token: 0x04013E08 RID: 81416
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013E09 RID: 81417
		internal static int __PropertyOffset_0;

		// Token: 0x04013E0A RID: 81418
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USkeletalMeshComponent> _SkeletalMeshComponents;
	}
}
