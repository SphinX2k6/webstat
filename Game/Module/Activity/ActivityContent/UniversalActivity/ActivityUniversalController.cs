using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.UniversalActivity
{
	// Token: 0x02006258 RID: 25176
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityUniversalController : ActivityControllerBase<ActivityUniversalController>
	{
		// Token: 0x0603F737 RID: 259895 RVA: 0x010441A3 File Offset: 0x010423A3
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0603F738 RID: 259896 RVA: 0x010441A8 File Offset: 0x010423A8
		protected override void OnOpenView(ActivityBaseData data)
		{
			if (this.GetFunctionTypeById(data.Id).GetValueOrDefault() != EActivityFunctionType.View)
			{
				return;
			}
			this.ActivityFunctionExecute(data.Id);
		}

		// Token: 0x0603F739 RID: 259897 RVA: 0x010441DC File Offset: 0x010423DC
		private EActivityFunctionType? GetFunctionTypeById(int activityId)
		{
			UniversalActivity? activityUniversalConfig = ConfigBase<ActivityUniversalConfig>.Instance.GetActivityUniversalConfig(activityId);
			if (activityUniversalConfig == null)
			{
				return null;
			}
			return new EActivityFunctionType?((EActivityFunctionType)activityUniversalConfig.Value.FunctionType);
		}

		// Token: 0x0603F73A RID: 259898 RVA: 0x0104421C File Offset: 0x0104241C
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			UniversalActivity? activityUniversalConfig = ConfigBase<ActivityUniversalConfig>.Instance.GetActivityUniversalConfig(data.Id);
			if (activityUniversalConfig == null)
			{
				return "";
			}
			return activityUniversalConfig.Value.UiResource;
		}

		// Token: 0x0603F73B RID: 259899 RVA: 0x01044258 File Offset: 0x01042458
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivitySubViewUniversal();
		}

		// Token: 0x0603F73C RID: 259900 RVA: 0x0104425F File Offset: 0x0104245F
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.UniversalActivityIdSet.Add(data.Id);
			return new ActivityUniversalData();
		}

		// Token: 0x0603F73D RID: 259901 RVA: 0x01044278 File Offset: 0x01042478
		protected override bool OnInit()
		{
			this.RegisterOpenViewFunc();
			return true;
		}

		// Token: 0x0603F73E RID: 259902 RVA: 0x01044281 File Offset: 0x01042481
		protected override bool OnClear()
		{
			this.UniversalActivityIdSet.Clear();
			this.OpenViewFuncMap.Clear();
			return true;
		}

		// Token: 0x0603F73F RID: 259903 RVA: 0x0104429C File Offset: 0x0104249C
		public void ActivityFunctionExecute(int activityId)
		{
			UniversalActivity? activityUniversalConfig = ConfigBase<ActivityUniversalConfig>.Instance.GetActivityUniversalConfig(activityId);
			if (activityUniversalConfig == null)
			{
				return;
			}
			UniversalActivity value = activityUniversalConfig.Value;
			string[] array = value.FunctionParams();
			switch (value.FunctionType)
			{
			case 0:
				break;
			case 1:
			{
				int? questId = null;
				if (array != null && array.Length >= 1)
				{
					questId = new int?(int.Parse(array[0]));
				}
				this.FunctionExecuteQuest(questId);
				return;
			}
			case 2:
				if (array.Length >= 1)
				{
					EUiViewName viewName = (EUiViewName)Enum.Parse(typeof(EUiViewName), array[0]);
					string[] array2 = new string[array.Length - 1];
					Array.Copy(array, 1, array2, 0, array2.Length);
					this.FunctionExecuteView(viewName, array2);
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x0603F740 RID: 259904 RVA: 0x01044356 File Offset: 0x01042556
		private void FunctionExecuteQuest(int? questId = null)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, questId, null);
		}

		// Token: 0x0603F741 RID: 259905 RVA: 0x01044370 File Offset: 0x01042570
		private void FunctionExecuteView(EUiViewName viewName, [Nullable(new byte[]
		{
			2,
			1
		})] string[] params_ = null)
		{
			Action<string[]> action;
			if (this.OpenViewFuncMap.TryGetValue(viewName, out action))
			{
				action(params_);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(viewName, params_, null);
		}

		// Token: 0x0603F742 RID: 259906 RVA: 0x010443A2 File Offset: 0x010425A2
		private void RegisterOpenViewFunc()
		{
			this.OpenViewFuncMap.Add(EUiViewName.WorldMapView, new Action<string[]>(this.OpenWorldMapView));
			this.OpenViewFuncMap.Add(EUiViewName.RoguelikeActivityView, new Action<string[]>(this.OpenRoguelikeActivityView));
		}

		// Token: 0x0603F743 RID: 259907 RVA: 0x010443DC File Offset: 0x010425DC
		private void OpenWorldMapView([Nullable(new byte[]
		{
			2,
			1
		})] string[] params_)
		{
			int? num = (params_ != null) ? new int?(int.Parse(params_[0])) : null;
			if (num != null && !ModelBase<MapModel>.Instance.IsConfigMarkIdUnlock(num.Value))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FunctionDisable", Array.Empty<object>());
				return;
			}
			WorldMapViewOpenParams data = new WorldMapViewOpenParams
			{
				MarkId = ((params_ != null) ? new int?(int.Parse(params_[0])) : null),
				MarkType = EMarkType.None,
				OpenFogId = new int?(0)
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
		}

		// Token: 0x0603F744 RID: 259908 RVA: 0x0104447E File Offset: 0x0104267E
		private void OpenRoguelikeActivityView([Nullable(new byte[]
		{
			2,
			1
		})] string[] params_)
		{
			ControllerBase<RoguelikeController>.Instance.OpenRoguelikeActivityView();
		}

		// Token: 0x040239CF RID: 145871
		public HashSet<int> UniversalActivityIdSet = new HashSet<int>();

		// Token: 0x040239D0 RID: 145872
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
