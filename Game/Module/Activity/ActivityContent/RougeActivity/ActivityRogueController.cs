using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity
{
	// Token: 0x02006472 RID: 25714
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityRogueController : ActivityControllerBase<ActivityRogueController>
	{
		// Token: 0x060407F7 RID: 264183 RVA: 0x01087631 File Offset: 0x01085831
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x060407F8 RID: 264184 RVA: 0x01087634 File Offset: 0x01085834
		protected override void OnOpenView(ActivityBaseData data)
		{
			if (this.GetFunctionTypeById(data.Id).GetValueOrDefault() != ERogueFunctionType.View)
			{
				return;
			}
			this.ActivityFunctionExecute(data.Id);
		}

		// Token: 0x060407F9 RID: 264185 RVA: 0x01087668 File Offset: 0x01085868
		private ERogueFunctionType? GetFunctionTypeById(int activityId)
		{
			ActivityRogueConfig instance = ConfigBase<ActivityRogueConfig>.Instance;
			RogueActivity? rogueActivity = (instance != null) ? instance.GetActivityUniversalConfig(activityId) : null;
			if (rogueActivity == null)
			{
				return null;
			}
			return new ERogueFunctionType?((ERogueFunctionType)rogueActivity.Value.FunctionType);
		}

		// Token: 0x060407FA RID: 264186 RVA: 0x010876B8 File Offset: 0x010858B8
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			ActivityRogueConfig instance = ConfigBase<ActivityRogueConfig>.Instance;
			RogueActivity? rogueActivity = (instance != null) ? instance.GetActivityUniversalConfig(data.Id) : null;
			if (rogueActivity == null)
			{
				return "UiItem_ActivityRouge";
			}
			return rogueActivity.Value.ActivityResource;
		}

		// Token: 0x060407FB RID: 264187 RVA: 0x01087703 File Offset: 0x01085903
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivitySubViewRogue();
		}

		// Token: 0x060407FC RID: 264188 RVA: 0x0108770A File Offset: 0x0108590A
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.ActivityId = data.Id;
			return new ActivityRogueData();
		}

		// Token: 0x060407FD RID: 264189 RVA: 0x0108771D File Offset: 0x0108591D
		protected override bool OnInit()
		{
			this.RegisterOpenViewFunc();
			return true;
		}

		// Token: 0x060407FE RID: 264190 RVA: 0x01087726 File Offset: 0x01085926
		protected override bool OnClear()
		{
			this.OpenViewFuncMap.Clear();
			return true;
		}

		// Token: 0x060407FF RID: 264191 RVA: 0x01087734 File Offset: 0x01085934
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		}

		// Token: 0x06040800 RID: 264192 RVA: 0x01087752 File Offset: 0x01085952
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		}

		// Token: 0x06040801 RID: 264193 RVA: 0x01087770 File Offset: 0x01085970
		private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason _)
		{
			foreach (ActivityBaseData activityBaseData in ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.RougeActivity))
			{
				ActivityRogueData activityRogueData = activityBaseData as ActivityRogueData;
				if (activityRogueData != null)
				{
					activityRogueData.OnQuestStateChange(questId, state);
				}
			}
		}

		// Token: 0x06040802 RID: 264194 RVA: 0x010877D4 File Offset: 0x010859D4
		[NullableContext(2)]
		public ActivityRogueData GetCurrentActivityData()
		{
			ActivityRogueData activityRogueData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as ActivityRogueData;
			if (activityRogueData == null)
			{
				return null;
			}
			return activityRogueData;
		}

		// Token: 0x06040803 RID: 264195 RVA: 0x010877FD File Offset: 0x010859FD
		public void RefreshActivityRedDot()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
		}

		// Token: 0x06040804 RID: 264196 RVA: 0x01087818 File Offset: 0x01085A18
		public void ActivityFunctionExecute(int activityId)
		{
			ActivityRogueConfig instance = ConfigBase<ActivityRogueConfig>.Instance;
			RogueActivity? rogueActivity = (instance != null) ? instance.GetActivityUniversalConfig(activityId) : null;
			if (rogueActivity == null)
			{
				return;
			}
			string[] array = rogueActivity.Value.FunctionParams();
			List<string> list = (array != null) ? new List<string>(array) : new List<string>();
			switch (rogueActivity.Value.FunctionType)
			{
			case 0:
				break;
			case 1:
			{
				int? questId = null;
				if (list != null && list.Count >= 1)
				{
					questId = new int?(int.Parse(list[0]));
				}
				this.FunctionExecuteQuest(questId);
				return;
			}
			case 2:
				if (list.Count >= 1)
				{
					EUiViewName viewName = (EUiViewName)list[0];
					List<string> params_ = (list.Count > 1) ? list.GetRange(1, list.Count - 1) : new List<string>();
					this.FunctionExecuteView(viewName, params_);
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x06040805 RID: 264197 RVA: 0x01087904 File Offset: 0x01085B04
		private void FunctionExecuteQuest(int? questId)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, questId, null);
		}

		// Token: 0x06040806 RID: 264198 RVA: 0x0108791C File Offset: 0x01085B1C
		private void FunctionExecuteView(EUiViewName viewName, [Nullable(new byte[]
		{
			2,
			1
		})] List<string> params_)
		{
			Action<string[]> action;
			if (this.OpenViewFuncMap.TryGetValue(viewName, out action))
			{
				action((params_ != null && params_.Count > 0) ? params_.ToArray() : null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(viewName, (params_ != null) ? params_.ToArray() : null, null);
		}

		// Token: 0x06040807 RID: 264199 RVA: 0x0108796D File Offset: 0x01085B6D
		private void RegisterOpenViewFunc()
		{
			this.OpenViewFuncMap[EUiViewName.WorldMapView] = new Action<string[]>(this.OpenWorldMapView);
			this.OpenViewFuncMap[EUiViewName.RoguelikeActivityView] = new Action<string[]>(this.OpenRoguelikeActivityView);
		}

		// Token: 0x06040808 RID: 264200 RVA: 0x010879A8 File Offset: 0x01085BA8
		private void OpenWorldMapView([Nullable(new byte[]
		{
			2,
			1
		})] string[] params_)
		{
			int? num = (params_ != null && params_.Length >= 1) ? new int?(int.Parse(params_[0])) : null;
			if (num != null && !ModelBase<MapModel>.Instance.IsConfigMarkIdUnlock(num.Value))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FunctionDisable", Array.Empty<object>());
				return;
			}
			WorldMapViewOpenParams data = new WorldMapViewOpenParams
			{
				MarkId = ((params_ != null && params_.Length >= 1) ? new int?(int.Parse(params_[0])) : null),
				MarkType = EMarkType.None,
				OpenFogId = new int?(0)
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
		}

		// Token: 0x06040809 RID: 264201 RVA: 0x01087A56 File Offset: 0x01085C56
		private void OpenRoguelikeActivityView([Nullable(new byte[]
		{
			2,
			1
		})] string[] params_)
		{
			ControllerBase<RoguelikeController>.Instance.OpenRoguelikeActivityView().Forget<bool>();
		}

		// Token: 0x0402419C RID: 147868
		public int ActivityId;

		// Token: 0x0402419D RID: 147869
		[Nullable(new byte[]
		{
			1,
			1,
			2,
			1
		})]
		public Dictionary<EUiViewName, Action<string[]>> OpenViewFuncMap = new Dictionary<EUiViewName, Action<string[]>>();
	}
}
