using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.MingSu;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020025F8 RID: 9720
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PlayerInfoController : UiControllerBase<PlayerInfoController>
{
	// Token: 0x060130AF RID: 77999 RVA: 0x005477A3 File Offset: 0x005459A3
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<BasicInfoNotify>(ENotifyMessageId.BasicInfoNotify, new Action<BasicInfoNotify, Net.CallbackStatus>(this.BasicInfoNotifyHandle));
		Singleton<Net>.Instance.Register<PlayerAttrNotify>(ENotifyMessageId.PlayerAttrNotify, new Action<PlayerAttrNotify, Net.CallbackStatus>(this.PlayerAttrNotifyHandle));
	}

	// Token: 0x060130B0 RID: 78000 RVA: 0x005477DD File Offset: 0x005459DD
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BasicInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerAttrNotify);
	}

	// Token: 0x060130B1 RID: 78001 RVA: 0x00547800 File Offset: 0x00545A00
	private void BasicInfoNotifyHandle(BasicInfoNotify notify, Net.CallbackStatus status)
	{
		if (notify == null)
		{
			return;
		}
		ControllerBase<WorldLevelController>.Instance.OnBasicInfoNotify(notify.Attributes);
		PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.SetId(notify.Id);
		Singleton<LogAnalyzer>.Instance.SetPlayerId(notify.Id);
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		Dictionary<int, string> dictionary2 = new Dictionary<int, string>();
		foreach (PlayerAttr playerAttr in notify.Attributes)
		{
			if (playerAttr.ValueType == PlayerAttrType.Int32)
			{
				dictionary[(int)playerAttr.Key] = playerAttr.Int32Value;
			}
			else
			{
				dictionary2[(int)playerAttr.Key] = playerAttr.StringValue;
			}
		}
		instance.SetNumberProp(dictionary);
		instance.SetStringProp(dictionary2);
		instance.RandomSeed = notify.RandomSeed;
		ModelBase<MingSuModel>.Instance.UpdateDragonPoolInfoMap(notify.DragonPoolInfos);
		ModelBase<PersonalModel>.Instance.SetRoleShowList(notify.RoleShowList.ToList<Aki.Protocol.RoleShowEntry>());
		ModelBase<PersonalModel>.Instance.SetCurCardId(notify.CurCardId);
		ModelBase<PersonalModel>.Instance.SetBirthday(notify.Birthday);
		ModelBase<PersonalModel>.Instance.SetBirthdayDisplay(notify.DisplayBirthDay);
		ModelBase<PersonalModel>.Instance.SetCardUnlockList(notify.CardUnlockList.ToArray<CardShowEntry>());
		ModelBase<PersonalModel>.Instance.SetName(ModelBase<FunctionModel>.Instance.GetPlayerName());
		ModelBase<PersonalModel>.Instance.SetPlayerId(ModelBase<PlayerInfoModel>.Instance.GetId().Value);
		ModelBase<PersonalModel>.Instance.SetModifyNameInfo(notify.LastModifyNameTime, notify.ModifyName);
		int? numberPropById = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.HeadPhoto);
		ModelBase<PersonalModel>.Instance.SetHeadPhotoId(numberPropById.GetValueOrDefault());
		this.SetAudioPlayerGenderState();
		ControllerBase<LoginController>.Instance.SetIfFirstTimeLogin();
		if (Singleton<CloudGameManager>.Instance.IsCloudGame)
		{
			UKuroStaticLibrary.SetThreadAffinity("GameThread", 65535, 65280);
			UKuroStaticLibrary.SetThreadAffinity("RenderThread", 65535, 65520);
			UKuroStaticLibrary.SetThreadAffinity("RHIThread", 65535, 65520);
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "IsCloudGame affinity set", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android && notify.Id % 10 == 1)
		{
			string deviceCPU = UKuroStaticLibrary.GetDeviceCPU();
			if (deviceCPU.Contains("SM8475") || deviceCPU.Contains("SM8550") || deviceCPU.Contains("SM8650"))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Game;
				ELogAuthor author = ELogAuthor.WY;
				string message = "Disable affinity set";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cpu", deviceCPU);
				instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				UKuroStaticLibrary.SetThreadAffinity("GameThread", 65535, 65535);
				UKuroStaticLibrary.SetThreadAffinity("RenderThread", 65535, 65535);
				UKuroStaticLibrary.SetThreadAffinity("RHIThread", 65535, 65535);
				if (Singleton<PerfSight>.Instance.IsEnable)
				{
					Singleton<PerfSight>.Instance.PostEvent(500, "0");
				}
			}
		}
		else if (Singleton<PerfSight>.Instance.IsEnable)
		{
			Singleton<PerfSight>.Instance.PostEvent(500, "1");
		}
		ModelBase<PayShopModel>.Instance.BusinessCompliance = notify.BusinessCompliance;
		instance.NewbieGuideV2 = notify.NewbieGuideV2;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnGetPlayerBasicInfo);
	}

	// Token: 0x060130B2 RID: 78002 RVA: 0x00547B48 File Offset: 0x00545D48
	private void PlayerAttrNotifyHandle(PlayerAttrNotify notify, Net.CallbackStatus status)
	{
		if (notify == null)
		{
			return;
		}
		ControllerBase<WorldLevelController>.Instance.OnPlayerAttrNotify(notify.Attributes);
		if (ModelBase<PlayerInfoModel>.Instance == null)
		{
			return;
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		Dictionary<int, string> dictionary2 = new Dictionary<int, string>();
		foreach (PlayerAttr playerAttr in notify.Attributes)
		{
			if (playerAttr.ValueType == PlayerAttrType.Int32)
			{
				dictionary[(int)playerAttr.Key] = playerAttr.Int32Value;
			}
			else
			{
				dictionary2[(int)playerAttr.Key] = playerAttr.StringValue;
			}
		}
		ModelBase<PlayerInfoModel>.Instance.UpdatePlayerAttributeNumberInfo(dictionary);
		ModelBase<PlayerInfoModel>.Instance.UpdatePlayerAttributeStringInfo(dictionary2);
	}

	// Token: 0x060130B3 RID: 78003 RVA: 0x00547BFC File Offset: 0x00545DFC
	private void SetAudioPlayerGenderState()
	{
		int? numberPropById = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.Sex);
		if (numberPropById == null)
		{
			return;
		}
		if (!(numberPropById != 1))
		{
			Singleton<AudioSystem>.Instance.SetState("player_rover_gender", "male", true);
			return;
		}
		Singleton<AudioSystem>.Instance.SetState("player_rover_gender", "female", true);
	}
}
