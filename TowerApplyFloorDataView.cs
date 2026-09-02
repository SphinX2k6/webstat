using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002BE6 RID: 11238
public class TowerApplyFloorDataView : UiViewBase
{
	// Token: 0x060166DE RID: 91870 RVA: 0x0063A92C File Offset: 0x00638B2C
	[NullableContext(1)]
	public TowerApplyFloorDataView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060166DF RID: 91871 RVA: 0x0063A938 File Offset: 0x00638B38
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickCancelButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickConfirmButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060166E0 RID: 91872 RVA: 0x0063AB0B File Offset: 0x00638D0B
	protected override void OnStart()
	{
		this.InitView();
	}

	// Token: 0x060166E1 RID: 91873 RVA: 0x0063AB14 File Offset: 0x00638D14
	private void InitView()
	{
		TowerFloorInfo currentNotConfirmedFloor = ModelBase<TowerModel>.Instance.CurrentNotConfirmedFloor;
		if (currentNotConfirmedFloor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.CycleTower, ELogAuthor.LJQ, "打开爬塔成绩确认框时失败，未能获取到新挑战数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		TowerFloorInfo floorData = ModelBase<TowerModel>.Instance.GetFloorData(currentNotConfirmedFloor.TowerId);
		UUIItem item = base.GetItem(8);
		UUIItem item2 = base.GetItem(5);
		for (int i = 0; i < currentNotConfirmedFloor.Star; i++)
		{
			Singleton<LguiUtil>.Instance.DuplicateActor(item.GetOwner(), item2);
		}
		UUIItem item3 = base.GetItem(3);
		for (int j = 0; j < floorData.Star; j++)
		{
			Singleton<LguiUtil>.Instance.DuplicateActor(item.GetOwner(), item3);
		}
		item.SetUIActive(false);
		UUIItem item4 = base.GetItem(9);
		UUIItem item5 = base.GetItem(4);
		List<int> list = new List<int>();
		foreach (TowerRolePb towerRolePb in currentNotConfirmedFloor.Formation)
		{
			list.Add(towerRolePb.RoleId);
		}
		using (List<int>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				int role = enumerator2.Current;
				UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(item4, item5);
				TowerRoleComplexItem newRole = new TowerRoleComplexItem();
				newRole.CreateThenShowByActorAsync(uuiitem.GetOwner(), null, false).ContinueWith(delegate()
				{
					newRole.RefreshRoleId(role);
				});
			}
		}
		UUIItem item6 = base.GetItem(2);
		List<int> list2 = new List<int>();
		foreach (TowerRolePb towerRolePb2 in floorData.Formation)
		{
			list2.Add(towerRolePb2.RoleId);
		}
		using (List<int>.Enumerator enumerator2 = list2.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				int role = enumerator2.Current;
				UUIItem uuiitem2 = Singleton<LguiUtil>.Instance.CopyItem(item4, item6);
				TowerRoleComplexItem newRole = new TowerRoleComplexItem();
				newRole.CreateThenShowByActorAsync(uuiitem2.GetOwner(), null, false).ContinueWith(delegate()
				{
					newRole.RefreshRoleId(role);
				});
			}
		}
		item4.SetUIActive(false);
		string textStringId = "";
		if (currentNotConfirmedFloor.Difficulties == 1)
		{
			textStringId = "Text_LowRiskAreaFloor_Text";
		}
		else if (currentNotConfirmedFloor.Difficulties == 2)
		{
			textStringId = "Text_HighRiskAreaFloor_Text";
		}
		else if (currentNotConfirmedFloor.Difficulties == 3)
		{
			textStringId = "Text_VariationAreaFloor_Text";
		}
		else if (currentNotConfirmedFloor.Difficulties == 4)
		{
			textStringId = "Text_OverLockAreaFloor_Text";
		}
		string towerAreaName = ConfigBase<TowerClimbConfig>.Instance.GetTowerAreaName(currentNotConfirmedFloor.TowerId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, new <>z__ReadOnlyArray<object>(new object[]
		{
			towerAreaName,
			currentNotConfirmedFloor.FloorNumber
		}));
	}

	// Token: 0x060166E2 RID: 91874 RVA: 0x0063AE40 File Offset: 0x00639040
	protected override void OnBeforeDestroy()
	{
		ModelBase<TowerModel>.Instance.ClearNotConfirmedData();
	}

	// Token: 0x060166E3 RID: 91875 RVA: 0x0063AE4C File Offset: 0x0063904C
	private void OnClickCancelButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x060166E4 RID: 91876 RVA: 0x0063AE55 File Offset: 0x00639055
	private void OnClickConfirmButton()
	{
		ControllerBase<TowerController>.Instance.TowerApplyFloorDataRequest(true);
		base.CloseMe(null);
	}

	// Token: 0x02008EDA RID: 36570
	private enum EChildType
	{
		// Token: 0x0402FFD3 RID: 196563
		TitleText,
		// Token: 0x0402FFD4 RID: 196564
		DescriptionText,
		// Token: 0x0402FFD5 RID: 196565
		OldRoleItem,
		// Token: 0x0402FFD6 RID: 196566
		OldStarRootItem,
		// Token: 0x0402FFD7 RID: 196567
		NewRoleItem,
		// Token: 0x0402FFD8 RID: 196568
		NewStarRootItem,
		// Token: 0x0402FFD9 RID: 196569
		CancelButton,
		// Token: 0x0402FFDA RID: 196570
		ConfirmButton,
		// Token: 0x0402FFDB RID: 196571
		StarItem,
		// Token: 0x0402FFDC RID: 196572
		RoleItem
	}
}
