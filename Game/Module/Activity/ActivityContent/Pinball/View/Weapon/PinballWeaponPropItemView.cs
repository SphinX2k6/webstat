using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon
{
	// Token: 0x020065A1 RID: 26017
	public class PinballWeaponPropItemView : GridProxyAbstract<int>
	{
		// Token: 0x0604100B RID: 266251 RVA: 0x010ADFDC File Offset: 0x010AC1DC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604100C RID: 266252 RVA: 0x010AE088 File Offset: 0x010AC288
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			PinballWeaponAttr? pinballWeaponAttrConfigById = ConfigBase<PinballConfig>.Instance.GetPinballWeaponAttrConfigById(data);
			if (pinballWeaponAttrConfigById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.CB;
				string message = "武器属性配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", data);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			PinballPropertyIndex? pinballPropertyIndexConfigById = ConfigBase<PinballConfig>.Instance.GetPinballPropertyIndexConfigById(pinballWeaponAttrConfigById.Value.ProperKey);
			if (pinballPropertyIndexConfigById == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.PinballBattle;
				ELogAuthor author2 = ELogAuthor.CB;
				string message2 = "属性索引配置不存在";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Id", pinballWeaponAttrConfigById.Value.ProperKey);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), pinballPropertyIndexConfigById.Value.Name, Array.Empty<object>());
			string text;
			if (!pinballPropertyIndexConfigById.Value.IsPercent)
			{
				text = pinballWeaponAttrConfigById.Value.ProperVal.ToString();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendFormatted<float>(pinballWeaponAttrConfigById.Value.ProperVal);
				defaultInterpolatedStringHandler.AppendLiteral("%");
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			string newText = text;
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.SetText(newText, true);
			}
			base.TrySetTextureByPath(pinballPropertyIndexConfigById.Value.Icon, base.GetTexture(2), null, null);
		}

		// Token: 0x0604100D RID: 266253 RVA: 0x010AE200 File Offset: 0x010AC400
		public override void Clear()
		{
		}

		// Token: 0x0604100E RID: 266254 RVA: 0x010AE202 File Offset: 0x010AC402
		public override void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x0604100F RID: 266255 RVA: 0x010AE204 File Offset: 0x010AC404
		public override void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06041010 RID: 266256 RVA: 0x010AE206 File Offset: 0x010AC406
		[NullableContext(1)]
		public override object GetKey(int data, int gridIndex)
		{
			return gridIndex;
		}

		// Token: 0x0200C59C RID: 50588
		private enum EPropItemComponent
		{
			// Token: 0x0403CD17 RID: 249111
			PropName,
			// Token: 0x0403CD18 RID: 249112
			PropValue,
			// Token: 0x0403CD19 RID: 249113
			PropIcon,
			// Token: 0x0403CD1A RID: 249114
			PropBg
		}
	}
}
