using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.BossPiling.View.Item;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005EF8 RID: 24312
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingNewBuffTipsView : UiViewBase
	{
		// Token: 0x0603D145 RID: 250181 RVA: 0x00F82E35 File Offset: 0x00F81035
		public BossPilingNewBuffTipsView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D146 RID: 250182 RVA: 0x00F82E4C File Offset: 0x00F8104C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D147 RID: 250183 RVA: 0x00F82F7C File Offset: 0x00F8117C
		protected override UniTask OnBeforeStartAsync()
		{
			BossPilingNewBuffTipsView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BossPilingNewBuffTipsView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D148 RID: 250184 RVA: 0x00F82FC0 File Offset: 0x00F811C0
		protected override void OnStart()
		{
			BossPilingNewBuffInfo bossPilingNewBuffInfo = this.OpenParam as BossPilingNewBuffInfo;
			ValueTuple<int, int> tipsPlayRate = ConfigBase<BossPilingConfig>.Instance.GetTipsPlayRate();
			int item = tipsPlayRate.Item1;
			int item2 = tipsPlayRate.Item2;
			this.PlayRate = (float)((ModelBase<BossPilingModel>.Instance.InstBuffAcquireCount > 1) ? item2 : item);
			BossPilingBuff value = ConfigBase<BossPilingConfig>.Instance.GetBuffInfo(bossPilingNewBuffInfo.BuffId).Value;
			BossPilingBuffCountPanel countPanel = this.CountPanel;
			if (countPanel != null)
			{
				countPanel.Refresh(bossPilingNewBuffInfo.OldValue, bossPilingNewBuffInfo.NewValue, value.BuffId);
			}
			QualityInfo value2 = ConfigBase<InventoryConfig>.Instance.GetItemQualityConfig(value.Quality).Value;
			FColor color = FColor.FromHex(value2.TextColor);
			this.IsGolden = (value2.Id >= 5);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(this.IsGolden ? "NS_Fx_LGUI_Item_Golden" : "NS_Fx_LGUI_Item_Other");
			Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraSystem>(resourcePath, delegate([Nullable(2)] UNiagaraSystem niagaraSystem, string _)
			{
				if (niagaraSystem == null || !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BossPilingNewBuffTipsView) || this.RootItem == null)
				{
					return;
				}
				UUINiagara uiNiagara = this.GetUiNiagara(5);
				uiNiagara.SetNiagaraSystem(niagaraSystem);
				if (!this.IsGolden)
				{
					uiNiagara.ColorParameter.Get("Color").Constant = FLinearColor.FromSRGBColor(color);
				}
			}, ResourceSystem.EResourceLoadPriority.Default, this.MemoryTag);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), value.Desc, value.DescArgs());
			this.BuffItem.Refresh(bossPilingNewBuffInfo.BuffId, false, 0);
			this.RefreshQualityTexture(value2.TextureAcquireBg, value2.TextureAcquireFlow);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
			{
				if (sequenceName == "Golden" || sequenceName == "Start01")
				{
					this.CloseMe(null);
				}
			}, false);
			UUIItem item3 = base.GetItem(6);
			if (item3 != null)
			{
				item3.SetUIActive(bossPilingNewBuffInfo.OldValue == 0);
			}
			UUITexture texture = base.GetTexture(0);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(false);
		}

		// Token: 0x0603D149 RID: 250185 RVA: 0x00F83190 File Offset: 0x00F81390
		private void RefreshQualityTexture(string bgPath, string flowPath)
		{
			base.SetTextureByPath(bgPath, base.GetTexture(4), null, null);
			base.SetTextureByPath(flowPath, base.GetTexture(7), null, null);
		}

		// Token: 0x0603D14A RID: 250186 RVA: 0x00F831D0 File Offset: 0x00F813D0
		protected override void OnAfterShow()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName(this.IsGolden ? "Golden" : "Start01", false, new float?(this.PlayRate), false);
			}
			BossPilingBuffCountPanel countPanel = this.CountPanel;
			if (countPanel == null)
			{
				return;
			}
			countPanel.PlaySequence(this.PlayRate);
		}

		// Token: 0x0603D14B RID: 250187 RVA: 0x00F83225 File Offset: 0x00F81425
		protected override void OnBeforeDestroy()
		{
			ModelBase<BossPilingModel>.Instance.InstBuffAcquireCount--;
			ModelBase<ItemModel>.Instance.LastCloseTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		}

		// Token: 0x04022429 RID: 140329
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0402242A RID: 140330
		private bool IsGolden;

		// Token: 0x0402242B RID: 140331
		[Nullable(2)]
		private BossPilingBuffCountPanel CountPanel;

		// Token: 0x0402242C RID: 140332
		protected BossPilingBuffSimpleItem BuffItem;

		// Token: 0x0402242D RID: 140333
		protected float PlayRate = 1f;

		// Token: 0x0200BEF0 RID: 48880
		[NullableContext(0)]
		private enum ENewItemTipsViewCom
		{
			// Token: 0x0403AC3E RID: 240702
			MainTypeIconTexture,
			// Token: 0x0403AC3F RID: 240703
			ItemNameText,
			// Token: 0x0403AC40 RID: 240704
			BuffItem,
			// Token: 0x0403AC41 RID: 240705
			ItemDescribeText,
			// Token: 0x0403AC42 RID: 240706
			QualityTexture,
			// Token: 0x0403AC43 RID: 240707
			QualityNiagara,
			// Token: 0x0403AC44 RID: 240708
			NewPanel,
			// Token: 0x0403AC45 RID: 240709
			FlowTexture
		}
	}
}
