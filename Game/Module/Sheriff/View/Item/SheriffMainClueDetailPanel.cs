using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FE4 RID: 20452
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffMainClueDetailPanel : UiTabViewBase
	{
		// Token: 0x06034BBD RID: 215997 RVA: 0x00D3A948 File Offset: 0x00D38B48
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnPageRight));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnPageLeft));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickBtnBackB2));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034BBE RID: 215998 RVA: 0x00D3AB1C File Offset: 0x00D38D1C
		protected override void OnStart()
		{
			this.Proxy = (this.ExtraParams as SheriffMainProxy);
			this.PagePointLayout = new GenericLayout<SheriffMainCluePagePoint, bool>(base.GetHorizontalLayout(4), new Func<SheriffMainCluePagePoint>(this.CreatePagePointItem), null, false, true);
			SheriffAnomalyInfo anomalyInfo = this.Proxy.GetAnomalyInfo();
			this.AnomalyInfo = anomalyInfo;
			this.DataList = ModelBase<SheriffModel>.Instance.GetClueListByAnomalyId(anomalyInfo.AnomalyId);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06034BBF RID: 215999 RVA: 0x00D3AB98 File Offset: 0x00D38D98
		protected override void OnBeforeShow()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
			}
			this.CurIndex = this.Proxy.CurrentClickedClueIndex;
			List<bool> list = new List<bool>();
			for (int i = 0; i < this.DataList.Count; i++)
			{
				list.Add(i == this.CurIndex);
			}
			this.PagePointLayout.RefreshByData(list, null, false);
			this.RefreshClueDetail();
		}

		// Token: 0x06034BC0 RID: 216000 RVA: 0x00D3AC18 File Offset: 0x00D38E18
		protected void RefreshClueDetail()
		{
			bool uiactive = this.CurIndex > 0;
			bool uiactive2 = this.CurIndex < this.DataList.Count - 1;
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(uiactive2);
			}
			UUIButtonComponent button2 = base.GetButton(1);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(uiactive);
			}
			this.LevelSequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
			bool flag = this.AnomalyInfo.ClueIds.Contains(this.DataList[this.CurIndex]);
			base.GetTexture(2).SetUIActive(flag);
			base.GetText(3).SetUIActive(!flag);
			FColor changeColor = base.GetText(6).changeColor;
			UUIItem text = base.GetText(6);
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(changeColor);
			text.SetChangeColor(bUseChangeColor, fcolor);
			if (!flag)
			{
				base.GetText(6).ShowTextNew("Inference_Desc_6");
				base.GetText(7).ShowTextNew("Inference_Desc_7");
				return;
			}
			SheriffClue value = ConfigBase<SheriffConfig>.Instance.GetClueConfigById(this.DataList[this.CurIndex]).Value;
			base.SetTextureByPath(value.Icon, base.GetTexture(2), null, null);
			base.GetText(6).ShowTextNew(value.Name);
			base.GetText(7).ShowTextNew(value.Desc);
		}

		// Token: 0x06034BC1 RID: 216001 RVA: 0x00D3AD96 File Offset: 0x00D38F96
		private SheriffMainCluePagePoint CreatePagePointItem()
		{
			return new SheriffMainCluePagePoint();
		}

		// Token: 0x06034BC2 RID: 216002 RVA: 0x00D3ADA0 File Offset: 0x00D38FA0
		private void OnClickBtnPageRight()
		{
			if (this.CurIndex >= this.DataList.Count - 1)
			{
				return;
			}
			this.CurIndex++;
			List<bool> list = new List<bool>();
			for (int i = 0; i < this.DataList.Count; i++)
			{
				list.Add(i == this.CurIndex);
			}
			this.PagePointLayout.RefreshByData(list, null, false);
			this.RefreshClueDetail();
		}

		// Token: 0x06034BC3 RID: 216003 RVA: 0x00D3AE10 File Offset: 0x00D39010
		private void OnClickBtnPageLeft()
		{
			if (this.CurIndex <= 0)
			{
				return;
			}
			this.CurIndex--;
			List<bool> list = new List<bool>();
			for (int i = 0; i < this.DataList.Count; i++)
			{
				list.Add(i == this.CurIndex);
			}
			this.PagePointLayout.RefreshByData(list, null, false);
			this.RefreshClueDetail();
		}

		// Token: 0x06034BC4 RID: 216004 RVA: 0x00D3AE74 File Offset: 0x00D39074
		private void OnClickBtnBackB2()
		{
			this.Proxy.CloseClueDetail();
		}

		// Token: 0x0401E631 RID: 124465
		[Nullable(2)]
		protected SheriffMainProxy Proxy;

		// Token: 0x0401E632 RID: 124466
		[Nullable(2)]
		protected SheriffAnomalyInfo AnomalyInfo;

		// Token: 0x0401E633 RID: 124467
		protected List<int> DataList = new List<int>();

		// Token: 0x0401E634 RID: 124468
		protected int CurIndex;

		// Token: 0x0401E635 RID: 124469
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<SheriffMainCluePagePoint, bool> PagePointLayout;

		// Token: 0x0401E636 RID: 124470
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200AFBF RID: 44991
		[NullableContext(0)]
		private static class EDefine
		{
			// Token: 0x0403688A RID: 223370
			public const int BtnPageArrowRight = 0;

			// Token: 0x0403688B RID: 223371
			public const int BtnPageArrowLeft = 1;

			// Token: 0x0403688C RID: 223372
			public const int TexIcon = 2;

			// Token: 0x0403688D RID: 223373
			public const int TxtLock = 3;

			// Token: 0x0403688E RID: 223374
			public const int PanelPage = 4;

			// Token: 0x0403688F RID: 223375
			public const int ItemPoint = 5;

			// Token: 0x04036890 RID: 223376
			public const int TxtName = 6;

			// Token: 0x04036891 RID: 223377
			public const int TxtInfo = 7;

			// Token: 0x04036892 RID: 223378
			public const int BtnBackB2 = 8;
		}
	}
}
