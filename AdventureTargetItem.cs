using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001741 RID: 5953
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AdventureTargetItem : GridProxyAbstract<AdventureTaskRecord>
{
	// Token: 0x0600A746 RID: 42822 RVA: 0x002C7058 File Offset: 0x002C5258
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnRedirectBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickGetButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A747 RID: 42823 RVA: 0x002C7294 File Offset: 0x002C5494
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(3), new Func<CommonItemSmallItemGrid>(this.OnRewardLayoutUpdater), null, false, true);
		this.ExtendToggle = (base.GetItem(1).GetOwner().GetComponentByClass(UUIExtendToggle.StaticClass()) as UUIExtendToggle);
		this.ExtendToggle.OnPostAudioEvent.Bind(delegate(string eventPath)
		{
			if (!string.IsNullOrEmpty(eventPath))
			{
				base.PostClickAudioEvent(eventPath);
			}
		});
		this.ExtendToggle.OnPostAudioStateEvent.Bind(delegate(EToggleAudioTransitionState state, string eventPath)
		{
			if (!string.IsNullOrEmpty(eventPath))
			{
				base.PostClickAudioEvent(eventPath);
			}
		});
	}

	// Token: 0x0600A748 RID: 42824 RVA: 0x002C7320 File Offset: 0x002C5520
	private CommonItemSmallItemGrid OnRewardLayoutUpdater()
	{
		CommonItemSmallItemGrid commonItemSmallItemGrid = new CommonItemSmallItemGrid();
		commonItemSmallItemGrid.SetUseFixedAsync(true);
		commonItemSmallItemGrid.ShowReceivedCallBack = delegate(TItem _)
		{
			AdventureTaskRecord data = this.Data;
			return data != null && data.Status == AdventreTaskSate.Received;
		};
		return commonItemSmallItemGrid;
	}

	// Token: 0x0600A749 RID: 42825 RVA: 0x002C7340 File Offset: 0x002C5540
	protected override void OnBeforeDestroy()
	{
		this.ExtendToggle.OnPostAudioEvent.Unbind();
		this.ExtendToggle.OnPostAudioStateEvent.Unbind();
	}

	// Token: 0x0600A74A RID: 42826 RVA: 0x002C7364 File Offset: 0x002C5564
	public override void Refresh(AdventureTaskRecord data, bool isSelected, int gridIndex)
	{
		this.Clicking = false;
		this.Data = data;
		AdventureTask adventureTaskBase = data.AdventureTaskBase;
		this.AdventureId = data.AdventureTaskBase.Id;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), adventureTaskBase.TaskText, Array.Empty<object>());
		base.GetItem(1).SetUIActive(false);
		int totalNum = data.GetTotalNum();
		int num = ModelBase<AdventureGuideModel>.Instance.GetRewardChaptersList().Contains(data.AdventureTaskBase.ChapterId) ? totalNum : data.Progress;
		UUIText text = base.GetText(5);
		if (totalNum != 0)
		{
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Wandering_Log_Task_Prograss", new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				totalNum
			}));
		}
		else
		{
			text.SetUIActive(false);
		}
		List<TItem> list = new List<TItem>();
		Dictionary<int, int> dropShowInfo = ConfigBase<AdventureGuideConfig>.Instance.GetDropShowInfo(adventureTaskBase.DropIds);
		foreach (KeyValuePair<int, int> keyValuePair in dropShowInfo)
		{
			int key = keyValuePair.Key;
			InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(key, 0);
			TItem item = new TItem(itemData, dropShowInfo[key]);
			list.Add(item);
		}
		this.Layout.RefreshByData(list, delegate
		{
			base.GetScrollViewWithScrollbar(6).ScrollTo(this.Layout.GetGrid(0), false);
		}, false);
		this.RootItem.SetUIActive(true);
		this.SetBtnStatusByTargetState(data.Status, this.Data.AdventureTaskBase.JumpToLength != 0);
		bool flag = data.Status == AdventreTaskSate.Received;
		base.GetItem(10).SetUIActive(!flag);
		base.GetItem(11).SetUIActive(flag);
		base.GetItem(12).SetAlpha(flag ? 0.5f : 1f);
	}

	// Token: 0x0600A74B RID: 42827 RVA: 0x002C754C File Offset: 0x002C574C
	public void SetClickGetButtonCb(Action<int> cb)
	{
		this.ClickGetButtonCb = cb;
	}

	// Token: 0x0600A74C RID: 42828 RVA: 0x002C7555 File Offset: 0x002C5755
	private void SetBtnStatusByTargetState(AdventreTaskSate status, bool showRedirect)
	{
		this.RefreshFinishItem(status);
		this.RefreshGetButton(status);
		this.RefreshRedirectButton(status, showRedirect);
		this.RefreshRedItem(status);
		this.RefreshDoingText(status, showRedirect);
	}

	// Token: 0x0600A74D RID: 42829 RVA: 0x002C757C File Offset: 0x002C577C
	private void RefreshDoingText(AdventreTaskSate state, bool showRedirect)
	{
		base.GetItem(7).SetUIActive(state == AdventreTaskSate.UnFinish && !showRedirect);
	}

	// Token: 0x0600A74E RID: 42830 RVA: 0x002C7594 File Offset: 0x002C5794
	private void RefreshFinishItem(AdventreTaskSate state)
	{
		base.GetItem(8).SetUIActive(state == AdventreTaskSate.Received);
	}

	// Token: 0x0600A74F RID: 42831 RVA: 0x002C75A8 File Offset: 0x002C57A8
	private void RefreshGetButton(AdventreTaskSate state)
	{
		base.GetButton(9).RootUIComp.Get().SetUIActive(state == AdventreTaskSate.Finish);
	}

	// Token: 0x0600A750 RID: 42832 RVA: 0x002C75D4 File Offset: 0x002C57D4
	private void RefreshRedirectButton(AdventreTaskSate state, bool showRedirect)
	{
		base.GetButton(2).RootUIComp.Get().SetUIActive(state == AdventreTaskSate.UnFinish && showRedirect);
	}

	// Token: 0x0600A751 RID: 42833 RVA: 0x002C7600 File Offset: 0x002C5800
	private void RefreshRedItem(AdventreTaskSate state)
	{
		base.GetItem(4).SetUIActive(state == AdventreTaskSate.Finish);
	}

	// Token: 0x0600A752 RID: 42834 RVA: 0x002C7612 File Offset: 0x002C5812
	private void OnClickGetButton()
	{
		if (this.Data.Status == AdventreTaskSate.Finish)
		{
			Action<int> clickGetButtonCb = this.ClickGetButtonCb;
			if (clickGetButtonCb == null)
			{
				return;
			}
			clickGetButtonCb(this.AdventureId);
		}
	}

	// Token: 0x0600A753 RID: 42835 RVA: 0x002C7638 File Offset: 0x002C5838
	private void OnRedirectBtnClick()
	{
		if (!this.Clicking)
		{
			this.Clicking = true;
			if (this.Data.Status == AdventreTaskSate.UnFinish)
			{
				this.HandleJump();
				this.Clicking = false;
			}
		}
	}

	// Token: 0x0600A754 RID: 42836 RVA: 0x002C7664 File Offset: 0x002C5864
	private unsafe void HandleJump()
	{
		AdventureTaskRecord data = this.Data;
		if (((data != null) ? data.AdventureTaskBase.JumpTo() : null) == null)
		{
			return;
		}
		int? num = null;
		string text = null;
		foreach (KeyValuePair<int, string> keyValuePair in this.Data.AdventureTaskBase.JumpTo())
		{
			num = new int?(keyValuePair.Key);
			text = keyValuePair.Value;
		}
		if (num == null || string.IsNullOrEmpty(text))
		{
			return;
		}
		switch (num.Value)
		{
		case 1:
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, int.Parse(text), null);
			return;
		case 2:
		{
			MapConfig instance = ConfigBase<MapConfig>.Instance;
			MapMark? mapMark = (instance != null) ? instance.GetConfigMark(int.Parse(text)) : null;
			if (mapMark == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AdventureGuide;
				ELogAuthor author = ELogAuthor.LJQ;
				string message = "配置了错误的开拓任务跳转参数";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id: ", this.Data.AdventureTaskBase.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Parma: ", text);
				instance2.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			WorldMapViewOpenParams data2 = new WorldMapViewOpenParams
			{
				MarkType = (EMarkType)mapMark.Value.ObjectType,
				MarkId = new int?(mapMark.Value.MarkId),
				OpenFogId = new int?(0)
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Mouse, false, data2, null);
			return;
		}
		case 3:
			if (text == EUiViewName.RoleRootView.ToString())
			{
				ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, 0, null, null, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView((EUiViewName)text, null, null);
			return;
		case 4:
		{
			string value = text;
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, 0, new List<int>(), new EUiTabViewName?((EUiTabViewName)value), null);
			return;
		}
		case 5:
		{
			CalabashRootViewData param = new CalabashRootViewData
			{
				TabViewName = (EUiTabViewName)text,
				Param = null
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CalabashRootView, param, null);
			return;
		}
		case 9:
			this.ProcessDisposableChallengeTabOpen(int.Parse(text));
			return;
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.AdventureGuide;
		ELogAuthor author2 = ELogAuthor.LJQ;
		string message2 = "配置了错误的开拓任务跳转类型";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id: ", this.Data.AdventureTaskBase.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("type: ", num);
		instance3.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
	}

	// Token: 0x0600A755 RID: 42837 RVA: 0x002C7958 File Offset: 0x002C5B58
	private void ProcessDisposableChallengeTabOpen(int jumpParma)
	{
		if (ModelBase<AdventureGuideModel>.Instance.CheckTargetDungeonTypeCanShow((EDungeonType)jumpParma))
		{
			ControllerBase<AdventureGuideController>.Instance.OpenGuideView(new EUiTabViewName?(EUiTabViewName.DisposableChallengeView), new int?(jumpParma), null);
			return;
		}
		AdventureGuideConfig instance = ConfigBase<AdventureGuideConfig>.Instance;
		SecondaryGuideData? secondaryGuideData;
		int valueOrDefault = ((instance != null) ? ((instance.GetSecondaryGuideDataConf(jumpParma) != null) ? new int?(secondaryGuideData.GetValueOrDefault().ConditionGroupId) : null) : null).GetValueOrDefault();
		if (valueOrDefault <= 0)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotOpen", Array.Empty<object>());
			return;
		}
		ConditionGroup? config = ConfigConditionGroupById.GetConfig(valueOrDefault, true);
		string text = (config != null) ? config.GetValueOrDefault().HintText : null;
		if (text != null && !StringUtils.IsEmpty(text))
		{
			string text2 = ConfigMultiTextLang.GetLocalTextNew(text, null) ?? "";
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("UnlockCondition", new object[]
			{
				text2
			});
			return;
		}
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotOpen", Array.Empty<object>());
	}

	// Token: 0x04004EF9 RID: 20217
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> Layout;

	// Token: 0x04004EFA RID: 20218
	public int AdventureId;

	// Token: 0x04004EFB RID: 20219
	[Nullable(2)]
	private AdventureTaskRecord Data;

	// Token: 0x04004EFC RID: 20220
	[Nullable(2)]
	private UUIExtendToggle ExtendToggle;

	// Token: 0x04004EFD RID: 20221
	[Nullable(2)]
	private Action<int> ClickGetButtonCb;

	// Token: 0x04004EFE RID: 20222
	private bool Clicking;

	// Token: 0x02007AAA RID: 31402
	[NullableContext(0)]
	private enum EAdventureItemNode
	{
		// Token: 0x0402A033 RID: 172083
		ItemText,
		// Token: 0x0402A034 RID: 172084
		RewardItem,
		// Token: 0x0402A035 RID: 172085
		RedirectBtn,
		// Token: 0x0402A036 RID: 172086
		RewardLayout,
		// Token: 0x0402A037 RID: 172087
		RedPointItem,
		// Token: 0x0402A038 RID: 172088
		ProgressText,
		// Token: 0x0402A039 RID: 172089
		RewardScroll,
		// Token: 0x0402A03A RID: 172090
		DoingText,
		// Token: 0x0402A03B RID: 172091
		FinishItem,
		// Token: 0x0402A03C RID: 172092
		GetButton,
		// Token: 0x0402A03D RID: 172093
		TextureActiveBg,
		// Token: 0x0402A03E RID: 172094
		TextureDoneBg,
		// Token: 0x0402A03F RID: 172095
		ContentItem
	}
}
