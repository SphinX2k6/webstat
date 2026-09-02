using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data
{
	// Token: 0x02003A6D RID: 14957
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/S_SE_ControllerCommon.S_SE_ControllerCommon")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 33)]
	public class S_SE_ControllerCommon : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601F2DB RID: 127707 RVA: 0x0090A243 File Offset: 0x00908443
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_SE_ControllerCommon._ScriptStructPtr != 0) ? S_SE_ControllerCommon._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/S_SE_ControllerCommon.S_SE_ControllerCommon", ref S_SE_ControllerCommon._ScriptStructPtr);
		}

		// Token: 0x17002E7B RID: 11899
		// (get) Token: 0x0601F2DC RID: 127708 RVA: 0x0090A268 File Offset: 0x00908468
		// (set) Token: 0x0601F2DD RID: 127709 RVA: 0x0090A2AB File Offset: 0x009084AB
		public TArray<SMaterialControllerFloatParameter> CustomFloats
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialControllerFloatParameter> result;
				if ((result = this._CustomFloats) == null)
				{
					result = (this._CustomFloats = new TArray<SMaterialControllerFloatParameter>(base.NativePtr + (IntPtr)S_SE_ControllerCommon.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CustomFloats.CopyAssign(value);
			}
		}

		// Token: 0x17002E7C RID: 11900
		// (get) Token: 0x0601F2DE RID: 127710 RVA: 0x0090A2BC File Offset: 0x009084BC
		// (set) Token: 0x0601F2DF RID: 127711 RVA: 0x0090A2FF File Offset: 0x009084FF
		public TArray<SMaterialControllerColorParameter> CustomColors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialControllerColorParameter> result;
				if ((result = this._CustomColors) == null)
				{
					result = (this._CustomColors = new TArray<SMaterialControllerColorParameter>(base.NativePtr + (IntPtr)S_SE_ControllerCommon.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CustomColors.CopyAssign(value);
			}
		}

		// Token: 0x17002E7D RID: 11901
		// (get) Token: 0x0601F2E0 RID: 127712 RVA: 0x0090A30D File Offset: 0x0090850D
		// (set) Token: 0x0601F2E1 RID: 127713 RVA: 0x0090A31D File Offset: 0x0090851D
		public unsafe bool bActive
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_SE_ControllerCommon.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_SE_ControllerCommon.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F2E2 RID: 127714 RVA: 0x0090A32E File Offset: 0x0090852E
		public S_SE_ControllerCommon()
		{
		}

		// Token: 0x0601F2E3 RID: 127715 RVA: 0x0090A336 File Offset: 0x00908536
		public S_SE_ControllerCommon(TArray<SMaterialControllerFloatParameter> CustomFloats, TArray<SMaterialControllerColorParameter> CustomColors, bool bActive)
		{
			this.CustomFloats = CustomFloats;
			this.CustomColors = CustomColors;
			this.bActive = bActive;
		}

		// Token: 0x0601F2E4 RID: 127716 RVA: 0x0090A353 File Offset: 0x00908553
		protected override IntPtr GetUStructPtr()
		{
			return S_SE_ControllerCommon.StaticStruct();
		}

		// Token: 0x0601F2E5 RID: 127717 RVA: 0x0090A35F File Offset: 0x0090855F
		[NullableContext(2)]
		public S_SE_ControllerCommon(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601F2E6 RID: 127718 RVA: 0x0090A369 File Offset: 0x00908569
		public S_SE_ControllerCommon(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601F2E7 RID: 127719 RVA: 0x0090A374 File Offset: 0x00908574
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_SE_ControllerCommon(Pointer, false, true);
		}

		// Token: 0x0601F2E8 RID: 127720 RVA: 0x0090A37E File Offset: 0x0090857E
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_SE_ControllerCommon(Pointer, MemoryOwner);
		}

		// Token: 0x0400F742 RID: 63298
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/S_SE_ControllerCommon.S_SE_ControllerCommon";

		// Token: 0x0400F743 RID: 63299
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400F744 RID: 63300
		internal static int __PropertyOffset_0;

		// Token: 0x0400F745 RID: 63301
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialControllerFloatParameter> _CustomFloats;

		// Token: 0x0400F746 RID: 63302
		internal static int __PropertyOffset_1;

		// Token: 0x0400F747 RID: 63303
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialControllerColorParameter> _CustomColors;

		// Token: 0x0400F748 RID: 63304
		internal static int __PropertyOffset_2;
	}
}
