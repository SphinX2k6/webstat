using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001247 RID: 4679
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerTeamItem : UiPanelBase
{
	// Token: 0x06007CBD RID: 31933 RVA: 0x0020D4D4 File Offset: 0x0020B6D4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007CBE RID: 31934 RVA: 0x0020D620 File Offset: 0x0020B820
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerTeamItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerTeamItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007CBF RID: 31935 RVA: 0x0020D663 File Offset: 0x0020B863
	private void OnClickButton()
	{
		Action onClickBtnCallBack = this.OnClickBtnCallBack;
		if (onClickBtnCallBack == null)
		{
			return;
		}
		onClickBtnCallBack();
	}

	// Token: 0x06007CC0 RID: 31936 RVA: 0x0020D675 File Offset: 0x0020B875
	private BabelTowerTeamRoleItem CreateTeamRoleItem()
	{
		return new BabelTowerTeamRoleItem();
	}

	// Token: 0x06007CC1 RID: 31937 RVA: 0x0020D67C File Offset: 0x0020B87C
	public void RefreshItem(List<int> roleList, int instanceId)
	{
		GenericLayout<BabelTowerTeamRoleItem, int> teamLayout = this.TeamLayout;
		if (teamLayout != null)
		{
			teamLayout.RefreshByData(roleList, null, false);
		}
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		foreach (CommonElementItem commonElementItem in this.ElementItemArray)
		{
			commonElementItem.SetActive(false);
		}
		if (config != null)
		{
			InstanceDungeon valueOrDefault = config.GetValueOrDefault();
			for (int i = 0; i < valueOrDefault.RecommendElementLength; i++)
			{
				int num = valueOrDefault.RecommendElement(i);
				if (num != 0)
				{
					this.ElementItemArray[i].SetActive(true);
					this.ElementItemArray[i].Refresh(num, false, i);
				}
			}
		}
		int recommendLevel = ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(instanceId, ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "BossRushRecommendLevel", new <>z__ReadOnlySingleElementList<object>(recommendLevel));
	}

	// Token: 0x06007CC2 RID: 31938 RVA: 0x0020D784 File Offset: 0x0020B984
	public void RefreshSkillBranchIcon()
	{
		if (this.TeamLayout == null)
		{
			return;
		}
		foreach (BabelTowerTeamRoleItem babelTowerTeamRoleItem in this.TeamLayout.GetLayoutItemList())
		{
			babelTowerTeamRoleItem.RefreshSkillBranchIcon();
		}
	}

	// Token: 0x04003BA8 RID: 15272
	[Nullable(2)]
	private CommonElementItem ElementItem1;

	// Token: 0x04003BA9 RID: 15273
	[Nullable(2)]
	private CommonElementItem ElementItem2;

	// Token: 0x04003BAA RID: 15274
	private readonly List<CommonElementItem> ElementItemArray = new List<CommonElementItem>();

	// Token: 0x04003BAB RID: 15275
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<BabelTowerTeamRoleItem, int> TeamLayout;

	// Token: 0x04003BAC RID: 15276
	[Nullable(2)]
	public Action OnClickBtnCallBack;

	// Token: 0x020075BF RID: 30143
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x040289F0 RID: 166384
		public const int Button = 0;

		// Token: 0x040289F1 RID: 166385
		public const int RecommendLevelText = 1;

		// Token: 0x040289F2 RID: 166386
		public const int RecommendElementText = 2;

		// Token: 0x040289F3 RID: 166387
		public const int RecommendElementItem1 = 3;

		// Token: 0x040289F4 RID: 166388
		public const int RecommendElementItem2 = 4;

		// Token: 0x040289F5 RID: 166389
		public const int TeamHorizontalScrollView = 5;

		// Token: 0x040289F6 RID: 166390
		public const int TeamItem = 6;
	}
}
