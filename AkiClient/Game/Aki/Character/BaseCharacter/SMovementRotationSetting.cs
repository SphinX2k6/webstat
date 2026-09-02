using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200426F RID: 17007
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SMovementRotationSetting.SMovementRotationSetting")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SMovementRotationSetting : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D191 RID: 184721 RVA: 0x00AB7459 File Offset: 0x00AB5659
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMovementRotationSetting._ScriptStructPtr != 0) ? SMovementRotationSetting._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SMovementRotationSetting.SMovementRotationSetting", ref SMovementRotationSetting._ScriptStructPtr);
		}

		// Token: 0x17007A85 RID: 31365
		// (get) Token: 0x0602D192 RID: 184722 RVA: 0x00AB747D File Offset: 0x00AB567D
		// (set) Token: 0x0602D193 RID: 184723 RVA: 0x00AB748D File Offset: 0x00AB568D
		public unsafe float 最小旋转速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementRotationSetting.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementRotationSetting.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A86 RID: 31366
		// (get) Token: 0x0602D194 RID: 184724 RVA: 0x00AB749E File Offset: 0x00AB569E
		// (set) Token: 0x0602D195 RID: 184725 RVA: 0x00AB74AE File Offset: 0x00AB56AE
		public unsafe float 最大旋转速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementRotationSetting.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementRotationSetting.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A87 RID: 31367
		// (get) Token: 0x0602D196 RID: 184726 RVA: 0x00AB74BF File Offset: 0x00AB56BF
		// (set) Token: 0x0602D197 RID: 184727 RVA: 0x00AB74CF File Offset: 0x00AB56CF
		public unsafe float 最小角度差
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementRotationSetting.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementRotationSetting.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A88 RID: 31368
		// (get) Token: 0x0602D198 RID: 184728 RVA: 0x00AB74E0 File Offset: 0x00AB56E0
		// (set) Token: 0x0602D199 RID: 184729 RVA: 0x00AB74F0 File Offset: 0x00AB56F0
		public unsafe float 最大角度差
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementRotationSetting.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementRotationSetting.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007A89 RID: 31369
		// (get) Token: 0x0602D19A RID: 184730 RVA: 0x00AB7504 File Offset: 0x00AB5704
		// (set) Token: 0x0602D19B RID: 184731 RVA: 0x00AB7547 File Offset: 0x00AB5747
		public SBaseCurve 渐变曲线
		{
			get
			{
				base.FastCheckIsValid();
				SBaseCurve result;
				if ((result = this._渐变曲线) == null)
				{
					result = (this._渐变曲线 = new SBaseCurve(base.NativePtr + (IntPtr)SMovementRotationSetting.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)SMovementRotationSetting.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D19C RID: 184732 RVA: 0x00AB7568 File Offset: 0x00AB5768
		public SMovementRotationSetting()
		{
		}

		// Token: 0x0602D19D RID: 184733 RVA: 0x00AB7570 File Offset: 0x00AB5770
		public SMovementRotationSetting(float 最小旋转速度, float 最大旋转速度, float 最小角度差, float 最大角度差, SBaseCurve 渐变曲线)
		{
			this.最小旋转速度 = 最小旋转速度;
			this.最大旋转速度 = 最大旋转速度;
			this.最小角度差 = 最小角度差;
			this.最大角度差 = 最大角度差;
			this.渐变曲线 = 渐变曲线;
		}

		// Token: 0x0602D19E RID: 184734 RVA: 0x00AB759D File Offset: 0x00AB579D
		protected override IntPtr GetUStructPtr()
		{
			return SMovementRotationSetting.StaticStruct();
		}

		// Token: 0x0602D19F RID: 184735 RVA: 0x00AB75A9 File Offset: 0x00AB57A9
		[NullableContext(2)]
		public SMovementRotationSetting(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D1A0 RID: 184736 RVA: 0x00AB75B3 File Offset: 0x00AB57B3
		public SMovementRotationSetting(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D1A1 RID: 184737 RVA: 0x00AB75BE File Offset: 0x00AB57BE
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMovementRotationSetting(Pointer, false, true);
		}

		// Token: 0x0602D1A2 RID: 184738 RVA: 0x00AB75C8 File Offset: 0x00AB57C8
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMovementRotationSetting(Pointer, MemoryOwner);
		}

		// Token: 0x04019492 RID: 103570
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SMovementRotationSetting.SMovementRotationSetting";

		// Token: 0x04019493 RID: 103571
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019494 RID: 103572
		internal static int __PropertyOffset_0;

		// Token: 0x04019495 RID: 103573
		internal static int __PropertyOffset_1;

		// Token: 0x04019496 RID: 103574
		internal static int __PropertyOffset_2;

		// Token: 0x04019497 RID: 103575
		internal static int __PropertyOffset_3;

		// Token: 0x04019498 RID: 103576
		internal static int __PropertyOffset_4;

		// Token: 0x04019499 RID: 103577
		[Nullable(2)]
		private SBaseCurve _渐变曲线;
	}
}
