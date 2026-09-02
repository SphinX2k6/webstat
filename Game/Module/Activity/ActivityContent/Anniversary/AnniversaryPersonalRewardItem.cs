using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069E5 RID: 27109
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AnniversaryPersonalRewardItem : GridProxyAbstract<AnniversaryPersonalRewardItemData>
	{
		// Token: 0x0604330C RID: 275212 RVA: 0x011440CC File Offset: 0x011422CC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
		}

		// Token: 0x0604330D RID: 275213 RVA: 0x01144194 File Offset: 0x01142394
		protected override UniTask OnBeforeStartAsync()
		{
			AnniversaryPersonalRewardItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<AnniversaryPersonalRewardItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604330E RID: 275214 RVA: 0x011441D7 File Offset: 0x011423D7
		public void SetClickCallback(Action<int> callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x0604330F RID: 275215 RVA: 0x011441E0 File Offset: 0x011423E0
		public override void Refresh(AnniversaryPersonalRewardItemData data, bool isSelected, int gridIndex)
		{
			if (data == null)
			{
				return;
			}
			this.Data = data;
			PersonProgressCurve? personProgressCurveById = ConfigBase<AnniversaryActivityConfig>.Instance.GetPersonProgressCurveById(data.CfgId);
			if (personProgressCurveById == null)
			{
				return;
			}
			EAnniversaryProgressRewardState valueOrDefault = data.State.GetValueOrDefault();
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetText(personProgressCurveById.Value.Progress.ToString(), true);
			}
			UUIText text2 = base.GetText(4);
			if (text2 != null)
			{
				text2.SetColor(this.GetProgressTextColor(valueOrDefault));
			}
			UUISprite sprite = base.GetSprite(5);
			if (sprite != null)
			{
				sprite.SetFillAmount(data.CurProgress);
			}
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(valueOrDefault == EAnniversaryProgressRewardState.Lock);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(valueOrDefault == EAnniversaryProgressRewardState.CanReceive);
			}
			UUIItem item3 = base.GetItem(3);
			if (item3 != null)
			{
				item3.SetUIActive(valueOrDefault == EAnniversaryProgressRewardState.Rewarded);
			}
			UUIItem item4 = base.GetItem(7);
			if (item4 != null)
			{
				item4.SetUIActive(personProgressCurveById.Value.ShowEffect);
			}
			if (this.RewardItem != null && personProgressCurveById.Value.DropId > 0)
			{
				Dictionary<int, int> dropPackagePreview = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreview(personProgressCurveById.Value.DropId);
				if (dropPackagePreview != null && dropPackagePreview.Count > 0)
				{
					using (Dictionary<int, int>.Enumerator enumerator = dropPackagePreview.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							KeyValuePair<int, int> keyValuePair = enumerator.Current;
							PropSmallItemGrid parameters = new PropSmallItemGrid
							{
								Data = null,
								ItemConfigId = new int?(keyValuePair.Key),
								BottomText = keyValuePair.Value.ToString(),
								IsReceivableVisible = new bool?(valueOrDefault == EAnniversaryProgressRewardState.CanReceive),
								IsReceivedVisible = new bool?(valueOrDefault == EAnniversaryProgressRewardState.Rewarded)
							};
							this.RewardItem.ApplyPropSmallItemGrid(parameters);
						}
					}
				}
			}
		}

		// Token: 0x06043310 RID: 275216 RVA: 0x011443CC File Offset: 0x011425CC
		private FColor GetProgressTextColor(EAnniversaryProgressRewardState state)
		{
			if (state == EAnniversaryProgressRewardState.CanReceive)
			{
				return FColor.FromHex("#010100FF");
			}
			if (state != EAnniversaryProgressRewardState.Rewarded)
			{
				return FColor.FromHex("#FFFFFFFF");
			}
			return FColor.FromHex("#9EFF2BFF");
		}

		// Token: 0x06043311 RID: 275217 RVA: 0x011443F8 File Offset: 0x011425F8
		private void OnClick(MediumItemGridExtendCallback _)
		{
			if (this.Data == null)
			{
				return;
			}
			Action<int> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(this.Data.CfgId);
		}

		// Token: 0x0402570D RID: 153357
		[Nullable(2)]
		private AnniversaryPersonalRewardItemData Data;

		// Token: 0x0402570E RID: 153358
		[Nullable(2)]
		private SmallItemGrid RewardItem;

		// Token: 0x0402570F RID: 153359
		[Nullable(2)]
		private Action<int> ClickCallback;

		// Token: 0x0200C960 RID: 51552
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403DEEA RID: 253674
			public const int ItemBase = 0;

			// Token: 0x0403DEEB RID: 253675
			public const int SprNor = 1;

			// Token: 0x0403DEEC RID: 253676
			public const int SprCanGet = 2;

			// Token: 0x0403DEED RID: 253677
			public const int SprFinished = 3;

			// Token: 0x0403DEEE RID: 253678
			public const int TxtValue = 4;

			// Token: 0x0403DEEF RID: 253679
			public const int SprProgressFill = 5;

			// Token: 0x0403DEF0 RID: 253680
			public const int PnlProgress = 6;

			// Token: 0x0403DEF1 RID: 253681
			public const int FxGlow = 7;
		}
	}
}
