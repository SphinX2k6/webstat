using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.Views
{
	// Token: 0x02005774 RID: 22388
	public class MenuScrollSettingSwitchItem : MenuScrollSettingBaseItem
	{
		// Token: 0x06038FB3 RID: 233395 RVA: 0x00E70274 File Offset: 0x00E6E474
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUISprite)),
				new ValueTuple<int, Type>(8, typeof(UUIExtendToggleSpriteTransition))
			};
		}

		// Token: 0x06038FB4 RID: 233396 RVA: 0x00E70352 File Offset: 0x00E6E552
		protected override void OnStart()
		{
			base.GetButton(3).SetCanClickWhenDisable(true);
			base.GetButton(2).SetCanClickWhenDisable(true);
			this.AddOptionsEvent();
		}

		// Token: 0x06038FB5 RID: 233397 RVA: 0x00E70374 File Offset: 0x00E6E574
		protected override void OnClear()
		{
			if (this.Data != null)
			{
				this.Data = null;
			}
			base.GetButton(2).OnClickCallBack.Unbind();
			base.GetButton(3).OnClickCallBack.Unbind();
		}

		// Token: 0x06038FB6 RID: 233398 RVA: 0x00E703A7 File Offset: 0x00E6E5A7
		[NullableContext(1)]
		public override void Update(MenuData data, bool bGameSettingsUpdate)
		{
			this.Data = data;
			this.RefreshTitle();
			this.RefreshOptions();
			this.RefreshDetailText();
			this.RefreshDetailSpriteVisible();
			this.RefreshDetailSprite().Forget();
		}

		// Token: 0x06038FB7 RID: 233399 RVA: 0x00E703D3 File Offset: 0x00E6E5D3
		private void RefreshTitle()
		{
			base.GetText(0).ShowTextNew(this.Data.FunctionName ?? "");
		}

		// Token: 0x06038FB8 RID: 233400 RVA: 0x00E703F8 File Offset: 0x00E6E5F8
		private void RefreshOptions()
		{
			base.GetRootItem().SetUIActive(true);
			int index = this.GetIndex();
			this.SetOptionsText(index);
			this.RefreshInteractionGroup(index, true);
		}

		// Token: 0x06038FB9 RID: 233401 RVA: 0x00E70427 File Offset: 0x00E6E627
		private void AddOptionsEvent()
		{
			base.GetButton(2).OnClickCallBack.Bind(new Action(this.OnLeftClickCallback));
			base.GetButton(3).OnClickCallBack.Bind(new Action(this.OnRightClickCallback));
		}

		// Token: 0x06038FBA RID: 233402 RVA: 0x00E70464 File Offset: 0x00E6E664
		public override void SetInteractionActive(bool val)
		{
			int index = this.GetIndex();
			this.RefreshInteractionGroup(index, val);
		}

		// Token: 0x06038FBB RID: 233403 RVA: 0x00E70480 File Offset: 0x00E6E680
		private void SetOptionsText(int index)
		{
			if (!this.Data.GetEnable())
			{
				string disableOverrideText = this.Data.GetDisableOverrideText();
				if (disableOverrideText != null)
				{
					base.GetText(1).ShowTextNew(disableOverrideText);
					return;
				}
			}
			string key = this.Data.OptionsNameList[index];
			if (this.NeedImageQualityCustomSpecial())
			{
				key = "MenuConfig_5_OptionsName_4";
			}
			base.GetText(1).ShowTextNew(key);
			base.GetSprite(7).SetUIActive(this.Data.IsRecommendIndex(index));
		}

		// Token: 0x06038FBC RID: 233404 RVA: 0x00E704FC File Offset: 0x00E6E6FC
		public void RefreshInteractionGroup(int index, bool active = true)
		{
			if (active)
			{
				base.GetButton(3).SetSelfInteractive(this.NeedImageQualityCustomSpecial() || index != this.Data.OptionsNameList.Count - 1);
				base.GetButton(2).SetSelfInteractive(this.NeedImageQualityCustomSpecial() || index != 0);
				return;
			}
			base.GetButton(3).SetSelfInteractive(false);
			base.GetButton(2).SetSelfInteractive(false);
		}

		// Token: 0x06038FBD RID: 233405 RVA: 0x00E70571 File Offset: 0x00E6E771
		private void OnLeftClickCallback()
		{
			if (base.GetItemClickLimit(base.GetButton(2)))
			{
				return;
			}
			this.ClickCallbackFromCheckIndex(-1);
		}

		// Token: 0x06038FBE RID: 233406 RVA: 0x00E7058A File Offset: 0x00E6E78A
		private void OnRightClickCallback()
		{
			if (base.GetItemClickLimit(base.GetButton(3)))
			{
				return;
			}
			this.ClickCallbackFromCheckIndex(1);
		}

		// Token: 0x06038FBF RID: 233407 RVA: 0x00E705A4 File Offset: 0x00E6E7A4
		private void ClickCallbackFromCheckIndex(int index)
		{
			int index2 = (int)Math.Floor((double)((float)this.GetIndex() + (float)index));
			if (this.NeedImageQualityCustomSpecial())
			{
				if (index > 0)
				{
					index2 = 0;
				}
				else
				{
					index2 = this.Data.OptionsNameList.Count - 1;
				}
			}
			this.FireSaveMenuChange(this.Data.OptionsValueList[index2]);
		}

		// Token: 0x06038FC0 RID: 233408 RVA: 0x00E70602 File Offset: 0x00E6E802
		private bool NeedImageQualityCustomSpecial()
		{
			return this.Data.FunctionId == EFunction.IMAGEQUALITY && ModelBase<MenuModel>.Instance.IsImageQualityCustom;
		}

		// Token: 0x06038FC1 RID: 233409 RVA: 0x00E70620 File Offset: 0x00E6E820
		protected unsafe int GetIndex()
		{
			MenuModel instance = ModelBase<MenuModel>.Instance;
			int? num = (instance != null) ? instance.GetDataCacheOrCurValue(this.Data.FunctionId) : null;
			IReadOnlyList<int> optionsValueList = this.Data.OptionsValueList;
			int num2 = optionsValueList.IndexOf(num.Value);
			if (num2 < 0)
			{
				int optionsDefault = this.Data.OptionsDefault;
				int num3 = optionsValueList.IndexOf(optionsDefault);
				if (num3 < 0)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Menu;
					ELogAuthor author = ELogAuthor.WZ;
					string message = "默认值不存在于可选值列表中，请策划策划策划检查配置";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", this.Data.FunctionId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Default Value", optionsDefault);
					instance2.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				num2 = num3;
			}
			return num2;
		}

		// Token: 0x06038FC2 RID: 233410 RVA: 0x00E706F8 File Offset: 0x00E6E8F8
		protected override void OnSetDetailVisible(bool bVisible)
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(bVisible);
			}
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.CanClickWhenDisable && !this.Data.GetEnable())
			{
				FColor color = bVisible ? FColor.FromHex("FFF7B6FF") : FColor.FromHex("FFFFFFFF");
				base.GetSprite(6).SetColor(color);
				base.GetUiExtendToggleSpriteTransition(8).TransitionState.UnDetermineUnHoverState.Color = color;
				base.GetUiExtendToggleSpriteTransition(8).TransitionState.UnDetermineHoverState.Color = color;
				base.GetUiExtendToggleSpriteTransition(8).TransitionState.UnDeterminePressedState.Color = color;
			}
		}

		// Token: 0x06038FC3 RID: 233411 RVA: 0x00E707A8 File Offset: 0x00E6E9A8
		private void RefreshDetailText()
		{
			if (this.Data == null)
			{
				return;
			}
			if (!this.Data.HasDetailText())
			{
				return;
			}
			UUIText text = base.GetText(5);
			string detailTextId = this.Data.GetDetailTextId();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, detailTextId, Array.Empty<object>());
		}

		// Token: 0x06038FC4 RID: 233412 RVA: 0x00E707F1 File Offset: 0x00E6E9F1
		private void RefreshDetailSpriteVisible()
		{
			if (this.Data == null)
			{
				return;
			}
			UUISprite sprite = base.GetSprite(6);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(this.Data.ShowHelpBtn());
		}

		// Token: 0x06038FC5 RID: 233413 RVA: 0x00E70818 File Offset: 0x00E6EA18
		public UniTask RefreshDetailSprite()
		{
			MenuScrollSettingSwitchItem.<RefreshDetailSprite>d__19 <RefreshDetailSprite>d__;
			<RefreshDetailSprite>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshDetailSprite>d__.<>4__this = this;
			<RefreshDetailSprite>d__.<>1__state = -1;
			<RefreshDetailSprite>d__.<>t__builder.Start<MenuScrollSettingSwitchItem.<RefreshDetailSprite>d__19>(ref <RefreshDetailSprite>d__);
			return <RefreshDetailSprite>d__.<>t__builder.Task;
		}

		// Token: 0x0200B814 RID: 47124
		private class EComponents
		{
			// Token: 0x04038F0C RID: 233228
			public const int Title = 0;

			// Token: 0x04038F0D RID: 233229
			public const int TitleName = 1;

			// Token: 0x04038F0E RID: 233230
			public const int LeftBtn = 2;

			// Token: 0x04038F0F RID: 233231
			public const int RightBtn = 3;

			// Token: 0x04038F10 RID: 233232
			public const int DetailItem = 4;

			// Token: 0x04038F11 RID: 233233
			public const int DetailText = 5;

			// Token: 0x04038F12 RID: 233234
			public const int DetailSprite = 6;

			// Token: 0x04038F13 RID: 233235
			public const int RecommendIcon = 7;

			// Token: 0x04038F14 RID: 233236
			public const int DetailToggleTransition = 8;
		}
	}
}
