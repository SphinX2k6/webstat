using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004289 RID: 17033
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SWeaponSocketItem.SWeaponSocketItem")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 88)]
	public class SWeaponSocketItem : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D400 RID: 185344 RVA: 0x00ABB0A7 File Offset: 0x00AB92A7
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SWeaponSocketItem._ScriptStructPtr != 0) ? SWeaponSocketItem._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SWeaponSocketItem.SWeaponSocketItem", ref SWeaponSocketItem._ScriptStructPtr);
		}

		// Token: 0x17007B56 RID: 31574
		// (get) Token: 0x0602D401 RID: 185345 RVA: 0x00ABB0CC File Offset: 0x00AB92CC
		// (set) Token: 0x0602D402 RID: 185346 RVA: 0x00ABB10F File Offset: 0x00AB930F
		public TArray<SWeaponMesh> Meshes
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SWeaponMesh> result;
				if ((result = this._Meshes) == null)
				{
					result = (this._Meshes = new TArray<SWeaponMesh>(base.NativePtr + (IntPtr)SWeaponSocketItem.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Meshes.CopyAssign(value);
			}
		}

		// Token: 0x17007B57 RID: 31575
		// (get) Token: 0x0602D403 RID: 185347 RVA: 0x00ABB11D File Offset: 0x00AB931D
		// (set) Token: 0x0602D404 RID: 185348 RVA: 0x00ABB131 File Offset: 0x00AB9331
		public unsafe FName DropSocket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWeaponSocketItem.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWeaponSocketItem.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007B58 RID: 31576
		// (get) Token: 0x0602D405 RID: 185349 RVA: 0x00ABB146 File Offset: 0x00AB9346
		// (set) Token: 0x0602D406 RID: 185350 RVA: 0x00ABB15A File Offset: 0x00AB935A
		public unsafe FVector DropVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWeaponSocketItem.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWeaponSocketItem.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007B59 RID: 31577
		// (get) Token: 0x0602D407 RID: 185351 RVA: 0x00ABB16F File Offset: 0x00AB936F
		// (set) Token: 0x0602D408 RID: 185352 RVA: 0x00ABB183 File Offset: 0x00AB9383
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWeaponSocketItem.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWeaponSocketItem.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007B5A RID: 31578
		// (get) Token: 0x0602D409 RID: 185353 RVA: 0x00ABB198 File Offset: 0x00AB9398
		// (set) Token: 0x0602D40A RID: 185354 RVA: 0x00ABB1DB File Offset: 0x00AB93DB
		public FSoftObjectPath WeaponEffectPath
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._WeaponEffectPath) == null)
				{
					result = (this._WeaponEffectPath = new FSoftObjectPath(base.NativePtr + (IntPtr)SWeaponSocketItem.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)SWeaponSocketItem.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D40B RID: 185355 RVA: 0x00ABB1FC File Offset: 0x00AB93FC
		public SWeaponSocketItem()
		{
		}

		// Token: 0x0602D40C RID: 185356 RVA: 0x00ABB204 File Offset: 0x00AB9404
		public SWeaponSocketItem(TArray<SWeaponMesh> Meshes, FName DropSocket, FVector DropVelocity, FGameplayTag Tag, FSoftObjectPath WeaponEffectPath)
		{
			this.Meshes = Meshes;
			this.DropSocket = DropSocket;
			this.DropVelocity = DropVelocity;
			this.Tag = Tag;
			this.WeaponEffectPath = WeaponEffectPath;
		}

		// Token: 0x0602D40D RID: 185357 RVA: 0x00ABB231 File Offset: 0x00AB9431
		protected override IntPtr GetUStructPtr()
		{
			return SWeaponSocketItem.StaticStruct();
		}

		// Token: 0x0602D40E RID: 185358 RVA: 0x00ABB23D File Offset: 0x00AB943D
		[NullableContext(2)]
		public SWeaponSocketItem(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D40F RID: 185359 RVA: 0x00ABB247 File Offset: 0x00AB9447
		public SWeaponSocketItem(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D410 RID: 185360 RVA: 0x00ABB252 File Offset: 0x00AB9452
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SWeaponSocketItem(Pointer, false, true);
		}

		// Token: 0x0602D411 RID: 185361 RVA: 0x00ABB25C File Offset: 0x00AB945C
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SWeaponSocketItem(Pointer, MemoryOwner);
		}

		// Token: 0x040195D6 RID: 103894
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SWeaponSocketItem.SWeaponSocketItem";

		// Token: 0x040195D7 RID: 103895
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040195D8 RID: 103896
		internal static int __PropertyOffset_0;

		// Token: 0x040195D9 RID: 103897
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SWeaponMesh> _Meshes;

		// Token: 0x040195DA RID: 103898
		internal static int __PropertyOffset_1;

		// Token: 0x040195DB RID: 103899
		internal static int __PropertyOffset_2;

		// Token: 0x040195DC RID: 103900
		internal static int __PropertyOffset_3;

		// Token: 0x040195DD RID: 103901
		internal static int __PropertyOffset_4;

		// Token: 0x040195DE RID: 103902
		[Nullable(2)]
		private FSoftObjectPath _WeaponEffectPath;
	}
}
