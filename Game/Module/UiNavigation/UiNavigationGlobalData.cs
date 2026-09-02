using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CDD RID: 19677
	public class UiNavigationGlobalData : IStaticVariableResetter
	{
		// Token: 0x060332EE RID: 209646 RVA: 0x00CD0029 File Offset: 0x00CCE229
		static UiNavigationGlobalData()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(UiNavigationGlobalData.CreateStaticDefaultValue), new Action(UiNavigationGlobalData.ResetStaticDefaultValue));
		}

		// Token: 0x060332EF RID: 209647 RVA: 0x00CD0048 File Offset: 0x00CCE248
		public static int GetListenerInstanceId()
		{
			return ++UiNavigationGlobalData.ListenerInstanceId;
		}

		// Token: 0x060332F0 RID: 209648 RVA: 0x00CD0058 File Offset: 0x00CCE258
		[NullableContext(1)]
		public static void AddBlockListenerFocusTag(string tag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "添加禁止切换导航对象标签";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签", tag);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			UiNavigationGlobalData.BlockListenerFocusTagList.Add(tag);
		}

		// Token: 0x060332F1 RID: 209649 RVA: 0x00CD009C File Offset: 0x00CCE29C
		[NullableContext(1)]
		public static void DeleteBlockListenerFocusTag(string tag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "移除禁止切换导航对象标签";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签", tag);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			UiNavigationGlobalData.BlockListenerFocusTagList.Remove(tag);
		}

		// Token: 0x170087CC RID: 34764
		// (get) Token: 0x060332F2 RID: 209650 RVA: 0x00CD00DF File Offset: 0x00CCE2DF
		public static bool IsBlockNavigation
		{
			get
			{
				return UiNavigationGlobalData.BlockListenerFocusTagList.Count > 0 || ControllerBase<BlackScreenController>.Instance.IsBlackScreenActive() || Singleton<UiLayer>.Instance.IsInMask();
			}
		}

		// Token: 0x060332F3 RID: 209651 RVA: 0x00CD0106 File Offset: 0x00CCE306
		public static void ClearBlockListener()
		{
			UiNavigationGlobalData.BlockListenerFocusTagList.Clear();
		}

		// Token: 0x060332F4 RID: 209652 RVA: 0x00CD0112 File Offset: 0x00CCE312
		public static void CreateStaticDefaultValue()
		{
			UiNavigationGlobalData.BlockListenerFocusTagList = new HashSet<string>();
		}

		// Token: 0x060332F5 RID: 209653 RVA: 0x00CD011E File Offset: 0x00CCE31E
		public static void ResetStaticDefaultValue()
		{
			UiNavigationGlobalData.NeedCalculateCurrentPanel = false;
			UiNavigationGlobalData.NeedRefreshPanelId = 0;
			UiNavigationGlobalData.IsAllowCrossNavigationGroup = false;
			UiNavigationGlobalData.IsAllowLoopScrollInteractHighlight = false;
			UiNavigationGlobalData.VisionReplaceViewFindDefault = true;
			UiNavigationGlobalData.ListenerInstanceId = 0;
			UiNavigationGlobalData.BlockListenerFocusTagList = null;
		}

		// Token: 0x0401DBFA RID: 121850
		public static bool NeedCalculateCurrentPanel;

		// Token: 0x0401DBFB RID: 121851
		public static int NeedRefreshPanelId;

		// Token: 0x0401DBFC RID: 121852
		public static bool IsAllowCrossNavigationGroup;

		// Token: 0x0401DBFD RID: 121853
		public static bool IsAllowLoopScrollInteractHighlight;

		// Token: 0x0401DBFE RID: 121854
		public static bool VisionReplaceViewFindDefault;

		// Token: 0x0401DBFF RID: 121855
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static HashSet<string> BlockListenerFocusTagList;

		// Token: 0x0401DC00 RID: 121856
		private static int ListenerInstanceId;
	}
}
