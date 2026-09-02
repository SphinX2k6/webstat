using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x0200687F RID: 26751
	[NullableContext(1)]
	[Nullable(0)]
	public class EncircleSelectLevelView : UiViewBase
	{
		// Token: 0x06042A90 RID: 273040 RVA: 0x0111C705 File Offset: 0x0111A905
		public EncircleSelectLevelView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06042A91 RID: 273041 RVA: 0x0111C71C File Offset: 0x0111A91C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem))
			};
		}

		// Token: 0x06042A92 RID: 273042 RVA: 0x0111C7FC File Offset: 0x0111A9FC
		protected override UniTask OnBeforeStartAsync()
		{
			EncircleSelectLevelView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<EncircleSelectLevelView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042A93 RID: 273043 RVA: 0x0111C83F File Offset: 0x0111AA3F
		protected override void OnBeforeShow()
		{
			this.RefreshView();
		}

		// Token: 0x06042A94 RID: 273044 RVA: 0x0111C848 File Offset: 0x0111AA48
		public void RefreshView()
		{
			List<IEncircleSelectLevelData> list = new List<IEncircleSelectLevelData>();
			int activityId = ControllerBase<ActivityEncircleController>.Instance.ActivityId;
			foreach (EncircleChallengeGroup encircleChallengeGroup in ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleGroups(activityId))
			{
				EncircleSelectLevelData item = new EncircleSelectLevelData
				{
					GroupId = encircleChallengeGroup.Id
				};
				list.Add(item);
			}
			int count = list.Count;
			int count2 = this.SelectItemList.Count;
			for (int i = 0; i < count2; i++)
			{
				if (i < count)
				{
					this.SelectItemList[i].RefreshView(list[i]);
					this.SelectItemList[i].SetUiActive(true);
				}
				else
				{
					this.SelectItemList[i].SetUiActive(false);
				}
			}
		}

		// Token: 0x06042A95 RID: 273045 RVA: 0x0111C930 File Offset: 0x0111AB30
		private void RefreshScrollPercentage()
		{
			ActivityEncircleData encircleData = ControllerBase<ActivityEncircleController>.Instance.GetEncircleData();
			if (encircleData == null)
			{
				return;
			}
			int activityId = ControllerBase<ActivityEncircleController>.Instance.ActivityId;
			IReadOnlyList<EncircleChallengeGroup> encircleGroups = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleGroups(activityId);
			int currentGroupId = encircleData.GetCurrentGroup();
			if (currentGroupId == 0)
			{
				return;
			}
			if (encircleGroups == null)
			{
				return;
			}
			UUIScrollViewWithScrollbarComponent scrollItem = base.GetScrollViewWithScrollbar(1);
			float percentage = (float)currentGroupId / (float)encircleGroups.Count;
			if (percentage < 0f)
			{
				return;
			}
			Action<float> callback = delegate(float _)
			{
				int name = 2 + currentGroupId - 1;
				UUIItem item = this.GetItem(name);
				scrollItem.SetScrollProgress(1f - percentage + 0.15f);
				scrollItem.OnLateUpdate.Unbind();
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(item, true, false, false);
			};
			scrollItem.OnLateUpdate.Bind(callback);
		}

		// Token: 0x06042A96 RID: 273046 RVA: 0x0111C9D9 File Offset: 0x0111ABD9
		private void OnClickedCloseButton()
		{
			base.CloseMe(null);
		}

		// Token: 0x06042A97 RID: 273047 RVA: 0x0111C9E4 File Offset: 0x0111ABE4
		private void OnClickHelpBtn()
		{
			ActivityEncircleData encircleData = ControllerBase<ActivityEncircleController>.Instance.GetEncircleData();
			if (encircleData == null)
			{
				return;
			}
			ControllerBase<HelpController>.Instance.OpenHelpById(encircleData.LocalConfig.Value.HelpId);
		}

		// Token: 0x040251C3 RID: 152003
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040251C4 RID: 152004
		private readonly List<EncircleSelectLevelItemGrid> SelectItemList = new List<EncircleSelectLevelItemGrid>();
	}
}
