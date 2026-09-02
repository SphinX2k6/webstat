using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200124F RID: 4687
[NullableContext(1)]
[Nullable(0)]
public class BeginnerCarnivalChoseRoleView : UiViewBase
{
	// Token: 0x06007CEB RID: 31979 RVA: 0x0020E708 File Offset: 0x0020C908
	public BeginnerCarnivalChoseRoleView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007CEC RID: 31980 RVA: 0x0020E714 File Offset: 0x0020C914
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickConfirmBtn))
		};
	}

	// Token: 0x06007CED RID: 31981 RVA: 0x0020E7D4 File Offset: 0x0020C9D4
	protected override UniTask OnBeforeStartAsync()
	{
		BeginnerCarnivalChoseRoleView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BeginnerCarnivalChoseRoleView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007CEE RID: 31982 RVA: 0x0020E818 File Offset: 0x0020CA18
	protected override void OnStart()
	{
		NewbieCarnivalParam? newbieCarnivalParam;
		List<int> list = ((ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalParam(ControllerBase<BeginnerCarnivalController>.Instance.ActivityId) != null) ? newbieCarnivalParam.GetValueOrDefault().GetRolesArray().ToList<int>() : null) ?? new List<int>();
		GenericScrollViewNew<RoleSelectItem, int> selectionScrollView = this.SelectionScrollView;
		if (selectionScrollView != null)
		{
			selectionScrollView.RefreshByData(list, delegate
			{
				int choseRoleId = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData().ChoseRoleId;
				int val = list.IndexOf(choseRoleId);
				GenericLayout<RoleSelectItem, int> genericLayout = this.SelectionScrollView.GetGenericLayout();
				int num = Math.Max(val, 0);
				genericLayout.SelectGridProxy(num, false);
				this.OnItemSelect(list[num]);
				this.RoleId = list[num];
			}, false);
		}
		ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData().SetChoseRoleViewEnter();
	}

	// Token: 0x06007CEF RID: 31983 RVA: 0x0020E8A9 File Offset: 0x0020CAA9
	private void OnClickConfirmBtn()
	{
		if (this.RoleId != ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData().ChoseRoleId)
		{
			ControllerBase<BeginnerCarnivalController>.Instance.NewbieCarnivalSwitchRoleRequest(this.RoleId);
		}
		base.CloseMe(null);
	}

	// Token: 0x06007CF0 RID: 31984 RVA: 0x0020E8D9 File Offset: 0x0020CAD9
	private RoleSelectItem CreateSelectionItem()
	{
		return new RoleSelectItem
		{
			ToggleCallBack = new Action<int, int>(this.SelectItemByIndex),
			CanToggleChange = new Func<int, bool>(this.CanToggleChange)
		};
	}

	// Token: 0x06007CF1 RID: 31985 RVA: 0x0020E904 File Offset: 0x0020CB04
	private void SelectItemByIndex(int gridIndex, int roleId)
	{
		GenericScrollViewNew<RoleSelectItem, int> selectionScrollView = this.SelectionScrollView;
		if (selectionScrollView != null)
		{
			GenericLayout<RoleSelectItem, int> genericLayout = selectionScrollView.GetGenericLayout();
			if (genericLayout != null)
			{
				genericLayout.SelectGridProxy(gridIndex, false);
			}
		}
		this.OnItemSelect(roleId);
		this.RoleId = roleId;
	}

	// Token: 0x06007CF2 RID: 31986 RVA: 0x0020E934 File Offset: 0x0020CB34
	private bool CanToggleChange(int gridIndex)
	{
		GenericScrollViewNew<RoleSelectItem, int> selectionScrollView = this.SelectionScrollView;
		int? num;
		if (selectionScrollView == null)
		{
			num = null;
		}
		else
		{
			GenericLayout<RoleSelectItem, int> genericLayout = selectionScrollView.GetGenericLayout();
			num = ((genericLayout != null) ? new int?(genericLayout.GetSelectedGridIndex()) : null);
		}
		int? num2 = num;
		int? num3 = num2;
		return !(gridIndex == num3.GetValueOrDefault() & num3 != null);
	}

	// Token: 0x06007CF3 RID: 31987 RVA: 0x0020E98C File Offset: 0x0020CB8C
	private void OnItemSelect(int roleId)
	{
		RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), value.Name, Array.Empty<object>());
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

	// Token: 0x04003BC3 RID: 15299
	private int RoleId;

	// Token: 0x04003BC4 RID: 15300
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<RoleSelectItem, int> SelectionScrollView;

	// Token: 0x04003BC5 RID: 15301
	[Nullable(2)]
	private SmallItemGrid CurSelectedItem;
}
