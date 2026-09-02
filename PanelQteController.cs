using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.UI;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002353 RID: 9043
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PanelQteController : UiControllerBase<PanelQteController>
{
	// Token: 0x06011487 RID: 70791 RVA: 0x004C0C38 File Offset: 0x004BEE38
	public int StartAnimNotifyQte(int qteId, USkeletalMeshComponent meshComp, long? preMessageId)
	{
		if (!this.CheckCanStartQte())
		{
			return -1;
		}
		return this.StartQte(new PanelQteContext
		{
			QteId = qteId,
			PreMessageId = preMessageId,
			Source = new EPanelQteSource?(EPanelQteSource.AnimNotify),
			SourceMeshComp = meshComp,
			SourceActor = meshComp.GetOwner()
		});
	}

	// Token: 0x06011488 RID: 70792 RVA: 0x004C0C8C File Offset: 0x004BEE8C
	[NullableContext(2)]
	public int StartBuffQte(int qteId, long buffId, int buffHandleId, Entity buffOwner, long? preMessageId)
	{
		if (!this.CheckCanStartQte())
		{
			return -1;
		}
		if (buffOwner != null)
		{
			int id = buffOwner.Id;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			int? num = (baseCharacter != null) ? new int?(baseCharacter.EntityId) : null;
			if (id == num.GetValueOrDefault() & num != null)
			{
				PanelQteContext panelQteContext = new PanelQteContext();
				panelQteContext.QteId = qteId;
				panelQteContext.Source = new EPanelQteSource?(EPanelQteSource.Buff);
				panelQteContext.PreMessageId = preMessageId;
				panelQteContext.SourceBuffId = new long?(buffId);
				panelQteContext.SourceBuffHandleId = buffHandleId;
				PanelQteContext panelQteContext2 = panelQteContext;
				BaseActorComponent component = buffOwner.GetComponent<BaseActorComponent>();
				panelQteContext2.SourceActor = ((component != null) ? component.Owner : null);
				panelQteContext.SourceEntityHandle = ModelBase<CharacterModel>.Instance.GetHandleByEntity(buffOwner);
				panelQteContext.IsInitSourceEntity = true;
				return this.StartQte(panelQteContext);
			}
		}
		return -1;
	}

	// Token: 0x06011489 RID: 70793 RVA: 0x004C0D50 File Offset: 0x004BEF50
	public int StartLevelSequenceQte(int qteId, AActor actor)
	{
		if (!this.CheckCanStartQte())
		{
			return -1;
		}
		return this.StartQte(new PanelQteContext
		{
			QteId = qteId,
			Source = new EPanelQteSource?(EPanelQteSource.LevelSequence),
			SourceActor = actor
		});
	}

	// Token: 0x0601148A RID: 70794 RVA: 0x004C0D90 File Offset: 0x004BEF90
	public int StartLevelEventQte(int qteId)
	{
		if (!this.CheckCanStartQte())
		{
			return -1;
		}
		return this.StartQte(new PanelQteContext
		{
			QteId = qteId,
			Source = new EPanelQteSource?(EPanelQteSource.LevelEvent)
		});
	}

	// Token: 0x0601148B RID: 70795 RVA: 0x004C0DC8 File Offset: 0x004BEFC8
	public bool StopQte(int handleId, bool bForce = false)
	{
		if (!ModelBase<PanelQteModel>.Instance.StopQte(handleId))
		{
			return false;
		}
		PanelQteModel instance = ModelBase<PanelQteModel>.Instance;
		if (instance.IsHideAllBattleUi)
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.PanelQte, 0);
			instance.IsHideAllBattleUi = false;
		}
		else
		{
			int[] hideBattleUiChildren = instance.HideBattleUiChildren;
			if (hideBattleUiChildren != null)
			{
				List<EBattleUiChild> list = new List<EBattleUiChild>();
				foreach (int item in hideBattleUiChildren)
				{
					list.Add((EBattleUiChild)item);
				}
				ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.PanelQte, list, true, true, 0);
				instance.HideBattleUiChildren = null;
			}
		}
		if (instance.DisableFightInput)
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			BaseTagComponent baseTagComponent;
			if (((curRoleData != null) ? curRoleData.EntityHandle : null) == instance.CurRoleEntity)
			{
				baseTagComponent = curRoleData.GameplayTagComponent;
			}
			else
			{
				EntityHandle curRoleEntity = instance.CurRoleEntity;
				BaseTagComponent baseTagComponent2;
				if (curRoleEntity == null)
				{
					baseTagComponent2 = null;
				}
				else
				{
					WorldEntity entity = curRoleEntity.Entity;
					baseTagComponent2 = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
				}
				baseTagComponent = baseTagComponent2;
			}
			if (baseTagComponent != null)
			{
				foreach (int value in this._disableInputTagIds)
				{
					baseTagComponent.RemoveTag(new int?(value));
				}
			}
			else
			{
				Singleton<Log>.Instance.Error(ELogModule.PanelQte, ELogAuthor.CFT, "界面qte结束时，场上角色已经被销毁了", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			instance.CurRoleEntity = null;
			instance.DisableFightInput = false;
		}
		Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.PanelQteEnd, handleId, ModelBase<PanelQteModel>.Instance.IsQteSuccess());
		if (!bForce)
		{
			ModelBase<PanelQteModel>.Instance.HandleResult();
		}
		return true;
	}

	// Token: 0x0601148C RID: 70796 RVA: 0x004C0F3F File Offset: 0x004BF13F
	private bool CheckCanStartQte()
	{
		return !ModelBase<PanelQteModel>.Instance.IsInQte.GetValueOrDefault() && ModelBase<GameModeModel>.Instance.WorldDone && ModelBase<BattleUiModel>.Instance.GetCurRoleData() != null;
	}

	// Token: 0x0601148D RID: 70797 RVA: 0x004C0F74 File Offset: 0x004BF174
	private int StartQte(PanelQteContext context)
	{
		SPanelQte panelQteConfig = ModelBase<PanelQteModel>.Instance.GetPanelQteConfig(context.QteId);
		if (panelQteConfig == null)
		{
			return -1;
		}
		context.Config = panelQteConfig;
		PanelQteModel instance = ModelBase<PanelQteModel>.Instance;
		int num = instance.StartQte(context);
		int num2 = (int)context.Config.ViewType;
		switch (num2)
		{
		case 0:
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FrozenQteView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.FrozenQteView, null);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FrozenQteView, num, null);
			break;
		case 1:
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InteractQteView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.InteractQteView, null);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InteractQteView, num, null);
			instance.DisableFightInput = true;
			break;
		case 2:
			context.BuffIndex = (int)Math.Floor(Singleton<MathUtils>.Instance.Random.NextDouble() * (double)panelQteConfig.MaxSuccessCount);
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.YouHuQteView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.YouHuQteView, null);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.YouHuQteView, num, null);
			break;
		case 3:
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FreeRunningQteView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.FreeRunningQteView, null);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FreeRunningQteView, num, null);
			instance.DisableFightInput = true;
			break;
		default:
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PanelQte;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "QTE界面类型没有实现";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("", num2);
			instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			break;
		}
		}
		if (panelQteConfig.HideAllBattleUi)
		{
			instance.IsHideAllBattleUi = true;
			ModelBase<BattleUiModel>.Instance.ChildViewData.HideBattleView(EBattleUiVisibleReason.PanelQte, new <>z__ReadOnlySingleElementList<EBattleUiChild>(EBattleUiChild.PanelQTE), 0);
		}
		else
		{
			instance.IsHideAllBattleUi = false;
			int num3 = panelQteConfig.HideUIElement.Num();
			if (num3 > 0)
			{
				List<EBattleUiChild> list = new List<EBattleUiChild>();
				List<int> list2 = new List<int>();
				for (int i = 0; i < num3; i++)
				{
					int item = (int)panelQteConfig.HideUIElement.Get(i);
					list.Add((EBattleUiChild)item);
					list2.Add(item);
				}
				ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.PanelQte, list, false, true, 0);
				instance.HideBattleUiChildren = list2.ToArray();
			}
			else
			{
				instance.HideBattleUiChildren = null;
			}
		}
		if (instance.DisableFightInput)
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (curRoleData != null)
			{
				EntityHandle entityHandle = curRoleData.EntityHandle;
				BaseTagComponent gameplayTagComponent = curRoleData.GameplayTagComponent;
				if (gameplayTagComponent != null)
				{
					foreach (int value in this._disableInputTagIds)
					{
						gameplayTagComponent.AddTag(new int?(value));
					}
					instance.CurRoleEntity = entityHandle;
				}
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.PanelQteStart, num);
		return num;
	}

	// Token: 0x0601148E RID: 70798 RVA: 0x004C1255 File Offset: 0x004BF455
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange));
	}

	// Token: 0x0601148F RID: 70799 RVA: 0x004C1273 File Offset: 0x004BF473
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange));
	}

	// Token: 0x06011490 RID: 70800 RVA: 0x004C1294 File Offset: 0x004BF494
	private void OnTeamLivingStateChange(bool isMyTeam, ETeamGroupType groupType, ETeamLivingState state, ETeamLivingState oldState)
	{
		if (isMyTeam && groupType == ETeamGroupType.Battle && state == ETeamLivingState.Dead)
		{
			PanelQteContext context = ModelBase<PanelQteModel>.Instance.GetContext();
			if (context != null && context.QteHandleId != 0)
			{
				this.StopQte(context.QteHandleId, true);
			}
		}
	}

	// Token: 0x040087BC RID: 34748
	private readonly int[] _disableInputTagIds = new int[]
	{
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攻击"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止技能"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止大招"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止闪避"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止幻象1"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止跳跃"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攀爬"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止幻象2"],
		GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]
	};
}
