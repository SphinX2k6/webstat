using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005708 RID: 22280
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleBuffActiveTips : UiTickViewBase
	{
		// Token: 0x06038B5A RID: 232282 RVA: 0x00E5C26C File Offset: 0x00E5A46C
		public MoraleBuffActiveTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038B5B RID: 232283 RVA: 0x00E5C280 File Offset: 0x00E5A480
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUISprite)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem))
			};
		}

		// Token: 0x06038B5C RID: 232284 RVA: 0x00E5C390 File Offset: 0x00E5A590
		protected override void OnStart()
		{
			this.ShowBuffList = ModelBase<MoraleModel>.Instance.BuffActiveTipsList;
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			UUIItem item3 = base.GetItem(4);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
		}

		// Token: 0x06038B5D RID: 232285 RVA: 0x00E5C3E5 File Offset: 0x00E5A5E5
		protected override void OnBeforeShow()
		{
			this.UpdateData();
		}

		// Token: 0x06038B5E RID: 232286 RVA: 0x00E5C3F0 File Offset: 0x00E5A5F0
		public void UpdateData()
		{
			if (this.ShowBuffList.Count > 0)
			{
				this.CurShowInfo = this.ShowBuffList[0];
				this.ShowBuffList.RemoveAt(0);
			}
			else
			{
				this.CurShowInfo = null;
			}
			if (this.CurShowInfo == null)
			{
				base.CloseMe(null);
				return;
			}
			this.TipCountDown = (float)ConfigBase<MoraleConfig>.Instance.GetMoraleBuffShowTime();
			MoraleBuffData moraleBuffData = ModelBase<MoraleModel>.Instance.BuffMap.ContainsKey(this.CurShowInfo.BuffId) ? ModelBase<MoraleModel>.Instance.BuffMap[this.CurShowInfo.BuffId] : null;
			if (moraleBuffData == null)
			{
				return;
			}
			base.GetText(1).ShowTextNew(moraleBuffData.Config.BuffName);
			base.GetText(2).ShowTextNew(moraleBuffData.Config.BuffDescDetail);
			this.UpdateState();
		}

		// Token: 0x06038B5F RID: 232287 RVA: 0x00E5C4C8 File Offset: 0x00E5A6C8
		public void UpdateState()
		{
			switch (this.CurShowInfo.State)
			{
			case EMoraleBuffState.TempActive:
				this.SetStateTempActive();
				return;
			case EMoraleBuffState.Active:
				this.SetStateActive();
				return;
			case EMoraleBuffState.NotActive:
				this.SetStateNotActive();
				return;
			default:
				return;
			}
		}

		// Token: 0x06038B60 RID: 232288 RVA: 0x00E5C508 File Offset: 0x00E5A708
		public void SetStateActive()
		{
			this.SetLockShow(false);
			this.SetTagName("Morale_title_24");
			this.SetTagBg("SP_ItemNewBg");
			this.SetCheckState(9);
			this.SetInvalidLine(false);
			this.SetTitleChangeColor(false);
		}

		// Token: 0x06038B61 RID: 232289 RVA: 0x00E5C53D File Offset: 0x00E5A73D
		public void SetStateTempActive()
		{
			this.SetLockShow(true);
			this.SetTagName("Morale_title_25");
			this.SetTagBg("SP_ItemNewBg");
			this.SetCheckState(9);
			this.SetInvalidLine(false);
			this.SetTitleChangeColor(false);
		}

		// Token: 0x06038B62 RID: 232290 RVA: 0x00E5C572 File Offset: 0x00E5A772
		public void SetStateNotActive()
		{
			this.SetLockShow(false);
			this.SetTagName("Morale_title_26");
			this.SetTagBg("SP_InvalidationBg");
			this.SetCheckState(10);
			this.SetInvalidLine(true);
			this.SetTitleChangeColor(true);
		}

		// Token: 0x06038B63 RID: 232291 RVA: 0x00E5C5A7 File Offset: 0x00E5A7A7
		private void SetLockShow(bool show)
		{
			base.GetItem(7).SetUIActive(show);
		}

		// Token: 0x06038B64 RID: 232292 RVA: 0x00E5C5B6 File Offset: 0x00E5A7B6
		private void SetTagName(string key)
		{
			UUIText text = base.GetText(8);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(key);
		}

		// Token: 0x06038B65 RID: 232293 RVA: 0x00E5C5CC File Offset: 0x00E5A7CC
		private void SetTagBg(string resId)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resId);
			UUISprite sprite = base.GetSprite(6);
			this.SetSpriteByPath(resourcePath, sprite, false, null, null);
		}

		// Token: 0x06038B66 RID: 232294 RVA: 0x00E5C600 File Offset: 0x00E5A800
		private void SetCheckState(int index)
		{
			foreach (int num in new int[]
			{
				9,
				10
			})
			{
				base.GetItem(num).SetUIActive(num == index);
			}
		}

		// Token: 0x06038B67 RID: 232295 RVA: 0x00E5C640 File Offset: 0x00E5A840
		private void SetInvalidLine(bool show)
		{
			base.GetItem(11).SetUIActive(show);
		}

		// Token: 0x06038B68 RID: 232296 RVA: 0x00E5C650 File Offset: 0x00E5A850
		private void SetTitleChangeColor(bool useChangeColor)
		{
			UUIText text = base.GetText(1);
			if (text != null)
			{
				UUIItem uuiitem = text;
				FColor? fcolor = new FColor?(text.changeColor);
				uuiitem.SetChangeColor(useChangeColor, fcolor);
			}
		}

		// Token: 0x06038B69 RID: 232297 RVA: 0x00E5C67D File Offset: 0x00E5A87D
		protected override void OnTick(float delta)
		{
			if (this.TipCountDown <= 0f)
			{
				return;
			}
			this.TipCountDown -= delta;
			if (this.TipCountDown <= 0f)
			{
				this.CloseViewOrShowNextData();
			}
		}

		// Token: 0x06038B6A RID: 232298 RVA: 0x00E5C6AE File Offset: 0x00E5A8AE
		private void CloseViewOrShowNextData()
		{
			if (this.ShowBuffList.Count > 0)
			{
				this.ShowNextBuff();
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x06038B6B RID: 232299 RVA: 0x00E5C6D0 File Offset: 0x00E5A8D0
		private UniTask ShowNextBuff()
		{
			MoraleBuffActiveTips.<ShowNextBuff>d__21 <ShowNextBuff>d__;
			<ShowNextBuff>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowNextBuff>d__.<>4__this = this;
			<ShowNextBuff>d__.<>1__state = -1;
			<ShowNextBuff>d__.<>t__builder.Start<MoraleBuffActiveTips.<ShowNextBuff>d__21>(ref <ShowNextBuff>d__);
			return <ShowNextBuff>d__.<>t__builder.Task;
		}

		// Token: 0x04020530 RID: 132400
		public float TipCountDown;

		// Token: 0x04020531 RID: 132401
		public List<MoraleBuffActiveTipsInfo> ShowBuffList = new List<MoraleBuffActiveTipsInfo>();

		// Token: 0x04020532 RID: 132402
		[Nullable(2)]
		public MoraleBuffActiveTipsInfo CurShowInfo;

		// Token: 0x0200B7A1 RID: 47009
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038CBA RID: 232634
			public const int TextTitle = 1;

			// Token: 0x04038CBB RID: 232635
			public const int TextDes = 2;

			// Token: 0x04038CBC RID: 232636
			public const int PanelHaveTitle = 3;

			// Token: 0x04038CBD RID: 232637
			public const int PanelNoTitle = 4;

			// Token: 0x04038CBE RID: 232638
			public const int ItemTagNew = 5;

			// Token: 0x04038CBF RID: 232639
			public const int SpriteTagBg = 6;

			// Token: 0x04038CC0 RID: 232640
			public const int PanelClockIcon = 7;

			// Token: 0x04038CC1 RID: 232641
			public const int TxtNew = 8;

			// Token: 0x04038CC2 RID: 232642
			public const int ItemCheck = 9;

			// Token: 0x04038CC3 RID: 232643
			public const int ItemInvalid = 10;

			// Token: 0x04038CC4 RID: 232644
			public const int ItemInvalidLine = 11;
		}
	}
}
