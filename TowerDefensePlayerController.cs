using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.Fight.Enum;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.TowerDefenseEvent;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000F8E RID: 3982
[NullableContext(2)]
[Nullable(0)]
public class TowerDefensePlayerController : IStaticVariableResetter
{
	// Token: 0x170007DE RID: 2014
	// (get) Token: 0x06006540 RID: 25920 RVA: 0x00195632 File Offset: 0x00193832
	public static TowerDefensePlayerModel Model
	{
		get
		{
			return TowerDefensePlayerController.TDPlayerModel;
		}
	}

	// Token: 0x06006541 RID: 25921 RVA: 0x00195639 File Offset: 0x00193839
	static TowerDefensePlayerController()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TowerDefensePlayerController.CreateStaticDefaultValue), new Action(TowerDefensePlayerController.ResetStaticDefaultValue));
	}

	// Token: 0x06006542 RID: 25922 RVA: 0x00195658 File Offset: 0x00193858
	public static void CreateStaticDefaultValue()
	{
		TowerDefensePlayerController.TDPlayerModel = new TowerDefensePlayerModel();
		TowerDefensePlayerController.EKSC_REMOVE_REASON_FOLLOWER = new FName("Follower");
	}

	// Token: 0x06006543 RID: 25923 RVA: 0x00195673 File Offset: 0x00193873
	public static void ResetStaticDefaultValue()
	{
		TowerDefensePlayerController.TDPlayerModel = null;
		TowerDefensePlayerController.DelegateSkillCoolDown = null;
		TowerDefensePlayerController.DelegateSkillCoolDownChange = null;
		TowerDefensePlayerController.EKSC_REMOVE_REASON_FOLLOWER = null;
	}

	// Token: 0x06006544 RID: 25924 RVA: 0x00195692 File Offset: 0x00193892
	public static bool OnInit()
	{
		return true;
	}

	// Token: 0x06006545 RID: 25925 RVA: 0x00195698 File Offset: 0x00193898
	public static bool OnStart()
	{
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.OnPlayerFollowerEnableChange;
		Action<bool> handle;
		if ((handle = TowerDefensePlayerController.<>O.<0>__OnPlayerFollowerEnableChange) == null)
		{
			handle = (TowerDefensePlayerController.<>O.<0>__OnPlayerFollowerEnableChange = new Action<bool>(TowerDefensePlayerController.OnPlayerFollowerEnableChange));
		}
		if (!instance.Has(name, handle))
		{
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.OnPlayerFollowerEnableChange;
			Action<bool> handle2;
			if ((handle2 = TowerDefensePlayerController.<>O.<0>__OnPlayerFollowerEnableChange) == null)
			{
				handle2 = (TowerDefensePlayerController.<>O.<0>__OnPlayerFollowerEnableChange = new Action<bool>(TowerDefensePlayerController.OnPlayerFollowerEnableChange));
			}
			instance2.Add(name2, handle2);
		}
		EventSystem instance3 = Singleton<EventSystem>.Instance;
		EEventName name3 = EEventName.OnPlayerFollowerUnPossessed;
		Action handle3;
		if ((handle3 = TowerDefensePlayerController.<>O.<1>__OnPlayerFollowerUnPossessed) == null)
		{
			handle3 = (TowerDefensePlayerController.<>O.<1>__OnPlayerFollowerUnPossessed = new Action(TowerDefensePlayerController.OnPlayerFollowerUnPossessed));
		}
		if (!instance3.Has(name3, handle3))
		{
			EventSystem instance4 = Singleton<EventSystem>.Instance;
			EEventName name4 = EEventName.OnPlayerFollowerUnPossessed;
			Action handle4;
			if ((handle4 = TowerDefensePlayerController.<>O.<1>__OnPlayerFollowerUnPossessed) == null)
			{
				handle4 = (TowerDefensePlayerController.<>O.<1>__OnPlayerFollowerUnPossessed = new Action(TowerDefensePlayerController.OnPlayerFollowerUnPossessed));
			}
			instance4.Add(name4, handle4);
		}
		TowerDefensePlayerController.Model.PendingRoleHandle = TowerDefensePlayerController.GetPlayerEntityHandle();
		TowerDefensePlayerController.Model.TowerDefenseWorldDone = true;
		TowerDefensePlayerController.DoPossessRole(TowerDefensePlayerController.Model.PendingRoleHandle);
		EntityHandle playerFollowShooter = FollowUtils.GetPlayerFollowShooter(ModelBase<CreatureModel>.Instance.GetPlayerId());
		if (playerFollowShooter == null || !TowerDefensePlayerController.CheckPlayerFollowerMatch(playerFollowShooter))
		{
			EventSystem instance5 = Singleton<EventSystem>.Instance;
			EEventName name5 = EEventName.OnPlayerFollowerPossessed;
			Action<EntityHandle> handle5;
			if ((handle5 = TowerDefensePlayerController.<>O.<2>__OnPlayerFollowerPossessed) == null)
			{
				handle5 = (TowerDefensePlayerController.<>O.<2>__OnPlayerFollowerPossessed = new Action<EntityHandle>(TowerDefensePlayerController.OnPlayerFollowerPossessed));
			}
			if (!instance5.Has(name5, handle5))
			{
				EventSystem instance6 = Singleton<EventSystem>.Instance;
				EEventName name6 = EEventName.OnPlayerFollowerPossessed;
				Action<EntityHandle> handle6;
				if ((handle6 = TowerDefensePlayerController.<>O.<2>__OnPlayerFollowerPossessed) == null)
				{
					handle6 = (TowerDefensePlayerController.<>O.<2>__OnPlayerFollowerPossessed = new Action<EntityHandle>(TowerDefensePlayerController.OnPlayerFollowerPossessed));
				}
				instance6.Add(name6, handle6);
			}
		}
		else
		{
			TowerDefensePlayerController.OnPlayerFollowerPossessed(playerFollowShooter);
		}
		TowerDefensePlayerController.TryInitKSCEnityt();
		TowerDefensePlayerController.AddRouletteGameplayTag();
		return true;
	}

	// Token: 0x06006546 RID: 25926 RVA: 0x00195801 File Offset: 0x00193A01
	public static void SyncMainLocations(float delta)
	{
		KscEntityHandle possessedPlayerHandle = TowerDefensePlayerController.Model.PossessedPlayerHandle;
		if (possessedPlayerHandle != null)
		{
			possessedPlayerHandle.SyncEntityLocation();
		}
		KscEntityHandle possessedFollowerHandle = TowerDefensePlayerController.Model.PossessedFollowerHandle;
		if (possessedFollowerHandle == null)
		{
			return;
		}
		possessedFollowerHandle.SyncEntityLocation();
	}

	// Token: 0x06006547 RID: 25927 RVA: 0x0019582C File Offset: 0x00193A2C
	public static bool OnClear()
	{
		TowerDefensePlayerController.RemoveRouletteGameplayTag();
		TowerDefensePlayerController.ClearFollowerKSCData();
		TowerDefensePlayerController.TDPlayerModel = null;
		return true;
	}

	// Token: 0x06006548 RID: 25928 RVA: 0x00195840 File Offset: 0x00193A40
	public static bool OnStop()
	{
		TowerDefensePlayerController.RemoveRouletteGameplayTag();
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.OnPlayerFollowerEnableChange;
		Action<bool> handle;
		if ((handle = TowerDefensePlayerController.<>O.<0>__OnPlayerFollowerEnableChange) == null)
		{
			handle = (TowerDefensePlayerController.<>O.<0>__OnPlayerFollowerEnableChange = new Action<bool>(TowerDefensePlayerController.OnPlayerFollowerEnableChange));
		}
		if (instance.Has(name, handle))
		{
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.OnPlayerFollowerEnableChange;
			Action<bool> handle2;
			if ((handle2 = TowerDefensePlayerController.<>O.<0>__OnPlayerFollowerEnableChange) == null)
			{
				handle2 = (TowerDefensePlayerController.<>O.<0>__OnPlayerFollowerEnableChange = new Action<bool>(TowerDefensePlayerController.OnPlayerFollowerEnableChange));
			}
			instance2.Remove(name2, handle2);
		}
		EventSystem instance3 = Singleton<EventSystem>.Instance;
		EEventName name3 = EEventName.OnPlayerFollowerUnPossessed;
		Action handle3;
		if ((handle3 = TowerDefensePlayerController.<>O.<1>__OnPlayerFollowerUnPossessed) == null)
		{
			handle3 = (TowerDefensePlayerController.<>O.<1>__OnPlayerFollowerUnPossessed = new Action(TowerDefensePlayerController.OnPlayerFollowerUnPossessed));
		}
		if (instance3.Has(name3, handle3))
		{
			EventSystem instance4 = Singleton<EventSystem>.Instance;
			EEventName name4 = EEventName.OnPlayerFollowerUnPossessed;
			Action handle4;
			if ((handle4 = TowerDefensePlayerController.<>O.<1>__OnPlayerFollowerUnPossessed) == null)
			{
				handle4 = (TowerDefensePlayerController.<>O.<1>__OnPlayerFollowerUnPossessed = new Action(TowerDefensePlayerController.OnPlayerFollowerUnPossessed));
			}
			instance4.Remove(name4, handle4);
		}
		EventSystem instance5 = Singleton<EventSystem>.Instance;
		EEventName name5 = EEventName.OnPlayerFollowerPossessed;
		Action<EntityHandle> handle5;
		if ((handle5 = TowerDefensePlayerController.<>O.<2>__OnPlayerFollowerPossessed) == null)
		{
			handle5 = (TowerDefensePlayerController.<>O.<2>__OnPlayerFollowerPossessed = new Action<EntityHandle>(TowerDefensePlayerController.OnPlayerFollowerPossessed));
		}
		if (instance5.Has(name5, handle5))
		{
			EventSystem instance6 = Singleton<EventSystem>.Instance;
			EEventName name6 = EEventName.OnPlayerFollowerPossessed;
			Action<EntityHandle> handle6;
			if ((handle6 = TowerDefensePlayerController.<>O.<2>__OnPlayerFollowerPossessed) == null)
			{
				handle6 = (TowerDefensePlayerController.<>O.<2>__OnPlayerFollowerPossessed = new Action<EntityHandle>(TowerDefensePlayerController.OnPlayerFollowerPossessed));
			}
			instance6.Remove(name6, handle6);
		}
		TowerDefensePlayerController.ClearFollowerKSCData();
		TowerDefensePlayerModel model = TowerDefensePlayerController.Model;
		if (model != null)
		{
			model.OnStop();
		}
		return true;
	}

	// Token: 0x06006549 RID: 25929 RVA: 0x0019596E File Offset: 0x00193B6E
	[NullableContext(1)]
	public static bool CheckPlayerFollowerMatch(EntityHandle followerHandle)
	{
		return followerHandle.Entity.GetComponent<CreatureDataComponent>().TrapAuxiliaryConfigIds != null;
	}

	// Token: 0x0600654A RID: 25930 RVA: 0x00195984 File Offset: 0x00193B84
	public static EntityHandle GetPlayerEntityHandle()
	{
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		SceneTeamPlayer teamPlayerData = ModelBase<SceneTeamModel>.Instance.GetTeamPlayerData(playerId);
		long? num;
		if (teamPlayerData == null)
		{
			num = null;
		}
		else
		{
			SceneTeamGroup currentGroup = teamPlayerData.GetCurrentGroup();
			if (currentGroup == null)
			{
				num = null;
			}
			else
			{
				SceneTeamRole currentRole = currentGroup.GetCurrentRole();
				num = ((currentRole != null) ? new long?(currentRole.CreatureDataId) : null);
			}
		}
		long? num2 = num;
		return ModelBase<CreatureModel>.Instance.GetEntity(num2.GetValueOrDefault());
	}

	// Token: 0x0600654B RID: 25931 RVA: 0x001959FC File Offset: 0x00193BFC
	public static void TryInitKSCEnityt()
	{
		if (!TowerDefensePlayerController.Model.TowerDefenseWorldDone || TowerDefensePlayerController.Model.PendingFollowerCreatureId == null || TowerDefensePlayerController.Model.PendingFollowers == null)
		{
			KscLog.Debug(KscLog.EModule.Common, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "塔防尝试绑定辅助机KSC数据失败,等待世界加载或者实体加载", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (TowerDefensePlayerController.Model.HasInitKSCEntity)
		{
			KscLog.Debug(KscLog.EModule.Common, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "塔防尝试绑定辅助机KSC数据重复", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		TowerDefensePlayerController.Model.HasInitKSCEntity = true;
		TowerDefensePlayerController.Model.PossessedFollowerHandle = new KscEntityHandle(null, TowerDefensePlayerController.Model.PendingFollowerCreatureId.Value);
		TowerDefensePlayerController.DoPossessFollowerProxy(TowerDefensePlayerController.Model.PendingFollowers);
		if (TowerDefensePlayerController.Model.CurrentFollowerProxyId == null)
		{
			TowerDefenseFollowerProxy primaryPossessedFollowerProxy = TowerDefensePlayerController.GetPrimaryPossessedFollowerProxy();
			if (primaryPossessedFollowerProxy != null && primaryPossessedFollowerProxy.ProxyId != null)
			{
				TowerDefensePlayerController.SetFollowerProxy(primaryPossessedFollowerProxy.ProxyId.Value);
			}
		}
		else
		{
			TowerDefensePlayerController.SetFollowerProxy(TowerDefensePlayerController.Model.CurrentFollowerProxyId.Value);
		}
		TowerDefensePlayerController.EnablePlayerFollower(TowerDefensePlayerController.Model.CurrentFollowerEnable);
		TowerDefensePlayerController.DoPlayerFollowerEnableChange(TowerDefensePlayerController.Model.CurrentFollowerEnable);
		KscLog.Debug(KscLog.EModule.Common, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "塔防尝试绑定辅助机KSC数据成功", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600654C RID: 25932 RVA: 0x00195B44 File Offset: 0x00193D44
	[NullableContext(1)]
	private static void SetPendingFollowers(int[] proxyIds)
	{
		if (TowerDefensePlayerController.Model.PendingFollowers == null)
		{
			TowerDefensePlayerController.Model.PendingFollowers = Array.Empty<int>();
		}
		TowerDefensePlayerController.Model.PendingFollowers = proxyIds;
	}

	// Token: 0x0600654D RID: 25933 RVA: 0x00195B6C File Offset: 0x00193D6C
	public static void DoPossessRole(EntityHandle entityHandle)
	{
		if (Singleton<KscEnv>.Instance.KscWorld == null)
		{
			KscLog.Warn(KscLog.EModule.Common, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "塔防感知玩家角色,世界非法", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (entityHandle == null || !entityHandle.Valid)
		{
			KscLog.Warn(KscLog.EModule.Common, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "塔防感知玩家角色,entity非法", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		KscLog.EModule flag = KscLog.EModule.Common;
		ELogAuthor author = ELogAuthor.PZ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "塔防感知玩家角色";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Spawned Player", entityHandle.Id);
		KscLog.Info(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		TowerDefensePlayerController.DoPossessRole_Impl(entityHandle);
	}

	// Token: 0x0600654E RID: 25934 RVA: 0x00195C14 File Offset: 0x00193E14
	[NullableContext(1)]
	private unsafe static void DoPossessRole_Impl(EntityHandle entityHandle)
	{
		if (TowerDefensePlayerController.Model.PossessedPlayerHandle != null)
		{
			long creatureDataId = TowerDefensePlayerController.Model.PossessedPlayerHandle.CreatureDataId;
			TowerDefensePlayerController.Model.PossessedPlayerHandle.CreatureDataId = entityHandle.CreatureDataId;
			TowerDefenseInputController.AddInputLayer();
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.PZ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "塔防绑定玩家战斗实体刷新";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("old creature", creatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("new creature", entityHandle.CreatureDataId);
			KscLog.Info(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		TowerDefenseInputController.AddInputLayer();
		if (entityHandle.Entity != null)
		{
			CharacterActorComponent component = entityHandle.Entity.GetComponent<CharacterActorComponent>();
			TsBaseCharacter tsBaseCharacter = (component != null) ? component.Actor : null;
			FTransformDouble transform = (tsBaseCharacter != null) ? tsBaseCharacter.D_GetTransform() : new FTransformDouble();
			ControllerBase<KuroSimpleCombatController>.Instance.AddEntityDt(entityHandle.CreatureDataId, TowerDefensePlayerModel.PlayerEntityKey, null, transform, delegate(AKSC_Entity kscEntity)
			{
				TowerDefensePlayerController.Model.PossessedPlayerHandle = new KscEntityHandle(kscEntity, entityHandle.CreatureDataId);
				KscLog.EModule flag2 = KscLog.EModule.Common;
				ELogAuthor author2 = ELogAuthor.PZ;
				UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
				string log2 = "塔防绑定玩家战斗实体";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("entity", entityHandle.Entity);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("creature", entityHandle.CreatureDataId);
				KscLog.Info(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			});
			return;
		}
		KscLog.Warn(KscLog.EModule.Common, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "塔防绑定玩家战斗实体失败", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600654F RID: 25935 RVA: 0x00195D6C File Offset: 0x00193F6C
	public static KscEntityHandle GetPossessedPlayer()
	{
		TowerDefensePlayerModel model = TowerDefensePlayerController.Model;
		if (model == null)
		{
			return null;
		}
		return model.PossessedPlayerHandle;
	}

	// Token: 0x06006550 RID: 25936 RVA: 0x00195D7E File Offset: 0x00193F7E
	public static EntityHandle GetPossessedPlayerEntity()
	{
		TowerDefensePlayerModel model = TowerDefensePlayerController.Model;
		if (model == null)
		{
			return null;
		}
		return model.PendingRoleHandle;
	}

	// Token: 0x06006551 RID: 25937 RVA: 0x00195D90 File Offset: 0x00193F90
	[NullableContext(1)]
	private static void DoPossessFollowerProxy(int[] proxyIds)
	{
		if (TowerDefensePlayerController.Model.PossessedFollowerProxies == null)
		{
			TowerDefensePlayerController.Model.PossessedFollowerProxies = new Dictionary<int, TowerDefenseFollowerProxy>();
		}
		TowerDefensePlayerController.Model.PossessedFollowerProxies.Clear();
		foreach (int num in proxyIds)
		{
			TowerDefenseFollowerProxy towerDefenseFollowerProxy = new TowerDefenseFollowerProxy(new int?(num));
			int[] followerSkillIdsByProxy = KscUtil.GetFollowerSkillIdsByProxy(num);
			int? followerPropertyIdByProxy = KscUtil.GetFollowerPropertyIdByProxy(num);
			towerDefenseFollowerProxy.SkillIds = followerSkillIdsByProxy;
			towerDefenseFollowerProxy.PropertyId = followerPropertyIdByProxy;
			TowerDefensePlayerController.Model.PossessedFollowerProxies[num] = towerDefenseFollowerProxy;
		}
	}

	// Token: 0x06006552 RID: 25938 RVA: 0x00195E18 File Offset: 0x00194018
	private static TowerDefenseFollowerProxy GetPossessedFollowerProxy(int proxyId)
	{
		Dictionary<int, TowerDefenseFollowerProxy> possessedFollowerProxies = TowerDefensePlayerController.Model.PossessedFollowerProxies;
		TowerDefenseFollowerProxy result;
		if (possessedFollowerProxies == null || !possessedFollowerProxies.TryGetValue(proxyId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06006553 RID: 25939 RVA: 0x00195E44 File Offset: 0x00194044
	private static TowerDefenseFollowerProxy GetPrimaryPossessedFollowerProxy()
	{
		if (TowerDefensePlayerController.Model.PossessedFollowerProxies == null)
		{
			return null;
		}
		using (Dictionary<int, TowerDefenseFollowerProxy>.Enumerator enumerator = TowerDefensePlayerController.Model.PossessedFollowerProxies.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				KeyValuePair<int, TowerDefenseFollowerProxy> keyValuePair = enumerator.Current;
				return TowerDefensePlayerController.GetPossessedFollowerProxy(keyValuePair.Key);
			}
		}
		return null;
	}

	// Token: 0x06006554 RID: 25940 RVA: 0x00195EB4 File Offset: 0x001940B4
	private static void AddRouletteGameplayTag()
	{
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(playerId);
		if (playerEntity == null)
		{
			return;
		}
		BaseTagComponent component = playerEntity.GetComponent<BaseTagComponent>();
		if (component == null)
		{
			return;
		}
		component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["TowerDefence.轮盘"]));
	}

	// Token: 0x06006555 RID: 25941 RVA: 0x00195F00 File Offset: 0x00194100
	private static void RemoveRouletteGameplayTag()
	{
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(playerId);
		if (playerEntity == null)
		{
			return;
		}
		BaseTagComponent component = playerEntity.GetComponent<BaseTagComponent>();
		if (component == null)
		{
			return;
		}
		component.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["TowerDefence.轮盘"]));
	}

	// Token: 0x06006556 RID: 25942 RVA: 0x00195F4C File Offset: 0x0019414C
	private static void OnPlayerFollowerEnableChange(bool isEnable)
	{
		if (Singleton<KscEnv>.Instance.KscWorld == null)
		{
			return;
		}
		TowerDefensePlayerController.DoPlayerFollowerEnableChange(isEnable);
	}

	// Token: 0x06006557 RID: 25943 RVA: 0x00195F61 File Offset: 0x00194161
	[NullableContext(1)]
	private static void OnPlayerFollowerPossessed(EntityHandle followerHandle)
	{
		TowerDefensePlayerController.DoPlayerFollowerCreate(followerHandle);
	}

	// Token: 0x06006558 RID: 25944 RVA: 0x00195F69 File Offset: 0x00194169
	private static void OnPlayerFollowerUnPossessed()
	{
		TowerDefensePlayerController.DoPlayerFollowerDestroy();
	}

	// Token: 0x06006559 RID: 25945 RVA: 0x00195F70 File Offset: 0x00194170
	public static void TogglePlayerFollower()
	{
		TowerDefensePlayerController.EnablePlayerFollower(!TowerDefensePlayerController.IsPlayerFollowerEnabled());
	}

	// Token: 0x0600655A RID: 25946 RVA: 0x00195F7F File Offset: 0x0019417F
	public static void EnablePlayerFollower(bool isEnable)
	{
		TowerDefensePlayerController.Model.CurrentFollowerEnable = isEnable;
		FollowUtils.SetPlayerFollowShooterEnable(ModelBase<CreatureModel>.Instance.GetPlayerId(), isEnable, BPEEnableFollowShooter.GameAbility, "");
		if (!isEnable)
		{
			TowerDefensePlayerController.RemoveChargeEffect();
			TowerDefensePlayerController.SetFollowerSKillAutoCast(false, true);
		}
	}

	// Token: 0x0600655B RID: 25947 RVA: 0x00195FB4 File Offset: 0x001941B4
	public unsafe static void DoPlayerFollowerEnableChange(bool isEnable)
	{
		if (isEnable)
		{
			KscEntityHandle possessedFollowerHandle = TowerDefensePlayerController.Model.PossessedFollowerHandle;
			if (possessedFollowerHandle != null && !possessedFollowerHandle.Valid && !TowerDefensePlayerController.Model.IsInFollowerInit)
			{
				long creatureDataId = TowerDefensePlayerController.Model.PossessedFollowerHandle.CreatureDataId;
				EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
				WorldEntity entity = (entity2 != null) ? entity2.Entity : null;
				if (entity == null)
				{
					KscLog.EModule flag = KscLog.EModule.Common;
					ELogAuthor author = ELogAuthor.PZ;
					UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
					string log = "塔防跟随物更新可用性;绑定实体不存在";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("creatureId", creatureDataId);
					KscLog.Warn(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				KscLog.EModule flag2 = KscLog.EModule.Common;
				ELogAuthor author2 = ELogAuthor.PZ;
				UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
				string log2 = "塔防跟随物更新";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entity", entity);
				KscLog.Info(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
				TsBaseCharacter tsBaseCharacter = (component != null) ? component.Actor : null;
				FTransformDouble transform = (tsBaseCharacter != null) ? tsBaseCharacter.D_GetTransform() : new FTransformDouble();
				ValueTuple<FKSCEntityTableRow, string> valueTuple3;
				ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel.EntityDataDt.TryGetValue(TowerDefensePlayerModel.FollowerEntityKey, out valueTuple3);
				string item = valueTuple3.Item2;
				CreatureDataComponent component2 = entity.GetComponent<CreatureDataComponent>();
				EntityComponentPb entityComponentPb;
				SimpleCombatComponentPb combatComponent = component2.ComponentDataMap.TryGetValue("SimpleCombatComponentPb", out entityComponentPb) ? ((entityComponentPb != null) ? entityComponentPb.SimpleCombatComponentPb : null) : null;
				if (!string.IsNullOrEmpty(item))
				{
					TowerDefensePlayerController.Model.IsInFollowerInit = true;
					KuroSimpleCombatController instance = ControllerBase<KuroSimpleCombatController>.Instance;
					KscEntityParam kscEntityParam = new KscEntityParam();
					kscEntityParam.CreatureId = creatureDataId;
					kscEntityParam.SimpleCombatId = TowerDefensePlayerModel.FollowerEntityKey;
					kscEntityParam.AssetPath = item;
					kscEntityParam.PropertyId = 0;
					kscEntityParam.Transform = transform;
					SimpleCombatComponentPb combatComponent3 = combatComponent;
					kscEntityParam.Buffs = ((combatComponent3 != null) ? combatComponent3.BuffLayers.ToDictionary<int, int>() : null);
					kscEntityParam.FinishCallback = delegate(AKSC_Entity kscEntity)
					{
						KscLog.EModule flag4 = KscLog.EModule.Common;
						ELogAuthor author4 = ELogAuthor.PZ;
						UObject kscWorld4 = Singleton<KscEnv>.Instance.KscWorld;
						string log4 = "塔防跟随物绑定";
						<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("entity", entity);
						ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
						string item3 = "buff";
						SimpleCombatComponentPb combatComponent2 = combatComponent;
						ptr2 = new ValueTuple<string, object>(item3, (combatComponent2 != null) ? combatComponent2.BuffLayers : null);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("kscHandle", TowerDefensePlayerController.Model.PossessedFollowerHandle);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("kscEntity", kscEntity);
						KscLog.Info(flag4, author4, kscWorld4, log4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
						KscEntityHandle possessedFollowerHandle3 = TowerDefensePlayerController.Model.PossessedFollowerHandle;
						if (possessedFollowerHandle3 != null)
						{
							possessedFollowerHandle3.SetKscEntity(kscEntity);
						}
						TowerDefensePlayerController.InitAllFollowerSkill();
						TowerDefensePlayerController.RefreshFollowerData();
						TowerDefensePlayerController.ListenFollowerCDAttribute();
						TowerDefensePlayerController.Model.IsInFollowerInit = false;
					};
					instance.AsyncAddEntity(kscEntityParam);
					return;
				}
				return;
			}
		}
		KscLog.EModule flag3 = KscLog.EModule.Common;
		ELogAuthor author3 = ELogAuthor.PZ;
		UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
		string log3 = "塔防跟随物更新可用性";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isEnable", isEnable);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item2 = "kscValid";
		KscEntityHandle possessedFollowerHandle2 = TowerDefensePlayerController.Model.PossessedFollowerHandle;
		ptr = new ValueTuple<string, object>(item2, (possessedFollowerHandle2 != null) ? new bool?(possessedFollowerHandle2.Valid) : null);
		KscLog.Info(flag3, author3, kscWorld3, log3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		AKSC_Entity_AssistMachine possessedFollowerKscEntity = TowerDefensePlayerController.Model.PossessedFollowerKscEntity;
		if (possessedFollowerKscEntity != null)
		{
			possessedFollowerKscEntity.SetActorHiddenInGame(!isEnable);
			TArray<AActor> tarray = new TArray<AActor>();
			possessedFollowerKscEntity.GetAttachedActors(ref tarray, true);
			for (int i = 0; i < tarray.Num(); i++)
			{
				tarray.Get(i).SetActorHiddenInGame(!isEnable);
			}
		}
	}

	// Token: 0x0600655C RID: 25948 RVA: 0x0019627C File Offset: 0x0019447C
	private unsafe static void InitAllFollowerSkill()
	{
		Dictionary<string, int> followerSkillName2Index = TowerDefensePlayerController.GetFollowerSkillName2Index(TowerDefensePlayerController.Model.PossessedFollowerKscEntity);
		if (followerSkillName2Index == null)
		{
			KscLog.Warn(KscLog.EModule.Skill, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "辅助机技能索引异常", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Dictionary<int, ValueTuple<FKSCSkillTableRow, string>> allSkillDataDt = ControllerBase<KuroSimpleCombatController>.Instance.GetAllSkillDataDt();
		if (TowerDefensePlayerController.Model.AllSkillId2SkillData == null)
		{
			TowerDefensePlayerController.Model.AllSkillId2SkillData = new Dictionary<int, TDPlayerDefine.ISkill>();
		}
		else
		{
			TowerDefensePlayerController.Model.AllSkillId2SkillData.Clear();
		}
		foreach (KeyValuePair<int, ValueTuple<FKSCSkillTableRow, string>> keyValuePair in allSkillDataDt)
		{
			FKSCSkillTableRow item = keyValuePair.Value.Item1;
			string item2 = keyValuePair.Value.Item2;
			int id = item.Id;
			int skillId = item.SkillId;
			EKSC_OperateType operateType = item.OperateType;
			if (skillId > 0)
			{
				KscLog.EModule flag = KscLog.EModule.Skill;
				ELogAuthor author = ELogAuthor.PZ;
				UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
				string log = "跟随物技能初始化MontageSkill";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("rid", id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("operateType", operateType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SkillId", skillId);
				KscLog.Debug(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				TDPlayerDefine.Skill value = new TDPlayerDefine.Skill
				{
					SkillType = TDPlayerDefine.ESkillType.MontageSkill,
					SkillId = skillId,
					Time = item.PressTime,
					ChargeCueId = item.ChargeCueId,
					ChargeFullCueId = item.ChargeFullCueId,
					PsFeedback = item.PsFeedbackId,
					OperateType = item.OperateType
				};
				TowerDefensePlayerController.Model.AllSkillId2SkillData[id] = value;
			}
			else
			{
				string text = KscUtil.AssetPath2Name(item2);
				int num;
				if (string.IsNullOrEmpty(text))
				{
					KscLog.EModule flag2 = KscLog.EModule.Skill;
					ELogAuthor author2 = ELogAuthor.PZ;
					UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
					string log2 = "跟随物技能初始化忽略,名称异常";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("rowId", id);
					KscLog.Info(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else if (!followerSkillName2Index.TryGetValue(text, out num))
				{
					KscLog.EModule flag3 = KscLog.EModule.Skill;
					ELogAuthor author3 = ELogAuthor.PZ;
					UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
					string log3 = "跟随物技能初始化忽略,索引异常";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("rowId", id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("name", text);
					KscLog.Info(flag3, author3, kscWorld3, log3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				else
				{
					KscLog.EModule flag4 = KscLog.EModule.Skill;
					ELogAuthor author4 = ELogAuthor.PZ;
					UObject kscWorld4 = Singleton<KscEnv>.Instance.KscWorld;
					string log4 = "跟随物技能初始化";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("rid", id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("name", text);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("index", num);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("operateType", operateType);
					KscLog.Debug(flag4, author4, kscWorld4, log4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
					TDPlayerDefine.Skill value2 = new TDPlayerDefine.Skill
					{
						SkillType = TDPlayerDefine.ESkillType.KscSkill,
						SkillId = num,
						Time = item.PressTime,
						ChargeCueId = item.ChargeCueId,
						ChargeFullCueId = item.ChargeFullCueId,
						PsFeedback = item.PsFeedbackId,
						OperateType = item.OperateType
					};
					TowerDefensePlayerController.Model.AllSkillId2SkillData[id] = value2;
				}
			}
		}
	}

	// Token: 0x0600655D RID: 25949 RVA: 0x0019662C File Offset: 0x0019482C
	public unsafe static void SetFollowerProxy(int proxyId)
	{
		TowerDefensePlayerController.Model.CurrentFollowerProxyId = new int?(proxyId);
		if (TowerDefensePlayerController.Model.PossessedFollowerProxies == null)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.PZ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "塔防辅助机数据未初始化完成,等待初始化完成";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", proxyId);
			KscLog.Info(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (TowerDefensePlayerController.Model.PossessedFollowerProxies.Count <= 0)
		{
			KscLog.EModule flag2 = KscLog.EModule.Common;
			ELogAuthor author2 = ELogAuthor.PZ;
			UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			string log2 = "塔防辅助机切换索引异常,没有捕获数据";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("id", proxyId);
			KscLog.Warn(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		TowerDefenseFollowerProxy item;
		if (!TowerDefensePlayerController.Model.PossessedFollowerProxies.TryGetValue(proxyId, out item))
		{
			KscLog.EModule flag3 = KscLog.EModule.Common;
			ELogAuthor author3 = ELogAuthor.PZ;
			UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
			string log3 = "塔防辅助机切换索引异常,找不到id";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("id", proxyId);
			KscLog.Warn(flag3, author3, kscWorld3, log3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return;
		}
		KscLog.EModule flag4 = KscLog.EModule.Common;
		ELogAuthor author4 = ELogAuthor.PZ;
		UObject kscWorld4 = Singleton<KscEnv>.Instance.KscWorld;
		string log4 = "塔防辅助机切换索引";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("proxy id", proxyId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("proxy", item);
		KscLog.Info(flag4, author4, kscWorld4, log4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		TowerDefensePlayerController.RefreshFollowerData();
		float followerSkillRemainCD = TowerDefensePlayerController.GetFollowerSkillRemainCD(proxyId);
		KscLog.EModule flag5 = KscLog.EModule.Common;
		ELogAuthor author5 = ELogAuthor.PZ;
		UObject kscWorld5 = Singleton<KscEnv>.Instance.KscWorld;
		string log5 = "TZQ Debug";
		ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("cd", followerSkillRemainCD);
		KscLog.Info(flag5, author5, kscWorld5, log5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
	}

	// Token: 0x0600655E RID: 25950 RVA: 0x001967A8 File Offset: 0x001949A8
	public static int? GetFollowerProxyId()
	{
		TowerDefensePlayerModel model = TowerDefensePlayerController.Model;
		if (model == null)
		{
			return null;
		}
		return model.CurrentFollowerProxyId;
	}

	// Token: 0x0600655F RID: 25951 RVA: 0x001967D0 File Offset: 0x001949D0
	private static void RefreshFollowerData()
	{
		TowerDefensePlayerController.UnBindFollowerOperateSkills();
		AKSC_Entity_AssistMachine possessedFollowerKscEntity = TowerDefensePlayerController.Model.PossessedFollowerKscEntity;
		TowerDefensePlayerController.BindFollowerOperateSkills(possessedFollowerKscEntity, TowerDefensePlayerController.Model.CurrentFollowerProxyId);
		TowerDefensePlayerController.BindFollowerAttrs(possessedFollowerKscEntity, TowerDefensePlayerController.Model.CurrentFollowerProxyId);
		TowerDefensePlayerController.SetListenSkillCD(possessedFollowerKscEntity, TowerDefensePlayerController.Model.CurrentFollowerProxyId);
		TowerDefensePlayerController.UpdateFollowMontageSkillCD();
		TowerDefensePlayerController.RemoveChargeEffect();
		TowerDefensePlayerController.RefreshFollowerCue();
		TowerDefensePlayerController.SetFollowerState(TDPlayerDefine.EFollowerState.None);
		TowerDefensePlayerController.ClearFollowerCdCue();
		TowerDefensePlayerController.RefreshFolloerCdCue(null);
		TowerDefensePlayerController.Model.IsInCharge = false;
	}

	// Token: 0x06006560 RID: 25952 RVA: 0x00196846 File Offset: 0x00194A46
	public static bool IsPlayerFollowerEnabled()
	{
		return TowerDefensePlayerController.Model.PossessedFollowerEnabled;
	}

	// Token: 0x06006561 RID: 25953 RVA: 0x00196854 File Offset: 0x00194A54
	public unsafe static void DoPlayerFollowerCreate(EntityHandle followerHandle)
	{
		if (followerHandle == null)
		{
			KscLog.Warn(KscLog.EModule.Common, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "塔防跟随物记录Id失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		long creatureDataId = followerHandle.CreatureDataId;
		int[] trapAuxiliaryConfigIds = followerHandle.Entity.GetComponent<CreatureDataComponent>().TrapAuxiliaryConfigIds;
		if (trapAuxiliaryConfigIds == null)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.PZ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "塔防辅助机监听创建不匹配";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entity", followerHandle.Entity);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("creatureId", followerHandle.CreatureDataId);
			KscLog.Info(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		KscLog.EModule flag2 = KscLog.EModule.Common;
		ELogAuthor author2 = ELogAuthor.PZ;
		UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
		string log2 = "检测到塔防辅助机实体加入";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("entity", followerHandle.Entity);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("configs", trapAuxiliaryConfigIds);
		KscLog.Info(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		TowerDefensePlayerController.Model.PendingFollowerCreatureId = new long?(followerHandle.CreatureDataId);
		TowerDefensePlayerController.SetPendingFollowers(trapAuxiliaryConfigIds);
		TowerDefensePlayerController.TryInitKSCEnityt();
	}

	// Token: 0x06006562 RID: 25954 RVA: 0x00196988 File Offset: 0x00194B88
	public unsafe static void DoPlayerFollowerDestroy()
	{
		KscEntityHandle possessedFollowerHandle = TowerDefensePlayerController.Model.PossessedFollowerHandle;
		long? num = (possessedFollowerHandle != null) ? new long?(possessedFollowerHandle.CreatureDataId) : null;
		KscLog.EModule flag = KscLog.EModule.Common;
		ELogAuthor author = ELogAuthor.PZ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "塔防跟随物移除战斗实体";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureId", num);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "kscEntity";
		KscEntityHandle possessedFollowerHandle2 = TowerDefensePlayerController.Model.PossessedFollowerHandle;
		ptr = new ValueTuple<string, object>(item, (possessedFollowerHandle2 != null) ? possessedFollowerHandle2.KscEntity : null);
		KscLog.Info(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (num != null)
		{
			ControllerBase<KuroSimpleCombatController>.Instance.RemoveEntity(num.Value, TowerDefensePlayerController.EKSC_REMOVE_REASON_FOLLOWER);
		}
		TowerDefensePlayerController.Model.PossessedFollowerHandle = null;
		TowerDefensePlayerController.UnBindFollowerOperateSkills();
	}

	// Token: 0x06006563 RID: 25955 RVA: 0x00196A59 File Offset: 0x00194C59
	public static void D_Fire(FTransformDouble transform, int skillIndex)
	{
		AKSC_Entity_AssistMachine possessedFollowerKscEntity = TowerDefensePlayerController.Model.PossessedFollowerKscEntity;
		if (possessedFollowerKscEntity == null)
		{
			return;
		}
		possessedFollowerKscEntity.D_Fire(transform, skillIndex);
	}

	// Token: 0x06006564 RID: 25956 RVA: 0x00196A72 File Offset: 0x00194C72
	[NullableContext(1)]
	public static void BeginSkillFollower(TDPlayerDefine.ISkill skillData)
	{
		if (skillData.SkillType == TDPlayerDefine.ESkillType.KscSkill)
		{
			TowerDefensePlayerController.BeginKSCSkillFollower(skillData);
			return;
		}
		TowerDefensePlayerController.BeginMontageSkillFollower(skillData);
	}

	// Token: 0x06006565 RID: 25957 RVA: 0x00196A8C File Offset: 0x00194C8C
	[NullableContext(1)]
	public static void BeginKSCSkillFollower(TDPlayerDefine.ISkill skillData)
	{
		AActor possessedFollowerActor = TowerDefensePlayerController.Model.PossessedFollowerActor;
		if (possessedFollowerActor != null)
		{
			TowerDefensePlayerController.D_Fire(possessedFollowerActor.D_GetTransform(), skillData.SkillId);
		}
	}

	// Token: 0x06006566 RID: 25958 RVA: 0x00196AB8 File Offset: 0x00194CB8
	[NullableContext(1)]
	private static void DispatchEnterCD(TDPlayerDefine.ISkill skillData, CharacterSkillCdComponent skillCDComp)
	{
		if (TowerDefensePlayerController.Model.CurrentFollowerProxyId == null)
		{
			return;
		}
		TDPlayerDefine.ISkill followListenSkillData = TowerDefensePlayerController.GetFollowListenSkillData(TowerDefensePlayerController.Model.CurrentFollowerProxyId.Value);
		if (followListenSkillData == null || followListenSkillData != skillData)
		{
			return;
		}
		float? num;
		if (skillCDComp == null)
		{
			num = null;
		}
		else
		{
			GroupSkillCdInfo groupSkillCdInfo = skillCDComp.GetGroupSkillCdInfo(skillData.SkillId);
			num = ((groupSkillCdInfo != null) ? new float?(groupSkillCdInfo.CurMaxCd) : null);
		}
		float? num2 = num;
		if (num2 != null)
		{
			float? num3 = num2;
			float num4 = 0f;
			if (num3.GetValueOrDefault() > num4 & num3 != null)
			{
				TowerDefensePlayerController.OnFollowerEnterSkillCd(0, num2.Value);
			}
		}
	}

	// Token: 0x06006567 RID: 25959 RVA: 0x00196B5C File Offset: 0x00194D5C
	[NullableContext(1)]
	public static void BeginMontageSkillFollower(TDPlayerDefine.ISkill skillData)
	{
		int skillId = skillData.SkillId;
		Entity possessedFollowerEntity = TowerDefensePlayerController.Model.PossessedFollowerEntity;
		BaseSkillComponent baseSkillComponent = (possessedFollowerEntity != null) ? possessedFollowerEntity.GetComponent<BaseSkillComponent>() : null;
		Entity possessedFollowerEntity2 = TowerDefensePlayerController.Model.PossessedFollowerEntity;
		CharacterSkillCdComponent characterSkillCdComponent = (possessedFollowerEntity2 != null) ? possessedFollowerEntity2.GetComponent<CharacterSkillCdComponent>() : null;
		if (baseSkillComponent == null || characterSkillCdComponent == null || characterSkillCdComponent.IsSkillInCd(skillId, true) || !baseSkillComponent.Active)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "塔防辅助机:释放技能return";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Active", (baseSkillComponent != null) ? new bool?(baseSkillComponent.Active) : null);
			KscLog.Debug(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		TowerDefensePlayerController.BeginMontageSkillFollowerAsync(skillData, baseSkillComponent, characterSkillCdComponent).Forget();
	}

	// Token: 0x06006568 RID: 25960 RVA: 0x00196C10 File Offset: 0x00194E10
	[NullableContext(1)]
	private static UniTask BeginMontageSkillFollowerAsync(TDPlayerDefine.ISkill skillData, BaseSkillComponent skillComp, CharacterSkillCdComponent skillCDComp)
	{
		TowerDefensePlayerController.<BeginMontageSkillFollowerAsync>d__45 <BeginMontageSkillFollowerAsync>d__;
		<BeginMontageSkillFollowerAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<BeginMontageSkillFollowerAsync>d__.skillData = skillData;
		<BeginMontageSkillFollowerAsync>d__.skillComp = skillComp;
		<BeginMontageSkillFollowerAsync>d__.skillCDComp = skillCDComp;
		<BeginMontageSkillFollowerAsync>d__.<>1__state = -1;
		<BeginMontageSkillFollowerAsync>d__.<>t__builder.Start<TowerDefensePlayerController.<BeginMontageSkillFollowerAsync>d__45>(ref <BeginMontageSkillFollowerAsync>d__);
		return <BeginMontageSkillFollowerAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006569 RID: 25961 RVA: 0x00196C64 File Offset: 0x00194E64
	public static TDPlayerDefine.ISkill GetFollowerSkillByOperateType(EKSC_OperateType operateType, float time)
	{
		if (TowerDefensePlayerController.Model.BindFollowerSkills == null || TowerDefensePlayerController.Model.BindFollowerSkills.Count == 0)
		{
			return null;
		}
		List<TDPlayerDefine.ISkill> list;
		if (!TowerDefensePlayerController.Model.BindFollowerSkills.TryGetValue(operateType, out list))
		{
			return null;
		}
		foreach (TDPlayerDefine.ISkill skill in list)
		{
			if (time >= skill.Time)
			{
				return skill;
			}
		}
		return null;
	}

	// Token: 0x0600656A RID: 25962 RVA: 0x00196CF0 File Offset: 0x00194EF0
	private static void TryBeginMontageSkillFollower()
	{
		List<TDPlayerDefine.ISkill> list;
		if (TowerDefensePlayerController.Model.BindFollowerSkills == null || !TowerDefensePlayerController.Model.BindFollowerSkills.TryGetValue(EKSC_OperateType.AutoCast, out list) || list == null)
		{
			return;
		}
		foreach (TDPlayerDefine.ISkill skill in list)
		{
			if (skill.SkillType == TDPlayerDefine.ESkillType.MontageSkill)
			{
				TowerDefensePlayerController.BeginMontageSkillFollower(skill);
			}
		}
	}

	// Token: 0x0600656B RID: 25963 RVA: 0x00196D6C File Offset: 0x00194F6C
	[NullableContext(1)]
	public static void OnCharSkillCountChanged(GroupSkillCdInfo cdInfo)
	{
		TowerDefensePlayerController.TryBeginMontageSkillFollower();
	}

	// Token: 0x0600656C RID: 25964 RVA: 0x00196D73 File Offset: 0x00194F73
	public static void OnFollowerMontageSkillEnd(int entityId, int skillId)
	{
		TowerDefensePlayerController.TryBeginMontageSkillFollower();
	}

	// Token: 0x0600656D RID: 25965 RVA: 0x00196D7C File Offset: 0x00194F7C
	public static void SetFollowerSKillAutoCast(bool bEnable, bool bForce)
	{
		if (TowerDefensePlayerController.Model.IsInAutoCast == bEnable && !bForce)
		{
			return;
		}
		TowerDefensePlayerController.Model.IsInAutoCast = bEnable;
		KscLog.EModule flag = KscLog.EModule.Input;
		ELogAuthor author = ELogAuthor.TZQ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "塔防辅助机:自动射击";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bEnable", bEnable);
		KscLog.Debug(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		bool flag2 = false;
		List<TDPlayerDefine.ISkill> list;
		if (TowerDefensePlayerController.Model.BindFollowerSkills == null || !TowerDefensePlayerController.Model.BindFollowerSkills.TryGetValue(EKSC_OperateType.AutoCast, out list) || list == null)
		{
			return;
		}
		AKSC_Entity_AssistMachine possessedFollowerKscEntity = TowerDefensePlayerController.Model.PossessedFollowerKscEntity;
		Entity possessedFollowerEntity = TowerDefensePlayerController.Model.PossessedFollowerEntity;
		if (possessedFollowerKscEntity == null || possessedFollowerEntity == null)
		{
			KscLog.Warn(KscLog.EModule.Input, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "塔防辅助机:自动射击更改失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		foreach (TDPlayerDefine.ISkill skill in list)
		{
			if (skill.SkillType == TDPlayerDefine.ESkillType.MontageSkill)
			{
				if (bEnable)
				{
					TowerDefensePlayerController.BeginMontageSkillFollower(skill);
				}
				flag2 = true;
			}
			else
			{
				AKSC_Entity_AssistMachine aksc_Entity_AssistMachine = possessedFollowerKscEntity;
				int skillId = skill.SkillId;
				aksc_Entity_AssistMachine.SetSkillAutoCast(skillId, bEnable ? EKSC_SkillAutoCast.AutoCast : EKSC_SkillAutoCast.ManualCast);
			}
		}
		if (flag2 || bForce)
		{
			if (bEnable)
			{
				EventSystem instance = Singleton<EventSystem>.Instance;
				EEventName name = EEventName.CharSkillCountChanged;
				Action<GroupSkillCdInfo> handle;
				if ((handle = TowerDefensePlayerController.<>O.<3>__OnCharSkillCountChanged) == null)
				{
					handle = (TowerDefensePlayerController.<>O.<3>__OnCharSkillCountChanged = new Action<GroupSkillCdInfo>(TowerDefensePlayerController.OnCharSkillCountChanged));
				}
				if (!instance.Has<GroupSkillCdInfo>(name, handle))
				{
					EventSystem instance2 = Singleton<EventSystem>.Instance;
					EEventName name2 = EEventName.CharSkillCountChanged;
					Action<GroupSkillCdInfo> handle2;
					if ((handle2 = TowerDefensePlayerController.<>O.<3>__OnCharSkillCountChanged) == null)
					{
						handle2 = (TowerDefensePlayerController.<>O.<3>__OnCharSkillCountChanged = new Action<GroupSkillCdInfo>(TowerDefensePlayerController.OnCharSkillCountChanged));
					}
					instance2.Add<GroupSkillCdInfo>(name2, handle2);
				}
				EventSystem instance3 = Singleton<EventSystem>.Instance;
				object target = possessedFollowerEntity;
				EEventName name3 = EEventName.OnSkillEnd;
				Action<int, int> handle3;
				if ((handle3 = TowerDefensePlayerController.<>O.<4>__OnFollowerMontageSkillEnd) == null)
				{
					handle3 = (TowerDefensePlayerController.<>O.<4>__OnFollowerMontageSkillEnd = new Action<int, int>(TowerDefensePlayerController.OnFollowerMontageSkillEnd));
				}
				if (!instance3.HasWithTarget<int, int>(target, name3, handle3))
				{
					EventSystem instance4 = Singleton<EventSystem>.Instance;
					object target2 = possessedFollowerEntity;
					EEventName name4 = EEventName.OnSkillEnd;
					Action<int, int> handle4;
					if ((handle4 = TowerDefensePlayerController.<>O.<4>__OnFollowerMontageSkillEnd) == null)
					{
						handle4 = (TowerDefensePlayerController.<>O.<4>__OnFollowerMontageSkillEnd = new Action<int, int>(TowerDefensePlayerController.OnFollowerMontageSkillEnd));
					}
					instance4.AddWithTarget<int, int>(target2, name4, handle4);
					return;
				}
			}
			else
			{
				EventSystem instance5 = Singleton<EventSystem>.Instance;
				EEventName name5 = EEventName.CharSkillCountChanged;
				Action<GroupSkillCdInfo> handle5;
				if ((handle5 = TowerDefensePlayerController.<>O.<3>__OnCharSkillCountChanged) == null)
				{
					handle5 = (TowerDefensePlayerController.<>O.<3>__OnCharSkillCountChanged = new Action<GroupSkillCdInfo>(TowerDefensePlayerController.OnCharSkillCountChanged));
				}
				if (instance5.Has<GroupSkillCdInfo>(name5, handle5))
				{
					EventSystem instance6 = Singleton<EventSystem>.Instance;
					EEventName name6 = EEventName.CharSkillCountChanged;
					Action<GroupSkillCdInfo> handle6;
					if ((handle6 = TowerDefensePlayerController.<>O.<3>__OnCharSkillCountChanged) == null)
					{
						handle6 = (TowerDefensePlayerController.<>O.<3>__OnCharSkillCountChanged = new Action<GroupSkillCdInfo>(TowerDefensePlayerController.OnCharSkillCountChanged));
					}
					instance6.Remove<GroupSkillCdInfo>(name6, handle6);
				}
				EventSystem instance7 = Singleton<EventSystem>.Instance;
				object target3 = possessedFollowerEntity;
				EEventName name7 = EEventName.OnSkillEnd;
				Action<int, int> handle7;
				if ((handle7 = TowerDefensePlayerController.<>O.<4>__OnFollowerMontageSkillEnd) == null)
				{
					handle7 = (TowerDefensePlayerController.<>O.<4>__OnFollowerMontageSkillEnd = new Action<int, int>(TowerDefensePlayerController.OnFollowerMontageSkillEnd));
				}
				if (instance7.HasWithTarget<int, int>(target3, name7, handle7))
				{
					EventSystem instance8 = Singleton<EventSystem>.Instance;
					object target4 = possessedFollowerEntity;
					EEventName name8 = EEventName.OnSkillEnd;
					Action<int, int> handle8;
					if ((handle8 = TowerDefensePlayerController.<>O.<4>__OnFollowerMontageSkillEnd) == null)
					{
						handle8 = (TowerDefensePlayerController.<>O.<4>__OnFollowerMontageSkillEnd = new Action<int, int>(TowerDefensePlayerController.OnFollowerMontageSkillEnd));
					}
					instance8.RemoveWithTarget<int, int>(target4, name8, handle8);
				}
			}
		}
	}

	// Token: 0x0600656E RID: 25966 RVA: 0x00197000 File Offset: 0x00195200
	public static void SetFollowerState(TDPlayerDefine.EFollowerState followerState)
	{
		TDPlayerDefine.EFollowerState followerState2 = TowerDefensePlayerController.Model.FollowerState;
		TowerDefensePlayerController.Model.FollowerState = followerState;
		if (followerState2 != followerState)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshTrapDefensePsFeedback);
		}
	}

	// Token: 0x0600656F RID: 25967 RVA: 0x0019702C File Offset: 0x0019522C
	public static void ClearFollowerCdCue()
	{
		if (TowerDefensePlayerController.Model.FollowerCdCueHandle != null)
		{
			Entity possessedFollowerEntity = TowerDefensePlayerController.Model.PossessedFollowerEntity;
			CharacterGameplayCueComponent characterGameplayCueComponent = (possessedFollowerEntity != null) ? possessedFollowerEntity.GetComponent<CharacterGameplayCueComponent>() : null;
			foreach (int num in TowerDefensePlayerController.Model.FollowerCdCueHandle)
			{
				if (characterGameplayCueComponent != null)
				{
					characterGameplayCueComponent.RemoveCueByHandle((long)num);
				}
			}
			TowerDefensePlayerController.Model.FollowerCdCueHandle = new List<int>();
		}
	}

	// Token: 0x06006570 RID: 25968 RVA: 0x001970BC File Offset: 0x001952BC
	private static void OnSkillReady()
	{
		TowerDefensePlayerController.RefreshFolloerCdCue(null);
	}

	// Token: 0x06006571 RID: 25969 RVA: 0x001970C4 File Offset: 0x001952C4
	[NullableContext(1)]
	public static void RefreshFolloerCdCue(GroupSkillCdInfo _ = null)
	{
		int? currentFollowerProxyId = TowerDefensePlayerController.Model.CurrentFollowerProxyId;
		if (currentFollowerProxyId == null)
		{
			return;
		}
		TDPlayerDefine.EFollowerState efollowerState;
		if (TowerDefensePlayerController.GetFollowerSkillRemainCD(currentFollowerProxyId.Value) > 0f)
		{
			efollowerState = TDPlayerDefine.EFollowerState.InCD;
		}
		else
		{
			efollowerState = TDPlayerDefine.EFollowerState.CDReady;
		}
		if (efollowerState == TowerDefensePlayerController.Model.FollowerState)
		{
			return;
		}
		TowerDefensePlayerController.ClearFollowerCdCue();
		TowerDefensePlayerController.SetFollowerState(efollowerState);
		Entity possessedFollowerEntity = TowerDefensePlayerController.Model.PossessedFollowerEntity;
		CharacterGameplayCueComponent characterGameplayCueComponent = (possessedFollowerEntity != null) ? possessedFollowerEntity.GetComponent<CharacterGameplayCueComponent>() : null;
		int[] followerCdCueIds = KscUtil.GetFollowerCdCueIds(currentFollowerProxyId.Value, efollowerState);
		if (followerCdCueIds == null || characterGameplayCueComponent == null)
		{
			return;
		}
		if (TowerDefensePlayerController.Model.FollowerCdCueHandle == null)
		{
			TowerDefensePlayerController.Model.FollowerCdCueHandle = new List<int>();
		}
		foreach (int num in followerCdCueIds)
		{
			int item = characterGameplayCueComponent.AddCue((long)num, null);
			TowerDefensePlayerController.Model.FollowerCdCueHandle.Add(item);
		}
	}

	// Token: 0x06006572 RID: 25970 RVA: 0x001971A4 File Offset: 0x001953A4
	public static void RemoveFollowerCue()
	{
		if (TowerDefensePlayerController.Model.FollowCueHandle != null)
		{
			Entity possessedFollowerEntity = TowerDefensePlayerController.Model.PossessedFollowerEntity;
			CharacterGameplayCueComponent characterGameplayCueComponent = (possessedFollowerEntity != null) ? possessedFollowerEntity.GetComponent<CharacterGameplayCueComponent>() : null;
			foreach (int num in TowerDefensePlayerController.Model.FollowCueHandle)
			{
				if (characterGameplayCueComponent != null)
				{
					characterGameplayCueComponent.RemoveCueByHandle((long)num);
				}
			}
			TowerDefensePlayerController.Model.FollowCueHandle.Clear();
		}
	}

	// Token: 0x06006573 RID: 25971 RVA: 0x00197234 File Offset: 0x00195434
	public static void RefreshFollowerCue()
	{
		TowerDefensePlayerController.RemoveFollowerCue();
		if (TowerDefensePlayerController.Model.CurrentFollowerProxyId == null)
		{
			return;
		}
		int[] followerCueIds = KscUtil.GetFollowerCueIds(TowerDefensePlayerController.Model.CurrentFollowerProxyId.Value);
		KscLog.EModule flag = KscLog.EModule.Common;
		ELogAuthor author = ELogAuthor.TZQ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "塔防辅助机:播放特效";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cueIds", followerCueIds);
		KscLog.Debug(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (followerCueIds == null || followerCueIds.Length == 0)
		{
			return;
		}
		Entity possessedFollowerEntity = TowerDefensePlayerController.Model.PossessedFollowerEntity;
		CharacterGameplayCueComponent characterGameplayCueComponent = (possessedFollowerEntity != null) ? possessedFollowerEntity.GetComponent<CharacterGameplayCueComponent>() : null;
		if (characterGameplayCueComponent == null)
		{
			return;
		}
		if (TowerDefensePlayerController.Model.FollowCueHandle == null)
		{
			TowerDefensePlayerController.Model.FollowCueHandle = new List<int>();
		}
		foreach (int num in followerCueIds)
		{
			int item = characterGameplayCueComponent.AddCue((long)num, null);
			List<int> followCueHandle = TowerDefensePlayerController.Model.FollowCueHandle;
			if (followCueHandle != null)
			{
				followCueHandle.Add(item);
			}
		}
	}

	// Token: 0x06006574 RID: 25972 RVA: 0x0019731C File Offset: 0x0019551C
	public static void SetPsFeedbackId(string PsFeedbackId)
	{
		string psFeedbackId = TowerDefensePlayerController.Model.PsFeedbackId;
		TowerDefensePlayerController.Model.PsFeedbackId = PsFeedbackId;
		KscLog.EModule flag = KscLog.EModule.Skill;
		ELogAuthor author = ELogAuthor.TZQ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "SetPsFeedbackId";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PsFeedbackId", PsFeedbackId);
		KscLog.Debug(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (psFeedbackId != PsFeedbackId)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshTrapDefensePsFeedback);
		}
	}

	// Token: 0x06006575 RID: 25973 RVA: 0x00197384 File Offset: 0x00195584
	public static void RemoveChargeEffect()
	{
		if (TowerDefensePlayerController.Model.ChargeCueHandle > 0)
		{
			Entity possessedFollowerEntity = TowerDefensePlayerController.Model.PossessedFollowerEntity;
			CharacterGameplayCueComponent characterGameplayCueComponent = (possessedFollowerEntity != null) ? possessedFollowerEntity.GetComponent<CharacterGameplayCueComponent>() : null;
			if (characterGameplayCueComponent != null)
			{
				characterGameplayCueComponent.RemoveCueByHandle((long)TowerDefensePlayerController.Model.ChargeCueHandle);
			}
			TowerDefensePlayerController.Model.ChargeCueHandle = 0;
		}
		TowerDefensePlayerController.Model.LastSkillChargeFull = false;
		TowerDefensePlayerController.Model.ChargeSkill = null;
		TowerDefensePlayerController.SetPsFeedbackId(null);
		TowerDefensePlayerController.Model.PsFeedbackId = null;
	}

	// Token: 0x06006576 RID: 25974 RVA: 0x001973FC File Offset: 0x001955FC
	public static void TryPlayCharageEffect(EKSC_OperateType operateType, float time)
	{
		if (operateType != EKSC_OperateType.OnHold)
		{
			TowerDefensePlayerController.RemoveChargeEffect();
			return;
		}
		List<TDPlayerDefine.ISkill> list;
		if (TowerDefensePlayerController.Model.BindFollowerSkills == null || !TowerDefensePlayerController.Model.BindFollowerSkills.TryGetValue(EKSC_OperateType.OnRelease, out list) || list == null || list.Count == 0)
		{
			return;
		}
		bool flag = false;
		TDPlayerDefine.ISkill skill = null;
		int num = -1;
		if (time > list[0].Time)
		{
			flag = true;
			skill = list[0];
			num = 0;
		}
		else
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (time <= list[i].Time)
				{
					skill = list[i];
					num = i;
					break;
				}
			}
		}
		TowerDefensePlayerModel model = TowerDefensePlayerController.Model;
		Entity possessedFollowerEntity = model.PossessedFollowerEntity;
		CharacterGameplayCueComponent characterGameplayCueComponent = (possessedFollowerEntity != null) ? possessedFollowerEntity.GetComponent<CharacterGameplayCueComponent>() : null;
		if (characterGameplayCueComponent == null)
		{
			return;
		}
		if (flag && !model.LastSkillChargeFull)
		{
			model.LastSkillChargeFull = true;
			if (skill.ChargeFullCueId > 0)
			{
				characterGameplayCueComponent.AddCue((long)skill.ChargeFullCueId, new GameplayCueParam?(new GameplayCueParam
				{
					Instant = true
				}));
			}
			TowerDefensePlayerController.SetPsFeedbackId(skill.PsFeedback);
		}
		if (model.ChargeSkill == skill)
		{
			return;
		}
		if (model.ChargeSkill != null && model.ChargeSkill.ChargeFullCueId > 0)
		{
			characterGameplayCueComponent.AddCue((long)model.ChargeSkill.ChargeFullCueId, new GameplayCueParam?(new GameplayCueParam
			{
				Instant = true
			}));
		}
		if (model.ChargeCueHandle > 0)
		{
			characterGameplayCueComponent.RemoveCueByHandle((long)model.ChargeCueHandle);
			model.ChargeCueHandle = 0;
		}
		if (skill != null)
		{
			int chargeCueId = skill.ChargeCueId;
			if (skill.ChargeCueId > 0)
			{
				model.ChargeCueHandle = characterGameplayCueComponent.AddCue((long)skill.ChargeCueId, null);
			}
		}
		TowerDefensePlayerController.SetPsFeedbackId((num + 1 < list.Count) ? list[num + 1].PsFeedback : null);
		model.ChargeSkill = skill;
	}

	// Token: 0x06006577 RID: 25975 RVA: 0x001975D4 File Offset: 0x001957D4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private unsafe static Dictionary<string, int> GetFollowerSkillName2Index(AKSC_Entity_AssistMachine kscEntity)
	{
		if (kscEntity == null)
		{
			KscLog.Warn(KscLog.EModule.Skill, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "获取跟随物<技能名,索引>异常,错误的逻辑实体", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		UKSC_SkillComp skillComp = kscEntity.GetSkillComp();
		TArray<UKSC_Skill> tarray = (skillComp != null) ? skillComp.Skills_ : null;
		int? num = (tarray != null) ? new int?(tarray.Num()) : null;
		if (num != null)
		{
			int? num2 = num;
			int num3 = 0;
			if (!(num2.GetValueOrDefault() == num3 & num2 != null))
			{
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				int num4 = 0;
				for (;;)
				{
					int num5 = num4;
					num2 = num;
					if (!(num5 < num2.GetValueOrDefault() & num2 != null))
					{
						break;
					}
					UKSC_Skill uksc_Skill = tarray.Get(num4);
					UKSC_DA_Skill uksc_DA_Skill = (uksc_Skill != null) ? uksc_Skill.DaSkill_ : null;
					if (uksc_DA_Skill == null)
					{
						KscLog.EModule flag = KscLog.EModule.Skill;
						ELogAuthor author = ELogAuthor.PZ;
						UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
						string log = "获取跟随物<技能名,索引>忽略";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", num4);
						KscLog.Info(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
					else
					{
						string name = uksc_DA_Skill.GetName();
						KscLog.EModule flag2 = KscLog.EModule.Skill;
						ELogAuthor author2 = ELogAuthor.PZ;
						UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
						string log2 = "获取跟随物<技能名,索引>";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("path", name);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("index", num4);
						KscLog.Debug(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						dictionary[name] = num4;
					}
					num4++;
				}
				return dictionary;
			}
		}
		KscLog.Warn(KscLog.EModule.Skill, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "获取跟随物<技能名,索引>异常,实体没有技能", default(ReadOnlySpan<ValueTuple<string, object>>));
		return null;
	}

	// Token: 0x06006578 RID: 25976 RVA: 0x0019776A File Offset: 0x0019596A
	private static int[] GetFollowerProxySkillIds(int proxyId)
	{
		if (TowerDefensePlayerController.Model.PossessedFollowerProxies == null || TowerDefensePlayerController.Model.PossessedFollowerProxies.Count <= 0)
		{
			return null;
		}
		TowerDefenseFollowerProxy possessedFollowerProxy = TowerDefensePlayerController.GetPossessedFollowerProxy(proxyId);
		if (possessedFollowerProxy == null)
		{
			return null;
		}
		return possessedFollowerProxy.SkillIds;
	}

	// Token: 0x06006579 RID: 25977 RVA: 0x001977A0 File Offset: 0x001959A0
	public unsafe static void BindFollowerOperateSkills(AKSC_Entity_AssistMachine kscEntity, int? proxyId)
	{
		if (kscEntity == null)
		{
			KscLog.Warn(KscLog.EModule.Skill, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "跟随物锚定战斗实体非法", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (proxyId == null)
		{
			KscLog.EModule flag = KscLog.EModule.Skill;
			ELogAuthor author = ELogAuthor.PZ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "跟随物输入非法的proxy id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("kscEntity", kscEntity);
			KscLog.Warn(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		int[] followerProxySkillIds = TowerDefensePlayerController.GetFollowerProxySkillIds(proxyId.Value);
		if (followerProxySkillIds == null)
		{
			KscLog.EModule flag2 = KscLog.EModule.Skill;
			ELogAuthor author2 = ELogAuthor.PZ;
			UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			string log2 = "跟随物Proxy没有技能";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("kscEntity", kscEntity);
			KscLog.Warn(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		if (TowerDefensePlayerController.Model.BindFollowerSkills == null)
		{
			TowerDefensePlayerController.Model.BindFollowerSkills = new Dictionary<EKSC_OperateType, List<TDPlayerDefine.ISkill>>();
		}
		if (TowerDefensePlayerController.Model.SkillId2SkillData == null)
		{
			TowerDefensePlayerController.Model.SkillId2SkillData = new Dictionary<int, TDPlayerDefine.ISkill>();
		}
		foreach (int num in followerProxySkillIds)
		{
			TDPlayerDefine.ISkill skill;
			if (TowerDefensePlayerController.Model.AllSkillId2SkillData != null && TowerDefensePlayerController.Model.AllSkillId2SkillData.TryGetValue(num, out skill))
			{
				EKSC_OperateType operateType = skill.OperateType;
				List<TDPlayerDefine.ISkill> list;
				if (!TowerDefensePlayerController.Model.BindFollowerSkills.TryGetValue(operateType, out list) || list == null)
				{
					list = new List<TDPlayerDefine.ISkill>();
					TowerDefensePlayerController.Model.BindFollowerSkills[operateType] = list;
				}
				KscLog.EModule flag3 = KscLog.EModule.Skill;
				ELogAuthor author3 = ELogAuthor.PZ;
				UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
				string log3 = "跟随物技能操作绑定";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("skillId", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("skillData", skill);
				KscLog.Info(flag3, author3, kscWorld3, log3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				list.Add(skill);
				TowerDefensePlayerController.Model.SkillId2SkillData[num] = skill;
			}
			else
			{
				KscLog.EModule flag4 = KscLog.EModule.Skill;
				ELogAuthor author4 = ELogAuthor.TZQ;
				UObject kscWorld4 = Singleton<KscEnv>.Instance.KscWorld;
				string log4 = "辅助机技能操作绑定失败";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("skillId", num);
				KscLog.Info(flag4, author4, kscWorld4, log4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			}
		}
		foreach (KeyValuePair<EKSC_OperateType, List<TDPlayerDefine.ISkill>> keyValuePair in TowerDefensePlayerController.Model.BindFollowerSkills)
		{
			keyValuePair.Value.Sort((TDPlayerDefine.ISkill a, TDPlayerDefine.ISkill b) => b.Time.CompareTo(a.Time));
		}
	}

	// Token: 0x0600657A RID: 25978 RVA: 0x00197A1C File Offset: 0x00195C1C
	public static void UnBindFollowerOperateSkills()
	{
		KscLog.Debug(KscLog.EModule.Skill, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "跟随物技能操作清空", default(ReadOnlySpan<ValueTuple<string, object>>));
		TowerDefensePlayerController.SetFollowerSKillAutoCast(false, true);
		Dictionary<EKSC_OperateType, List<TDPlayerDefine.ISkill>> bindFollowerSkills = TowerDefensePlayerController.Model.BindFollowerSkills;
		if (bindFollowerSkills != null)
		{
			bindFollowerSkills.Clear();
		}
		Dictionary<int, TDPlayerDefine.ISkill> skillId2SkillData = TowerDefensePlayerController.Model.SkillId2SkillData;
		if (skillId2SkillData == null)
		{
			return;
		}
		skillId2SkillData.Clear();
	}

	// Token: 0x0600657B RID: 25979 RVA: 0x00197A7C File Offset: 0x00195C7C
	public static void ClearFollowerKSCData()
	{
		TowerDefensePlayerController.RemoveChargeEffect();
		TowerDefensePlayerController.RemoveFollowerCue();
		TowerDefensePlayerController.ClearFollowerCdCue();
		KscLog.Debug(KscLog.EModule.Skill, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "塔防辅助机:清理数据", default(ReadOnlySpan<ValueTuple<string, object>>));
		AKSC_Entity_AssistMachine possessedFollowerKscEntity = TowerDefensePlayerController.Model.PossessedFollowerKscEntity;
		if (possessedFollowerKscEntity != null)
		{
			FOnSkillCD onSkillCD = possessedFollowerKscEntity.OnSkillCD;
			if (onSkillCD != null)
			{
				onSkillCD.Unbind();
			}
			FOnSkillReady onSkillReady = possessedFollowerKscEntity.OnSkillReady;
			if (onSkillReady != null)
			{
				onSkillReady.Unbind();
			}
			UKSC_SkillComp skillComp = possessedFollowerKscEntity.GetSkillComp();
			UKSC_AttrSet uksc_AttrSet = (skillComp != null) ? skillComp.AttrSet_ : null;
			if (uksc_AttrSet != null)
			{
				if (TowerDefensePlayerController.DelegateSkillCoolDown != null)
				{
					uksc_AttrSet.RemoveAttrListen(EKSC_AttrType.SkillCoolDown, TowerDefensePlayerController.DelegateSkillCoolDown);
					TowerDefensePlayerController.DelegateSkillCoolDown = null;
				}
				if (TowerDefensePlayerController.DelegateSkillCoolDownChange != null)
				{
					uksc_AttrSet.RemoveAttrListen(EKSC_AttrType.SkillCoolDownChange, TowerDefensePlayerController.DelegateSkillCoolDownChange);
					TowerDefensePlayerController.DelegateSkillCoolDownChange = null;
				}
			}
		}
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.CharSkillCountChanged;
		Action<GroupSkillCdInfo> handle;
		if ((handle = TowerDefensePlayerController.<>O.<5>__RefreshFolloerCdCue) == null)
		{
			handle = (TowerDefensePlayerController.<>O.<5>__RefreshFolloerCdCue = new Action<GroupSkillCdInfo>(TowerDefensePlayerController.RefreshFolloerCdCue));
		}
		if (instance.Has<GroupSkillCdInfo>(name, handle))
		{
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.CharSkillCountChanged;
			Action<GroupSkillCdInfo> handle2;
			if ((handle2 = TowerDefensePlayerController.<>O.<5>__RefreshFolloerCdCue) == null)
			{
				handle2 = (TowerDefensePlayerController.<>O.<5>__RefreshFolloerCdCue = new Action<GroupSkillCdInfo>(TowerDefensePlayerController.RefreshFolloerCdCue));
			}
			instance2.Remove<GroupSkillCdInfo>(name2, handle2);
		}
		Action<EKSC_AttrType, int> callBack;
		if ((callBack = TowerDefensePlayerController.<>O.<6>__OnFollowerCDAttr) == null)
		{
			callBack = (TowerDefensePlayerController.<>O.<6>__OnFollowerCDAttr = new Action<EKSC_AttrType, int>(TowerDefensePlayerController.OnFollowerCDAttr));
		}
		global::DelegateUtils.ReleaseManualReleaseDelegate(callBack);
		Action<EKSC_AttrType, int> callBack2;
		if ((callBack2 = TowerDefensePlayerController.<>O.<7>__OnFollowerCDChangeAttr) == null)
		{
			callBack2 = (TowerDefensePlayerController.<>O.<7>__OnFollowerCDChangeAttr = new Action<EKSC_AttrType, int>(TowerDefensePlayerController.OnFollowerCDChangeAttr));
		}
		global::DelegateUtils.ReleaseManualReleaseDelegate(callBack2);
	}

	// Token: 0x0600657C RID: 25980 RVA: 0x00197BC4 File Offset: 0x00195DC4
	public static void ListenFollowerCDAttribute()
	{
		AKSC_Entity_AssistMachine possessedFollowerKscEntity = TowerDefensePlayerController.Model.PossessedFollowerKscEntity;
		UKSC_AttrSet uksc_AttrSet;
		if (possessedFollowerKscEntity == null)
		{
			uksc_AttrSet = null;
		}
		else
		{
			UKSC_SkillComp skillComp = possessedFollowerKscEntity.GetSkillComp();
			uksc_AttrSet = ((skillComp != null) ? skillComp.AttrSet_ : null);
		}
		UKSC_AttrSet uksc_AttrSet2 = uksc_AttrSet;
		if (uksc_AttrSet2 == null)
		{
			KscLog.Warn(KscLog.EModule.Skill, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "塔防辅助机:监听CD属性异常", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Action<EKSC_AttrType, int> callback;
		if ((callback = TowerDefensePlayerController.<>O.<6>__OnFollowerCDAttr) == null)
		{
			callback = (TowerDefensePlayerController.<>O.<6>__OnFollowerCDAttr = new Action<EKSC_AttrType, int>(TowerDefensePlayerController.OnFollowerCDAttr));
		}
		TowerDefensePlayerController.DelegateSkillCoolDown = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(callback);
		uksc_AttrSet2.AssignAttrListen(EKSC_AttrType.SkillCoolDown, TowerDefensePlayerController.DelegateSkillCoolDown);
		Action<EKSC_AttrType, int> callback2;
		if ((callback2 = TowerDefensePlayerController.<>O.<7>__OnFollowerCDChangeAttr) == null)
		{
			callback2 = (TowerDefensePlayerController.<>O.<7>__OnFollowerCDChangeAttr = new Action<EKSC_AttrType, int>(TowerDefensePlayerController.OnFollowerCDChangeAttr));
		}
		TowerDefensePlayerController.DelegateSkillCoolDownChange = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(callback2);
		uksc_AttrSet2.AssignAttrListen(EKSC_AttrType.SkillCoolDownChange, TowerDefensePlayerController.DelegateSkillCoolDownChange);
	}

	// Token: 0x0600657D RID: 25981 RVA: 0x00197C7C File Offset: 0x00195E7C
	private static void OnFollowerCDAttr(EKSC_AttrType attrType, int value)
	{
		KscLog.Debug(KscLog.EModule.Skill, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "塔防辅助机:OnFollowerCDChange", default(ReadOnlySpan<ValueTuple<string, object>>));
		TowerDefensePlayerController.UpdateFollowMontageSkillCD();
	}

	// Token: 0x0600657E RID: 25982 RVA: 0x00197CB0 File Offset: 0x00195EB0
	private static void OnFollowerCDChangeAttr(EKSC_AttrType attrType, int value)
	{
		KscLog.Debug(KscLog.EModule.Skill, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "塔防辅助机:OnFollowerCDChange", default(ReadOnlySpan<ValueTuple<string, object>>));
		TowerDefensePlayerController.UpdateFollowMontageSkillCD();
	}

	// Token: 0x0600657F RID: 25983 RVA: 0x00197CE4 File Offset: 0x00195EE4
	private static void UpdateFollowMontageSkillCD()
	{
		AKSC_Entity_AssistMachine possessedFollowerKscEntity = TowerDefensePlayerController.Model.PossessedFollowerKscEntity;
		UKSC_SkillComp uksc_SkillComp = (possessedFollowerKscEntity != null) ? possessedFollowerKscEntity.GetSkillComp() : null;
		if (uksc_SkillComp == null)
		{
			return;
		}
		float skillCollDown = uksc_SkillComp.GetSkillCollDown();
		Entity possessedFollowerEntity = TowerDefensePlayerController.Model.PossessedFollowerEntity;
		CharacterSkillCdComponent characterSkillCdComponent = (possessedFollowerEntity != null) ? possessedFollowerEntity.GetComponent<CharacterSkillCdComponent>() : null;
		if (characterSkillCdComponent == null)
		{
			return;
		}
		Dictionary<int, TDPlayerDefine.ISkill> skillId2SkillData = TowerDefensePlayerController.Model.SkillId2SkillData;
		if (skillId2SkillData == null)
		{
			return;
		}
		KscLog.EModule flag = KscLog.EModule.Skill;
		ELogAuthor author = ELogAuthor.TZQ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "塔防辅助机:更新蒙太奇技能CD";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SkillCoolDown", skillCollDown);
		KscLog.Debug(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		foreach (KeyValuePair<int, TDPlayerDefine.ISkill> keyValuePair in skillId2SkillData)
		{
			TDPlayerDefine.ISkill value = keyValuePair.Value;
			if (value.SkillType == TDPlayerDefine.ESkillType.MontageSkill)
			{
				characterSkillCdComponent.ModifyCdInfo(value.SkillId, (float)((int)skillCollDown));
			}
		}
	}

	// Token: 0x06006580 RID: 25984 RVA: 0x00197DD0 File Offset: 0x00195FD0
	public static void OnFollowerEnterSkillCd(int skillIndex, float cd)
	{
		KscLog.EModule flag = KscLog.EModule.Skill;
		ELogAuthor author = ELogAuthor.TZQ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "塔防OnFollowerEnterSkillCd";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cd", cd);
		KscLog.Debug(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (TowerDefensePlayerController.Model.CurrentFollowerProxyId == null)
		{
			return;
		}
		TowerDefensePlayerController.RefreshFolloerCdCue(null);
		Singleton<EventSystem>.Instance.Emit<int, float>(EEventName.TrapFollowerSkillCd, TowerDefensePlayerController.Model.CurrentFollowerProxyId.Value, cd);
	}

	// Token: 0x06006581 RID: 25985 RVA: 0x00197E48 File Offset: 0x00196048
	public static TDPlayerDefine.ISkill GetFollowListenSkillData(int proxyId)
	{
		if (KscUtil.GetFollowerCdSkillByProxy(proxyId).GetValueOrDefault() != 1)
		{
			return null;
		}
		int[] followerProxySkillIds = TowerDefensePlayerController.GetFollowerProxySkillIds(proxyId);
		if (followerProxySkillIds == null || followerProxySkillIds.Length != 1)
		{
			return null;
		}
		Dictionary<int, TDPlayerDefine.ISkill> allSkillId2SkillData = TowerDefensePlayerController.Model.AllSkillId2SkillData;
		TDPlayerDefine.ISkill result;
		if (allSkillId2SkillData == null || !allSkillId2SkillData.TryGetValue(followerProxySkillIds[0], out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06006582 RID: 25986 RVA: 0x00197E9C File Offset: 0x0019609C
	public static TDPlayerDefine.ISkill GetSkillDataByRowId(int CDSkillRowId)
	{
		Dictionary<int, TDPlayerDefine.ISkill> skillId2SkillData = TowerDefensePlayerController.Model.SkillId2SkillData;
		TDPlayerDefine.ISkill result;
		if (skillId2SkillData == null || !skillId2SkillData.TryGetValue(CDSkillRowId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06006583 RID: 25987 RVA: 0x00197EC8 File Offset: 0x001960C8
	public static void SetListenSkillCD(AKSC_Entity_AssistMachine kscEntity, int? proxyId)
	{
		if (proxyId == null || kscEntity == null)
		{
			KscLog.EModule flag = KscLog.EModule.Skill;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "塔防辅助机输入非法的proxy id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("proxyId", proxyId);
			KscLog.Warn(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		FOnSkillCD onSkillCD = kscEntity.OnSkillCD;
		if (onSkillCD != null)
		{
			onSkillCD.Unbind();
		}
		FOnSkillReady onSkillReady = kscEntity.OnSkillReady;
		if (onSkillReady != null)
		{
			onSkillReady.Unbind();
		}
		TDPlayerDefine.ISkill followListenSkillData = TowerDefensePlayerController.GetFollowListenSkillData(proxyId.Value);
		if (followListenSkillData == null)
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.CharSkillCountChanged;
			Action<GroupSkillCdInfo> handle;
			if ((handle = TowerDefensePlayerController.<>O.<5>__RefreshFolloerCdCue) == null)
			{
				handle = (TowerDefensePlayerController.<>O.<5>__RefreshFolloerCdCue = new Action<GroupSkillCdInfo>(TowerDefensePlayerController.RefreshFolloerCdCue));
			}
			if (instance.Has<GroupSkillCdInfo>(name, handle))
			{
				EventSystem instance2 = Singleton<EventSystem>.Instance;
				EEventName name2 = EEventName.CharSkillCountChanged;
				Action<GroupSkillCdInfo> handle2;
				if ((handle2 = TowerDefensePlayerController.<>O.<5>__RefreshFolloerCdCue) == null)
				{
					handle2 = (TowerDefensePlayerController.<>O.<5>__RefreshFolloerCdCue = new Action<GroupSkillCdInfo>(TowerDefensePlayerController.RefreshFolloerCdCue));
				}
				instance2.Remove<GroupSkillCdInfo>(name2, handle2);
			}
			return;
		}
		if (followListenSkillData.SkillType != TDPlayerDefine.ESkillType.KscSkill)
		{
			EventSystem instance3 = Singleton<EventSystem>.Instance;
			EEventName name3 = EEventName.CharSkillCountChanged;
			Action<GroupSkillCdInfo> handle3;
			if ((handle3 = TowerDefensePlayerController.<>O.<5>__RefreshFolloerCdCue) == null)
			{
				handle3 = (TowerDefensePlayerController.<>O.<5>__RefreshFolloerCdCue = new Action<GroupSkillCdInfo>(TowerDefensePlayerController.RefreshFolloerCdCue));
			}
			if (!instance3.Has<GroupSkillCdInfo>(name3, handle3))
			{
				EventSystem instance4 = Singleton<EventSystem>.Instance;
				EEventName name4 = EEventName.CharSkillCountChanged;
				Action<GroupSkillCdInfo> handle4;
				if ((handle4 = TowerDefensePlayerController.<>O.<5>__RefreshFolloerCdCue) == null)
				{
					handle4 = (TowerDefensePlayerController.<>O.<5>__RefreshFolloerCdCue = new Action<GroupSkillCdInfo>(TowerDefensePlayerController.RefreshFolloerCdCue));
				}
				instance4.Add<GroupSkillCdInfo>(name4, handle4);
			}
			return;
		}
		KscLog.EModule flag2 = KscLog.EModule.Skill;
		ELogAuthor author2 = ELogAuthor.TZQ;
		UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
		string log2 = "塔防辅助机监听KSC技能CD";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("KSCSkillId", followListenSkillData.SkillId);
		KscLog.Info(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		kscEntity.ListenCDSkillIndex = followListenSkillData.SkillId;
		FOnSkillCD onSkillCD2 = kscEntity.OnSkillCD;
		if (onSkillCD2 != null)
		{
			Action<int, float> callback;
			if ((callback = TowerDefensePlayerController.<>O.<8>__OnFollowerEnterSkillCd) == null)
			{
				callback = (TowerDefensePlayerController.<>O.<8>__OnFollowerEnterSkillCd = new Action<int, float>(TowerDefensePlayerController.OnFollowerEnterSkillCd));
			}
			onSkillCD2.Bind(callback);
		}
		kscEntity.ListenSkillReadyIndex = followListenSkillData.SkillId;
		FOnSkillReady onSkillReady2 = kscEntity.OnSkillReady;
		if (onSkillReady2 == null)
		{
			return;
		}
		Action callback2;
		if ((callback2 = TowerDefensePlayerController.<>O.<9>__OnSkillReady) == null)
		{
			callback2 = (TowerDefensePlayerController.<>O.<9>__OnSkillReady = new Action(TowerDefensePlayerController.OnSkillReady));
		}
		onSkillReady2.Bind(callback2);
	}

	// Token: 0x06006584 RID: 25988 RVA: 0x00198097 File Offset: 0x00196297
	public static float GetFollowerSkillRemainCD(int proxyId)
	{
		return TowerDefensePlayerController.GetFollowerSkillCDInner(proxyId, true);
	}

	// Token: 0x06006585 RID: 25989 RVA: 0x001980A0 File Offset: 0x001962A0
	public static float GetFollowerSkillCD(int proxyId)
	{
		return TowerDefensePlayerController.GetFollowerSkillCDInner(proxyId, false);
	}

	// Token: 0x06006586 RID: 25990 RVA: 0x001980AC File Offset: 0x001962AC
	private static float GetFollowerSkillCDInner(int proxyId, bool bRemainCd)
	{
		TDPlayerDefine.ISkill followListenSkillData = TowerDefensePlayerController.GetFollowListenSkillData(proxyId);
		if (followListenSkillData == null)
		{
			KscLog.EModule flag = KscLog.EModule.Skill;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "塔防辅助机没有CD技能";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("proxyId", proxyId);
			KscLog.Warn(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0f;
		}
		AKSC_Entity_AssistMachine possessedFollowerKscEntity = TowerDefensePlayerController.Model.PossessedFollowerKscEntity;
		if (possessedFollowerKscEntity == null)
		{
			KscLog.EModule flag2 = KscLog.EModule.Skill;
			ELogAuthor author2 = ELogAuthor.TZQ;
			UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			string log2 = "塔防监听辅助机实体不存在";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("proxyId", proxyId);
			KscLog.Warn(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return 0f;
		}
		if (followListenSkillData.SkillType != TDPlayerDefine.ESkillType.MontageSkill)
		{
			UKSC_SkillComp skillComp = possessedFollowerKscEntity.GetSkillComp();
			TArray<UKSC_Skill> tarray = (skillComp != null) ? skillComp.Skills_ : null;
			int? num = (tarray != null) ? new int?(tarray.Num()) : null;
			int skillId = followListenSkillData.SkillId;
			if (num != null)
			{
				int num2 = skillId;
				int? num3 = num;
				if (!(num2 >= num3.GetValueOrDefault() & num3 != null))
				{
					UKSC_Skill uksc_Skill = tarray.Get(skillId);
					if (uksc_Skill == null || !uksc_Skill.IsValid())
					{
						KscLog.EModule flag3 = KscLog.EModule.Skill;
						ELogAuthor author3 = ELogAuthor.TZQ;
						UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
						string log3 = "塔防辅助机技能不合法";
						ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("proxyId", proxyId);
						KscLog.Warn(flag3, author3, kscWorld3, log3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
						return 0f;
					}
					if (bRemainCd)
					{
						return uksc_Skill.GetSkillCoolDownRemain();
					}
					return uksc_Skill.GetSkillCoolDownMax();
				}
			}
			KscLog.EModule flag4 = KscLog.EModule.Skill;
			ELogAuthor author4 = ELogAuthor.TZQ;
			UObject kscWorld4 = Singleton<KscEnv>.Instance.KscWorld;
			string log4 = "塔防辅助机CDSkill不合法";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("proxyId", proxyId);
			KscLog.Warn(flag4, author4, kscWorld4, log4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			return 0f;
		}
		Entity possessedFollowerEntity = TowerDefensePlayerController.Model.PossessedFollowerEntity;
		CharacterSkillCdComponent characterSkillCdComponent = (possessedFollowerEntity != null) ? possessedFollowerEntity.GetComponent<CharacterSkillCdComponent>() : null;
		GroupSkillCdInfo groupSkillCdInfo = (characterSkillCdComponent != null) ? characterSkillCdComponent.GetGroupSkillCdInfo(followListenSkillData.SkillId) : null;
		if (groupSkillCdInfo == null)
		{
			return 0f;
		}
		if (!bRemainCd)
		{
			return groupSkillCdInfo.CurMaxCd;
		}
		return groupSkillCdInfo.CurRemainingCd;
	}

	// Token: 0x06006587 RID: 25991 RVA: 0x0019827C File Offset: 0x0019647C
	private unsafe static void BindFollowerAttrs(AKSC_Entity_AssistMachine kscEntity, int? proxyId)
	{
		if (kscEntity == null)
		{
			KscLog.Warn(KscLog.EModule.Attr, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "跟随物锚定战斗实体非法", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (proxyId == null)
		{
			KscLog.EModule flag = KscLog.EModule.Attr;
			ELogAuthor author = ELogAuthor.PZ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "跟随物输入非法的proxy id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("kscEntity", kscEntity);
			KscLog.Warn(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		TowerDefenseFollowerProxy towerDefenseFollowerProxy;
		if (TowerDefensePlayerController.Model.PossessedFollowerProxies == null || !TowerDefensePlayerController.Model.PossessedFollowerProxies.TryGetValue(proxyId.Value, out towerDefenseFollowerProxy) || towerDefenseFollowerProxy == null)
		{
			KscLog.EModule flag2 = KscLog.EModule.Attr;
			ELogAuthor author2 = ELogAuthor.PZ;
			UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			string log2 = "跟随物输入非法的proxy";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("kscEntity", kscEntity);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("proxy id", proxyId);
			KscLog.Warn(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		int? propertyId = towerDefenseFollowerProxy.PropertyId;
		if (propertyId == null)
		{
			KscLog.EModule flag3 = KscLog.EModule.Attr;
			ELogAuthor author3 = ELogAuthor.PZ;
			UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
			string log3 = "跟随物proxy的属性数据异常";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("kscEntity", kscEntity);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("proxy id", proxyId);
			KscLog.Warn(flag3, author3, kscWorld3, log3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		KscSubControllerBase curSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController;
		if (curSubController == null)
		{
			return;
		}
		curSubController.SetAttrs(kscEntity, propertyId.Value, null);
	}

	// Token: 0x06006588 RID: 25992 RVA: 0x001983F4 File Offset: 0x001965F4
	private unsafe static void DoCommit(EKSC_OperateType operateType, float time)
	{
		if (TowerDefensePlayerController.IsPlayerFollowerEnabled())
		{
			if (operateType != EKSC_OperateType.OnPress && !TowerDefensePlayerController.Model.IsInCharge)
			{
				return;
			}
			if (operateType == EKSC_OperateType.OnPress)
			{
				TowerDefensePlayerController.Model.IsInCharge = true;
			}
			else if (operateType == EKSC_OperateType.OnRelease)
			{
				TowerDefensePlayerController.Model.IsInCharge = false;
			}
			TowerDefensePlayerController.TryPlayCharageEffect(operateType, time);
			if (operateType == EKSC_OperateType.OnPress)
			{
				TowerDefensePlayerController.SetFollowerSKillAutoCast(!TowerDefensePlayerController.Model.IsInAutoCast, false);
			}
			TDPlayerDefine.ISkill followerSkillByOperateType = TowerDefensePlayerController.GetFollowerSkillByOperateType(operateType, time);
			KscLog.EModule flag = KscLog.EModule.Input;
			ELogAuthor author = ELogAuthor.PZ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "塔防Commit:射击转发";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("op type", operateType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("time", time);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SkillData", followerSkillByOperateType);
			KscLog.Debug(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (followerSkillByOperateType != null)
			{
				TowerDefensePlayerController.BeginSkillFollower(followerSkillByOperateType);
				return;
			}
		}
		else
		{
			if (operateType == EKSC_OperateType.OnPress && !Singleton<Info>.Instance.IsInTouch())
			{
				KscLog.Info(KscLog.EModule.Input, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "塔防输入层请求陷阱", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<TowerDefenseEventController>.Instance.OccupyTrap();
				return;
			}
			if (operateType == EKSC_OperateType.OnRelease && Singleton<Info>.Instance.IsInTouch())
			{
				KscLog.Info(KscLog.EModule.Input, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "塔防输入层请求陷阱", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<TowerDefenseEventController>.Instance.OccupyTrap();
			}
		}
	}

	// Token: 0x06006589 RID: 25993 RVA: 0x00198558 File Offset: 0x00196758
	private static void DoUseItem()
	{
		if (!ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(false))
		{
			return;
		}
		if (!ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelDataHasShop())
		{
			return;
		}
		int? exploreSkillId = ModelBase<TrapDefenseModel>.Instance.BattleData.GetExploreSkillId();
		if (exploreSkillId != null)
		{
			TrapDefenseItem? trapDefenseItemByExploreToolId = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseItemByExploreToolId(exploreSkillId.Value);
			if (trapDefenseItemByExploreToolId != null)
			{
				TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
				TrapDefenseBattleItemData trapDefenseBattleItemData = (instance != null) ? instance.BattleInventoryData.GetItemData(trapDefenseItemByExploreToolId.Value.Id) : null;
				if (trapDefenseBattleItemData == null || trapDefenseBattleItemData.InventoryCount <= 0)
				{
					return;
				}
				ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseUseItem(trapDefenseItemByExploreToolId.Value.Id);
			}
		}
	}

	// Token: 0x0600658A RID: 25994 RVA: 0x00198600 File Offset: 0x00196800
	public static void HandleUseItem()
	{
		TowerDefensePlayerController.DoUseItem();
	}

	// Token: 0x0600658B RID: 25995 RVA: 0x00198607 File Offset: 0x00196807
	public static void HandleTowerDefenseCommitFast()
	{
		TowerDefensePlayerController.DoCommit(EKSC_OperateType.OnPress, 0f);
	}

	// Token: 0x0600658C RID: 25996 RVA: 0x00198614 File Offset: 0x00196814
	public static void HandleTowerDefenseCommit(EKSC_OperateType operateType, float time)
	{
		TowerDefensePlayerController.DoCommit(operateType, time);
	}

	// Token: 0x0600658D RID: 25997 RVA: 0x0019861D File Offset: 0x0019681D
	public static void HandleTowerFollowerSelect(int proxyId)
	{
		ControllerBase<TowerDefenseEventController>.Instance.CancelCurrentPreviewTrap();
		TowerDefensePlayerController.SetFollowerProxy(proxyId);
		TowerDefensePlayerController.EnablePlayerFollower(true);
	}

	// Token: 0x0600658E RID: 25998 RVA: 0x00198638 File Offset: 0x00196838
	public static void PlayerDoSkill(int skillIndex)
	{
		TowerDefensePlayerModel model = TowerDefensePlayerController.Model;
		WorldEntity worldEntity;
		if (model == null)
		{
			worldEntity = null;
		}
		else
		{
			EntityHandle pendingRoleHandle = model.PendingRoleHandle;
			worldEntity = ((pendingRoleHandle != null) ? pendingRoleHandle.Entity : null);
		}
		WorldEntity worldEntity2 = worldEntity;
		if (worldEntity2 != null)
		{
			TowerDefensePlayerController.DoSkill(worldEntity2, skillIndex);
		}
	}

	// Token: 0x0600658F RID: 25999 RVA: 0x00198670 File Offset: 0x00196870
	[NullableContext(1)]
	public unsafe static void DoSkill(Entity entity, int skillIndex)
	{
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		long? num = (component != null) ? new long?(component.GetCreatureDataId()) : null;
		if (num == null)
		{
			KscLog.Warn(KscLog.EModule.Input, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "塔防触发技能失败:无creatureId", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		KscEntityHandle kscEntityHandle = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel.GetKscEntityHandle(num.Value);
		if (kscEntityHandle == null || !kscEntityHandle.Valid)
		{
			KscLog.Warn(KscLog.EModule.Input, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "塔防触发技能失败:无绑定的kscEntity", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		AKSC_Entity kscEntity = kscEntityHandle.KscEntity;
		if (kscEntity == null)
		{
			return;
		}
		if (kscEntity is AKSC_Entity_AssistMachine)
		{
			CharacterActorComponent component2 = entity.GetComponent<CharacterActorComponent>();
			TsBaseCharacter tsBaseCharacter = (component2 != null) ? component2.Actor : null;
			if (tsBaseCharacter != null)
			{
				KscLog.EModule flag = KscLog.EModule.Input;
				ELogAuthor author = ELogAuthor.TZQ;
				UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
				string log = "塔防触发技能";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityId", entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("skillId", skillIndex);
				KscLog.Debug(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				FTransformDouble ftransformDouble = tsBaseCharacter.D_GetTransform();
				((AKSC_Entity_AssistMachine)kscEntity).D_Fire(ftransformDouble, skillIndex);
				return;
			}
		}
		else
		{
			kscEntity.TryActiveSKill(skillIndex);
		}
	}

	// Token: 0x0400303C RID: 12348
	private static TowerDefensePlayerModel TDPlayerModel;

	// Token: 0x0400303D RID: 12349
	public static FOnKSCAttrChange DelegateSkillCoolDown;

	// Token: 0x0400303E RID: 12350
	public static FOnKSCAttrChange DelegateSkillCoolDownChange;

	// Token: 0x0400303F RID: 12351
	private static FName EKSC_REMOVE_REASON_FOLLOWER;

	// Token: 0x02007377 RID: 29559
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04027FBA RID: 163770
		[Nullable(0)]
		public static Action<bool> <0>__OnPlayerFollowerEnableChange;

		// Token: 0x04027FBB RID: 163771
		[Nullable(0)]
		public static Action <1>__OnPlayerFollowerUnPossessed;

		// Token: 0x04027FBC RID: 163772
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<EntityHandle> <2>__OnPlayerFollowerPossessed;

		// Token: 0x04027FBD RID: 163773
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<GroupSkillCdInfo> <3>__OnCharSkillCountChanged;

		// Token: 0x04027FBE RID: 163774
		[Nullable(0)]
		public static Action<int, int> <4>__OnFollowerMontageSkillEnd;

		// Token: 0x04027FBF RID: 163775
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<GroupSkillCdInfo> <5>__RefreshFolloerCdCue;

		// Token: 0x04027FC0 RID: 163776
		[Nullable(0)]
		public static Action<EKSC_AttrType, int> <6>__OnFollowerCDAttr;

		// Token: 0x04027FC1 RID: 163777
		[Nullable(0)]
		public static Action<EKSC_AttrType, int> <7>__OnFollowerCDChangeAttr;

		// Token: 0x04027FC2 RID: 163778
		[Nullable(0)]
		public static Action<int, float> <8>__OnFollowerEnterSkillCd;

		// Token: 0x04027FC3 RID: 163779
		[Nullable(0)]
		public static Action <9>__OnSkillReady;
	}
}
