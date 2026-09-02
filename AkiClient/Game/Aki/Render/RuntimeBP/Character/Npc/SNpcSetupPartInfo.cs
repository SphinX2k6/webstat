using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D6E RID: 15726
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/SNpcSetupPartInfo.SNpcSetupPartInfo")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SNpcSetupPartInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060264EA RID: 156906 RVA: 0x009D49DE File Offset: 0x009D2BDE
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SNpcSetupPartInfo._ScriptStructPtr != 0) ? SNpcSetupPartInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/Npc/SNpcSetupPartInfo.SNpcSetupPartInfo", ref SNpcSetupPartInfo._ScriptStructPtr);
		}

		// Token: 0x1700568E RID: 22158
		// (get) Token: 0x060264EB RID: 156907 RVA: 0x009D4A04 File Offset: 0x009D2C04
		// (set) Token: 0x060264EC RID: 156908 RVA: 0x009D4A47 File Offset: 0x009D2C47
		public TArray<USkeletalMeshComponent> SkeletalMeshComponents
		{
			get
			{
				base.FastCheckIsValid();
				TArray<USkeletalMeshComponent> result;
				if ((result = this._SkeletalMeshComponents) == null)
				{
					result = (this._SkeletalMeshComponents = new TArray<USkeletalMeshComponent>(base.NativePtr + (IntPtr)SNpcSetupPartInfo.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SkeletalMeshComponents.CopyAssign(value);
			}
		}

		// Token: 0x060264ED RID: 156909 RVA: 0x009D4A55 File Offset: 0x009D2C55
		public SNpcSetupPartInfo()
		{
		}

		// Token: 0x060264EE RID: 156910 RVA: 0x009D4A5D File Offset: 0x009D2C5D
		public SNpcSetupPartInfo(TArray<USkeletalMeshComponent> SkeletalMeshComponents)
		{
			this.SkeletalMeshComponents = SkeletalMeshComponents;
		}

		// Token: 0x060264EF RID: 156911 RVA: 0x009D4A6C File Offset: 0x009D2C6C
		protected override IntPtr GetUStructPtr()
		{
			return SNpcSetupPartInfo.StaticStruct();
		}

		// Token: 0x060264F0 RID: 156912 RVA: 0x009D4A78 File Offset: 0x009D2C78
		[NullableContext(2)]
		public SNpcSetupPartInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060264F1 RID: 156913 RVA: 0x009D4A82 File Offset: 0x009D2C82
		public SNpcSetupPartInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060264F2 RID: 156914 RVA: 0x009D4A8D File Offset: 0x009D2C8D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SNpcSetupPartInfo(Pointer, false, true);
		}

		// Token: 0x060264F3 RID: 156915 RVA: 0x009D4A97 File Offset: 0x009D2C97
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SNpcSetupPartInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04013DF2 RID: 81394
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/SNpcSetupPartInfo.SNpcSetupPartInfo";

		// Token: 0x04013DF3 RID: 81395
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013DF4 RID: 81396
		internal static int __PropertyOffset_0;

		// Token: 0x04013DF5 RID: 81397
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USkeletalMeshComponent> _SkeletalMeshComponents;
	}
}
