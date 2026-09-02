using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062DA RID: 25306
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisSelectLevelView : UiViewBase
	{
		// Token: 0x0603FA6A RID: 260714 RVA: 0x010519C0 File Offset: 0x0104FBC0
		public TetrisSelectLevelView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FA6B RID: 260715 RVA: 0x010519D0 File Offset: 0x0104FBD0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x0603FA6C RID: 260716 RVA: 0x01051A40 File Offset: 0x0104FC40
		protected override UniTask OnBeforeStartAsync()
		{
			TetrisSelectLevelView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TetrisSelectLevelView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FA6D RID: 260717 RVA: 0x01051A84 File Offset: 0x0104FC84
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetTitle(ConfigMultiTextLang.GetLocalTextNew("PrefabTextItem_3394563466_Text", null) ?? "");
			this.CaptionItem.SetHelpBtnActive(true);
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickedCloseButton));
			this.CaptionItem.SetHelpCallBack(new Action(this.OnClickHelpBtn));
		}

		// Token: 0x0603FA6E RID: 260718 RVA: 0x01051AFC File Offset: 0x0104FCFC
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x0603FA6F RID: 260719 RVA: 0x01051B1A File Offset: 0x0104FD1A
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x0603FA70 RID: 260720 RVA: 0x01051B38 File Offset: 0x0104FD38
		protected override void OnBeforeShow()
		{
			this.LevelScroll.RefreshByData(ControllerBase<ActivityTetrisController>.Instance.GetAllLevelSelectData(), null, false);
			this.RefreshScrollPercentage();
		}

		// Token: 0x0603FA71 RID: 260721 RVA: 0x01051B58 File Offset: 0x0104FD58
		private void RefreshScrollPercentage()
		{
			TetrisSelectLevelView.<>c__DisplayClass11_0 CS$<>8__locals1 = new TetrisSelectLevelView.<>c__DisplayClass11_0();
			CS$<>8__locals1.<>4__this = this;
			ActivityTetrisData tetrisData = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData();
			if (tetrisData == null)
			{
				return;
			}
			List<ITetrisSelectGroupData> allLevelSelectData = ControllerBase<ActivityTetrisController>.Instance.GetAllLevelSelectData();
			if (allLevelSelectData == null || allLevelSelectData.Count == 0)
			{
				return;
			}
			CS$<>8__locals1.targetIndex = 0;
			bool flag = false;
			for (int i = 0; i < allLevelSelectData.Count; i++)
			{
				int challengeId = allLevelSelectData[i].ChallengeIds[0];
				if (tetrisData.CheckChallengeIsOpen(challengeId) && tetrisData.CheckPreChallengeComplete(challengeId) && !tetrisData.CheckChallengeComplete(challengeId))
				{
					CS$<>8__locals1.targetIndex = i;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				for (int j = 0; j < allLevelSelectData.Count; j++)
				{
					ITetrisSelectGroupData tetrisSelectGroupData = allLevelSelectData[j];
					if (tetrisSelectGroupData.ChallengeIds.Count > 1)
					{
						int challengeId2 = tetrisSelectGroupData.ChallengeIds[1];
						if (tetrisData.CheckChallengeIsOpen(challengeId2) && tetrisData.CheckPreChallengeComplete(challengeId2) && !tetrisData.CheckChallengeComplete(challengeId2))
						{
							CS$<>8__locals1.targetIndex = j;
							flag = true;
							break;
						}
					}
				}
			}
			if (!flag)
			{
				for (int k = allLevelSelectData.Count - 1; k >= 0; k--)
				{
					int challengeId3 = allLevelSelectData[k].ChallengeIds[0];
					if (tetrisData.CheckChallengeIsOpen(challengeId3) && tetrisData.CheckPreChallengeComplete(challengeId3))
					{
						CS$<>8__locals1.targetIndex = k;
						break;
					}
				}
			}
			CS$<>8__locals1.percentage = (float)CS$<>8__locals1.targetIndex / (float)allLevelSelectData.Count;
			if (float.IsNaN(CS$<>8__locals1.percentage) || allLevelSelectData.Count <= 1)
			{
				return;
			}
			CS$<>8__locals1.scrollItem = base.GetScrollViewWithScrollbar(1);
			CS$<>8__locals1.scrollItem.OnLateUpdate.Bind(new Action<float>(CS$<>8__locals1.<RefreshScrollPercentage>g__callBack|0));
		}

		// Token: 0x0603FA72 RID: 260722 RVA: 0x01051D07 File Offset: 0x0104FF07
		private TetrisSelectLevelItemGrid UpdateItem()
		{
			return new TetrisSelectLevelItemGrid();
		}

		// Token: 0x0603FA73 RID: 260723 RVA: 0x01051D0E File Offset: 0x0104FF0E
		private void OnActivityClose(IReadOnlySet<int> closeActivities)
		{
			if (closeActivities.Contains(ControllerBase<ActivityTetrisController>.Instance.ActivityId))
			{
				ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
			}
		}

		// Token: 0x0603FA74 RID: 260724 RVA: 0x01051D2C File Offset: 0x0104FF2C
		private void OnClickedCloseButton()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.TetrisSelectLevelView, null);
		}

		// Token: 0x0603FA75 RID: 260725 RVA: 0x01051D40 File Offset: 0x0104FF40
		private void OnClickHelpBtn()
		{
			ActivityTetrisData tetrisData = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData();
			if (tetrisData == null)
			{
				return;
			}
			ControllerBase<HelpController>.Instance.OpenHelpById(tetrisData.LocalConfig.Value.HelpId);
		}

		// Token: 0x04023BDA RID: 146394
		private const int ANIM_ENDCOUNT = 15;

		// Token: 0x04023BDB RID: 146395
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023BDC RID: 146396
		private GenericLayout<TetrisSelectLevelItemGrid, ITetrisSelectGroupData> LevelScroll;

		// Token: 0x04023BDD RID: 146397
		public int ExecuteCount = 1;
	}
}
