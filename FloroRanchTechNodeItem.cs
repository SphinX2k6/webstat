using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C71 RID: 7281
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchTechNodeItem : UiPanelBase
{
	// Token: 0x0600D485 RID: 54405 RVA: 0x0038B770 File Offset: 0x00389970
	public FloroRanchTechNodeItem(UUIItem parent, FloroRanchTechnologyData data, UUIItem gridPanelItem)
	{
		this.Data = data2;
		this.PreItem = parent;
		this.GridPanelItem = gridPanelItem;
	}

	// Token: 0x0600D486 RID: 54406 RVA: 0x0038B7C8 File Offset: 0x003899C8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D487 RID: 54407 RVA: 0x0038B9BD File Offset: 0x00389BBD
	protected override void OnStart()
	{
		base.GetExtendToggle(10).bLockStateOnSelect = true;
	}

	// Token: 0x0600D488 RID: 54408 RVA: 0x0038B9D0 File Offset: 0x00389BD0
	[NullableContext(2)]
	public void Refresh(FloroRanchTechnologyData data = null)
	{
		FloroRanchTechNodeItem.<>c__DisplayClass9_0 CS$<>8__locals1 = new FloroRanchTechNodeItem.<>c__DisplayClass9_0();
		CS$<>8__locals1.<>4__this = this;
		this.Data = (data ?? this.Data);
		FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
		int[] array = this.Data.PreNode ?? Array.Empty<int>();
		CS$<>8__locals1.i = 0;
		while (CS$<>8__locals1.i < array.Length)
		{
			int offset = activityData.GetFloroRanchTechnologyData(array[CS$<>8__locals1.i]).Row - this.Data.Row;
			UUIItem prePosItem = this.GetPrePosItem(offset);
			if (this.LineComponentList.Count <= CS$<>8__locals1.i || this.LineComponentList[CS$<>8__locals1.i] == null)
			{
				UniTask<AActor> task = Singleton<LguiUtil>.Instance.LoadPrefabByResourceIdAsync("UiItem_PastureSkillLine", prePosItem, null, ResourceSystem.EResourceLoadPriority.Default, "js_undefined");
				Func<AActor, UniTask> continuationFunction;
				if ((continuationFunction = CS$<>8__locals1.<>9__0) == null)
				{
					continuationFunction = (CS$<>8__locals1.<>9__0 = delegate(AActor prefab)
					{
						FloroRanchTechNodeItem.<>c__DisplayClass9_0.<<Refresh>b__0>d <<Refresh>b__0>d;
						<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
						<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
						<<Refresh>b__0>d.prefab = prefab;
						<<Refresh>b__0>d.<>1__state = -1;
						<<Refresh>b__0>d.<>t__builder.Start<FloroRanchTechNodeItem.<>c__DisplayClass9_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
						return <<Refresh>b__0>d.<>t__builder.Task;
					});
				}
				task.ContinueWith(continuationFunction);
			}
			else
			{
				this.LineComponentList[CS$<>8__locals1.i].Refresh(this.Data.IsUnLock);
			}
			int i = CS$<>8__locals1.i;
			CS$<>8__locals1.i = i + 1;
		}
		bool flag = activityData.GetTechnologyCoinNum() >= this.Data.Cost;
		bool flag2 = activityData.IsPreNodeAllUnlock(this.Data);
		this.SetSpriteByPath(this.Data.Icon, base.GetSprite(8), false, null, null);
		this.SetSpriteByPath(this.Data.Icon, base.GetSprite(11), false, null, null);
		base.GetSprite(11).SetUIActive(!this.Data.IsUnLock);
		base.GetSprite(8).SetUIActive(this.Data.IsUnLock);
		base.GetSprite(6).SetUIActive(!this.Data.IsUnLock);
		base.GetSprite(7).SetUIActive(this.Data.IsUnLock);
		base.GetSprite(9).SetUIActive(!this.Data.IsUnLock && flag && flag2);
		if (activityData.GetNextCanUnlockTechId() == this.Data.Id)
		{
			FloroRanchTechnologyView floroRanchTechnologyView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.FloroRanchTechnologyView) as FloroRanchTechnologyView;
			if (floroRanchTechnologyView != null && (floroRanchTechnologyView.IsShowOrShowing || floroRanchTechnologyView.IsStartOrStarting))
			{
				floroRanchTechnologyView.TrySelectTechNode(this);
			}
		}
	}

	// Token: 0x0600D489 RID: 54409 RVA: 0x0038BC35 File Offset: 0x00389E35
	public UUIItem GetPrePosItem(int offset)
	{
		if (offset > 0)
		{
			return base.GetItem(2);
		}
		if (offset < 0)
		{
			return base.GetItem(0);
		}
		return base.GetItem(1);
	}

	// Token: 0x0600D48A RID: 54410 RVA: 0x0038BC56 File Offset: 0x00389E56
	private void OnToggleClick(EToggleState _)
	{
		Action<FloroRanchTechNodeItem> onClickCallback = this.OnClickCallback;
		if (onClickCallback == null)
		{
			return;
		}
		onClickCallback(this);
	}

	// Token: 0x0600D48B RID: 54411 RVA: 0x0038BC69 File Offset: 0x00389E69
	public void SetToggleState(EToggleState state)
	{
		base.GetExtendToggle(10).SetToggleState(state, false, false, false);
	}

	// Token: 0x04006519 RID: 25881
	[Nullable(2)]
	public FloroRanchTechnologyData Data;

	// Token: 0x0400651A RID: 25882
	[Nullable(2)]
	public UUIItem PreItem;

	// Token: 0x0400651B RID: 25883
	private List<FloroRanchTechLine> LineComponentList = new List<FloroRanchTechLine>();

	// Token: 0x0400651C RID: 25884
	[Nullable(2)]
	public UUIItem GridPanelItem;

	// Token: 0x0400651D RID: 25885
	public Action<FloroRanchTechNodeItem> OnClickCallback = delegate(FloroRanchTechNodeItem data)
	{
	};

	// Token: 0x02007F9D RID: 32669
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B71C RID: 177948
		public const int PrePos1 = 0;

		// Token: 0x0402B71D RID: 177949
		public const int PrePos2 = 1;

		// Token: 0x0402B71E RID: 177950
		public const int PrePos3 = 2;

		// Token: 0x0402B71F RID: 177951
		public const int OutPos1 = 3;

		// Token: 0x0402B720 RID: 177952
		public const int OutPos2 = 4;

		// Token: 0x0402B721 RID: 177953
		public const int OutPos3 = 5;

		// Token: 0x0402B722 RID: 177954
		public const int SpriteLock = 6;

		// Token: 0x0402B723 RID: 177955
		public const int SpriteUnlock = 7;

		// Token: 0x0402B724 RID: 177956
		public const int SpriteIcon = 8;

		// Token: 0x0402B725 RID: 177957
		public const int SpriteUp = 9;

		// Token: 0x0402B726 RID: 177958
		public const int Toggle = 10;

		// Token: 0x0402B727 RID: 177959
		public const int SpriteIconLock = 11;
	}
}
