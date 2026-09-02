using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game
{
	// Token: 0x020046CE RID: 18126
	[NullableContext(2)]
	[Nullable(0)]
	public class Global : IStaticVariableResetter
	{
		// Token: 0x0602F254 RID: 193108 RVA: 0x00B2BDA2 File Offset: 0x00B29FA2
		static Global()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(Global.CreateStaticDefaultValue), new Action(Global.ResetStaticDefaultValue));
		}

		// Token: 0x0602F255 RID: 193109 RVA: 0x00B2BDC1 File Offset: 0x00B29FC1
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0602F256 RID: 193110 RVA: 0x00B2BDC3 File Offset: 0x00B29FC3
		public static void ResetStaticDefaultValue()
		{
			Global.BaseCharacter = null;
			Global._myBaseCharacter = null;
			Global.CharacterController = null;
			Global._myCharacterControllerInternal = null;
			Global._playerControllerInternal = null;
			Global._myCharacterCameraManager = null;
			Global._myPawnOrSpectator = null;
		}

		// Token: 0x17008114 RID: 33044
		// (get) Token: 0x0602F257 RID: 193111 RVA: 0x00B2BDEF File Offset: 0x00B29FEF
		// (set) Token: 0x0602F258 RID: 193112 RVA: 0x00B2BE25 File Offset: 0x00B2A025
		public static TsBaseCharacter BaseCharacter
		{
			get
			{
				if ((Global._myBaseCharacter == null || !Global._myBaseCharacter.IsValid()) && GlobalData.GameInstance != null)
				{
					Global._myBaseCharacter = (UGameplayStatics.GetPlayerCharacter(GlobalData.World, 0) as TsBaseCharacter);
				}
				return Global._myBaseCharacter;
			}
			set
			{
				Global._myBaseCharacter = value;
			}
		}

		// Token: 0x17008115 RID: 33045
		// (get) Token: 0x0602F259 RID: 193113 RVA: 0x00B2BE2D File Offset: 0x00B2A02D
		// (set) Token: 0x0602F25A RID: 193114 RVA: 0x00B2BE6D File Offset: 0x00B2A06D
		[Obsolete("慎用,可以暂时用PlayerController替代")]
		public static TsCharacterController CharacterController
		{
			get
			{
				if ((Global._myCharacterControllerInternal == null || !Global._myCharacterControllerInternal.IsValid()) && GlobalData.GameInstance != null)
				{
					Global._myCharacterControllerInternal = (UGameplayStatics.GetPlayerController(GlobalData.World, 0) as TsCharacterController);
					Global._playerControllerInternal = Global._myCharacterControllerInternal;
				}
				return Global._myCharacterControllerInternal;
			}
			set
			{
				if (Global._myCharacterControllerInternal == value)
				{
					return;
				}
				Global._myCharacterControllerInternal = value;
				Global._playerControllerInternal = value;
				if (value != null)
				{
					Singleton<TickSystem>.Instance.AddTickPrerequisiteActor(ETickingGroup.TG_PrePhysics, value, 2);
				}
			}
		}

		// Token: 0x17008116 RID: 33046
		// (get) Token: 0x0602F25B RID: 193115 RVA: 0x00B2BE94 File Offset: 0x00B2A094
		public static APlayerController PlayerController
		{
			get
			{
				if ((Global._playerControllerInternal == null || !Global._playerControllerInternal.IsValid()) && GlobalData.GameInstance != null)
				{
					Global._playerControllerInternal = UGameplayStatics.GetPlayerController(GlobalData.World, 0);
				}
				return Global._playerControllerInternal;
			}
		}

		// Token: 0x17008117 RID: 33047
		// (get) Token: 0x0602F25C RID: 193116 RVA: 0x00B2BEC5 File Offset: 0x00B2A0C5
		[Nullable(1)]
		public static APlayerCameraManager CharacterCameraManager
		{
			[NullableContext(1)]
			get
			{
				if ((Global._myCharacterCameraManager == null || !Global._myCharacterCameraManager.IsValid()) && GlobalData.GameInstance != null)
				{
					Global._myCharacterCameraManager = UGameplayStatics.GetPlayerCameraManager(GlobalData.World, 0);
				}
				return Global._myCharacterCameraManager;
			}
		}

		// Token: 0x17008118 RID: 33048
		// (get) Token: 0x0602F25D RID: 193117 RVA: 0x00B2BEF6 File Offset: 0x00B2A0F6
		public static APawn PawnOrSpectator
		{
			get
			{
				if ((Global._myPawnOrSpectator == null || !Global._myPawnOrSpectator.IsValid()) && GlobalData.GameInstance != null)
				{
					Global._myPawnOrSpectator = UGameplayStatics.GetPlayerPawn(GlobalData.World, 0);
				}
				return Global._myPawnOrSpectator;
			}
		}

		// Token: 0x0602F25E RID: 193118 RVA: 0x00B2BF28 File Offset: 0x00B2A128
		[NullableContext(1)]
		private static void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
		{
			if (GlobalData.GameInstance != null)
			{
				Global.CharacterController = (UGameplayStatics.GetPlayerController(GlobalData.World, 0) as TsCharacterController);
				Global.BaseCharacter = (UGameplayStatics.GetPlayerCharacter(GlobalData.World, 0) as TsBaseCharacter);
				Global._myCharacterCameraManager = UGameplayStatics.GetPlayerCameraManager(GlobalData.World, 0);
				Global._myPawnOrSpectator = UGameplayStatics.GetPlayerPawn(GlobalData.World, 0);
			}
		}

		// Token: 0x0602F25F RID: 193119 RVA: 0x00B2BF86 File Offset: 0x00B2A186
		[NullableContext(1)]
		public static bool IsControlledCharacter(AActor inActor)
		{
			return inActor is TsBaseCharacter && ((ACharacter)inActor).GetController() == Global.CharacterController;
		}

		// Token: 0x0602F260 RID: 193120 RVA: 0x00B2BFA4 File Offset: 0x00B2A1A4
		private static void BeforeLoadMap()
		{
			Global.CharacterController = null;
			Global.BaseCharacter = null;
			Global._myCharacterCameraManager = null;
			Global._myPawnOrSpectator = null;
		}

		// Token: 0x0602F261 RID: 193121 RVA: 0x00B2BFBE File Offset: 0x00B2A1BE
		private static void AfterLoadMap()
		{
			Global.CharacterController = (UGameplayStatics.GetPlayerController(GlobalData.World, 0) as TsCharacterController);
			Global._myCharacterCameraManager = UGameplayStatics.GetPlayerCameraManager(GlobalData.World, 0);
			Global._myPawnOrSpectator = UGameplayStatics.GetPlayerPawn(GlobalData.World, 0);
		}

		// Token: 0x0602F262 RID: 193122 RVA: 0x00B2BFF8 File Offset: 0x00B2A1F8
		public static void InitEvent()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnChangeRole;
			Action<EntityHandle, EntityHandle> handle;
			if ((handle = Global.<>O.<0>__OnChangeRole) == null)
			{
				handle = (Global.<>O.<0>__OnChangeRole = new Action<EntityHandle, EntityHandle>(Global.OnChangeRole));
			}
			instance.Add<EntityHandle, EntityHandle>(name, handle);
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.BeforeLoadMap;
			Action handle2;
			if ((handle2 = Global.<>O.<1>__BeforeLoadMap) == null)
			{
				handle2 = (Global.<>O.<1>__BeforeLoadMap = new Action(Global.BeforeLoadMap));
			}
			instance2.Add(name2, handle2);
			EventSystem instance3 = Singleton<EventSystem>.Instance;
			EEventName name3 = EEventName.AfterLoadMap;
			Action handle3;
			if ((handle3 = Global.<>O.<2>__AfterLoadMap) == null)
			{
				handle3 = (Global.<>O.<2>__AfterLoadMap = new Action(Global.AfterLoadMap));
			}
			instance3.Add(name3, handle3);
		}

		// Token: 0x0401ADAC RID: 109996
		private static TsBaseCharacter _myBaseCharacter;

		// Token: 0x0401ADAD RID: 109997
		private static TsCharacterController _myCharacterControllerInternal;

		// Token: 0x0401ADAE RID: 109998
		private static APlayerController _playerControllerInternal;

		// Token: 0x0401ADAF RID: 109999
		private static APlayerCameraManager _myCharacterCameraManager;

		// Token: 0x0401ADB0 RID: 110000
		private static APawn _myPawnOrSpectator;

		// Token: 0x0200A84D RID: 43085
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x040343FB RID: 214011
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<EntityHandle, EntityHandle> <0>__OnChangeRole;

			// Token: 0x040343FC RID: 214012
			[Nullable(0)]
			public static Action <1>__BeforeLoadMap;

			// Token: 0x040343FD RID: 214013
			[Nullable(0)]
			public static Action <2>__AfterLoadMap;
		}
	}
}
