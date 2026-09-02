using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x020066AA RID: 26282
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingRiskInstanceView : IInstanceDungeonEntranceAbility
	{
		// Token: 0x1700A02F RID: 41007
		// (get) Token: 0x06041A19 RID: 268825 RVA: 0x010D413E File Offset: 0x010D233E
		public override string ResourceId
		{
			get
			{
				return ModelBase<MowingRiskModel>.Instance.InstanceSubViewResourceId;
			}
		}

		// Token: 0x06041A1A RID: 268826 RVA: 0x010D414C File Offset: 0x010D234C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnLeftClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnRightClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041A1B RID: 268827 RVA: 0x010D4300 File Offset: 0x010D2500
		protected override UniTask OnBeforeStartAsync()
		{
			MowingRiskInstanceView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MowingRiskInstanceView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041A1C RID: 268828 RVA: 0x010D4343 File Offset: 0x010D2543
		protected override void OnBeforeDestroy()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotMowingRiskBuffAll, base.GetItem(5), 0);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotMowingRiskReward, base.GetItem(7), 0);
		}

		// Token: 0x06041A1D RID: 268829 RVA: 0x010D4373 File Offset: 0x010D2573
		protected override void OnStart()
		{
			this.InitVerticalPanels();
			Singleton<EventSystem>.Instance.Emit(EEventName.MowingRiskOnRefreshRewardRedDot);
		}

		// Token: 0x06041A1E RID: 268830 RVA: 0x010D438C File Offset: 0x010D258C
		public override UniTask RefreshExternalAsync()
		{
			MowingRiskInstanceView.<RefreshExternalAsync>d__8 <RefreshExternalAsync>d__;
			<RefreshExternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshExternalAsync>d__.<>4__this = this;
			<RefreshExternalAsync>d__.<>1__state = -1;
			<RefreshExternalAsync>d__.<>t__builder.Start<MowingRiskInstanceView.<RefreshExternalAsync>d__8>(ref <RefreshExternalAsync>d__);
			return <RefreshExternalAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041A1F RID: 268831 RVA: 0x010D43D0 File Offset: 0x010D25D0
		public override void RefreshOnTick()
		{
			MowingRiskModel instance = ModelBase<MowingRiskModel>.Instance;
			IMowingRiskInstanceDetailLockItemData data = instance.BuildInstanceDetailLockDataByInstanceId(instance.CurrentInstanceId);
			this.Detail.RefreshLockItemExternalByData(data);
		}

		// Token: 0x06041A20 RID: 268832 RVA: 0x010D43FA File Offset: 0x010D25FA
		private void OnLeftClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MowingBuffView, EMowingBuffViewUsage.BeforeBattle, null);
		}

		// Token: 0x06041A21 RID: 268833 RVA: 0x010D4412 File Offset: 0x010D2612
		private void OnRightClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRewardPopUpView, ModelBase<MowingRiskModel>.Instance.BuildActivityRewardViewData(), null);
		}

		// Token: 0x06041A22 RID: 268834 RVA: 0x010D4430 File Offset: 0x010D2630
		private UniTask CreateDetailAsync()
		{
			MowingRiskInstanceView.<CreateDetailAsync>d__12 <CreateDetailAsync>d__;
			<CreateDetailAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDetailAsync>d__.<>4__this = this;
			<CreateDetailAsync>d__.<>1__state = -1;
			<CreateDetailAsync>d__.<>t__builder.Start<MowingRiskInstanceView.<CreateDetailAsync>d__12>(ref <CreateDetailAsync>d__);
			return <CreateDetailAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041A23 RID: 268835 RVA: 0x010D4473 File Offset: 0x010D2673
		private void InitVerticalPanels()
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(true);
		}

		// Token: 0x04024A43 RID: 150083
		private MowingRiskInstanceDetailView Detail;

		// Token: 0x0200C6D0 RID: 50896
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D36E RID: 250734
			public const int DetailItem = 0;

			// Token: 0x0403D36F RID: 250735
			public const int DropDownItem = 1;

			// Token: 0x0403D370 RID: 250736
			public const int RecommendLevelItem = 2;

			// Token: 0x0403D371 RID: 250737
			public const int RecommendLevelText = 3;

			// Token: 0x0403D372 RID: 250738
			public const int LeftButton = 4;

			// Token: 0x0403D373 RID: 250739
			public const int LeftRedDotItem = 5;

			// Token: 0x0403D374 RID: 250740
			public const int RightButton = 6;

			// Token: 0x0403D375 RID: 250741
			public const int RightRedDotItem = 7;

			// Token: 0x0403D376 RID: 250742
			public const int ProgressText = 8;
		}
	}
}
