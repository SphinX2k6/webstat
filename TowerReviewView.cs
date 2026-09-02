using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C00 RID: 11264
public class TowerReviewView : UiViewBase
{
	// Token: 0x0601679E RID: 92062 RVA: 0x0063F45C File Offset: 0x0063D65C
	[NullableContext(1)]
	public TowerReviewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601679F RID: 92063 RVA: 0x0063F468 File Offset: 0x0063D668
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060167A0 RID: 92064 RVA: 0x0063F514 File Offset: 0x0063D714
	protected override UniTask OnBeforeStartAsync()
	{
		TowerReviewView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TowerReviewView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060167A1 RID: 92065 RVA: 0x0063F557 File Offset: 0x0063D757
	protected override void OnStart()
	{
		this.AreaLayout = new GenericLayout<TowerReviewItem, int>(base.GetVerticalLayout(1), new Func<TowerReviewItem>(this.RefreshItem), null, false, true);
		this.RefreshView();
	}

	// Token: 0x060167A2 RID: 92066 RVA: 0x0063F580 File Offset: 0x0063D780
	protected override void OnBeforeDestroy()
	{
		this.AreaLayout = null;
		if (this.HasQuickPass)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnTowerReviewGoToReward);
		}
	}

	// Token: 0x060167A3 RID: 92067 RVA: 0x0063F5A4 File Offset: 0x0063D7A4
	private void RefreshView()
	{
		int difficulty = 3;
		int[] difficultyAllAreaFirstFloor = ModelBase<TowerModel>.Instance.GetDifficultyAllAreaFirstFloor(difficulty, true);
		if (difficultyAllAreaFirstFloor == null)
		{
			return;
		}
		this.AreaLayout.RefreshByData(difficultyAllAreaFirstFloor.ToList<int>(), null, false);
		base.GetText(2).SetText(ModelBase<TowerModel>.Instance.GetDifficultyMaxStars(difficulty, true).ToString() + "/" + ModelBase<TowerModel>.Instance.GetDifficultyAllStars(difficulty, true).ToString(), true);
		this.HasQuickPass = false;
		foreach (int floorId in ModelBase<TowerModel>.Instance.GetDifficultyAllFloor(difficulty))
		{
			TowerFloorInfo floorData = ModelBase<TowerModel>.Instance.GetFloorData(floorId);
			if (floorData != null && floorData.IsQuickPass)
			{
				this.HasQuickPass = true;
				break;
			}
		}
		base.GetText(3).SetUIActive(this.HasQuickPass);
		if (this.HasQuickPass)
		{
			int quickPassId = ModelBase<TowerModel>.Instance.QuickPassId;
			TowerQuickPass? config = ConfigTowerQuickPassById.GetConfig(quickPassId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CycleTower;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "TowerReviewView: QuickPass config not found";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("QuickPassId", quickPassId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), config.Value.TipText, Array.Empty<object>());
			}
		}
		string textId = this.HasQuickPass ? "CycleTowerReward" : "CycleTowerConfirm";
		this.ConfirmBtnItem.SetLocalTextNew(textId, Array.Empty<object>());
	}

	// Token: 0x060167A4 RID: 92068 RVA: 0x0063F721 File Offset: 0x0063D921
	[NullableContext(1)]
	private TowerReviewItem RefreshItem()
	{
		return new TowerReviewItem();
	}

	// Token: 0x060167A5 RID: 92069 RVA: 0x0063F728 File Offset: 0x0063D928
	private void OnClickConfirmBtn(int _)
	{
		ModelBase<TowerModel>.Instance.ClearHandleData();
		base.CloseMe(null);
	}

	// Token: 0x0400ADF4 RID: 44532
	[Nullable(2)]
	private ButtonItem ConfirmBtnItem;

	// Token: 0x0400ADF5 RID: 44533
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerReviewItem, int> AreaLayout;

	// Token: 0x0400ADF6 RID: 44534
	private bool HasQuickPass;

	// Token: 0x02008EFA RID: 36602
	private enum EChildType
	{
		// Token: 0x04030086 RID: 196742
		ConfirmBtnItem,
		// Token: 0x04030087 RID: 196743
		ScrollView,
		// Token: 0x04030088 RID: 196744
		ReceivedStarText,
		// Token: 0x04030089 RID: 196745
		QuickPassTipText
	}
}
