using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Vision;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.Teleport;
using Google.Protobuf.Collections;

// Token: 0x0200315A RID: 12634
[NullableContext(2)]
[Nullable(0)]
public class CharacterVisionComponent : EntityComponent
{
	// Token: 0x0601A2C1 RID: 107201 RVA: 0x007AFF14 File Offset: 0x007AE114
	protected override bool OnStart()
	{
		EntityComponentPb valueOrDefault = base.Entity.GetComponent<CreatureDataComponent>().ComponentDataMap.GetValueOrDefault("VisionSkillComponent");
		VisionSkillComponentPb visionSkillComponentPb = (valueOrDefault != null) ? valueOrDefault.VisionSkillComponent : null;
		RepeatedField<VisionSkillInformation> repeatedField = (visionSkillComponentPb != null) ? visionSkillComponentPb.VisionSkillInfos : null;
		VisionSkillInformation visionControlSkillInfo = (visionSkillComponentPb != null) ? visionSkillComponentPb.PhantomSkillInfo : null;
		if (this.VisionInformationList == null)
		{
			this.VisionInformationList = ((repeatedField != null) ? new List<VisionSkillInformation>(repeatedField) : new List<VisionSkillInformation>());
		}
		if (this.VisionControlSkillInfo == null)
		{
			this.VisionControlSkillInfo = visionControlSkillInfo;
		}
		this.RefreshVisionIdList();
		BaseTagComponent component = base.Entity.GetComponent<BaseTagComponent>();
		if (component != null)
		{
			this.VisionTriggerTask = component.ListenForTagAnyCountChanged(visionTriggerTag.Value, delegate(int newCount, int tagId, int exactTagId, int oldCount)
			{
				if (newCount > oldCount)
				{
					ControllerBase<SceneTeamController>.Instance.EmitEvent<int>(base.Entity, EEventName.ActivateAbilityVision, exactTagId);
				}
			});
		}
		foreach (ValueTuple<EVisionType, Func<CharacterVisionComponent, GameplayAbilityVisionBase>> valueTuple in visionTypes.Value)
		{
			EVisionType item = valueTuple.Item1;
			Func<CharacterVisionComponent, GameplayAbilityVisionBase> item2 = valueTuple.Item2;
			this.GameplayAbilityVisionMap[item] = GameplayAbilityVisionBase.Spawn(item2, this);
		}
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
		Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharSkillTargetChanged, new Action<EntityHandle, string>(this.OnSkillTargetChanged));
		this.AddVisionInputLayer();
		return true;
	}

	// Token: 0x0601A2C2 RID: 107202 RVA: 0x007B0064 File Offset: 0x007AE264
	protected override bool OnEnd()
	{
		foreach (GameplayAbilityVisionBase gameplayAbilityVisionBase in this.GameplayAbilityVisionMap.Values)
		{
			gameplayAbilityVisionBase.Destroy();
		}
		if (this.VisionTriggerTask != null)
		{
			this.VisionTriggerTask.EndTask();
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharSkillTargetChanged, new Action<EntityHandle, string>(this.OnSkillTargetChanged));
		this.RemoveVisionInputLayer();
		return true;
	}

	// Token: 0x0601A2C3 RID: 107203 RVA: 0x007B012C File Offset: 0x007AE32C
	protected override void OnTick(float delta)
	{
		foreach (GameplayAbilityVisionBase gameplayAbilityVisionBase in this.GameplayAbilityVisionMap.Values)
		{
			gameplayAbilityVisionBase.Tick(delta);
		}
	}

	// Token: 0x0601A2C4 RID: 107204 RVA: 0x007B0184 File Offset: 0x007AE384
	[NullableContext(1)]
	public void SetVisionData(VisionSkillChangeNotify data)
	{
		this.VisionInformationList = new List<VisionSkillInformation>(data.VisionSkillInfos);
		this.VisionControlSkillInfo = data.PhantomSkillInfo;
		this.RefreshVisionIdList();
	}

	// Token: 0x0601A2C5 RID: 107205 RVA: 0x007B01AC File Offset: 0x007AE3AC
	public int GetVisionLevel()
	{
		int currentPosition = this.GetCurrentPosition();
		if (this.VisionInformationList == null || currentPosition < 0 || currentPosition >= this.VisionInformationList.Count)
		{
			return 0;
		}
		return this.VisionInformationList[currentPosition].Quality;
	}

	// Token: 0x0601A2C6 RID: 107206 RVA: 0x007B01F0 File Offset: 0x007AE3F0
	public int GetVisionLevelByBuffId(long buffId)
	{
		if (this.VisionInformationList != null)
		{
			foreach (VisionSkillInformation visionSkillInformation in this.VisionInformationList)
			{
				if (visionSkillInformation.Quality > 0 && PhantomUtil.GetSkillBuffIds(visionSkillInformation.SkillId).Contains(buffId))
				{
					return visionSkillInformation.Quality;
				}
			}
			return -1;
		}
		return -1;
	}

	// Token: 0x0601A2C7 RID: 107207 RVA: 0x007B026C File Offset: 0x007AE46C
	public int GetVisionLevelByDamageId(long damageId)
	{
		if (this.VisionInformationList != null)
		{
			foreach (VisionSkillInformation visionSkillInformation in this.VisionInformationList)
			{
				if (visionSkillInformation.Quality > 0 && PhantomUtil.GetSkillSettleIds(visionSkillInformation.SkillId).Contains(damageId))
				{
					return visionSkillInformation.Quality;
				}
			}
			return -1;
		}
		return -1;
	}

	// Token: 0x0601A2C8 RID: 107208 RVA: 0x007B02E8 File Offset: 0x007AE4E8
	public SVisionData GetVisionData(int visionId)
	{
		if (Array.IndexOf<int>(this.VisionIdList, visionId) < 0)
		{
			return null;
		}
		return PhantomUtil.GetVisionData(visionId);
	}

	// Token: 0x0601A2C9 RID: 107209 RVA: 0x007B0304 File Offset: 0x007AE504
	public bool ActivateAbilityVision(EVisionType visionType)
	{
		bool flag = this.GameplayAbilityVisionMap.ContainsKey(visionType) && this.GameplayAbilityVisionMap[visionType].ActivateAbility();
		if (flag && (visionType == EVisionType.召唤 || visionType == EVisionType.变身 || visionType == EVisionType.驻场))
		{
			ControllerBase<SceneTeamController>.Instance.EmitEvent<int>(base.Entity, EEventName.ActivateAbilityVision, this.GetVisionId(new int?(0)));
			this.VisionTriggerPush(this.GetVisionId(new int?(0)));
		}
		return flag;
	}

	// Token: 0x0601A2CA RID: 107210 RVA: 0x007B0374 File Offset: 0x007AE574
	public bool EndAbilityVision(EVisionType visionType)
	{
		return this.GameplayAbilityVisionMap.ContainsKey(visionType) && this.GameplayAbilityVisionMap[visionType].EndAbility();
	}

	// Token: 0x0601A2CB RID: 107211 RVA: 0x007B0398 File Offset: 0x007AE598
	public int GetVisionId(int? pos = null)
	{
		int num = pos ?? this.GetCurrentPosition();
		if (num < 0 || num >= this.VisionIdList.Length)
		{
			return 0;
		}
		return this.VisionIdList[num];
	}

	// Token: 0x0601A2CC RID: 107212 RVA: 0x007B03D9 File Offset: 0x007AE5D9
	public int GetVisionControlSkillId()
	{
		VisionSkillInformation visionControlSkillInfo = this.VisionControlSkillInfo;
		if (visionControlSkillInfo == null)
		{
			return 0;
		}
		return visionControlSkillInfo.SkillId;
	}

	// Token: 0x0601A2CD RID: 107213 RVA: 0x007B03EC File Offset: 0x007AE5EC
	public bool HandlePress(AkiClient.Game.Aki.Character.Input.Enum.EInputAction action, float time)
	{
		using (Dictionary<EVisionType, GameplayAbilityVisionBase>.ValueCollection.Enumerator enumerator = this.GameplayAbilityVisionMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.HandlePress(action, time))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0601A2CE RID: 107214 RVA: 0x007B044C File Offset: 0x007AE64C
	public void SetCurrentPosition(int pos)
	{
		if (this.Position != pos)
		{
			this.Position = pos;
			Singleton<EventSystem>.Instance.EmitWithTarget<int>(base.Entity, EEventName.EntityVisionPosChanged, pos);
		}
	}

	// Token: 0x0601A2CF RID: 107215 RVA: 0x007B0475 File Offset: 0x007AE675
	public int GetCurrentPosition()
	{
		return this.Position;
	}

	// Token: 0x0601A2D0 RID: 107216 RVA: 0x007B0480 File Offset: 0x007AE680
	public long GetVisionCreatureDataId()
	{
		int currentPosition = this.GetCurrentPosition();
		if (this.VisionInformationList == null || currentPosition < 0 || currentPosition >= this.VisionInformationList.Count)
		{
			return 0L;
		}
		return Singleton<MathUtils>.Instance.LongToNumber(this.VisionInformationList[currentPosition].VisionEntityId);
	}

	// Token: 0x0601A2D1 RID: 107217 RVA: 0x007B04CC File Offset: 0x007AE6CC
	private void RefreshVisionIdList()
	{
		VisionSkillInformation visionSkillInformation = null;
		int currentPosition = -1;
		if (this.VisionInformationList != null)
		{
			for (int i = 0; i < this.VisionInformationList.Count; i++)
			{
				VisionSkillInformation visionSkillInformation2 = this.VisionInformationList[i];
				if (visionSkillInformation2.Index == 0)
				{
					visionSkillInformation = visionSkillInformation2;
					currentPosition = i;
					break;
				}
			}
			this.VisionIdList = new int[this.VisionInformationList.Count];
			for (int j = 0; j < this.VisionInformationList.Count; j++)
			{
				this.VisionIdList[j] = this.VisionInformationList[j].SkillId;
			}
		}
		else
		{
			this.VisionIdList = new int[0];
		}
		if (visionSkillInformation == null)
		{
			this.SetCurrentPosition(-1);
			return;
		}
		this.SetCurrentPosition(currentPosition);
		CharacterSkillCdComponent component = base.Entity.GetComponent<CharacterSkillCdComponent>();
		if (component == null)
		{
			return;
		}
		component.ModifyCdInfo(PhantomUtil.GetSkillGroupId(visionSkillInformation.SkillId), (float)PhantomUtil.GetSkillCd(visionSkillInformation.SkillId));
	}

	// Token: 0x0601A2D2 RID: 107218 RVA: 0x007B05B0 File Offset: 0x007AE7B0
	private void OnTeleportStart(bool loading)
	{
		foreach (GameplayAbilityVisionBase gameplayAbilityVisionBase in this.GameplayAbilityVisionMap.Values)
		{
			gameplayAbilityVisionBase.TeleportStart();
		}
		if (loading && this.VisionInformationList != null)
		{
			foreach (VisionSkillInformation visionSkillInformation in this.VisionInformationList)
			{
				long visionEntityId = visionSkillInformation.VisionEntityId;
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(Singleton<MathUtils>.Instance.LongToNumber(visionEntityId));
				if (entity != null && entity.Valid)
				{
					ControllerBase<CreatureController>.Instance.SetEntityEnable(entity.Entity, false, "OnTeleportStart.SetVisionEnable", false);
				}
			}
		}
	}

	// Token: 0x0601A2D3 RID: 107219 RVA: 0x007B0688 File Offset: 0x007AE888
	private void OnTeleportComplete(TeleportContext teleportContext)
	{
		if (this.VisionInformationList == null)
		{
			return;
		}
		foreach (VisionSkillInformation visionSkillInformation in this.VisionInformationList)
		{
			SVisionData visionData = PhantomUtil.GetVisionData(visionSkillInformation.SkillId);
			if (visionData != null && visionData.类型 == EVisionType.驻场)
			{
				long visionEntityId = visionSkillInformation.VisionEntityId;
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(Singleton<MathUtils>.Instance.LongToNumber(visionEntityId));
				if (entity != null && entity.Valid)
				{
					CreatureDataComponent creatureDataComponent;
					if (entity == null)
					{
						creatureDataComponent = null;
					}
					else
					{
						WorldEntity entity2 = entity.Entity;
						creatureDataComponent = ((entity2 != null) ? entity2.GetComponent<CreatureDataComponent>() : null);
					}
					CreatureDataComponent creatureDataComponent2 = creatureDataComponent;
					if (creatureDataComponent2 != null)
					{
						SummonCfg? config = ConfigSummonCfgById.GetConfig(creatureDataComponent2.SummonCfgId, true);
						if (config != null && config.GetValueOrDefault().InitVisiable)
						{
							ControllerBase<CreatureController>.Instance.SetEntityEnable(entity.Entity, true, "OnTeleportComplete.SetVisionEnable", false);
						}
					}
				}
			}
		}
	}

	// Token: 0x0601A2D4 RID: 107220 RVA: 0x007B07A8 File Offset: 0x007AE9A8
	[NullableContext(1)]
	private void OnSkillTargetChanged([Nullable(2)] EntityHandle skillTarget, string skillTargetSocket)
	{
		EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(base.Entity, ESummonType.ConcomitantVision, 1);
		CharacterSkillComponent characterSkillComponent;
		if (summonedEntity == null)
		{
			characterSkillComponent = null;
		}
		else
		{
			WorldEntity entity = summonedEntity.Entity;
			characterSkillComponent = ((entity != null) ? entity.GetComponent<CharacterSkillComponent>() : null);
		}
		CharacterSkillComponent characterSkillComponent2 = characterSkillComponent;
		if (characterSkillComponent2 != null && characterSkillComponent2.Valid)
		{
			characterSkillComponent2.SkillTarget = skillTarget;
			characterSkillComponent2.SkillTargetSocket = skillTargetSocket;
		}
	}

	// Token: 0x0601A2D5 RID: 107221 RVA: 0x007B07F4 File Offset: 0x007AE9F4
	private void AddVisionInputLayer()
	{
		this.InputLayer = (ControllerBase<InputController>.Instance.CreateInputLayer(EInputLayer.Vision) as VisionInputLayer);
		if (this.InputLayer != null)
		{
			EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(base.Entity);
			if (handleByEntity != null)
			{
				this.InputLayer.Init(handleByEntity);
				ControllerBase<InputController>.Instance.AddInputLayer(base.Entity.Id, this.InputLayer);
			}
		}
	}

	// Token: 0x0601A2D6 RID: 107222 RVA: 0x007B085A File Offset: 0x007AEA5A
	private void RemoveVisionInputLayer()
	{
		if (this.InputLayer != null)
		{
			ControllerBase<InputController>.Instance.RemoveInputLayer(this.InputLayer);
			this.InputLayer.Clear();
			this.InputLayer = null;
		}
	}

	// Token: 0x0601A2D7 RID: 107223 RVA: 0x007B0888 File Offset: 0x007AEA88
	private void VisionTriggerPush(int visionId)
	{
		VisionTriggerPush visionTriggerPush = Aki.Protocol.VisionTriggerPush.Create();
		visionTriggerPush.NumberId = visionId;
		Singleton<CombatNet>.Instance.Send(EPushMessageId.VisionTriggerPush, base.Entity, visionTriggerPush, null, null, null);
	}

	// Token: 0x0601A2D8 RID: 107224 RVA: 0x007B08D4 File Offset: 0x007AEAD4
	[CombatListen(ENotifyMessageId.VisionTriggerNotify, true, false)]
	public static void VisionTriggerNotify(Entity entity, [Nullable(1)] VisionTriggerNotify data, CombatCommon combatCommon = null)
	{
		if (entity == null)
		{
			return;
		}
		int numberId = data.NumberId;
		ControllerBase<SceneTeamController>.Instance.EmitEvent<int>(entity, EEventName.ActivateAbilityVision, numberId);
	}

	// Token: 0x0601A2D9 RID: 107225 RVA: 0x007B0900 File Offset: 0x007AEB00
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterVisionComponent characterVisionComponent = (CharacterVisionComponent)componentTemplate;
		if (base.CanResetComponentProperty("VisionInformationList"))
		{
			if (characterVisionComponent.VisionInformationList == null)
			{
				this.VisionInformationList = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<VisionSkillInformation>>(this.VisionInformationList), "VisionInformationList"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("VisionControlSkillInfo"))
		{
			if (characterVisionComponent.VisionControlSkillInfo == null)
			{
				this.VisionControlSkillInfo = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VisionSkillInformation>(this.VisionControlSkillInfo), "VisionControlSkillInfo"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("GameplayAbilityVisionMap") && characterVisionComponent.GameplayAbilityVisionMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EVisionType, GameplayAbilityVisionBase>>(this.GameplayAbilityVisionMap), "GameplayAbilityVisionMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("VisionIdList"))
		{
			if (characterVisionComponent.VisionIdList == null)
			{
				this.VisionIdList = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<int[]>(this.VisionIdList), "VisionIdList"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InputLayer"))
		{
			if (characterVisionComponent.InputLayer == null)
			{
				this.InputLayer = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VisionInputLayer>(this.InputLayer), "InputLayer"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("VisionTriggerTask"))
		{
			if (characterVisionComponent.VisionTriggerTask == null)
			{
				this.VisionTriggerTask = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.VisionTriggerTask), "VisionTriggerTask"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("Position"))
		{
			this.Position = characterVisionComponent.Position;
		}
		return true;
	}

	// Token: 0x0400D27D RID: 53885
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<VisionSkillInformation> VisionInformationList;

	// Token: 0x0400D27E RID: 53886
	private VisionSkillInformation VisionControlSkillInfo;

	// Token: 0x0400D27F RID: 53887
	[Nullable(1)]
	private readonly Dictionary<EVisionType, GameplayAbilityVisionBase> GameplayAbilityVisionMap = new Dictionary<EVisionType, GameplayAbilityVisionBase>();

	// Token: 0x0400D280 RID: 53888
	[Nullable(1)]
	private int[] VisionIdList = new int[0];

	// Token: 0x0400D281 RID: 53889
	private VisionInputLayer InputLayer;

	// Token: 0x0400D282 RID: 53890
	private ITagTask VisionTriggerTask;

	// Token: 0x0400D283 RID: 53891
	private int Position = -1;
}
