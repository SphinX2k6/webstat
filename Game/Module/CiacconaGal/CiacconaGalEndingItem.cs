using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ED5 RID: 24277
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalEndingItem : UiPanelBase
	{
		// Token: 0x0603D011 RID: 249873 RVA: 0x00F7E99A File Offset: 0x00F7CB9A
		public CiacconaGalEndingItem(CiacconaGalEndingData endingData, string labelTextId)
		{
			this.EndingData = endingData;
			this.LabelTextId = labelTextId;
		}

		// Token: 0x0603D012 RID: 249874 RVA: 0x00F7E9B0 File Offset: 0x00F7CBB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnSelfClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D013 RID: 249875 RVA: 0x00F7EB40 File Offset: 0x00F7CD40
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaGalEndingItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaGalEndingItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D014 RID: 249876 RVA: 0x00F7EB83 File Offset: 0x00F7CD83
		protected override void OnStart()
		{
			this.RefreshPanel();
			Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaEndingDataUpdate, new Action(this.OnCiacconaEndingDataUpdate));
		}

		// Token: 0x0603D015 RID: 249877 RVA: 0x00F7EBA7 File Offset: 0x00F7CDA7
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaEndingDataUpdate, new Action(this.OnCiacconaEndingDataUpdate));
		}

		// Token: 0x0603D016 RID: 249878 RVA: 0x00F7EBC8 File Offset: 0x00F7CDC8
		private void RefreshPanel()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.LabelTextId, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.EndingData.Title, Array.Empty<object>());
			this.BtnReward.SetActive(!this.EndingData.IsRewarded);
			this.BtnReward.SetRedDotVisible(this.EndingData.IsFinished && !this.EndingData.IsRewarded);
			base.GetSprite(4).SetUIActive(this.EndingData.IsRewarded);
			string resourceId = (this.EndingData.Type == ECiacconaGalEndingType.Main) ? "T_PlotReasoningFinalLockGold" : "T_PlotReasoningFinalLock";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			string path = this.EndingData.IsFinished ? this.EndingData.ImagePath : resourcePath;
			base.SetTextureByPath(path, base.GetTexture(1), null, null);
			base.GetTexture(6).SetUIActive(!this.EndingData.IsFinished);
			base.GetTexture(7).SetUIActive(this.EndingData.IsFinished);
			base.GetUiNiagara(8).SetUIActive(!this.EndingData.IsFinished && this.EndingData.Type == ECiacconaGalEndingType.Main);
		}

		// Token: 0x0603D017 RID: 249879 RVA: 0x00F7ED24 File Offset: 0x00F7CF24
		private void OnBtnRewardClick()
		{
			if (this.EndingData.IsFinished)
			{
				int id = ModelBase<CiacconaGalModel>.Instance.ActivityData.Id;
				ControllerBase<CiacconaGalController>.Instance.RequestGetActivityEndingReward(id, this.EndingData.Id);
				return;
			}
			List<TItem> dropPackagePreviewItemList = ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(this.EndingData.RewardId);
			List<DailyActivityDefine.RewardTuple> list = new List<DailyActivityDefine.RewardTuple>();
			foreach (TItem titem in dropPackagePreviewItemList)
			{
				list.Add(new DailyActivityDefine.RewardTuple
				{
					Id = titem.ItemData.ItemId,
					Num = titem.Count,
					Received = false
				});
			}
			RewardPopupData p = new RewardPopupData
			{
				RewardLists = list,
				MountItem = base.GetItem(5),
				PosBias = new FVector?(new FVector(0f, 0f, 0f))
			};
			Singleton<EventSystem>.Instance.Emit<RewardPopupData>(EEventName.RefreshRewardPopUp, p);
		}

		// Token: 0x0603D018 RID: 249880 RVA: 0x00F7EE38 File Offset: 0x00F7D038
		private void OnBtnSelfClick()
		{
			if (this.EndingData.IsFinished)
			{
				ControllerBase<CiacconaGalController>.Instance.OpenEndingDetailView(this.EndingData.Id, this.LabelTextId);
				return;
			}
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("EndingUnfinished", Array.Empty<object>());
		}

		// Token: 0x0603D019 RID: 249881 RVA: 0x00F7EE77 File Offset: 0x00F7D077
		private void OnCiacconaEndingDataUpdate()
		{
			this.RefreshPanel();
		}

		// Token: 0x040223C7 RID: 140231
		[Nullable(2)]
		private ButtonSpriteItem BtnReward;

		// Token: 0x040223C8 RID: 140232
		private readonly CiacconaGalEndingData EndingData;

		// Token: 0x040223C9 RID: 140233
		private readonly string LabelTextId;

		// Token: 0x0200BED2 RID: 48850
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403ABAF RID: 240559
			public const int BtnSelf = 0;

			// Token: 0x0403ABB0 RID: 240560
			public const int TextureBg = 1;

			// Token: 0x0403ABB1 RID: 240561
			public const int TextTitle = 2;

			// Token: 0x0403ABB2 RID: 240562
			public const int TextDesc = 3;

			// Token: 0x0403ABB3 RID: 240563
			public const int SpriteRewarded = 4;

			// Token: 0x0403ABB4 RID: 240564
			public const int BtnReward = 5;

			// Token: 0x0403ABB5 RID: 240565
			public const int TextureHoverLock = 6;

			// Token: 0x0403ABB6 RID: 240566
			public const int TextureHoverFinish = 7;

			// Token: 0x0403ABB7 RID: 240567
			public const int Niagara = 8;
		}
	}
}
