using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x0200431F RID: 17183
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SSettlementCamera.SSettlementCamera")]
	[UnrealStructLayout(464, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 460)]
	public class SSettlementCamera : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D95C RID: 186716 RVA: 0x00AC3F6E File Offset: 0x00AC216E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSettlementCamera._ScriptStructPtr != 0) ? SSettlementCamera._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SSettlementCamera.SSettlementCamera", ref SSettlementCamera._ScriptStructPtr);
		}

		// Token: 0x17007CE8 RID: 31976
		// (get) Token: 0x0602D95D RID: 186717 RVA: 0x00AC3F92 File Offset: 0x00AC2192
		// (set) Token: 0x0602D95E RID: 186718 RVA: 0x00AC3FA2 File Offset: 0x00AC21A2
		public unsafe float MinRandomPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007CE9 RID: 31977
		// (get) Token: 0x0602D95F RID: 186719 RVA: 0x00AC3FB3 File Offset: 0x00AC21B3
		// (set) Token: 0x0602D960 RID: 186720 RVA: 0x00AC3FC3 File Offset: 0x00AC21C3
		public unsafe float MaxRandomPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007CEA RID: 31978
		// (get) Token: 0x0602D961 RID: 186721 RVA: 0x00AC3FD4 File Offset: 0x00AC21D4
		// (set) Token: 0x0602D962 RID: 186722 RVA: 0x00AC3FE4 File Offset: 0x00AC21E4
		public unsafe float TopAdditionZ
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007CEB RID: 31979
		// (get) Token: 0x0602D963 RID: 186723 RVA: 0x00AC3FF5 File Offset: 0x00AC21F5
		// (set) Token: 0x0602D964 RID: 186724 RVA: 0x00AC4005 File Offset: 0x00AC2205
		public unsafe float BottomAdditionZ
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007CEC RID: 31980
		// (get) Token: 0x0602D965 RID: 186725 RVA: 0x00AC4016 File Offset: 0x00AC2216
		// (set) Token: 0x0602D966 RID: 186726 RVA: 0x00AC4026 File Offset: 0x00AC2226
		public unsafe float LeftMinYawRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007CED RID: 31981
		// (get) Token: 0x0602D967 RID: 186727 RVA: 0x00AC4037 File Offset: 0x00AC2237
		// (set) Token: 0x0602D968 RID: 186728 RVA: 0x00AC4047 File Offset: 0x00AC2247
		public unsafe float LeftMaxYawRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007CEE RID: 31982
		// (get) Token: 0x0602D969 RID: 186729 RVA: 0x00AC4058 File Offset: 0x00AC2258
		// (set) Token: 0x0602D96A RID: 186730 RVA: 0x00AC4068 File Offset: 0x00AC2268
		public unsafe float RightMinYawRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007CEF RID: 31983
		// (get) Token: 0x0602D96B RID: 186731 RVA: 0x00AC4079 File Offset: 0x00AC2279
		// (set) Token: 0x0602D96C RID: 186732 RVA: 0x00AC4089 File Offset: 0x00AC2289
		public unsafe float RightMaxYawRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007CF0 RID: 31984
		// (get) Token: 0x0602D96D RID: 186733 RVA: 0x00AC409A File Offset: 0x00AC229A
		// (set) Token: 0x0602D96E RID: 186734 RVA: 0x00AC40AA File Offset: 0x00AC22AA
		public unsafe float MinValidYawRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007CF1 RID: 31985
		// (get) Token: 0x0602D96F RID: 186735 RVA: 0x00AC40BC File Offset: 0x00AC22BC
		// (set) Token: 0x0602D970 RID: 186736 RVA: 0x00AC40FF File Offset: 0x00AC22FF
		public SCameraModifier CameraModifier
		{
			get
			{
				base.FastCheckIsValid();
				SCameraModifier result;
				if ((result = this._CameraModifier) == null)
				{
					result = (this._CameraModifier = new SCameraModifier(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCameraModifier.StaticStruct(), base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007CF2 RID: 31986
		// (get) Token: 0x0602D971 RID: 186737 RVA: 0x00AC4120 File Offset: 0x00AC2320
		// (set) Token: 0x0602D972 RID: 186738 RVA: 0x00AC4134 File Offset: 0x00AC2334
		public unsafe FVector CharacterOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSettlementCamera.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x0602D973 RID: 186739 RVA: 0x00AC4149 File Offset: 0x00AC2349
		public SSettlementCamera()
		{
		}

		// Token: 0x0602D974 RID: 186740 RVA: 0x00AC4154 File Offset: 0x00AC2354
		public SSettlementCamera(float MinRandomPitch, float MaxRandomPitch, float TopAdditionZ, float BottomAdditionZ, float LeftMinYawRange, float LeftMaxYawRange, float RightMinYawRange, float RightMaxYawRange, float MinValidYawRange, SCameraModifier CameraModifier, FVector CharacterOffset)
		{
			this.MinRandomPitch = MinRandomPitch;
			this.MaxRandomPitch = MaxRandomPitch;
			this.TopAdditionZ = TopAdditionZ;
			this.BottomAdditionZ = BottomAdditionZ;
			this.LeftMinYawRange = LeftMinYawRange;
			this.LeftMaxYawRange = LeftMaxYawRange;
			this.RightMinYawRange = RightMinYawRange;
			this.RightMaxYawRange = RightMaxYawRange;
			this.MinValidYawRange = MinValidYawRange;
			this.CameraModifier = CameraModifier;
			this.CharacterOffset = CharacterOffset;
		}

		// Token: 0x0602D975 RID: 186741 RVA: 0x00AC41BC File Offset: 0x00AC23BC
		protected override IntPtr GetUStructPtr()
		{
			return SSettlementCamera.StaticStruct();
		}

		// Token: 0x0602D976 RID: 186742 RVA: 0x00AC41C8 File Offset: 0x00AC23C8
		[NullableContext(2)]
		public SSettlementCamera(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D977 RID: 186743 RVA: 0x00AC41D2 File Offset: 0x00AC23D2
		public SSettlementCamera(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D978 RID: 186744 RVA: 0x00AC41DD File Offset: 0x00AC23DD
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSettlementCamera(Pointer, false, true);
		}

		// Token: 0x0602D979 RID: 186745 RVA: 0x00AC41E7 File Offset: 0x00AC23E7
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSettlementCamera(Pointer, MemoryOwner);
		}

		// Token: 0x04019B2B RID: 105259
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SSettlementCamera.SSettlementCamera";

		// Token: 0x04019B2C RID: 105260
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019B2D RID: 105261
		internal static int __PropertyOffset_0;

		// Token: 0x04019B2E RID: 105262
		internal static int __PropertyOffset_1;

		// Token: 0x04019B2F RID: 105263
		internal static int __PropertyOffset_2;

		// Token: 0x04019B30 RID: 105264
		internal static int __PropertyOffset_3;

		// Token: 0x04019B31 RID: 105265
		internal static int __PropertyOffset_4;

		// Token: 0x04019B32 RID: 105266
		internal static int __PropertyOffset_5;

		// Token: 0x04019B33 RID: 105267
		internal static int __PropertyOffset_6;

		// Token: 0x04019B34 RID: 105268
		internal static int __PropertyOffset_7;

		// Token: 0x04019B35 RID: 105269
		internal static int __PropertyOffset_8;

		// Token: 0x04019B36 RID: 105270
		internal static int __PropertyOffset_9;

		// Token: 0x04019B37 RID: 105271
		[Nullable(2)]
		private SCameraModifier _CameraModifier;

		// Token: 0x04019B38 RID: 105272
		internal static int __PropertyOffset_10;
	}
}
