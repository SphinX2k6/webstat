using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006879 RID: 26745
	[NullableContext(1)]
	[Nullable(0)]
	public class EncircleResultView : UiViewBase
	{
		// Token: 0x06042A6E RID: 273006 RVA: 0x0111BBFB File Offset: 0x01119DFB
		public EncircleResultView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06042A6F RID: 273007 RVA: 0x0111BC04 File Offset: 0x01119E04
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
		}

		// Token: 0x06042A70 RID: 273008 RVA: 0x0111BC8C File Offset: 0x01119E8C
		protected override UniTask OnBeforeStartAsync()
		{
			EncircleResultView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<EncircleResultView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042A71 RID: 273009 RVA: 0x0111BCCF File Offset: 0x01119ECF
		protected override void OnBeforeShow()
		{
			this.RefreshTitle();
			this.RefreshRewardList();
			this.RefreshRecord();
		}

		// Token: 0x06042A72 RID: 273010 RVA: 0x0111BCE3 File Offset: 0x01119EE3
		private void RefreshRecord()
		{
			if (this.RewardData == null)
			{
				return;
			}
			EncircleRecordItem encircleRecordItem = this.EncircleRecordItem;
			if (encircleRecordItem == null)
			{
				return;
			}
			encircleRecordItem.Refresh(this.RewardData.GetRewardInfo());
		}

		// Token: 0x06042A73 RID: 273011 RVA: 0x0111BD0C File Offset: 0x01119F0C
		private void RefreshRewardList()
		{
			if (this.RewardData == null || this.RewardItemList == null)
			{
				return;
			}
			if (!this.RewardData.GetRewardInfo().IsSuccess)
			{
				this.RewardItemList.SetUiActive(false);
				return;
			}
			if (this.RewardData.GetRewardInfo().CommonItems == null)
			{
				this.RewardItemList.SetUiActive(false);
				return;
			}
			this.RewardItemList.SetUiActive(true);
			this.RewardItemList.Refresh(this.RewardData.GetRewardInfo().CommonItems, true);
		}

		// Token: 0x06042A74 RID: 273012 RVA: 0x0111BD90 File Offset: 0x01119F90
		protected virtual void RefreshTitle()
		{
			if (this.RewardData == null)
			{
				return;
			}
			UUIText text = base.GetText(1);
			UUITexture texture = base.GetTexture(2);
			UUIEffectOutline uuieffectOutline = text.GetOwner().GetComponentByClass(UUIEffectOutline.StaticClass()) as UUIEffectOutline;
			if (this.IsSuccess())
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "CorniceMeetingSettleSuccess", Array.Empty<object>());
				text.outlineColor = FColor.FromHex("C48B29FF");
				texture.SetColor(FColor.FromHex("8C754D7F"));
				uuieffectOutline.SetOutlineColor(FColor.FromHex("C48B29FF"));
				text.SetColor(FColor.FromHex("f2efd5"));
				base.PlaySequence("Success", null, false);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "GenericPromptTypes_4_GeneralText", Array.Empty<object>());
			texture.SetColor(FColor.FromHex("6e363f"));
			text.SetColor(FColor.FromHex("F08086FF"));
			text.outlineColor = FColor.FromHex("B33100FF");
			uuieffectOutline.SetOutlineColor(FColor.FromHex("B33100FF"));
			base.PlaySequence("Fail", null, false);
		}

		// Token: 0x06042A75 RID: 273013 RVA: 0x0111BE9E File Offset: 0x0111A09E
		private bool IsSuccess()
		{
			return this.RewardData != null && this.RewardData.GetRewardInfo().IsSuccess;
		}

		// Token: 0x06042A76 RID: 273014 RVA: 0x0111BEBC File Offset: 0x0111A0BC
		private UniTask InitButtonAsync()
		{
			EncircleResultView.<InitButtonAsync>d__16 <InitButtonAsync>d__;
			<InitButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButtonAsync>d__.<>4__this = this;
			<InitButtonAsync>d__.<>1__state = -1;
			<InitButtonAsync>d__.<>t__builder.Start<EncircleResultView.<InitButtonAsync>d__16>(ref <InitButtonAsync>d__);
			return <InitButtonAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042A77 RID: 273015 RVA: 0x0111BF00 File Offset: 0x0111A100
		private UniTask CreateButton(UUIItem uiItem, int buttonIndex, Action clickFunction)
		{
			EncircleResultView.<CreateButton>d__17 <CreateButton>d__;
			<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateButton>d__.<>4__this = this;
			<CreateButton>d__.buttonIndex = buttonIndex;
			<CreateButton>d__.clickFunction = clickFunction;
			<CreateButton>d__.<>1__state = -1;
			<CreateButton>d__.<>t__builder.Start<EncircleResultView.<CreateButton>d__17>(ref <CreateButton>d__);
			return <CreateButton>d__.<>t__builder.Task;
		}

		// Token: 0x06042A78 RID: 273016 RVA: 0x0111BF53 File Offset: 0x0111A153
		private void OnReChallengeBtnClick()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.EncircleResultView, null);
			Singleton<EncirclePlayLevelController>.Instance.ResetEncircle();
		}

		// Token: 0x06042A79 RID: 273017 RVA: 0x0111BF6F File Offset: 0x0111A16F
		private void OnExitBtnClick()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.EncircleResultView, null);
			Singleton<UiManager>.Instance.CloseView(EUiViewName.EncirclePlayView, null);
		}

		// Token: 0x04025196 RID: 151958
		private const string SUCCESS_OUTLINE_COLOR = "C48B29FF";

		// Token: 0x04025197 RID: 151959
		private const string FAIL_OUTLINE_COLOR = "B33100FF";

		// Token: 0x04025198 RID: 151960
		private const string FAIL_TEXT_COLOR = "F08086FF";

		// Token: 0x04025199 RID: 151961
		private const string SUCCESS_TEXT_COLOR = "f2efd5";

		// Token: 0x0402519A RID: 151962
		protected Dictionary<int, ActivityCorniceMeetingButton> ButtonMap;

		// Token: 0x0402519B RID: 151963
		[Nullable(2)]
		private RewardItemList RewardItemList;

		// Token: 0x0402519C RID: 151964
		[Nullable(2)]
		private EncircleRecordItem EncircleRecordItem;

		// Token: 0x0402519D RID: 151965
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private RewardData<IEncircleRewardInfo> RewardData;
	}
}
