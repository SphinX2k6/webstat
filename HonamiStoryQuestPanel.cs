using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F64 RID: 8036
public class HonamiStoryQuestPanel : UiPanelBase
{
	// Token: 0x0600F0B0 RID: 61616 RVA: 0x0041C4FC File Offset: 0x0041A6FC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnQuestView));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F0B1 RID: 61617 RVA: 0x0041C668 File Offset: 0x0041A868
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryQuestPanel.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryQuestPanel.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F0B2 RID: 61618 RVA: 0x0041C6AB File Offset: 0x0041A8AB
	[NullableContext(1)]
	private HonamiStoryQuestPanelQuestItem CreateQuestItem()
	{
		return new HonamiStoryQuestPanelQuestItem();
	}

	// Token: 0x0600F0B3 RID: 61619 RVA: 0x0041C6B4 File Offset: 0x0041A8B4
	public void Refresh(bool showSubQuest = true)
	{
		bool flag = HonamiStoryUtil.CheckInActivityQuest();
		List<HonamiStoryQuestDataBase> questDataListByQuestType = ModelBase<HonamiStoryModel>.Instance.GetQuestDataListByQuestType(EHonamiStoryQuestType.Main);
		if (flag && questDataListByQuestType.Count > 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), questDataListByQuestType[0].GetNameKey(), Array.Empty<object>());
			GenericScrollViewNew<HonamiStoryQuestPanelQuestItem, HonamiStoryQuestDataBase> mainQuestLayout = this.MainQuestLayout;
			if (mainQuestLayout != null)
			{
				mainQuestLayout.RefreshByData(questDataListByQuestType, null, false);
			}
		}
		base.GetItem(0).SetUIActive(flag && questDataListByQuestType.Count > 0);
		bool flag2 = ModelBase<FunctionModel>.Instance != null && ModelBase<FunctionModel>.Instance.IsOpen(10113);
		bool flag3 = showSubQuest && flag2;
		if (flag3)
		{
			List<HonamiStoryQuestDataBase> questDataListByQuestType2 = ModelBase<HonamiStoryModel>.Instance.GetQuestDataListByQuestType(EHonamiStoryQuestType.Sub);
			if (questDataListByQuestType2.Count == 0)
			{
				flag3 = false;
			}
			else
			{
				GenericLayout<HonamiStoryQuestPanelQuestItem, HonamiStoryQuestDataBase> subQuestLayout = this.SubQuestLayout;
				if (subQuestLayout != null)
				{
					subQuestLayout.RefreshByData(questDataListByQuestType2, null, false);
				}
			}
		}
		base.GetItem(5).SetUIActive(flag3);
	}

	// Token: 0x0600F0B4 RID: 61620 RVA: 0x0041C78D File Offset: 0x0041A98D
	private void OnBtnQuestView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryQuestView, null, null);
	}

	// Token: 0x040073A5 RID: 29605
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<HonamiStoryQuestPanelQuestItem, HonamiStoryQuestDataBase> MainQuestLayout;

	// Token: 0x040073A6 RID: 29606
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<HonamiStoryQuestPanelQuestItem, HonamiStoryQuestDataBase> SubQuestLayout;

	// Token: 0x020082F4 RID: 33524
	private enum EHonamiStoryQuestPanelComponent
	{
		// Token: 0x0402C66A RID: 181866
		MainContent,
		// Token: 0x0402C66B RID: 181867
		QuestViewButton,
		// Token: 0x0402C66C RID: 181868
		MainQuestTitleText,
		// Token: 0x0402C66D RID: 181869
		MainQuestVerticalLayout,
		// Token: 0x0402C66E RID: 181870
		MainQuestItem,
		// Token: 0x0402C66F RID: 181871
		SubContent,
		// Token: 0x0402C670 RID: 181872
		SubQuestVerticalLayout,
		// Token: 0x0402C671 RID: 181873
		SubQuestItem
	}
}
