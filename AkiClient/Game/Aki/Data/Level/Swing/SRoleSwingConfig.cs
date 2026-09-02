using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Level.Swing
{
	// Token: 0x02003E71 RID: 15985
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/Swing/SRoleSwingConfig.SRoleSwingConfig")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SRoleSwingConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027802 RID: 161794 RVA: 0x009F3434 File Offset: 0x009F1634
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRoleSwingConfig._ScriptStructPtr != 0) ? SRoleSwingConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Level/Swing/SRoleSwingConfig.SRoleSwingConfig", ref SRoleSwingConfig._ScriptStructPtr);
		}

		// Token: 0x17005D21 RID: 23841
		// (get) Token: 0x06027803 RID: 161795 RVA: 0x009F3458 File Offset: 0x009F1658
		// (set) Token: 0x06027804 RID: 161796 RVA: 0x009F349B File Offset: 0x009F169B
		public TArray<int> RoleId
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._RoleId) == null)
				{
					result = (this._RoleId = new TArray<int>(base.NativePtr + (IntPtr)SRoleSwingConfig.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.RoleId.CopyAssign(value);
			}
		}

		// Token: 0x17005D22 RID: 23842
		// (get) Token: 0x06027805 RID: 161797 RVA: 0x009F34A9 File Offset: 0x009F16A9
		// (set) Token: 0x06027806 RID: 161798 RVA: 0x009F34C8 File Offset: 0x009F16C8
		public TSoftObjectPtr<UAnimMontage> SwingMontage
		{
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)SRoleSwingConfig.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SRoleSwingConfig.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x06027807 RID: 161799 RVA: 0x009F34ED File Offset: 0x009F16ED
		public SRoleSwingConfig()
		{
		}

		// Token: 0x06027808 RID: 161800 RVA: 0x009F34F5 File Offset: 0x009F16F5
		public SRoleSwingConfig(TArray<int> RoleId, TSoftObjectPtr<UAnimMontage> SwingMontage)
		{
			this.RoleId = RoleId;
			this.SwingMontage = SwingMontage;
		}

		// Token: 0x06027809 RID: 161801 RVA: 0x009F350B File Offset: 0x009F170B
		protected override IntPtr GetUStructPtr()
		{
			return SRoleSwingConfig.StaticStruct();
		}

		// Token: 0x0602780A RID: 161802 RVA: 0x009F3517 File Offset: 0x009F1717
		[NullableContext(2)]
		public SRoleSwingConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602780B RID: 161803 RVA: 0x009F3521 File Offset: 0x009F1721
		public SRoleSwingConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602780C RID: 161804 RVA: 0x009F352C File Offset: 0x009F172C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SRoleSwingConfig(Pointer, false, true);
		}

		// Token: 0x0602780D RID: 161805 RVA: 0x009F3536 File Offset: 0x009F1736
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SRoleSwingConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014B12 RID: 84754
		public const string __ObjectPath = "/Game/Aki/Data/Level/Swing/SRoleSwingConfig.SRoleSwingConfig";

		// Token: 0x04014B13 RID: 84755
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014B14 RID: 84756
		internal static int __PropertyOffset_0;

		// Token: 0x04014B15 RID: 84757
		[Nullable(2)]
		private TArray<int> _RoleId;

		// Token: 0x04014B16 RID: 84758
		internal static int __PropertyOffset_1;
	}
}
