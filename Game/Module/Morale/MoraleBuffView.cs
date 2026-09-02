using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005713 RID: 22291
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleBuffView : UiViewBase
	{
		// Token: 0x17009120 RID: 37152
		// (get) Token: 0x06038BC1 RID: 232385 RVA: 0x00E5D796 File Offset: 0x00E5B996
		[Nullable(2)]
		public new MoraleBuffViewParams OpenParam
		{
			[NullableContext(2)]
			get
			{
				return this.OpenParam as MoraleBuffViewParams;
			}
		}

		// Token: 0x06038BC2 RID: 232386 RVA: 0x00E5D7A3 File Offset: 0x00E5B9A3
		public MoraleBuffView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038BC3 RID: 232387 RVA: 0x00E5D7D0 File Offset: 0x00E5B9D0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIArtText)),
				new ValueTuple<int, Type>(8, typeof(UUIArtText)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIText)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIText)),
				new ValueTuple<int, Type>(17, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(9, new Action(this.OnButtonBuffDetail))
			};
		}

		// Token: 0x06038BC4 RID: 232388 RVA: 0x00E5D9A4 File Offset: 0x00E5BBA4
		private void InitDataParam()
		{
			this.BuffDataList = new List<MoraleBuffData>(ModelBase<MoraleModel>.Instance.BuffList);
			MoraleBuffData moraleBuffData = null;
			foreach (MoraleBuffData moraleBuffData2 in this.BuffDataList)
			{
				int id = moraleBuffData2.Id;
				MoraleBuffViewParams openParam = this.OpenParam;
				int? num = (openParam != null) ? openParam.BuffId : null;
				if (id == num.GetValueOrDefault() & num != null)
				{
					moraleBuffData = moraleBuffData2;
					break;
				}
			}
			this.SelectBuff = (moraleBuffData ?? ModelBase<MoraleModel>.Instance.GetStageBuffData());
			this.SetSelectBuff(this.SelectBuff);
		}

		// Token: 0x06038BC5 RID: 232389 RVA: 0x00E5DA64 File Offset: 0x00E5BC64
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleBuffView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleBuffView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038BC6 RID: 232390 RVA: 0x00E5DAA8 File Offset: 0x00E5BCA8
		private UniTask InitBuffList()
		{
			MoraleBuffView.<InitBuffList>d__16 <InitBuffList>d__;
			<InitBuffList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBuffList>d__.<>4__this = this;
			<InitBuffList>d__.<>1__state = -1;
			<InitBuffList>d__.<>t__builder.Start<MoraleBuffView.<InitBuffList>d__16>(ref <InitBuffList>d__);
			return <InitBuffList>d__.<>t__builder.Task;
		}

		// Token: 0x06038BC7 RID: 232391 RVA: 0x00E5DAEB File Offset: 0x00E5BCEB
		protected override void OnAddEventListener()
		{
		}

		// Token: 0x06038BC8 RID: 232392 RVA: 0x00E5DAED File Offset: 0x00E5BCED
		protected override void OnRemoveEventListener()
		{
		}

		// Token: 0x06038BC9 RID: 232393 RVA: 0x00E5DAF0 File Offset: 0x00E5BCF0
		protected override void OnBeforeShow()
		{
			this.UpdateData();
			UUIScrollViewWithScrollbarComponent scroll = base.GetScrollViewWithScrollbar(13);
			scroll.OnLateUpdate.Bind(delegate(float _)
			{
				TimerSystem.Instance.Next(new TTimerAction(this.UpdateProgressAndJump), null, null);
				scroll.OnLateUpdate.Unbind();
			});
		}

		// Token: 0x06038BCA RID: 232394 RVA: 0x00E5DB3C File Offset: 0x00E5BD3C
		protected void UpdateProgressAndJump(float _)
		{
			if (base.IsDestroyOrDestroying)
			{
				return;
			}
			this.UpdateLvProgress(null, null);
			this.UpdateScrollJumpPos();
		}

		// Token: 0x06038BCB RID: 232395 RVA: 0x00E5DB70 File Offset: 0x00E5BD70
		private void UpdateData()
		{
			foreach (MoraleBuffItem moraleBuffItem in this.BuffItemList)
			{
				moraleBuffItem.UpdateData();
			}
			if (this.SelectBuff != null)
			{
				this.BuffInfoPanel.UpdateData(this.SelectBuff);
			}
			this.MoraleLvPanel.UpdateData();
			this.UnbreakableLvPanel.UpdateData();
			List<MoraleBuffData> buffList = ModelBase<MoraleModel>.Instance.BuffList;
			int num = 0;
			using (List<MoraleBuffData>.Enumerator enumerator2 = buffList.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.IsActiveOrTempActive())
					{
						num++;
					}
				}
			}
			UUIArtText artText = base.GetArtText(7);
			if (artText != null)
			{
				artText.SetText(num.ToString());
			}
			UUIArtText artText2 = base.GetArtText(8);
			if (artText2 != null)
			{
				artText2.SetText(buffList.Count.ToString());
			}
			this.UpdateLvProgress(null, null);
			this.UpdateExpAddDesc();
			this.UpdateAreaBuffRedDot();
		}

		// Token: 0x06038BCC RID: 232396 RVA: 0x00E5DC9C File Offset: 0x00E5BE9C
		public void UpdateScrollJumpPos()
		{
			if (this.SelectBuff == null)
			{
				return;
			}
			int num = Math.Max(0, this.SelectBuff.Index - 2);
			MoraleBuffItem moraleBuffItem = (num < this.BuffItemList.Count) ? this.BuffItemList[num] : null;
			if (moraleBuffItem == null)
			{
				return;
			}
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(13);
			FVector relativeLocation = scrollViewWithScrollbar.ContentUIItem.Get().RelativeLocation;
			FVector2D fvector2D = new FVector2D(ref relativeLocation);
			scrollViewWithScrollbar.ScrollToLeft(ref fvector2D, moraleBuffItem.GetRootItem(), false);
		}

		// Token: 0x06038BCD RID: 232397 RVA: 0x00E5DD1E File Offset: 0x00E5BF1E
		private void SetSelectBuff(MoraleBuffData buff)
		{
			this.SelectBuff = buff;
			this.UpdateSelectBuffState();
		}

		// Token: 0x06038BCE RID: 232398 RVA: 0x00E5DD30 File Offset: 0x00E5BF30
		private void UpdateSelectBuffState()
		{
			foreach (MoraleBuffData moraleBuffData in this.BuffDataList)
			{
				int id = moraleBuffData.Id;
				MoraleBuffData selectBuff = this.SelectBuff;
				int? num = (selectBuff != null) ? new int?(selectBuff.Id) : null;
				moraleBuffData.SetSelectState(id == num.GetValueOrDefault() & num != null);
			}
		}

		// Token: 0x06038BCF RID: 232399 RVA: 0x00E5DDB8 File Offset: 0x00E5BFB8
		private void OnButtonBuffDetail()
		{
			this.RoleAttrAddPanel.SetActive(true);
		}

		// Token: 0x06038BD0 RID: 232400 RVA: 0x00E5DDC8 File Offset: 0x00E5BFC8
		private void OnClickBuff(MoraleBuffData buff)
		{
			this.SetSelectBuff(buff);
			this.BuffInfoPanel.UpdateData(buff);
			foreach (MoraleBuffItem moraleBuffItem in this.BuffItemList)
			{
				moraleBuffItem.UpdateToggleState();
			}
		}

		// Token: 0x06038BD1 RID: 232401 RVA: 0x00E5DE2C File Offset: 0x00E5C02C
		private void OnBtnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038BD2 RID: 232402 RVA: 0x00E5DE38 File Offset: 0x00E5C038
		public void UpdateLvProgress(int? moraleLv = null, int? tempMoraleLv = null)
		{
			UUISprite sprite = base.GetSprite(2);
			float num = (sprite != null) ? sprite.GetWidth() : 0f;
			if (num <= 0f)
			{
				return;
			}
			int num2 = moraleLv ?? ModelBase<MoraleBattleModel>.Instance.GetMoraleLevel();
			float lvProgress = this.GetLvProgress(num2);
			if (sprite != null)
			{
				sprite.SetFillAmount(lvProgress);
			}
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			int num3 = tempMoraleLv ?? ModelBase<MoraleBattleModel>.Instance.GetTempMoraleLevel();
			bool flag = num3 > 0 || lvProgress < 1f;
			UUISprite sprite2 = base.GetSprite(3);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(flag);
			}
			if (!flag)
			{
				return;
			}
			float stretchLeft = num * lvProgress;
			if (sprite2 != null)
			{
				sprite2.SetStretchLeft(stretchLeft);
			}
			int lv = num2 + num3;
			float lvProgress2 = this.GetLvProgress(lv);
			float num4 = 1f - lvProgress2;
			float stretchRight = num * num4;
			if (sprite2 != null)
			{
				sprite2.SetStretchRight(stretchRight);
			}
		}

		// Token: 0x06038BD3 RID: 232403 RVA: 0x00E5DF30 File Offset: 0x00E5C130
		public float GetLvProgress(int lv)
		{
			int num = this.BuffItemList.Count * 2 - 1;
			MoraleBuffData stageBuffDataByLv = ModelBase<MoraleModel>.Instance.GetStageBuffDataByLv(lv);
			int num2 = Math.Max(stageBuffDataByLv.StartStageLv - 1, 0);
			int num3 = (stageBuffDataByLv.Index > 0) ? 2 : 1;
			float num4 = (float)(lv - num2) / (float)(stageBuffDataByLv.EndStageLv - num2) * (float)num3;
			return ((float)Math.Max(stageBuffDataByLv.Index * 2 - 1, 0) + num4) / (float)num;
		}

		// Token: 0x06038BD4 RID: 232404 RVA: 0x00E5DFA4 File Offset: 0x00E5C1A4
		public void UpdateExpAddDesc()
		{
			UUIText text = base.GetText(16);
			float num = (float)ModelBase<MoraleBattleModel>.Instance.GetExpRatio() / 100f;
			bool flag = num > 100f;
			if (text != null)
			{
				text.SetUIActive(flag);
			}
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Morale_title_37", new <>z__ReadOnlySingleElementList<object>(num.ToString()));
			}
		}

		// Token: 0x06038BD5 RID: 232405 RVA: 0x00E5E000 File Offset: 0x00E5C200
		public void UpdateAreaBuffRedDot()
		{
			bool uiactive = ModelBase<MoraleModel>.Instance.RedDotAreaBuff();
			UUIItem item = base.GetItem(17);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x06038BD6 RID: 232406 RVA: 0x00E5E02B File Offset: 0x00E5C22B
		private void OnCloseRoleAttrAddPanel()
		{
			ModelBase<MoraleModel>.Instance.ClearNewActiveAreaBuff();
			this.UpdateAreaBuffRedDot();
		}

		// Token: 0x04020544 RID: 132420
		public PopupCaptionItem PopupCaption;

		// Token: 0x04020545 RID: 132421
		public MoraleBuffInfoPanel BuffInfoPanel;

		// Token: 0x04020546 RID: 132422
		public List<MoraleBuffItem> BuffItemList = new List<MoraleBuffItem>();

		// Token: 0x04020547 RID: 132423
		public Dictionary<int, MoraleBuffItem> BuffItemMap = new Dictionary<int, MoraleBuffItem>();

		// Token: 0x04020548 RID: 132424
		public MoraleLvInfoItem MoraleLvPanel;

		// Token: 0x04020549 RID: 132425
		public MoraleUnbreakableLvInfoItem UnbreakableLvPanel;

		// Token: 0x0402054A RID: 132426
		[Nullable(2)]
		public MoraleBuffData SelectBuff;

		// Token: 0x0402054B RID: 132427
		public List<MoraleBuffData> BuffDataList = new List<MoraleBuffData>();

		// Token: 0x0402054C RID: 132428
		public MoraleBuffAddPanel RoleAttrAddPanel;

		// Token: 0x0200B7AF RID: 47023
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038D0F RID: 232719
			public const int ItemCaption = 0;

			// Token: 0x04038D10 RID: 232720
			public const int ItemInfo = 1;

			// Token: 0x04038D11 RID: 232721
			public const int SpriteMoraleLvProgress = 2;

			// Token: 0x04038D12 RID: 232722
			public const int SpriteTempMoraleLvProgress = 3;

			// Token: 0x04038D13 RID: 232723
			public const int ItemBuffRoot = 4;

			// Token: 0x04038D14 RID: 232724
			public const int ItemBuffTemplateDown = 5;

			// Token: 0x04038D15 RID: 232725
			public const int ItemBuffTemplateUp = 6;

			// Token: 0x04038D16 RID: 232726
			public const int ArtTextCurrentProgress = 7;

			// Token: 0x04038D17 RID: 232727
			public const int ArtTextTotalProgress = 8;

			// Token: 0x04038D18 RID: 232728
			public const int ButtonBuffDetail = 9;

			// Token: 0x04038D19 RID: 232729
			public const int ItemUnbreakableLv = 10;

			// Token: 0x04038D1A RID: 232730
			public const int ItemMoraleLv = 11;

			// Token: 0x04038D1B RID: 232731
			public const int ItemBuffDetailPos = 12;

			// Token: 0x04038D1C RID: 232732
			public const int ScrollBuff = 13;

			// Token: 0x04038D1D RID: 232733
			public const int TextLvAddDesc = 14;

			// Token: 0x04038D1E RID: 232734
			public const int ItemRoleAttrAdd = 15;

			// Token: 0x04038D1F RID: 232735
			public const int TextExpAddDesc = 16;

			// Token: 0x04038D20 RID: 232736
			public const int ItemAreaBuffRedDot = 17;
		}
	}
}
