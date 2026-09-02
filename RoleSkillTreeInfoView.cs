using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi.RoleSkill;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028CC RID: 10444
public class RoleSkillTreeInfoView : UiViewBase
{
	// Token: 0x06014BC5 RID: 84933 RVA: 0x005BFB63 File Offset: 0x005BDD63
	[NullableContext(1)]
	public RoleSkillTreeInfoView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06014BC6 RID: 84934 RVA: 0x005BFB6C File Offset: 0x005BDD6C
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

	// Token: 0x06014BC7 RID: 84935 RVA: 0x005BFBB4 File Offset: 0x005BDDB4
	protected override UniTask OnBeforeStartAsync()
	{
		RoleSkillTreeInfoView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleSkillTreeInfoView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014BC8 RID: 84936 RVA: 0x005BFBF8 File Offset: 0x005BDDF8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleInternalViewQuit, new Action(this.OnRoleInternalViewQuit));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleSkillBranchChanged, new Action<int>(this.OnRoleSkillBranchChanged));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SkillTreeNodeLevelUp, new Action<int>(this.OnSkillTreeNodeLevelUp));
	}

	// Token: 0x06014BC9 RID: 84937 RVA: 0x005BFC78 File Offset: 0x005BDE78
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleInternalViewQuit, new Action(this.OnRoleInternalViewQuit));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRoleSkillBranchChanged, new Action<int>(this.OnRoleSkillBranchChanged));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.SkillTreeNodeLevelUp, new Action<int>(this.OnSkillTreeNodeLevelUp));
	}

	// Token: 0x06014BCA RID: 84938 RVA: 0x005BFCF5 File Offset: 0x005BDEF5
	protected override void OnBeforeShow()
	{
		this.Refresh();
	}

	// Token: 0x06014BCB RID: 84939 RVA: 0x005BFD00 File Offset: 0x005BDF00
	protected override UniTask OnPlayingStartSequenceAsync()
	{
		RoleSkillTreeInfoView.<OnPlayingStartSequenceAsync>d__8 <OnPlayingStartSequenceAsync>d__;
		<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingStartSequenceAsync>d__.<>4__this = this;
		<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
		<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<RoleSkillTreeInfoView.<OnPlayingStartSequenceAsync>d__8>(ref <OnPlayingStartSequenceAsync>d__);
		return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014BCC RID: 84940 RVA: 0x005BFD44 File Offset: 0x005BDF44
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		RoleSkillTreeInfoView.<OnPlayingCloseSequenceAsync>d__9 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<RoleSkillTreeInfoView.<OnPlayingCloseSequenceAsync>d__9>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014BCD RID: 84941 RVA: 0x005BFD88 File Offset: 0x005BDF88
	public void Refresh()
	{
		IRoleSkillTreeInfoItemData data = this.OpenParam as IRoleSkillTreeInfoItemData;
		RoleSkillTreeInfoItem roleSkillTreeInfoItem = this.RoleSkillTreeInfoItem;
		if (roleSkillTreeInfoItem != null)
		{
			roleSkillTreeInfoItem.Update(data);
		}
		RoleSkillTreeInfoItem roleSkillTreeInfoItem2 = this.RoleSkillTreeInfoItem;
		if (roleSkillTreeInfoItem2 == null)
		{
			return;
		}
		roleSkillTreeInfoItem2.ShowLeftPanelByTabType(this.RoleSkillTreeInfoItem.GetCurSkillTabShowType());
	}

	// Token: 0x06014BCE RID: 84942 RVA: 0x005BFDCE File Offset: 0x005BDFCE
	private void OnCommonItemCountAnyChange(int i, int i1)
	{
		RoleSkillTreeInfoItem roleSkillTreeInfoItem = this.RoleSkillTreeInfoItem;
		if (roleSkillTreeInfoItem == null)
		{
			return;
		}
		roleSkillTreeInfoItem.OnCommonItemCountAnyChange();
	}

	// Token: 0x06014BCF RID: 84943 RVA: 0x005BFDE0 File Offset: 0x005BDFE0
	private void OnRoleInternalViewQuit()
	{
		base.CloseMe(null);
	}

	// Token: 0x06014BD0 RID: 84944 RVA: 0x005BFDE9 File Offset: 0x005BDFE9
	private void OnRoleSkillBranchChanged(int i)
	{
		RoleSkillTreeInfoItem roleSkillTreeInfoItem = this.RoleSkillTreeInfoItem;
		if (roleSkillTreeInfoItem == null)
		{
			return;
		}
		roleSkillTreeInfoItem.OnRoleSkillBranchChanged();
	}

	// Token: 0x06014BD1 RID: 84945 RVA: 0x005BFDFB File Offset: 0x005BDFFB
	private void OnSkillTreeNodeLevelUp(int i)
	{
		RoleSkillTreeInfoItem roleSkillTreeInfoItem = this.RoleSkillTreeInfoItem;
		if (roleSkillTreeInfoItem == null)
		{
			return;
		}
		roleSkillTreeInfoItem.OnSkillTreeNodeLevelUp();
	}

	// Token: 0x04009FDA RID: 40922
	[Nullable(2)]
	private RoleSkillTreeInfoItem RoleSkillTreeInfoItem;

	// Token: 0x02008C1C RID: 35868
	private enum EComponent
	{
		// Token: 0x0402F347 RID: 193351
		RoleSkillTreeInfoItem
	}
}
