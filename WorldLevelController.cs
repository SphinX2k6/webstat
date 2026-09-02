using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x02002D69 RID: 11625
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class WorldLevelController : UiControllerBase<WorldLevelController>
{
	// Token: 0x0601777A RID: 96122 RVA: 0x00681578 File Offset: 0x0067F778
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OriginWorldLevelUp, new Action(this.OnOriginWorldLevelUp));
		Singleton<EventSystem>.Instance.Add(EEventName.BackLoginView, new Action(this.OnBackLoginView));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.TsResponseWorldLevelChangeInFight, new Action<bool>(this.OnTsResponseWorldLevelChangeInFight));
		Singleton<EventSystem>.Instance.Add(EEventName.TsSyncWorldLevelChangeEvent, new Action(this.TsSyncWorldLevelChangeEvent));
		Singleton<EventSystem>.Instance.Add(EEventName.TsSyncOriginWorldLevelUpEvent, new Action(this.TsSyncOriginWorldLevelUpEvent));
	}

	// Token: 0x0601777B RID: 96123 RVA: 0x0068162C File Offset: 0x0067F82C
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OriginWorldLevelUp, new Action(this.OnOriginWorldLevelUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.BackLoginView, new Action(this.OnBackLoginView));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsResponseWorldLevelChangeInFight, new Action<bool>(this.OnTsResponseWorldLevelChangeInFight));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncWorldLevelChangeEvent, new Action(this.TsSyncWorldLevelChangeEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncOriginWorldLevelUpEvent, new Action(this.TsSyncOriginWorldLevelUpEvent));
	}

	// Token: 0x0601777C RID: 96124 RVA: 0x006816DE File Offset: 0x0067F8DE
	protected override void OnRegisterNetEvent()
	{
	}

	// Token: 0x0601777D RID: 96125 RVA: 0x006816E0 File Offset: 0x0067F8E0
	protected override void OnUnRegisterNetEvent()
	{
	}

	// Token: 0x0601777E RID: 96126 RVA: 0x006816E2 File Offset: 0x0067F8E2
	public void OnBasicInfoNotify(RepeatedField<PlayerAttr> attributes)
	{
		this.SetWorldLevelAttributes(attributes);
	}

	// Token: 0x0601777F RID: 96127 RVA: 0x006816EB File Offset: 0x0067F8EB
	public void OnPlayerAttrNotify(RepeatedField<PlayerAttr> attributes)
	{
		this.SetWorldLevelAttributes(attributes);
	}

	// Token: 0x06017780 RID: 96128 RVA: 0x006816F4 File Offset: 0x0067F8F4
	public void SetWorldLevelAttributes(RepeatedField<PlayerAttr> attributes)
	{
		foreach (PlayerAttr playerAttr in attributes)
		{
			if (playerAttr.Key == PlayerAttrKey.OriginWorldLevel)
			{
				ModelBase<WorldLevelModel>.Instance.OriginWorldLevel = playerAttr.Int32Value;
			}
			if (playerAttr.Key == PlayerAttrKey.CurWorldLevel)
			{
				ModelBase<WorldLevelModel>.Instance.CurWorldLevel = playerAttr.Int32Value;
			}
			if (playerAttr.Key == PlayerAttrKey.WorldLevelTimeStamp)
			{
				ModelBase<WorldLevelModel>.Instance.LastChangeWorldLevelTimeStamp = playerAttr.Int32Value;
			}
			if (playerAttr.Key == PlayerAttrKey.Sex)
			{
				ModelBase<WorldLevelModel>.Instance.Sex = playerAttr.Int32Value;
				ModelBase<PersonalModel>.Instance.SetSex(playerAttr.Int32Value);
			}
			if (playerAttr.Key == PlayerAttrKey.Sign)
			{
				ModelBase<PersonalModel>.Instance.SetSignature(playerAttr.StringValue);
			}
			if (playerAttr.Key == PlayerAttrKey.PlayerTitle)
			{
				string[] array = playerAttr.StringValue.Split('_', StringSplitOptions.None);
				int? starLevel = (array.Length == 2) ? new int?(int.Parse(array[1])) : null;
				int playerTitleId;
				if (!int.TryParse(array[0], out playerTitleId))
				{
					playerTitleId = 0;
				}
				ModelBase<PersonalModel>.Instance.SetDressedPlayerTitle(playerTitleId, starLevel);
			}
		}
	}

	// Token: 0x06017781 RID: 96129 RVA: 0x00681824 File Offset: 0x0067FA24
	public void OnOriginWorldLevelUp()
	{
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.WorldLevelUpView))
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.WorldLevelUpViewRefresh);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WorldLevelUpView, null, null);
	}

	// Token: 0x06017782 RID: 96130 RVA: 0x00681859 File Offset: 0x0067FA59
	public void OpenWorldLevelInfoView()
	{
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.WorldLevelInfoView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WorldLevelInfoView, null, null);
		}
	}

	// Token: 0x06017783 RID: 96131 RVA: 0x00681880 File Offset: 0x0067FA80
	public void SendWorldLevelDownRequest()
	{
		WorldLevelDownRequest message = WorldLevelDownRequest.Create();
		Singleton<Net>.Instance.Call<WorldLevelDownResponse>(ERequestMessageId.WorldLevelDownRequest, message, delegate(WorldLevelDownResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<WorldLevelModel>.Instance.OriginWorldLevel = response.OriginWorldLevel;
				ModelBase<WorldLevelModel>.Instance.CurWorldLevel = response.CurWorldLevel;
				ModelBase<WorldLevelModel>.Instance.LastChangeWorldLevelTimeStamp = response.WorldLevelTimeStamp;
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(this.GetLocalText("WorldLevelAdjustTo", ModelBase<WorldLevelModel>.Instance.CurWorldLevel.ToString()));
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24910, null, true, true);
		}, 0);
	}

	// Token: 0x06017784 RID: 96132 RVA: 0x006818B0 File Offset: 0x0067FAB0
	public void SendWorldLevelRegainRequest()
	{
		WorldLevelRegainRequest message = WorldLevelRegainRequest.Create();
		Singleton<Net>.Instance.Call<WorldLevelRegainResponse>(ERequestMessageId.WorldLevelRegainRequest, message, delegate(WorldLevelRegainResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<WorldLevelModel>.Instance.OriginWorldLevel = response.OriginWorldLevel;
				ModelBase<WorldLevelModel>.Instance.CurWorldLevel = response.CurWorldLevel;
				ModelBase<WorldLevelModel>.Instance.LastChangeWorldLevelTimeStamp = response.WorldLevelTimeStamp;
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(this.GetLocalText("WorldLevelAdjustTo", ModelBase<WorldLevelModel>.Instance.CurWorldLevel.ToString()));
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22879, null, true, true);
		}, 0);
	}

	// Token: 0x06017785 RID: 96133 RVA: 0x006818E0 File Offset: 0x0067FAE0
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.FunctionView && Singleton<UiManager>.Instance.IsViewShow(EUiViewName.WorldLevelInfoView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.WorldLevelInfoView, null);
		}
	}

	// Token: 0x06017786 RID: 96134 RVA: 0x00681910 File Offset: 0x0067FB10
	private void OnBackLoginView()
	{
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.WorldLevelInfoView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.WorldLevelInfoView, null);
		}
	}

	// Token: 0x06017787 RID: 96135 RVA: 0x00681934 File Offset: 0x0067FB34
	public string GetLocalText(string textId, string param1)
	{
		string textById = ConfigBase<TextConfig>.Instance.GetTextById(textId);
		TArray<string> tarray = new TArray<string>();
		tarray.Add(param1);
		return UKuroStaticLibrary.KuroFormatText(textById ?? "", tarray);
	}

	// Token: 0x06017788 RID: 96136 RVA: 0x00681968 File Offset: 0x0067FB68
	private void OnTsResponseWorldLevelChangeInFight(bool state)
	{
		ModelBase<WorldLevelModel>.Instance.TsFightState = state;
	}

	// Token: 0x06017789 RID: 96137 RVA: 0x00681975 File Offset: 0x0067FB75
	private void TsSyncWorldLevelChangeEvent()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.CurWorldLevelChange);
	}

	// Token: 0x0601778A RID: 96138 RVA: 0x00681987 File Offset: 0x0067FB87
	private void TsSyncOriginWorldLevelUpEvent()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OriginWorldLevelUp);
	}
}
