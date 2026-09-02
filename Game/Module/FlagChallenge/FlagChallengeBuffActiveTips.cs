using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D54 RID: 23892
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeBuffActiveTips : UiTickViewBase
	{
		// Token: 0x1700989F RID: 39071
		// (get) Token: 0x0603C372 RID: 246642 RVA: 0x00F4618E File Offset: 0x00F4438E
		[Nullable(2)]
		public new FlagChallengeBuffActiveTipsParams OpenParam
		{
			[NullableContext(2)]
			get
			{
				return this.OpenParam as FlagChallengeBuffActiveTipsParams;
			}
		}

		// Token: 0x0603C373 RID: 246643 RVA: 0x00F4619B File Offset: 0x00F4439B
		public FlagChallengeBuffActiveTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C374 RID: 246644 RVA: 0x00F461B0 File Offset: 0x00F443B0
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

		// Token: 0x0603C375 RID: 246645 RVA: 0x00F462C0 File Offset: 0x00F444C0
		protected override void OnStart()
		{
			int activityId = this.OpenParam.ActivityId;
			this.Data = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(activityId);
			this.ShowBuffList = this.Data.GetBuffActiveTipsList();
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
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			FlagChallengeBuffActiveTipsInfo flagChallengeBuffActiveTipsInfo = null;
			if (this.ShowBuffList.Count > 0)
			{
				flagChallengeBuffActiveTipsInfo = this.ShowBuffList[0];
				this.ShowBuffList.RemoveAt(0);
			}
			if (flagChallengeBuffActiveTipsInfo == null)
			{
				base.CloseMe(null);
				return;
			}
			this.UpdateData(flagChallengeBuffActiveTipsInfo);
		}

		// Token: 0x0603C376 RID: 246646 RVA: 0x00F4636F File Offset: 0x00F4456F
		protected override void OnBeforeDestroy()
		{
			FlagChallengeData data = this.Data;
			if (data == null)
			{
				return;
			}
			data.ClearBuffActiveTipsList();
		}

		// Token: 0x0603C377 RID: 246647 RVA: 0x00F46384 File Offset: 0x00F44584
		public void UpdateData(FlagChallengeBuffActiveTipsInfo buffInfo)
		{
			this.CurShowInfo = buffInfo;
			if (this.CurShowInfo == null)
			{
				base.CloseMe(null);
				return;
			}
			this.TipCountDown = (float)ConfigBase<FlagChallengeConfig>.Instance.GetBuffShowTime();
			FlagChallengeBuffData buffData = this.Data.GetBuffData(this.CurShowInfo.BuffId);
			if (buffData == null)
			{
				return;
			}
			base.GetText(1).ShowTextNew(buffData.Config.BuffName);
			base.GetText(2).ShowTextNew(buffData.Config.BuffDesc);
			this.UpdateState();
		}

		// Token: 0x0603C378 RID: 246648 RVA: 0x00F46410 File Offset: 0x00F44610
		public void UpdateState()
		{
			switch (this.CurShowInfo.State)
			{
			case EFlagChallengeBuffStatus.NotActive:
				this.SetStateNotActive();
				return;
			case EFlagChallengeBuffStatus.Active:
				this.SetStateActive();
				return;
			case EFlagChallengeBuffStatus.TempActive:
				this.SetStateTempActive();
				return;
			default:
				return;
			}
		}

		// Token: 0x0603C379 RID: 246649 RVA: 0x00F46450 File Offset: 0x00F44650
		public void SetStateActive()
		{
			this.SetLockShow(false);
			this.SetTagName("Morale_title_24");
			this.SetTagBg("SP_ItemNewBg");
			this.SetCheckState(9);
			this.SetInvalidLine(false);
			this.SetTitleChangeColor(false);
		}

		// Token: 0x0603C37A RID: 246650 RVA: 0x00F46485 File Offset: 0x00F44685
		public void SetStateTempActive()
		{
			this.SetLockShow(true);
			this.SetTagName("Morale_title_25");
			this.SetTagBg("SP_ItemNewBg");
			this.SetCheckState(9);
			this.SetInvalidLine(false);
			this.SetTitleChangeColor(false);
		}

		// Token: 0x0603C37B RID: 246651 RVA: 0x00F464BA File Offset: 0x00F446BA
		public void SetStateNotActive()
		{
			this.SetLockShow(false);
			this.SetTagName("Morale_title_26");
			this.SetTagBg("SP_InvalidationBg");
			this.SetCheckState(10);
			this.SetInvalidLine(true);
			this.SetTitleChangeColor(true);
		}

		// Token: 0x0603C37C RID: 246652 RVA: 0x00F464EF File Offset: 0x00F446EF
		private void SetLockShow(bool show)
		{
			base.GetItem(7).SetUIActive(show);
		}

		// Token: 0x0603C37D RID: 246653 RVA: 0x00F464FE File Offset: 0x00F446FE
		private void SetTagName(string key)
		{
			UUIText text = base.GetText(8);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(key);
		}

		// Token: 0x0603C37E RID: 246654 RVA: 0x00F46514 File Offset: 0x00F44714
		private void SetTagBg(string resId)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resId);
			UUISprite sprite = base.GetSprite(6);
			this.SetSpriteByPath(resourcePath, sprite, false, null, null);
		}

		// Token: 0x0603C37F RID: 246655 RVA: 0x00F46548 File Offset: 0x00F44748
		private void SetCheckState(int index)
		{
			foreach (int num in new List<int>
			{
				9,
				10
			})
			{
				base.GetItem(num).SetUIActive(num == index);
			}
		}

		// Token: 0x0603C380 RID: 246656 RVA: 0x00F465B4 File Offset: 0x00F447B4
		private void SetInvalidLine(bool show)
		{
			base.GetItem(11).SetUIActive(show);
		}

		// Token: 0x0603C381 RID: 246657 RVA: 0x00F465C4 File Offset: 0x00F447C4
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

		// Token: 0x0603C382 RID: 246658 RVA: 0x00F465F1 File Offset: 0x00F447F1
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

		// Token: 0x0603C383 RID: 246659 RVA: 0x00F46622 File Offset: 0x00F44822
		private void CloseViewOrShowNextData()
		{
			if (this.ShowBuffList.Count > 0)
			{
				this.ShowNextBuff();
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x0603C384 RID: 246660 RVA: 0x00F46644 File Offset: 0x00F44844
		private UniTask ShowNextBuff()
		{
			FlagChallengeBuffActiveTips.<ShowNextBuff>d__23 <ShowNextBuff>d__;
			<ShowNextBuff>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowNextBuff>d__.<>4__this = this;
			<ShowNextBuff>d__.<>1__state = -1;
			<ShowNextBuff>d__.<>t__builder.Start<FlagChallengeBuffActiveTips.<ShowNextBuff>d__23>(ref <ShowNextBuff>d__);
			return <ShowNextBuff>d__.<>t__builder.Task;
		}

		// Token: 0x04021D32 RID: 138546
		public float TipCountDown;

		// Token: 0x04021D33 RID: 138547
		public List<FlagChallengeBuffActiveTipsInfo> ShowBuffList = new List<FlagChallengeBuffActiveTipsInfo>();

		// Token: 0x04021D34 RID: 138548
		[Nullable(2)]
		public FlagChallengeBuffActiveTipsInfo CurShowInfo;

		// Token: 0x04021D35 RID: 138549
		[Nullable(2)]
		private FlagChallengeData Data;
	}
}
