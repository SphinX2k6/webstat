using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Menu.DropDownLogic;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.Views
{
	// Token: 0x02005772 RID: 22386
	public class MenuScrollSettingDropDown : MenuScrollSettingBaseItem
	{
		// Token: 0x06038F90 RID: 233360 RVA: 0x00E6FA54 File Offset: 0x00E6DC54
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIExtendToggleSpriteTransition))
			};
		}

		// Token: 0x06038F91 RID: 233361 RVA: 0x00E6FAF0 File Offset: 0x00E6DCF0
		[NullableContext(1)]
		private TableTextArgNew GetDropDownTextId(object data)
		{
			return this.Logic.GetDataTextId(data, this.Data);
		}

		// Token: 0x06038F92 RID: 233362 RVA: 0x00E6FB04 File Offset: 0x00E6DD04
		protected override UniTask OnBeforeStartAsync()
		{
			MenuScrollSettingDropDown.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MenuScrollSettingDropDown.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038F93 RID: 233363 RVA: 0x00E6FB47 File Offset: 0x00E6DD47
		protected override void OnStart()
		{
		}

		// Token: 0x06038F94 RID: 233364 RVA: 0x00E6FB49 File Offset: 0x00E6DD49
		protected override void OnBeforeDestroy()
		{
			this.DropDown.Destroy(null);
		}

		// Token: 0x06038F95 RID: 233365 RVA: 0x00E6FB57 File Offset: 0x00E6DD57
		private void RefreshTitle()
		{
			base.GetText(0).ShowTextNew(this.Data.FunctionName ?? "");
		}

		// Token: 0x06038F96 RID: 233366 RVA: 0x00E6FB7C File Offset: 0x00E6DD7C
		private void RefreshDropDown()
		{
			this.Logic = DropDownLogicCreator.GetDropDownLogic(this.Data.FunctionId);
			if (this.Logic == null)
			{
				return;
			}
			IReadOnlyList<object> dropDownDataList = this.Logic.GetDropDownDataList();
			int defaultIndex = this.Logic.GetDefaultIndex(this.Data);
			this.DropDown.InitScroll(dropDownDataList, new Func<object, TableTextArgNew>(this.GetDropDownTextId), defaultIndex, true);
		}

		// Token: 0x06038F97 RID: 233367 RVA: 0x00E6FBE0 File Offset: 0x00E6DDE0
		[NullableContext(1)]
		public override void Update(MenuData data, bool bGameSettingsUpdate)
		{
			this.Data = data;
			this.RefreshTitle();
			this.RefreshDropDown();
			this.RefreshDetailText();
			this.RefreshDetailSpriteVisible();
			this.RefreshDetailSprite().Forget();
		}

		// Token: 0x06038F98 RID: 233368 RVA: 0x00E6FC0C File Offset: 0x00E6DE0C
		public override UniTask ClearAsync()
		{
			MenuScrollSettingDropDown.<ClearAsync>d__11 <ClearAsync>d__;
			<ClearAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ClearAsync>d__.<>4__this = this;
			<ClearAsync>d__.<>1__state = -1;
			<ClearAsync>d__.<>t__builder.Start<MenuScrollSettingDropDown.<ClearAsync>d__11>(ref <ClearAsync>d__);
			return <ClearAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038F99 RID: 233369 RVA: 0x00E6FC4F File Offset: 0x00E6DE4F
		public override void SetInteractionActive(bool val)
		{
		}

		// Token: 0x06038F9A RID: 233370 RVA: 0x00E6FC54 File Offset: 0x00E6DE54
		protected override void OnSetDetailVisible(bool bVisible)
		{
			UUIItem item = base.GetItem(2);
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
				base.GetSprite(4).SetColor(color);
				base.GetUiExtendToggleSpriteTransition(5).TransitionState.UnDetermineUnHoverState.Color = color;
				base.GetUiExtendToggleSpriteTransition(5).TransitionState.UnDetermineHoverState.Color = color;
				base.GetUiExtendToggleSpriteTransition(5).TransitionState.UnDeterminePressedState.Color = color;
			}
		}

		// Token: 0x06038F9B RID: 233371 RVA: 0x00E6FD04 File Offset: 0x00E6DF04
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
			UUIText text = base.GetText(3);
			string detailTextId = this.Data.GetDetailTextId();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, detailTextId, Array.Empty<object>());
		}

		// Token: 0x06038F9C RID: 233372 RVA: 0x00E6FD4D File Offset: 0x00E6DF4D
		private void RefreshDetailSpriteVisible()
		{
			if (this.Data == null)
			{
				return;
			}
			UUISprite sprite = base.GetSprite(4);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(this.Data.ShowHelpBtn());
		}

		// Token: 0x06038F9D RID: 233373 RVA: 0x00E6FD74 File Offset: 0x00E6DF74
		public UniTask RefreshDetailSprite()
		{
			MenuScrollSettingDropDown.<RefreshDetailSprite>d__16 <RefreshDetailSprite>d__;
			<RefreshDetailSprite>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshDetailSprite>d__.<>4__this = this;
			<RefreshDetailSprite>d__.<>1__state = -1;
			<RefreshDetailSprite>d__.<>t__builder.Start<MenuScrollSettingDropDown.<RefreshDetailSprite>d__16>(ref <RefreshDetailSprite>d__);
			return <RefreshDetailSprite>d__.<>t__builder.Task;
		}

		// Token: 0x040206FE RID: 132862
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private CommonDropDown<TableTextArgNew, object> DropDown;

		// Token: 0x040206FF RID: 132863
		[Nullable(2)]
		private DropDownLogicBase Logic;

		// Token: 0x0200B80D RID: 47117
		private class ECompDefine
		{
			// Token: 0x04038EEB RID: 233195
			public const int Title = 0;

			// Token: 0x04038EEC RID: 233196
			public const int DropDown = 1;

			// Token: 0x04038EED RID: 233197
			public const int DetailItem = 2;

			// Token: 0x04038EEE RID: 233198
			public const int DetailText = 3;

			// Token: 0x04038EEF RID: 233199
			public const int DetailSprite = 4;

			// Token: 0x04038EF0 RID: 233200
			public const int DetailToggleTransition = 5;
		}
	}
}
