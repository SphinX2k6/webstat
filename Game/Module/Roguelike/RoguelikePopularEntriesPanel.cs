using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005154 RID: 20820
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikePopularEntriesPanel : UiPanelBase
	{
		// Token: 0x0603597C RID: 219516 RVA: 0x00D75DB4 File Offset: 0x00D73FB4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603597D RID: 219517 RVA: 0x00D76018 File Offset: 0x00D74218
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikePopularEntriesPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikePopularEntriesPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603597E RID: 219518 RVA: 0x00D7605B File Offset: 0x00D7425B
		private RoguelikePopularEntriesGroup CreateEntriesGroupItem()
		{
			return new RoguelikePopularEntriesGroup
			{
				IsLastGroup = new Func<int, bool>(this.IsLastGroup)
			};
		}

		// Token: 0x0603597F RID: 219519 RVA: 0x00D76074 File Offset: 0x00D74274
		private RoguelikePopularEntryTypeItem CreateEntriesTypeItem()
		{
			return new RoguelikePopularEntryTypeItem();
		}

		// Token: 0x06035980 RID: 219520 RVA: 0x00D7607B File Offset: 0x00D7427B
		private bool IsLastGroup(int index)
		{
			return index == ModelBase<RoguelikeModel>.Instance.GetEntranceViewModel().EntriesDataGroupList.Count - 1;
		}

		// Token: 0x06035981 RID: 219521 RVA: 0x00D76096 File Offset: 0x00D74296
		public void Refresh(RoguelikeEntranceViewModel vm)
		{
			if (vm.CurrentSelectEntryData != null)
			{
				this.RefreshSelectEntry(vm, vm.CurrentSelectEntryData, false);
			}
		}

		// Token: 0x06035982 RID: 219522 RVA: 0x00D760B0 File Offset: 0x00D742B0
		public void ScrollToGroup(int groupId)
		{
			UUIItem itemByKey = this.LayoutEntriesGroup.GetItemByKey(groupId);
			if (itemByKey != null)
			{
				this.LayoutEntriesGroup.LateScrollTo(itemByKey, null, true);
			}
		}

		// Token: 0x06035983 RID: 219523 RVA: 0x00D760E0 File Offset: 0x00D742E0
		public void RefreshSelectEntry(RoguelikeEntranceViewModel vm, RoguelikeEntryData entryData, bool isSwitch = false)
		{
			RogueHotEntryType? rogueHotEntryTypeConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueHotEntryTypeConfig((int)entryData.Type);
			FColor color = FColor.FromHex(rogueHotEntryTypeConfig.Value.DescRingColor);
			UUITexture texture = base.GetTexture(4);
			if (texture != null)
			{
				texture.SetColor(color);
			}
			base.SetTextureByPath(rogueHotEntryTypeConfig.Value.Icon, base.GetTexture(8), null, null);
			UUIText text = base.GetText(9);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, rogueHotEntryTypeConfig.Value.Name, Array.Empty<object>());
			FColor color2 = FColor.FromHex(rogueHotEntryTypeConfig.Value.NameColor);
			text.SetColor(color2);
			UUISprite sprite = base.GetSprite(16);
			this.SetSpriteByPath(rogueHotEntryTypeConfig.Value.FrameIcon, sprite, false, null, null);
			UUIText text2 = base.GetText(12);
			bool entryDataActiveState = vm.GetEntryDataActiveState(entryData);
			string textStringId = vm.EntriesDataGroupMap[entryData.GroupId].IsUnlock ? (entryDataActiveState ? "RogueHotEntry_Activate" : "RogueHotEntry_Unactivate") : "RogueHotEntry_Lock";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, textStringId, Array.Empty<object>());
			UUIItem uuiitem = text2;
			bool bUseChangeColor = !entryDataActiveState;
			FColor? fcolor = new FColor?(text2.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			base.GetItem(10).SetUIActive(!entryDataActiveState);
			base.GetItem(11).SetUIActive(entryDataActiveState);
			RogueHotEntry config = entryData.GetConfig();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), config.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), config.Desc, config.DescParam());
			string icon = config.Icon;
			bool flag = icon.Contains("Atlas");
			UUITexture texture2 = base.GetTexture(5);
			texture2.SetUIActive(!flag);
			UUISprite sprite2 = base.GetSprite(6);
			sprite2.SetUIActive(flag);
			if (flag)
			{
				this.SetSpriteByPath(icon, sprite2, false, null, null);
			}
			else
			{
				base.SetTextureByPath(icon, texture2, null, null);
			}
			if (isSwitch)
			{
				base.GetUiNiagara(14).ActivateSystem(true);
				this.LevelSequencePlayer.PlayOrReplaySequenceByName("Sle", false, null);
			}
		}

		// Token: 0x0401EC8C RID: 126092
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RoguelikePopularEntriesGroup, RoguelikeEntriesGroupData> LayoutEntriesGroup;

		// Token: 0x0401EC8D RID: 126093
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoguelikePopularEntryTypeItem, ERoguelikeEntryType> LayoutEntriesType;

		// Token: 0x0401EC8E RID: 126094
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200B101 RID: 45313
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036E77 RID: 224887
			public const int LayoutIcon = 0;

			// Token: 0x04036E78 RID: 224888
			public const int ItemIcon = 1;

			// Token: 0x04036E79 RID: 224889
			public const int LayoutEntriesGroup = 2;

			// Token: 0x04036E7A RID: 224890
			public const int ItemEntriesGroup = 3;

			// Token: 0x04036E7B RID: 224891
			public const int TexEntryTypeRing = 4;

			// Token: 0x04036E7C RID: 224892
			public const int TexEntry = 5;

			// Token: 0x04036E7D RID: 224893
			public const int SpriteEntry = 6;

			// Token: 0x04036E7E RID: 224894
			public const int TxtEntryName = 7;

			// Token: 0x04036E7F RID: 224895
			public const int TexEntryTypeIcon = 8;

			// Token: 0x04036E80 RID: 224896
			public const int TxtTypeName = 9;

			// Token: 0x04036E81 RID: 224897
			public const int ItemDeactivate = 10;

			// Token: 0x04036E82 RID: 224898
			public const int ItemActive = 11;

			// Token: 0x04036E83 RID: 224899
			public const int TxtActive = 12;

			// Token: 0x04036E84 RID: 224900
			public const int TxtEntryDesc = 13;

			// Token: 0x04036E85 RID: 224901
			public const int NiagaraTxtEntryDesc = 14;

			// Token: 0x04036E86 RID: 224902
			public const int PanelEntry = 15;

			// Token: 0x04036E87 RID: 224903
			public const int FrameIcon = 16;
		}
	}
}
