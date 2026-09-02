using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200120B RID: 4619
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BabelTowerDeTermSelectItem : GridProxyAbstract<IBabelTowerDeTermSelectItemInfo>
{
	// Token: 0x06007A34 RID: 31284 RVA: 0x001FD44C File Offset: 0x001FB64C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007A35 RID: 31285 RVA: 0x001FD4F7 File Offset: 0x001FB6F7
	protected override void OnStart()
	{
		this.DeTermLayout = new GenericLayout<DeTermItem, int>(base.GetGridLayout(2), new Func<DeTermItem>(this.InitItem), null, false, true);
	}

	// Token: 0x06007A36 RID: 31286 RVA: 0x001FD51C File Offset: 0x001FB71C
	[NullableContext(1)]
	public override void Refresh(IBabelTowerDeTermSelectItemInfo data, bool isSelected, int gridIndex)
	{
		this.IsNecessary = data.IsNecessary;
		base.GetItem(1).SetUIActive(data.IsNecessary);
		this.OnChangeSelectDeTerm = data.OnChangeSelectDeTerm;
		GenericLayout<DeTermItem, int> deTermLayout = this.DeTermLayout;
		if (deTermLayout == null)
		{
			return;
		}
		deTermLayout.RefreshByData(data.AllDeTerm, delegate
		{
			foreach (DeTermItem deTermItem in this.DeTermLayout.GetLayoutItemList())
			{
				IBabelTowerSelectInfo babelTowerSelectInfo;
				ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo.TryGetValue(deTermItem.DeTermId, out babelTowerSelectInfo);
				if (babelTowerSelectInfo != null && babelTowerSelectInfo.State == EBabelTowerDeTermState.Lock)
				{
					deTermItem.SetToggleState(EToggleState.ETT_UnDetermined);
				}
				if ((babelTowerSelectInfo != null && babelTowerSelectInfo.State == EBabelTowerDeTermState.Select) || (babelTowerSelectInfo != null && babelTowerSelectInfo.State == EBabelTowerDeTermState.StaticSelect))
				{
					this.CurrentDeTermId = deTermItem.DeTermId;
					this.CurrentToggle = deTermItem.GetDeTermToggle();
					deTermItem.SetToggleState(EToggleState.ETT_Checked);
				}
				if (babelTowerSelectInfo != null && babelTowerSelectInfo.State == EBabelTowerDeTermState.Normal)
				{
					deTermItem.SetToggleState(EToggleState.ETT_UnChecked);
				}
				deTermItem.SetDailyQuestItem(deTermItem.DeTermId != 0 && data.DailyDeTerm.Contains(deTermItem.DeTermId));
			}
			if (this.CurrentToggle != null)
			{
				this.RefreshItemColor();
			}
		}, false);
	}

	// Token: 0x06007A37 RID: 31287 RVA: 0x001FD59E File Offset: 0x001FB79E
	[NullableContext(1)]
	private DeTermItem InitItem()
	{
		return new DeTermItem
		{
			OnClickToggleCallBack = new Action<int, UUIExtendToggle>(this.OnClickToggleCallBack),
			CanClickCallBack = new Func<bool>(this.CanClickCallBack)
		};
	}

	// Token: 0x06007A38 RID: 31288 RVA: 0x001FD5CC File Offset: 0x001FB7CC
	private void OnClickToggleCallBack(int deTerm, UUIExtendToggle toggle)
	{
		UUIExtendToggle currentToggle = this.CurrentToggle;
		if (currentToggle != null)
		{
			currentToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentToggle = toggle;
		if (deTerm == 0)
		{
			BabelTowerSelectInfo babelTowerSelectInfo = new BabelTowerSelectInfo();
			babelTowerSelectInfo.State = EBabelTowerDeTermState.Normal;
			BabelTowerModel instance = ModelBase<BabelTowerModel>.Instance;
			int deTermSelectIndex = instance.DeTermSelectIndex;
			instance.DeTermSelectIndex = deTermSelectIndex + 1;
			babelTowerSelectInfo.SelectIndex = deTermSelectIndex;
			BabelTowerSelectInfo value = babelTowerSelectInfo;
			ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[this.CurrentDeTermId] = value;
		}
		else
		{
			BabelTowerSelectInfo babelTowerSelectInfo2 = new BabelTowerSelectInfo();
			babelTowerSelectInfo2.State = EBabelTowerDeTermState.Normal;
			BabelTowerModel instance2 = ModelBase<BabelTowerModel>.Instance;
			int deTermSelectIndex = instance2.DeTermSelectIndex;
			instance2.DeTermSelectIndex = deTermSelectIndex + 1;
			babelTowerSelectInfo2.SelectIndex = deTermSelectIndex;
			BabelTowerSelectInfo value2 = babelTowerSelectInfo2;
			ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[this.CurrentDeTermId] = value2;
			BabelTowerSelectInfo babelTowerSelectInfo3 = new BabelTowerSelectInfo();
			babelTowerSelectInfo3.State = EBabelTowerDeTermState.Select;
			BabelTowerModel instance3 = ModelBase<BabelTowerModel>.Instance;
			deTermSelectIndex = instance3.DeTermSelectIndex;
			instance3.DeTermSelectIndex = deTermSelectIndex + 1;
			babelTowerSelectInfo3.SelectIndex = deTermSelectIndex;
			BabelTowerSelectInfo value3 = babelTowerSelectInfo3;
			ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[deTerm] = value3;
		}
		this.RefreshItemColor();
		this.CurrentDeTermId = deTerm;
		Action<int> onChangeSelectDeTerm = this.OnChangeSelectDeTerm;
		if (onChangeSelectDeTerm == null)
		{
			return;
		}
		onChangeSelectDeTerm(deTerm);
	}

	// Token: 0x06007A39 RID: 31289 RVA: 0x001FD6CE File Offset: 0x001FB8CE
	private bool CanClickCallBack()
	{
		bool flag = !this.IsNecessary;
		if (!flag)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerNecessaryDeTerm", Array.Empty<object>());
		}
		return flag;
	}

	// Token: 0x06007A3A RID: 31290 RVA: 0x001FD6F0 File Offset: 0x001FB8F0
	public void PlayPositionSequence(int deTerm)
	{
		foreach (DeTermItem deTermItem in this.DeTermLayout.GetLayoutItemList())
		{
			if (deTermItem.DeTermId == deTerm)
			{
				deTermItem.PlayPositionSequence();
			}
		}
	}

	// Token: 0x06007A3B RID: 31291 RVA: 0x001FD750 File Offset: 0x001FB950
	private void RefreshItemColor()
	{
		foreach (DeTermItem deTermItem in this.DeTermLayout.GetLayoutItemList())
		{
			IBabelTowerSelectInfo babelTowerSelectInfo;
			ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo.TryGetValue(deTermItem.DeTermId, out babelTowerSelectInfo);
			deTermItem.UseChangeColor(babelTowerSelectInfo != null && babelTowerSelectInfo.State == EBabelTowerDeTermState.Normal && this.CurrentToggle != null);
		}
	}

	// Token: 0x06007A3C RID: 31292 RVA: 0x001FD7D8 File Offset: 0x001FB9D8
	public void ClearSelect()
	{
		this.CurrentToggle = null;
		this.CurrentDeTermId = 0;
		this.RefreshItemColor();
	}

	// Token: 0x04003AB6 RID: 15030
	private Action<int> OnChangeSelectDeTerm;

	// Token: 0x04003AB7 RID: 15031
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<DeTermItem, int> DeTermLayout;

	// Token: 0x04003AB8 RID: 15032
	private UUIExtendToggle CurrentToggle;

	// Token: 0x04003AB9 RID: 15033
	private bool IsNecessary;

	// Token: 0x04003ABA RID: 15034
	private int CurrentDeTermId;

	// Token: 0x02007551 RID: 30033
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x040287BC RID: 165820
		public const int BgSprite = 0;

		// Token: 0x040287BD RID: 165821
		public const int NecessaryItem = 1;

		// Token: 0x040287BE RID: 165822
		public const int DeTermScrollView = 2;

		// Token: 0x040287BF RID: 165823
		public const int DeTermItem = 3;
	}
}
