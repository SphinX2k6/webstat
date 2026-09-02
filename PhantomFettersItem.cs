using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002492 RID: 9362
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhantomFettersItem : GridProxyAbstract<PhantomFetterItemData>
{
	// Token: 0x060122A5 RID: 74405 RVA: 0x004FF168 File Offset: 0x004FD368
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnItemButtonClicked))
		};
	}

	// Token: 0x060122A6 RID: 74406 RVA: 0x004FF228 File Offset: 0x004FD428
	protected override void OnStart()
	{
		this.VisionFetterSuitItem = new VisionFetterSuitItem(base.GetItem(2));
		this.VisionFetterSuitItem.Init().ContinueWith(delegate()
		{
			this.VisionFetterSuitItem.SetActive(true);
		}).Forget();
		base.GetItem(3).SetUIActive(false);
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060122A7 RID: 74407 RVA: 0x004FF286 File Offset: 0x004FD486
	public override void Refresh(PhantomFetterItemData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		this.RefreshName();
		this.RefreshSuitElement();
		this.RefreshUnlockText();
		this.RefreshLikeItemState();
		this.Selected(isSelected, false);
	}

	// Token: 0x060122A8 RID: 74408 RVA: 0x004FF2B0 File Offset: 0x004FD4B0
	private void RefreshLikeItemState()
	{
		int id = this.ItemData.PhantomFetterGroup.Value.Id;
		if (this.ItemData.RecommendGroupIds.Count > 0)
		{
			base.GetItem(5).SetUIActive(this.ItemData.RecommendGroupIds.Contains(id));
			return;
		}
		List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(this.ItemData.RoleId);
		bool uiactive = false;
		if (roleFetterRecommendInfo != null)
		{
			using (List<VisionFetterRecommendInfo>.Enumerator enumerator = roleFetterRecommendInfo.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetRecommendFetterGroupId() == id)
					{
						uiactive = true;
						break;
					}
				}
			}
		}
		base.GetItem(5).SetUIActive(uiactive);
	}

	// Token: 0x060122A9 RID: 74409 RVA: 0x004FF378 File Offset: 0x004FD578
	public void RefreshName()
	{
		base.GetText(1).ShowTextNew(this.ItemData.PhantomFetterGroup.Value.FetterGroupName);
	}

	// Token: 0x060122AA RID: 74410 RVA: 0x004FF3AC File Offset: 0x004FD5AC
	public void RefreshUnlockText()
	{
		int id = this.ItemData.PhantomFetterGroup.Value.Id;
		int[] fetterGroupMonsterIdArray = ModelBase<PhantomBattleModel>.Instance.GetFetterGroupMonsterIdArray(id);
		int monsterFindCountByMonsterIdArray = ModelBase<PhantomBattleModel>.Instance.GetMonsterFindCountByMonsterIdArray(fetterGroupMonsterIdArray);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Illustration_Progress_Iteration", new <>z__ReadOnlyArray<object>(new object[]
		{
			monsterFindCountByMonsterIdArray,
			fetterGroupMonsterIdArray.Length
		}));
	}

	// Token: 0x060122AB RID: 74411 RVA: 0x004FF41F File Offset: 0x004FD61F
	public void BindOnItemButtonClickedCallback(Action<PhantomFetterItemData> onItemButtonClicked)
	{
		this.OnItemButtonClickedCallback = onItemButtonClicked;
	}

	// Token: 0x060122AC RID: 74412 RVA: 0x004FF428 File Offset: 0x004FD628
	public override void OnSelected(bool fireEvent)
	{
		this.Selected(true, true);
	}

	// Token: 0x060122AD RID: 74413 RVA: 0x004FF432 File Offset: 0x004FD632
	public override void OnDeselected(bool fireEvent)
	{
		this.Selected(false, true);
	}

	// Token: 0x060122AE RID: 74414 RVA: 0x004FF43C File Offset: 0x004FD63C
	private void RefreshSuitElement()
	{
		this.VisionFetterSuitItem.Update(this.ItemData.PhantomFetterGroup);
	}

	// Token: 0x060122AF RID: 74415 RVA: 0x004FF454 File Offset: 0x004FD654
	private void Selected(bool bSelected, bool fire = true)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (bSelected)
		{
			extendToggle.SetToggleState(EToggleState.ETT_Checked, fire, false, false);
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060122B0 RID: 74416 RVA: 0x004FF483 File Offset: 0x004FD683
	private void OnItemButtonClicked(EToggleState state)
	{
		if (this.OnItemButtonClickedCallback != null)
		{
			this.OnItemButtonClickedCallback(this.ItemData);
		}
	}

	// Token: 0x04008DD0 RID: 36304
	[Nullable(2)]
	private PhantomFetterItemData ItemData;

	// Token: 0x04008DD1 RID: 36305
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x04008DD2 RID: 36306
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<PhantomFetterItemData> OnItemButtonClickedCallback;
}
