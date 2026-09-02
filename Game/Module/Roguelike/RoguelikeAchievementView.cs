using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200517D RID: 20861
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeAchievementView : UiViewBase
	{
		// Token: 0x06035ACF RID: 219855 RVA: 0x00D7BAC4 File Offset: 0x00D79CC4
		public RoguelikeAchievementView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035AD0 RID: 219856 RVA: 0x00D7BAD8 File Offset: 0x00D79CD8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035AD1 RID: 219857 RVA: 0x00D7BB64 File Offset: 0x00D79D64
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeAchievementView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeAchievementView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035AD2 RID: 219858 RVA: 0x00D7BBA7 File Offset: 0x00D79DA7
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAchievementDataWithIdNotify, new Action<int>(this.OnAchievementDataWithIdNotify));
		}

		// Token: 0x06035AD3 RID: 219859 RVA: 0x00D7BBC5 File Offset: 0x00D79DC5
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnAchievementDataWithIdNotify, new Action<int>(this.OnAchievementDataWithIdNotify));
		}

		// Token: 0x06035AD4 RID: 219860 RVA: 0x00D7BBE3 File Offset: 0x00D79DE3
		protected void OnAchievementDataWithIdNotify(int id)
		{
			this.ToggleCallBack(this.TabComponent.GetSelectedIndex());
		}

		// Token: 0x06035AD5 RID: 219861 RVA: 0x00D7BBF6 File Offset: 0x00D79DF6
		private RoguelikeAchievementItem CreateAchievementItem()
		{
			return new RoguelikeAchievementItem
			{
				OnBtnRewardClick = new Action(this.OnBtnRewardClick)
			};
		}

		// Token: 0x06035AD6 RID: 219862 RVA: 0x00D7BC10 File Offset: 0x00D79E10
		private void OnBtnRewardClick()
		{
			List<int> list = new List<int>();
			foreach (AchievementData achievementData in ModelBase<AchievementModel>.Instance.GetGroupAchievements(this.CurrentGroupId, true))
			{
				if (achievementData.GetFinishState() == EAchievementStateEnum.CanGetReward && achievementData.GetRewards().Count > 0)
				{
					list.Add(achievementData.GetId());
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			ControllerBase<AchievementController>.Instance.RequestGetMultiAchievementReward(list.ToArray(), Array.Empty<int>());
		}

		// Token: 0x06035AD7 RID: 219863 RVA: 0x00D7BCB0 File Offset: 0x00D79EB0
		protected void CloseClick()
		{
			Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
		}

		// Token: 0x06035AD8 RID: 219864 RVA: 0x00D7BCC8 File Offset: 0x00D79EC8
		private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new CommonTabItem();
		}

		// Token: 0x06035AD9 RID: 219865 RVA: 0x00D7BCD0 File Offset: 0x00D79ED0
		private void ToggleCallBack(int index)
		{
			AchievementGroupData groupData = this.AchievementGroupDataList[index];
			this.RefreshAchievementList(groupData);
		}

		// Token: 0x06035ADA RID: 219866 RVA: 0x00D7BCF4 File Offset: 0x00D79EF4
		private CommonTabData GetCommonData(int index)
		{
			AchievementGroupData groupData = this.AchievementGroupDataList[index];
			return this.CreateCommonTabData(groupData);
		}

		// Token: 0x06035ADB RID: 219867 RVA: 0x00D7BD15 File Offset: 0x00D79F15
		private CommonTabItemData CreateTabItemData(AchievementGroupData groupData)
		{
			return new CommonTabItemData
			{
				RedDotName = new ERedDotName?(ERedDotName.RoguelikeAchievementGroup),
				RedDotUid = new int?(groupData.GetId()),
				Data = this.CreateCommonTabData(groupData)
			};
		}

		// Token: 0x06035ADC RID: 219868 RVA: 0x00D7BD47 File Offset: 0x00D79F47
		private CommonTabData CreateCommonTabData(AchievementGroupData groupData)
		{
			return new CommonTabData(groupData.GetTexture(), new CommonTabTitleData(groupData.GetTitleId(), Array.Empty<object>()), null);
		}

		// Token: 0x06035ADD RID: 219869 RVA: 0x00D7BD68 File Offset: 0x00D79F68
		public void RefreshAchievementList(AchievementGroupData groupData)
		{
			this.CurrentGroupId = groupData.GetId();
			List<AchievementData> groupAchievements = ModelBase<AchievementModel>.Instance.GetGroupAchievements(this.CurrentGroupId, true);
			groupAchievements.Sort((AchievementData a, AchievementData b) => b.GetFinishSort() - a.GetFinishSort());
			this.AchievementScrollView.RefreshByData(groupAchievements, delegate
			{
				RoguelikeAchievementItem scrollItemByIndex = this.AchievementScrollView.GetScrollItemByIndex(0);
				if (scrollItemByIndex != null)
				{
					this.AchievementScrollView.LateScrollTo(scrollItemByIndex.GetRootItem(), null, false);
				}
			}, false);
		}

		// Token: 0x0401ECF9 RID: 126201
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x0401ECFA RID: 126202
		public List<AchievementGroupData> AchievementGroupDataList = new List<AchievementGroupData>();

		// Token: 0x0401ECFB RID: 126203
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericScrollViewNew<RoguelikeAchievementItem, AchievementData> AchievementScrollView;

		// Token: 0x0401ECFC RID: 126204
		private int CurrentGroupId;

		// Token: 0x0200B133 RID: 45363
		[NullableContext(0)]
		private class ERoguelikeAchievementViewDefine
		{
			// Token: 0x04036F55 RID: 225109
			public const int CaptionItem = 0;

			// Token: 0x04036F56 RID: 225110
			public const int PanelContent = 1;

			// Token: 0x04036F57 RID: 225111
			public const int ScrollViewItem = 2;
		}
	}
}
