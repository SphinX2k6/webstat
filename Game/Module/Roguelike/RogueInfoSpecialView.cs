using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005173 RID: 20851
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueInfoSpecialView : UiPanelBase
	{
		// Token: 0x06035A7F RID: 219775 RVA: 0x00D7A4A4 File Offset: 0x00D786A4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035A80 RID: 219776 RVA: 0x00D7A4EC File Offset: 0x00D786EC
		protected override void OnBeforeCreateImplement()
		{
			this.UiViewSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiViewSequence);
		}

		// Token: 0x06035A81 RID: 219777 RVA: 0x00D7A506 File Offset: 0x00D78706
		protected override void OnStart()
		{
			this.SpecialItemLayout = new GenericLayout<RoguelikeSelectSpecialItem, RogueGainEntry>(base.GetHorizontalLayout(0), new Func<RoguelikeSelectSpecialItem>(this.CreateSpecialItem), null, false, true);
		}

		// Token: 0x06035A82 RID: 219778 RVA: 0x00D7A52C File Offset: 0x00D7872C
		public void Refresh(List<RogueGainEntry> specialDataList)
		{
			List<RogueGainEntry> list = specialDataList.ToList<RogueGainEntry>();
			list.Sort(new Comparison<RogueGainEntry>(this.SortSpecialItem));
			this.SpecialItemLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06035A83 RID: 219779 RVA: 0x00D7A560 File Offset: 0x00D78760
		private int SortSpecialItem(RogueGainEntry a, RogueGainEntry b)
		{
			RougeMiraclecreation? roguelikeSpecialConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguelikeSpecialConfig(a.ConfigId);
			RougeMiraclecreation? roguelikeSpecialConfig2 = ConfigBase<RoguelikeConfig>.Instance.GetRoguelikeSpecialConfig(b.ConfigId);
			RougeMiraclecreationColor? rougeMiraclecreationColor = (roguelikeSpecialConfig != null) ? ConfigBase<RoguelikeConfig>.Instance.GetRoguelikeMiraclecreationColorConfig(roguelikeSpecialConfig.Value.ColorType) : null;
			RougeMiraclecreationColor? rougeMiraclecreationColor2 = (roguelikeSpecialConfig2 != null) ? ConfigBase<RoguelikeConfig>.Instance.GetRoguelikeMiraclecreationColorConfig(roguelikeSpecialConfig2.Value.ColorType) : null;
			int num = (rougeMiraclecreationColor != null) ? rougeMiraclecreationColor.GetValueOrDefault().Sort : 0;
			return ((rougeMiraclecreationColor2 != null) ? rougeMiraclecreationColor2.GetValueOrDefault().Sort : 0) - num;
		}

		// Token: 0x06035A84 RID: 219780 RVA: 0x00D7A62C File Offset: 0x00D7882C
		private RoguelikeSelectSpecialItem CreateSpecialItem()
		{
			return new RoguelikeSelectSpecialItem(new Action<RoguelikeSelectSpecialItem, RogueGainEntry>(this.OnClickRoguelikeSpecialItem));
		}

		// Token: 0x06035A85 RID: 219781 RVA: 0x00D7A63F File Offset: 0x00D7883F
		private void OnClickRoguelikeSpecialItem(RoguelikeSelectSpecialItem item, RogueGainEntry data)
		{
			item.SetSelect(false);
			UiManager instance = Singleton<UiManager>.Instance;
			EUiViewName roguelikeSpecialDetailView = EUiViewName.RoguelikeSpecialDetailView;
			object[] array = new object[2];
			array[0] = data;
			instance.OpenView(roguelikeSpecialDetailView, array, null);
		}

		// Token: 0x0401ECE3 RID: 126179
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoguelikeSelectSpecialItem, RogueGainEntry> SpecialItemLayout;

		// Token: 0x0401ECE4 RID: 126180
		[Nullable(2)]
		public UiBehaviorLevelSequence UiViewSequence;

		// Token: 0x0200B128 RID: 45352
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04036F2B RID: 225067
			public const int SpecialItemLayout = 0;
		}
	}
}
