using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x020032A0 RID: 12960
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleUiComponent : EntityComponent
{
	// Token: 0x0601B2AB RID: 111275 RVA: 0x0082ADC5 File Offset: 0x00828FC5
	protected override bool OnStart()
	{
		this.TagComp = base.Entity.GetComponent<VehicleTagComponent>();
		return true;
	}

	// Token: 0x0601B2AC RID: 111276 RVA: 0x0082ADDC File Offset: 0x00828FDC
	protected override void OnActivate()
	{
		this.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["载具.摩托.滑轨.能够跳跃上轨"], new BaseTagComponent.TTagSwitchedCallback(this.OnJumpTagChange));
		this.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中"], new BaseTagComponent.TTagSwitchedCallback(this.OnAirTagChange));
	}

	// Token: 0x0601B2AD RID: 111277 RVA: 0x0082AE2B File Offset: 0x0082902B
	protected override bool OnEnd()
	{
		this.ClearAllTagTask();
		Singleton<EventSystem>.Instance.RemoveAllTargetUseKey(this);
		return true;
	}

	// Token: 0x0601B2AE RID: 111278 RVA: 0x0082AE40 File Offset: 0x00829040
	private void ListenForTagAddOrRemove(int tagId, BaseTagComponent.TTagSwitchedCallback onTagChange)
	{
		if (this.TagComp == null)
		{
			return;
		}
		ITagTask item = this.TagComp.ListenForTagAddOrRemove(new int?(tagId), onTagChange, null);
		this.TagTaskList.Add(item);
		if (this.TagComp.HasTag(tagId))
		{
			onTagChange(tagId, true);
		}
	}

	// Token: 0x0601B2AF RID: 111279 RVA: 0x0082AE8C File Offset: 0x0082908C
	private void ClearAllTagTask()
	{
		foreach (ITagTask tagTask in this.TagTaskList)
		{
			tagTask.EndTask();
		}
		this.TagTaskList.Clear();
	}

	// Token: 0x0601B2B0 RID: 111280 RVA: 0x0082AEE8 File Offset: 0x008290E8
	private void OnJumpTagChange(int tagId, bool tagExist)
	{
		this.SetPlayerTagEnable(GameplayTagDefine.EGameplayTagId["UI.摩托.键鼠显示子弹跳按键"], tagExist);
	}

	// Token: 0x0601B2B1 RID: 111281 RVA: 0x0082AF00 File Offset: 0x00829100
	private void OnAirTagChange(int tagId, bool tagExist)
	{
		this.SetSelfTagEnable(GameplayTagDefine.EGameplayTagId["UI.摩托.可抬升"], tagExist);
		this.SetSelfTagEnable(GameplayTagDefine.EGameplayTagId["UI.摩托.可压低"], tagExist);
	}

	// Token: 0x0601B2B2 RID: 111282 RVA: 0x0082AF30 File Offset: 0x00829130
	private void SetPlayerTagEnable(int tagId, bool enable)
	{
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		if (!ControllerBase<FormationDataController>.Instance.IsPlayerExist(playerId))
		{
			return;
		}
		bool flag = ControllerBase<FormationDataController>.Instance.HasPlayerTag(playerId, tagId, true);
		if (enable && !flag)
		{
			ControllerBase<FormationDataController>.Instance.AddPlayerTag(playerId, new int?(tagId));
			return;
		}
		if (!enable && flag)
		{
			ControllerBase<FormationDataController>.Instance.RemovePlayerTag(playerId, new int?(tagId));
		}
	}

	// Token: 0x0601B2B3 RID: 111283 RVA: 0x0082AF98 File Offset: 0x00829198
	private void SetSelfTagEnable(int tagId, bool enable)
	{
		if (this.TagComp == null)
		{
			return;
		}
		bool flag = this.TagComp.HasTag(tagId);
		if (enable && !flag)
		{
			this.TagComp.AddTag(new int?(tagId));
			return;
		}
		if (!enable && flag)
		{
			this.TagComp.RemoveTag(new int?(tagId));
		}
	}

	// Token: 0x0601B2B4 RID: 111284 RVA: 0x0082AFF0 File Offset: 0x008291F0
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		MotorcycleUiComponent motorcycleUiComponent = (MotorcycleUiComponent)componentTemplate;
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (motorcycleUiComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		return !base.CanResetComponentProperty("TagTaskList") || motorcycleUiComponent.TagTaskList == null || base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.TagTaskList), "TagTaskList");
	}

	// Token: 0x0400DD4E RID: 56654
	[Nullable(2)]
	private VehicleTagComponent TagComp;

	// Token: 0x0400DD4F RID: 56655
	private readonly List<ITagTask> TagTaskList = new List<ITagTask>();
}
