using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Weather;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005238 RID: 21048
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class RogueBattleController : UiControllerBase<RogueBattleController>
	{
		// Token: 0x06035E8D RID: 220813 RVA: 0x00D919F4 File Offset: 0x00D8FBF4
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<RogueResRoomInfoNotify>(ENotifyMessageId.RogueResRoomInfoNotify, new Action<RogueResRoomInfoNotify, Net.CallbackStatus>(this.OnRogueRoomInfoNotify));
			Singleton<Net>.Instance.Register<RogueResInstOptionsUpdateNotify>(ENotifyMessageId.RogueResInstOptionsUpdateNotify, new Action<RogueResInstOptionsUpdateNotify, Net.CallbackStatus>(this.OnRogueResInstOptionsUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResGainDataUpdateNotify>(ENotifyMessageId.RogueResGainDataUpdateNotify, new Action<RogueResGainDataUpdateNotify, Net.CallbackStatus>(this.OnRogueResGainDataUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResElementUpdateNotify>(ENotifyMessageId.RogueResElementUpdateNotify, new Action<RogueResElementUpdateNotify, Net.CallbackStatus>(this.OnRogueResElementUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResRoleBondUpdateNotify>(ENotifyMessageId.RogueResRoleBondUpdateNotify, new Action<RogueResRoleBondUpdateNotify, Net.CallbackStatus>(this.OnRogueResRoleBondUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResFormationUpdateNotify>(ENotifyMessageId.RogueResFormationUpdateNotify, new Action<RogueResFormationUpdateNotify, Net.CallbackStatus>(this.OnRogueResFormationUpdateNotify));
		}

		// Token: 0x06035E8E RID: 220814 RVA: 0x00D91AAC File Offset: 0x00D8FCAC
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResRoomInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResInstOptionsUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResGainDataUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResElementUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResRoleBondUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResFormationUpdateNotify);
		}

		// Token: 0x06035E8F RID: 220815 RVA: 0x00D91B19 File Offset: 0x00D8FD19
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeon, new Action(this.OnLeaveInstanceDungeon));
		}

		// Token: 0x06035E90 RID: 220816 RVA: 0x00D91B37 File Offset: 0x00D8FD37
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeon, new Action(this.OnLeaveInstanceDungeon));
		}

		// Token: 0x06035E91 RID: 220817 RVA: 0x00D91B55 File Offset: 0x00D8FD55
		protected void OnLeaveInstanceDungeon()
		{
			ModelBase<RogueBattleModel>.Instance.ClearData();
		}

		// Token: 0x06035E92 RID: 220818 RVA: 0x00D91B61 File Offset: 0x00D8FD61
		protected void OnRogueResRoleBondUpdateNotify(RogueResRoleBondUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<RogueBattleModel>.Instance.UpdateFetterData(notify);
		}

		// Token: 0x06035E93 RID: 220819 RVA: 0x00D91B6E File Offset: 0x00D8FD6E
		protected void OnRogueResElementUpdateNotify(RogueResElementUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<RogueBattleModel>.Instance.UpdateElementData(notify);
		}

		// Token: 0x06035E94 RID: 220820 RVA: 0x00D91B7B File Offset: 0x00D8FD7B
		protected void OnRogueResGainDataUpdateNotify(RogueResGainDataUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<RogueBattleModel>.Instance.UpdateGainData(notify);
		}

		// Token: 0x06035E95 RID: 220821 RVA: 0x00D91B88 File Offset: 0x00D8FD88
		protected void OnRogueRoomInfoNotify(RogueResRoomInfoNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			RogueResRoomPool? roomPoolConfig = ConfigBase<RogueBattleConfig>.Instance.GetRoomPoolConfig(data.RoguelikeRoomId);
			RogueResRoomType value = ConfigBase<RogueBattleConfig>.Instance.GetRogueRoomType(data.RoguelikeRoomTypeId).Value;
			ModelBase<RogueBattleModel>.Instance.CurrentRoomTypeId = value.RoomType;
			ModelBase<RogueBattleModel>.Instance.CurrentRoomId = data.RoguelikeRoomId;
			if (roomPoolConfig != null && !StringUtils.IsEmpty(roomPoolConfig.Value.RoomsMusicState))
			{
				ModelBase<RogueBattleModel>.Instance.CurrentRoomMusicState = roomPoolConfig.Value.RoomsMusicState;
			}
			else
			{
				ModelBase<RogueBattleModel>.Instance.CurrentRoomMusicState = value.RoomsMusicState;
			}
			if (data.SkyBoxId != 0)
			{
				ModelBase<WeatherModel>.Instance.GetWorldWeatherActor().ChangeWeather(data.SkyBoxId, 0f);
				return;
			}
			ControllerBase<WeatherController>.Instance.StopWeather();
		}

		// Token: 0x06035E96 RID: 220822 RVA: 0x00D91C58 File Offset: 0x00D8FE58
		protected void OnRogueResInstOptionsUpdateNotify(RogueResInstOptionsUpdateNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<RogueBattleModel>.Instance.UpdateOptionData(data);
		}

		// Token: 0x06035E97 RID: 220823 RVA: 0x00D91C68 File Offset: 0x00D8FE68
		protected void OnRogueResFormationUpdateNotify(RogueResFormationUpdateNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			for (int i = 0; i < data.RogueResFormations.Count; i++)
			{
				ModelBase<RogueBattleModel>.Instance.UpdateFormationData(i, data.RogueResFormations[i]);
			}
		}

		// Token: 0x06035E98 RID: 220824 RVA: 0x00D91CA4 File Offset: 0x00D8FEA4
		public UniTask GotoNextRoomRequest()
		{
			RogueBattleController.<GotoNextRoomRequest>d__11 <GotoNextRoomRequest>d__;
			<GotoNextRoomRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<GotoNextRoomRequest>d__.<>1__state = -1;
			<GotoNextRoomRequest>d__.<>t__builder.Start<RogueBattleController.<GotoNextRoomRequest>d__11>(ref <GotoNextRoomRequest>d__);
			return <GotoNextRoomRequest>d__.<>t__builder.Task;
		}

		// Token: 0x06035E99 RID: 220825 RVA: 0x00D91CE0 File Offset: 0x00D8FEE0
		public UniTask SwitchFormationRequest(int index)
		{
			RogueBattleController.<SwitchFormationRequest>d__12 <SwitchFormationRequest>d__;
			<SwitchFormationRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SwitchFormationRequest>d__.index = index;
			<SwitchFormationRequest>d__.<>1__state = -1;
			<SwitchFormationRequest>d__.<>t__builder.Start<RogueBattleController.<SwitchFormationRequest>d__12>(ref <SwitchFormationRequest>d__);
			return <SwitchFormationRequest>d__.<>t__builder.Task;
		}

		// Token: 0x06035E9A RID: 220826 RVA: 0x00D91D24 File Offset: 0x00D8FF24
		public UniTask ChangeFormationAllListRequest(int formationIndex, List<int> roleIdList)
		{
			RogueBattleController.<ChangeFormationAllListRequest>d__13 <ChangeFormationAllListRequest>d__;
			<ChangeFormationAllListRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChangeFormationAllListRequest>d__.formationIndex = formationIndex;
			<ChangeFormationAllListRequest>d__.roleIdList = roleIdList;
			<ChangeFormationAllListRequest>d__.<>1__state = -1;
			<ChangeFormationAllListRequest>d__.<>t__builder.Start<RogueBattleController.<ChangeFormationAllListRequest>d__13>(ref <ChangeFormationAllListRequest>d__);
			return <ChangeFormationAllListRequest>d__.<>t__builder.Task;
		}

		// Token: 0x06035E9B RID: 220827 RVA: 0x00D91D70 File Offset: 0x00D8FF70
		public UniTask ChangeFormationRequest(int formationIndex, int position, int roleId)
		{
			RogueBattleController.<ChangeFormationRequest>d__14 <ChangeFormationRequest>d__;
			<ChangeFormationRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChangeFormationRequest>d__.formationIndex = formationIndex;
			<ChangeFormationRequest>d__.position = position;
			<ChangeFormationRequest>d__.roleId = roleId;
			<ChangeFormationRequest>d__.<>1__state = -1;
			<ChangeFormationRequest>d__.<>t__builder.Start<RogueBattleController.<ChangeFormationRequest>d__14>(ref <ChangeFormationRequest>d__);
			return <ChangeFormationRequest>d__.<>t__builder.Task;
		}

		// Token: 0x06035E9C RID: 220828 RVA: 0x00D91DC4 File Offset: 0x00D8FFC4
		public UniTask SelectTokenRequest(int index)
		{
			RogueBattleController.<SelectTokenRequest>d__15 <SelectTokenRequest>d__;
			<SelectTokenRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SelectTokenRequest>d__.index = index;
			<SelectTokenRequest>d__.<>1__state = -1;
			<SelectTokenRequest>d__.<>t__builder.Start<RogueBattleController.<SelectTokenRequest>d__15>(ref <SelectTokenRequest>d__);
			return <SelectTokenRequest>d__.<>t__builder.Task;
		}

		// Token: 0x06035E9D RID: 220829 RVA: 0x00D91E08 File Offset: 0x00D90008
		[NullableContext(0)]
		public UniTask<bool> OpenBuffSelectViewById(int bindId)
		{
			RogueBattleController.<OpenBuffSelectViewById>d__16 <OpenBuffSelectViewById>d__;
			<OpenBuffSelectViewById>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenBuffSelectViewById>d__.<>4__this = this;
			<OpenBuffSelectViewById>d__.bindId = bindId;
			<OpenBuffSelectViewById>d__.<>1__state = -1;
			<OpenBuffSelectViewById>d__.<>t__builder.Start<RogueBattleController.<OpenBuffSelectViewById>d__16>(ref <OpenBuffSelectViewById>d__);
			return <OpenBuffSelectViewById>d__.<>t__builder.Task;
		}

		// Token: 0x06035E9E RID: 220830 RVA: 0x00D91E54 File Offset: 0x00D90054
		public EUiViewName? GetViewNameByGainType(RogueResDataType type)
		{
			switch (type)
			{
			case RogueResDataType.Token:
				return new EUiViewName?(EUiViewName.RogueBattleSelectTokenView);
			case RogueResDataType.TokenShop:
				return new EUiViewName?(EUiViewName.RogueBattleShopView);
			case RogueResDataType.Phantom:
				return new EUiViewName?(EUiViewName.RogueBattlePhantomSelectView);
			case RogueResDataType.Event:
				return new EUiViewName?(EUiViewName.RogueBattleRandomEventView);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RogueBattle;
			ELogAuthor author = ELogAuthor.LPH;
			string message = "当前增益类型没有对应的界面数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type.ToString());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
	}
}
