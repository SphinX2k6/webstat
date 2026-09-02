using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005164 RID: 20836
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomEntryItem : GridProxyAbstract<AffixEntry>
	{
		// Token: 0x060359EF RID: 219631 RVA: 0x00D77EC0 File Offset: 0x00D760C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060359F0 RID: 219632 RVA: 0x00D77F8C File Offset: 0x00D7618C
		protected override void OnStart()
		{
			this.PhantomElementItemLayout = new GenericLayout<PhantomElementItem, ElementInfo>(base.GetVerticalLayout(0), new Func<PhantomElementItem>(this.CreateElementItem), null, false, true);
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x060359F1 RID: 219633 RVA: 0x00D77FC0 File Offset: 0x00D761C0
		private PhantomElementItem CreateElementItem()
		{
			return new PhantomElementItem();
		}

		// Token: 0x060359F2 RID: 219634 RVA: 0x00D77FC8 File Offset: 0x00D761C8
		public override void Refresh(AffixEntry data, bool isSelected, int gridIndex)
		{
			this.AffixEntry = data;
			List<ElementInfo> sortElementInfoArrayByCount = this.AffixEntry.GetSortElementInfoArrayByCount(false);
			foreach (ElementInfo elementInfo in sortElementInfoArrayByCount)
			{
				if (elementInfo.ElementId == 9)
				{
					elementInfo.Name = "RoguelikeView_16_Text";
				}
				else
				{
					ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(elementInfo.ElementId);
					if (elementConfig != null)
					{
						elementInfo.Name = elementConfig.Value.Name;
					}
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Rogue_Phantom_Info_Index", new <>z__ReadOnlySingleElementList<object>(gridIndex + 1));
			this.PhantomElementItemLayout.RefreshByData(sortElementInfoArrayByCount, null, false);
		}

		// Token: 0x060359F3 RID: 219635 RVA: 0x00D7809C File Offset: 0x00D7629C
		[NullableContext(2)]
		public void RefreshPreview(Dictionary<int, int> elementDict = null)
		{
			bool flag = true;
			using (List<PhantomElementItem>.Enumerator enumerator = this.PhantomElementItemLayout.GetLayoutItemList().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.RefreshPanel(elementDict))
					{
						flag = false;
					}
				}
			}
			bool flag2 = !this.AffixEntry.IsUnlock.GetValueOrDefault() && flag;
			if (flag2)
			{
				this.PlayComplete();
				this.IsUnlockState = true;
				Singleton<EventSystem>.Instance.Emit(EEventName.RogueTermUnlock);
			}
			else if (this.IsUnlockState)
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName("Disappear", false, null, false);
				this.IsUnlockState = false;
			}
			base.GetItem(2).SetUIActive(flag2);
			UUIText text = base.GetText(3);
			RoguelikeModel instance = ModelBase<RoguelikeModel>.Instance;
			if (instance != null && instance.GetDescModel() == EDescModel.SIMPLE)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.AffixEntry.GetAffixDesc(), Array.Empty<object>());
			}
			else
			{
				RoguelikeConfig instance2 = ConfigBase<RoguelikeConfig>.Instance;
				RogueAffix? rogueAffix = (instance2 != null) ? instance2.GetRogueAffixConfig(this.AffixEntry.Id.Value) : null;
				if (rogueAffix != null)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.AffixEntry.GetAffixDesc(), rogueAffix.Value.AffixDescParam());
				}
			}
			UUIItem uuiitem = text;
			bool bUseChangeColor = flag2;
			FColor? fcolor;
			FColor? fcolor2;
			if (text == null)
			{
				fcolor = null;
				fcolor2 = fcolor;
			}
			else
			{
				fcolor2 = new FColor?(text.changeColor);
			}
			fcolor = fcolor2;
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x060359F4 RID: 219636 RVA: 0x00D78224 File Offset: 0x00D76424
		private void PlayComplete()
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Complete", false, null, false);
		}

		// Token: 0x0401ECB8 RID: 126136
		private AffixEntry AffixEntry;

		// Token: 0x0401ECB9 RID: 126137
		private GenericLayout<PhantomElementItem, ElementInfo> PhantomElementItemLayout;

		// Token: 0x0401ECBA RID: 126138
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401ECBB RID: 126139
		private bool IsUnlockState;

		// Token: 0x0200B112 RID: 45330
		[NullableContext(0)]
		private class EPhantomEntryItemCom
		{
			// Token: 0x04036EC8 RID: 224968
			public const int PhantomElementItemLayout = 0;

			// Token: 0x04036EC9 RID: 224969
			public const int PhantomElementItem = 1;

			// Token: 0x04036ECA RID: 224970
			public const int DescPanel = 2;

			// Token: 0x04036ECB RID: 224971
			public const int DescText = 3;

			// Token: 0x04036ECC RID: 224972
			public const int IndexText = 4;
		}
	}
}
