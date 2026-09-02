using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001455 RID: 5205
public class NewcomerJourneyChoseRoleView : UiViewBase
{
	// Token: 0x06009128 RID: 37160 RVA: 0x002636AA File Offset: 0x002618AA
	[NullableContext(1)]
	public NewcomerJourneyChoseRoleView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06009129 RID: 37161 RVA: 0x002636B4 File Offset: 0x002618B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickConfirmBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600912A RID: 37162 RVA: 0x00263800 File Offset: 0x00261A00
	protected override UniTask OnBeforeStartAsync()
	{
		NewcomerJourneyChoseRoleView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<NewcomerJourneyChoseRoleView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600912B RID: 37163 RVA: 0x00263844 File Offset: 0x00261A44
	protected override void OnStart()
	{
		ActivityNewcomerJourneyData newcomerJourneyData = ControllerBase<ActivityNewcomerJourneyController>.Instance.GetNewcomerJourneyData();
		List<int> list = new List<int>(ConfigBase<ActivityNewcomerJourneyConfig>.Instance.GetChapterById(newcomerJourneyData.ChooseRoleChapterId).Value.GetRolesArray());
		GenericScrollViewNew<NewcomerJourneyRoleSelectItem, int> selectionScrollView = this.SelectionScrollView;
		if (selectionScrollView != null)
		{
			selectionScrollView.RefreshByData(list, delegate
			{
				int num = 0;
				this.SelectionScrollView.GetGenericLayout().SelectGridProxy(num, false);
				this.OnItemSelect(list[num]);
				this.RoleId = list[num];
			}, false);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "NewPlayer_Adventure_005", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "NewPlayer_Adventure_006", Array.Empty<object>());
		base.GetItem(7).SetUIActive(false);
	}

	// Token: 0x0600912C RID: 37164 RVA: 0x002638FC File Offset: 0x00261AFC
	private void OnClickConfirmBtn()
	{
		ActivityNewcomerJourneyData newcomerJourneyData = ControllerBase<ActivityNewcomerJourneyController>.Instance.GetNewcomerJourneyData();
		if (newcomerJourneyData.GetCanGetCharacter())
		{
			ControllerBase<ActivityNewcomerJourneyController>.Instance.GetSelectRole(newcomerJourneyData.Id, newcomerJourneyData.ChooseRoleChapterId, this.RoleId);
		}
		base.CloseMe(null);
	}

	// Token: 0x0600912D RID: 37165 RVA: 0x0026393F File Offset: 0x00261B3F
	[NullableContext(1)]
	private NewcomerJourneyRoleSelectItem CreateSelectionItem()
	{
		return new NewcomerJourneyRoleSelectItem
		{
			ToggleCallBack = new Action<int, int>(this.SelectItemByIndex),
			CanToggleChange = new Func<int, bool>(this.CanToggleChange),
			OpenCallBack = new Action(this.AfterOpenRoleView)
		};
	}

	// Token: 0x0600912E RID: 37166 RVA: 0x0026397C File Offset: 0x00261B7C
	private void AfterOpenRoleView()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600912F RID: 37167 RVA: 0x00263985 File Offset: 0x00261B85
	private void SelectItemByIndex(int gridIndex, int roleId)
	{
		GenericScrollViewNew<NewcomerJourneyRoleSelectItem, int> selectionScrollView = this.SelectionScrollView;
		if (selectionScrollView != null)
		{
			GenericLayout<NewcomerJourneyRoleSelectItem, int> genericLayout = selectionScrollView.GetGenericLayout();
			if (genericLayout != null)
			{
				genericLayout.SelectGridProxy(gridIndex, false);
			}
		}
		this.OnItemSelect(roleId);
		this.RoleId = roleId;
	}

	// Token: 0x06009130 RID: 37168 RVA: 0x002639B4 File Offset: 0x00261BB4
	private bool CanToggleChange(int gridIndex)
	{
		GenericScrollViewNew<NewcomerJourneyRoleSelectItem, int> selectionScrollView = this.SelectionScrollView;
		int? num;
		if (selectionScrollView == null)
		{
			num = null;
		}
		else
		{
			GenericLayout<NewcomerJourneyRoleSelectItem, int> genericLayout = selectionScrollView.GetGenericLayout();
			num = ((genericLayout != null) ? new int?(genericLayout.GetSelectedGridIndex()) : null);
		}
		int? num2 = num;
		int? num3 = num2;
		return !(gridIndex == num3.GetValueOrDefault() & num3 != null);
	}

	// Token: 0x06009131 RID: 37169 RVA: 0x00263A0C File Offset: 0x00261C0C
	private void OnItemSelect(int roleId)
	{
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), roleConfig.Value.Name, Array.Empty<object>());
		CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
		{
			Data = null,
			ItemConfigId = new int?(roleId)
		};
		SmallItemGrid curSelectedItem = this.CurSelectedItem;
		if (curSelectedItem == null)
		{
			return;
		}
		curSelectedItem.Apply<CharacterSmallItemGrid>(parameters);
	}

	// Token: 0x04004345 RID: 17221
	private int RoleId;

	// Token: 0x04004346 RID: 17222
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<NewcomerJourneyRoleSelectItem, int> SelectionScrollView;

	// Token: 0x04004347 RID: 17223
	[Nullable(2)]
	private SmallItemGrid CurSelectedItem;

	// Token: 0x02007855 RID: 30805
	private class EComponentDefine
	{
		// Token: 0x04029625 RID: 169509
		public const int TitleText = 0;

		// Token: 0x04029626 RID: 169510
		public const int SubTitleText = 1;

		// Token: 0x04029627 RID: 169511
		public const int ScrollView = 2;

		// Token: 0x04029628 RID: 169512
		public const int RoleItem = 3;

		// Token: 0x04029629 RID: 169513
		public const int RoleNameText = 4;

		// Token: 0x0402962A RID: 169514
		public const int ConfirmBtn = 5;

		// Token: 0x0402962B RID: 169515
		public const int SelectText = 6;

		// Token: 0x0402962C RID: 169516
		public const int TipsText = 7;
	}
}
