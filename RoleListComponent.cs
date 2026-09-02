using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020027A4 RID: 10148
[NullableContext(1)]
[Nullable(0)]
public class RoleListComponent : UiPanelBase
{
	// Token: 0x1700197E RID: 6526
	// (get) Token: 0x06014093 RID: 82067 RVA: 0x00597DAC File Offset: 0x00595FAC
	public int CurSelectDataId
	{
		get
		{
			int selectedGridIndex = this.ScrollView.GetGenericLayout().GetSelectedGridIndex();
			if (this.DataList == null || selectedGridIndex < 0 || selectedGridIndex >= this.DataList.Count)
			{
				return 0;
			}
			return this.DataList[selectedGridIndex].RoleDataId;
		}
	}

	// Token: 0x06014094 RID: 82068 RVA: 0x00597DF7 File Offset: 0x00595FF7
	[return: Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public GenericScrollViewNew<RoleListItem, RoleListItemData> GetSelfScrollView()
	{
		return this.ScrollView;
	}

	// Token: 0x06014095 RID: 82069 RVA: 0x00597DFF File Offset: 0x00595FFF
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent))
		};
	}

	// Token: 0x06014096 RID: 82070 RVA: 0x00597E24 File Offset: 0x00596024
	protected override void OnStart()
	{
		this.RoleViewAgent = (this.OpenParam as RoleViewAgent);
		if (this.RoleViewAgent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RoleViewAgent为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("界面名称", "RoleListComponent");
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.ScrollView = new GenericScrollViewNew<RoleListItem, RoleListItemData>(base.GetScrollViewWithScrollbar(0), new Func<RoleListItem>(this.InitRoleItem), null, false, null);
	}

	// Token: 0x06014097 RID: 82071 RVA: 0x00597E97 File Offset: 0x00596097
	private RoleListItem InitRoleItem()
	{
		return new RoleListItem
		{
			ToggleCallBack = new Action<int>(this.OnRoleItemToggleCallBack),
			CanToggleExecuteChange = new Func<int, bool>(this.CanToggleExecuteChange)
		};
	}

	// Token: 0x06014098 RID: 82072 RVA: 0x00597EC2 File Offset: 0x005960C2
	private bool CanToggleExecuteChange(int gridIndex)
	{
		return this.ScrollView.GetGenericLayout().GetSelectedGridIndex() != gridIndex && !Singleton<UiCameraAnimationManager>.Instance.IsPlayingAnimation();
	}

	// Token: 0x06014099 RID: 82073 RVA: 0x00597EE8 File Offset: 0x005960E8
	private void OnRoleItemToggleCallBack(int gridIndex)
	{
		this.ScrollView.GetGenericLayout().SelectGridProxy(gridIndex, false);
		this.RoleViewAgent.SetCurSelectRoleId(this.CurSelectDataId);
		RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
		ControllerBase<RoleController>.Instance.OnSelectedRoleChange(this.CurSelectDataId, curSelectRoleData.GetRoleSkinId());
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoleSystemChangeRole, this.CurSelectDataId);
	}

	// Token: 0x0601409A RID: 82074 RVA: 0x00597F50 File Offset: 0x00596150
	public void UnBindRedDot()
	{
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.RoleSystemRoleList);
	}

	// Token: 0x0601409B RID: 82075 RVA: 0x00597F5D File Offset: 0x0059615D
	public void SetRoleSystemUiParams(IRoleSystemUiParams roleSystemUiParams)
	{
		this.RoleSystemUiParams = roleSystemUiParams;
	}

	// Token: 0x0601409C RID: 82076 RVA: 0x00597F68 File Offset: 0x00596168
	public UniTask UpdateComponent(IReadOnlyList<int> roleList)
	{
		RoleListComponent.<UpdateComponent>d__15 <UpdateComponent>d__;
		<UpdateComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateComponent>d__.<>4__this = this;
		<UpdateComponent>d__.roleList = roleList;
		<UpdateComponent>d__.<>1__state = -1;
		<UpdateComponent>d__.<>t__builder.Start<RoleListComponent.<UpdateComponent>d__15>(ref <UpdateComponent>d__);
		return <UpdateComponent>d__.<>t__builder.Task;
	}

	// Token: 0x0601409D RID: 82077 RVA: 0x00597FB4 File Offset: 0x005961B4
	public void SetCurSelection(int dataId)
	{
		int num = this.DataList.IndexOf((RoleListItemData a) => a.RoleDataId == dataId);
		if (num < 0 || num >= this.DataList.Count)
		{
			return;
		}
		this.OnRoleItemToggleCallBack(num);
		UUIItem itemByIndex = this.ScrollView.GetItemByIndex(num);
		if (itemByIndex != null)
		{
			this.ScrollView.ScrollTo(itemByIndex, false);
		}
	}

	// Token: 0x04009C25 RID: 39973
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericScrollViewNew<RoleListItem, RoleListItemData> ScrollView;

	// Token: 0x04009C26 RID: 39974
	[Nullable(2)]
	protected RoleViewAgent RoleViewAgent;

	// Token: 0x04009C27 RID: 39975
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected List<RoleListItemData> DataList;

	// Token: 0x04009C28 RID: 39976
	[Nullable(2)]
	protected IRoleSystemUiParams RoleSystemUiParams;

	// Token: 0x02008B5D RID: 35677
	[NullableContext(0)]
	private enum ERoleListComponentDefine
	{
		// Token: 0x0402EFB2 RID: 192434
		ScrollViewWithScrollbar
	}
}
