using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x0200431E RID: 17182
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SSequenceCamera_SpecificConfig.SSequenceCamera_SpecificConfig")]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 14)]
	public class SSequenceCamera_SpecificConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D94A RID: 186698 RVA: 0x00AC3E2C File Offset: 0x00AC202C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSequenceCamera_SpecificConfig._ScriptStructPtr != 0) ? SSequenceCamera_SpecificConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SSequenceCamera_SpecificConfig.SSequenceCamera_SpecificConfig", ref SSequenceCamera_SpecificConfig._ScriptStructPtr);
		}

		// Token: 0x17007CE3 RID: 31971
		// (get) Token: 0x0602D94B RID: 186699 RVA: 0x00AC3E50 File Offset: 0x00AC2050
		// (set) Token: 0x0602D94C RID: 186700 RVA: 0x00AC3E64 File Offset: 0x00AC2064
		public unsafe TEnumAsByte<ESequenceCameraSpecificType> SpecificType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_SpecificConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_SpecificConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007CE4 RID: 31972
		// (get) Token: 0x0602D94D RID: 186701 RVA: 0x00AC3E79 File Offset: 0x00AC2079
		// (set) Token: 0x0602D94E RID: 186702 RVA: 0x00AC3E89 File Offset: 0x00AC2089
		public unsafe float OverrideSequenceTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_SpecificConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_SpecificConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007CE5 RID: 31973
		// (get) Token: 0x0602D94F RID: 186703 RVA: 0x00AC3E9A File Offset: 0x00AC209A
		// (set) Token: 0x0602D950 RID: 186704 RVA: 0x00AC3EAA File Offset: 0x00AC20AA
		public unsafe float OverrideBlendOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_SpecificConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_SpecificConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007CE6 RID: 31974
		// (get) Token: 0x0602D951 RID: 186705 RVA: 0x00AC3EBB File Offset: 0x00AC20BB
		// (set) Token: 0x0602D952 RID: 186706 RVA: 0x00AC3ECF File Offset: 0x00AC20CF
		public unsafe TEnumAsByte<ESequenceCameraAnsEffectiveClientType> OverrideCondition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_SpecificConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_SpecificConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007CE7 RID: 31975
		// (get) Token: 0x0602D953 RID: 186707 RVA: 0x00AC3EE4 File Offset: 0x00AC20E4
		// (set) Token: 0x0602D954 RID: 186708 RVA: 0x00AC3EF4 File Offset: 0x00AC20F4
		public unsafe bool IsRecoverRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequenceCamera_SpecificConfig.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequenceCamera_SpecificConfig.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D955 RID: 186709 RVA: 0x00AC3F05 File Offset: 0x00AC2105
		public SSequenceCamera_SpecificConfig()
		{
		}

		// Token: 0x0602D956 RID: 186710 RVA: 0x00AC3F0D File Offset: 0x00AC210D
		public SSequenceCamera_SpecificConfig(TEnumAsByte<ESequenceCameraSpecificType> SpecificType, float OverrideSequenceTime, float OverrideBlendOutTime, TEnumAsByte<ESequenceCameraAnsEffectiveClientType> OverrideCondition, bool IsRecoverRotation)
		{
			this.SpecificType = SpecificType;
			this.OverrideSequenceTime = OverrideSequenceTime;
			this.OverrideBlendOutTime = OverrideBlendOutTime;
			this.OverrideCondition = OverrideCondition;
			this.IsRecoverRotation = IsRecoverRotation;
		}

		// Token: 0x0602D957 RID: 186711 RVA: 0x00AC3F3A File Offset: 0x00AC213A
		protected override IntPtr GetUStructPtr()
		{
			return SSequenceCamera_SpecificConfig.StaticStruct();
		}

		// Token: 0x0602D958 RID: 186712 RVA: 0x00AC3F46 File Offset: 0x00AC2146
		[NullableContext(2)]
		public SSequenceCamera_SpecificConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D959 RID: 186713 RVA: 0x00AC3F50 File Offset: 0x00AC2150
		public SSequenceCamera_SpecificConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D95A RID: 186714 RVA: 0x00AC3F5B File Offset: 0x00AC215B
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSequenceCamera_SpecificConfig(Pointer, false, true);
		}

		// Token: 0x0602D95B RID: 186715 RVA: 0x00AC3F65 File Offset: 0x00AC2165
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSequenceCamera_SpecificConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04019B24 RID: 105252
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SSequenceCamera_SpecificConfig.SSequenceCamera_SpecificConfig";

		// Token: 0x04019B25 RID: 105253
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019B26 RID: 105254
		internal static int __PropertyOffset_0;

		// Token: 0x04019B27 RID: 105255
		internal static int __PropertyOffset_1;

		// Token: 0x04019B28 RID: 105256
		internal static int __PropertyOffset_2;

		// Token: 0x04019B29 RID: 105257
		internal static int __PropertyOffset_3;

		// Token: 0x04019B2A RID: 105258
		internal static int __PropertyOffset_4;
	}
}
