using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x0200430F RID: 17167
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier.SCameraModifier")]
	[UnrealStructLayout(408, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 408)]
	public class SCameraModifier : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D782 RID: 186242 RVA: 0x00AC133C File Offset: 0x00ABF53C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraModifier._ScriptStructPtr != 0) ? SCameraModifier._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier.SCameraModifier", ref SCameraModifier._ScriptStructPtr);
		}

		// Token: 0x17007C3A RID: 31802
		// (get) Token: 0x0602D783 RID: 186243 RVA: 0x00AC1360 File Offset: 0x00ABF560
		// (set) Token: 0x0602D784 RID: 186244 RVA: 0x00AC1370 File Offset: 0x00ABF570
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007C3B RID: 31803
		// (get) Token: 0x0602D785 RID: 186245 RVA: 0x00AC1381 File Offset: 0x00ABF581
		// (set) Token: 0x0602D786 RID: 186246 RVA: 0x00AC1391 File Offset: 0x00ABF591
		public unsafe float BlendInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007C3C RID: 31804
		// (get) Token: 0x0602D787 RID: 186247 RVA: 0x00AC13A2 File Offset: 0x00ABF5A2
		// (set) Token: 0x0602D788 RID: 186248 RVA: 0x00AC13B2 File Offset: 0x00ABF5B2
		public unsafe float BlendOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007C3D RID: 31805
		// (get) Token: 0x0602D789 RID: 186249 RVA: 0x00AC13C3 File Offset: 0x00ABF5C3
		// (set) Token: 0x0602D78A RID: 186250 RVA: 0x00AC13D3 File Offset: 0x00ABF5D3
		public unsafe float BreakBlendOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007C3E RID: 31806
		// (get) Token: 0x0602D78B RID: 186251 RVA: 0x00AC13E4 File Offset: 0x00ABF5E4
		// (set) Token: 0x0602D78C RID: 186252 RVA: 0x00AC1427 File Offset: 0x00ABF627
		public SCameraModifier_Settings Settings
		{
			get
			{
				base.FastCheckIsValid();
				SCameraModifier_Settings result;
				if ((result = this._Settings) == null)
				{
					result = (this._Settings = new SCameraModifier_Settings(base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCameraModifier_Settings.StaticStruct(), base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C3F RID: 31807
		// (get) Token: 0x0602D78D RID: 186253 RVA: 0x00AC1448 File Offset: 0x00ABF648
		// (set) Token: 0x0602D78E RID: 186254 RVA: 0x00AC148B File Offset: 0x00ABF68B
		public SBaseCurve BlendInCurve
		{
			get
			{
				base.FastCheckIsValid();
				SBaseCurve result;
				if ((result = this._BlendInCurve) == null)
				{
					result = (this._BlendInCurve = new SBaseCurve(base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C40 RID: 31808
		// (get) Token: 0x0602D78F RID: 186255 RVA: 0x00AC14AC File Offset: 0x00ABF6AC
		// (set) Token: 0x0602D790 RID: 186256 RVA: 0x00AC14EF File Offset: 0x00ABF6EF
		public SBaseCurve BlendOutCurve
		{
			get
			{
				base.FastCheckIsValid();
				SBaseCurve result;
				if ((result = this._BlendOutCurve) == null)
				{
					result = (this._BlendOutCurve = new SBaseCurve(base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)SCameraModifier.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D791 RID: 186257 RVA: 0x00AC1510 File Offset: 0x00ABF710
		public SCameraModifier()
		{
		}

		// Token: 0x0602D792 RID: 186258 RVA: 0x00AC1518 File Offset: 0x00ABF718
		public SCameraModifier(float Duration, float BlendInTime, float BlendOutTime, float BreakBlendOutTime, SCameraModifier_Settings Settings, SBaseCurve BlendInCurve, SBaseCurve BlendOutCurve)
		{
			this.Duration = Duration;
			this.BlendInTime = BlendInTime;
			this.BlendOutTime = BlendOutTime;
			this.BreakBlendOutTime = BreakBlendOutTime;
			this.Settings = Settings;
			this.BlendInCurve = BlendInCurve;
			this.BlendOutCurve = BlendOutCurve;
		}

		// Token: 0x0602D793 RID: 186259 RVA: 0x00AC1555 File Offset: 0x00ABF755
		protected override IntPtr GetUStructPtr()
		{
			return SCameraModifier.StaticStruct();
		}

		// Token: 0x0602D794 RID: 186260 RVA: 0x00AC1561 File Offset: 0x00ABF761
		[NullableContext(2)]
		public SCameraModifier(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D795 RID: 186261 RVA: 0x00AC156B File Offset: 0x00ABF76B
		public SCameraModifier(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D796 RID: 186262 RVA: 0x00AC1576 File Offset: 0x00ABF776
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraModifier(Pointer, false, true);
		}

		// Token: 0x0602D797 RID: 186263 RVA: 0x00AC1580 File Offset: 0x00ABF780
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraModifier(Pointer, MemoryOwner);
		}

		// Token: 0x04019A38 RID: 105016
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier.SCameraModifier";

		// Token: 0x04019A39 RID: 105017
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019A3A RID: 105018
		internal static int __PropertyOffset_0;

		// Token: 0x04019A3B RID: 105019
		internal static int __PropertyOffset_1;

		// Token: 0x04019A3C RID: 105020
		internal static int __PropertyOffset_2;

		// Token: 0x04019A3D RID: 105021
		internal static int __PropertyOffset_3;

		// Token: 0x04019A3E RID: 105022
		internal static int __PropertyOffset_4;

		// Token: 0x04019A3F RID: 105023
		[Nullable(2)]
		private SCameraModifier_Settings _Settings;

		// Token: 0x04019A40 RID: 105024
		internal static int __PropertyOffset_5;

		// Token: 0x04019A41 RID: 105025
		[Nullable(2)]
		private SBaseCurve _BlendInCurve;

		// Token: 0x04019A42 RID: 105026
		internal static int __PropertyOffset_6;

		// Token: 0x04019A43 RID: 105027
		[Nullable(2)]
		private SBaseCurve _BlendOutCurve;
	}
}
