using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061E6 RID: 25062
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityInstanceEntranceDropDownItem : UiPanelBase
	{
		// Token: 0x0603F3D3 RID: 259027 RVA: 0x0103AE64 File Offset: 0x01039064
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F3D4 RID: 259028 RVA: 0x0103AEAC File Offset: 0x010390AC
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityInstanceEntranceDropDownItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityInstanceEntranceDropDownItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F3D5 RID: 259029 RVA: 0x0103AEF0 File Offset: 0x010390F0
		private UniTask CreateDropDownCom()
		{
			ActivityInstanceEntranceDropDownItem.<CreateDropDownCom>d__5 <CreateDropDownCom>d__;
			<CreateDropDownCom>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDropDownCom>d__.<>4__this = this;
			<CreateDropDownCom>d__.<>1__state = -1;
			<CreateDropDownCom>d__.<>t__builder.Start<ActivityInstanceEntranceDropDownItem.<CreateDropDownCom>d__5>(ref <CreateDropDownCom>d__);
			return <CreateDropDownCom>d__.<>t__builder.Task;
		}

		// Token: 0x0603F3D6 RID: 259030 RVA: 0x0103AF33 File Offset: 0x01039133
		protected override void OnStart()
		{
		}

		// Token: 0x0603F3D7 RID: 259031 RVA: 0x0103AF35 File Offset: 0x01039135
		private ActivityEntranceDropDownContentData GetDropDownItemData(object data)
		{
			return data as ActivityEntranceDropDownContentData;
		}

		// Token: 0x0603F3D8 RID: 259032 RVA: 0x0103AF40 File Offset: 0x01039140
		public void RefreshView(ActivityInstanceEntranceData entranceData, ActivityEntranceDropDownData data)
		{
			this.EntranceData = entranceData;
			ActivityEntranceDropDownContentData[] dropDownContentDataList = data.GetDropDownContentDataList();
			int defaultDifficultIndex = this.EntranceData.GetActivityEntranceSelectItemData().GetCurrentSelectData().GetDefaultDifficultIndex();
			CommonDropDown<ActivityEntranceDropDownContentData, ActivityEntranceDropDownContentData> difficultyDropDown = this.DifficultyDropDown;
			if (difficultyDropDown == null)
			{
				return;
			}
			difficultyDropDown.InitScroll(dropDownContentDataList, new Func<ActivityEntranceDropDownContentData, ActivityEntranceDropDownContentData>(this.GetDropDownItemData), defaultDifficultIndex, true);
		}

		// Token: 0x0603F3D9 RID: 259033 RVA: 0x0103AF90 File Offset: 0x01039190
		private DropDownItemBase<ActivityEntranceDropDownContentData> OnCreateDropDownItem(UUIItem item, ActivityEntranceDropDownContentData data)
		{
			return new DropDownItem(item);
		}

		// Token: 0x0603F3DA RID: 259034 RVA: 0x0103AF98 File Offset: 0x01039198
		private TitleItemBase<ActivityEntranceDropDownContentData> OnCreateDropDownTitle(UUIItem item)
		{
			return new DropDownTitle(item);
		}

		// Token: 0x0603F3DB RID: 259035 RVA: 0x0103AFA0 File Offset: 0x010391A0
		private void OnSelectDifficulty(int index, object data)
		{
			ActivityEntranceDropDownContentData activityEntranceDropDownContentData = data as ActivityEntranceDropDownContentData;
			ActivityEntranceDropDownData activityEntranceDropDownData = this.EntranceData.GetActivityEntranceDropDownData();
			if (activityEntranceDropDownData != null)
			{
				activityEntranceDropDownData.SetDefaultIndex(activityEntranceDropDownContentData.GetDataIndex());
			}
			Action<ActivityInstanceEntranceData, int> onSelectCallBack = activityEntranceDropDownContentData.GetOnSelectCallBack();
			if (onSelectCallBack == null)
			{
				return;
			}
			onSelectCallBack(this.EntranceData, activityEntranceDropDownContentData.GetDataIndex());
		}

		// Token: 0x04023821 RID: 145441
		private CommonDropDown<ActivityEntranceDropDownContentData, ActivityEntranceDropDownContentData> DifficultyDropDown;

		// Token: 0x04023822 RID: 145442
		protected ActivityInstanceEntranceData EntranceData;

		// Token: 0x0200C31F RID: 49951
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403C23F RID: 246335
			public const int DropdownItem = 0;
		}
	}
}
