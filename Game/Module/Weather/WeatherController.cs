using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Weather
{
	// Token: 0x02004BFC RID: 19452
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class WeatherController : ControllerBase<WeatherController>
	{
		// Token: 0x06032C26 RID: 207910 RVA: 0x00CB75E9 File Offset: 0x00CB57E9
		protected override bool OnInit()
		{
			this.OnAddEvents();
			this.OnRegisterNetEvent();
			this.InitTimer();
			return true;
		}

		// Token: 0x06032C27 RID: 207911 RVA: 0x00CB75FE File Offset: 0x00CB57FE
		protected override bool OnClear()
		{
			this.OnRemoveEvents();
			this.OnUnRegisterNetEvent();
			this.DestroyWeatherActor();
			this.CancelTimer();
			return true;
		}

		// Token: 0x06032C28 RID: 207912 RVA: 0x00CB761C File Offset: 0x00CB581C
		protected void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.EnterGameSuccess, new Action(this.OnEnterGame));
			Singleton<EventSystem>.Instance.Add(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
			Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFuncOpenSet));
		}

		// Token: 0x06032C29 RID: 207913 RVA: 0x00CB76EC File Offset: 0x00CB58EC
		protected void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.EnterGameSuccess, new Action(this.OnEnterGame));
			Singleton<EventSystem>.Instance.Remove(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
			Singleton<EventSystem>.Instance.Remove<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
			Singleton<EventSystem>.Instance.Remove<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			Singleton<EventSystem>.Instance.Remove<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFuncOpenSet));
		}

		// Token: 0x06032C2A RID: 207914 RVA: 0x00CB77BA File Offset: 0x00CB59BA
		private void InitTimer()
		{
			this.CheckUiSceneTimer = TimerSystem.Instance.Forever(new TTimerAction(this.CheckActiveState), 300f, 1f, null, null, true);
		}

		// Token: 0x06032C2B RID: 207915 RVA: 0x00CB77E5 File Offset: 0x00CB59E5
		private void CancelTimer()
		{
			if (this.CheckUiSceneTimer != null)
			{
				TimerSystem.Instance.Remove(this.CheckUiSceneTimer);
				this.CheckUiSceneTimer = null;
			}
		}

		// Token: 0x06032C2C RID: 207916 RVA: 0x00CB7807 File Offset: 0x00CB5A07
		private void CheckActiveState(float _)
		{
			ModelBase<WeatherModel>.Instance.GetWorldWeatherActor().SetActorState(!GlobalData.IsUiSceneOpen);
		}

		// Token: 0x06032C2D RID: 207917 RVA: 0x00CB7820 File Offset: 0x00CB5A20
		protected void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<WeatherNotify>(ENotifyMessageId.WeatherNotify, new Action<WeatherNotify, Net.CallbackStatus>(this.OnWeatherNotify));
			Singleton<Net>.Instance.Register<WeatherControlUnlockNotify>(ENotifyMessageId.WeatherControlUnlockNotify, delegate(WeatherControlUnlockNotify notify, [Nullable(2)] Net.CallbackStatus _)
			{
				this.OnWeatherSwitchUnlock(notify.WeatherSwitchId);
			});
		}

		// Token: 0x06032C2E RID: 207918 RVA: 0x00CB785A File Offset: 0x00CB5A5A
		protected void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.WeatherNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.WeatherControlUnlockNotify);
		}

		// Token: 0x06032C2F RID: 207919 RVA: 0x00CB787C File Offset: 0x00CB5A7C
		private void OnEnterGame()
		{
		}

		// Token: 0x06032C30 RID: 207920 RVA: 0x00CB787E File Offset: 0x00CB5A7E
		private void OnBeforeLoadMap()
		{
			ModelBase<WeatherModel>.Instance.GetWorldWeatherActor().Destroy();
		}

		// Token: 0x06032C31 RID: 207921 RVA: 0x00CB788F File Offset: 0x00CB5A8F
		private void OnWorldDone()
		{
			this.BackToWorldWeather();
		}

		// Token: 0x06032C32 RID: 207922 RVA: 0x00CB7897 File Offset: 0x00CB5A97
		[NullableContext(2)]
		private void OnTeleportComplete(TeleportContext teleportContext)
		{
			this.BackToWorldWeather();
		}

		// Token: 0x06032C33 RID: 207923 RVA: 0x00CB789F File Offset: 0x00CB5A9F
		private void BackToWorldWeather()
		{
			if (!ControllerBase<GameModeController>.Instance.IsInInstance() && ModelBase<WeatherModel>.Instance.CurrentWeatherId != 0)
			{
				ModelBase<WeatherModel>.Instance.GetWorldWeatherActor().ChangeWeather(ModelBase<WeatherModel>.Instance.CurrentWeatherId, 0f);
			}
		}

		// Token: 0x06032C34 RID: 207924 RVA: 0x00CB78D7 File Offset: 0x00CB5AD7
		private void DestroyWeatherActor()
		{
			ModelBase<WeatherModel>.Instance.GetWorldWeatherActor().Destroy();
		}

		// Token: 0x06032C35 RID: 207925 RVA: 0x00CB78E8 File Offset: 0x00CB5AE8
		public void RequestChangeWeather(int weatherId, ChangeWeatherReason? reason = null)
		{
			ChangeWeatherRequest changeWeatherRequest = ChangeWeatherRequest.Create();
			changeWeatherRequest.WeatherId = weatherId;
			if (reason != null)
			{
				changeWeatherRequest.Reason = reason.Value;
			}
			Singleton<Net>.Instance.Call<ChangeWeatherResponse>(ERequestMessageId.ChangeWeatherRequest, changeWeatherRequest, delegate(ChangeWeatherResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					if (reason.GetValueOrDefault() == ChangeWeatherReason.ClientSkill)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Battle;
						ELogAuthor author = ELogAuthor.GHY;
						string message = "AN[切换天气] 触发切换天气失败";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ErrorCode", response.ErrorCode);
						instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return;
					}
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22668, null, true, true);
				}
			}, 0);
		}

		// Token: 0x06032C36 RID: 207926 RVA: 0x00CB794A File Offset: 0x00CB5B4A
		public void ChangeCurrentWeather(int weatherId, float changeTime)
		{
			if (ModelBase<WeatherModel>.Instance.CurrentWeatherId != weatherId)
			{
				ModelBase<WeatherModel>.Instance.SetCurrentWeatherId(weatherId);
				ModelBase<WeatherModel>.Instance.GetWorldWeatherActor().ChangeWeather(weatherId, changeTime);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.WeatherChange);
		}

		// Token: 0x06032C37 RID: 207927 RVA: 0x00CB7988 File Offset: 0x00CB5B88
		[NullableContext(1)]
		private void OnWeatherNotify(WeatherNotify message, [Nullable(2)] Net.CallbackStatus _)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Weather;
			ELogAuthor author = ELogAuthor.YZY;
			string message2 = "OnWeatherNotify";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("WeatherNotify", message);
			instance.Info(module, author, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (message.IsClient)
			{
				this.ChangeCurrentWeather(message.WeatherId, 1f);
				return;
			}
			this.ChangeCurrentWeather(message.WeatherId, 10f);
		}

		// Token: 0x06032C38 RID: 207928 RVA: 0x00CB79EA File Offset: 0x00CB5BEA
		public void TestChangeWeather(int weatherId)
		{
			ModelBase<WeatherModel>.Instance.SetCurrentWeatherId(weatherId);
			ModelBase<WeatherModel>.Instance.GetWorldWeatherActor().ChangeWeather(weatherId, 10f);
		}

		// Token: 0x06032C39 RID: 207929 RVA: 0x00CB7A0C File Offset: 0x00CB5C0C
		public void StopWeather()
		{
			ModelBase<WeatherModel>.Instance.GetWorldWeatherActor().Destroy();
		}

		// Token: 0x06032C3A RID: 207930 RVA: 0x00CB7A1D File Offset: 0x00CB5C1D
		public void BanWeather()
		{
			ModelBase<WeatherModel>.Instance.GetWorldWeatherActor().BanWeather();
		}

		// Token: 0x06032C3B RID: 207931 RVA: 0x00CB7A30 File Offset: 0x00CB5C30
		public void TryOpenWeatherCentralMainView(int? weatherConfigId = null)
		{
			if (!ControllerBase<TimeOfDayController>.Instance.CanOpenView(EUiViewName.TimeOfDayView))
			{
				return;
			}
			this.RequestWeatherControlInfoAsync().ContinueWith(delegate(bool result)
			{
				if (result)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.WeatherCentralMainView, weatherConfigId, null);
				}
			}).Forget();
		}

		// Token: 0x06032C3C RID: 207932 RVA: 0x00CB7A78 File Offset: 0x00CB5C78
		public UniTask<bool> RequestWeatherControlInfoAsync()
		{
			WeatherController.<RequestWeatherControlInfoAsync>d__26 <RequestWeatherControlInfoAsync>d__;
			<RequestWeatherControlInfoAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestWeatherControlInfoAsync>d__.<>1__state = -1;
			<RequestWeatherControlInfoAsync>d__.<>t__builder.Start<WeatherController.<RequestWeatherControlInfoAsync>d__26>(ref <RequestWeatherControlInfoAsync>d__);
			return <RequestWeatherControlInfoAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032C3D RID: 207933 RVA: 0x00CB7AB4 File Offset: 0x00CB5CB4
		public UniTask<bool> RequestWeatherControlInfoWithoutCheckAsync()
		{
			WeatherController.<RequestWeatherControlInfoWithoutCheckAsync>d__27 <RequestWeatherControlInfoWithoutCheckAsync>d__;
			<RequestWeatherControlInfoWithoutCheckAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestWeatherControlInfoWithoutCheckAsync>d__.<>1__state = -1;
			<RequestWeatherControlInfoWithoutCheckAsync>d__.<>t__builder.Start<WeatherController.<RequestWeatherControlInfoWithoutCheckAsync>d__27>(ref <RequestWeatherControlInfoWithoutCheckAsync>d__);
			return <RequestWeatherControlInfoWithoutCheckAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032C3E RID: 207934 RVA: 0x00CB7AF0 File Offset: 0x00CB5CF0
		public UniTask RequestSwitchWeather(int weatherSwitchConfigId)
		{
			WeatherController.<RequestSwitchWeather>d__28 <RequestSwitchWeather>d__;
			<RequestSwitchWeather>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestSwitchWeather>d__.weatherSwitchConfigId = weatherSwitchConfigId;
			<RequestSwitchWeather>d__.<>1__state = -1;
			<RequestSwitchWeather>d__.<>t__builder.Start<WeatherController.<RequestSwitchWeather>d__28>(ref <RequestSwitchWeather>d__);
			return <RequestSwitchWeather>d__.<>t__builder.Task;
		}

		// Token: 0x06032C3F RID: 207935 RVA: 0x00CB7B33 File Offset: 0x00CB5D33
		private void OnFunctionOpenUpdate(EFunctionType funcId, bool isOpen)
		{
			if (!isOpen)
			{
				return;
			}
			if (funcId != EFunctionType.WeatherCentral)
			{
				return;
			}
			this.TryOpenWeatherUnlockTips();
			this.RequestWeatherControlInfoWithoutCheckAsync().Forget<bool>();
			Singleton<EventSystem>.Instance.Emit(EEventName.OnWeatherCentralRedDotUpdate);
		}

		// Token: 0x06032C40 RID: 207936 RVA: 0x00CB7B63 File Offset: 0x00CB5D63
		private void TryOpenWeatherUnlockTips()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WeatherUnlockTips, null, null);
		}

		// Token: 0x06032C41 RID: 207937 RVA: 0x00CB7B76 File Offset: 0x00CB5D76
		private void OnFuncOpenSet(EFunctionType funcType, bool isOpen)
		{
			if (!isOpen)
			{
				return;
			}
			if (funcType != EFunctionType.WeatherCentral)
			{
				return;
			}
			this.RequestWeatherControlInfoWithoutCheckAsync().Forget<bool>();
			Singleton<EventSystem>.Instance.Emit(EEventName.OnWeatherCentralRedDotUpdate);
		}

		// Token: 0x06032C42 RID: 207938 RVA: 0x00CB7BA0 File Offset: 0x00CB5DA0
		private void OnWeatherSwitchUnlock(int weatherSwitchConfigId)
		{
			ModelBase<WeatherModel>.Instance.AddUnlockedWeatherSwitchConfigId(weatherSwitchConfigId);
		}

		// Token: 0x06032C43 RID: 207939 RVA: 0x00CB7BB0 File Offset: 0x00CB5DB0
		private void OnWorldDoneAndCloseLoading()
		{
			int? targetWeatherSwitchConfigId = ModelBase<WeatherModel>.Instance.TargetWeatherSwitchConfigId;
			if (targetWeatherSwitchConfigId != null)
			{
				this.TryOpenWeatherCentralMainView(targetWeatherSwitchConfigId);
			}
		}

		// Token: 0x0401D8A5 RID: 120997
		public const int CHANGE_WEATHER_SMOOTH_TIME = 10;

		// Token: 0x0401D8A6 RID: 120998
		public const int CHANGE_WEATHER_SMOOTH_TIME_QUICK = 1;

		// Token: 0x0401D8A7 RID: 120999
		public const int CHECKGAP = 300;

		// Token: 0x0401D8A8 RID: 121000
		[Nullable(2)]
		private TimerHandle CheckUiSceneTimer;
	}
}
