using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020014E9 RID: 5353
[NullableContext(1)]
[Nullable(0)]
public class ActivityRegressAdventureView : ActivityRegressMainSubViewBase
{
	// Token: 0x060095D8 RID: 38360 RVA: 0x002713F8 File Offset: 0x0026F5F8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x060095D9 RID: 38361 RVA: 0x002714AC File Offset: 0x0026F6AC
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressAdventureView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressAdventureView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060095DA RID: 38362 RVA: 0x002714E8 File Offset: 0x0026F6E8
	protected override void OnStart()
	{
		base.OnStart();
		this.RoleLayout = new GenericLayout<ActivityRegressAdventureRoleItem, int>(base.GetHorizontalLayout(0), new Func<ActivityRegressAdventureRoleItem>(this.InitRoleItem), null, false, true);
		this.AdventureLayout = new GenericLayout<ActivityRegressAdventureAdventureItem, int>(base.GetVerticalLayout(2), new Func<ActivityRegressAdventureAdventureItem>(this.InitAdventureItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, true);
		this.AdventureLayout2 = new GenericLayout<ActivityRegressAdventureAdventureItem, int>(base.GetVerticalLayout(4), new Func<ActivityRegressAdventureAdventureItem>(this.InitAdventureItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, true);
		this.RefreshRolePanelState();
	}

	// Token: 0x060095DB RID: 38363 RVA: 0x00271584 File Offset: 0x0026F784
	private void RefreshRolePanelState()
	{
		List<int> roleList = ModelBase<ActivityRegressModel>.Instance.GetGachaPoolUpRole();
		bool flag = roleList.Count > 0;
		base.GetItem(5).SetUIActive(flag);
		base.GetItem(6).SetUIActive(!flag);
		if (!flag)
		{
			this.CurrentSelectRoleId = 0;
			this.CurrentSelectToggle = null;
			GenericLayout<ActivityRegressAdventureAdventureItem, int> adventureLayout = this.AdventureLayout;
			if (adventureLayout != null)
			{
				adventureLayout.RefreshByData(new List<int>(), null, true);
			}
			GenericLayout<ActivityRegressAdventureAdventureItem, int> adventureLayout2 = this.AdventureLayout2;
			if (adventureLayout2 == null)
			{
				return;
			}
			adventureLayout2.RefreshByData(new List<int>(), null, true);
			return;
		}
		else
		{
			GenericLayout<ActivityRegressAdventureRoleItem, int> roleLayout = this.RoleLayout;
			if (roleLayout == null)
			{
				return;
			}
			roleLayout.RefreshByData(roleList, delegate
			{
				int num = (this.CurrentSelectRoleId != 0) ? roleList.IndexOf(this.CurrentSelectRoleId) : 0;
				GenericLayout<ActivityRegressAdventureRoleItem, int> roleLayout2 = this.RoleLayout;
				if (roleLayout2 == null)
				{
					return;
				}
				ActivityRegressAdventureRoleItem layoutItemByIndex = roleLayout2.GetLayoutItemByIndex((num >= 0) ? num : 0);
				if (layoutItemByIndex == null)
				{
					return;
				}
				layoutItemByIndex.SelectToggle();
			}, false);
			return;
		}
	}

	// Token: 0x060095DC RID: 38364 RVA: 0x0027163E File Offset: 0x0026F83E
	private ActivityRegressAdventureRoleItem InitRoleItem()
	{
		return new ActivityRegressAdventureRoleItem
		{
			OnClickToggleCallBack = new Action<int, UUIExtendToggle>(this.OnClickRoleToggleCallBack)
		};
	}

	// Token: 0x060095DD RID: 38365 RVA: 0x00271657 File Offset: 0x0026F857
	private ActivityRegressAdventureAdventureItem InitAdventureItem()
	{
		return new ActivityRegressAdventureAdventureItem
		{
			OnClickJumpToCallBack = new Action(this.RefreshRolePanelState)
		};
	}

	// Token: 0x060095DE RID: 38366 RVA: 0x00271670 File Offset: 0x0026F870
	private void OnClickRoleToggleCallBack(int roleId, UUIExtendToggle toggle)
	{
		this.RefreshRolePanelState();
		if (this.CurrentSelectRoleId == roleId)
		{
			return;
		}
		this.CurrentSelectRoleId = roleId;
		UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
		if (currentSelectToggle != null)
		{
			currentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		IReadOnlyList<GachaRoleDevelopIns> gachaRoleDevelopInsByRoleId = ConfigBase<ActivityRegressConfig>.Instance.GetGachaRoleDevelopInsByRoleId(roleId);
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		if (gachaRoleDevelopInsByRoleId != null)
		{
			for (int i = 0; i < gachaRoleDevelopInsByRoleId.Count; i++)
			{
				GachaRoleDevelopIns gachaRoleDevelopIns = gachaRoleDevelopInsByRoleId[i];
				if (gachaRoleDevelopIns.Type == 1)
				{
					list.Add(gachaRoleDevelopIns.Id);
				}
				if (gachaRoleDevelopIns.Type == 2)
				{
					list2.Add(gachaRoleDevelopIns.Id);
				}
			}
		}
		GenericLayout<ActivityRegressAdventureAdventureItem, int> adventureLayout = this.AdventureLayout;
		if (adventureLayout != null)
		{
			adventureLayout.RefreshByData(list, null, true);
		}
		GenericLayout<ActivityRegressAdventureAdventureItem, int> adventureLayout2 = this.AdventureLayout2;
		if (adventureLayout2 == null)
		{
			return;
		}
		adventureLayout2.RefreshByData(list2, null, true);
	}

	// Token: 0x04004555 RID: 17749
	private int CurrentSelectRoleId;

	// Token: 0x04004556 RID: 17750
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x04004557 RID: 17751
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<ActivityRegressAdventureRoleItem, int> RoleLayout;

	// Token: 0x04004558 RID: 17752
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<ActivityRegressAdventureAdventureItem, int> AdventureLayout;

	// Token: 0x04004559 RID: 17753
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<ActivityRegressAdventureAdventureItem, int> AdventureLayout2;

	// Token: 0x020078A5 RID: 30885
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040297A2 RID: 169890
		public const int RoleLayout = 0;

		// Token: 0x040297A3 RID: 169891
		public const int RoleItem = 1;

		// Token: 0x040297A4 RID: 169892
		public const int AdventureItemLayout = 2;

		// Token: 0x040297A5 RID: 169893
		public const int AdventureItem = 3;

		// Token: 0x040297A6 RID: 169894
		public const int AdventureItemLayout2 = 4;

		// Token: 0x040297A7 RID: 169895
		public const int RoleLayoutItem = 5;

		// Token: 0x040297A8 RID: 169896
		public const int LockTipsItem = 6;
	}
}
