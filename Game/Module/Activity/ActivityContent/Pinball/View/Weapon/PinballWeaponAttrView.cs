using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon
{
	// Token: 0x020065A0 RID: 26016
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballWeaponAttrView : UiPanelBase
	{
		// Token: 0x06041006 RID: 266246 RVA: 0x010ADDA4 File Offset: 0x010ABFA4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041007 RID: 266247 RVA: 0x010ADE70 File Offset: 0x010AC070
		protected override void OnStart()
		{
			this.PropLayout = new GenericLayout<PinballWeaponPropItemView, int>(base.GetVerticalLayout(1), new Func<PinballWeaponPropItemView>(this.CreatePropItem), null, false, true);
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06041008 RID: 266248 RVA: 0x010ADEA5 File Offset: 0x010AC0A5
		private PinballWeaponPropItemView CreatePropItem()
		{
			return new PinballWeaponPropItemView();
		}

		// Token: 0x06041009 RID: 266249 RVA: 0x010ADEAC File Offset: 0x010AC0AC
		public void Refresh(PinballWeaponData data)
		{
			GenericLayout<PinballWeaponPropItemView, int> propLayout = this.PropLayout;
			if (propLayout != null)
			{
				propLayout.RefreshByData(data.PropList, null, false);
			}
			PinballWeaponMainEntry? pinballWeaponMainEntryConfigById = ConfigBase<PinballConfig>.Instance.GetPinballWeaponMainEntryConfigById(data.MainEntryId);
			if (pinballWeaponMainEntryConfigById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.CB;
				string message = "武器主词条配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", data.MainEntryId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(3), pinballWeaponMainEntryConfigById.Value.ProperDesc, pinballWeaponMainEntryConfigById.Value.ProperVal());
			PinballWeaponSubEntry? pinballWeaponSubEntryConfigById = ConfigBase<PinballConfig>.Instance.GetPinballWeaponSubEntryConfigById(data.SubEntryId);
			if (pinballWeaponSubEntryConfigById == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.PinballBattle;
				ELogAuthor author2 = ELogAuthor.CB;
				string message2 = "武器副词条配置不存在";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Id", data.SubEntryId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(4), pinballWeaponSubEntryConfigById.Value.ProperDesc, pinballWeaponSubEntryConfigById.Value.ProperVal());
		}

		// Token: 0x0402472A RID: 149290
		protected GenericLayout<PinballWeaponPropItemView, int> PropLayout;

		// Token: 0x0200C59B RID: 50587
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CD11 RID: 249105
			ScrollView,
			// Token: 0x0403CD12 RID: 249106
			PropLayout,
			// Token: 0x0403CD13 RID: 249107
			PropLayoutItem,
			// Token: 0x0403CD14 RID: 249108
			TextMainEntry,
			// Token: 0x0403CD15 RID: 249109
			TextSubEntry
		}
	}
}
