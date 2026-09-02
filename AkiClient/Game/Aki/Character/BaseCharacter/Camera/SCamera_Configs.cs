using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004316 RID: 17174
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SCamera_Configs.SCamera_Configs")]
	[UnrealStructLayout(184, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 184)]
	public class SCamera_Configs : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D87B RID: 186491 RVA: 0x00AC2AFC File Offset: 0x00AC0CFC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCamera_Configs._ScriptStructPtr != 0) ? SCamera_Configs._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SCamera_Configs.SCamera_Configs", ref SCamera_Configs._ScriptStructPtr);
		}

		// Token: 0x17007C9B RID: 31899
		// (get) Token: 0x0602D87C RID: 186492 RVA: 0x00AC2B20 File Offset: 0x00AC0D20
		// (set) Token: 0x0602D87D RID: 186493 RVA: 0x00AC2B34 File Offset: 0x00AC0D34
		public unsafe TEnumAsByte<EFightCameraType> Type
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Configs.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Configs.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007C9C RID: 31900
		// (get) Token: 0x0602D87E RID: 186494 RVA: 0x00AC2B49 File Offset: 0x00AC0D49
		// (set) Token: 0x0602D87F RID: 186495 RVA: 0x00AC2B5D File Offset: 0x00AC0D5D
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Configs.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Configs.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007C9D RID: 31901
		// (get) Token: 0x0602D880 RID: 186496 RVA: 0x00AC2B74 File Offset: 0x00AC0D74
		// (set) Token: 0x0602D881 RID: 186497 RVA: 0x00AC2BB7 File Offset: 0x00AC0DB7
		[Nullable(1)]
		public SCamera_Setting Config
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SCamera_Setting result;
				if ((result = this._Config) == null)
				{
					result = (this._Config = new SCamera_Setting(base.NativePtr + (IntPtr)SCamera_Configs.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCamera_Setting.StaticStruct(), base.NativePtr + (IntPtr)SCamera_Configs.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D882 RID: 186498 RVA: 0x00AC2BD8 File Offset: 0x00AC0DD8
		public SCamera_Configs()
		{
		}

		// Token: 0x0602D883 RID: 186499 RVA: 0x00AC2BE0 File Offset: 0x00AC0DE0
		public SCamera_Configs(TEnumAsByte<EFightCameraType> Type, FGameplayTag Tag, [Nullable(1)] SCamera_Setting Config)
		{
			this.Type = Type;
			this.Tag = Tag;
			this.Config = Config;
		}

		// Token: 0x0602D884 RID: 186500 RVA: 0x00AC2BFD File Offset: 0x00AC0DFD
		protected override IntPtr GetUStructPtr()
		{
			return SCamera_Configs.StaticStruct();
		}

		// Token: 0x0602D885 RID: 186501 RVA: 0x00AC2C09 File Offset: 0x00AC0E09
		[NullableContext(2)]
		public SCamera_Configs(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D886 RID: 186502 RVA: 0x00AC2C13 File Offset: 0x00AC0E13
		public SCamera_Configs(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D887 RID: 186503 RVA: 0x00AC2C1E File Offset: 0x00AC0E1E
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCamera_Configs(Pointer, false, true);
		}

		// Token: 0x0602D888 RID: 186504 RVA: 0x00AC2C28 File Offset: 0x00AC0E28
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCamera_Configs(Pointer, MemoryOwner);
		}

		// Token: 0x04019ABC RID: 105148
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SCamera_Configs.SCamera_Configs";

		// Token: 0x04019ABD RID: 105149
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019ABE RID: 105150
		internal static int __PropertyOffset_0;

		// Token: 0x04019ABF RID: 105151
		internal static int __PropertyOffset_1;

		// Token: 0x04019AC0 RID: 105152
		internal static int __PropertyOffset_2;

		// Token: 0x04019AC1 RID: 105153
		[Nullable(2)]
		private SCamera_Setting _Config;
	}
}
