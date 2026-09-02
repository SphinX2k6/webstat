using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02000F66 RID: 3942
[NullableContext(1)]
[Nullable(0)]
public class PinballBattleHeadStateManager
{
	// Token: 0x0600639B RID: 25499 RVA: 0x0018F5C8 File Offset: 0x0018D7C8
	public void Init()
	{
		string stringConfig = ConfigCommonParamById.GetStringConfig("HeadStateScaleCurvePath");
		this.HeadStateScaleCurve = Singleton<ResourceSystem>.Instance.Load<UCurveFloat>(stringConfig, "js_undefined");
	}

	// Token: 0x0600639C RID: 25500 RVA: 0x0018F5F8 File Offset: 0x0018D7F8
	public void Clear()
	{
		foreach (PinballBattleHeadStateUiBase pinballBattleHeadStateUiBase in this.HeadStateMap.Values)
		{
			pinballBattleHeadStateUiBase.DestroyAsync().Forget<bool>();
		}
		this.HeadStateMap.Clear();
	}

	// Token: 0x0600639D RID: 25501 RVA: 0x0018F660 File Offset: 0x0018D860
	public void UpdateHeadState(FKSC_HeadHpContext headContext)
	{
		EKSC_HeadHpContextType actionType = headContext.ActionType;
		if (actionType <= EKSC_HeadHpContextType.Update)
		{
			this.HandleAddOrUpdate(headContext);
			return;
		}
		if (actionType != EKSC_HeadHpContextType.Remove)
		{
			return;
		}
		this.HandleRemove(headContext);
	}

	// Token: 0x0600639E RID: 25502 RVA: 0x0018F68C File Offset: 0x0018D88C
	private void HandleAddOrUpdate(FKSC_HeadHpContext headContext)
	{
		PinballBattleHeadStateUiBase pinballBattleHeadStateUiBase;
		if (!this.HeadStateMap.TryGetValue(headContext.EntityId, out pinballBattleHeadStateUiBase))
		{
			pinballBattleHeadStateUiBase = this.CreateHeadUiItem(headContext);
			if (pinballBattleHeadStateUiBase == null)
			{
				return;
			}
			this.HeadStateMap[headContext.EntityId] = pinballBattleHeadStateUiBase;
		}
		pinballBattleHeadStateUiBase.UpdateByHeadInfo(headContext);
	}

	// Token: 0x0600639F RID: 25503 RVA: 0x0018F6D4 File Offset: 0x0018D8D4
	private void HandleRemove(FKSC_HeadHpContext headContext)
	{
		PinballBattleHeadStateUiBase pinballBattleHeadStateUiBase;
		if (this.HeadStateMap.TryGetValue(headContext.EntityId, out pinballBattleHeadStateUiBase))
		{
			pinballBattleHeadStateUiBase.DestroyAsync().Forget<bool>();
			this.HeadStateMap.Remove(headContext.EntityId);
		}
	}

	// Token: 0x060063A0 RID: 25504 RVA: 0x0018F714 File Offset: 0x0018D914
	[return: Nullable(2)]
	private PinballBattleHeadStateUiBase CreateHeadUiItem(FKSC_HeadHpContext headContext)
	{
		PinballBattleHeadStateUiBase pinballBattleHeadStateUiBase = null;
		string text = null;
		if (headContext.HeadUiType == EKSC_HeadUiType.Marble)
		{
			pinballBattleHeadStateUiBase = new PinballBattlePlayerHpBar();
			text = "UiItem_FlipperHP";
		}
		if (pinballBattleHeadStateUiBase == null || text == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PinballBattle;
			ELogAuthor author = ELogAuthor.LJ;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 2);
			defaultInterpolatedStringHandler.AppendLiteral("未注册的头部状态UI类型！EntityId: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(headContext.EntityId);
			defaultInterpolatedStringHandler.AppendLiteral(" HeadUiType: ");
			defaultInterpolatedStringHandler.AppendFormatted<EKSC_HeadUiType>(headContext.HeadUiType);
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		pinballBattleHeadStateUiBase.InitScaleCurve(this.HeadStateScaleCurve);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text);
		pinballBattleHeadStateUiBase.CreateThenShowByPathAsync(resourcePath, Singleton<UiLayer>.Instance.WorldSpaceUiRootItem, true).Forget();
		return pinballBattleHeadStateUiBase;
	}

	// Token: 0x04002FA2 RID: 12194
	private readonly Dictionary<int, PinballBattleHeadStateUiBase> HeadStateMap = new Dictionary<int, PinballBattleHeadStateUiBase>();

	// Token: 0x04002FA3 RID: 12195
	[Nullable(2)]
	private UCurveFloat HeadStateScaleCurve;
}
