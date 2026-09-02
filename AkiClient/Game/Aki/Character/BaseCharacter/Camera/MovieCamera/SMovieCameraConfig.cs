using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera.MovieCamera
{
	// Token: 0x02004325 RID: 17189
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfig.SMovieCameraConfig")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SMovieCameraConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D97A RID: 186746 RVA: 0x00AC41F0 File Offset: 0x00AC23F0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMovieCameraConfig._ScriptStructPtr != 0) ? SMovieCameraConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfig.SMovieCameraConfig", ref SMovieCameraConfig._ScriptStructPtr);
		}

		// Token: 0x17007CF3 RID: 31987
		// (get) Token: 0x0602D97B RID: 186747 RVA: 0x00AC4214 File Offset: 0x00AC2414
		// (set) Token: 0x0602D97C RID: 186748 RVA: 0x00AC4228 File Offset: 0x00AC2428
		public unsafe FName Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007CF4 RID: 31988
		// (get) Token: 0x0602D97D RID: 186749 RVA: 0x00AC423D File Offset: 0x00AC243D
		// (set) Token: 0x0602D97E RID: 186750 RVA: 0x00AC4251 File Offset: 0x00AC2451
		public unsafe TEnumAsByte<EMovieCameraSwitchType> MovieCameraSwitchType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007CF5 RID: 31989
		// (get) Token: 0x0602D97F RID: 186751 RVA: 0x00AC4268 File Offset: 0x00AC2468
		// (set) Token: 0x0602D980 RID: 186752 RVA: 0x00AC42AB File Offset: 0x00AC24AB
		[Nullable(1)]
		public TArray<SMovieCameraConfigItem> MovieCameraConfigItemList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SMovieCameraConfigItem> result;
				if ((result = this._MovieCameraConfigItemList) == null)
				{
					result = (this._MovieCameraConfigItemList = new TArray<SMovieCameraConfigItem>(base.NativePtr + (IntPtr)SMovieCameraConfig.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MovieCameraConfigItemList.CopyAssign(value);
			}
		}

		// Token: 0x0602D981 RID: 186753 RVA: 0x00AC42B9 File Offset: 0x00AC24B9
		public SMovieCameraConfig()
		{
		}

		// Token: 0x0602D982 RID: 186754 RVA: 0x00AC42C1 File Offset: 0x00AC24C1
		public SMovieCameraConfig(FName Name, TEnumAsByte<EMovieCameraSwitchType> MovieCameraSwitchType, [Nullable(1)] TArray<SMovieCameraConfigItem> MovieCameraConfigItemList)
		{
			this.Name = Name;
			this.MovieCameraSwitchType = MovieCameraSwitchType;
			this.MovieCameraConfigItemList = MovieCameraConfigItemList;
		}

		// Token: 0x0602D983 RID: 186755 RVA: 0x00AC42DE File Offset: 0x00AC24DE
		protected override IntPtr GetUStructPtr()
		{
			return SMovieCameraConfig.StaticStruct();
		}

		// Token: 0x0602D984 RID: 186756 RVA: 0x00AC42EA File Offset: 0x00AC24EA
		[NullableContext(2)]
		public SMovieCameraConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D985 RID: 186757 RVA: 0x00AC42F4 File Offset: 0x00AC24F4
		public SMovieCameraConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D986 RID: 186758 RVA: 0x00AC42FF File Offset: 0x00AC24FF
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMovieCameraConfig(Pointer, false, true);
		}

		// Token: 0x0602D987 RID: 186759 RVA: 0x00AC4309 File Offset: 0x00AC2509
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMovieCameraConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04019B50 RID: 105296
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfig.SMovieCameraConfig";

		// Token: 0x04019B51 RID: 105297
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019B52 RID: 105298
		internal static int __PropertyOffset_0;

		// Token: 0x04019B53 RID: 105299
		internal static int __PropertyOffset_1;

		// Token: 0x04019B54 RID: 105300
		internal static int __PropertyOffset_2;

		// Token: 0x04019B55 RID: 105301
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMovieCameraConfigItem> _MovieCameraConfigItemList;
	}
}
