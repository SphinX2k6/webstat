using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C1C RID: 27676
	public class LevelEventToggleMapMarkState : LevelEventBase
	{
		// Token: 0x0604419F RID: 278943 RVA: 0x011AEFC3 File Offset: 0x011AD1C3
		public LevelEventToggleMapMarkState(int id) : base(id)
		{
		}

		// Token: 0x060441A0 RID: 278944 RVA: 0x011AEFCC File Offset: 0x011AD1CC
		private void OnCloseMapView(EUiViewName viewName, int viewId)
		{
			if (viewName == EUiViewName.WorldMapView)
			{
				base.Finish();
				Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseMapView));
			}
		}

		// Token: 0x060441A1 RID: 278945 RVA: 0x011AEFFC File Offset: 0x011AD1FC
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ToggleMapMarkState toggleMapMarkState = inParams as ToggleMapMarkState;
			if (toggleMapMarkState == null)
			{
				base.Finish();
				return;
			}
			EMapMarkState type = toggleMapMarkState.Type;
			if (type != EMapMarkState.Show)
			{
				if (type == EMapMarkState.Hide)
				{
					IHideMapMark hideMapMark = toggleMapMarkState as IHideMapMark;
					this.ConditionMarkId(hideMapMark.MarkId);
				}
			}
			else
			{
				IShowMapMark showMapMark = toggleMapMarkState as IShowMapMark;
				if (this.ConditionMarkId(showMapMark.MarkId) && showMapMark.IsFocusOnFirstShow.GetValueOrDefault())
				{
					IMarkShowState markExtraShowState = ModelBase<MapModel>.Instance.GetMarkExtraShowState(showMapMark.MarkId);
					if (markExtraShowState.ShowFlag != MapMarkShowFlag.Hide && markExtraShowState.NeedFocus)
					{
						markExtraShowState.NeedFocus = false;
						MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(showMapMark.MarkId);
						if (configMark == null)
						{
							global::Log instance = Singleton<global::Log>.Instance;
							ELogModule module = ELogModule.Map;
							ELogAuthor author = ELogAuthor.LK;
							string message = "缺少MapMark表缺少地图配置";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", showMapMark.MarkId);
							instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
							base.Finish();
							return;
						}
						WorldMapViewOpenParams param = new WorldMapViewOpenParams
						{
							MarkId = new int?(showMapMark.MarkId),
							MarkType = (EMarkType)configMark.Value.ObjectType,
							IsNotFocusTween = new bool?(true)
						};
						Singleton<UiManager>.Instance.OpenView(EUiViewName.WorldMapView, param, delegate(bool _, int _)
						{
							ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Common, "LevelEventToggleMapMarkState", null, null);
							if (!this.IsAsync)
							{
								Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseMapView));
							}
						});
						if (!this.IsAsync)
						{
							return;
						}
					}
				}
			}
			base.Finish();
		}

		// Token: 0x060441A2 RID: 278946 RVA: 0x011AF160 File Offset: 0x011AD360
		private bool ConditionMarkId(int markId)
		{
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
			return configMark != null && configMark.GetValueOrDefault().ShowCondition == -1;
		}
	}
}
