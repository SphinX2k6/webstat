using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BFE RID: 11262
public class TowerResetView : UiViewBase
{
	// Token: 0x06016793 RID: 92051 RVA: 0x0063F0D3 File Offset: 0x0063D2D3
	[NullableContext(1)]
	public TowerResetView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06016794 RID: 92052 RVA: 0x0063F0E4 File Offset: 0x0063D2E4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickCancelButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickConfirmButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06016795 RID: 92053 RVA: 0x0063F210 File Offset: 0x0063D410
	protected override void OnStart()
	{
		this.InitView();
	}

	// Token: 0x06016796 RID: 92054 RVA: 0x0063F218 File Offset: 0x0063D418
	protected override void OnBeforeDestroy()
	{
		this.RoleLayout = null;
	}

	// Token: 0x06016797 RID: 92055 RVA: 0x0063F224 File Offset: 0x0063D424
	private void InitView()
	{
		this.TowerId = (int)this.OpenParam;
		TowerFloorInfo floorData = ModelBase<TowerModel>.Instance.GetFloorData(this.TowerId);
		if (floorData == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CycleTower;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "重置爬塔成绩时，无法获取到爬塔数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TowerId", this.TowerId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.RoleLayout = new GenericLayout<TowerResetItem, int>(base.GetVerticalLayout(0), new Func<TowerResetItem>(this.RefreshItem), null, false, true);
		List<int> list = new List<int>();
		foreach (TowerRolePb towerRolePb in floorData.Formation)
		{
			list.Add(towerRolePb.RoleId);
		}
		this.RoleLayout.RefreshByData(list, null, false);
		int difficultyStars = ModelBase<TowerModel>.Instance.GetDifficultyStars(floorData.Difficulties);
		base.GetText(1).SetText(difficultyStars.ToString(), true);
		base.GetText(2).SetText((difficultyStars - floorData.Star).ToString(), true);
	}

	// Token: 0x06016798 RID: 92056 RVA: 0x0063F350 File Offset: 0x0063D550
	[NullableContext(1)]
	private TowerResetItem RefreshItem()
	{
		return new TowerResetItem();
	}

	// Token: 0x06016799 RID: 92057 RVA: 0x0063F357 File Offset: 0x0063D557
	private void OnClickCancelButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x0601679A RID: 92058 RVA: 0x0063F360 File Offset: 0x0063D560
	private void OnClickConfirmButton()
	{
		ControllerBase<TowerController>.Instance.TowerResetRequest(this.TowerId);
		base.CloseMe(null);
	}

	// Token: 0x0400ADF2 RID: 44530
	private int TowerId = -1;

	// Token: 0x0400ADF3 RID: 44531
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerResetItem, int> RoleLayout;

	// Token: 0x02008EF8 RID: 36600
	private enum EChildType
	{
		// Token: 0x0403007D RID: 196733
		RoleLayout,
		// Token: 0x0403007E RID: 196734
		CurrentStarText,
		// Token: 0x0403007F RID: 196735
		ChangeToStarText,
		// Token: 0x04030080 RID: 196736
		CancelButton,
		// Token: 0x04030081 RID: 196737
		ConfirmButton
	}
}
