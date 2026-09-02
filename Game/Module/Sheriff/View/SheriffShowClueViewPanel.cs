using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Sheriff.View.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View
{
	// Token: 0x02004FD5 RID: 20437
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffShowClueViewPanel : UiPanelBase
	{
		// Token: 0x06034B2E RID: 215854 RVA: 0x00D37554 File Offset: 0x00D35754
		public SheriffShowClueViewPanel(List<int> dataList, int? inputClue = null)
		{
			this.DataList = dataList;
			if (inputClue != null && inputClue.Value != 0)
			{
				this.CurIndex = this.DataList.IndexOf(inputClue.Value);
			}
		}

		// Token: 0x06034B2F RID: 215855 RVA: 0x00D37590 File Offset: 0x00D35790
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

		// Token: 0x06034B30 RID: 215856 RVA: 0x00D37764 File Offset: 0x00D35964
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
			this.PagePointLayout = new GenericLayout<SheriffMainCluePagePoint, bool>(base.GetHorizontalLayout(4), new Func<SheriffMainCluePagePoint>(this.CreatePagePointItem), null, false, true);
		}

		// Token: 0x06034B31 RID: 215857 RVA: 0x00D37798 File Offset: 0x00D35998
		protected override void OnBeforeShow()
		{
			this.LevelSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
			if (this.CurIndex <= 0)
			{
				for (int i = 0; i < this.DataList.Count; i++)
				{
					if (this.DataList[i] != 0)
					{
						this.CurIndex = i;
						break;
					}
				}
			}
			List<bool> list = new List<bool>();
			for (int j = 0; j < this.DataList.Count; j++)
			{
				list.Add(j == this.CurIndex);
			}
			this.PagePointLayout.RefreshByData(list, null, false);
			this.RefreshClueDetail();
		}

		// Token: 0x06034B32 RID: 215858 RVA: 0x00D37834 File Offset: 0x00D35A34
		protected void RefreshClueDetail()
		{
			if (this.DataList.Count == 0)
			{
				return;
			}
			this.LevelSequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
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
			int num = this.DataList[this.CurIndex];
			base.GetTexture(2).SetUIActive(num != 0);
			base.GetText(3).SetUIActive(num == 0);
			FColor changeColor = base.GetText(6).changeColor;
			UUIItem text = base.GetText(6);
			bool bUseChangeColor = num != 0;
			FColor? fcolor = new FColor?(changeColor);
			text.SetChangeColor(bUseChangeColor, fcolor);
			if (num == 0)
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

		// Token: 0x06034B33 RID: 215859 RVA: 0x00D379B6 File Offset: 0x00D35BB6
		private SheriffMainCluePagePoint CreatePagePointItem()
		{
			return new SheriffMainCluePagePoint();
		}

		// Token: 0x06034B34 RID: 215860 RVA: 0x00D379C0 File Offset: 0x00D35BC0
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

		// Token: 0x06034B35 RID: 215861 RVA: 0x00D37A30 File Offset: 0x00D35C30
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

		// Token: 0x06034B36 RID: 215862 RVA: 0x00D37A94 File Offset: 0x00D35C94
		private void OnClickBtnBackB2()
		{
			Action closeCallBack = this.CloseCallBack;
			if (closeCallBack == null)
			{
				return;
			}
			closeCallBack();
		}

		// Token: 0x0401E605 RID: 124421
		[Nullable(2)]
		public Action CloseCallBack;

		// Token: 0x0401E606 RID: 124422
		protected int CurIndex;

		// Token: 0x0401E607 RID: 124423
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401E608 RID: 124424
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<SheriffMainCluePagePoint, bool> PagePointLayout;

		// Token: 0x0401E609 RID: 124425
		protected List<int> DataList;

		// Token: 0x0200AFA2 RID: 44962
		[NullableContext(0)]
		private static class EPanelDefine
		{
			// Token: 0x04036812 RID: 223250
			public const int BtnPageArrowRight = 0;

			// Token: 0x04036813 RID: 223251
			public const int BtnPageArrowLeft = 1;

			// Token: 0x04036814 RID: 223252
			public const int TexIcon = 2;

			// Token: 0x04036815 RID: 223253
			public const int TxtLock = 3;

			// Token: 0x04036816 RID: 223254
			public const int PanelPage = 4;

			// Token: 0x04036817 RID: 223255
			public const int ItemPoint = 5;

			// Token: 0x04036818 RID: 223256
			public const int TxtName = 6;

			// Token: 0x04036819 RID: 223257
			public const int TxtInfo = 7;

			// Token: 0x0403681A RID: 223258
			public const int BtnBackB2 = 8;
		}
	}
}
