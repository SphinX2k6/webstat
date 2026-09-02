using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.CreatureTools;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.NewWorld.SceneItem.Model;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200176C RID: 5996
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class AdviceController : ControllerBase<AdviceController>
{
	// Token: 0x0600A8A2 RID: 43170 RVA: 0x002CE32D File Offset: 0x002CC52D
	protected override bool OnInit()
	{
		this.OnAddEvents();
		this.OnRegisterNetEvent();
		return true;
	}

	// Token: 0x0600A8A3 RID: 43171 RVA: 0x002CE33C File Offset: 0x002CC53C
	protected override bool OnClear()
	{
		this.OnRemoveEvents();
		this.OnUnRegisterNetEvent();
		return true;
	}

	// Token: 0x0600A8A4 RID: 43172 RVA: 0x002CE34C File Offset: 0x002CC54C
	protected void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnGetFriendInitData, new Action(this.RequestAdviceData));
		Singleton<EventSystem>.Instance.Add(EEventName.OnItemUse, new Action<int, int>(this.OnItemUse));
		Singleton<EventSystem>.Instance.Add(EEventName.OriginWorldLevelUp, new Action(this.OnWorldLevelUp));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(this.OnCrossDay));
	}

	// Token: 0x0600A8A5 RID: 43173 RVA: 0x002CE3E8 File Offset: 0x002CC5E8
	protected void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGetFriendInitData, new Action(this.RequestAdviceData));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemUse, new Action<int, int>(this.OnItemUse));
		Singleton<EventSystem>.Instance.Remove(EEventName.OriginWorldLevelUp, new Action(this.OnWorldLevelUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(this.OnCrossDay));
	}

	// Token: 0x0600A8A6 RID: 43174 RVA: 0x002CE484 File Offset: 0x002CC684
	protected void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<AdviceContentUpdateNotify>(ENotifyMessageId.AdviceContentUpdateNotify, new Action<AdviceContentUpdateNotify, Net.CallbackStatus>(this.OnAdviceContentUpdateNotify));
		Singleton<Net>.Instance.Register<AdviceVoteUpdateNotify>(ENotifyMessageId.AdviceVoteUpdateNotify, new Action<AdviceVoteUpdateNotify, Net.CallbackStatus>(this.OnAdviceVoteUpdateNotify));
		Singleton<Net>.Instance.Register<AdviceUpdateNotify>(ENotifyMessageId.AdviceUpdateNotify, new Action<AdviceUpdateNotify, Net.CallbackStatus>(this.OnAdviceUpdateNotify));
		Singleton<Net>.Instance.Register<AdviceSettingNotify>(ENotifyMessageId.AdviceSettingNotify, new Action<AdviceSettingNotify, Net.CallbackStatus>(this.OnAdviceSettingNotify));
	}

	// Token: 0x0600A8A7 RID: 43175 RVA: 0x002CE504 File Offset: 0x002CC704
	protected void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AdviceContentUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AdviceVoteUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AdviceSettingNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AdviceUpdateNotify);
	}

	// Token: 0x0600A8A8 RID: 43176 RVA: 0x002CE551 File Offset: 0x002CC751
	private void OnWorldLevelUp()
	{
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.AdviceInfoView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.AdviceInfoView, null);
		}
	}

	// Token: 0x0600A8A9 RID: 43177 RVA: 0x002CE574 File Offset: 0x002CC774
	private void OnPlayerLevelChanged(int lastLevel, int currentLevel, int currentExp, int lastExp, int addExp, int currentMaxExp, int lastMaxExp)
	{
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.AdviceInfoView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.AdviceInfoView, null);
		}
	}

	// Token: 0x0600A8AA RID: 43178 RVA: 0x002CE598 File Offset: 0x002CC798
	private void OnItemUse(int configId, int useCount)
	{
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(configId);
		int num;
		if (itemConfig != null && itemConfig.Value.Parameters() != null && itemConfig.Value.Parameters().Count > 0 && itemConfig.Value.Parameters().TryGetValue(20, out num) && num != 0)
		{
			this.OpenAdviceCreateView();
		}
	}

	// Token: 0x0600A8AB RID: 43179 RVA: 0x002CE605 File Offset: 0x002CC805
	private void OnCrossDay()
	{
		ModelBase<AdviceModel>.Instance.ResetVoteIds();
	}

	// Token: 0x0600A8AC RID: 43180 RVA: 0x002CE611 File Offset: 0x002CC811
	public void OpenAdviceConjunctionSelectView()
	{
		AdviceModel instance = ModelBase<AdviceModel>.Instance;
		instance.CurrentChangeWordType = EChangeWordType.Conjunction;
		instance.CurrentSelectWordId = instance.CurrentConjunctionId;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AdviceWordView, null, null);
	}

	// Token: 0x0600A8AD RID: 43181 RVA: 0x002CE63C File Offset: 0x002CC83C
	public void OpenAdviceWordSelectView(int wordIndex)
	{
		AdviceModel instance = ModelBase<AdviceModel>.Instance;
		int num;
		if (instance.CurrentWordMap.TryGetValue(wordIndex, out num) && num > 0)
		{
			instance.CurrentSelectSortTypeId = ConfigBase<AdviceConfig>.Instance.GetAdviceWordType(num).GetValueOrDefault();
			instance.CurrentSelectSortWordId = num;
		}
		else
		{
			IReadOnlyList<AdviceWordType> adviceWordTypeConfigs = ConfigBase<AdviceConfig>.Instance.GetAdviceWordTypeConfigs();
			int currentSelectSortTypeId = (adviceWordTypeConfigs != null && adviceWordTypeConfigs.Count > 0) ? adviceWordTypeConfigs[0].Id : 0;
			instance.CurrentSelectSortTypeId = currentSelectSortTypeId;
			instance.CurrentSelectSortWordId = -1;
		}
		instance.CurrentSelectWordIndex = wordIndex;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AdviceSortWordView, null, null);
	}

	// Token: 0x0600A8AE RID: 43182 RVA: 0x002CE6D8 File Offset: 0x002CC8D8
	public void OpenAdviceSentenceSelectView()
	{
		AdviceModel instance = ModelBase<AdviceModel>.Instance;
		if (instance.CurrentLineModel == ELineMode.SingleLine)
		{
			instance.CurrentChangeWordType = EChangeWordType.Sentence;
			int currentSelectWordId;
			instance.CurrentSentenceWordMap.TryGetValue(0, out currentSelectWordId);
			instance.CurrentSelectWordId = currentSelectWordId;
			instance.CurrentPreSelectSentenceIndex = 0;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.AdviceWordView, null, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AdviceMutiSentenceSelectView, null, null);
	}

	// Token: 0x0600A8AF RID: 43183 RVA: 0x002CE73A File Offset: 0x002CC93A
	public void OpenAdviceExpressionView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AdviceExpressionView, null, null);
	}

	// Token: 0x0600A8B0 RID: 43184 RVA: 0x002CE750 File Offset: 0x002CC950
	public void OpenAdviceCreateView()
	{
		if (ModelBase<AdviceModel>.Instance.GetCreateAdvicePreConditionState())
		{
			ModelBase<AdviceModel>.Instance.ResetWordData();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.AdviceCreateView, null, null);
			return;
		}
		string createPreConditionFailText = ModelBase<AdviceModel>.Instance.GetCreatePreConditionFailText();
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(createPreConditionFailText, Array.Empty<object>());
	}

	// Token: 0x0600A8B1 RID: 43185 RVA: 0x002CE7A0 File Offset: 0x002CC9A0
	public void OpenAdviceView()
	{
		ModelBase<AdviceModel>.Instance.AdviceViewShowId = null;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AdviceView, null, null);
	}

	// Token: 0x0600A8B2 RID: 43186 RVA: 0x002CE7C4 File Offset: 0x002CC9C4
	[NullableContext(0)]
	public UniTask<bool> OpenAdviceInfoView(int entityId)
	{
		AdviceController.<OpenAdviceInfoView>d__18 <OpenAdviceInfoView>d__;
		<OpenAdviceInfoView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenAdviceInfoView>d__.<>4__this = this;
		<OpenAdviceInfoView>d__.entityId = entityId;
		<OpenAdviceInfoView>d__.<>1__state = -1;
		<OpenAdviceInfoView>d__.<>t__builder.Start<AdviceController.<OpenAdviceInfoView>d__18>(ref <OpenAdviceInfoView>d__);
		return <OpenAdviceInfoView>d__.<>t__builder.Task;
	}

	// Token: 0x0600A8B3 RID: 43187 RVA: 0x002CE810 File Offset: 0x002CCA10
	private bool CheckEntityIfInBattle()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity != null && getCurrentEntity.Valid)
		{
			WorldEntity entity = getCurrentEntity.Entity;
			BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null && baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("BattleCannotOpenAdvice", Array.Empty<object>());
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600A8B4 RID: 43188 RVA: 0x002CE878 File Offset: 0x002CCA78
	private void PlayMotionAnimation(int entityId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity == null)
		{
			return;
		}
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		bool flag;
		if (component == null)
		{
			flag = (null != null);
		}
		else
		{
			AdviceEntityData adviceInfo = component.GetAdviceInfo();
			flag = (((adviceInfo != null) ? adviceInfo.GetAdviceData() : null) != null);
		}
		if (flag && component.GetAdviceInfo().GetAdviceData().GetAdviceMotionId() > 0L)
		{
			ModelBase<AdviceModel>.Instance.GetAdviceMotionActor(entityId).PlayMotion(entityId);
		}
		SceneItemAdviceComponent component2 = entity.GetComponent<SceneItemAdviceComponent>();
		if (component2 == null)
		{
			return;
		}
		component2.DoInteract();
	}

	// Token: 0x0600A8B5 RID: 43189 RVA: 0x002CE8EC File Offset: 0x002CCAEC
	private void RequestAdviceData()
	{
		AdviceRequest message = AdviceRequest.Create();
		Singleton<Net>.Instance.Call<AdviceResponse>(ERequestMessageId.AdviceRequest, message, delegate(AdviceResponse response, Net.CallbackStatus _)
		{
			if (response == null || response.ErrorCode > Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18557, null, true, true);
				return;
			}
			if (response != null)
			{
				ModelBase<AdviceModel>.Instance.PhraseAdviceData(response);
			}
		}, 0);
	}

	// Token: 0x0600A8B6 RID: 43190 RVA: 0x002CE930 File Offset: 0x002CCB30
	public void RequestCreateAdvice(global::Vector position, global::Rotator rotator, AdviceContentData[] adviceContent, Action callback)
	{
		AdviceCreateRequest adviceCreateRequest = AdviceCreateRequest.Create();
		adviceCreateRequest.Pos = new Aki.Protocol.Vector
		{
			X = (float)position.X,
			Y = (float)position.Y,
			Z = (float)position.Z
		};
		adviceCreateRequest.Rot = new Aki.Protocol.Rotator
		{
			Pitch = rotator.Pitch,
			Yaw = rotator.Yaw,
			Roll = rotator.Roll
		};
		adviceCreateRequest.Contents.Add(new List<PbAdviceContent>());
		foreach (AdviceContentData adviceContentData in adviceContent)
		{
			adviceCreateRequest.Contents.Add(adviceContentData.ConvertToPb());
		}
		Singleton<Net>.Instance.Call<AdviceCreateResponse>(ERequestMessageId.AdviceCreateRequest, adviceCreateRequest, delegate(AdviceCreateResponse response, Net.CallbackStatus _)
		{
			if (response == null || response.ErrorCode > Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15005, null, true, true);
				return;
			}
			Action callback2 = callback;
			if (callback2 != null)
			{
				callback2();
			}
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("HasPublishAdvice", Array.Empty<object>());
			if (response != null)
			{
				ModelBase<AdviceModel>.Instance.PhraseAdviceCreateData(response);
			}
		}, 0);
	}

	// Token: 0x0600A8B7 RID: 43191 RVA: 0x002CEA08 File Offset: 0x002CCC08
	public void RequestModifyAdvice(long id, AdviceContentData[] adviceContent)
	{
		AdviceModifyRequest adviceModifyRequest = AdviceModifyRequest.Create();
		adviceModifyRequest.Id = id;
		adviceModifyRequest.Contents.Add(new List<PbAdviceContent>());
		foreach (AdviceContentData adviceContentData in adviceContent)
		{
			adviceModifyRequest.Contents.Add(adviceContentData.ConvertToPb());
		}
		Singleton<Net>.Instance.Call<AdviceModifyResponse>(ERequestMessageId.AdviceModifyRequest, adviceModifyRequest, delegate(AdviceModifyResponse response, Net.CallbackStatus _)
		{
			if (response == null || response.ErrorCode > Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18464, null, true, true);
				return;
			}
			ModelBase<AdviceModel>.Instance.OnModifyAdvice(id, adviceContent);
		}, 0);
	}

	// Token: 0x0600A8B8 RID: 43192 RVA: 0x002CEA94 File Offset: 0x002CCC94
	public void RequestDeleteAdvice(long id)
	{
		AdviceDeleteRequest adviceDeleteRequest = AdviceDeleteRequest.Create();
		adviceDeleteRequest.Id = id;
		Singleton<Net>.Instance.Call<AdviceDeleteResponse>(ERequestMessageId.AdviceDeleteRequest, adviceDeleteRequest, delegate(AdviceDeleteResponse response, Net.CallbackStatus _)
		{
			if (response == null || response.ErrorCode > Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24084, null, true, true);
				return;
			}
			ModelBase<AdviceModel>.Instance.OnDeleteAdvice(id);
		}, 0);
	}

	// Token: 0x0600A8B9 RID: 43193 RVA: 0x002CEAE0 File Offset: 0x002CCCE0
	public void RequestVote(long entityId, long adviceId, PbAdviceVoteType type)
	{
		AdviceVoteRequest adviceVoteRequest = AdviceVoteRequest.Create();
		adviceVoteRequest.Id = entityId;
		adviceVoteRequest.Type = type;
		Singleton<Net>.Instance.Call<AdviceVoteResponse>(ERequestMessageId.AdviceVoteRequest, adviceVoteRequest, delegate(AdviceVoteResponse response, Net.CallbackStatus _)
		{
			if (response == null || response.ErrorCode > Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28383, null, true, true);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnAdviceVoteNotify);
				return;
			}
			ModelBase<AdviceModel>.Instance.OnRequestVote(adviceId, type);
		}, 0);
	}

	// Token: 0x0600A8BA RID: 43194 RVA: 0x002CEB38 File Offset: 0x002CCD38
	private void OnAdviceContentUpdateNotify(AdviceContentUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		int id = (int)Singleton<MathUtils>.Instance.LongToBigInt(message.Id);
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		if (entity != null)
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component == null)
			{
				return;
			}
			AdviceEntityData adviceInfo = component.GetAdviceInfo();
			if (adviceInfo == null)
			{
				return;
			}
			adviceInfo.PhraseContent(message.Contents.ToList<PbAdviceContent>());
		}
	}

	// Token: 0x0600A8BB RID: 43195 RVA: 0x002CEB8C File Offset: 0x002CCD8C
	private void OnAdviceVoteUpdateNotify(AdviceVoteUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		long creatureDataId = Singleton<MathUtils>.Instance.LongToNumber(message.Id);
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
		if (entity != null && entity.Valid && entity.Entity != null)
		{
			CreatureDataComponent component = entity.Entity.GetComponent<CreatureDataComponent>();
			if (((component != null) ? component.GetAdviceInfo() : null) != null)
			{
				component.GetAdviceInfo().PhraseVote((long)message.UpVote);
				AdviceData adviceData = component.GetAdviceInfo().GetAdviceData();
				if (adviceData != null && adviceData.GetAdviceBigId() != null)
				{
					ModelBase<AdviceModel>.Instance.OnAdviceVoteUpdate(adviceData.GetAdviceBigId().Value, message);
				}
			}
		}
	}

	// Token: 0x0600A8BC RID: 43196 RVA: 0x002CEC2F File Offset: 0x002CCE2F
	private void OnAdviceUpdateNotify(AdviceUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<AdviceModel>.Instance.OnAdviceUpdateNotify(message);
	}

	// Token: 0x0600A8BD RID: 43197 RVA: 0x002CEC3C File Offset: 0x002CCE3C
	private void OnAdviceSettingNotify(AdviceSettingNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<AdviceModel>.Instance.SetAdviceShowSetting(message.IsShow);
	}

	// Token: 0x0600A8BE RID: 43198 RVA: 0x002CEC50 File Offset: 0x002CCE50
	public void RequestSetAdviceShowState(bool state)
	{
		AdviceSetRequest message = AdviceSetRequest.Create();
		message.IsShow = state;
		Singleton<Net>.Instance.Call<AdviceSetResponse>(ERequestMessageId.AdviceSetRequest, message, delegate(AdviceSetResponse response, Net.CallbackStatus _)
		{
			if (response == null || response.ErrorCode > Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25432, null, true, true);
				return;
			}
			ModelBase<AdviceModel>.Instance.SetAdviceShowSetting(message.IsShow);
		}, 0);
	}

	// Token: 0x0600A8BF RID: 43199 RVA: 0x002CEC9C File Offset: 0x002CCE9C
	public bool CheckInInValidArea()
	{
		IReadOnlyList<int> adviceCannotPutArea = ConfigBase<AdviceConfig>.Instance.GetAdviceCannotPutArea();
		Area? area;
		int num = (ModelBase<AreaModel>.Instance.AreaInfo != null) ? area.GetValueOrDefault().AreaId : 0;
		if (adviceCannotPutArea != null)
		{
			using (IEnumerator<int> enumerator = adviceCannotPutArea.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current == num)
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x0600A8C0 RID: 43200 RVA: 0x002CED24 File Offset: 0x002CCF24
	public bool CheckBehindAdviceActor()
	{
		IReadOnlyList<EntityHandle> allEntities = ModelBase<CreatureModel>.Instance.GetAllEntities();
		int playerId = ModelBase<FunctionModel>.Instance.PlayerId;
		int adviceCannotPutDistance = ConfigBase<AdviceConfig>.Instance.GetAdviceCannotPutDistance();
		if (allEntities == null)
		{
			return false;
		}
		foreach (EntityHandle entityHandle in allEntities)
		{
			if (((entityHandle != null) ? entityHandle.Entity : null) != null)
			{
				CreatureDataComponent component = entityHandle.Entity.GetComponent<CreatureDataComponent>();
				bool flag;
				if (component == null)
				{
					flag = false;
				}
				else
				{
					AdviceEntityData adviceInfo = component.GetAdviceInfo();
					long? num = (adviceInfo != null) ? new long?(adviceInfo.GetPlayerId()) : null;
					long num2 = (long)playerId;
					flag = (num.GetValueOrDefault() == num2 & num != null);
				}
				if (flag)
				{
					TsBaseCharacter baseCharacter = Global.BaseCharacter;
					BaseActorComponent component2 = entityHandle.Entity.GetComponent<BaseActorComponent>();
					AActor aactor = (component2 != null) ? component2.Owner : null;
					if (baseCharacter != null && aactor != null)
					{
						FVectorDouble v = aactor.D_K2_GetActorLocation();
						FVectorDouble v2 = baseCharacter.D_K2_GetActorLocation();
						if (UKismetMathLibrary.D_Vector_Distance(v, v2) <= (double)adviceCannotPutDistance)
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	// Token: 0x0600A8C1 RID: 43201 RVA: 0x002CEE40 File Offset: 0x002CD040
	public bool CheckIfStandAndInValidActor()
	{
		global::Vector vector = global::Vector.Create();
		global::Vector vector2 = global::Vector.Create();
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
		if (characterActorComponent == null)
		{
			return false;
		}
		global::Vector actorLocationProxy = characterActorComponent.ActorLocationProxy;
		vector.DeepCopy(actorLocationProxy);
		vector.Z += (double)characterActorComponent.DefaultHalfHeight;
		vector2.DeepCopy(actorLocationProxy);
		vector2.Z -= (double)(characterActorComponent.DefaultHalfHeight + 300f);
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		if (actorTrace == null)
		{
			return false;
		}
		actorTrace.WorldContextObject = characterActorComponent.Actor;
		actorTrace.Radius = characterActorComponent.DefaultRadius;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, vector);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, vector2);
		actorTrace.ActorsToIgnore.Empty(true);
		if (!Singleton<TraceElementCommon>.Instance.ShapeTrace(characterActorComponent.Actor.CapsuleComponent, actorTrace, "Advice", "Advice"))
		{
			ModelBase<TraceElementModel>.Instance.ClearActorTrace();
			return false;
		}
		UKuroHitResult hitResult = actorTrace.HitResult;
		int num = (hitResult != null) ? hitResult.GetHitCount() : 0;
		for (int i = 0; i < num; i++)
		{
			UKuroHitResult hitResult2 = actorTrace.HitResult;
			TWeakObjectPtr<AActor>? tweakObjectPtr;
			if (hitResult2 == null)
			{
				tweakObjectPtr = null;
			}
			else
			{
				TArray<TWeakObjectPtr<AActor>> actors = hitResult2.Actors;
				tweakObjectPtr = ((actors != null) ? new TWeakObjectPtr<AActor>?(actors.Get(i)) : null);
			}
			TWeakObjectPtr<AActor>? tweakObjectPtr2 = tweakObjectPtr;
			if (tweakObjectPtr2 != null)
			{
				TWeakObjectPtr<AActor>? tweakObjectPtr3 = tweakObjectPtr2;
				if (!this.GetActorIfValidForAdvice((tweakObjectPtr3 != null) ? tweakObjectPtr3.GetValueOrDefault() : null))
				{
					ModelBase<TraceElementModel>.Instance.ClearActorTrace();
					return false;
				}
			}
		}
		ModelBase<TraceElementModel>.Instance.ClearActorTrace();
		return true;
	}

	// Token: 0x0600A8C2 RID: 43202 RVA: 0x002CEFDC File Offset: 0x002CD1DC
	private bool GetActorIfValidForAdvice(AActor hitActor)
	{
		if (hitActor != null && hitActor is IBPI_CreatureInterface_C)
		{
			IBPI_CreatureInterface_C ibpi_CreatureInterface_C = hitActor as IBPI_CreatureInterface_C;
			int id = (ibpi_CreatureInterface_C != null) ? ibpi_CreatureInterface_C.GetEntityId() : 0;
			Entity entity = Singleton<EntitySystem>.Instance.Get(id);
			return entity == null || !entity.Valid;
		}
		SceneInteractionModel instance = ModelBase<SceneInteractionModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetEntityByActor(hitActor, false) : null;
		return entityHandle == null || !entityHandle.Valid;
	}

	// Token: 0x04004F6B RID: 20331
	public const int INFO_ADVICE_ITEM_TYPE = 20;

	// Token: 0x04004F6C RID: 20332
	private const string PROFILE_KEY = "Advice";
}
