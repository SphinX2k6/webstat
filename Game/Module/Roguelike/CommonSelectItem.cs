using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200514B RID: 20811
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CommonSelectItem : GridProxyAbstract<RogueGainEntry>
	{
		// Token: 0x06035902 RID: 219394 RVA: 0x00D72744 File Offset: 0x00D70944
		public void SetClickCallBack(Action<CommonSelectItem> callback)
		{
			this.ClickCallBack = callback;
		}

		// Token: 0x06035903 RID: 219395 RVA: 0x00D7274D File Offset: 0x00D7094D
		protected override void OnStart()
		{
			this.GenericLayout = new GenericLayout<CommonElementItem, int>(base.GetHorizontalLayout(3), new Func<CommonElementItem>(this.CreateElement), null, false, true);
		}

		// Token: 0x06035904 RID: 219396 RVA: 0x00D72770 File Offset: 0x00D70970
		private CommonElementItem CreateElement()
		{
			return new CommonElementItem();
		}

		// Token: 0x06035905 RID: 219397 RVA: 0x00D72777 File Offset: 0x00D70977
		public override void Refresh(RogueGainEntry data, bool isSelected, int gridIndex)
		{
			this.Update(data);
		}

		// Token: 0x06035906 RID: 219398 RVA: 0x00D72780 File Offset: 0x00D70980
		public void Update(RogueGainEntry rogueGainEntry)
		{
			if (rogueGainEntry.RoguelikeGainDataType.GetValueOrDefault() != RoguelikeGainDataType.CommonBuff)
			{
				return;
			}
			this.RogueGainEntry = rogueGainEntry;
			this.InitData();
		}

		// Token: 0x06035907 RID: 219399 RVA: 0x00D727A0 File Offset: 0x00D709A0
		private void InitData()
		{
			List<ElementInfo> sortElementInfoArrayByCount = this.RogueGainEntry.GetSortElementInfoArrayByCount(false);
			if (sortElementInfoArrayByCount.Count <= 0)
			{
				return;
			}
			this.ElementInfo = sortElementInfoArrayByCount[0];
			int[] data = Enumerable.Repeat<int>(this.ElementInfo.ElementId, this.ElementInfo.Count).ToArray<int>();
			this.GenericLayout.RefreshByDataAsync(data, false, null).ContinueWith(new Action(this.RefreshPanel));
		}

		// Token: 0x06035908 RID: 219400 RVA: 0x00D7281A File Offset: 0x00D70A1A
		public void SetToggleUnDetermined()
		{
			base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
		}

		// Token: 0x06035909 RID: 219401 RVA: 0x00D72830 File Offset: 0x00D70A30
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.SelfToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603590A RID: 219402 RVA: 0x00D729E0 File Offset: 0x00D70BE0
		private void SelfToggle(EToggleState state)
		{
			Action<CommonSelectItem> clickCallBack = this.ClickCallBack;
			if (clickCallBack == null)
			{
				return;
			}
			clickCallBack((state == EToggleState.ETT_Checked) ? this : null);
		}

		// Token: 0x0603590B RID: 219403 RVA: 0x00D729FA File Offset: 0x00D70BFA
		public bool IsSelect()
		{
			return base.GetExtendToggle(5).GetToggleState() == EToggleState.ETT_Checked;
		}

		// Token: 0x0603590C RID: 219404 RVA: 0x00D72A0B File Offset: 0x00D70C0B
		public void RefreshPanel()
		{
			if (this.RogueGainEntry == null)
			{
				return;
			}
			this.RefreshCommon();
			this.RefreshCommonElementItem();
		}

		// Token: 0x0603590D RID: 219405 RVA: 0x00D72A24 File Offset: 0x00D70C24
		private void RefreshCommon()
		{
			base.GetItem(6).SetUIActive(this.RogueGainEntry.IsNew);
			RogueBuffPool? rogueBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueBuffConfig(this.RogueGainEntry.ConfigId);
			if (rogueBuffConfig == null)
			{
				return;
			}
			base.GetText(2).ShowTextNew(rogueBuffConfig.Value.BuffName);
			if (ModelBase<RoguelikeModel>.Instance.GetDescModel() == EDescModel.SIMPLE)
			{
				base.GetText(4).ShowTextNew(rogueBuffConfig.Value.BuffDescSimple);
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), rogueBuffConfig.Value.BuffDesc, rogueBuffConfig.Value.BuffDescParam());
			}
			base.SetTextureByPath(rogueBuffConfig.Value.BuffIcon, base.GetTexture(1), null, null);
			RogueQualityConfig? rogueQualityConfigByQualityId = ConfigBase<RoguelikeConfig>.Instance.GetRogueQualityConfigByQualityId(rogueBuffConfig.Value.Quality);
			if (rogueQualityConfigByQualityId != null)
			{
				base.SetTextureByPath(rogueQualityConfigByQualityId.Value.TokenBg, base.GetTexture(0), null, null);
			}
			base.GetSprite(7).SetColor(FColor.FromHex(rogueQualityConfigByQualityId.Value.TokenColor));
			base.GetItem(9).SetUIActive(rogueBuffConfig.Value.Quality == 5);
			base.GetItem(8).SetUIActive(rogueBuffConfig.Value.Quality == 6);
		}

		// Token: 0x0603590E RID: 219406 RVA: 0x00D72BAC File Offset: 0x00D70DAC
		private void RefreshCommonElementItem()
		{
			int[] data = Enumerable.Repeat<int>(this.ElementInfo.ElementId, this.ElementInfo.Count).ToArray<int>();
			GenericLayout<CommonElementItem, int> genericLayout = this.GenericLayout;
			if (genericLayout == null)
			{
				return;
			}
			genericLayout.RefreshByDataAsync(data, false, null);
		}

		// Token: 0x0401EC59 RID: 126041
		public RogueGainEntry RogueGainEntry;

		// Token: 0x0401EC5A RID: 126042
		private ElementInfo ElementInfo;

		// Token: 0x0401EC5B RID: 126043
		private GenericLayout<CommonElementItem, int> GenericLayout;

		// Token: 0x0401EC5C RID: 126044
		public Action<CommonSelectItem> ClickCallBack;

		// Token: 0x0200B0EB RID: 45291
		[NullableContext(0)]
		private class ECommonSelectItemCom
		{
			// Token: 0x04036E06 RID: 224774
			public const int QualityBgTexture = 0;

			// Token: 0x04036E07 RID: 224775
			public const int IconTexture = 1;

			// Token: 0x04036E08 RID: 224776
			public const int NameText = 2;

			// Token: 0x04036E09 RID: 224777
			public const int ElementLayout = 3;

			// Token: 0x04036E0A RID: 224778
			public const int DescText = 4;

			// Token: 0x04036E0B RID: 224779
			public const int SelfToggle = 5;

			// Token: 0x04036E0C RID: 224780
			public const int NewItem = 6;

			// Token: 0x04036E0D RID: 224781
			public const int QualityLineSprite = 7;

			// Token: 0x04036E0E RID: 224782
			public const int GoldItem = 8;

			// Token: 0x04036E0F RID: 224783
			public const int YellowItem = 9;
		}
	}
}
