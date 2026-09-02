using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200669F RID: 26271
	public class MowingBuffNewBuffTipsView : UiTickViewBase, INewItemTipsViewLike
	{
		// Token: 0x060419A8 RID: 268712 RVA: 0x010D2320 File Offset: 0x010D0520
		[NullableContext(1)]
		public MowingBuffNewBuffTipsView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060419A9 RID: 268713 RVA: 0x010D2329 File Offset: 0x010D0529
		public void RefreshMainTypeIconTexture()
		{
			UUITexture texture = base.GetTexture(0);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(false);
		}

		// Token: 0x060419AA RID: 268714 RVA: 0x010D2340 File Offset: 0x010D0540
		public void RefreshItemNameText()
		{
			if (this.Color != null)
			{
				UUIText text = base.GetText(1);
				if (text != null)
				{
					text.SetColor(this.Color.Value);
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.PassData.NameTextId, Array.Empty<object>());
		}

		// Token: 0x060419AB RID: 268715 RVA: 0x010D2398 File Offset: 0x010D0598
		public void RefreshItemIconTexture()
		{
			base.SetTextureByPath(this.PassData.IconPath, base.GetTexture(2), null, null);
		}

		// Token: 0x060419AC RID: 268716 RVA: 0x010D23C7 File Offset: 0x010D05C7
		public void RefreshItemDescribeText()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.PassData.DescriptionTextId, this.PassData.DescriptionArgs);
		}

		// Token: 0x060419AD RID: 268717 RVA: 0x010D23F0 File Offset: 0x010D05F0
		public void RefreshQualityTexture()
		{
			base.SetTextureByPath(this.PassData.QualityTexPath, base.GetTexture(4), null, null);
			base.SetTextureByPath(this.PassData.QualityFlowPath, base.GetTexture(7), null, null);
		}

		// Token: 0x060419AE RID: 268718 RVA: 0x010D2444 File Offset: 0x010D0644
		public void RefreshQualityNiagara()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(this.PassData.IsGolden ? "NS_Fx_LGUI_Item_Golden" : "NS_Fx_LGUI_Item_Other");
			Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraSystem>(resourcePath, delegate([Nullable(2)] UNiagaraSystem niagaraSystem, string path)
			{
				if (niagaraSystem == null || !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.NewItemTipsView) || this.RootItem == null)
				{
					return;
				}
				UUINiagara uiNiagara = base.GetUiNiagara(5);
				uiNiagara.SetNiagaraSystem(niagaraSystem);
				if (!this.PassData.IsGolden && this.Color != null)
				{
					FKuroCurveLinearColor fkuroCurveLinearColor = uiNiagara.ColorParameter.Get("Color");
					FColor value = this.Color.Value;
					fkuroCurveLinearColor.Constant = FLinearColor.FromSRGBColor(value);
				}
			}, 100, this.MemoryTag);
		}

		// Token: 0x060419AF RID: 268719 RVA: 0x010D2498 File Offset: 0x010D0698
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060419B0 RID: 268720 RVA: 0x010D25A8 File Offset: 0x010D07A8
		protected override void OnStart()
		{
			if (this.OpenParam == null)
			{
				base.CloseMe(null);
				return;
			}
			this.PassData = (this.OpenParam as IMowingRiskNewBasicBuffTipsData);
			this.Color = new FColor?(FColor.FromHex(this.PassData.NameHexColor));
			this.RefreshMainTypeIconTexture();
			this.RefreshItemNameText();
			this.RefreshItemIconTexture();
			this.RefreshItemDescribeText();
			this.RefreshQualityTexture();
			this.RefreshQualityNiagara();
		}

		// Token: 0x060419B1 RID: 268721 RVA: 0x010D2618 File Offset: 0x010D0818
		protected override UniTask OnBeforeStartAsync()
		{
			MowingBuffNewBuffTipsView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MowingBuffNewBuffTipsView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419B2 RID: 268722 RVA: 0x010D265B File Offset: 0x010D085B
		protected override void OnAfterShow()
		{
			this.HandleOnAfterShowAsync().Forget();
		}

		// Token: 0x060419B3 RID: 268723 RVA: 0x010D2668 File Offset: 0x010D0868
		protected override void OnAfterDestroy()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.MowingRiskOnBuffTipsAfterDestroy);
		}

		// Token: 0x060419B4 RID: 268724 RVA: 0x010D267C File Offset: 0x010D087C
		private UniTask HandleOnAfterShowAsync()
		{
			MowingBuffNewBuffTipsView.<HandleOnAfterShowAsync>d__16 <HandleOnAfterShowAsync>d__;
			<HandleOnAfterShowAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleOnAfterShowAsync>d__.<>4__this = this;
			<HandleOnAfterShowAsync>d__.<>1__state = -1;
			<HandleOnAfterShowAsync>d__.<>t__builder.Start<MowingBuffNewBuffTipsView.<HandleOnAfterShowAsync>d__16>(ref <HandleOnAfterShowAsync>d__);
			return <HandleOnAfterShowAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04024A26 RID: 150054
		[Nullable(1)]
		private UiSequencePlayer UiSequencePlayer;

		// Token: 0x04024A27 RID: 150055
		[Nullable(1)]
		private IMowingRiskNewBasicBuffTipsData PassData;

		// Token: 0x04024A28 RID: 150056
		private FColor? Color;

		// Token: 0x0200C6AA RID: 50858
		private class ENewItemTipsViewLikeComponent
		{
			// Token: 0x0403D2C3 RID: 250563
			public const int MainTypeIconTexture = 0;

			// Token: 0x0403D2C4 RID: 250564
			public const int ItemNameText = 1;

			// Token: 0x0403D2C5 RID: 250565
			public const int ItemIconTexture = 2;

			// Token: 0x0403D2C6 RID: 250566
			public const int ItemDescribeText = 3;

			// Token: 0x0403D2C7 RID: 250567
			public const int QualityTexture = 4;

			// Token: 0x0403D2C8 RID: 250568
			public const int QualityNiagara = 5;

			// Token: 0x0403D2C9 RID: 250569
			public const int FlowTexture = 7;
		}
	}
}
