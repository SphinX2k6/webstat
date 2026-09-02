using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;

// Token: 0x0200319F RID: 12703
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class NpcPerformController : ControllerBase<NpcPerformController>
{
	// Token: 0x0601A59F RID: 107935 RVA: 0x007C384C File Offset: 0x007C1A4C
	protected override bool OnInit()
	{
		Singleton<Net>.Instance.Register<SetNpcPerformStateNotify>(ENotifyMessageId.SetNpcPerformStateNotify, new Action<SetNpcPerformStateNotify, Net.CallbackStatus>(this.SetPerformStateNotify));
		Singleton<EventSystem>.Instance.Add<ITrackData>(EEventName.TrackMark, new Action<ITrackData>(this.OnTrackMark));
		Singleton<EventSystem>.Instance.Add<ITrackData>(EEventName.UnTrackMark, new Action<ITrackData>(this.OnUnTrackMark));
		Singleton<Net>.Instance.Register<ShopBuyNotify>(ENotifyMessageId.ShopBuyNotify, new Action<ShopBuyNotify, Net.CallbackStatus>(this.OnShopBuyNotify));
		return true;
	}

	// Token: 0x0601A5A0 RID: 107936 RVA: 0x007C38CC File Offset: 0x007C1ACC
	protected override bool OnClear()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SetNpcPerformStateNotify);
		Singleton<EventSystem>.Instance.Remove(EEventName.TrackMark, new Action<ITrackData>(this.OnTrackMark));
		Singleton<EventSystem>.Instance.Remove(EEventName.UnTrackMark, new Action<ITrackData>(this.OnUnTrackMark));
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ShopBuyNotify);
		return true;
	}

	// Token: 0x0601A5A1 RID: 107937 RVA: 0x007C3934 File Offset: 0x007C1B34
	protected void SetPerformStateNotify(SetNpcPerformStateNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(data.EntityId);
		bool flag;
		if (entity == null)
		{
			flag = true;
		}
		else
		{
			WorldEntity entity2 = entity.Entity;
			flag = !((entity2 != null) ? new bool?(entity2.IsInit) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return;
		}
		entity.Entity.GetComponent<CommonNpcPerformComponent>().PerformGroupController.SwitchPerformState(data.State);
	}

	// Token: 0x0601A5A2 RID: 107938 RVA: 0x007C39A0 File Offset: 0x007C1BA0
	protected void OnTrackMark(ITrackData data)
	{
		TTrackTarget_Int ttrackTarget_Int = data.TrackTarget as TTrackTarget_Int;
		if (ttrackTarget_Int == null)
		{
			return;
		}
		int value = ttrackTarget_Int.Value;
		if (value == 0)
		{
			return;
		}
		this.ForceSetNpcDitherVisible(true, value, EForceVisibleReason.TrackMark);
	}

	// Token: 0x0601A5A3 RID: 107939 RVA: 0x007C39D4 File Offset: 0x007C1BD4
	protected void OnUnTrackMark(ITrackData data)
	{
		TTrackTarget_Int ttrackTarget_Int = data.TrackTarget as TTrackTarget_Int;
		if (ttrackTarget_Int == null)
		{
			return;
		}
		int value = ttrackTarget_Int.Value;
		if (value == 0)
		{
			return;
		}
		this.ForceSetNpcDitherVisible(false, value, EForceVisibleReason.TrackMark);
	}

	// Token: 0x0601A5A4 RID: 107940 RVA: 0x007C3A08 File Offset: 0x007C1C08
	public void ForceSetNpcDitherVisible(bool enable, int pbDataId, EForceVisibleReason reason)
	{
		if (enable)
		{
			if (this.ForceNpcDitherVisibleMap.ContainsKey(pbDataId))
			{
				this.ForceNpcDitherVisibleMap[pbDataId].Add(reason);
				return;
			}
			this.ForceNpcDitherVisibleMap[pbDataId] = new HashSet<EForceVisibleReason>
			{
				reason
			};
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
			if (entityByPbDataId == null || !entityByPbDataId.IsInit)
			{
				return;
			}
			NpcPerformComponent component = entityByPbDataId.Entity.GetComponent<NpcPerformComponent>();
			if (component == null)
			{
				return;
			}
			component.SetForceInShowRange(true);
			return;
		}
		else
		{
			if (!this.ForceNpcDitherVisibleMap.ContainsKey(pbDataId))
			{
				return;
			}
			HashSet<EForceVisibleReason> hashSet = this.ForceNpcDitherVisibleMap[pbDataId];
			hashSet.Remove(reason);
			if (hashSet.Count > 0)
			{
				return;
			}
			this.ForceNpcDitherVisibleMap.Remove(pbDataId);
			EntityHandle entityByPbDataId2 = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
			if (entityByPbDataId2 == null || !entityByPbDataId2.IsInit)
			{
				return;
			}
			NpcPerformComponent component2 = entityByPbDataId2.Entity.GetComponent<NpcPerformComponent>();
			if (component2 == null)
			{
				return;
			}
			component2.SetForceInShowRange(false);
			return;
		}
	}

	// Token: 0x0601A5A5 RID: 107941 RVA: 0x007C3AF5 File Offset: 0x007C1CF5
	protected void OnShopBuyNotify(ShopBuyNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeScrollingTipsView(data.ErrorCode, Array.Empty<string>());
	}

	// Token: 0x0601A5A6 RID: 107942 RVA: 0x007C3B0C File Offset: 0x007C1D0C
	public void AddNpcLookAtParams(INpcInterestLookAtParamGroup param)
	{
		if (this.EntityLookAtCacheForKey.ContainsKey(param.Key))
		{
			return;
		}
		this.EntityLookAtCacheForKey[param.Key] = param;
		foreach (int num in param.PbDataIds)
		{
			HashSet<string> hashSet;
			if (!this.EntityLookAtCacheForId.TryGetValue(num, out hashSet))
			{
				hashSet = new HashSet<string>();
				this.EntityLookAtCacheForId[num] = hashSet;
			}
			hashSet.Add(param.Key);
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num);
			WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
			CommonNpcPerformComponent commonNpcPerformComponent = (worldEntity != null) ? worldEntity.GetComponent<CommonNpcPerformComponent>() : null;
			if (worldEntity != null && worldEntity.IsInit && commonNpcPerformComponent != null)
			{
				commonNpcPerformComponent.InterestEventController.AddExternalLookAtInterestEvents(param);
			}
		}
	}

	// Token: 0x0601A5A7 RID: 107943 RVA: 0x007C3BF0 File Offset: 0x007C1DF0
	public void RemoveNpcLookAtParams(string key)
	{
		INpcInterestLookAtParamGroup npcInterestLookAtParamGroup;
		if (!this.EntityLookAtCacheForKey.TryGetValue(key, out npcInterestLookAtParamGroup))
		{
			return;
		}
		foreach (int num in npcInterestLookAtParamGroup.PbDataIds)
		{
			HashSet<string> hashSet;
			if (this.EntityLookAtCacheForId.TryGetValue(num, out hashSet))
			{
				hashSet.Remove(key);
				if (hashSet.Count == 0)
				{
					this.EntityLookAtCacheForId.Remove(num);
				}
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num);
				WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
				CommonNpcPerformComponent commonNpcPerformComponent = (worldEntity != null) ? worldEntity.GetComponent<CommonNpcPerformComponent>() : null;
				if (worldEntity != null && worldEntity.IsInit && commonNpcPerformComponent != null)
				{
					commonNpcPerformComponent.InterestEventController.RemoveExternalInterestEvent(key);
				}
			}
		}
		this.EntityLookAtCacheForKey.Remove(npcInterestLookAtParamGroup.Key);
	}

	// Token: 0x0400D488 RID: 54408
	public Dictionary<int, HashSet<EForceVisibleReason>> ForceNpcDitherVisibleMap = new Dictionary<int, HashSet<EForceVisibleReason>>();

	// Token: 0x0400D489 RID: 54409
	public Dictionary<int, HashSet<string>> EntityLookAtCacheForId = new Dictionary<int, HashSet<string>>();

	// Token: 0x0400D48A RID: 54410
	public Dictionary<string, INpcInterestLookAtParamGroup> EntityLookAtCacheForKey = new Dictionary<string, INpcInterestLookAtParamGroup>();
}
