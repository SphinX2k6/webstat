using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E24 RID: 20004
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseResultResultItem : GridProxyAbstract<ITrapDefenseResultInfo>
	{
		// Token: 0x06033B7A RID: 211834 RVA: 0x00CED0FC File Offset: 0x00CEB2FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033B7B RID: 211835 RVA: 0x00CED1E9 File Offset: 0x00CEB3E9
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<TrapDefenseResultStarItem, ITrapDefenseStarInfo>(base.GetHorizontalLayout(3), new Func<TrapDefenseResultStarItem>(this.CreateStar), null, false, true);
		}

		// Token: 0x06033B7C RID: 211836 RVA: 0x00CED20C File Offset: 0x00CEB40C
		public override void Refresh(ITrapDefenseResultInfo data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(data.Type > ETrapDefenseResultType.Star);
			}
			UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(3);
			if (horizontalLayout != null)
			{
				horizontalLayout.RootUIComp.Get().SetUIActive(data.Type == ETrapDefenseResultType.Star);
			}
			if (data.Type == ETrapDefenseResultType.Star)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "TowerDefense_Ending_GainStar_Text", Array.Empty<object>());
				if (this.StarList.Count == 0)
				{
					int i = 1;
					while (i <= data.Value)
					{
						ITrapDefenseStarInfo trapDefenseStarInfo = new ITrapDefenseStarInfo();
						int num = i;
						int? num2 = data.Total;
						trapDefenseStarInfo.IsAchieve = (num <= num2.GetValueOrDefault() & num2 != null);
						int num3 = i;
						num2 = data.Total;
						bool isNew;
						if (num3 <= num2.GetValueOrDefault() & num2 != null)
						{
							int num4 = i;
							num2 = data.History;
							isNew = (num4 > num2.GetValueOrDefault() & num2 != null);
						}
						else
						{
							isNew = false;
						}
						trapDefenseStarInfo.IsNew = isNew;
						trapDefenseStarInfo.HasPlayed = false;
						int num5 = i;
						num2 = data.Total;
						if (!(num5 <= num2.GetValueOrDefault() & num2 != null))
						{
							goto IL_12F;
						}
						int num6 = i;
						num2 = data.History;
						if (!(num6 > num2.GetValueOrDefault() & num2 != null))
						{
							goto IL_12F;
						}
						int playDelay = this.GetAnimDelay(i - data.History.Value, data.Total.Value - data.History.Value);
						IL_165:
						trapDefenseStarInfo.PlayDelay = playDelay;
						ITrapDefenseStarInfo item2 = trapDefenseStarInfo;
						this.StarList.Add(item2);
						i++;
						continue;
						IL_12F:
						playDelay = 0;
						goto IL_165;
					}
				}
				GenericLayout<TrapDefenseResultStarItem, ITrapDefenseStarInfo> layout = this.Layout;
				if (layout == null)
				{
					return;
				}
				layout.RefreshByData(this.StarList, null, true);
				return;
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "TowerDefense_Ending_GainBdUp_Text", Array.Empty<object>());
				UUIText text = base.GetText(1);
				if (text == null)
				{
					return;
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Value);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				return;
			}
		}

		// Token: 0x06033B7D RID: 211837 RVA: 0x00CED404 File Offset: 0x00CEB604
		public void PlayStarIn()
		{
			if (this.Data.Type != ETrapDefenseResultType.Star)
			{
				return;
			}
			foreach (TrapDefenseResultStarItem trapDefenseResultStarItem in this.Layout.GetLayoutItemList())
			{
				trapDefenseResultStarItem.PlayAnim();
			}
		}

		// Token: 0x06033B7E RID: 211838 RVA: 0x00CED468 File Offset: 0x00CEB668
		public void EndStarAnim()
		{
			foreach (ITrapDefenseStarInfo trapDefenseStarInfo in this.StarList)
			{
				trapDefenseStarInfo.HasPlayed = true;
			}
		}

		// Token: 0x06033B7F RID: 211839 RVA: 0x00CED4BC File Offset: 0x00CEB6BC
		private int GetAnimDelay(int index, int length)
		{
			if (length <= 1 || index <= 1)
			{
				return 0;
			}
			int num = 50;
			int num2 = 150;
			return num + (int)Math.Floor((double)((float)((num2 - num) * (index - 2)) / ((float)(length - 2) * 1f)));
		}

		// Token: 0x06033B80 RID: 211840 RVA: 0x00CED4F8 File Offset: 0x00CEB6F8
		private TrapDefenseResultStarItem CreateStar()
		{
			return new TrapDefenseResultStarItem();
		}

		// Token: 0x0401DF17 RID: 122647
		private GenericLayout<TrapDefenseResultStarItem, ITrapDefenseStarInfo> Layout;

		// Token: 0x0401DF18 RID: 122648
		private ITrapDefenseResultInfo Data;

		// Token: 0x0401DF19 RID: 122649
		private List<ITrapDefenseStarInfo> StarList = new List<ITrapDefenseStarInfo>();

		// Token: 0x0200AD9C RID: 44444
		[NullableContext(0)]
		private class EResult
		{
			// Token: 0x04035E97 RID: 220823
			public const int Title = 0;

			// Token: 0x04035E98 RID: 220824
			public const int Value = 1;

			// Token: 0x04035E99 RID: 220825
			public const int Icon = 2;

			// Token: 0x04035E9A RID: 220826
			public const int StarLayout = 3;

			// Token: 0x04035E9B RID: 220827
			public const int StarItem = 4;

			// Token: 0x04035E9C RID: 220828
			public const int PanelTxt = 5;
		}
	}
}
