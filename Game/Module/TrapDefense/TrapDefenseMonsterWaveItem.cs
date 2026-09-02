using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E45 RID: 20037
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseMonsterWaveItem : GridProxyAbstract<TrapDefenseMonsterWaveData>, IDynamicScrollItem<TrapDefenseMonsterWaveData>
	{
		// Token: 0x06033C9D RID: 212125 RVA: 0x00CF2030 File Offset: 0x00CF0230
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUILayoutBase));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033C9E RID: 212126 RVA: 0x00CF220C File Offset: 0x00CF040C
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseMonsterWaveItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseMonsterWaveItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033C9F RID: 212127 RVA: 0x00CF2250 File Offset: 0x00CF0450
		public override UniTask RefreshAsync(TrapDefenseMonsterWaveData data, bool isSelected, int gridIndex)
		{
			TrapDefenseMonsterWaveItem.<RefreshAsync>d__9 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<TrapDefenseMonsterWaveItem.<RefreshAsync>d__9>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033CA0 RID: 212128 RVA: 0x00CF229B File Offset: 0x00CF049B
		public TrapDefenseMonsterItem CreateItemMonster()
		{
			return new TrapDefenseMonsterItem(true)
			{
				OnSelectMonsterItemCallback = new Action<TrapDefenseMonsterData>(this.OnSelectMonsterItem),
				OnShowNumCallback = new Func<TrapDefenseMonsterData, string>(this.GetMonsterInTheWaveShowNum)
			};
		}

		// Token: 0x06033CA1 RID: 212129 RVA: 0x00CF22C7 File Offset: 0x00CF04C7
		public override void OnSelected(bool isSelected)
		{
			if (!this.IsFireForBuffClick)
			{
				this.LayoutMonster.SelectGridProxy(Math.Max(this.LastSelectMonsterIndex, 0), false);
			}
		}

		// Token: 0x06033CA2 RID: 212130 RVA: 0x00CF22E9 File Offset: 0x00CF04E9
		public override void OnDeselected(bool isSelected)
		{
			this.LayoutMonster.DeselectCurrentGridProxy();
		}

		// Token: 0x06033CA3 RID: 212131 RVA: 0x00CF22F8 File Offset: 0x00CF04F8
		private void OnSelectMonsterItem(TrapDefenseMonsterData data)
		{
			this.IsFireForBuffClick = true;
			IScrollViewDelegate<IGridProxy<TrapDefenseMonsterWaveData>, TrapDefenseMonsterWaveData> scrollViewDelegate = base.ScrollViewDelegate;
			if (scrollViewDelegate != null)
			{
				scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
			}
			Action<TrapDefenseMonsterData, TrapDefenseMonsterWaveData> onSelectMonsterCallBack = this.OnSelectMonsterCallBack;
			if (onSelectMonsterCallBack != null)
			{
				onSelectMonsterCallBack(data, this.ItemData);
			}
			this.IsFireForBuffClick = false;
		}

		// Token: 0x06033CA4 RID: 212132 RVA: 0x00CF234C File Offset: 0x00CF054C
		public string GetMonsterInTheWaveShowNum(TrapDefenseMonsterData data)
		{
			int monsterNum = this.ItemData.GetMonsterNum(data);
			if (monsterNum <= 1)
			{
				return "";
			}
			string multiText = ConfigBase<TextConfig>.Instance.GetMultiText(ETrapDefenseTextKey.XValueShow.ToString(), new string[]
			{
				monsterNum.ToString()
			});
			if (string.IsNullOrEmpty(multiText))
			{
				return monsterNum.ToString();
			}
			return multiText;
		}

		// Token: 0x06033CA5 RID: 212133 RVA: 0x00CF23AC File Offset: 0x00CF05AC
		public AUIBaseActor GetUsingItem(TrapDefenseMonsterWaveData data)
		{
			UUIItem item = base.GetItem(10);
			return ((item != null) ? item.GetOwner() : null) as AUIBaseActor;
		}

		// Token: 0x06033CA6 RID: 212134 RVA: 0x00CF23C8 File Offset: 0x00CF05C8
		public void Update(TrapDefenseMonsterWaveData data, int index)
		{
			if (this.ItemData == data)
			{
				this.UpdateSelectState();
				return;
			}
			this.ItemData = data;
			bool flag = data.IsInTheCurrentWave();
			bool flag2 = data.IsFinish();
			UUIArtText artText = base.GetArtText(2);
			UUIText text = base.GetText(3);
			if (artText != null)
			{
				artText.SetText(data.GetWaveFormat(2));
			}
			if (artText != null)
			{
				UUIItem uuiitem = artText;
				bool bUseChangeColor = flag;
				FColor? fcolor = new FColor?(artText.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			}
			if (text != null)
			{
				UUIItem uuiitem2 = text;
				bool bUseChangeColor2 = flag;
				FColor? fcolor = new FColor?(text.changeColor);
				uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			}
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetAlpha(flag2 ? 0.5f : 1f);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(flag2);
			}
			UUIItem item3 = base.GetItem(0);
			if (item3 != null)
			{
				item3.SetUIActive(!flag);
			}
			UUIItem item4 = base.GetItem(1);
			if (item4 != null)
			{
				item4.SetUIActive(flag);
			}
			string enhanceTipsInfoKey = data.GetEnhanceTipsInfoKey();
			bool flag3 = !string.IsNullOrEmpty(enhanceTipsInfoKey);
			UUIItem item5 = base.GetItem(5);
			if (item5 != null)
			{
				item5.SetUIActive(flag3);
			}
			if (flag3)
			{
				UUIText text2 = base.GetText(6);
				if (text2 != null)
				{
					text2.ShowTextNew(enhanceTipsInfoKey);
				}
			}
			this.EndlessItem.SetActive(data.IsEndlessStart);
			if (data.IsEndlessStart)
			{
				this.EndlessItem.UpdateDescKey(data.EndlessWaveDesc ?? data.Wave.ToString());
			}
			List<TrapDefenseMonsterData> monsterDataList = data.GetMonsterDataList();
			this.LayoutMonster.RefreshByData(monsterDataList, new Action(this.UpdateSelectState), true);
		}

		// Token: 0x06033CA7 RID: 212135 RVA: 0x00CF2545 File Offset: 0x00CF0745
		public void UpdateSelectState()
		{
			GenericLayout<TrapDefenseMonsterItem, TrapDefenseMonsterData> layoutMonster = this.LayoutMonster;
			if (layoutMonster == null)
			{
				return;
			}
			layoutMonster.GetLayoutItemList().ForEach(delegate(TrapDefenseMonsterItem item)
			{
				item.CheckWaveUpdate(this.ItemData);
			});
		}

		// Token: 0x06033CA8 RID: 212136 RVA: 0x00CF2568 File Offset: 0x00CF0768
		public UniTask Init(UUIItem actor)
		{
			TrapDefenseMonsterWaveItem.<Init>d__18 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<TrapDefenseMonsterWaveItem.<Init>d__18>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06033CA9 RID: 212137 RVA: 0x00CF25B3 File Offset: 0x00CF07B3
		public void ClearItem()
		{
		}

		// Token: 0x0401DF8A RID: 122762
		public TrapDefenseMonsterWaveData ItemData;

		// Token: 0x0401DF8B RID: 122763
		public Action<TrapDefenseMonsterWaveData> ClickCallBack;

		// Token: 0x0401DF8C RID: 122764
		public Action<TrapDefenseMonsterData, TrapDefenseMonsterWaveData> OnSelectMonsterCallBack;

		// Token: 0x0401DF8D RID: 122765
		public GenericLayout<TrapDefenseMonsterItem, TrapDefenseMonsterData> LayoutMonster;

		// Token: 0x0401DF8E RID: 122766
		public TrapDefenseMonsterEndlessWaveItem EndlessItem;

		// Token: 0x0401DF8F RID: 122767
		public int LastSelectMonsterIndex = -1;

		// Token: 0x0401DF90 RID: 122768
		public bool IsFireForBuffClick;
	}
}
