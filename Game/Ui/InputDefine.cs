using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A23 RID: 18979
	public class InputDefine
	{
		// Token: 0x06031989 RID: 203145 RVA: 0x00C5B33C File Offset: 0x00C5953C
		// Note: this type is marked as 'beforefieldinit'.
		static InputDefine()
		{
			Dictionary<string, EUiViewName> dictionary = new Dictionary<string, EUiViewName>();
			dictionary["邮件"] = EUiViewName.MailBoxView;
			dictionary["地图"] = EUiViewName.WorldMapView;
			dictionary["任务"] = EUiViewName.QuestView;
			dictionary["编队"] = EUiViewName.EditFormationView;
			dictionary["背包"] = EUiViewName.InventoryView;
			dictionary["聊天"] = EUiViewName.ChatView;
			dictionary["功能菜单"] = EUiViewName.FunctionView;
			dictionary["角色选择界面"] = EUiViewName.RoleRootView;
			dictionary["幻象列表界面"] = EUiViewName.PhantomExploreSetView;
			dictionary["幻象探索选择界面"] = EUiViewName.PhantomExploreView;
			dictionary["塔防轮盘"] = EUiViewName.PhantomExploreView;
			dictionary["GM指令"] = EUiViewName.GmView;
			dictionary["教程"] = EUiViewName.TutorialView;
			dictionary["联机"] = EUiViewName.OnlineWorldHallView;
			dictionary["小活动"] = EUiViewName.CommonActivityView;
			dictionary["调谐"] = EUiViewName.GachaMainView;
			dictionary["变星"] = EUiViewName.BattlePassMainView;
			dictionary["拾音辑录"] = EUiViewName.AdventureGuideView;
			InputDefine.openViewActionsMap = dictionary;
		}

		// Token: 0x0401CE0B RID: 118283
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<string, EUiViewName> openViewActionsMap;
	}
}
