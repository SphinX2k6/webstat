using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065BE RID: 26046
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DamageLayoutItemView : GridProxyAbstract<IDamageLayoutItemData>
	{
		// Token: 0x0604116E RID: 266606 RVA: 0x010B352C File Offset: 0x010B172C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604116F RID: 266607 RVA: 0x010B365C File Offset: 0x010B185C
		[NullableContext(1)]
		public override void Refresh(IDamageLayoutItemData data, bool isSelected, int gridIndex)
		{
			PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(data.RoleId);
			if (pinballRoleConfigById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.CB;
				string message = "星弹奇游角色配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleId", data.RoleId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(pinballRoleConfigById.Value.RoleId);
			if (roleConfig == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.PinballBattle;
				ELogAuthor author2 = ELogAuthor.CB;
				string message2 = "角色表角色配置不存在";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("RoleId", data.RoleId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			base.TrySetTextureByPath(pinballRoleConfigById.Value.MiddleIcon, base.GetTexture(1), null, null);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), roleConfig.Value.Name, Array.Empty<object>());
			UUIText text = base.GetText(7);
			if (text != null)
			{
				text.SetText(((int)Math.Round((double)(data.Damage * 100f))).ToString(), true);
			}
			if (data.IsWin)
			{
				UUISprite sprite = base.GetSprite(4);
				if (sprite != null)
				{
					sprite.SetFillAmount(data.Damage);
				}
			}
			else
			{
				UUISprite sprite2 = base.GetSprite(5);
				if (sprite2 != null)
				{
					sprite2.SetFillAmount(data.Damage);
				}
			}
			UUISprite sprite3 = base.GetSprite(4);
			if (sprite3 != null)
			{
				sprite3.SetUIActive(data.IsWin);
			}
			UUISprite sprite4 = base.GetSprite(5);
			if (sprite4 != null)
			{
				sprite4.SetUIActive(!data.IsWin);
			}
			UUISprite sprite5 = base.GetSprite(0);
			FColor? fcolor;
			if (sprite5 != null)
			{
				bool bUseChangeColor = !data.IsWin;
				fcolor = new FColor?(base.GetSprite(0).changeColor);
				sprite5.SetChangeColor(bUseChangeColor, fcolor);
			}
			UUIText text2 = base.GetText(2);
			if (text2 != null)
			{
				bool bUseChangeColor2 = !data.IsWin;
				fcolor = new FColor?(base.GetText(2).changeColor);
				text2.SetChangeColor(bUseChangeColor2, fcolor);
			}
			UUISprite sprite6 = base.GetSprite(3);
			if (sprite6 != null)
			{
				bool bUseChangeColor3 = !data.IsWin;
				fcolor = new FColor?(base.GetSprite(3).changeColor);
				sprite6.SetChangeColor(bUseChangeColor3, fcolor);
			}
			UUIText text3 = base.GetText(6);
			if (text3 != null)
			{
				bool bUseChangeColor4 = !data.IsWin;
				fcolor = new FColor?(base.GetText(6).changeColor);
				text3.SetChangeColor(bUseChangeColor4, fcolor);
			}
			UUIText text4 = base.GetText(7);
			if (text4 == null)
			{
				return;
			}
			bool bUseChangeColor5 = !data.IsWin;
			fcolor = new FColor?(base.GetText(7).changeColor);
			text4.SetChangeColor(bUseChangeColor5, fcolor);
		}

		// Token: 0x0200C5C3 RID: 50627
		private enum EDamageLayoutItemComponent
		{
			// Token: 0x0403CDEC RID: 249324
			SpriteBg,
			// Token: 0x0403CDED RID: 249325
			HeadTexture,
			// Token: 0x0403CDEE RID: 249326
			TextName,
			// Token: 0x0403CDEF RID: 249327
			SpriteBarBg,
			// Token: 0x0403CDF0 RID: 249328
			SpriteSuccessBar,
			// Token: 0x0403CDF1 RID: 249329
			SpriteFailBar,
			// Token: 0x0403CDF2 RID: 249330
			TextDamageProgressPercent,
			// Token: 0x0403CDF3 RID: 249331
			TextDamageProgress
		}
	}
}
