using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BA3 RID: 27555
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventFocusOnMapMark : LevelEventBase
	{
		// Token: 0x06043FBB RID: 278459 RVA: 0x0119DCC6 File Offset: 0x0119BEC6
		public LevelEventFocusOnMapMark(int id) : base(id)
		{
		}

		// Token: 0x06043FBC RID: 278460 RVA: 0x0119DCD0 File Offset: 0x0119BED0
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			FocusOnMapMarkAction focusOnMapMarkAction = inParams as FocusOnMapMarkAction;
			if (focusOnMapMarkAction == null)
			{
				base.Finish();
				return;
			}
			EMapMarkType type = focusOnMapMarkAction.MapMarkType.Type;
			if (type == EMapMarkType.Custom)
			{
				this.HandleCustomMapFocus(focusOnMapMarkAction.MapMarkType as IFocusOnCustomMapMark);
				return;
			}
			if (type != EMapMarkType.Quest)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "[LevelEventFocusOnMapMark]未定义类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MapMarkType", focusOnMapMarkAction.MapMarkType.Type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.Finish();
				return;
			}
			this.HandleQuestMapFocus(focusOnMapMarkAction.MapMarkType as IFocusOnQuestMapMark);
		}

		// Token: 0x06043FBD RID: 278461 RVA: 0x0119DD64 File Offset: 0x0119BF64
		private void HandleCustomMapFocus(IFocusOnCustomMapMark param)
		{
			int markId = param.MarkId;
			OneOf<MapMark, DynamicMapMark>? oneOf = ConfigBase<MapConfig>.Instance.SearchMarkConfig(markId);
			if (oneOf == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "[LevelEventFocusOnMapMark]HandleCustomMapFocus->找不到对应的标记配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("markId", markId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				WorldMapViewOpenParams worldMapViewOpenParams = new WorldMapViewOpenParams();
				worldMapViewOpenParams.MarkId = new int?(markId);
				worldMapViewOpenParams.MarkType = (EMarkType)oneOf.Value.Match<int>((MapMark mark) => mark.ObjectType, (DynamicMapMark mark) => mark.ObjectType);
				WorldMapViewOpenParams data = worldMapViewOpenParams;
				ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
			}
			base.Finish();
		}

		// Token: 0x06043FBE RID: 278462 RVA: 0x0119DE38 File Offset: 0x0119C038
		private void HandleQuestMapFocus(IFocusOnQuestMapMark param)
		{
			int questId = param.QuestId;
			QuestMarkCreateInfo markByQuestId = ModelBase<MapModel>.Instance.GetMarkByQuestId(questId);
			if (markByQuestId == null)
			{
				ControllerBase<WorldMapController>.Instance.StartListenChildQuestNodeStatusChangedAndOpenWorldMap(questId);
				base.Finish();
				return;
			}
			WorldMapViewOpenParams data = new WorldMapViewOpenParams
			{
				MarkId = markByQuestId.MarkId,
				MarkType = markByQuestId.MarkType
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, delegate(bool _, int _)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.WorldMapOpenedForQuestMapFocus, questId);
			});
			base.Finish();
		}
	}
}
