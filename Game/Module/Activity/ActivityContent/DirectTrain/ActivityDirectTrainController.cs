using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain
{
	// Token: 0x02006942 RID: 26946
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ActivityDirectTrainController : ActivityControllerBase<ActivityDirectTrainController>
	{
		// Token: 0x06042E0C RID: 273932 RVA: 0x0112AA18 File Offset: 0x01128C18
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06042E0D RID: 273933 RVA: 0x0112AA1F File Offset: 0x01128C1F
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06042E0E RID: 273934 RVA: 0x0112AA22 File Offset: 0x01128C22
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x06042E0F RID: 273935 RVA: 0x0112AA28 File Offset: 0x01128C28
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnActivityUpdate));
			Singleton<EventSystem>.Instance.Add<int, IReadOnlyList<int>>(EEventName.OnReceiveActivityData, new Action<int, IReadOnlyList<int>>(this.OnReceiveActivityData));
			Singleton<Net>.Instance.Register<ThroughTrainForceRemindNotify>(ENotifyMessageId.ThroughTrainForceRemindNotify, new Action<ThroughTrainForceRemindNotify, Net.CallbackStatus>(this.OnThroughTrainForceRemindNotify));
			Singleton<Net>.Instance.Register<DirectTrainPreOpenCloseNotify>(ENotifyMessageId.DirectTrainPreOpenCloseNotify, new Action<DirectTrainPreOpenCloseNotify, Net.CallbackStatus>(this.OnDirectTrainPreOpenCloseNotify));
			Singleton<Net>.Instance.Register<DirectTrainInfoNotify>(ENotifyMessageId.DirectTrainInfoNotify, new Action<DirectTrainInfoNotify, Net.CallbackStatus>(this.OnDirectTrainInfoNotify));
			Singleton<Net>.Instance.Register<DirectTrainInfoUpdateNotify>(ENotifyMessageId.DirectTrainInfoUpdateNotify, new Action<DirectTrainInfoUpdateNotify, Net.CallbackStatus>(this.OnDirectTrainInfoUpdateNotify));
		}

		// Token: 0x06042E10 RID: 273936 RVA: 0x0112AAFC File Offset: 0x01128CFC
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnActivityUpdate));
			Singleton<EventSystem>.Instance.Remove<int, IReadOnlyList<int>>(EEventName.OnReceiveActivityData, new Action<int, IReadOnlyList<int>>(this.OnReceiveActivityData));
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ThroughTrainForceRemindNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DirectTrainPreOpenCloseNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DirectTrainInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DirectTrainInfoUpdateNotify);
		}

		// Token: 0x06042E11 RID: 273937 RVA: 0x0112AB9D File Offset: 0x01128D9D
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06042E12 RID: 273938 RVA: 0x0112AB9F File Offset: 0x01128D9F
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new ActivityDirectTrainData();
		}

		// Token: 0x06042E13 RID: 273939 RVA: 0x0112ABA6 File Offset: 0x01128DA6
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivityDirectTrainSubView();
		}

		// Token: 0x06042E14 RID: 273940 RVA: 0x0112ABAD File Offset: 0x01128DAD
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return ModelBase<ActivityDirectTrainModel>.Instance.GetPrefabResource(data.Id);
		}

		// Token: 0x1700A1CD RID: 41421
		// (get) Token: 0x06042E15 RID: 273941 RVA: 0x0112ABBF File Offset: 0x01128DBF
		private Dictionary<EDirectTrainStartCondition, bool> DirectTrainStartConditionMap
		{
			get
			{
				return ActivityDirectTrainHelper.DirectTrainStartConditionMap;
			}
		}

		// Token: 0x06042E16 RID: 273942 RVA: 0x0112ABC8 File Offset: 0x01128DC8
		private void OnReceiveActivityData(int type, IReadOnlyList<int> activityIds)
		{
			if (type != 30)
			{
				return;
			}
			foreach (int subActivityId in activityIds)
			{
				ModelBase<DirectTrainModel>.Instance.RefreshSubActivityCache(subActivityId);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityDirectTrainRedDotUpdate, 0);
		}

		// Token: 0x06042E17 RID: 273943 RVA: 0x0112AC2C File Offset: 0x01128E2C
		private void OnWorldDone()
		{
			UniTask? uniTask = null;
			if (ModelBase<FunctionModel>.Instance.IsOpen(10053))
			{
				this.CheckIsStart(false);
			}
			else if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DirectTrainProView) && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DirectTrainDetailView))
			{
				uniTask = new UniTask?(ActivityDirectTrainHelper.TryOpenPro(true));
			}
			if (uniTask != null)
			{
				uniTask.Value.ContinueWith(new Action(this.LoadInitDataIfNeed)).Forget();
				return;
			}
			this.LoadInitDataIfNeed();
		}

		// Token: 0x06042E18 RID: 273944 RVA: 0x0112ACB7 File Offset: 0x01128EB7
		private void LoadInitDataIfNeed()
		{
			if (ModelBase<ActivityDirectTrainModel>.Instance.HasInitData())
			{
				return;
			}
			ActivityDirectTrainHelper.RequestDirectTrainInfoBeforeActivityOpen().ContinueWith(delegate(DirectTrainInfoResponse result)
			{
				ModelBase<ActivityDirectTrainModel>.Instance.LoadDataFromInfoProto(result);
			}).Forget();
		}

		// Token: 0x06042E19 RID: 273945 RVA: 0x0112ACF4 File Offset: 0x01128EF4
		private void OnActivityUpdate(int activityId)
		{
			if (!ModelBase<FunctionModel>.Instance.IsOpen(10053))
			{
				return;
			}
			ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(activityId);
			if (activityById == null || activityById.Type != ActivityType.ThroughTrain || activityById.Id != activityId)
			{
				return;
			}
			bool flag = activityById.IsUnLock();
			this.DirectTrainStartConditionMap[EDirectTrainStartCondition.ActivityOpen] = flag;
			if (flag)
			{
				this.CheckIsStart(true);
			}
		}

		// Token: 0x06042E1A RID: 273946 RVA: 0x0112AD54 File Offset: 0x01128F54
		private void OnThroughTrainForceRemindNotify(ThroughTrainForceRemindNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<ActivityDirectTrainModel>.Instance.SetServerRemindActivityId(notify.ActivityId);
		}

		// Token: 0x06042E1B RID: 273947 RVA: 0x0112AD68 File Offset: 0x01128F68
		private void OnDirectTrainPreOpenCloseNotify(DirectTrainPreOpenCloseNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.DirectTrainPro);
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DirectTrainProView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.DirectTrainProView, null);
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DirectTrainDetailView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.DirectTrainDetailView, null);
			}
			ActivityDirectTrainHelper.IsProOpen = false;
			ActivityDirectTrainHelper.EmitEventsForOther(false);
		}

		// Token: 0x06042E1C RID: 273948 RVA: 0x0112ADCE File Offset: 0x01128FCE
		private void OnDirectTrainInfoUpdateNotify(DirectTrainInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<ActivityDirectTrainModel>.Instance.UpdateDataFromNotify(notify);
		}

		// Token: 0x06042E1D RID: 273949 RVA: 0x0112ADDC File Offset: 0x01128FDC
		private void OnDirectTrainInfoNotify(DirectTrainInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify.Activity != null && notify.Activity.Id != 0)
			{
				ActivityDirectTrainHelper.IsProOpen = true;
				ActivityDirectTrainHelper.EmitEventsForOther(true);
				if (!LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.IsDirectTrainProOpened, false) && ModelBase<GameModeModel>.Instance.WorldDoneAndLoadingClosed)
				{
					ActivityDirectTrainHelper.TryOpenPro(true).Forget();
				}
			}
		}

		// Token: 0x06042E1E RID: 273950 RVA: 0x0112AE30 File Offset: 0x01129030
		private void CheckIsStart(bool isInstantly = false)
		{
			if (Singleton<PublicUtil>.Instance.GetIsSilentLogin())
			{
				return;
			}
			int severRemindId = ModelBase<ActivityDirectTrainModel>.Instance.GetDirectTrainServerRemindId();
			if (severRemindId != 0)
			{
				DirectTrainActivity? directTrainActivityConfById = ConfigBase<ActivityDirectTrainConfig>.Instance.GetDirectTrainActivityConfById(severRemindId);
				if (directTrainActivityConfById != null && directTrainActivityConfById.Value.IsForceRemind)
				{
					this.DirectTrainStartConditionMap[EDirectTrainStartCondition.ServerConditionDone] = true;
				}
			}
			bool flag = true;
			foreach (object obj in Enum.GetValues(typeof(EDirectTrainStartCondition)))
			{
				EDirectTrainStartCondition key = (EDirectTrainStartCondition)obj;
				bool flag2;
				if (!this.DirectTrainStartConditionMap.TryGetValue(key, out flag2) || !flag2)
				{
					flag = false;
					key.ToString();
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			if (ModelBase<ActivityDirectTrainModel>.Instance.AlreadyStartView)
			{
				return;
			}
			if (severRemindId != 0)
			{
				SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.DirectTrain, ESplashScreenType.Config, delegate()
				{
					DirectTrainSubActivityViewModel directTrainSubActivityViewModel = ModelBase<DirectTrainModel>.Instance.BuildSubActivityViewModel(severRemindId);
					if (directTrainSubActivityViewModel == null)
					{
						ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.DirectTrain);
						return;
					}
					Singleton<UiManager>.Instance.OpenView(EUiViewName.DirectTrainDetailView, directTrainSubActivityViewModel, null);
				});
				ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, isInstantly);
			}
		}
	}
}
