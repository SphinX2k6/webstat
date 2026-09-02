using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004236 RID: 16950
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SAiWeaponSocket.SAiWeaponSocket")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 88)]
	public class SAiWeaponSocket : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CD40 RID: 183616 RVA: 0x00AB0CC6 File Offset: 0x00AAEEC6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAiWeaponSocket._ScriptStructPtr != 0) ? SAiWeaponSocket._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SAiWeaponSocket.SAiWeaponSocket", ref SAiWeaponSocket._ScriptStructPtr);
		}

		// Token: 0x1700793C RID: 31036
		// (get) Token: 0x0602CD41 RID: 183617 RVA: 0x00AB0CEC File Offset: 0x00AAEEEC
		// (set) Token: 0x0602CD42 RID: 183618 RVA: 0x00AB0D2F File Offset: 0x00AAEF2F
		public TMap<int, SWeaponSocket> AiModelConfig
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, SWeaponSocket> result;
				if ((result = this._AiModelConfig) == null)
				{
					result = (this._AiModelConfig = new TMap<int, SWeaponSocket>(base.NativePtr + (IntPtr)SAiWeaponSocket.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AiModelConfig.CopyAssign(value);
			}
		}

		// Token: 0x1700793D RID: 31037
		// (get) Token: 0x0602CD43 RID: 183619 RVA: 0x00AB0D3D File Offset: 0x00AAEF3D
		// (set) Token: 0x0602CD44 RID: 183620 RVA: 0x00AB0D4D File Offset: 0x00AAEF4D
		public unsafe float CollisionRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAiWeaponSocket.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAiWeaponSocket.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700793E RID: 31038
		// (get) Token: 0x0602CD45 RID: 183621 RVA: 0x00AB0D5E File Offset: 0x00AAEF5E
		// (set) Token: 0x0602CD46 RID: 183622 RVA: 0x00AB0D6E File Offset: 0x00AAEF6E
		public unsafe float Mass
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAiWeaponSocket.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAiWeaponSocket.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602CD47 RID: 183623 RVA: 0x00AB0D7F File Offset: 0x00AAEF7F
		public SAiWeaponSocket()
		{
		}

		// Token: 0x0602CD48 RID: 183624 RVA: 0x00AB0D87 File Offset: 0x00AAEF87
		public SAiWeaponSocket(TMap<int, SWeaponSocket> AiModelConfig, float CollisionRadius, float Mass)
		{
			this.AiModelConfig = AiModelConfig;
			this.CollisionRadius = CollisionRadius;
			this.Mass = Mass;
		}

		// Token: 0x0602CD49 RID: 183625 RVA: 0x00AB0DA4 File Offset: 0x00AAEFA4
		protected override IntPtr GetUStructPtr()
		{
			return SAiWeaponSocket.StaticStruct();
		}

		// Token: 0x0602CD4A RID: 183626 RVA: 0x00AB0DB0 File Offset: 0x00AAEFB0
		[NullableContext(2)]
		public SAiWeaponSocket(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CD4B RID: 183627 RVA: 0x00AB0DBA File Offset: 0x00AAEFBA
		public SAiWeaponSocket(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CD4C RID: 183628 RVA: 0x00AB0DC5 File Offset: 0x00AAEFC5
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAiWeaponSocket(Pointer, false, true);
		}

		// Token: 0x0602CD4D RID: 183629 RVA: 0x00AB0DCF File Offset: 0x00AAEFCF
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAiWeaponSocket(Pointer, MemoryOwner);
		}

		// Token: 0x04019264 RID: 103012
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SAiWeaponSocket.SAiWeaponSocket";

		// Token: 0x04019265 RID: 103013
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019266 RID: 103014
		internal static int __PropertyOffset_0;

		// Token: 0x04019267 RID: 103015
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, SWeaponSocket> _AiModelConfig;

		// Token: 0x04019268 RID: 103016
		internal static int __PropertyOffset_1;

		// Token: 0x04019269 RID: 103017
		internal static int __PropertyOffset_2;
	}
}
