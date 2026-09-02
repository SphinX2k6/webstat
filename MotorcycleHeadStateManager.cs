using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001D43 RID: 7491
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleHeadStateManager
{
	// Token: 0x0600DCC4 RID: 56516 RVA: 0x003B5374 File Offset: 0x003B3574
	public void Init()
	{
		string stringConfig = ConfigCommonParamById.GetStringConfig("MotorArrowDropHeadScaleCurvePath");
		this.DropHeadStateScaleCurve = Singleton<ResourceSystem>.Instance.Load<UCurveFloat>(stringConfig, "js_undefined");
	}

	// Token: 0x0600DCC5 RID: 56517 RVA: 0x003B53A4 File Offset: 0x003B35A4
	public void UpdateHeadState(Func<UiPanelBase> headStateClass, FKSC_HeadHpContext headInfo, [Nullable(2)] IBuffGateDesc buffGateInfo = null)
	{
		UiPanelBase uiPanelBase2;
		if (headInfo.ActionType == EKSC_HeadHpContextType.Add || headInfo.ActionType == EKSC_HeadHpContextType.Update)
		{
			UiPanelBase uiPanelBase;
			if (!this.HeadStateMap.TryGetValue(headInfo.EntityId, out uiPanelBase))
			{
				uiPanelBase = headStateClass();
				MotorcycleBuffGateHeadState motorcycleBuffGateHeadState = uiPanelBase as MotorcycleBuffGateHeadState;
				if (motorcycleBuffGateHeadState != null)
				{
					motorcycleBuffGateHeadState.CreateHeadStateView(Singleton<UiLayer>.Instance.WorldSpaceUiRootItem, buffGateInfo);
				}
				else
				{
					MotorcycleDropBuffGateHeadState motorcycleDropBuffGateHeadState = uiPanelBase as MotorcycleDropBuffGateHeadState;
					if (motorcycleDropBuffGateHeadState != null)
					{
						motorcycleDropBuffGateHeadState.CreateHeadStateView(Singleton<UiLayer>.Instance.WorldSpaceUiRootItem, buffGateInfo, this.DropHeadStateScaleCurve);
					}
					else
					{
						((DigitalHpHeadStateHeadState)uiPanelBase).CreateHeadStateView(Singleton<UiLayer>.Instance.WorldSpaceUiRootItem, headInfo);
					}
				}
				this.HeadStateMap[headInfo.EntityId] = uiPanelBase;
			}
			DigitalHpHeadStateHeadState digitalHpHeadStateHeadState = uiPanelBase as DigitalHpHeadStateHeadState;
			if (digitalHpHeadStateHeadState != null)
			{
				digitalHpHeadStateHeadState.UpdateByHeadInfo(headInfo);
				return;
			}
			MotorcycleBuffGateHeadState motorcycleBuffGateHeadState2 = uiPanelBase as MotorcycleBuffGateHeadState;
			if (motorcycleBuffGateHeadState2 != null)
			{
				motorcycleBuffGateHeadState2.UpdateByHeadInfo(headInfo);
				return;
			}
			MotorcycleDropBuffGateHeadState motorcycleDropBuffGateHeadState2 = uiPanelBase as MotorcycleDropBuffGateHeadState;
			if (motorcycleDropBuffGateHeadState2 != null)
			{
				motorcycleDropBuffGateHeadState2.UpdateByHeadInfo(headInfo);
				return;
			}
		}
		else if (headInfo.ActionType == EKSC_HeadHpContextType.Remove && this.HeadStateMap.TryGetValue(headInfo.EntityId, out uiPanelBase2))
		{
			uiPanelBase2.DestroyAsync().Forget<bool>();
			this.HeadStateMap.Remove(headInfo.EntityId);
		}
	}

	// Token: 0x0600DCC6 RID: 56518 RVA: 0x003B54C4 File Offset: 0x003B36C4
	private void SwapBattleBuff()
	{
		MotorcycleBattleBuff motorcycleBattleBuff = this.MotorcycleBattleBuff;
		this.MotorcycleBattleBuff = this.MotorcycleBattleBuffUp;
		this.MotorcycleBattleBuffUp = motorcycleBattleBuff;
	}

	// Token: 0x0600DCC7 RID: 56519 RVA: 0x003B54EC File Offset: 0x003B36EC
	private bool TryPlayBattleBuff(IBuffGateDesc buffGateInfo)
	{
		if ((float)Singleton<Time>.Instance.WorldTimeSeconds < this.NextBuffTime)
		{
			return false;
		}
		MotorcycleBattleBuff motorcycleBattleBuff = this.MotorcycleBattleBuff;
		if (motorcycleBattleBuff != null && motorcycleBattleBuff.IsFree)
		{
			this.MotorcycleBattleBuff.UpdateBuffInfo(buffGateInfo);
			this.MotorcycleBattleBuff.SetActive(true);
			this.NextBuffTime = (float)Singleton<Time>.Instance.WorldTimeSeconds + 500f;
			return true;
		}
		MotorcycleBattleBuff motorcycleBattleBuffUp = this.MotorcycleBattleBuffUp;
		if (motorcycleBattleBuffUp != null && motorcycleBattleBuffUp.IsFree)
		{
			this.MotorcycleBattleBuffUp.UpdateBuffInfo(buffGateInfo);
			this.MotorcycleBattleBuffUp.SetActive(true);
			this.MotorcycleBattleBuff.SetUp();
			this.SwapBattleBuff();
			this.NextBuffTime = (float)Singleton<Time>.Instance.WorldTimeSeconds + 500f;
			return true;
		}
		return false;
	}

	// Token: 0x0600DCC8 RID: 56520 RVA: 0x003B55AC File Offset: 0x003B37AC
	public void CreateMotorcycleBuffItem(IBuffGateDesc buffGateInfo)
	{
		if (this.MotorcycleBattleBuff == null)
		{
			this.MotorcycleBattleBuff = new MotorcycleBattleBuff();
			this.MotorcycleBattleBuff.CreateHeadStateView(Singleton<UiLayer>.Instance.WorldSpaceUiRootItem, buffGateInfo);
			this.MotorcycleBattleBuffUp = new MotorcycleBattleBuff();
			this.MotorcycleBattleBuffUp.CreateHeadStateView(Singleton<UiLayer>.Instance.WorldSpaceUiRootItem, buffGateInfo);
		}
		if (!this.TryPlayBattleBuff(buffGateInfo))
		{
			this.WaitToShowBattleBuff.Add(buffGateInfo);
		}
	}

	// Token: 0x0600DCC9 RID: 56521 RVA: 0x003B5618 File Offset: 0x003B3818
	public void Tick()
	{
		if (this.MotorcycleBattleBuff == null)
		{
			return;
		}
		if (this.WaitToShowBattleBuff.Count > 0 && this.TryPlayBattleBuff(this.WaitToShowBattleBuff[0]))
		{
			this.WaitToShowBattleBuff.RemoveAt(0);
		}
		this.MotorcycleBattleBuff.Tick();
		this.MotorcycleBattleBuffUp.Tick();
	}

	// Token: 0x0600DCCA RID: 56522 RVA: 0x003B5674 File Offset: 0x003B3874
	public void Clear()
	{
		foreach (UiPanelBase uiPanelBase in this.HeadStateMap.Values)
		{
			uiPanelBase.DestroyAsync().Forget<bool>();
		}
		this.HeadStateMap.Clear();
		MotorcycleBattleBuff motorcycleBattleBuff = this.MotorcycleBattleBuff;
		if (motorcycleBattleBuff != null)
		{
			motorcycleBattleBuff.DestroyAsync().Forget<bool>();
		}
		this.MotorcycleBattleBuff = null;
		MotorcycleBattleBuff motorcycleBattleBuffUp = this.MotorcycleBattleBuffUp;
		if (motorcycleBattleBuffUp != null)
		{
			motorcycleBattleBuffUp.DestroyAsync().Forget<bool>();
		}
		this.MotorcycleBattleBuffUp = null;
		this.WaitToShowBattleBuff.Clear();
		this.DropHeadStateScaleCurve = null;
	}

	// Token: 0x040069AF RID: 27055
	private const int NEXT_BUFF_DURATION = 500;

	// Token: 0x040069B0 RID: 27056
	private readonly Dictionary<int, UiPanelBase> HeadStateMap = new Dictionary<int, UiPanelBase>();

	// Token: 0x040069B1 RID: 27057
	[Nullable(2)]
	private UCurveFloat DropHeadStateScaleCurve;

	// Token: 0x040069B2 RID: 27058
	private float NextBuffTime;

	// Token: 0x040069B3 RID: 27059
	[Nullable(2)]
	public MotorcycleBattleBuff MotorcycleBattleBuff;

	// Token: 0x040069B4 RID: 27060
	[Nullable(2)]
	public MotorcycleBattleBuff MotorcycleBattleBuffUp;

	// Token: 0x040069B5 RID: 27061
	public List<IBuffGateDesc> WaitToShowBattleBuff = new List<IBuffGateDesc>();
}
